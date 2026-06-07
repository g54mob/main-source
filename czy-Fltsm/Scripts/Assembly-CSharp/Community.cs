using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using I2.Loc;
using M4.Session;
using PajamaLlama.Debugs;
using PajamaLlama.Flotsam.Morale;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.Events;

public class Community
{
	public enum Type
	{
		Regular = 0,
		Player = 1,
		Abandoned = 2
	}

	public const string EDITOR_NAME = "Editor Town";

	public const string DEBUG_NAME = "_DEBUG_";

	public UnityEvent<IPlaceable, bool> OnStoredBuildableAdded = new UnityEvent<IPlaceable, bool>();

	public UnityEvent<IPlaceable> OnStoredBuildableRemoved = new UnityEvent<IPlaceable>();

	public CommunityResearch Research;

	[NonSerialized]
	public CommunityInventory Inventory;

	public string Name;

	[HideInInspector]
	public List<Project> Projects = new List<Project>();

	public List<Rejuvenator> Rejuvenators = new List<Rejuvenator>();

	public List<Storage> Storages = new List<Storage>();

	public List<Marker> Markers = new List<Marker>();

	public static Community AbandonedCommunity = null;

	public static List<Community> Communities = new List<Community>();

	public static Community PlayerCommunity = null;

	private readonly Dictionary<BuildableProperties, List<Buildable>> _storedBuildables = new Dictionary<BuildableProperties, List<Buildable>>();

	private readonly Dictionary<DecorationProperties, List<Decoration>> _storedDecorations = new Dictionary<DecorationProperties, List<Decoration>>();

	private Type _type;

	private List<Boat> _boats = new List<Boat>();

	private List<House> _houses = new List<House>();

	private List<MooringPoint> _mooringPoints = new List<MooringPoint>();

	private ProjectManager _projectManager;

	private int _cycledAgentIndex;

	private List<Boat> _finishedBoats;

	private List<IItemReserver> _itemReservers;

	private List<AssignmentSetting> _assignmentsToEnable;

	public List<Agent> Agents { get; private set; } = new List<Agent>();

	public List<Bird> Birds { get; private set; } = new List<Bird>();

	public List<Buildable> Buildables { get; private set; } = new List<Buildable>();

	public Dictionary<BuildableCategory, List<Buildable>> CategorizedBuildables { get; } = new Dictionary<BuildableCategory, List<Buildable>>();

	public List<Construction> Constructions { get; private set; } = new List<Construction>();

	public List<IItemProducer> Producers { get; private set; } = new List<IItemProducer>();

	public List<BirdHouse> BirdHouses { get; private set; } = new List<BirdHouse>();

	public List<WalkwaySegment> WalkwaySegments { get; private set; } = new List<WalkwaySegment>();

	public List<WalkwayPonton> WalkwayPontons { get; private set; } = new List<WalkwayPonton>();

	public List<DecorationSlots> DecorationSlots { get; private set; } = new List<DecorationSlots>();

	public IReadOnlyDictionary<BuildableProperties, List<Buildable>> StoredBuildables => _storedBuildables;

	public IReadOnlyDictionary<DecorationProperties, List<Decoration>> StoredDecorations => _storedDecorations;

	public Engine Engine { get; set; }

	public Project GlobalHaulProject { get; set; }

	public Project GlobalWateringProject { get; set; }

	public Type CommunityType => _type;

	public HashSet<ItemProperties> FoundItems { get; private set; } = new HashSet<ItemProperties>();

	public int BeautyScore { get; private set; }

	public int WeightTierIndex { get; private set; }

	public GameplaySettings.WeightTier WeightTier { get; private set; }

	public event UnityAction AgentsUpdatedEvent;

	public event UnityAction BirdsUpdatedEvent;

	public event UnityAction BoatsUpdatedEvent;

	public event UnityAction HouseUpdateEvent;

	public event UnityAction MooringPointsUpdatedEvent;

	public event UnityAction BirdhousesUpdatedEvent;

	public event UnityAction BuildablesUpdatedEvent;

	public event UnityAction BeautyScoreUpdated;

	public Community(string name = "", Type type = Type.Regular)
	{
		if (type != Type.Regular && Communities.Find((Community community) => community._type == type) != null)
		{
			Debugger.Error($"Can't add another community of type {type}!");
			return;
		}
		if (string.IsNullOrEmpty(name))
		{
			if (type == Type.Player)
			{
				Name = Session.Profile.ActiveRun.CommunityName;
			}
			else
			{
				Name = GameSettings.Instance.DataSettings.ReturnRandomCommunityName();
			}
		}
		else
		{
			Name = name;
		}
		_type = type;
		if (type == Type.Player)
		{
			PlayerCommunity = this;
			Inventory = new CommunityInventory();
			Research = new CommunityResearch(this);
		}
		else if (type == Type.Abandoned)
		{
			AbandonedCommunity = this;
		}
		Communities.Add(this);
	}

	public static void DestroyAll()
	{
		for (int num = Communities.Count - 1; num > -1; num--)
		{
			Communities[num]?.OnDestroy();
		}
		Communities.Clear();
	}

	private void OnDestroy()
	{
		foreach (Storage storage in Storages)
		{
			if ((bool)storage && (bool)storage.Buildable && (bool)storage.Buildable.Inventory)
			{
				storage.Buildable.Inventory.Destroy();
			}
		}
		DestroyProjects();
		ClearEvents();
	}

	private void DestroyProjects()
	{
		for (int i = 0; i < Projects.Count; i++)
		{
			Projects[i].Destroy();
		}
		if ((bool)_projectManager)
		{
			_projectManager.Dispose();
		}
	}

	private void ClearEvents()
	{
		ClearEvent(this.AgentsUpdatedEvent);
		ClearEvent(this.BirdsUpdatedEvent);
		ClearEvent(this.BoatsUpdatedEvent);
		ClearEvent(this.HouseUpdateEvent);
		ClearEvent(this.MooringPointsUpdatedEvent);
		ClearEvent(this.BirdhousesUpdatedEvent);
		ClearEvent(this.BuildablesUpdatedEvent);
		ClearEvent(this.BeautyScoreUpdated);
		this.AgentsUpdatedEvent = null;
		this.BirdsUpdatedEvent = null;
		this.BoatsUpdatedEvent = null;
		this.HouseUpdateEvent = null;
		this.MooringPointsUpdatedEvent = null;
		this.BirdhousesUpdatedEvent = null;
		this.BuildablesUpdatedEvent = null;
		this.BeautyScoreUpdated = null;
	}

	private void ClearEvent(UnityAction unityAction)
	{
		if (unityAction != null)
		{
			Delegate[] invocationList = unityAction.GetInvocationList();
			foreach (Delegate obj in invocationList)
			{
				unityAction = (UnityAction)Delegate.Remove(unityAction, (UnityAction)obj);
			}
		}
	}

	public void AddAgent(Agent agent, bool showNotification = true)
	{
		if (!Agents.AddUnique(agent))
		{
			Debugger.Warning($"Tried adding agent {agent.Name} to the community but he/she was already a part.");
			return;
		}
		agent.JoinCommunity(this);
		EnableAssignments(agent);
		TriggerAgentUpdatedEvents();
		SelectionLink[] componentsInChildren = agent.GetComponentsInChildren<SelectionLink>();
		foreach (SelectionLink obj in componentsInChildren)
		{
			obj.Type = ObjectType.CommunityMember;
			obj.SetObjectToSelect(agent.gameObject, ObjectType.CommunityMember);
		}
		if (showNotification)
		{
			GameManager.UIManager.NotificationHandler.AddNotification(GameManager.Settings.UISettings.DrifterJoinedNotification, agent.gameObject, ObjectType.CommunityMember);
		}
		if (IsPlayerCommunity())
		{
			new AgentEvent(GameEventType.AgentAddedToPlayerCommunity, agent).Dispatch();
		}
	}

	private void EnableAssignments(Agent agent)
	{
		foreach (Assignment assignment in agent.Assignments)
		{
			if (assignment.Enabled && assignment.TryReturnSettings(out var assignmentSettings) && assignmentSettings.AppliesEnabledToAllAgents)
			{
				if (_assignmentsToEnable == null)
				{
					_assignmentsToEnable = new List<AssignmentSetting>();
				}
				_assignmentsToEnable.Add(assignmentSettings);
			}
		}
		if (_assignmentsToEnable.IsNullOrEmpty())
		{
			return;
		}
		foreach (AssignmentSetting item in _assignmentsToEnable)
		{
			foreach (Agent agent2 in Agents)
			{
				agent2.EnableAssignment(item.Type);
			}
		}
	}

	public void RemoveAgent(Agent agent)
	{
		if (!Agents.Remove(agent))
		{
			return;
		}
		if ((bool)_projectManager)
		{
			_projectManager.CancelAssignProject(agent);
		}
		agent.Community = null;
		if (!IsPlayerCommunity())
		{
			return;
		}
		foreach (Project project in Projects)
		{
			project.UnassignAgent(agent);
		}
		if (!TryTriggerGameOver())
		{
			new AgentEvent(GameEventType.AgentRemovedFromPlayerCommunity, agent).Dispatch();
			if (this.AgentsUpdatedEvent != null)
			{
				this.AgentsUpdatedEvent();
			}
		}
	}

	public void AddBird(Bird bird, bool showNotification = true)
	{
		if (!Birds.AddUnique(bird))
		{
			Debugger.Warning($"Tried adding bird {bird.Name} to the community but he/she was already a part.");
			return;
		}
		if (bird.Community != null)
		{
			bird.Community.RemoveBird(bird);
		}
		bird.Community = this;
		if (showNotification && IsPlayerCommunity())
		{
			GameManager.UIManager.NotificationHandler.AddNotification(GameManager.Settings.UISettings.SeagullJoinedNotification, bird.gameObject, ObjectType.Bird);
		}
		new BirdEvent(GameEventType.BirdAddedToCommunity, bird).Dispatch();
		if (this.BirdsUpdatedEvent != null)
		{
			this.BirdsUpdatedEvent();
		}
	}

	public void RemoveBird(Bird bird)
	{
		if (Birds.Remove(bird))
		{
			new BirdEvent(GameEventType.BirdRemovedFromCommunity, bird).Dispatch();
			bird.JoinCommunity(ReturnRandomCommunity());
			if (this.BirdsUpdatedEvent != null)
			{
				this.BirdsUpdatedEvent();
			}
		}
	}

	public void TriggerAgentUpdatedEvents()
	{
		if (this.AgentsUpdatedEvent != null)
		{
			this.AgentsUpdatedEvent();
		}
	}

	public void StopNonInteractableProjects(Vector3 townheartPosition, float interactionRadius = 0f)
	{
		int count = Projects.Count;
		while (0 < count--)
		{
			StopNonInteractableProject(Projects[count], townheartPosition, interactionRadius);
		}
		foreach (Agent agent in Agents)
		{
			foreach (Vital item in (IEnumerable<Vital>)agent.Vitals)
			{
				StopNonInteractableProject(item.Project, townheartPosition, interactionRadius);
			}
		}
	}

	private void StopNonInteractableProject(Project project, Vector3 townheartPosition, float interactionRadius = 0f)
	{
		if (project != null && project.Properties.StopOnMove && project.Target != null && !WorldManager.ReturnLocalToWorldPosition(project.Target.transform.position).IsInRangeXZ(townheartPosition, interactionRadius))
		{
			project.Stop(ProjectFlags.NonInteractable);
		}
	}

	public void CycleAgents(bool forward = true)
	{
		if (forward)
		{
			_cycledAgentIndex = (_cycledAgentIndex + 1) % Agents.Count;
		}
		else
		{
			_cycledAgentIndex = (_cycledAgentIndex - 1 + Agents.Count) % Agents.Count;
		}
		Selector.Select(Agents[_cycledAgentIndex].gameObject, ObjectType.CommunityMember);
		CameraController.Instance.Lock(Agents[_cycledAgentIndex].gameObject);
	}

	private bool TryTriggerGameOver()
	{
		if (IsPlayerCommunity() && Agents.Count == 0)
		{
			if (LoadingScreen.IsLoading)
			{
				GameEventDispatcher.AddListener(GameEventType.GameStart, TryTriggerGameOverOnGameStart);
			}
			else
			{
				GameManager.StoryManager.EndGame();
			}
			return true;
		}
		return false;
	}

	private void TryTriggerGameOverOnGameStart(GameEvent gameEvent)
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, TryTriggerGameOverOnGameStart);
		TryTriggerGameOver();
	}

	public void AssignProject(Agent agent)
	{
		if (_projectManager == null)
		{
			_projectManager = ProjectManager.CreateInstance(this);
		}
		_projectManager.AssignProject(agent);
	}

	public bool QueueProject(Project project)
	{
		if (project.Properties.IsGlobal && ReturnHasProjectWithProperties(project.Properties))
		{
			Debug.LogErrorFormat("Trying to queue global project '{0}', however the project is already queued with the community!!", project.Properties);
			return false;
		}
		if (Projects.AddUnique(project))
		{
			project.FinishedEvent.AddListener(OnProjectFinished);
			return true;
		}
		return false;
	}

	public void QueueGlobalProjects(ProjectSettings projectSettings)
	{
		ProjectProperties[] globalProjects = projectSettings.GlobalProjects;
		foreach (ProjectProperties projectProperties in globalProjects)
		{
			if (ReturnHasProjectWithProperties(projectProperties))
			{
				Debug.LogWarningFormat("Unable to queue global project '{0}', it is already queued!", projectProperties);
			}
			else
			{
				QueueProject(new Project(projectProperties, Construction.Townheart.gameObject));
			}
		}
	}

	private void OnProjectFinished(Project project, bool succes)
	{
		if (!Projects.Remove(project))
		{
			Debug.LogException(new Exception($"Can't remove project '{project.Properties}' from community queue as it was not in the queue."));
		}
	}

	public void AddBuildable(Buildable buildable)
	{
		if (!Buildables.AddUnique(buildable))
		{
			Debug.LogException(new Exception("Cannot add duplicate (" + buildable.name + ") buildables to the community."));
			return;
		}
		if (buildable.Properties.Category == null)
		{
			Debug.LogException(new Exception($"BuildableProperties '{buildable.Properties}' does not have a category set"));
		}
		else
		{
			if (!CategorizedBuildables.TryGetValue(buildable.Properties.Category, out var value))
			{
				value = new List<Buildable>();
				CategorizedBuildables.Add(buildable.Properties.Category, value);
			}
			value.Add(buildable);
		}
		UpdateBuildables();
		buildable.Community = this;
	}

	public void RemoveBuildable(Buildable buildable)
	{
		if (Buildables.RemoveSafely(buildable))
		{
			if ((bool)buildable.Properties.Category && CategorizedBuildables.TryGetValue(buildable.Properties.Category, out var value))
			{
				value.Remove(buildable);
			}
			UpdateBuildables();
			buildable.Community = null;
		}
	}

	public void UpdateBuildables()
	{
		this.BuildablesUpdatedEvent?.Invoke();
		int weightTierIndex = GameplaySettings.GetWeightTierIndex(ReturnWeight());
		if (WeightTierIndex != weightTierIndex)
		{
			WeightTierIndex = weightTierIndex;
			if (GameplaySettings.TryGetWeightTierData(WeightTierIndex, out var tierData))
			{
				WeightTier = tierData;
			}
		}
	}

	public void AddConstruction(Construction construction)
	{
		if (construction.Buildable.Community != this)
		{
			Debugger.Warning($"Cannot add construction ({construction.name}) to community as the buildable's community does not match this construction.");
		}
		else if (Constructions.AddUnique(construction))
		{
			BuildableEvent.Dispatch(GameEventType.ConstructionAddedToCommunity, construction.Buildable);
			UpdateBeautyScore();
		}
		else
		{
			Debugger.Warning($"Cannot add duplicate constructions ({construction.name}) to the community.");
		}
	}

	public void RemoveConstruction(Construction construction)
	{
		if (Constructions.RemoveSafely(construction))
		{
			BuildableEvent.Dispatch(GameEventType.ConstructionRemovedFromCommunity, construction.Buildable);
			UpdateBeautyScore();
		}
		else
		{
			Debugger.Warning($"Cannot remove constructions ({construction.name}) that was not in the community.");
		}
	}

	public void UpdateBeautyScore()
	{
		int num = 0;
		foreach (Construction construction in Constructions)
		{
			num += construction.Buildable.ReturnBeautyScore();
		}
		if (num != BeautyScore)
		{
			BeautyScore = num;
			this.BeautyScoreUpdated?.Invoke();
		}
	}

	public void AddStoredBuildable(BuildableProperties properties, Buildable buildable, bool toggleCategory = true)
	{
		_storedBuildables.GetOrCreate(properties).Add(buildable);
		OnStoredBuildableAdded.Invoke(properties, toggleCategory);
	}

	public void AddStoredDecoration(DecorationProperties properties, Decoration decoration, bool toggleCategory = true)
	{
		_storedDecorations.GetOrCreate(properties).Add(decoration);
		OnStoredBuildableAdded.Invoke(properties, toggleCategory);
	}

	public bool GetStoredBuildable(BuildableProperties properties, out Buildable buildable)
	{
		if (_storedBuildables.TryGetValue(properties, out var value) && 0 < value.Count)
		{
			int index = value.Count - 1;
			buildable = value[index];
			value.RemoveAt(index);
			OnStoredBuildableRemoved.Invoke(properties);
			return true;
		}
		buildable = null;
		return false;
	}

	public bool GetStoredDecoration(DecorationProperties properties, out Decoration decoration)
	{
		if (_storedDecorations.TryGetValue(properties, out var value) && !value.IsNullOrEmpty())
		{
			int index = value.Count - 1;
			decoration = value[index];
			value.RemoveAt(index);
			OnStoredBuildableRemoved.Invoke(properties);
			return true;
		}
		decoration = null;
		return false;
	}

	public int ReturnStoredBuildablesCount(bool onlyBuildings = false)
	{
		int num = 0;
		foreach (KeyValuePair<BuildableProperties, List<Buildable>> storedBuildable in _storedBuildables)
		{
			if (!onlyBuildings || (!(storedBuildable.Key.PlacementCursorProperties is EnergyPoleCursorProperties) && storedBuildable.Key.Prefab.GetComponent<WalkwayPonton>() == null))
			{
				num += storedBuildable.Value.Count;
			}
		}
		if (!onlyBuildings)
		{
			foreach (KeyValuePair<DecorationProperties, List<Decoration>> storedDecoration in _storedDecorations)
			{
				if (storedDecoration.Key is EnergyPoleDecorationProperties)
				{
					num += storedDecoration.Value.Count;
				}
			}
		}
		return num;
	}

	public void AddStorage(Storage storage)
	{
		if (Storages.AddUnique(storage))
		{
			Inventory.AddStorage(storage);
		}
	}

	public void RemoveStorage(Storage storage)
	{
		if (Storages.Remove(storage))
		{
			Inventory.RemoveStorage(storage);
		}
	}

	public bool SpawnItemToAvailableStorage(ItemProperties properties)
	{
		Item item = new Item(properties);
		Storage storage = ReturnAvailableStorages(item).FirstOrDefault();
		if (storage == null)
		{
			Debugger.Error($"Could not spawn {item.Properties.name} as there are no available storages.");
			return false;
		}
		GameManager.ResourceManager.SpawnItemToInventory(storage.Buildable.Inventory, item);
		return true;
	}

	public void ReserveIncomingItems(List<Item> items, List<Item> incoming, SubInventoryType type)
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (ReserveIncomingItems(items[i], type))
			{
				incoming.Add(items[i]);
			}
		}
	}

	public bool ReserveIncomingItems(Item item, SubInventoryType type)
	{
		foreach (Storage item2 in Storages.OrderBy((Storage storage) => (float)storage.Priority + Vector3.Distance(storage.gameObject.transform.position, item.Owner.transform.position)))
		{
			if (item2.ReserveIncomingItem(item))
			{
				return true;
			}
		}
		return false;
	}

	public void UnreserveStuckItems(Inventory inventory, SubInventoryType subInventory)
	{
		using ListPool<Item>.List list = ListPool<Item>.Get();
		inventory.ReturnAllItems(subInventory, list);
		UnreserveStuckItem(list);
	}

	public void UnreserveStuckItems(SubInventory subInventory)
	{
		using ListPool<Item>.List list = ListPool<Item>.Get();
		subInventory.ReturnAllItems(list);
		UnreserveStuckItem(list);
	}

	private void UnreserveStuckItem(List<Item> items)
	{
		foreach (Item item in items)
		{
			if (item.IsReserved && !ReturnIsProjectItem(item))
			{
				Debug.LogErrorFormat($"Item '{item.Properties.LocalizedName}' stored in '{item.Inventory}' is reserved, but is not linked to any project in Community '{Name}' and appears to be stuck. Unreserving the item.");
				item.CancelReservation();
			}
		}
	}

	public void ForceStorageLateUpdate()
	{
		foreach (Storage storage in Storages)
		{
			storage.SendMessage("LateUpdate");
		}
	}

	public void AddBoat(Boat boat)
	{
		if (_boats.AddUnique(boat))
		{
			boat.Buildable.Community = this;
			UpdateBoats();
		}
	}

	public void BoatFinished()
	{
		UpdateBoats();
	}

	public void AddMooringPoint(MooringPoint mooringPoint)
	{
		if (_mooringPoints.AddUnique(mooringPoint))
		{
			UpdateMooringPoints();
		}
	}

	public bool IsThereAMooringPointFree()
	{
		int num = 0;
		for (int i = 0; i < _mooringPoints.Count; i++)
		{
			if (_mooringPoints[i].Buildable.BuildPhase == BuildPhase.Finished)
			{
				num++;
			}
		}
		return num > _boats.Count;
	}

	public void RemoveBoat(Boat boat)
	{
		if (_boats.RemoveSafely(boat))
		{
			UpdateBoats();
		}
	}

	public void RemoveMooringPoint(MooringPoint mooringPoint)
	{
		if (_mooringPoints.RemoveSafely(mooringPoint))
		{
			UpdateMooringPoints();
		}
	}

	private void UpdateBoats()
	{
		if (this.BoatsUpdatedEvent != null)
		{
			this.BoatsUpdatedEvent();
		}
	}

	public void UpdateMooringPoints()
	{
		this.MooringPointsUpdatedEvent?.Invoke();
	}

	public void AddRejuvenator(Rejuvenator rejuvenator)
	{
		if (!Rejuvenators.AddUnique(rejuvenator))
		{
			Debugger.Error("Already tracking this rejuvenator.");
		}
	}

	public void RemoveRejuvenator(Rejuvenator rejuvenator)
	{
		if (!Rejuvenators.RemoveSafely(rejuvenator))
		{
			Debugger.Error("Not tracking this rejuvenator.");
		}
	}

	public List<House> ReturnHouseList()
	{
		return _houses;
	}

	public void AddHouse(House house)
	{
		if (_houses.AddUnique(house) && this.HouseUpdateEvent != null)
		{
			this.HouseUpdateEvent();
		}
	}

	public void RemoveHouse(House house)
	{
		if (!_houses.RemoveSafely(house))
		{
			Debugger.Error("Could not delete a house since it didn't exist", house);
		}
		else if (this.HouseUpdateEvent != null)
		{
			this.HouseUpdateEvent();
		}
	}

	public void AddWalkwaySegment(WalkwaySegment segment)
	{
		WalkwaySegments.AddUnique(segment);
	}

	public void RemoveWalkwaySegment(WalkwaySegment segment)
	{
		WalkwaySegments.RemoveSafely(segment);
	}

	public void AddWalkwayPonton(WalkwayPonton ponton)
	{
		WalkwayPontons.AddUnique(ponton);
	}

	public void RemoveWalkwayPonton(WalkwayPonton ponton)
	{
		WalkwayPontons.RemoveSafely(ponton);
	}

	public void AddDecorationSlots(DecorationSlots decorationSlots)
	{
		DecorationSlots.AddUnique(decorationSlots);
	}

	public void RemoveDecorationSlots(DecorationSlots decorationSlots)
	{
		DecorationSlots.Remove(decorationSlots);
	}

	public void AddProducer(IItemProducer producer)
	{
		if (Producers.AddUnique(producer))
		{
			GameManager.ResourceManager.AddProductionLimits(producer);
		}
		else
		{
			Debug.LogException(new Exception("Already tracking producer '" + producer.Buildable.Name + "'"));
		}
	}

	public void RemoveProducer(IItemProducer producer)
	{
		if (!Producers.RemoveSafely(producer))
		{
			Debug.LogException(new Exception("Not tracking producer '" + producer.Buildable.Name + "'"));
		}
	}

	public void AddBirdhouse(BirdHouse birdhouse)
	{
		if (!BirdHouses.AddUnique(birdhouse))
		{
			Debugger.Error("Already tracking this birdhouse.");
		}
	}

	public void RemoveBirdhouse(BirdHouse birdhouse)
	{
		if (BirdHouses.RemoveSafely(birdhouse))
		{
			UpdateBirdhouses();
		}
		else
		{
			Debugger.Error("Not tracking this birdhouse.");
		}
	}

	public void BirdhouseFinished()
	{
		UpdateBirdhouses();
	}

	private void UpdateBirdhouses()
	{
		this.BirdhousesUpdatedEvent?.Invoke();
	}

	public void AddFoundItem(ItemProperties itemProperties)
	{
		if (FoundItems.Add(itemProperties))
		{
			new FoundItemPropertiesEvent(GameEventType.NewItemDiscovered, itemProperties, this).Dispatch();
		}
	}

	public void AddFoundItems(ItemProperties[] itemProperties)
	{
		for (int i = 0; i < itemProperties.Length; i++)
		{
			FoundItems.Add(itemProperties[i]);
		}
	}

	public void AddItemReserver(IItemReserver itemReserver)
	{
		if (_itemReservers == null)
		{
			_itemReservers = new List<IItemReserver>();
		}
		_itemReservers.Add(itemReserver);
	}

	public void RemoveItemReserver(IItemReserver itemReserver)
	{
		_itemReservers?.Remove(itemReserver);
	}

	public void ShowMarkerHighlights(bool enabled)
	{
		int count = Markers.Count;
		for (int i = 0; i < count; i++)
		{
			Markers[i].ShowMarkerHighlight(enabled);
		}
	}

	public float ReturnWeight()
	{
		float num = 0f;
		foreach (Buildable buildable in Buildables)
		{
			num += buildable.ReturnWeight();
		}
		return num;
	}

	public float ReturnBuildingWeights()
	{
		float num = 0f;
		foreach (Buildable buildable in Buildables)
		{
			num += buildable.ReturnConstructionWeight();
		}
		return num;
	}

	public float ReturnStorageWeights()
	{
		float num = 0f;
		foreach (Buildable buildable in Buildables)
		{
			num += buildable.ReturnStorageWeight();
		}
		return num;
	}

	public string ReturnWeightOverCapacityString()
	{
		BuildableSettings.WeightModes weightMode = GameManager.Settings.BuildableSettings.WeightMode;
		if (weightMode != BuildableSettings.WeightModes.Properties)
		{
			if (weightMode == BuildableSettings.WeightModes.Items)
			{
				LocalizedString weightTotalString = GameManager.Settings.BuildableSettings.WeightTotalString;
				return ReplaceWeightVariables(weightTotalString.GetOrDefault(weightTotalString.mTerm), ReturnStorageWeights(), ReturnBuildingWeights(), Engine.TownTugCapacity);
			}
			Debug.LogException(new NotImplementedException());
		}
		return $"{ReturnWeight()}/{Engine.TownTugCapacity}";
	}

	private string ReplaceWeightVariables(string text, float totalStorageWeight, float totalBuildingWeight, float totalWeightCapacity)
	{
		text = Regex.Replace(text, "%TOTALSTORAGEWEIGHT%", totalStorageWeight.ToString(), RegexOptions.IgnoreCase);
		text = Regex.Replace(text, "%TOTALBUILDINGWEIGHT%", totalBuildingWeight.ToString(), RegexOptions.IgnoreCase);
		text = Regex.Replace(text, "%TOTALWEIGHT%", (totalStorageWeight + totalBuildingWeight).ToString(), RegexOptions.IgnoreCase);
		text = Regex.Replace(text, "%TOTALWEIGHTCAPACITY%", totalWeightCapacity.ToString(), RegexOptions.IgnoreCase);
		return text;
	}

	public static int ReturnCommunityIndex(Community community)
	{
		_ = Communities.Count;
		for (int i = 0; i < Communities.Count; i++)
		{
			if (Communities[i] == community)
			{
				return i;
			}
		}
		return -1;
	}

	public static Community ReturnRandomCommunity()
	{
		return FlotsamGame.Random(ReturnRegularCommunities());
	}

	public static List<Community> ReturnRegularCommunities()
	{
		return Communities.FindAll((Community community) => community._type == Type.Regular);
	}

	public bool IsPlayerCommunity()
	{
		return this == PlayerCommunity;
	}

	public bool TryReturnAgent(out Agent agent, AgentDescriptor agentDescriptor)
	{
		int count = Agents.Count;
		while (0 < count--)
		{
			agent = Agents[count];
			if (agent.Descriptor == agentDescriptor)
			{
				return true;
			}
		}
		agent = null;
		return false;
	}

	public bool HasActor(ActorDescriptor actorDescriptor)
	{
		foreach (Agent agent in Agents)
		{
			if (agent.Descriptor.UniqueID == actorDescriptor.UniqueID)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasActor(ActorProfile actorProfile)
	{
		if (actorProfile == null)
		{
			return false;
		}
		foreach (Agent agent in Agents)
		{
			if (agent.Descriptor.ActorProfile == actorProfile)
			{
				return true;
			}
		}
		return false;
	}

	public int ReturnBuildableCount(BuildableProperties properties, bool onlyFinished = true)
	{
		int num = 0;
		for (int i = 0; i < Buildables.Count; i++)
		{
			if (Buildables[i].Properties == properties && (!onlyFinished || Buildables[i].BuildPhase == BuildPhase.Finished))
			{
				num++;
			}
		}
		return num;
	}

	public bool ReturnHasBuildable(BuildableProperties buildableProperties)
	{
		return Buildables.Exists((Buildable buildable) => buildable.Properties == buildableProperties);
	}

	public List<Boat> ReturnAllBoats(bool returnOnlyFinished = true)
	{
		if (returnOnlyFinished)
		{
			if (_finishedBoats == null)
			{
				_finishedBoats = new List<Boat>(8);
			}
			_finishedBoats.Clear();
			foreach (Boat boat in _boats)
			{
				if (boat.Buildable.BuildPhase == BuildPhase.Finished)
				{
					_finishedBoats.Add(boat);
				}
			}
			return _finishedBoats;
		}
		return _boats;
	}

	public bool ReturnHasBoatWithAssignmentType(AssignmentType assignmentType)
	{
		foreach (Boat item in ReturnAllBoats())
		{
			if ((item.ResourceProvider.AssignmentType & AssignmentType.LandmarkInteraction) != AssignmentType.None)
			{
				return true;
			}
		}
		return false;
	}

	public bool ReturnHasBoatOfType(BoatType type)
	{
		return _boats.Exists((Boat boat) => boat.Type == type);
	}

	public bool HasBoat()
	{
		return _boats.Count > 0;
	}

	public List<MooringPoint> ReturnAllMooringPoints(bool onlyAvailable = false)
	{
		if (onlyAvailable)
		{
			return _mooringPoints.Where((MooringPoint mooringPoint) => mooringPoint.IsAvailableForMooring).ToList();
		}
		return _mooringPoints;
	}

	public int ReturnEnabledMooringPointCount()
	{
		int num = 0;
		foreach (MooringPoint mooringPoint in _mooringPoints)
		{
			if (mooringPoint.IsEnabled())
			{
				num++;
			}
		}
		return num;
	}

	public List<Storage> ReturnAvailableStorages(Item item)
	{
		List<Storage> list = new List<Storage>();
		foreach (Storage storage in Storages)
		{
			if (storage.Buildable.BuildPhase == BuildPhase.Finished && storage.FitsItem(item))
			{
				list.Add(storage);
			}
		}
		return list;
	}

	public bool TryReturnClosestMooringpointWithAvailableBoat(Vector3 position, BoatType boatType, out MooringPointBase closestMooringPoint)
	{
		closestMooringPoint = null;
		if (boatType == BoatType.None)
		{
			return false;
		}
		float num = float.MaxValue;
		foreach (MooringPoint mooringPoint in _mooringPoints)
		{
			if (mooringPoint.ReturnHasAvailableBoat(boatType))
			{
				float num2 = position.DistanceToLeveledSquared(mooringPoint.transform.position);
				if (num2 < num)
				{
					num = num2;
					closestMooringPoint = mooringPoint;
				}
			}
		}
		return closestMooringPoint != null;
	}

	public MooringPoint ReturnClosestAvailableMooringPoint(Vector3 position)
	{
		MooringPoint result = null;
		float num = float.MaxValue;
		foreach (MooringPoint mooringPoint in _mooringPoints)
		{
			if (mooringPoint.IsAvailableForMooring)
			{
				float num2 = position.DistanceToLeveledSquared(mooringPoint.MooringTarget.Position);
				if (num2 < num)
				{
					num = num2;
					result = mooringPoint;
				}
			}
		}
		return result;
	}

	public WalkwayPonton ReturnClosestAvailablePonton(Vector3 position)
	{
		WalkwayPonton result = null;
		float num = float.MaxValue;
		foreach (WalkwayPonton walkwayPonton in WalkwayPontons)
		{
			if (walkwayPonton.Buildable.BuildPhase == BuildPhase.Finished)
			{
				float num2 = position.DistanceToLeveledSquared(walkwayPonton.transform.position);
				if (num2 < num)
				{
					num = num2;
					result = walkwayPonton;
				}
			}
		}
		return result;
	}

	public bool ReturnHasProjectWithProperties(ProjectProperties properties)
	{
		Project project;
		return TryReturnProjectWithProperties(properties, out project);
	}

	public bool TryReturnProjectWithProperties(ProjectProperties properties, out Project project)
	{
		foreach (Project project2 in Projects)
		{
			if (project2.Properties == properties)
			{
				project = project2;
				return true;
			}
		}
		project = null;
		return false;
	}

	public int ReturnMaximumAgentCapacity()
	{
		int num = 0;
		foreach (House house in _houses)
		{
			num += house.Properties.Capacity;
		}
		return num;
	}

	public int ReturnBoatCount(BoatType boatType)
	{
		int num = 0;
		for (int i = 0; i < _boats.Count; i++)
		{
			if (_boats[i].Buildable.BuildPhase == BuildPhase.Finished && _boats[i].Type == boatType)
			{
				num++;
			}
		}
		return num;
	}

	public int ReturnMarkerCount(MarkerCursorProperties properties)
	{
		int num = 0;
		for (int i = 0; i < Markers.Count; i++)
		{
			if (Markers[i].MarkerCursorProperties == properties)
			{
				num++;
			}
		}
		return num;
	}

	public int ReturnHumanAgentCount()
	{
		return Agents.Count;
	}

	public bool ProjectRemainsPriority(Project project, Agent agent, bool assignmentPriorityOnly = false)
	{
		if (_projectManager == null)
		{
			_projectManager = ProjectManager.CreateInstance(this);
		}
		return _projectManager.ProjectRemainsPriority(project, agent, assignmentPriorityOnly);
	}

	public bool TryReturnAgentRunableBlockedProject(Agent agent, out Project project, ProjectBlocker acceptedBlockers = ProjectBlocker.All, bool nonFeedbackProjectsOnly = true)
	{
		if (_projectManager == null)
		{
			project = null;
			return false;
		}
		return _projectManager.TryReturnAssignmentsPrioritizedBlockedProject(agent, out project, acceptedBlockers, nonFeedbackProjectsOnly);
	}

	public bool TryReturnBuildableExtendable<T>(GameObject target, out T buildableExtendable) where T : IBuildableExtendable
	{
		buildableExtendable = default(T);
		foreach (Buildable buildable in Buildables)
		{
			if (buildable == null)
			{
				Debug.LogError($"COMMUNITY::Buildable {target.name} was null in TryReturnBuildableExtendable. Playercommunity? {IsPlayerCommunity()}. Type? {typeof(T).Name}");
			}
			else if (buildable.gameObject == target && buildable.TryReturnBuildableExtendable<T>(out buildableExtendable))
			{
				return true;
			}
		}
		return false;
	}

	public bool TryReturnBuildableExtendable<T>(out T construction) where T : IBuildableExtendable
	{
		foreach (Buildable buildable in Buildables)
		{
			if (buildable.TryReturnBuildableExtendable<T>(out construction))
			{
				return true;
			}
		}
		construction = default(T);
		return false;
	}

	public bool ReturnIsProjectItem(Item item)
	{
		if (item.Project != null || (item.MoveToInventory != null && item.MoveToInventory.TryGetComponent<Decoration>(out var _)))
		{
			return true;
		}
		foreach (Project project in Projects)
		{
			if (project != null && project.ContainsItem(item))
			{
				return true;
			}
		}
		foreach (Agent agent in Agents)
		{
			if (agent.Vitals != null && agent.Vitals.IsProjectItem(item))
			{
				return true;
			}
		}
		if (_itemReservers.IsNullOrEmpty())
		{
			return false;
		}
		foreach (IItemReserver itemReserver in _itemReservers)
		{
			if (itemReserver.HasItemReserved(item))
			{
				return true;
			}
		}
		return false;
	}

	public bool TryReturnCommunityMoraleCategory(out MoraleCategory communityMorale)
	{
		int num = int.MaxValue;
		communityMorale = null;
		foreach (Agent agent in Agents)
		{
			if (agent.Morale.TryReturnCurrentCategory(out var category, out var index) && index < num)
			{
				communityMorale = category;
				num = index;
			}
		}
		return communityMorale != null;
	}

	public bool ReturnAgentWithAssigmentType(AssignmentType assignment, out Agent agentOut)
	{
		agentOut = null;
		foreach (Agent agent in Agents)
		{
			if (agent.GetPriority(assignment) != AssignmentPriority.None)
			{
				agentOut = agent;
				return true;
			}
		}
		return false;
	}
}
