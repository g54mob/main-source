using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using I2.Loc;
using PajamaLlama.Debugs;
using PajamaLlama.Math;
using PajamaLlama.Utilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Inventory))]
public class Buildable : SceneBehaviour, IPersistentReference, ISelectable, ITooltipProvider, IPanelContext, IOutlineRenderControllerProvider, IConstructible, IPathfindingNodeProvider
{
	public delegate void MalfunctionUpdateEventHandler();

	[Tooltip("Properties of the buildable.")]
	[SerializeField]
	[FormerlySerializedAs("Properties")]
	private BuildableProperties _properties;

	[Tooltip("Static transform component of this buildable.")]
	public Transform StaticTransform;

	[Tooltip("Buoyant transform component of this buildable.")]
	public Transform BuoyantTransform;

	[Tooltip("Reference to the VisualPrefab instance in the Buildable prefab. Disabled if there are multiple VisualPrefabs in the BuildableProperties.")]
	[SerializeField]
	private VisualPrefab _visualPrefab;

	[Space]
	[Tooltip("Spots where drifters will be placed when building.")]
	public BuildSlots BuildSlots;

	public static Transform BuildableParent = null;

	public static HashSet<Polygon> BlockingPolygons = new HashSet<Polygon>();

	public static HashSet<Polygon> FreeformBlockerPolygons = new HashSet<Polygon>();

	private string _customName;

	private readonly List<GameObject> _buildableOutlineRopes = new List<GameObject>();

	private readonly List<GameObject> _buildableOutlineBuoys = new List<GameObject>();

	private ResourceProvider _resourceProvider;

	private List<PlaceableAlertProperties> _malfunctions = new List<PlaceableAlertProperties>();

	private bool _malfunctionsUpdated;

	[NonSerialized]
	private string _cachedDescription;

	private BuildableSettings.WeightModes _weightMode;

	private int _assignmentLimit = 1;

	private ModuleManager _moduleManager;

	private readonly List<IBuildableExtendable> _buildableExtendables = new List<IBuildableExtendable>();

	public BuildableProperties Properties => _properties;

	public List<Transform> OutlineCorners { get; private set; }

	public Vector2[] OutlinePositions { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public int VisualIndex { get; private set; }

	public VisualPrefab SpawnedVisual { get; private set; }

	public VisualBoundary Boundary { get; private set; }

	public float Health { get; private set; }

	PlaceableProperties IConstructible.Properties => Properties;

	public BuildPhase BuildPhase { get; private set; }

	public Community Community { get; set; }

	public bool IsActive { get; private set; }

	public PlaceableAlertProperties Status { get; private set; }

	public ConstructionHandler ConstructionHandler { get; } = new ConstructionHandler();

	public ConstructibleStatus StatusHolder { get; } = new ConstructibleStatus();

	public Project AssignedProject { get; set; }

	public int AssignmentLimit
	{
		get
		{
			if (AssignedProject == null || !AssignedProject.Properties.AllowAgentLimitOverride)
			{
				return _assignmentLimit;
			}
			return AssignedProject.AssignmentLimit;
		}
		set
		{
			value = Mathf.Max(1, value);
			if (AssignedProject != null && AssignedProject.Properties.AllowAgentLimitOverride)
			{
				if (AssignedProject.Properties.AllowAgentLimitOverride)
				{
					AssignedProject.AssignmentLimit = value;
				}
			}
			else
			{
				_assignmentLimit = value;
			}
		}
	}

	public string Name
	{
		get
		{
			if (_customName == null)
			{
				return Properties.Name;
			}
			return _customName;
		}
		set
		{
			_customName = (IsDefaultName(value) ? null : value);
		}
	}

	public string CustomName => _customName;

	public List<Item> ReservedUpgradeItems { get; } = new List<Item>();

	public FMODEventEmitter FMODEventEmitter { get; private set; }

	public BuildableVisual Visual { get; private set; }

	public PanelID PanelID => PanelID.BuildablePanel;

	public bool CancelConstructionAfterHaul { get; private set; }

	public Polygon OutlinePolygon { get; private set; }

	public Polygon BlockingPolygon { get; private set; }

	public Inventory Inventory { get; private set; }

	public WorldIconHandler WorldIconHandler { get; private set; }

	public BuildableAnimator BuildableAnimator { get; private set; }

	public PhysicsController PhysicsController { get; private set; }

	public OutlineRendererComponent OutlineRenderer { get; private set; }

	public OutlineRenderController OutlineController => SpawnedVisual.GetComponentInChildren<OutlineRenderController>();

	public ObjectType ObjectType => ObjectType.Buildable;

	public GameObject RelatedGameObject => base.gameObject;

	public UnityEvent<Buildable> OnBuildableFinishedEvent { get; } = new UnityEvent<Buildable>();

	public UnityEvent<Buildable, Buildable> OnBuildableUpgradedEvent { get; } = new UnityEvent<Buildable, Buildable>();

	public UnityEvent<Buildable> OnBuildableRemovedEvent { get; } = new UnityEvent<Buildable>();

	public UnityEvent<Buildable> OnAssignedProjectUpdatedEvent { get; } = new UnityEvent<Buildable>();

	public BuildableVisual.Event OnBuildableVisualRegister { get; } = new BuildableVisual.Event();

	public BuildableVisual.Event OnBuildableVisualUnregister { get; } = new BuildableVisual.Event();

	GameObject IConstructible.gameObject => base.gameObject;

	Transform IPathfindingNodeProvider.transform => base.transform;

	public event MalfunctionUpdateEventHandler MalfunctionUpdatedEvent;

	public void RestorePhase(BuildPhase buildphase)
	{
		BuildPhase = buildphase;
		switch (buildphase)
		{
		case BuildPhase.HaulTo:
			PlaceBuildingLines();
			SetHealth(0f);
			return;
		case BuildPhase.Build:
			MoveReservedResources(SubInventoryType.Resources, SubInventoryType.Composition);
			SetHealth(Inventory.ReturnCompositionProgress());
			if (Inventory.ReturnCount(SubInventoryType.Resources) == 0)
			{
				GameEventDispatcher.AddListener(GameEventType.StoryManagerStart, OnStoryManagerStart_FinishBuilding);
			}
			else
			{
				PlaceBuildingLines();
			}
			return;
		case BuildPhase.Deconstructing:
			MoveReservedResources(SubInventoryType.Composition, SubInventoryType.Resources);
			if (Inventory.ReturnCount(SubInventoryType.Composition) != 0)
			{
				SetStatus(GameSettings.Instance.BuildableSettings.StatusDeconstructingProperties);
				PlaceBuildingLines();
				return;
			}
			goto case BuildPhase.HaulFrom;
		case BuildPhase.HaulFrom:
			SetStatus(GameSettings.Instance.BuildableSettings.StatusSalvagingHaulingItemstoStorageProperties);
			PlaceBuildingLines();
			HaulFromBuildable(restore: true);
			SetHealth(0f);
			return;
		case BuildPhase.UpgradeHaulFrom:
			SetStatus(GameSettings.Instance.BuildableSettings.StatusUpgradeHaulingItemstoStorageProperties);
			RegisterResourceProvider();
			return;
		case BuildPhase.SalvageShutdown:
			FinalUpdate.RegisterGameStartOneShot(Salvage);
			break;
		case BuildPhase.UpgradeShutdown:
			FinalUpdate.RegisterGameStartOneShot(Upgrade);
			break;
		case BuildPhase.UpgradeHaulTo:
			PlaceBuildingLines();
			SetStatus(GameSettings.Instance.BuildableSettings.StatusUpgradingProperties);
			return;
		}
		Inventory.FillComposition(Properties.RequiredResources);
		FinishBuilding(restored: true);
	}

	protected override void Awake()
	{
		base.Awake();
		InitializeReferences();
	}

	private void Start()
	{
		OnInventoryUpdated();
	}

	private void InitializeReferences()
	{
		if (Properties.Outline.Length == 0)
		{
			Debugger.Error("No outline corners for building set for " + base.gameObject.name, base.gameObject);
		}
		Inventory = GetComponent<Inventory>();
		PhysicsController = GetComponentInChildren<PhysicsController>();
		WorldIconHandler = GetComponentInChildren<WorldIconHandler>(includeInactive: true);
		OutlineRenderer = GetComponent<OutlineRendererComponent>();
		BuildableAnimator = GetComponent<BuildableAnimator>();
		FMODEventEmitter = base.gameObject.AddComponent<FMODEventEmitter>();
		if (!Properties.Modules.IsNullOrEmpty() && !TryGetComponent<ModuleManager>(out _moduleManager))
		{
			_moduleManager = base.gameObject.AddComponent<ModuleManager>();
		}
		_buildableExtendables.Clear();
		_buildableExtendables.AddRange(GetComponentsInChildren<IBuildableExtendable>());
	}

	public void Initialize(Community community, int visualPrefabIndex, Vector2[] outlinePositions = null, bool restored = false)
	{
		BuildableSettings buildableSettings = GameSettings.Instance.BuildableSettings;
		community.AddBuildable(this);
		if (BuildableParent == null)
		{
			BuildableParent = new GameObject("Buildables").transform;
		}
		base.transform.SetParent(BuildableParent, worldPositionStays: true);
		OutlinePositions = outlinePositions;
		if (outlinePositions == null)
		{
			outlinePositions = Properties.Outline;
		}
		OutlineCorners = new List<Transform>(outlinePositions.Length);
		for (int i = 0; i < outlinePositions.Length; i++)
		{
			GameObject gameObject = new GameObject("OutlineCorner" + i);
			gameObject.transform.SetParent(StaticTransform);
			gameObject.transform.localPosition = outlinePositions[i].Vector3TopDown().SetY(0f);
			gameObject.transform.position = gameObject.transform.position.SetY(0f);
			OutlineCorners.Add(gameObject.transform);
		}
		OutlinePolygon = new Polygon();
		OutlinePolygon.Initialize(base.transform, OutlineCorners);
		OutlinePolygon.Update();
		BlockingPolygon = CreateBlockingPolygon(Properties, buildableSettings.GridSize, base.transform, StaticTransform);
		BlockingPolygons.Add(BlockingPolygon);
		FreeformBlockerPolygons.Add(OutlinePolygon);
		BuildableColliders componentInChildren = GetComponentInChildren<BuildableColliders>();
		if ((bool)componentInChildren)
		{
			componentInChildren.ActivateColliders();
		}
		InitializeVisual(visualPrefabIndex);
		VisualBoundary visualBoundary = Properties.ReturnBoundary();
		if (visualBoundary != null)
		{
			Boundary = UnityEngine.Object.Instantiate(visualBoundary, StaticTransform);
			if (!Properties.UseCustomSize)
			{
				Boundary.SetSize(Properties.Width, Properties.Depth);
			}
		}
		Inventory.Initialize(InventoryType.Construction);
		Inventory.GetOrAddSubInventory(SubInventoryType.Resources);
		Inventory.InitializeComposition(Properties.RequiredResources);
		Inventory.InventoryUpdatedEvent.AddListener(OnInventoryUpdated);
		Inventory.CompositionUpdatedEvent += SetHealth;
		if (BuildableAnimator != null)
		{
			BuildableAnimator.Initialize(SpawnedVisual.GetComponentInChildren<Animator>(includeInactive: true));
		}
		SelectionLink[] componentsInChildren = GetComponentsInChildren<SelectionLink>();
		foreach (SelectionLink selectionLink in componentsInChildren)
		{
			selectionLink.SetObjectToSelect(base.gameObject, ObjectType.Buildable);
			if (selectionLink.TryGetComponent<QuickConnecting>(out var _))
			{
				selectionLink.SetOnShowTooltipListener(OnShowQuickConnectTooltip);
				selectionLink.SetOnSelectedListener(OnQuickConnectSelected);
				selectionLink.SetOnDeselectedListener(OnQuickConnectDeselected);
			}
			else
			{
				selectionLink.SetOnShowTooltipListener(OnShowTooltip);
				selectionLink.SetOnSelectedListener(OnSelected);
				selectionLink.SetOnDeselectedListener(OnDeselected);
			}
		}
		BuoyantTransform.localPosition = Vector3.zero;
		for (int k = 0; k < _buildableExtendables.Count; k++)
		{
			IBuildableExtendable buildableExtendable = _buildableExtendables[k];
			buildableExtendable.Initialize(this, restored);
			if (buildableExtendable is BuildableExtendableBase buildableExtendableBase)
			{
				buildableExtendableBase.MalfunctionsUpdated += OnBuildableExtendableMalfunctionsUpdated;
			}
		}
		_weightMode = GameManager.Settings.BuildableSettings.WeightMode;
	}

	public void InitializeVisual(int visualPrefabIndex)
	{
		if (!SpawnedVisual)
		{
			VisualIndex = ReturnVisualIndex(visualPrefabIndex);
			SpawnedVisual = SpawnVisual(VisualIndex);
		}
	}

	private void FixedUpdate()
	{
		UpdateBuildingLines();
	}

	private void Update()
	{
		if (BuildPhase == BuildPhase.SalvageShutdown)
		{
			TryToSalvage();
		}
		if (BuildPhase == BuildPhase.UpgradeShutdown)
		{
			TryToStartUpgrade();
		}
		if (BuildPhase == BuildPhase.HaulTo)
		{
			if (AssignedProject == null)
			{
				StartBuilding();
			}
			else if (AssignedProject.Properties != GameSettings.Instance.ProjectSettings.HaulToBuildableProperties)
			{
				AssignedProject.Stop(ProjectFlags.BugFix);
				StartBuilding();
			}
		}
		else if (BuildPhase == BuildPhase.UpgradeHaulTo)
		{
			if (AssignedProject == null)
			{
				ChangeBuildPhase(BuildPhase.UpgradeShutdown);
				TryToStartUpgrade();
			}
			else if (AssignedProject.Properties != GameSettings.Instance.ProjectSettings.HaulToBuildableProperties)
			{
				AssignedProject.Stop(ProjectFlags.BugFix);
				ChangeBuildPhase(BuildPhase.UpgradeShutdown);
				TryToStartUpgrade();
			}
		}
	}

	private void OnDestroy()
	{
		if (Community != null && base.gameObject.scene.isLoaded && !GameManager.IsQuittingToDesktop)
		{
			Debug.LogErrorFormat("'{0}' is being destroyed, but it is still part of a community. This is a whale of a bug!", Name);
			Remove();
		}
		Inventory.CompositionUpdatedEvent -= SetHealth;
		if (Inventory.InventoryUpdatedEvent != null)
		{
			Inventory.InventoryUpdatedEvent.RemoveListener(OnInventoryUpdated);
		}
	}

	private void LateUpdate()
	{
		if (_malfunctionsUpdated)
		{
			_malfunctionsUpdated = false;
			UpdateWorldIcons();
			if (this.MalfunctionUpdatedEvent != null)
			{
				this.MalfunctionUpdatedEvent();
			}
		}
	}

	public void RemoveConstructible()
	{
		Remove();
	}

	public void Remove(Buildable instantiatedBuildable = null)
	{
		if (BuildPhase != BuildPhase.HaulFrom)
		{
			ChangeBuildPhase(BuildPhase.HaulFrom);
		}
		if (instantiatedBuildable == null)
		{
			OnBuildableRemovedEvent.Invoke(this);
		}
		else
		{
			OnBuildableUpgradedEvent.Invoke(this, instantiatedBuildable);
		}
		Agent[] componentsInChildren = GetComponentsInChildren<Agent>();
		foreach (Agent agent in componentsInChildren)
		{
			OutlineRenderer.UpdateAgent(agent);
		}
		foreach (IBuildableExtendable buildableExtendable in _buildableExtendables)
		{
			buildableExtendable.Remove();
			if (buildableExtendable is BuildableExtendableBase buildableExtendableBase)
			{
				buildableExtendableBase.MalfunctionsUpdated -= OnBuildableExtendableMalfunctionsUpdated;
			}
		}
		Selector.Deselect(base.gameObject);
		AudioManager.PlayOneShot(Properties.FMODEventReference_DestroyBuilding, base.transform);
		BlockingPolygons.Remove(BlockingPolygon);
		FreeformBlockerPolygons.Remove(OutlinePolygon);
		Inventory.CompositionUpdatedEvent -= SetHealth;
		Inventory.InventoryUpdatedEvent.RemoveListener(OnInventoryUpdated);
		UnregisterResourceProvider();
		Community.RemoveBuildable(this);
		RemoveBuildingSet();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void StartBuilding()
	{
		BuildableEvent.Dispatch(GameEventType.BuildablePlaced, this);
		if (BuildingDevTools.InstantBuild)
		{
			FinishBuilding();
			return;
		}
		using ListPool<CountedItemProperty>.List list = ListPool<CountedItemProperty>.Get();
		CountedItemProperty[] requiredResources = Properties.RequiredResources;
		foreach (CountedItemProperty countedItemProperty in requiredResources)
		{
			CountedItemProperty countedItemProperty2 = new CountedItemProperty(countedItemProperty.ItemProperties, countedItemProperty.Amount - Inventory.ReturnCount(countedItemProperty.ItemProperties, SubInventoryType.Resources));
			if (0 < countedItemProperty2.Amount)
			{
				list.Add(countedItemProperty2);
			}
		}
		int count = list.Count;
		while (0 < count--)
		{
			CountedItemProperty countedItemProperty2 = list[count];
			if (countedItemProperty2.ItemProperties.IsQuestItem && !Community.Inventory.ReturnContainsItem(countedItemProperty2.ItemProperties, countedItemProperty2.Amount))
			{
				for (int j = 0; j < list.Count; j++)
				{
					Inventory.AddItem(new Item(countedItemProperty2.ItemProperties), SubInventoryType.Resources);
				}
				list.RemoveAt(count);
			}
		}
		if (list.Count == 0)
		{
			Debug.Log("Start building was called and the required resources all already present at the buildable so we can directly start the build phase.");
			StartBuildPhase();
			return;
		}
		if (!Community.Inventory.ReturnContainsItems(list))
		{
			Debug.LogError($"Start building was called on {Name} while the required resources were not available. The building will be salvaged...");
			ListPool<CountedItemProperty>.Add(list);
			Salvage();
			return;
		}
		ChangeBuildPhase(BuildPhase.HaulTo);
		if (Properties.PlopProperties != null)
		{
			Properties.PlopProperties.Initiate(CameraController.Instance.transform);
			EffectsManager.ActivateEffect(EffectTrigger.Splash, base.transform, Vector3.zero);
		}
		SpawnedVisual.SetProgress(0f);
		PlaceBuildingLines();
		AudioManager.PlayOneShot(Properties.FMODEventReference_StartBuild, base.transform);
		AssignProject(GameSettings.Instance.ProjectSettings.HaulToBuildableProperties, ResourceManager.ReserveClosestItems(this, list));
	}

	public void StartUpgradedBuilding(Buildable antecede)
	{
		using ListPool<Item>.List list = ListPool<Item>.Get();
		antecede.Inventory.ReturnAllItems(SubInventoryType.Composition, list);
		foreach (Item item in list)
		{
			Inventory.AddItem(item, SubInventoryType.Composition);
		}
		list.Clear();
		antecede.Inventory.ReturnAllItems(SubInventoryType.Resources, list);
		foreach (Item item2 in list)
		{
			Inventory.AddItem(item2, SubInventoryType.Resources);
		}
		SpawnedVisual.SetProgress(Inventory.ReturnCompositionProgress());
		BuildBuildable();
	}

	private void ChangeBuildPhase(BuildPhase buildPhase)
	{
		BuildPhase = buildPhase;
		UpdateBuildPhaseStatus();
	}

	private void StartBuildPhase()
	{
		if (BuildPhase != BuildPhase.Build && Inventory.ReturnContainsItems(Properties.RequiredResources, SubInventoryType.Resources))
		{
			BuildBuildable();
		}
	}

	public void BuildBuildable()
	{
		if (TryReturnBuildableExtendable<WalkwaySegment>(out var _) || TryReturnBuildableExtendable<WalkwayPonton>(out var _))
		{
			Inventory.Clear(SubInventoryType.Resources);
			FinishBuilding();
		}
		else
		{
			ChangeBuildPhase(BuildPhase.Build);
			AssignProject(GameSettings.Instance.ProjectSettings.BuildBuildableProperties);
		}
	}

	private void OnStoryManagerStart_FinishBuilding(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.StoryManagerStart, OnStoryManagerStart_FinishBuilding);
		FinishBuilding();
	}

	public void FinishConstruction(bool restored = false)
	{
		FinishBuilding(restored);
	}

	public void FinishBuilding(bool restored = false)
	{
		ChangeBuildPhase(BuildPhase.Finished);
		Inventory.FillComposition(Properties.RequiredResources);
		UIManager instance;
		bool flag = UIManager.TryReturnInstance(out instance);
		if (!restored)
		{
			RemoveBuildingSet();
			AudioManager.PlayOneShot(Properties.FMODEventReference_DestroyBuilding);
			Activate();
			if (Properties.NotificationOnFinished && flag)
			{
				instance.NotificationHandler.AddNotification(GameSettings.Instance.UISettings.BuildableFinishedNotification, new BuildableObjectOfInterest(RelatedGameObject, Properties));
			}
			OnBuildableFinishedEvent.Invoke(this);
			BuildableEvent.Dispatch(GameEventType.BuildableBuilt, this);
		}
		for (int i = 0; i < _buildableExtendables.Count; i++)
		{
			_buildableExtendables[i].Finish(restored);
		}
		Community.UpdateBuildables();
	}

	void IConstructible.SetProgress(float progress)
	{
		SetHealth(progress);
	}

	public void SetHealth(float health)
	{
		Health = health;
		if (TryReturnBuildableExtendable<WalkwaySegment>(out var _))
		{
			SpawnedVisual.SetProgress(1f);
		}
		else
		{
			SpawnedVisual.SetProgress(Health);
		}
		BuildSlots.SetProgress(Health);
	}

	public void Activate()
	{
		UpdateBuildPhaseStatus();
		for (int i = 0; i < _buildableExtendables.Count; i++)
		{
			_buildableExtendables[i].Activate();
		}
		IsActive = true;
	}

	public void Deactivate()
	{
		for (int i = 0; i < _buildableExtendables.Count; i++)
		{
			_buildableExtendables[i].Deactivate();
		}
		if (BuildPhase == BuildPhase.Finished)
		{
			SetStatus(GameSettings.Instance.BuildableSettings.StatusInactiveProperties);
		}
		IsActive = false;
	}

	private void AssignProject(ProjectProperties projectProperties, List<Item> items = null)
	{
		if (AssignedProject != null)
		{
			Debug.LogException(new Exception($"Trying to set Buildable.AssignedProject, but it still has a reference to '{AssignedProject.Properties}'"));
		}
		AssignedProject = new Project(projectProperties, base.gameObject, items);
		AssignedProject.ProjectAssignmentsUpdated.AddListener(OnProjectAssignmentsUpdated);
		AssignedProject.FinishedEvent.AddListener(OnAssignedProjectFinished);
		if (projectProperties.AllowAgentLimitOverride)
		{
			AssignedProject.AssignmentLimit = _assignmentLimit;
			_assignmentLimit = 1;
		}
		Community.PlayerCommunity.QueueProject(AssignedProject);
		OnAssignedProjectUpdatedEvent.Invoke(this);
	}

	public void StopAssignedProject()
	{
		if (AssignedProject != null)
		{
			AssignedProject.Stop(ProjectFlags.BugFix);
			OnAssignedProjectUpdatedEvent.Invoke(this);
		}
	}

	public void RestoreAssignedProject(Project project)
	{
		if (AssignedProject != null)
		{
			throw new NotSupportedException();
		}
		AssignedProject = project;
		AssignedProject.ProjectAssignmentsUpdated.AddListener(OnProjectAssignmentsUpdated);
		AssignedProject.FinishedEvent.AddListener(OnAssignedProjectFinished);
	}

	private void OnProjectAssignmentsUpdated()
	{
		UpdateBuildPhaseStatus();
		OnAssignedProjectUpdatedEvent.Invoke(this);
	}

	private void OnAssignedProjectFinished(Project project, bool succes)
	{
		AssignedProject.FinishedEvent.RemoveListener(OnAssignedProjectFinished);
		AssignedProject = null;
		switch (BuildPhase)
		{
		case BuildPhase.HaulTo:
			if (CancelConstructionAfterHaul)
			{
				ChangeBuildPhase(BuildPhase.SalvageShutdown);
				TryToSalvage();
				CancelConstructionAfterHaul = false;
			}
			else
			{
				StartBuildPhase();
			}
			break;
		case BuildPhase.Build:
			if (Health >= 1f)
			{
				FinishBuilding();
			}
			break;
		case BuildPhase.UpgradeHaulTo:
			StartUpgrade();
			break;
		case BuildPhase.Deconstructing:
			if (Health <= 0f)
			{
				HaulFromBuildable();
			}
			break;
		case BuildPhase.SalvageShutdown:
			TryToSalvage();
			break;
		}
		OnAssignedProjectUpdatedEvent.Invoke(this);
	}

	void IConstructible.OnBuildPhaseUpdated(BuildPhase buildPhase)
	{
	}

	private void OnInventoryUpdated()
	{
		switch (BuildPhase)
		{
		case BuildPhase.HaulFrom:
			EndSalvaging();
			break;
		case BuildPhase.UpgradeHaulFrom:
			UpdateUpgradeHaulFrom();
			break;
		}
	}

	public void CancelUpgrade()
	{
		if (BuildPhase == BuildPhase.UpgradeShutdown)
		{
			foreach (Item reservedUpgradeItem in ReservedUpgradeItems)
			{
				reservedUpgradeItem.CancelReservation();
			}
			ReservedUpgradeItems.Clear();
			FinishBuilding();
		}
		else if (BuildPhase == BuildPhase.UpgradeHaulTo)
		{
			AssignedProject?.Stop(ProjectFlags.Cancelled | ProjectFlags.InventoryMustBeEmpty);
			RegisterResourceProvider();
			ChangeBuildPhase(BuildPhase.UpgradeHaulFrom);
			OnInventoryUpdated();
		}
	}

	private void UpdateUpgradeHaulFrom()
	{
		if (AssignedProject == null && Inventory.ReturnIsEmpty(SubInventoryType.Resources))
		{
			FinishBuilding();
			UnregisterResourceProvider();
		}
	}

	public void Upgrade()
	{
		if (BuildPhase != BuildPhase.Finished || !Properties.Upgrade || !Properties.Upgrade.IsUnlocked() || !BuildingDevTools.TryAutoSpawnResources(Properties.UpgradeResources) || !ResourceManager.AreCommunityResourcesAvailable(Properties.UpgradeResources))
		{
			return;
		}
		ChangeBuildPhase(BuildPhase.UpgradeShutdown);
		Shutdown();
		if (!BuildingDevTools.InstantBuild)
		{
			ReservedUpgradeItems.Clear();
			if (Properties.UpgradeResources.Length != 0)
			{
				ReservedUpgradeItems.AddRange(ResourceManager.ReserveClosestItems(this, Properties.UpgradeResources));
			}
			int count = ReservedUpgradeItems.Count;
			while (0 < count--)
			{
				Item item = ReservedUpgradeItems[count];
				if (item.Inventory == Inventory && item.SubInventory == SubInventoryType.Export)
				{
					Inventory.MoveToSubInventory(item, SubInventoryType.Resources);
					item.CancelReservation();
					ReservedUpgradeItems.RemoveAt(count);
				}
			}
		}
		TryToStartUpgrade();
	}

	private void TryToStartUpgrade()
	{
		if (BuildPhase != BuildPhase.UpgradeShutdown)
		{
			return;
		}
		for (int i = 0; i < _buildableExtendables.Count; i++)
		{
			if (!_buildableExtendables[i].CanBeUpgraded())
			{
				return;
			}
		}
		ChangeBuildPhase(BuildPhase.UpgradeHaulTo);
		if (BuildingDevTools.InstantBuild || ReservedUpgradeItems.Count == 0)
		{
			StartUpgrade();
		}
		else if (HasReservedUpgradeResources())
		{
			AssignProject(GameSettings.Instance.ProjectSettings.HaulToBuildableProperties, ReservedUpgradeItems);
		}
	}

	public bool CanUpgrade()
	{
		if (BuildPhase == BuildPhase.Finished && (bool)Properties.Upgrade && Properties.Upgrade.IsUnlocked())
		{
			return ResourceManager.AreCommunityResourcesAvailable(Properties.UpgradeResources);
		}
		return false;
	}

	public void StartUpgrade()
	{
		if (BuildPhase != BuildPhase.UpgradeHaulTo || (!BuildingDevTools.InstantBuild && !Inventory.ReturnContainsItems(Properties.UpgradeResources, SubInventoryType.Resources)))
		{
			return;
		}
		Buildable buildable = UnityEngine.Object.Instantiate(Properties.Upgrade.Prefab, base.transform.position, base.transform.rotation);
		buildable.Initialize(Community.PlayerCommunity, -1);
		if (BuildingDevTools.InstantBuild)
		{
			buildable.FinishBuilding();
		}
		else
		{
			buildable.StartUpgradedBuilding(this);
		}
		foreach (IBuildableExtendable buildableExtendable in _buildableExtendables)
		{
			buildableExtendable.Upgrade(buildable);
		}
		Remove(buildable);
		BuildableEvent.Dispatch(GameEventType.BuildableUpgraded, this);
	}

	private bool HasReservedUpgradeResources()
	{
		if (Properties.Upgrade == null)
		{
			Debug.LogError($"BUILDABLE::Upgrade for buildable {Name} is null.");
		}
		if (Properties.Upgrade.RequiredResources == null)
		{
			Debug.LogError($"BUILDABLE::Upgrade Required Resources for buildable {Name} is null.");
		}
		using ListPool<Item>.List list = ListPool<Item>.Get();
		Inventory.ReturnAllItems(SubInventoryType.Resources, list);
		CountedItemProperty[] upgradeResources = Properties.UpgradeResources;
		foreach (CountedItemProperty countedItemProperty in upgradeResources)
		{
			int num = 0;
			if (ReservedUpgradeItems == null)
			{
				Debug.LogError($"BUILDABLE::Reserved Upgrade Items for buildable {Name} is null.");
			}
			foreach (Item item in list)
			{
				if (item.Properties == countedItemProperty.ItemProperties)
				{
					num++;
				}
			}
			foreach (Item reservedUpgradeItem in ReservedUpgradeItems)
			{
				if (reservedUpgradeItem.Properties == countedItemProperty.ItemProperties)
				{
					num++;
				}
			}
			if (num != countedItemProperty.Amount)
			{
				return false;
			}
		}
		return true;
	}

	public void Salvage()
	{
		if (BuildPhase == BuildPhase.Finished)
		{
			if (TryReturnBuildableExtendable<WalkwayPonton>(out var buildableExtendable))
			{
				buildableExtendable.SalvageWalkwayNeighbours();
				return;
			}
			ChangeBuildPhase(BuildPhase.SalvageShutdown);
			Shutdown();
			PlaceBuildingLines();
			TryToSalvage();
			return;
		}
		if (BuildPhase == BuildPhase.HaulTo)
		{
			CancelConstructionAfterHaul = true;
			UpdateBuildPhaseStatus();
			return;
		}
		using ListPool<Agent>.List list = ListPool<Agent>.Get();
		if (AssignedProject != null)
		{
			AssignedProject.ReturnAssignedAgents(list);
		}
		if (BuildPhase == BuildPhase.Build)
		{
			AssignedProject.ReturnAssignedAgents(list);
			AssignedProject?.Stop(ProjectFlags.Cancelled);
			BuildSlots.Detach(GameManager.AgentManager.AgentParent);
			for (int i = 0; i < list.Count; i++)
			{
				list[i].ReturnNavigator().AttachToTarget(list[i].ReturnClosestConstruction(onlyFinished: true).Target, overrideCheck: true);
			}
		}
		ChangeBuildPhase(BuildPhase.SalvageShutdown);
		TryToSalvage();
	}

	public void DetachBuildingAgents()
	{
		BuildSlots.Detach(GameManager.AgentManager.AgentParent);
	}

	public void CancelDeconstruction()
	{
		if (BuildPhase == BuildPhase.HaulTo)
		{
			CancelConstructionAfterHaul = false;
			UpdateBuildPhaseStatus();
			return;
		}
		if (BuildPhase == BuildPhase.SalvageShutdown)
		{
			FinishBuilding();
			return;
		}
		BuildPhase buildPhase = BuildPhase;
		if (buildPhase == BuildPhase.Deconstructing || buildPhase == BuildPhase.HaulFrom)
		{
			List<Agent> list = ListPool<Agent>.Get();
			if (AssignedProject != null)
			{
				AssignedProject.ReturnAssignedAgents(list);
				AssignedProject.Stop(ProjectFlags.Cancelled);
			}
			DetachBuildingAgents();
			for (int i = 0; i < list.Count; i++)
			{
				list[i].ReturnNavigator().AttachToTarget(list[i].ReturnClosestConstruction(onlyFinished: true).Target, overrideCheck: true);
			}
			ListPool<Agent>.Add(list);
			if (Mathf.Approximately(Health, 1f))
			{
				FinishBuilding();
				return;
			}
			ChangeBuildPhase(BuildPhase.Build);
			BuildBuildable();
		}
	}

	private void TryToSalvage()
	{
		if (BuildPhase != BuildPhase.SalvageShutdown || AssignedProject != null)
		{
			return;
		}
		for (int i = 0; i < _buildableExtendables.Count; i++)
		{
			if (!_buildableExtendables[i].CanBeSalvaged())
			{
				return;
			}
		}
		ChangeBuildPhase(BuildPhase.Deconstructing);
		DeconstructBuildable();
		BuildableEvent.Dispatch(GameEventType.BuildableSalvaged, this);
	}

	private void DeconstructBuildable()
	{
		for (int i = 0; i < _buildableExtendables.Count; i++)
		{
			_buildableExtendables[i].OnDeconstruct();
		}
		if (Inventory.ReturnCount(SubInventoryType.Composition, includeReserved: true) > 0)
		{
			if (TryReturnBuildableExtendable<WalkwaySegment>(out var _))
			{
				foreach (Item item in Inventory.ReturnAllItems(SubInventoryType.Composition))
				{
					Inventory.MoveToSubInventory(item, SubInventoryType.Resources);
				}
				HaulFromBuildable();
			}
			else
			{
				AssignProject(GameSettings.Instance.ProjectSettings.DeconstructBuildableProperties);
			}
		}
		else if (Inventory.ReturnCount(SubInventoryType.Resources, includeReserved: true) > 0)
		{
			HaulFromBuildable();
		}
		else
		{
			EndSalvaging();
		}
	}

	private void HaulFromBuildable(bool restore = false)
	{
		ChangeBuildPhase(BuildPhase.HaulFrom);
		RegisterResourceProvider();
		if (!restore)
		{
			OnInventoryUpdated();
		}
		if (TryReturnBuildableExtendable<Hookable>(out var buildableExtendable))
		{
			buildableExtendable.Remove();
		}
		if (TryReturnBuildableExtendable<WalkwaySegment>(out var buildableExtendable2))
		{
			buildableExtendable2.OnHaulFromBuildable();
		}
	}

	private void EndSalvaging()
	{
		if (Inventory.ReturnCount(SubInventoryType.Resources, includeReserved: true) <= 0)
		{
			UnregisterResourceProvider();
			Remove();
		}
	}

	bool IConstructible.CanBeDeconstructed(out LocalizedString error)
	{
		foreach (IBuildableExtendable buildableExtendable in _buildableExtendables)
		{
			if (!buildableExtendable.CanBeDeconstructed())
			{
				error = Properties.CantDeconstructTooltip;
				return false;
			}
		}
		error = GameSettings.Instance.BuildableSettings.DeconstructionTooltip;
		return true;
	}

	public bool CanBeDeconstructed(out LocalizedString error)
	{
		error = GameSettings.Instance.BuildableSettings.DeconstructionTooltip;
		if (BuildPhase == BuildPhase.HaulFrom || BuildPhase == BuildPhase.UpgradeHaulFrom)
		{
			error = GameSettings.Instance.BuildableSettings.HaulFromTooltip;
			return false;
		}
		if (BuildPhase == BuildPhase.UpgradeHaulTo || BuildPhase == BuildPhase.UpgradeShutdown)
		{
			error = GameSettings.Instance.BuildableSettings.UpgradeHaulToTooltip;
			return false;
		}
		if (BuildPhase == BuildPhase.Deconstructing || (BuildPhase == BuildPhase.HaulTo && CancelConstructionAfterHaul))
		{
			error = GameSettings.Instance.BuildableSettings.CancelDeconstructionTooltip;
			return true;
		}
		foreach (IBuildableExtendable buildableExtendable in _buildableExtendables)
		{
			if (!buildableExtendable.CanBeDeconstructed())
			{
				error = Properties.CantDeconstructTooltip;
				return false;
			}
		}
		return true;
	}

	public void Shutdown()
	{
		for (int i = 0; i < _buildableExtendables.Count; i++)
		{
			_buildableExtendables[i].Shutdown();
		}
		RemoveAllMalfunctions();
	}

	public VisualPrefab SpawnVisual(int index)
	{
		if ((bool)_visualPrefab)
		{
			if (Properties.Visuals.Length < 2)
			{
				return _visualPrefab;
			}
			_visualPrefab.gameObject.SetActive(value: false);
		}
		VisualPrefab visualPrefab = UnityEngine.Object.Instantiate(ReturnVisual(index));
		visualPrefab.Randomize();
		visualPrefab.transform.SetParent(BuoyantTransform, worldPositionStays: true);
		visualPrefab.transform.localPosition = Vector3.zero;
		visualPrefab.transform.localRotation = Quaternion.identity;
		return visualPrefab;
	}

	public void RegisterVisual(BuildableVisual visual)
	{
		OnBuildableVisualRegister.Invoke(visual);
	}

	public void UnregisterVisual(BuildableVisual visual)
	{
		OnBuildableVisualUnregister.Invoke(visual);
	}

	public bool IsDraggable()
	{
		if (BuildPhase != BuildPhase.Finished)
		{
			return false;
		}
		if (TryReturnBuildableExtendable<Construction>(out var buildableExtendable) && buildableExtendable == Construction.Townheart)
		{
			return false;
		}
		if (TryReturnBuildableExtendable<Boat>(out var buildableExtendable2))
		{
			return false;
		}
		if (TryReturnBuildableExtendable<Boat>(out buildableExtendable2))
		{
			return false;
		}
		if (TryReturnBuildableExtendable<WalkwayPonton>(out var buildableExtendable3))
		{
			return false;
		}
		if (TryReturnBuildableExtendable<WalkwaySegment>(out var buildableExtendable4) && !buildableExtendable4.CanBeDeconstructed())
		{
			return false;
		}
		if (TryReturnBuildableExtendable<Hookable>(out var buildableExtendable5) && !buildableExtendable5.CanBeDeconstructed())
		{
			return false;
		}
		if (TryReturnBuildableExtendable<DecorationSlots>(out var buildableExtendable6) && !buildableExtendable6.IsDraggable())
		{
			return false;
		}
		if (buildableExtendable3 != null && !buildableExtendable3.NeighbouringWalkwaysFinished())
		{
			return false;
		}
		return true;
	}

	private void MoveReservedResources(SubInventoryType from, SubInventoryType to)
	{
		using ListPool<Item>.List list = ListPool<Item>.Get();
		Inventory.ReturnAllItems(from, list);
		foreach (Item item in list)
		{
			if (item.IsReserved)
			{
				item.CancelReservation();
				Inventory.MoveToSubInventory(item, to);
			}
		}
	}

	private void RegisterResourceProvider()
	{
		if (_resourceProvider == null)
		{
			_resourceProvider = ResourceProvider.Get(this, SubInventoryType.Resources, AssignmentType.Constructing);
		}
		_resourceProvider.Register();
	}

	private void UnregisterResourceProvider()
	{
		_resourceProvider?.Unregister();
	}

	public void Animator_SetInteger(string name, int value)
	{
		if (!(BuildableAnimator == null) && !(BuildableAnimator.Animator == null))
		{
			BuildableAnimator.Animator.SetInteger(name, value);
		}
	}

	public void SetStatus(PlaceableAlertProperties status)
	{
		if (!(Status == status))
		{
			Status = status;
			_malfunctionsUpdated = true;
		}
	}

	public void AddMalfunction(PlaceableAlertProperties properties)
	{
		if (_malfunctions.AddUnique(properties))
		{
			_malfunctionsUpdated = true;
		}
	}

	public void RemoveMalfunction(PlaceableAlertProperties properties)
	{
		if (_malfunctions.Remove(properties))
		{
			_malfunctionsUpdated = true;
		}
	}

	public void RemoveAllMalfunctions()
	{
		_malfunctions.Clear();
		_malfunctionsUpdated = true;
	}

	public void PopulateMalfunctions(List<PlaceableAlertProperties> malfunctions, PlaceableAlertProperties.AlertType minimumAlertType = PlaceableAlertProperties.AlertType.Minor)
	{
		foreach (PlaceableAlertProperties malfunction in _malfunctions)
		{
			if (minimumAlertType <= malfunction.Alert)
			{
				malfunctions.Add(malfunction);
			}
		}
		foreach (IBuildableExtendable buildableExtendable in _buildableExtendables)
		{
			if (buildableExtendable is BuildableExtendableBase buildableExtendableBase)
			{
				buildableExtendableBase.PopulateMalfunctions(malfunctions, minimumAlertType);
			}
		}
	}

	private void OnBuildableExtendableMalfunctionsUpdated()
	{
		_malfunctionsUpdated = true;
	}

	private void UpdateBuildPhaseStatus()
	{
		switch (BuildPhase)
		{
		case BuildPhase.UpgradeHaulTo:
			SetStatus(GameSettings.Instance.BuildableSettings.StatusUpgradingProperties);
			break;
		case BuildPhase.HaulTo:
			if (CancelConstructionAfterHaul)
			{
				SetStatus(GameSettings.Instance.BuildableSettings.StatusStoppingConstructionProperties);
			}
			else if (AssignedProject != null && AssignedProject.ReturnAssignedAgents().Count > 0)
			{
				SetStatus(GameSettings.Instance.BuildableSettings.StatusResourcesComingProperties);
			}
			else
			{
				SetStatus(GameSettings.Instance.BuildableSettings.StatusWaitingForResourcesProperties);
			}
			break;
		case BuildPhase.Build:
			if (AssignedProject != null && AssignedProject.ReturnAssignedAgents().Count > 0)
			{
				SetStatus(GameSettings.Instance.BuildableSettings.StatusBuildingProperties);
			}
			else
			{
				SetStatus(GameSettings.Instance.BuildableSettings.StatusWaitingForConstructorProperties);
			}
			break;
		case BuildPhase.SalvageShutdown:
		case BuildPhase.UpgradeShutdown:
			SetStatus(GameSettings.Instance.BuildableSettings.StatusStoppingConstructionProperties);
			break;
		case BuildPhase.Deconstructing:
			if (AssignedProject != null && AssignedProject.ReturnAssignedAgents().Count > 0)
			{
				SetStatus(GameSettings.Instance.BuildableSettings.StatusDeconstructingProperties);
			}
			else
			{
				SetStatus(GameSettings.Instance.BuildableSettings.StatusWaitingForDeconstructorProperties);
			}
			break;
		case BuildPhase.HaulFrom:
			SetStatus(GameSettings.Instance.BuildableSettings.StatusSalvagingHaulingItemstoStorageProperties);
			break;
		case BuildPhase.UpgradeHaulFrom:
			SetStatus(GameSettings.Instance.BuildableSettings.StatusUpgradeHaulingItemstoStorageProperties);
			break;
		default:
			SetStatus(GameSettings.Instance.BuildableSettings.StatusIdleProperties);
			break;
		}
	}

	private void UpdateWorldIcons()
	{
		using ListPool<PlaceableAlertProperties>.List list = ListPool<PlaceableAlertProperties>.Get();
		PopulateMalfunctions(list, PlaceableAlertProperties.AlertType.Major);
		WorldIconHandler.ClearAllIcons();
		if (list.Count > 1)
		{
			WorldIconHandler.AddIcon(GameSettings.Instance.BuildableSettings.MultipleMalfunctionsIconProperties);
		}
		else if (list.Count == 1)
		{
			WorldIconHandler.AddIcon(list[0]);
		}
		else if ((bool)Status && Status.Alert == PlaceableAlertProperties.AlertType.Major)
		{
			WorldIconHandler.AddIcon(Status);
		}
	}

	public void RemoveBuildingSet()
	{
		if (_buildableOutlineBuoys.Count != 0)
		{
			UnityEngine.Object.Destroy(_buildableOutlineBuoys[0].transform.parent.gameObject);
			_buildableOutlineRopes.Clear();
			_buildableOutlineBuoys.Clear();
		}
	}

	public void PlaceBuildingLines()
	{
		if (Properties.BuildBuoy == null || Properties.BuildRope == null)
		{
			return;
		}
		Transform transform = new GameObject($"{Properties.name}BuildingLines").transform;
		transform.position = base.transform.position;
		transform.rotation = base.transform.rotation;
		for (int i = 0; i < OutlineCorners.Count; i++)
		{
			int index = (int)Mathf.Repeat(i + 1, OutlineCorners.Count);
			float num = Vector3.Distance(OutlineCorners[i].localPosition, OutlineCorners[index].localPosition);
			int num2 = Mathf.RoundToInt(num / 2f);
			float z = num / 2f / (float)num2;
			Vector3 vector = (OutlineCorners[index].localPosition - OutlineCorners[i].localPosition) / num2;
			Quaternion localRotation = Quaternion.LookRotation(OutlineCorners[index].localPosition - OutlineCorners[i].localPosition);
			for (int j = 0; j < num2; j++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(Properties.BuildRope);
				_buildableOutlineRopes.Add(gameObject);
				gameObject.transform.SetParent(OutlineCorners[0].parent, worldPositionStays: true);
				gameObject.transform.localPosition = OutlineCorners[i].localPosition + j * vector;
				gameObject.transform.localScale = new Vector3(1f, 1f, z);
				gameObject.transform.localRotation = localRotation;
				GameObject gameObject2 = UnityEngine.Object.Instantiate(GameSettings.Instance.BuildableSettings.BuildBuoy);
				_buildableOutlineBuoys.Add(gameObject2);
				gameObject2.transform.SetParent(OutlineCorners[0].parent, worldPositionStays: true);
				gameObject2.transform.localPosition = OutlineCorners[i].localPosition + j * vector;
				gameObject2.transform.localRotation = localRotation;
				GameObject obj = UnityEngine.Object.Instantiate(Properties.BuildBuoy);
				obj.transform.SetParent(gameObject2.transform, worldPositionStays: true);
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localRotation = Quaternion.identity;
				gameObject2.GetComponent<PhysicsController>().Initialize();
			}
		}
		for (int k = 0; k < _buildableOutlineBuoys.Count; k++)
		{
			_buildableOutlineBuoys[k].transform.SetParent(transform, worldPositionStays: true);
		}
		for (int l = 0; l < _buildableOutlineRopes.Count; l++)
		{
			_buildableOutlineRopes[l].transform.SetParent(transform, worldPositionStays: true);
		}
	}

	private void UpdateBuildingLines()
	{
		for (int i = 0; i < _buildableOutlineRopes.Count; i++)
		{
			int index = (int)Mathf.Repeat(i + 1, _buildableOutlineBuoys.Count);
			_buildableOutlineRopes[i].transform.localPosition = _buildableOutlineBuoys[i].transform.localPosition;
			_buildableOutlineRopes[i].transform.localScale = new Vector3(1f, 1f, Vector3.Distance(_buildableOutlineBuoys[index].transform.localPosition, _buildableOutlineBuoys[i].transform.localPosition) / 2f);
			_buildableOutlineRopes[i].transform.localRotation = Quaternion.LookRotation(_buildableOutlineBuoys[index].transform.localPosition - _buildableOutlineBuoys[i].transform.localPosition);
		}
	}

	public void OnShowTooltip()
	{
		TooltipPanel.ShowTooltip(this);
	}

	public void OnSelected(bool playSelectionSound)
	{
		AudioManager.PlayOneShot(Properties.FMODEventReference_Select);
		GameManager.UIManager.DisplayPanel(this);
		BuildableEvent.Dispatch(GameEventType.BuildableSelected, this);
	}

	public void OnDeselected()
	{
		GameManager.UIManager.ClosePanel(PanelID.BuildablePanel);
		OutlineRenderer.ResetHighlightOutline();
		BuildableEvent.Dispatch(GameEventType.BuildableDeselected, this);
	}

	public void OnShowQuickConnectTooltip()
	{
		if (!TryReturnBuildableExtendable<EnergyGridBuildableComponent>(out var buildableExtendable) || !buildableExtendable.CanConnect())
		{
			OnShowTooltip();
		}
	}

	public void OnQuickConnectSelected(bool playSelectionSound)
	{
		if (!TryReturnBuildableExtendable<EnergyGridBuildableComponent>(out var buildableExtendable) || !buildableExtendable.CanConnect())
		{
			OnSelected(playSelectionSound);
		}
	}

	public void OnQuickConnectDeselected()
	{
		if (!TryReturnBuildableExtendable<EnergyGridBuildableComponent>(out var buildableExtendable) || !buildableExtendable.CanConnect())
		{
			OnDeselected();
		}
	}

	public string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return Name;
	}

	public PathfindingNode ReturnPathfindingNode(Navigator navigator)
	{
		if (TryReturnBuildableExtendable<Construction>(out var buildableExtendable))
		{
			if (buildableExtendable.TryReturnBuildablePhaseTargetNode(out var node))
			{
				return node;
			}
			if ((bool)buildableExtendable.Target && (bool)buildableExtendable.Target.PrimaryMarker && buildableExtendable.Target.PrimaryMarker.Node != null)
			{
				return buildableExtendable.Target.PrimaryMarker.Node;
			}
			return buildableExtendable.Target.ReturnPathfindingNode(navigator);
		}
		return null;
	}

	public bool IsInConstruction()
	{
		return BuildPhase != BuildPhase.Finished;
	}

	public string ReturnDescription()
	{
		if (!string.IsNullOrEmpty(_cachedDescription))
		{
			return _cachedDescription;
		}
		_cachedDescription = Properties.Description;
		_cachedDescription = Regex.Replace(_cachedDescription, "%NAME%", $"<b>{Properties.Name}</b>", RegexOptions.IgnoreCase);
		_cachedDescription = Regex.Replace(_cachedDescription, "%RESEARCH%", Properties.ResearchCost.ToString(), RegexOptions.IgnoreCase);
		IBuildableExtendable[] componentsInChildren = GetComponentsInChildren<IBuildableExtendable>();
		foreach (IBuildableExtendable buildableExtendable in componentsInChildren)
		{
			_cachedDescription = buildableExtendable.ReturnDescription(_cachedDescription);
		}
		return _cachedDescription;
	}

	public Agent[] ReturnAgentsOnBuildable()
	{
		return GetComponentsInChildren<Agent>();
	}

	public void ReturnAgentsOnBuildable(List<Agent> agents)
	{
		GetComponentsInChildren(agents);
	}

	public List<Agent> GetWorkers(List<Agent> listToPopulate = null)
	{
		if (listToPopulate == null)
		{
			listToPopulate = new List<Agent>(8);
		}
		if (AssignedProject != null)
		{
			AssignedProject.ReturnAssignedAgents(listToPopulate);
		}
		foreach (IBuildableExtendable buildableExtendable in _buildableExtendables)
		{
			buildableExtendable.GetWorkers(listToPopulate);
		}
		return listToPopulate;
	}

	public VisualPrefab ReturnVisual(int index = -1)
	{
		if (index < 0 || index >= Properties.Visuals.Length)
		{
			return Properties.Visuals[UnityEngine.Random.Range(0, Properties.Visuals.Length)];
		}
		return Properties.Visuals[index];
	}

	public int ReturnVisualIndex(int index)
	{
		if (index < 0 || index >= Properties.Visuals.Length)
		{
			index = UnityEngine.Random.Range(0, Properties.Visuals.Length);
		}
		return index;
	}

	public bool TryReturnBuildableExtendable<T>(out T buildableExtendable) where T : IBuildableExtendable
	{
		if (_buildableExtendables != null)
		{
			foreach (IBuildableExtendable buildableExtendable2 in _buildableExtendables)
			{
				if (buildableExtendable2 is T val)
				{
					buildableExtendable = val;
					return true;
				}
			}
		}
		buildableExtendable = default(T);
		return false;
	}

	public T ReturnExtendable<T>() where T : IBuildableExtendable
	{
		TryReturnBuildableExtendable<T>(out var buildableExtendable);
		return buildableExtendable;
	}

	public int ReturnBeautyScore()
	{
		int num = Properties.BeautyScore;
		if (TryReturnBuildableExtendable<DecorationSlots>(out var buildableExtendable))
		{
			num += buildableExtendable.BeautyScore;
		}
		return num;
	}

	public float ReturnWeight()
	{
		if (Properties.IgnoreWeight)
		{
			return 0f;
		}
		switch (_weightMode)
		{
		case BuildableSettings.WeightModes.Properties:
		{
			float num = Properties.Weight;
			foreach (IBuildableExtendable buildableExtendable in _buildableExtendables)
			{
				num += buildableExtendable.ReturnWeight();
			}
			return num * ReturnModifier(ModifierType.Weight);
		}
		case BuildableSettings.WeightModes.Items:
			return Inventory.Weight;
		default:
			Debug.LogException(new NotImplementedException());
			return 0f;
		}
	}

	public float ReturnConstructionWeight()
	{
		return _weightMode switch
		{
			BuildableSettings.WeightModes.Properties => ReturnWeight(), 
			BuildableSettings.WeightModes.Items => Inventory.ReturnWeight(SubInventoryType.Resources) + Inventory.ReturnWeight(SubInventoryType.Composition), 
			_ => throw new NotImplementedException(), 
		};
	}

	public float ReturnStorageWeight()
	{
		return _weightMode switch
		{
			BuildableSettings.WeightModes.Properties => 0f, 
			BuildableSettings.WeightModes.Items => Inventory.ReturnWeight(SubInventoryType.Storage) + Inventory.ReturnWeight(SubInventoryType.Import) + Inventory.ReturnWeight(SubInventoryType.Export) + Inventory.ReturnWeight(SubInventoryType.Liquid), 
			_ => throw new NotImplementedException(), 
		};
	}

	public bool HasActiveModule(ModuleProperties moduleProperties)
	{
		if ((bool)_moduleManager)
		{
			return _moduleManager.IsActiveModule(moduleProperties);
		}
		return false;
	}

	public float ReturnModifier(ModifierType modifierType)
	{
		if ((bool)_moduleManager)
		{
			return _moduleManager.ReturnModifier(modifierType);
		}
		return 1f;
	}

	private bool IsDefaultName(string name)
	{
		if (!(name == Properties.Name))
		{
			return name == Properties.GetDefaultEnglishName();
		}
		return true;
	}

	private void OnDrawGizmos()
	{
		if (Application.isPlaying)
		{
			if (OutlineCorners != null)
			{
				for (int i = 0; i < OutlineCorners.Count; i++)
				{
					Gizmos.color = Color.yellow;
					int index = (int)Mathf.Repeat(i + 1, OutlineCorners.Count);
					Gizmos.DrawLine(OutlineCorners[i].position, OutlineCorners[index].position);
				}
				if (BlockingPolygon != null)
				{
					BlockingPolygon.FastUpdate();
					BlockingPolygon.DrawPolygon(Color.green);
				}
			}
		}
		else if (Properties != null)
		{
			for (int j = 0; j < Properties.Outline.Length; j++)
			{
				Gizmos.color = Color.yellow;
				int num = (int)Mathf.Repeat(j + 1, Properties.Outline.Length);
				Gizmos.DrawLine(Properties.Outline[j].Vector3TopDown(), Properties.Outline[num].Vector3TopDown());
			}
			Vector2Polygon[] pathfindingOutlines = Properties.PathfindingOutlines;
			foreach (Vector2Polygon vector2Polygon in pathfindingOutlines)
			{
				vector2Polygon.DrawGizmo(Color.white);
			}
		}
	}

	public static Polygon CreateBlockingPolygon(BuildableProperties properties, float inset, Transform buildableTransform, Transform parent)
	{
		Transform transform = new GameObject("Blocker_Outline").transform;
		transform.SetParent(parent, worldPositionStays: false);
		List<Transform> list = new List<Transform>(properties.Outline.Length);
		Vector2 vector = properties.Outline.Average();
		for (int i = 0; i < properties.Outline.Length; i++)
		{
			int num = i - 1;
			if (num < 0)
			{
				num = properties.Outline.Length - 1;
			}
			int num2 = (i + 1) % properties.Outline.Length;
			Vector2 vector2 = properties.Outline[i];
			Vector2 vector3 = properties.Outline[num];
			Vector2 vector4 = properties.Outline[num2];
			Vector2 normalized = (vector2 - vector3).normalized;
			Vector2 normalized2 = (vector2 - vector4).normalized;
			Vector2 normalized3 = (normalized + normalized2).normalized;
			_ = (vector - vector2).normalized;
			Vector2 vector5 = vector2 - normalized3 * inset;
			Transform transform2 = new GameObject("BlockerOutlineCorner" + i).transform;
			transform2.SetParent(transform);
			transform2.localPosition = vector5.Vector3TopDown().SetY(0f);
			transform2.position = transform2.transform.position.SetY(0f);
			list.Add(transform2);
		}
		Polygon polygon = new Polygon();
		polygon.Initialize(buildableTransform, list);
		polygon.Update();
		return polygon;
	}

	public static bool IsPointOverlapping(Vector3 point)
	{
		foreach (Polygon blockingPolygon in BlockingPolygons)
		{
			if (blockingPolygon.ReturnPointIsOverlapping(point))
			{
				return true;
			}
		}
		return false;
	}

	public static Buildable Place(Buildable buildable, Vector3 position, Quaternion rotation, int visualIndex, bool instantPlacement = false)
	{
		Buildable buildable2 = UnityEngine.Object.Instantiate(buildable, position.Leveled(), rotation);
		buildable2.Initialize(Community.PlayerCommunity, visualIndex);
		if (instantPlacement)
		{
			buildable2.FinishBuilding();
		}
		else
		{
			buildable2.StartBuilding();
		}
		BuildableEvent.Dispatch(GameEventType.BuildablePlaced, buildable);
		return buildable2;
	}

	public IBuildableExtendablePersistentData[] ReturnExtendablesPersistentData()
	{
		using ListPool<IBuildableExtendablePersistentData>.List list = ListPool<IBuildableExtendablePersistentData>.Get(_buildableExtendables.Count);
		for (int i = 0; i < _buildableExtendables.Count; i++)
		{
			IBuildableExtendable buildableExtendable = _buildableExtendables[i];
			if (buildableExtendable != null)
			{
				IBuildableExtendablePersistentData buildableExtendablePersistentData = buildableExtendable.ReturnPersistentData();
				if (buildableExtendablePersistentData != null)
				{
					list.Add(buildableExtendablePersistentData);
				}
			}
		}
		return list.ToArray();
	}
}
