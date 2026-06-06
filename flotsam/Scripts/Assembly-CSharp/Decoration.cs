using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using I2.Loc;
using PajamaLlama.Extensions;
using UnityEngine;

public class Decoration : SceneBehaviour, IPersistentReference, ISelectable, IPanelContext, IOutlineRenderControllerProvider, IConstructible, IPathfindingNodeProvider
{
	private const float FLOTSAM_UNIT = 2f;

	[SerializeField]
	private Inventory _inventory;

	[SerializeField]
	private BoxCollider _collider;

	[SerializeField]
	private OutlineRendererComponent _outlineRenderer;

	[SerializeField]
	private AudioClipProperties _buildStateChangeSFX;

	public Action<Decoration> OnSalvageDone;

	private static Dictionary<DecorationProperties, Decoration> _prefabsWithProperties = new Dictionary<DecorationProperties, Decoration>();

	private bool _isPrefab;

	private readonly List<IDecorationExtendable> _decorationExtendables = new List<IDecorationExtendable>();

	private string _cachedDescription;

	public string Name
	{
		get
		{
			if (CustomName == null)
			{
				return Properties.Name;
			}
			return CustomName;
		}
		set
		{
			CustomName = (IsDefaultName(value) ? null : value);
		}
	}

	public string CustomName { get; private set; }

	public DecorationSlots Parent { get; private set; }

	public VisualPrefab SpawnedVisual { get; private set; }

	public IDecorationBehaviour Behaviour { get; private set; }

	public OutlineRendererComponent OutlineRenderer => _outlineRenderer;

	OutlineRenderController IOutlineRenderControllerProvider.OutlineController => SpawnedVisual.GetComponentInChildren<OutlineRenderController>();

	public DecorationProperties Properties { get; private set; }

	PlaceableProperties IConstructible.Properties => Properties;

	public DecorationProperties.Turns Turn { get; private set; }

	public int Visual { get; private set; }

	public int[] SlotIndices { get; private set; }

	public Inventory Inventory => _inventory;

	public ConstructionHandler ConstructionHandler { get; } = new ConstructionHandler();

	public ConstructibleStatus StatusHolder { get; } = new ConstructibleStatus();

	ObjectType ISelectable.ObjectType => ObjectType.Decoration;

	GameObject ISelectable.RelatedGameObject => base.gameObject;

	PanelID IPanelContext.PanelID => PanelID.DecorationPanel;

	public int AssignmentLimit
	{
		get
		{
			return ConstructionHandler.AssignmentLimit;
		}
		set
		{
			ConstructionHandler.AssignmentLimit = value;
		}
	}

	public Community Community
	{
		get
		{
			if (!(Parent != null) || !(Parent.Buildable != null))
			{
				return null;
			}
			return Parent.Buildable.Community;
		}
	}

	public int PersistentIndex { get; set; } = -1;

	GameObject IConstructible.gameObject => base.gameObject;

	Transform IPathfindingNodeProvider.transform => base.transform;

	protected override void Awake()
	{
		base.Awake();
		Behaviour = GetComponent<IDecorationBehaviour>();
		_decorationExtendables.AddRange(GetComponentsInChildren<IDecorationExtendable>());
	}

	private void Start()
	{
		UpdateBuildPhase(ConstructionHandler.BuildPhase);
		ConstructionHandler.Start();
	}

	public void Initialize(DecorationSlots parent, DecorationProperties properties, DecorationProperties.Turns turn, int visual, int[] slotIndices, bool instantFreeBuild = false)
	{
		if (instantFreeBuild || ResourceManager.AreCommunityResourcesAvailable(properties.RequiredResources))
		{
			InitializeThis(parent, properties, turn, visual, slotIndices);
			ConstructionHandler.StartBuilding(instantFreeBuild);
			DecorationEvent.DispatchPlaced(this);
		}
		else
		{
			Debug.LogError("Unable to initialize Decoration \"" + base.name + "\", the required resources are not available in the inventory");
		}
	}

	public void RotateVisualPrefab()
	{
		SpawnedVisual.transform.Reset();
		SpawnedVisual.transform.rotation = Parent.transform.rotation * Properties.TurnToRotation(Turn);
	}

	public void Upgrade(DecorationSlots parent)
	{
		Parent = parent;
		foreach (IDecorationExtendable decorationExtendable in _decorationExtendables)
		{
			decorationExtendable.Upgrade(this);
		}
	}

	public void StartUpgrade()
	{
	}

	public void Restore(DecorationSlots parent, DecorationProperties properties, DecorationProperties.Turns turn, int visual, int[] slotIndices)
	{
		InitializeThis(parent, properties, turn, visual, slotIndices);
	}

	public void RestoreConstruction(int assignmentLimit, BuildPhase buildPhase, float progress)
	{
		ConstructionHandler.Restore(assignmentLimit, buildPhase, progress);
	}

	public void RestoreConstructionReferences(Project assignedProject)
	{
		ConstructionHandler.RestoreReferences(assignedProject);
	}

	private void InitializeThis(DecorationSlots parent, DecorationProperties properties, DecorationProperties.Turns turn, int visual, int[] slotIndices)
	{
		Parent = parent;
		Properties = properties;
		Turn = turn;
		Visual = ((properties.VisualPrefabs.Length > visual) ? visual : 0);
		SlotIndices = slotIndices;
		_inventory.GetOrAddSubInventory(SubInventoryType.Resources);
		SpawnedVisual = UnityEngine.Object.Instantiate(properties.VisualPrefabs[Visual], base.transform);
		SpawnedVisual.OverrideBuildStateChangeSFX(_buildStateChangeSFX);
		RotateVisualPrefab();
		if ((bool)SpawnedVisual.SelectionLink)
		{
			SpawnedVisual.SelectionLink.SetObjectToSelect(base.gameObject, ObjectType.Decoration, changeInitialObject: true);
			SpawnedVisual.SelectionLink.SetOnSelectedListener(OnSelected);
		}
		foreach (IDecorationExtendable decorationExtendable in _decorationExtendables)
		{
			decorationExtendable.Initialize(this);
		}
		if (!Properties.RequiredResources.IsNullOrEmpty())
		{
			_inventory.Initialize(InventoryType.Decoration);
			_inventory.InitializeComposition(properties.RequiredResources);
			if (_collider != null)
			{
				_collider.size = new Vector3((float)Properties.Width * 2f, _collider.size.y, (float)properties.Depth * 2f);
				if (!properties.IsSelectable)
				{
					_collider.enabled = false;
				}
			}
		}
		if (!ConstructionHandler.IsInitialized)
		{
			StatusHolder.Initialize(GetComponentInChildren<WorldIconHandler>(includeInactive: true));
			ConstructionHandler.Initialize(this);
		}
		ConstructionHandler.SetProgress(0f);
	}

	public void AddToConstructionGraph()
	{
		if (Parent.SlotsAreOutOfBounds)
		{
			_inventory.Target.SetOverride(Parent.Buildable.Inventory.Target);
			return;
		}
		Target target = _inventory.Target;
		target.PrimaryMarker.SetParent(Parent.Buildable.Inventory.Target.PrimaryMarker);
		target.PrimaryMarker.IsOutOfBounds = Parent.SlotsAreOutOfBounds;
		target.PrimaryMarker.AddToConstructionGraph();
	}

	public void RemoveFromConstructionGraph()
	{
		if (Parent.SlotsAreOutOfBounds)
		{
			_inventory.Target.SetOverride(null);
		}
		else
		{
			_inventory.Target.PrimaryMarker.RemoveFromConstructionGraph();
		}
	}

	public void SetColliderActive(bool active)
	{
		if (_collider != null)
		{
			_collider.enabled = active;
		}
	}

	private void OnSelected(bool playSelectionSound = true)
	{
		if (playSelectionSound)
		{
			AudioManager.PlayOneShot(Properties.FMODEventReference_Select);
		}
		Parent.SetSelectedDecoration(this);
	}

	public void OnRemoveCursorEnter()
	{
		if (ConstructionHandler.CanBeDeconstructed(out var _) && !ConstructionHandler.CancelConstructionAfterHaul)
		{
			int[] slotIndices = SlotIndices;
			foreach (int num in slotIndices)
			{
				Parent.Slots[num].SetOutlineActive(value: true);
			}
		}
	}

	public void OnRemoveCursorExit()
	{
		int[] slotIndices = SlotIndices;
		foreach (int num in slotIndices)
		{
			Parent.Slots[num].SetOutlineActive(value: false);
		}
	}

	public void Remove(bool immediately = false)
	{
		if (_isPrefab)
		{
			return;
		}
		OnRemoveCursorExit();
		foreach (IDecorationExtendable decorationExtendable in _decorationExtendables)
		{
			decorationExtendable.OnDeconstruct();
		}
		if (immediately)
		{
			RemoveConstructible();
		}
		else
		{
			ConstructionHandler.TryToSalvage();
		}
	}

	public void RemoveConstructible()
	{
		List<Item> list = Inventory.ReturnIncomingItems(SubInventoryType.Composition);
		for (int num = list.Count - 1; num >= 0; num--)
		{
			Item item = list[num];
			if (item.Project != null)
			{
				item.Project.RemoveItem(item);
			}
			_inventory.UnreserveIncomingItem(item);
		}
		foreach (IDecorationExtendable decorationExtendable in _decorationExtendables)
		{
			decorationExtendable.Remove();
		}
		RemoveFromConstructionGraph();
		SetSlotOutlinesActive(active: false, Color.white);
		OnSalvageDone.SafeInvoke(this);
		if ((bool)Parent)
		{
			Parent.RemoveDecorationImmediate(this);
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void FinishConstruction(bool restored = false)
	{
		if (Behaviour != null)
		{
			Behaviour.Initialize();
		}
		foreach (IDecorationExtendable decorationExtendable in _decorationExtendables)
		{
			decorationExtendable.Finish();
		}
		if (!restored)
		{
			DecorationEvent.DispatchConstructed(this);
		}
	}

	void IConstructible.SetProgress(float progress)
	{
		if (SpawnedVisual != null)
		{
			SpawnedVisual.SetProgress(progress);
		}
	}

	public void Select()
	{
		DecorationEvent.DispatchSelected(this);
		GameManager.UIManager.DisplayPanel(this);
	}

	public void Deselect()
	{
		GameManager.UIManager.ClosePanel(PanelID.DecorationPanel);
		OutlineRenderer.ResetHighlightOutline();
		Selector.Deselect(GetComponentsInChildren<SelectionLink>());
	}

	public string GetDescription()
	{
		if (!_cachedDescription.IsNullOrEmpty())
		{
			return _cachedDescription;
		}
		_cachedDescription = Properties.Description;
		_cachedDescription = Regex.Replace(_cachedDescription, "%NAME%", "<b>" + Properties.Name + "</b>", RegexOptions.IgnoreCase);
		IDecorationExtendable[] componentsInChildren = GetComponentsInChildren<IDecorationExtendable>();
		foreach (IDecorationExtendable decorationExtendable in componentsInChildren)
		{
			_cachedDescription = decorationExtendable.GetDescription(_cachedDescription);
		}
		return _cachedDescription;
	}

	public void AddSubInventory(SubInventoryType subInventory)
	{
		if (!(Inventory == null) && !Inventory.HasSubInventory(subInventory))
		{
			Inventory.GetOrAddSubInventory(subInventory);
		}
	}

	void IConstructible.OnBuildPhaseUpdated(BuildPhase buildPhase)
	{
		UpdateBuildPhase(buildPhase);
	}

	private void UpdateBuildPhase(BuildPhase buildPhase)
	{
		switch (buildPhase)
		{
		case BuildPhase.HaulTo:
			SetSlotOutlinesActive(active: true, Color.yellow);
			break;
		case BuildPhase.HaulFrom:
			SetSlotOutlinesActive(active: true, Color.red);
			break;
		default:
			SetSlotOutlinesActive(active: false, Color.white);
			break;
		}
	}

	private void SetSlotOutlinesActive(bool active, Color color)
	{
	}

	public bool IsInConstruction()
	{
		if (ConstructionHandler != null)
		{
			return ConstructionHandler.BuildPhase != BuildPhase.Finished;
		}
		return false;
	}

	public Decoration GetPrefabWithProperties(DecorationProperties properties)
	{
		if (_prefabsWithProperties.TryGetValue(properties, out var value))
		{
			return value;
		}
		value = UnityEngine.Object.Instantiate(properties.DecorationPrefab);
		value.name = $"{properties} (DecorationPrefab)";
		value.Properties = properties;
		value._isPrefab = true;
		value.gameObject.SetActive(value: false);
		UnityEngine.Object.DontDestroyOnLoad(value.gameObject);
		_prefabsWithProperties.Add(properties, value);
		return value;
	}

	public T GetExtendable<T>() where T : Component, IDecorationExtendable
	{
		foreach (IDecorationExtendable decorationExtendable in _decorationExtendables)
		{
			if (decorationExtendable is T result)
			{
				return result;
			}
		}
		return null;
	}

	public bool TryGetExtendable<T>(out T extendable) where T : Component, IDecorationExtendable
	{
		extendable = GetExtendable<T>();
		return extendable != null;
	}

	private bool IsDefaultName(string name)
	{
		LocalizedString nameLocalizedString = Properties.NameLocalizedString;
		if (!(name == Properties.Name))
		{
			return name == LocalizationManager.GetTranslation(nameLocalizedString.mTerm, !nameLocalizedString.mRTL_IgnoreArabicFix, nameLocalizedString.mRTL_MaxLineLength, !nameLocalizedString.mRTL_ConvertNumbers, applyParameters: true, null, "English");
		}
		return true;
	}

	bool IConstructible.CanBeDeconstructed(out LocalizedString error)
	{
		foreach (IDecorationExtendable decorationExtendable in _decorationExtendables)
		{
			if (!decorationExtendable.CanBeDeconstructed())
			{
				error = Properties.CantDeconstructTooltip;
				return false;
			}
		}
		error = GameSettings.Instance.BuildableSettings.DeconstructionTooltip;
		return true;
	}

	public virtual bool IsDraggable()
	{
		return ConstructionHandler.AssignedProject == null;
	}

	public PathfindingNode ReturnPathfindingNode(Navigator navigator = null)
	{
		if (Parent.SlotsAreOutOfBounds)
		{
			ReturnPathfindingNode(Parent.Buildable.Inventory.Target);
		}
		else if ((bool)_inventory && (bool)_inventory.Target)
		{
			ReturnPathfindingNode(_inventory.Target);
		}
		return null;
	}

	private PathfindingNode ReturnPathfindingNode(Target target)
	{
		if ((bool)target && (bool)target.PrimaryMarker && target.PrimaryMarker.Node != null)
		{
			return target.PrimaryMarker.Node;
		}
		return target.ReturnNode(Graph.Type.Constructions);
	}
}
