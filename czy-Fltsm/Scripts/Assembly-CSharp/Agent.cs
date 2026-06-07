using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PajamaLlama.Debugs;
using PajamaLlama.Flotsam.Morale;
using PajamaLlama.Utilities;
using UnityEngine;
using UnityEngine.Events;

[SelectionBase]
[RequireComponent(typeof(Inventory), typeof(Vitals), typeof(Navigator))]
[RequireComponent(typeof(Morale))]
public class Agent : ActorBehaviour, ISelectable, IPersistentReference, IAgentReference, ITooltipProvider, IPanelContext, IDialogueContextProvider, IOutlineRenderControllerProvider
{
	public delegate void Event(Agent agent);

	public enum EGender
	{
		Female = 0,
		Male = 1
	}

	[Header("Components")]
	public Vitals Vitals;

	public Inventory Inventory;

	public WorldIconHandler WorldIconHandler;

	public SelectionLink SelectionLink;

	[SerializeField]
	private SelectionCollider _selectionCollider;

	[SerializeField]
	private Navigator _navigator;

	[SerializeField]
	private PhysicsController _physicsController;

	[SerializeField]
	private OutlineRendererComponent _outlineRenderer;

	[HideInInspector]
	public AssignmentPanelEntry AssignmentPanelEntry;

	[HideInInspector]
	public Boat Boat;

	[HideInInspector]
	public Activity CurrentActivity;

	[HideInInspector]
	public bool IsCaptain;

	[HideInInspector]
	public bool IsInWater;

	private List<Assignment> _assignmentsByPriority;

	private bool _sortAssignmentsByPriority;

	private ProjectAssignment _assignment;

	private HierarchicalNodeMarker _nodeToMoveAwayFrom;

	private Coroutine _moveToFreeNodeCoroutine;

	public bool Initialized { get; private set; }

	public AgentDescriptor Descriptor { get; protected set; }

	public AgentProperties Properties => Descriptor.Properties;

	public override string Name => Descriptor.Name;

	public List<Assignment> Assignments { get; } = new List<Assignment>();

	[HideInInspector]
	public House ReservedHouse { get; private set; }

	public bool IsAlive { get; private set; } = true;

	public DrifterAttributes Attributes { get; private set; }

	public Morale Morale { get; private set; }

	public Quirks Quirks { get; private set; }

	public int PersistentIndex { get; set; } = -1;

	public ProjectAssignment Assignment
	{
		get
		{
			return _assignment;
		}
		set
		{
			_assignment = value;
			OnAssignmentUpdatedEvent?.Invoke(this);
		}
	}

	public Boat ReservedBoat { get; set; }

	public bool SalvageLock { get; set; }

	public DrifterRig DrifterRig { get; private set; }

	public ObjectType ObjectType => ObjectType.Agent;

	public GameObject RelatedGameObject => base.gameObject;

	public Vector3 LocalPosition => base.transform.position;

	public override PanelID PanelID => PanelID.AgentPanel;

	public bool HasActiveTalkObjective { get; private set; }

	DialogueTreeProperties IDialogueContextProvider.DialogueProperties
	{
		get
		{
			if (!(Descriptor.AgentProfile != null))
			{
				return null;
			}
			return Descriptor.AgentProfile.DialogueProperties;
		}
	}

	IReadOnlyList<DialogueTriggerType> IDialogueContextProvider.SupportedTriggers => null;

	public Agent AgentReference => this;

	public UnityEvent OnAgentUpdated { get; private set; } = new UnityEvent();

	public OutlineRenderController OutlineController
	{
		get
		{
			if (!IsAlive)
			{
				return null;
			}
			return DrifterRig.OutlineRenderController;
		}
	}

	public GlobalHaulingPriorities GlobalHaulingPriorities { get; private set; } = new GlobalHaulingPriorities();

	public UnityEvent OnDeath { get; private set; } = new UnityEvent();

	public UnityEvent OnBoatBoard { get; private set; } = new UnityEvent();

	public UnityEvent OnBoatLeave { get; private set; } = new UnityEvent();

	public UnityEvent<Agent> OnAssignmentUpdatedEvent { get; private set; } = new UnityEvent<Agent>();

	public UnityEvent OnSelectedEvent { get; private set; } = new UnityEvent();

	public UnityEvent OnDeselectedEvent { get; private set; } = new UnityEvent();

	private void Start()
	{
		Navigator navigator = ReturnNavigator();
		if (base.Community.IsPlayerCommunity() && !navigator.Validate())
		{
			navigator.AttachToTarget(FlotsamGame.ReturnClosest(base.transform.position, base.Community.Constructions).Target);
		}
		GameEventDispatcher.AddListener(GameEventType.TownheartMoved, OnTownheartMoved);
		TryGoToTown();
	}

	public void Spawn(AgentDescriptor descriptor, Community community)
	{
		Initialize(descriptor);
		ApplyPastBackground();
		ApplyPresentBackground();
		ApplyLooks();
		community.AddAgent(this, showNotification: false);
		OnAgentUpdated.Invoke();
		FinalUpdate.RegisterEndOfFrameOneShot(delegate
		{
			AgentEvent.Dispatch(GameEventType.AgentSpawn, this);
		});
	}

	public void Initialize(AgentDescriptor descriptor)
	{
		Descriptor = descriptor;
		ApplyAssignmentTemplate();
		Attributes = UnityEngine.Object.Instantiate(Properties.AttributeProperties);
		Attributes.Initialize(this);
		Attributes.AttributesUpdatedEvent.AddListener(OnModifierUpdated);
		Morale = GetComponent<Morale>();
		Morale.Initialize(this);
		Morale.CategoryUpdatedEvent.AddListener(OnModifierUpdated);
		Quirks = GetComponent<Quirks>();
		Quirks.Initialize(this);
		Inventory.Initialize(InventoryType.Agent);
		Inventory.GetOrAddSubInventory(SubInventoryType.Storage, Properties.StorageCapacity);
		Vitals.Initialize(this);
		_selectionCollider.Initialize(base.gameObject);
		SelectionLink.SetObjectToSelect(base.gameObject, ObjectType.Agent);
		IsInWater = _navigator.Terrain == Navigator.TerrainType.WaterSurface || _navigator.Terrain == Navigator.TerrainType.Underwater;
		_physicsController.Initialize();
		_physicsController.ShouldApplyCurrent = IsInWater;
		Initialized = true;
	}

	private void LateUpdate()
	{
		if (InPlayerCommunity() && IsAlive && ValidateNavigator())
		{
			if (Assignment == null && Descriptor.TryGetQuestToStart(out var questProperties))
			{
				StoryManager.StartQuest(questProperties, Descriptor);
			}
			AssignProject();
			if (Assignment == null)
			{
				UpdateActivity(Activity.Idling);
			}
		}
	}

	private void OnDestroy()
	{
		Attributes?.AttributesUpdatedEvent.RemoveListener(OnModifierUpdated);
		Morale?.CategoryUpdatedEvent.RemoveListener(OnModifierUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, OnTownheartMoved);
		GameEventDispatcher.RemoveListener(GameEventType.DialogueEnded, OnDialogueEnded);
	}

	public void LookAtObject(Transform targetTransform)
	{
		Vector3 worldPosition = new Vector3(targetTransform.position.x, base.transform.position.y, targetTransform.position.z);
		base.transform.LookAt(worldPosition);
	}

	public void MoveToFreeNode(HierarchicalNodeMarker node)
	{
		_nodeToMoveAwayFrom = node;
		if (_moveToFreeNodeCoroutine == null)
		{
			_moveToFreeNodeCoroutine = StartCoroutine(MoveToFreeNodeCoroutine());
		}
	}

	private IEnumerator MoveToFreeNodeCoroutine()
	{
		while (LoadingScreen.IsLoading || Overlays.OverlayType == Overlays.Type.Architect)
		{
			yield return null;
		}
		if (Assignment == null)
		{
			new Project(GameManager.Settings.ProjectSettings.MoveToFreeNodeProperties, _nodeToMoveAwayFrom.gameObject).AssignAgent(this);
		}
		_nodeToMoveAwayFrom = null;
		_moveToFreeNodeCoroutine = null;
	}

	public void ResetToTown(bool ignoreTerrain = false)
	{
		if ((bool)Boat)
		{
			Boat.ResetToTown();
			Boat.Disembark(this);
		}
		if (IsCaptain || (bool)Boat)
		{
			Debug.LogError("Agent " + Descriptor.Name + " is getting reset to town while still in a Boat!");
		}
		if (_navigator.Terrain != Navigator.TerrainType.Construction || ignoreTerrain)
		{
			_navigator.AttachToNode(ReturnClosestConstruction(onlyFinished: true).Target.PrimaryMarker.Node);
		}
		TryGoToTown();
	}

	public void ForceDescriptor(AgentDescriptor descriptor)
	{
		if (!(descriptor == Descriptor))
		{
			RemoveBackground(Descriptor.PastBackground);
			RemoveBackground(Descriptor.PresentBackground);
			Descriptor = descriptor;
			SetName(Descriptor.Name);
			ApplyPastBackground();
			ApplyPresentBackground();
			ApplyLooks();
		}
	}

	public void ForcePastBackground(DrifterAttributesEffect background)
	{
		RemoveBackground(Descriptor.PastBackground);
		Descriptor.SetPastBackground(background);
		ApplyPastBackground();
		ApplyLooks();
	}

	private void ApplyPastBackground()
	{
		DrifterAttributesEffect pastBackground = Descriptor.PastBackground;
		ApplyBackground(pastBackground);
		if (InPlayerCommunity())
		{
			SetAssignmentEnabled(pastBackground.Assignment, enabled: true, pastBackground.AssignmentPriority);
		}
		base.Community?.TriggerAgentUpdatedEvents();
	}

	private void ApplyPresentBackground()
	{
		ApplyBackground(Descriptor.PresentBackground);
	}

	private void ApplyBackground(DrifterAttributesEffect background)
	{
		Attributes.AddEffect(background);
		background.ApplyQuirks(this);
	}

	private void RemoveBackground(DrifterAttributesEffect background)
	{
		Attributes.RemoveEffect(background);
		background.RemoveQuirks(this);
	}

	public void Reroll(List<DrifterAttributesEffect> pastBackgrounds, List<DrifterAttributesEffect> presentBackgrounds)
	{
		RemoveBackground(Descriptor.PastBackground);
		RemoveBackground(Descriptor.PresentBackground);
		Descriptor.Reroll(FlotsamGame.Random(pastBackgrounds), FlotsamGame.Random(presentBackgrounds));
		base.Community?.TriggerAgentUpdatedEvents();
	}

	public void JoinCommunity(Community community)
	{
		if (base.Community != null)
		{
			base.Community.RemoveAgent(this);
		}
		base.Community = community;
		if (community.IsPlayerCommunity())
		{
			community.Research.AddResearchPoints(Attributes.Level);
			GetComponentInChildren<SelectionLink>().Type = ObjectType.CommunityMember;
			ApplyAssignmentTemplate();
		}
	}

	public void DropToInventory(Inventory inventory, SubInventoryType inventoryList)
	{
		Item item = Inventory.PeekAtFirstItem(inventoryList);
		Item item2 = Inventory.TakeItem(item);
		item2.InventoryType = (inventory.CompareTag("Boat") ? InventoryType.Boat : InventoryType.Storage);
		inventory.AddItem(item2, inventoryList);
	}

	public AssignmentPriority GetPriority(AssignmentType assignment)
	{
		return Assignments.Find((Assignment assignmentToCheck) => assignmentToCheck.Type == assignment).Priority;
	}

	public void KillAgent()
	{
		IsAlive = false;
		if (Assignment != null)
		{
			Debugger.Error(Name + " died while they still had a project.", this);
		}
		StopAllCoroutines();
		Selector.Deselect(base.gameObject);
		CameraController.Instance.Unlock(base.gameObject);
		base.Community.RemoveAgent(this);
		UpdateActivity(Activity.Dead);
		if (_navigator.Terrain != Navigator.TerrainType.Construction && _navigator.Terrain != Navigator.TerrainType.Vessel)
		{
			_physicsController.Sink();
		}
		PortraitGenerator.RemovePortrait(Descriptor);
		_navigator.StopIdling();
		OnDeath.Invoke();
		AgentEvent.Dispatch(GameEventType.AgentDeath, this);
		_navigator.StopNavigation(ProjectFlags.Cancelled);
		Descriptor.OnAgentKilled();
	}

	public void UpdateActivity(Activity newActivity)
	{
		if (CurrentActivity != newActivity)
		{
			CurrentActivity = newActivity;
			DrifterRig.UpdateActivity(newActivity);
		}
	}

	public void UpdateAgentTerrain(Navigator.TerrainType terrain)
	{
		switch (terrain)
		{
		default:
			_physicsController.EnableCollider(primaryEnabled: false, secondaryEnabled: true);
			_physicsController.PhysicsActive(active: true);
			break;
		case Navigator.TerrainType.Vessel:
			_physicsController.PhysicsActive(active: false);
			break;
		case Navigator.TerrainType.WaterSurface:
			_physicsController.EnableCollider(primaryEnabled: true, secondaryEnabled: false);
			_physicsController.PhysicsActive(active: true);
			break;
		case Navigator.TerrainType.Underwater:
		case Navigator.TerrainType.Sky:
			_physicsController.EnableCollider(primaryEnabled: true, secondaryEnabled: false);
			_physicsController.PhysicsActive(active: false);
			break;
		case Navigator.TerrainType.Construction:
		case Navigator.TerrainType.UnityNavMesh:
			_physicsController.EnableCollider(primaryEnabled: false, secondaryEnabled: true);
			_physicsController.PhysicsActive(active: false);
			break;
		case Navigator.TerrainType.OutOfBounds:
			OnOutOfBounds();
			break;
		}
		IsInWater = terrain == Navigator.TerrainType.WaterSurface || terrain == Navigator.TerrainType.Underwater;
		_physicsController.ShouldApplyCurrent = IsInWater;
		if (_navigator.Terrain != Navigator.TerrainType.Vessel)
		{
			DrifterRig.MeshAnimator.UpdateAnimator();
		}
		AgentEvent.Dispatch(GameEventType.AgentTerrainChanged, this);
	}

	private void ApplyLooks(DrifterRigPersistentData drifterRigData = null)
	{
		UpdateRig(drifterRigData);
		if (drifterRigData == null)
		{
			Descriptor.ApplyLooks(DrifterRig);
		}
		else
		{
			Descriptor.RestoreLooks(DrifterRig);
		}
		DrifterRig.SetAttributeVariation(Descriptor.AttributesVariation);
		PortraitGenerator.GeneratePortrait(Descriptor);
	}

	private void UpdateRig(DrifterRigPersistentData drifterRigData = null)
	{
		if (DrifterRig != null && DrifterRig.Gender != Descriptor.Gender)
		{
			UnityEngine.Object.Destroy(DrifterRig);
			DrifterRig = null;
		}
		if (DrifterRig == null)
		{
			DrifterRig = DrifterRig.Instantiate(Descriptor, base.transform, drifterRigData);
		}
		OnModifierUpdated();
	}

	public void ApplyAlternativeLook(DrifterLookProperties alternativeLookProperties)
	{
		Descriptor.ApplyAlternativeLook(alternativeLookProperties, DrifterRig);
	}

	public void UndoAlternativeLook(DrifterLookProperties alternativeLookProperties)
	{
		Descriptor.UndoAlternativeLook(alternativeLookProperties, DrifterRig);
	}

	public void ApplyAssignmentTemplate()
	{
		if (!InPlayerCommunity())
		{
			return;
		}
		Dictionary<AssignmentType, AssignmentPriority> assignmentPriorityTemplates = GameManager.AgentManager.AssignmentPriorityTemplates;
		int count = GameManager.Settings.ProjectSettings.AssignmentSettings.Count;
		foreach (AssignmentSetting assignmentSetting in GameManager.Settings.ProjectSettings.AssignmentSettings)
		{
			if (assignmentSetting.Type != AssignmentType.None)
			{
				if (!assignmentPriorityTemplates.TryGetValue(assignmentSetting.Type, out var value))
				{
					value = AssignmentPriority.Default;
				}
				if (!TryUpdateAssignmentPriority(assignmentSetting.Type, value))
				{
					Assignments.Add(new Assignment(assignmentSetting, value, count--, this, Properties.VitalProperties.AssignmentTypes.Contains(assignmentSetting.Type)));
				}
			}
		}
		if (Descriptor.PastBackground != null)
		{
			SetAssignmentEnabled(Descriptor.PastBackground.Assignment, enabled: true, Descriptor.PastBackground.AssignmentPriority);
		}
		_sortAssignmentsByPriority = true;
	}

	public bool TryUpdateAssignmentPriority(AssignmentType assignmentType, AssignmentPriority newPriority)
	{
		if (TryReturnAssignment(out var assignment, assignmentType))
		{
			SetAssignmentPriority(assignment, newPriority);
		}
		return false;
	}

	public void EnableAssignment(AssignmentType assignmentType)
	{
		if (TryReturnAssignment(out var assignment, assignmentType))
		{
			assignment.Enabled = true;
		}
		else if (assignmentType != AssignmentType.None)
		{
			Debug.LogException(new Exception($"'{Name}' was unable to enable assignment '{assignmentType}'."));
		}
	}

	public void SetAssignmentEnabled(AssignmentType assignmentType, bool enabled, AssignmentPriority priority)
	{
		if (TryReturnAssignment(out var assignment, assignmentType))
		{
			assignment.SetEnabled(enabled);
			SetAssignmentPriority(assignment, priority, alwaysUpdate: true);
		}
		else if (assignmentType != AssignmentType.None)
		{
			Debug.LogException(new Exception($"'{Name}' was unable to enable assignment '{assignmentType}'."));
		}
	}

	private void SetAssignmentPriority(Assignment assignment, AssignmentPriority priority, bool alwaysUpdate = false)
	{
		if (assignment.UpdatePriority(priority) || base.enabled)
		{
			if (_assignment != null && !_assignment.RemainsPriority(assignmentPriorityOnly: true))
			{
				_assignment.Stop(ProjectFlags.Priority);
			}
			_sortAssignmentsByPriority = true;
		}
		GlobalHaulingPriorities.Update(Assignments);
	}

	public bool TryGoToTown(Project previousProject = null)
	{
		if (this == null || Assignment != null)
		{
			return false;
		}
		Project project = null;
		ListPool<Item>.List storeableItems;
		if ((bool)_navigator && _navigator.Terrain == Navigator.TerrainType.UnityNavMesh)
		{
			Target target = previousProject?.NavigationTarget;
			if (target == null && _navigator.TryReturnNavMeshOwnerComponent<Landmark>(out var component) && (bool)component.Obstacle)
			{
				target = component.Obstacle.ReturnTarget() as Target;
			}
			if ((bool)target)
			{
				if (!_navigator.enabled)
				{
					_navigator.enabled = true;
				}
				ProjectProperties properties;
				GameObject target2;
				if (target.TryReturnAvailableBoat(this, out var boat))
				{
					properties = GameManager.Settings.ProjectSettings.GoToTownFromLandmark;
					target2 = boat.gameObject;
				}
				else
				{
					properties = GameManager.Settings.ProjectSettings.GoToTownFromLandmarkSwimming;
					target2 = ((previousProject == null) ? target.gameObject : previousProject.Target);
				}
				project = new Project(properties, target2, Inventory.ReturnAllItems(SubInventoryType.Storage));
			}
			else
			{
				Debug.LogException(new Exception("'" + Name + "' seems to be stuck on a Landmark with no way to get back to the town, executing emergency ResetToTown!"));
				OnOutOfBounds();
			}
		}
		else if (TryReturnStorableItems(out storeableItems))
		{
			project = new Project(GameManager.Settings.ProjectSettings.ClearInventoryProperties, Construction.Townheart.gameObject, storeableItems);
			storeableItems.Dispose();
		}
		else if (ReturnNavigator().Terrain != Navigator.TerrainType.Construction)
		{
			project = new Project(GameManager.Settings.ProjectSettings.GoToTownProperties, Construction.Townheart.gameObject);
		}
		if (project == null)
		{
			return false;
		}
		if (project.AssignAgent(this))
		{
			return true;
		}
		Debug.LogException(new Exception($"'{Name}' could not be assigned to the go-to-town project '{project.Properties}'"));
		return false;
	}

	private bool TryReturnStorableItems(out ListPool<Item>.List storeableItems)
	{
		using ListPool<Item>.List list = ListPool<Item>.Get();
		Inventory.ReturnAllItems(SubInventoryType.Storage, list);
		if (list.IsNullOrEmpty())
		{
			storeableItems = null;
			return false;
		}
		storeableItems = ListPool<Item>.Get(list.Count);
		foreach (Item item in list)
		{
			item.CancelReservation();
			if (base.Community.ReserveIncomingItems(item, SubInventoryType.Storage))
			{
				storeableItems.Add(item);
			}
		}
		return 0 < storeableItems.Count;
	}

	public void SetHouse(House house)
	{
		if (ReservedHouse != house)
		{
			ReservedHouse = house;
			AgentEvent.Dispatch(GameEventType.AgentHouseUpdated, this);
		}
	}

	public void SetName(string newName)
	{
		Descriptor.SetName(newName);
	}

	public bool Study(float studyTime, float experienceGainPerSecond)
	{
		if (studyTime <= 0f)
		{
			return false;
		}
		ExpertiseManager.Instance.IncreaseExperience(this, experienceGainPerSecond * studyTime, applyMoraleEffect: false);
		return true;
	}

	private void AssignProject()
	{
		if ((Assignment == null || Assignment.AllowsDeprioritization) && !TryGoToTown() && !Vitals.AssignProject())
		{
			base.Community.AssignProject(this);
		}
	}

	public bool TryStartAssociatedQuest()
	{
		if (StoryManager.TryStartPendingQuest(this))
		{
			GameEventDispatcher.AddListener(GameEventType.DialogueEnded, OnDialogueEnded);
			return true;
		}
		return false;
	}

	public void SetHasActiveTalkObjective(bool hasActiveObjective)
	{
		HasActiveTalkObjective = hasActiveObjective;
		AgentEvent.Dispatch(GameEventType.AgentMessageUpdated, this);
	}

	private bool ValidateNavigator()
	{
		if (ReturnNavigator().ReturnIsOutOfBounds())
		{
			OnOutOfBounds();
			return false;
		}
		return true;
	}

	private void OnOutOfBounds()
	{
		if (Assignment != null)
		{
			Assignment.Stop(ProjectFlags.OutOfBounds);
		}
		else
		{
			ResetToTown();
		}
	}

	public override void PrepareForRescue()
	{
		Navigator navigator = ReturnNavigator();
		navigator.enabled = true;
		navigator.UpdateTerrain(Navigator.TerrainType.UnityNavMesh);
		if ((bool)Descriptor.AgentProfile && !Descriptor.AgentProfile.Items.IsNullOrEmpty())
		{
			ItemProperties[] items = Descriptor.AgentProfile.Items;
			foreach (ItemProperties properties in items)
			{
				Inventory.AddItem(new Item(properties), SubInventoryType.Storage);
			}
		}
	}

	public override void Rescue(Project rescueProject = null, Boat rescueBoat = null)
	{
		Project project = null;
		Community.PlayerCommunity.AddAgent(this);
		AgentEvent.Dispatch(GameEventType.AgentRescue, this);
		if ((bool)rescueBoat)
		{
			project = new Project(GameManager.Settings.ProjectSettings.GoToTownFromLandmarkSwimming, rescueBoat.gameObject);
		}
		else if (rescueProject != null)
		{
			project = new Project(GameManager.Settings.ProjectSettings.GoToTownFromLandmarkSwimming, rescueProject.Target);
		}
		if (project != null && base.Community.QueueProject(project))
		{
			project.AssignAgent(this);
		}
		else
		{
			TryGoToTown();
		}
	}

	public void RestoreSpawn(AgentDescriptor descriptor, Community community, AgentPersistentData data)
	{
		Initialize(descriptor);
		ApplyPastBackground();
		ApplyPresentBackground();
		ApplyLooks(data.DrifterRig);
		community.AddAgent(this, showNotification: false);
		OnAgentUpdated.Invoke();
	}

	public Construction ReturnClosestConstruction(bool onlyFinished)
	{
		Construction construction = Construction.Townheart;
		float num = Vector3.Distance(base.transform.position, construction.transform.position);
		for (int i = 0; i < Community.PlayerCommunity.Constructions.Count; i++)
		{
			Construction construction2 = Community.PlayerCommunity.Constructions[i];
			if (!onlyFinished || construction2.Buildable.BuildPhase == BuildPhase.Finished)
			{
				float num2 = Vector3.Distance(base.transform.position, construction2.transform.position);
				if (!(num2 > num))
				{
					num = num2;
					construction = construction2;
				}
			}
		}
		return construction;
	}

	public Construction ReturnClosestWalkwayConstruction()
	{
		Construction construction = Construction.Townheart;
		float num = Vector3.Distance(base.transform.position, construction.transform.position);
		foreach (Buildable buildable in Community.PlayerCommunity.Buildables)
		{
			if (buildable.BuildPhase == BuildPhase.Finished && buildable.TryGetComponent<Construction>(out var component) && (buildable.TryReturnBuildableExtendable<WalkwaySegment>(out var _) || buildable.TryReturnBuildableExtendable<WalkwayPonton>(out var _)))
			{
				float num2 = Vector3.Distance(base.transform.position, component.transform.position);
				if (num2 < num)
				{
					num = num2;
					construction = component;
				}
			}
		}
		return construction;
	}

	public Storage ReturnClosestStorage(Item item)
	{
		Storage storage = (from storage2 in base.Community.ReturnAvailableStorages(item)
			orderby Vector3.Distance(storage2.transform.position, item.Inventory.transform.position)
			select storage2).FirstOrDefault();
		if (storage == null)
		{
			Debugger.Warning($"No available storage found to {Name} for {item.Properties.name}!");
		}
		return storage;
	}

	public Buildable ReturnCurrentBuildable()
	{
		if (IsCaptain)
		{
			return Boat.Buildable;
		}
		if ((bool)_navigator && _navigator.ReturnPathfindingNode(null) is HierarchicalNode hierarchicalNode && hierarchicalNode.Marker.Construction != null)
		{
			return hierarchicalNode.Marker.Construction.Buildable;
		}
		return null;
	}

	public Navigator ReturnNavigator(bool alwaysReturnDrifter = false)
	{
		if (alwaysReturnDrifter)
		{
			return _navigator;
		}
		if (_navigator.Terrain != Navigator.TerrainType.Vessel)
		{
			return _navigator;
		}
		return Boat.Navigator;
	}

	public Inventory ReturnInventory()
	{
		if (Boat == null)
		{
			return Inventory;
		}
		return Boat.Buildable.Inventory;
	}

	public bool InPlayerCommunity()
	{
		if (base.Community != null && base.Community.IsPlayerCommunity())
		{
			return base.Community.Agents.Contains(this);
		}
		return false;
	}

	public bool ReturnHasMessageQueued()
	{
		return HasActiveTalkObjective;
	}

	public bool HasQuestToStart()
	{
		return Descriptor.HasQuestToStart();
	}

	public List<Assignment> ReturnAssignmentsByPriority()
	{
		if (_sortAssignmentsByPriority)
		{
			if (_assignmentsByPriority == null)
			{
				_assignmentsByPriority = new List<Assignment>(Assignments);
			}
			else
			{
				_assignmentsByPriority.Clear();
				_assignmentsByPriority.AddRange(Assignments);
			}
			Sorting.SlowSort(_assignmentsByPriority);
			_sortAssignmentsByPriority = false;
		}
		return _assignmentsByPriority;
	}

	public bool ReturnAcceptsAssignmentType(AssignmentType assignmentType)
	{
		if (TryReturnAssignment(out var assignment, assignmentType))
		{
			return assignment.Enabled;
		}
		return false;
	}

	private bool TryReturnAssignment(out Assignment assignment, AssignmentType assignmentType)
	{
		assignment = null;
		if (assignmentType == AssignmentType.None)
		{
			return false;
		}
		int count = Assignments.Count;
		while (0 < count--)
		{
			assignment = Assignments[count];
			if (assignment.Type == assignmentType)
			{
				return true;
			}
		}
		return false;
	}

	public bool TryReturnAttribute(AssignmentType assignmentType, out DrifterAttributes.Attribute attribute)
	{
		foreach (Assignment assignment in Assignments)
		{
			if (assignment.Type == assignmentType && assignment.Enabled)
			{
				return Attributes.TryReturnAttribute(assignmentType, out attribute);
			}
		}
		attribute = null;
		return false;
	}

	private void OnDialogueEnded(GameEvent gameEvent)
	{
		AgentEvent.Dispatch(GameEventType.AgentMessageUpdated, this);
		GameEventDispatcher.RemoveListener(GameEventType.DialogueEnded, OnDialogueEnded);
	}

	private void OnTownheartMoved(GameEvent evt)
	{
		if (InPlayerCommunity() && evt is MovementEvent movementEvent)
		{
			Navigator navigator = ReturnNavigator();
			Navigator.TerrainType terrain = navigator.Terrain;
			if (terrain == Navigator.TerrainType.WaterSurface || (uint)(terrain - 3) <= 1u)
			{
				movementEvent.ApplyMovementToTransformLocal(navigator.transform);
				ValidateNavigator();
			}
		}
	}

	private void OnModifierUpdated()
	{
		if ((bool)DrifterRig)
		{
			DrifterAttributes.Attribute attribute = Attributes.ReturnAttribute(DrifterAttributes.AttributeType.Athletics);
			DrifterRig.MeshAnimator.SetFloat(attribute.AnimationParameter, Attributes.ReturnAttributeModifier(attribute));
		}
	}

	public void OnUnderCursor()
	{
		if (IsAlive)
		{
			CursorManager.SetCursorState(CursorState.Select);
		}
		else
		{
			CursorManager.SetCursorState(CursorState.Normal);
		}
	}

	public void OnShowTooltip()
	{
		if (IsAlive && base.Community.IsPlayerCommunity())
		{
			TooltipPanel.ShowTooltip(this);
		}
	}

	public void OnSelected(bool playSelectionSound)
	{
		if (IsAlive && InPlayerCommunity())
		{
			AudioManager.Play(Descriptor.VoicePack.HelloSounds, base.transform);
			if (!TryStartAssociatedQuest() && !HasActiveTalkObjective)
			{
				GameManager.UIManager.DisplayPanel(this);
			}
			OnSelectedEvent.Invoke();
			AgentEvent.Dispatch(GameEventType.AgentSelected, this);
		}
	}

	public void OnDeselected()
	{
		if (GameManager.UIManager != null)
		{
			GameManager.UIManager.CloseDrifterPanel();
			GameManager.UIManager.DisableDynamicPortrait(this);
		}
		if (ReturnNavigator().enabled)
		{
			ReturnNavigator().LineRenderer.EnablePathVisuals(enabled: false);
		}
		_outlineRenderer.ResetHighlightOutline();
		OnDeselectedEvent.Invoke();
		AgentEvent.Dispatch(GameEventType.AgentDeselected, this);
	}

	public string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return Name;
	}

	bool IDialogueContextProvider.IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		return false;
	}

	public static int SortByHunger(Agent a1, Agent a2)
	{
		int num = a2.Vitals.Hunger.Amount.CompareTo(a1.Vitals.Hunger.Amount);
		if (num != 0)
		{
			return num;
		}
		return SortByDanger(a1, a2);
	}

	public static int SortByThirst(Agent a1, Agent a2)
	{
		int num = a2.Vitals.Thirst.CompareTo(a1.Vitals.Thirst);
		if (num != 0)
		{
			return num;
		}
		return SortByDanger(a1, a2);
	}

	public static int SortByLevelLowToHigh(Agent a1, Agent a2)
	{
		return a1.Attributes.Level.CompareTo(a2.Attributes.Level);
	}

	public static int SortByLevelHighToLow(Agent a1, Agent a2)
	{
		return a2.Attributes.Level.CompareTo(a1.Attributes.Level);
	}

	public static int SortByDanger(Agent a1, Agent a2)
	{
		int num = a1.Vitals.ReturnDangerScore() - a2.Vitals.ReturnDangerScore();
		if (num != 0)
		{
			return num;
		}
		return SortByLevelHighToLow(a1, a2);
	}
}
