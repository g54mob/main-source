using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using PajamaLlama.Extensions;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.Events;

public class DecorationSlots : SceneBehaviour, IBuildableExtendable, IPersistentReference
{
	[Serializable]
	public class PersistentData : BuildableExtendablePersistentData<DecorationSlots>
	{
		[Serializable]
		private struct Slot
		{
			public int Index;

			public int DecorationIndex;

			[OptionalField(VersionAdded = 2)]
			public int Visual;

			public Quaternion Rotation;

			public Slot(DecorationSlot slot, int index)
			{
				Index = index;
				DecorationIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(slot.Decoration);
				Visual = slot.Visual;
				Rotation = slot.Rotation;
			}

			public void Restore(DecorationSlots decorationSlots)
			{
				if (Index >= 0 && decorationSlots.Slots.Length > Index && GameManager.PersistenceManager.TryReturnPropertiesReference<DecorationProperties>(DecorationIndex, out var reference))
				{
					decorationSlots.AddDecoration(reference, reference.RotationToTurn(Rotation), Visual, new int[1] { Index });
				}
			}
		}

		[Serializable]
		public class DecorationPersistentData : PersistentReference<Decoration>
		{
			public int PropertiesIndex;

			public DecorationProperties.Turns Turn;

			public int Visual;

			public int[] SlotIndices;

			public SubInventoryPersistentData Composition;

			[OptionalField(VersionAdded = 4)]
			private readonly string _customName;

			[OptionalField(VersionAdded = 3)]
			private readonly IDecoBehaviourPersistentData _behaviourData;

			[OptionalField(VersionAdded = 5)]
			private readonly BuildPhase _buildPhase = BuildPhase.Finished;

			[OptionalField(VersionAdded = 5)]
			private readonly PersistentReference<Project>.Reference _assignedProject;

			[OptionalField(VersionAdded = 5)]
			private readonly int _assignmentLimit = 1;

			[OptionalField(VersionAdded = 5)]
			private readonly InventoryPersistentData _inventory;

			[OptionalField(VersionAdded = 2)]
			public SubInventoryPersistentData Export;

			[OptionalField(VersionAdded = 2)]
			public float WaterConsumed;

			public DecorationPersistentData(Decoration decoration)
				: base(decoration)
			{
				PropertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(decoration.Properties);
				Turn = decoration.Turn;
				Visual = decoration.Visual;
				SlotIndices = decoration.SlotIndices;
				Composition = SubInventoryPersistentData.Get(decoration.Inventory, SubInventoryType.Composition);
				_buildPhase = decoration.ConstructionHandler.BuildPhase;
				_assignedProject = decoration.ConstructionHandler.AssignedProject;
				_assignmentLimit = decoration.AssignmentLimit;
				_inventory = new InventoryPersistentData(decoration.Inventory);
				_customName = decoration.CustomName;
				if (base.Instance.Behaviour != null)
				{
					_behaviourData = base.Instance.Behaviour.GetPersistentData();
				}
			}

			public void Restore(DecorationSlots decorationSlots)
			{
				base.Restore();
				if (!GameManager.PersistenceManager.TryReturnPropertiesReference<DecorationProperties>(PropertiesIndex, out var reference))
				{
					return;
				}
				base.Instance = UnityEngine.Object.Instantiate(reference.DecorationPrefab, decorationSlots._decorationParent);
				base.Instance.Restore(decorationSlots, reference, Turn, Visual, SlotIndices);
				if (Composition != null)
				{
					Composition.Restore(base.Instance.Inventory);
				}
				decorationSlots.AddDecoration(base.Instance, SlotIndices);
				if (!_customName.IsNullOrEmpty())
				{
					base.Instance.Name = _customName;
				}
				if (_behaviourData != null && base.Instance.TryGetComponent<IDecorationBehaviour>(out var component))
				{
					_behaviourData.Restore(component, reference);
				}
				else if (PersistenceManager.DoesSaveInfoVersionComeBefore(0, 8, 6))
				{
					if (Export != null)
					{
						Export.Restore(base.Instance.Inventory);
					}
					if (base.Instance.TryGetComponent<CropDecorationBehaviour>(out var component2))
					{
						component2.Initialize();
						component2.RestoreCrop(WaterConsumed);
					}
				}
				if (_inventory != null)
				{
					_inventory.Restore(base.Instance.Inventory, base.Instance.gameObject);
				}
				BuildPhase buildPhase = _buildPhase;
				float progress = base.Instance.Inventory.ReturnCompositionProgress();
				base.Instance.RestoreConstruction(_assignmentLimit, buildPhase, progress);
			}

			public void RestoreReferences()
			{
				if (_behaviourData != null)
				{
					_behaviourData.RestoreReferences();
				}
				if (_assignedProject != null && _assignedProject.TryReturnInstance(out var reference))
				{
					base.Instance.RestoreConstructionReferences(reference);
				}
			}

			public void PopulateReferences()
			{
				if (_behaviourData != null)
				{
					_behaviourData.PopulateReferences();
				}
			}
		}

		private Slot[] _decorationSlots;

		[OptionalField(VersionAdded = 3)]
		private DecorationPersistentData[] _decorations;

		public PersistentData(DecorationSlots reference)
			: base(reference)
		{
			base.Instance = reference;
			_decorations = ReturnDecorationPersistentData();
		}

		public override void RestoreData(Buildable buildable)
		{
			if (!buildable.TryGetComponent<DecorationSlots>(out var component))
			{
				return;
			}
			base.Instance = component;
			if (!_decorationSlots.IsNullOrEmpty())
			{
				Slot[] decorationSlots = _decorationSlots;
				foreach (Slot slot in decorationSlots)
				{
					slot.Restore(base.Instance);
				}
			}
			if (!_decorations.IsNullOrEmpty())
			{
				DecorationPersistentData[] decorations = _decorations;
				for (int i = 0; i < decorations.Length; i++)
				{
					decorations[i].Restore(base.Instance);
				}
			}
		}

		public override void RestoreReferences()
		{
			if (!_decorations.IsNullOrEmpty())
			{
				DecorationPersistentData[] decorations = _decorations;
				for (int i = 0; i < decorations.Length; i++)
				{
					decorations[i].RestoreReferences();
				}
			}
		}

		public override void PopulateReferences()
		{
			if (!_decorations.IsNullOrEmpty())
			{
				DecorationPersistentData[] decorations = _decorations;
				for (int i = 0; i < decorations.Length; i++)
				{
					decorations[i].PopulateReferences();
				}
			}
		}

		private DecorationPersistentData[] ReturnDecorationPersistentData()
		{
			if (base.Instance.Decorations.Count == 0)
			{
				return null;
			}
			using ListPool<DecorationPersistentData>.List list = ListPool<DecorationPersistentData>.Get(32);
			int count = base.Instance.Decorations.Count;
			for (int i = 0; i < count; i++)
			{
				Decoration decoration = base.Instance.Decorations[i];
				if ((bool)decoration && (bool)decoration.Properties)
				{
					list.Add(new DecorationPersistentData(decoration));
				}
			}
			return list.IsNullOrEmpty() ? null : list.ToArray();
		}
	}

	[SerializeField]
	private DecorationType _acceptedDecorationTypes;

	[SerializeField]
	private int _width = 1;

	[SerializeField]
	private int _height = 1;

	[SerializeField]
	[Tooltip("The DecorationSlot instances linked to this DecorationSlots component. When the list is empty the DecorationSlot instances will be retrieved from the VisualPrfab using GetComponentsInChildren.")]
	private DecorationSlot[] _decorationSlots;

	[SerializeField]
	private Transform _decorationParent;

	[SerializeField]
	[Tooltip("If it is not guaranteed that all decoration slots are connected to the construction graph toggle this on. (e.g. houses)")]
	private bool _slotsAreOutOfBounds;

	public Action<Decoration> OnDecorationAdded;

	public Action<Decoration> OnDecorationRemoved;

	private static readonly InventoryAuditor s_auditor = new InventoryAuditor();

	private bool _decorationInventoryUpdated;

	private bool _isPlacementAllowed = true;

	public UnityEvent DecorationInventoryUpdated { get; } = new UnityEvent();

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public int PersistentIndex { get; set; }

	public int Width => _width;

	public int Height => _height;

	public DecorationSlot[] Slots { get; private set; }

	public List<Decoration> Decorations { get; } = new List<Decoration>();

	public int BeautyScore { get; private set; }

	public Decoration SelectedDecoration { get; private set; }

	public bool SlotsAreOutOfBounds => _slotsAreOutOfBounds;

	private void Start()
	{
		DisablePlacementMode();
		OnRemoveDecoToolDisabled();
	}

	private void Update()
	{
		foreach (InventoryAuditor.CountedItem countedItem in ReturnAuditorCount().CountedItems)
		{
			if (countedItem.UnreservedCount != 0 && !Buildable.Community.Inventory.ReturnFitsItemWithProperties(countedItem.ItemProperties))
			{
				Buildable.AddMalfunction(GameManager.Settings.BuildableSettings.ErrorResourceProviderBlocked);
				return;
			}
		}
		Buildable.RemoveMalfunction(GameManager.Settings.BuildableSettings.ErrorResourceProviderBlocked);
	}

	private void LateUpdate()
	{
		if (_decorationInventoryUpdated)
		{
			_decorationInventoryUpdated = false;
			DecorationInventoryUpdated.Invoke();
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.RemoveDecorationToolEnabled, OnRemoveDecoToolEnabled);
		GameEventDispatcher.RemoveListener(GameEventType.RemoveDecorationToolDisabled, OnRemoveDecoToolDisabled);
	}

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		if (_decorationSlots.IsNullOrEmpty())
		{
			Slots = buildable.SpawnedVisual.GetComponentsInChildren<DecorationSlot>(includeInactive: true);
		}
		else
		{
			Slots = _decorationSlots;
		}
		GameEventDispatcher.AddListener(GameEventType.RemoveDecorationToolEnabled, OnRemoveDecoToolEnabled);
		GameEventDispatcher.AddListener(GameEventType.RemoveDecorationToolDisabled, OnRemoveDecoToolDisabled);
	}

	public void SetPlacementAllowed(bool allowed)
	{
		_isPlacementAllowed = allowed;
	}

	public bool TryEnablePlacementMode(DecorationProperties decorationProperties)
	{
		if (ReturnCanPlaceDecoration(decorationProperties))
		{
			DecorationSlot[] slots = Slots;
			for (int i = 0; i < slots.Length; i++)
			{
				slots[i].EnablePlacementOutline(decorationProperties);
			}
			return true;
		}
		return false;
	}

	public void DisablePlacementMode()
	{
		DecorationSlot[] slots = Slots;
		for (int i = 0; i < slots.Length; i++)
		{
			slots[i].SetOutlineActive(value: false);
		}
	}

	public void DisconnectEnergyPoles()
	{
		if (Decorations.IsNullOrEmpty())
		{
			return;
		}
		using ListPool<EnergyGridConnector>.List list = ListPool<EnergyGridConnector>.Get(Decorations.Count);
		foreach (Decoration decoration in Decorations)
		{
			if (decoration.TryGetExtendable<EnergyGridPole>(out var extendable) && extendable.Connector != null)
			{
				list.Add(extendable.Connector);
			}
		}
		foreach (EnergyGridConnector item in list)
		{
			for (int num = item.Connections.Length - 1; num >= 0; num--)
			{
				EnergyGridConnector energyGridConnector = item.Connections[num];
				if (energyGridConnector != null && !list.Contains(energyGridConnector))
				{
					EnergyGrid.Disconnect(item, energyGridConnector);
				}
			}
		}
	}

	public void SetSlotsOutlineColor(List<int> indices, Color color)
	{
		foreach (int index in indices)
		{
			Slots[index].SetOutlineColor(color);
		}
	}

	public void ResetSlotsOutlineColor()
	{
		DecorationSlot[] slots = Slots;
		for (int i = 0; i < slots.Length; i++)
		{
			slots[i].ResetOutlineColor();
		}
	}

	public Decoration AddDecoration(DecorationProperties decorationProperties, DecorationProperties.Turns turn, int visual, List<int> slotIndices, bool instantFreeBuild = false)
	{
		AudioManager.PlayOneShot(decorationProperties.FMODEventReference_Place);
		return AddDecoration(decorationProperties, turn, visual, slotIndices.ToArray(), instantFreeBuild);
	}

	public Decoration AddDecoration(DecorationProperties decorationProperties, DecorationProperties.Turns turn, int visual, int[] slotIndices, bool instantFreeBuild = false)
	{
		Decoration decoration = UnityEngine.Object.Instantiate(decorationProperties.DecorationPrefab);
		decoration.Initialize(this, decorationProperties, turn, visual, slotIndices, instantFreeBuild);
		AddDecoration(decoration, slotIndices);
		return decoration;
	}

	private void AddDecoration(Decoration decoration, int[] slotIndices)
	{
		decoration.transform.SetParent(ReturnDecorationParent(slotIndices));
		decoration.transform.Reset();
		decoration.transform.position = ReturnPositionFromBoundsIndices(slotIndices);
		decoration.RotateVisualPrefab();
		decoration.AddToConstructionGraph();
		decoration.Inventory.InventoryUpdatedEvent.AddListener(OnDecorationInventoryUpdated);
		foreach (int num in slotIndices)
		{
			Slots[num].Populate(decoration.Properties);
		}
		Decorations.Add(decoration);
		BeautyScore += decoration.Properties.BeautyScore;
		Buildable.Community.UpdateBeautyScore();
		OnDecorationAdded.SafeInvoke(decoration);
	}

	public void RefreshDecorationGraphNodes()
	{
		foreach (Decoration decoration in Decorations)
		{
			decoration.RemoveFromConstructionGraph();
			decoration.AddToConstructionGraph();
		}
	}

	public void RemoveDecoration(Decoration decoration, bool immediately = false)
	{
		if (decoration.ConstructionHandler.BuildPhase == BuildPhase.Finished)
		{
			decoration.OnSalvageDone = (Action<Decoration>)Delegate.Combine(decoration.OnSalvageDone, new Action<Decoration>(RemoveDecorationImmediate));
			decoration.Remove(immediately);
		}
	}

	public void RemoveDecorationImmediate(Decoration decoration)
	{
		if (Decorations.Remove(decoration))
		{
			int[] slotIndices = decoration.SlotIndices;
			foreach (int num in slotIndices)
			{
				Slots[num].Clear(decoration.Properties);
			}
			decoration.Inventory.InventoryUpdatedEvent.RemoveListener(OnDecorationInventoryUpdated);
			BeautyScore -= decoration.Properties.BeautyScore;
			Buildable.Community.UpdateBeautyScore();
			OnDecorationRemoved.SafeInvoke(decoration);
			DecorationEvent.DispatchRemoved(decoration);
		}
	}

	public void CancelDecorationRemoval(Decoration decoration)
	{
		decoration.ConstructionHandler.CancelSalvaging();
		decoration.OnSalvageDone = (Action<Decoration>)Delegate.Remove(decoration.OnSalvageDone, new Action<Decoration>(RemoveDecorationImmediate));
	}

	public void SetSelectedDecoration(Decoration decoration)
	{
		SelectedDecoration = decoration;
		if (!GameManager.UIManager.IsPanelOpen(PanelID.BuildablePanel))
		{
			GameManager.UIManager.DisplayPanel(Buildable);
		}
	}

	private void OnDecorationInventoryUpdated()
	{
		_decorationInventoryUpdated = true;
	}

	private void OnRemoveDecoToolEnabled(GameEvent gameEvent)
	{
		foreach (Decoration decoration in Decorations)
		{
			if (!decoration.Properties.IsSelectable)
			{
				decoration.SetColliderActive(active: true);
			}
		}
	}

	private void OnRemoveDecoToolDisabled(GameEvent gameEvent = null)
	{
		foreach (Decoration decoration in Decorations)
		{
			if (!decoration.Properties.IsSelectable)
			{
				decoration.SetColliderActive(active: false);
			}
		}
	}

	public bool AcceptsDecorationType(DecorationType decorationType)
	{
		return (_acceptedDecorationTypes & decorationType) != 0;
	}

	public bool HasAvailableSlots()
	{
		if (_isPlacementAllowed)
		{
			return Decorations.Count < Slots.Length;
		}
		return false;
	}

	public bool ReturnCanPlaceDecoration(DecorationProperties decorationProperties)
	{
		if (_isPlacementAllowed && (decorationProperties.DecorationType & _acceptedDecorationTypes) == decorationProperties.DecorationType && Buildable.BuildPhase == BuildPhase.Finished && decorationProperties.Width <= Width)
		{
			return decorationProperties.Depth <= Height;
		}
		return false;
	}

	public bool TryPopulateClosestSlotIndices(List<int> indices, Vector3 position, out Vector3 closesetPosition, DecorationProperties decorationProperties, DecorationProperties.Turns turn)
	{
		if (!ReturnCanPlaceDecoration(decorationProperties))
		{
			closesetPosition = default(Vector3);
			return false;
		}
		using ListPool<int>.List list = ListPool<int>.Get();
		using ListPool<int>.List list2 = ListPool<int>.Get();
		float num = float.MaxValue;
		bool result = false;
		closesetPosition = default(Vector3);
		for (int i = 0; i < Slots.Length; i++)
		{
			list.Clear();
			list2.Clear();
			if (!decorationProperties.ReturnCanPlaceOnSlot(this, i, turn, list, list2))
			{
				continue;
			}
			result = true;
			Vector3 vector = ReturnPositionFromBoundsIndices(list2);
			float num2 = position.DistanceToSquared(vector);
			if (!(num2 < num))
			{
				continue;
			}
			num = num2;
			indices.Clear();
			foreach (int item in list)
			{
				indices.Add(item);
			}
			closesetPosition = vector;
		}
		return result;
	}

	private Vector3 ReturnPositionFromBoundsIndices(List<int> boundsIndices)
	{
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < boundsIndices.Count; i++)
		{
			zero += Slots[boundsIndices[i]].transform.position;
		}
		return zero / boundsIndices.Count;
	}

	private Vector3 ReturnPositionFromBoundsIndices(int[] boundsIndices)
	{
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < boundsIndices.Length; i++)
		{
			zero += Slots[boundsIndices[i]].transform.position;
		}
		return zero / boundsIndices.Length;
	}

	private bool TryReturnDecorationSlot(int[] slotIndices, out DecorationSlot decorationSlot)
	{
		decorationSlot = null;
		if (slotIndices.IsNullOrEmpty() || !_isPlacementAllowed)
		{
			return false;
		}
		foreach (int num in slotIndices)
		{
			if (0 <= num && num < Slots.Length)
			{
				decorationSlot = Slots[num];
				return true;
			}
		}
		return false;
	}

	public Transform ReturnDecorationParent(int[] slotIndices)
	{
		Transform decorationParent = _decorationParent;
		if (decorationParent == null && TryReturnDecorationSlot(slotIndices, out var decorationSlot))
		{
			decorationParent = decorationSlot.transform;
		}
		return decorationParent;
	}

	public InventoryAuditor ReturnAuditorCount()
	{
		s_auditor.Reset();
		foreach (Decoration decoration in Decorations)
		{
			decoration.Inventory.Count(s_auditor, SubInventoryType.Export);
		}
		return s_auditor;
	}

	public bool IsDraggable()
	{
		foreach (Decoration decoration in Decorations)
		{
			if (!decoration.IsDraggable())
			{
				return false;
			}
		}
		return true;
	}

	public void GetBlockingNeighbours(ref ListPool<VisualPrefab>.List blockingConstructions)
	{
		foreach (Decoration decoration in Decorations)
		{
			if (!decoration.IsDraggable())
			{
				blockingConstructions.Add(decoration.SpawnedVisual);
			}
		}
	}

	public void Activate()
	{
		Active = true;
		Buildable.Community.AddDecorationSlots(this);
	}

	public void Deactivate()
	{
		Active = false;
	}

	public bool CanBeDeconstructed()
	{
		return Decorations.Count == 0;
	}

	public bool CanBeUpgraded()
	{
		return true;
	}

	public bool CanBeSalvaged()
	{
		return Decorations.Count == 0;
	}

	public void Finish(bool restored = false)
	{
	}

	public bool IsEnabled()
	{
		if (base.enabled)
		{
			return Active;
		}
		return false;
	}

	public void OnDeconstruct()
	{
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		Debug.LogWarning("TODO: Implement DecorationSlots.PopulateReferences");
	}

	public void Remove()
	{
	}

	public string ReturnDescription(string text)
	{
		return text;
	}

	public float ReturnWeight()
	{
		float num = 0f;
		foreach (Decoration decoration in Decorations)
		{
			num += decoration.Properties.Weight;
		}
		return num;
	}

	public void ShowResearchInfo(RectTransform parent)
	{
		Debug.LogWarning("TODO: Implement DecorationSlots.ShowResearchInfo");
	}

	public void Shutdown()
	{
		Buildable.Community.RemoveDecorationSlots(this);
		DisablePlacementMode();
		if (Buildable.BuildPhase != BuildPhase.SalvageShutdown || Decorations.Count == 0)
		{
			return;
		}
		for (int num = Decorations.Count - 1; num >= 0; num--)
		{
			Decoration decoration = Decorations[num];
			if (decoration.ConstructionHandler.Progress < 1f)
			{
				if (decoration.Properties is CropDecorationProperties cropDecorationProperties && (float)cropDecorationProperties.Yield.Amount > 0f)
				{
					SalvageCompositionItems(decoration);
				}
				RemoveDecoration(decoration);
			}
		}
		GraphManager.RefreshNavigatorPaths();
	}

	private void SalvageCompositionItems(Decoration decoration)
	{
		foreach (Item item in decoration.Inventory.ReturnAllItems(SubInventoryType.Composition))
		{
			if (decoration.Inventory.TryTakeItem(item, out var takenItem))
			{
				Buildable.Inventory.AddItem(takenItem, SubInventoryType.Resources);
			}
		}
	}

	public void ShutdownImmediately()
	{
	}

	public void Upgrade(Buildable buildable)
	{
		if (Decorations.Count == 0 || !buildable.TryReturnBuildableExtendable<DecorationSlots>(out var buildableExtendable))
		{
			return;
		}
		if (buildableExtendable._width != _width || buildableExtendable.Height != _height)
		{
			Debug.LogError("Upgrading is not currently not supported for DecorationSlots that don't have the same width and height!");
			return;
		}
		for (int i = 0; i < Decorations.Count; i++)
		{
			buildableExtendable.UpgradeDecoration(Decorations[i]);
		}
	}

	private void UpgradeDecoration(Decoration decoration)
	{
		int num = ((decoration.SlotIndices.Length == 1) ? decoration.SlotIndices[0] : (-1));
		if (num >= 0 && Slots.Length > num)
		{
			decoration.Upgrade(this);
			AddDecoration(decoration, decoration.SlotIndices);
		}
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new PersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
	}
}
