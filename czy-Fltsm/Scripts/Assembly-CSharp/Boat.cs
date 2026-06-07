using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Navigator))]
public class Boat : MonoBehaviour, IBuildableExtendable, IPersistentReference
{
	public BoatType Type;

	[SerializeField]
	private int _storageCapacity = 10;

	[SerializeField]
	[FormerlySerializedAs("InventorySlots")]
	private InventorySlots _inventorySlots;

	[Header("Mooring")]
	public Transform RopeAttachment;

	public Vector3 MooringOffset;

	[Header("Components")]
	[SerializeField]
	private Navigator _navigator;

	[SerializeField]
	private Transform _captainPosition;

	[SerializeField]
	private List<Transform> _crewPositions;

	[Header("Animator")]
	public int BoatAnimationID;

	public UnityAction<Boat> BoatUpdatedEvent;

	private List<Agent> _passengerManifest;

	private List<Agent> _passengers;

	public Agent Captain { get; set; }

	public int PersistentIndex { get; set; } = -1;

	public MooringPointBase CurrentMooringPoint { get; set; }

	public MooringPoint TownMooringPoint { get; set; }

	public bool Active { get; private set; }

	public Project ReclaimProject { get; private set; }

	public int NumberOfRemainingCrewSpots => _passengerManifest.Capacity - _passengerManifest.Count;

	public bool IsWaitingForPassengers => _passengers.Count < _passengerManifest.Count;

	public ResourceProvider ResourceProvider { get; private set; }

	public bool CanBeMoved
	{
		get
		{
			if (CurrentMooringPoint == TownMooringPoint && Buildable.BuildPhase == BuildPhase.Finished && !CurrentMooringPoint.IsReserved)
			{
				return Buildable.Inventory.ReturnCount(SubInventoryType.Storage, includeReserved: true) == 0;
			}
			return false;
		}
	}

	public Agent RestoreReservingAgent { get; set; }

	public Navigator Navigator => _navigator;

	public Buildable Buildable { get; private set; }

	private void Awake()
	{
		_navigator = GetComponent<Navigator>();
		_passengerManifest = new List<Agent>(_crewPositions.Count);
		_passengers = new List<Agent>(_crewPositions.Count);
	}

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		Buildable.Inventory.InventoryUpdatedEvent.AddListener(UpdateHaulingBlocked);
		Buildable.Inventory.GetOrAddSubInventory(SubInventoryType.Storage, _storageCapacity);
		Buildable.Community.Inventory.InventoryUpdatedEvent.AddListener(UpdateMooredStoredItems);
		Buildable.Name = GameManager.Settings.BoatSettings.ReturnRandomName();
		Buildable.Community.AddBoat(this);
		ResourceProvider = ResourceProvider.Get(Buildable, SubInventoryType.Storage, ReturnResourceProviderAssignmentType());
		ResourceProvider.OverrideCapacity(1);
		_inventorySlots.Initialize(Buildable.Inventory, SubInventoryType.Storage, Buildable.OutlineRenderer);
	}

	public void Finish(bool restored = false)
	{
		Buildable.Community.BoatFinished();
	}

	private void OnDestroy()
	{
		ResourceProvider.Unregister();
		RemoveListeners();
		_inventorySlots.Remove();
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(MooringOffset, 0.5f);
	}

	public void Remove()
	{
		if (Captain != null)
		{
			Captain.KillAgent();
		}
		if (TownMooringPoint != null)
		{
			TownMooringPoint.UnlinkBoat(this);
		}
		if (CurrentMooringPoint != null)
		{
			CurrentMooringPoint.UnmoorBoat();
		}
		Buildable.Community.RemoveBoat(this);
		ResourceProvider.Unregister();
		RemoveListeners();
	}

	private void Update()
	{
		Buildable.StaticTransform.localPosition = Vector3.zero.Leveled();
		Buildable.StaticTransform.rotation = Quaternion.Euler(Buildable.StaticTransform.rotation.eulerAngles.SetX(0f).SetZ(0f));
	}

	public void ResetToTown(bool disembarkAll = false)
	{
		if (!(CurrentMooringPoint == TownMooringPoint))
		{
			if (TryGetProjectAssignment(out var projectAssignment))
			{
				Debug.LogException(new Exception($"Boat '{Buildable.Name}' is being reset to town, but it is still assigned to '{projectAssignment.Agent.Name}' working on '{projectAssignment.Project.Properties}' project."));
			}
			if ((bool)CurrentMooringPoint)
			{
				CurrentMooringPoint.UnmoorBoat();
			}
			if ((bool)TownMooringPoint)
			{
				TownMooringPoint.MoorBoat(this);
			}
		}
	}

	public bool BoardCaptain(Agent agent)
	{
		if (Captain == null)
		{
			Captain = agent;
			Captain.IsCaptain = true;
			Captain.OnBoatBoard.Invoke();
			Captain.transform.SetParent(_captainPosition.transform);
			Board(Captain);
			agent.DrifterRig.MeshAnimator.UpdateAnimator();
			return true;
		}
		return false;
	}

	public void BoardPassenger(Agent agent)
	{
		if (_passengerManifest.Contains(agent))
		{
			_passengers.Add(agent);
			agent.transform.SetParent(_crewPositions[_passengers.Count - 1].transform);
			Board(agent);
			agent.UpdateActivity(Activity.BoatPassenger);
		}
	}

	private void Board(Agent agent)
	{
		agent.Boat = this;
		agent.ReturnNavigator().UpdateTerrain(Navigator.TerrainType.Vessel);
		agent.transform.localPosition = Vector3.zero;
		agent.transform.localRotation = Quaternion.identity;
		SendUpdatedEvent();
	}

	public void Disembark(Agent agent, bool disembarkPassengers = false)
	{
		CurrentMooringPoint.EmbarkTarget.AttachNavigator(agent.ReturnNavigator(alwaysReturnDrifter: true));
		if (agent.IsCaptain)
		{
			ClearCaptain();
			if (disembarkPassengers)
			{
				DisembarkPassengers();
			}
		}
		else
		{
			agent.Boat = null;
			_passengerManifest.Remove(agent);
			_passengers.Remove(agent);
			SendUpdatedEvent();
		}
	}

	private void DisembarkPassengers()
	{
		if (!_passengerManifest.IsNullOrEmpty())
		{
			int count = _passengerManifest.Count;
			while (0 < count--)
			{
				Disembark(_passengerManifest[count]);
			}
		}
	}

	public bool ReservePassage(Agent agent)
	{
		if (_passengerManifest.Contains(agent))
		{
			return true;
		}
		if (_passengerManifest.Count < _passengerManifest.Capacity)
		{
			_passengerManifest.Add(agent);
			return true;
		}
		return false;
	}

	public void UnreservePassage(Agent agent)
	{
		_passengerManifest.Remove(agent);
	}

	public void Abandon(Agent agent)
	{
		if ((bool)agent)
		{
			float num = Navigator.Radius + agent.ReturnNavigator().Radius + 1f;
			Vector3 position = base.transform.localPosition + Vector3.left * num;
			agent.ReturnNavigator(alwaysReturnDrifter: true).PlaceAt(position, overrideCheck: false, placeOnObstacle: false);
		}
		Navigator.StopNavigation(ProjectFlags.BoatAbandoned);
		RemoveFromCommunity();
		ClearCaptain();
		DisableDriftWithCurrent(disabled: false);
		SendReclaimBoatNotification();
		if (ReclaimProject != null)
		{
			ReclaimProject.Stop(ProjectFlags.BoatAbandoned);
		}
	}

	public void ClearCaptain()
	{
		if ((bool)Captain)
		{
			Captain.Boat = null;
			Captain.OnBoatLeave.Invoke();
			Captain.IsCaptain = false;
			Captain = null;
			SendUpdatedEvent();
		}
	}

	public void SendUpdatedEvent()
	{
		BoatUpdatedEvent.SafeInvoke(this);
	}

	private void RemoveListeners()
	{
		Buildable.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateHaulingBlocked);
		Buildable.Community?.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateMooredStoredItems);
		if (ReclaimProject != null)
		{
			ReclaimProject.Stop(ProjectFlags.BuildableRemoved);
		}
	}

	public void OnReclaimProjectFinished(Project project, bool success)
	{
		ReclaimProject.FinishedEvent.RemoveListener(OnReclaimProjectFinished);
		ReclaimProject = null;
	}

	public void Reclaim()
	{
		if (CanBeReclaimed())
		{
			ReclaimProject = new Project(GameManager.Settings.ProjectSettings.ReclaimBoatProperties, base.gameObject);
			ReclaimProject.FinishedEvent.AddListener(OnReclaimProjectFinished);
			Community.PlayerCommunity.QueueProject(ReclaimProject);
			SendUpdatedEvent();
		}
	}

	public void SendReclaimBoatNotification()
	{
		GameManager.UIManager.NotificationHandler.AddNotification(GameManager.Settings.UISettings.BoatAbandonedNotification, new DefaultObjectOfInterest(base.gameObject, ObjectType.None));
	}

	public void RemoveFromCommunity()
	{
		Buildable.Community.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateMooredStoredItems);
		Buildable.Community.RemoveBoat(this);
		Buildable.Community.RemoveBuildable(Buildable);
		Community.AbandonedCommunity.AddBuildable(Buildable);
		Community.AbandonedCommunity.AddBoat(this);
	}

	public void AddToCommunity(Community community)
	{
		community.Inventory.InventoryUpdatedEvent.AddListener(UpdateMooredStoredItems);
		Buildable.Community.RemoveBoat(this);
		Buildable.Community.RemoveBuildable(Buildable);
		community.AddBuildable(Buildable);
		community.AddBoat(this);
	}

	public void UpdateMooredStoredItems()
	{
		if (!(CurrentMooringPoint == null))
		{
			Buildable.Inventory.HasItems(SubInventoryType.Storage, includeReserved: true);
			UpdateHaulingBlocked();
		}
	}

	private void UpdateHaulingBlocked()
	{
		_ = CurrentMooringPoint == null;
	}

	public void DisableDriftWithCurrent(bool disabled)
	{
		Buildable.PhysicsController.ShouldApplyCurrent = !disabled;
	}

	public bool NeedsReclaiming()
	{
		if (Buildable.Community != Community.PlayerCommunity)
		{
			return ReclaimProject == null;
		}
		return false;
	}

	public bool CanBeReclaimed()
	{
		if (Captain != null)
		{
			return false;
		}
		if (CurrentMooringPoint != null)
		{
			return false;
		}
		if (ReclaimProject != null)
		{
			return false;
		}
		if (!Community.PlayerCommunity.IsThereAMooringPointFree())
		{
			return false;
		}
		if (!GameManager.WorldManager.IsInteractable(base.transform.position))
		{
			return false;
		}
		return true;
	}

	private AssignmentType ReturnResourceProviderAssignmentType()
	{
		return Type switch
		{
			BoatType.SalvagingBoat => AssignmentType.BuoySalvaging | AssignmentType.LandmarkInteraction, 
			BoatType.FishingBoat => AssignmentType.Fishing, 
			_ => AssignmentType.None, 
		};
	}

	public float ReturnWeight()
	{
		return 0f;
	}

	private bool TryGetProjectAssignment(out ProjectAssignment projectAssignment)
	{
		foreach (Project project in Buildable.Community.Projects)
		{
			for (int i = 0; i < project.Assignments.Count; i++)
			{
				projectAssignment = project.Assignments[i];
				if (projectAssignment.Boat == this)
				{
					return true;
				}
			}
		}
		projectAssignment = null;
		return false;
	}

	public void Activate()
	{
		Active = true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public void Shutdown()
	{
		Deactivate();
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public bool IsEnabled()
	{
		return Buildable.BuildPhase == BuildPhase.Finished;
	}

	public bool CanBeSalvaged()
	{
		if (CurrentMooringPoint != null && CurrentMooringPoint.IsInTown && !CurrentMooringPoint.IsEmpty)
		{
			return Buildable.Inventory.ReturnCount() <= 0;
		}
		return false;
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new BoatPersistentData(this, Buildable.PhysicsController.ShouldApplyCurrent);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
		BoatPersistentData boatPersistentData = persistentData as BoatPersistentData;
		Buildable.PhysicsController.ShouldApplyCurrent = boatPersistentData.DriftWithCurrent;
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
		BoatPersistentData boatPersistentData = persistentData as BoatPersistentData;
		if (boatPersistentData.ReclaimProject != null && boatPersistentData.ReclaimProject.TryReturn(out var instance))
		{
			ReclaimProject = instance;
			ReclaimProject.FinishedEvent.AddListener(OnReclaimProjectFinished);
		}
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
		(persistentData as BoatPersistentData).ReclaimProject = ReclaimProject;
	}

	public void OnDeconstruct()
	{
	}

	public bool CanBeDeconstructed()
	{
		if (CurrentMooringPoint == null)
		{
			return false;
		}
		if (CurrentMooringPoint.IsReserved)
		{
			return false;
		}
		if (Buildable.Inventory.HasItems(SubInventoryType.Storage, includeReserved: true))
		{
			return false;
		}
		return CurrentMooringPoint.IsInTown;
	}

	public void Upgrade(Buildable buildable)
	{
	}

	public void ShowResearchInfo(RectTransform parent)
	{
	}

	public string ReturnDescription(string text)
	{
		return text;
	}

	public List<Agent> GetWorkers(List<Agent> listToPopulate = null)
	{
		if (listToPopulate == null)
		{
			listToPopulate = new List<Agent>(_passengerManifest.Count);
		}
		listToPopulate.AddUniqueRange(_passengerManifest);
		return listToPopulate;
	}
}
