using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ProjectAssignment
{
	private bool _hasStarted;

	private IEnumerator _runCoroutine;

	private IEnumerator _isValidCoroutine;

	private IEnumerator _activeTaskCoroutine;

	private TaskBase _activeTask;

	private readonly List<ItemToHaul> _itemsToHaul = new List<ItemToHaul>();

	public Project Project { get; private set; }

	public Agent Agent { get; private set; }

	public int ActiveTaskIndex { get; private set; }

	public ProjectAssignmentFlags Flags { get; private set; }

	public bool AllowsDeprioritization { get; private set; }

	public bool IsIdleProject { get; private set; }

	public Boat Boat { get; private set; }

	public MooringPointBase ReservedEmbarkMooringPoint { get; private set; }

	public MooringPointBase ReservedDisembarkMooringPoint { get; private set; }

	public IReadOnlyList<ItemToHaul> ItemsToHaul => _itemsToHaul;

	public Item ReservedItem { get; private set; }

	public bool RequiresStorageSpace => Project.Properties.RequiresGeneralStorageSpace;

	public float Water { get; private set; }

	public int Priority { get; private set; }

	public ProjectAssignment(Project project, Agent agent, bool isIdleProject)
		: this(project, agent, 0, isIdleProject)
	{
		IsIdleProject = isIdleProject;
		AllowsDeprioritization |= isIdleProject;
	}

	public ProjectAssignment(Project project, Agent agent, int activeTaskIndex, bool isIdleProject)
	{
		Project = project;
		Agent = agent;
		ActiveTaskIndex = activeTaskIndex;
		AllowsDeprioritization = Project.Properties.AllowDeprioritization || isIdleProject;
		IsIdleProject = isIdleProject;
		_itemsToHaul = ListPool<ItemToHaul>.Get(10);
		if (_itemsToHaul.Count > 0)
		{
			Debug.LogException(new NotSupportedException("List is not empty!"));
			_itemsToHaul.Dispose();
			_itemsToHaul.Clear();
		}
		_hasStarted = false;
	}

	public void Destroy()
	{
		if (_itemsToHaul == null)
		{
			return;
		}
		foreach (ItemToHaul item in _itemsToHaul)
		{
			item.Dispose();
		}
		_itemsToHaul.Dispose();
		_itemsToHaul.Clear();
		if (ReservedItem != null)
		{
			UnreserveItem(ReservedItem);
		}
	}

	public bool Start()
	{
		if (_hasStarted || (Agent.Assignment != null && !Agent.Assignment.AllowsDeprioritization && Agent.Assignment != this))
		{
			return false;
		}
		if (!Project.IsValid())
		{
			Project.Stop(ProjectFlags.InValid);
			return _hasStarted;
		}
		if (Agent.Assignment != null && Agent.Assignment != this && Agent.Assignment.AllowsDeprioritization && !Agent.Assignment.Stop(ProjectFlags.Priority | ProjectFlags.DoNotTryGoToTown))
		{
			Debug.LogException(new Exception($"Agent '{Agent.Name}' is unable to stop idle project '{Agent.Assignment.Project.Properties}'"));
			return false;
		}
		_runCoroutine = RunCoroutine();
		Agent.StartCoroutine(_runCoroutine);
		_isValidCoroutine = IsValidCoroutine();
		Agent.StartCoroutine(_isValidCoroutine);
		if (Agent.Assignment == null)
		{
			Agent.Assignment = this;
		}
		else if (Agent.Assignment != this)
		{
			Debug.LogException(new Exception($"It seems an exception occured while '{Agent.Descriptor.Name}' was starting its assignment for project '{Project.Properties}'"));
		}
		_hasStarted = true;
		return true;
	}

	public void SetFlags(ProjectAssignmentFlags flags)
	{
		Flags = flags;
	}

	public bool Stop(ProjectFlags flags)
	{
		if (Agent.Inventory.ReturnCount() > 0)
		{
			if (flags.IsFlagSet(ProjectFlags.InventoryMustBeEmpty))
			{
				return false;
			}
			if (HasItemsInTransitWithoutReservedStorageSpace())
			{
				Debug.LogException(new Exception($"ProjectAssignment for project '{Project.Properties}' is being stopped, but '{Agent.Name}' has items in its inventory without reserved storage space."));
			}
		}
		if (_activeTask != null)
		{
			_activeTask.Stop();
		}
		Dispose(finished: false);
		Project.OnAssignmentFinished(this);
		Agent.ReturnNavigator().StopNavigation(flags);
		if (flags.IsFlagSet(ProjectFlags.NonInteractable) || flags.IsFlagSet(ProjectFlags.OutOfBounds))
		{
			if ((bool)Agent)
			{
				Agent.ResetToTown();
			}
			if ((bool)Boat)
			{
				Boat.ResetToTown(disembarkAll: true);
			}
		}
		else if (!flags.IsFlagSet(ProjectFlags.DoNotTryGoToTown))
		{
			Agent.TryGoToTown(Project);
		}
		return true;
	}

	public void Finish()
	{
		if (!Agent.Inventory.ReturnIsEmpty())
		{
			Debug.LogErrorFormat("'{0}' finished '{1}' project, but there are still items in it's inventory", Agent.Name, Project.Properties.name);
		}
		Dispose();
		Project.OnAssignmentFinished(this);
	}

	public void UpdatePriority()
	{
		Priority = ((!IsIdleProject) ? Project.ReturnAgentPriority(Agent) : 0);
	}

	private IEnumerator RunCoroutine()
	{
		while (LoadingScreen.IsLoading)
		{
			yield return null;
		}
		List<TaskBase> taskQueue = Project.Properties.TaskQueue.List;
		while (ActiveTaskIndex < taskQueue.Count)
		{
			_activeTask = UnityEngine.Object.Instantiate(taskQueue[ActiveTaskIndex]);
			_activeTask.Initialize(this);
			_activeTaskCoroutine = _activeTask.RunTaskCoroutine(Agent, Project);
			if (_activeTask.DoYieldReturn)
			{
				yield return Agent.StartCoroutine(_activeTaskCoroutine);
			}
			else if (_activeTaskCoroutine.MoveNext())
			{
				Debug.LogException(new NotSupportedException("TaskBase.DoYieldReturn == false for task '" + _activeTask.name + "', but MoveNext() returns true!"));
			}
			ActiveTaskIndex++;
		}
		_activeTask = null;
		_activeTaskCoroutine = null;
		_runCoroutine = null;
		yield return WaitForAssignedToProject();
		Finish();
	}

	private IEnumerator IsValidCoroutine()
	{
		while (LoadingScreen.IsLoading)
		{
			yield return null;
		}
		while (Project.IsValid())
		{
			yield return null;
		}
		Project.Stop(ProjectFlags.InValid);
	}

	private IEnumerator WaitForAssignedToProject()
	{
		while (LoadingScreen.IsLoading)
		{
			yield return null;
		}
		for (int i = 0; i < 60; i++)
		{
			if (Project.Assignments.Contains(this))
			{
				yield break;
			}
			yield return null;
		}
		Debug.LogErrorFormat("'{0}' its assignment to project '{1}' was never added to the projects assignments list, this is a bug!", Agent.Name, Project.Properties.name);
	}

	private void Dispose(bool finished = true)
	{
		if (_itemsToHaul.Count > 0)
		{
			if (finished)
			{
				Debug.LogErrorFormat("'{0}' finished assignment for project '{1}', but there are still items ({2}) left to haul!", Agent.Name, Project.Properties.name, ReturnItemsToHaulString());
			}
			foreach (ItemToHaul item in _itemsToHaul)
			{
				item.Dispose(finished);
			}
			_itemsToHaul.Dispose();
			_itemsToHaul.Clear();
		}
		if (ReservedItem != null)
		{
			Debug.LogError($"'{Agent.Name}' finished assignment for project '{Project.Properties.name}', but there are still reserved items left! ({ReservedItem})");
			UnreserveItem(ReservedItem);
		}
		if (UnreserveEmbarkMooringPoint() && finished)
		{
			Debug.LogErrorFormat("'{0}' finished '{1}' project, but still had an embark mooring point reserved!", Agent.Name, Project.Properties.name);
		}
		if (UnreserveDisembarkMooringPoint() && finished)
		{
			Debug.LogErrorFormat("'{0}' finished '{1}' project, but still had a disembark mooring point reserved!", Agent.Name, Project.Properties.name);
		}
		if (Agent.Assignment == this)
		{
			Agent.Assignment = null;
		}
		else
		{
			Debug.LogException(new NotSupportedException($"Unable to clear project '{Project.Properties}' its assignment to agent '{Agent.Name}'." + $"The agent is currently assigned to project '{Agent.Assignment.Project.Properties}'"));
		}
		if (_runCoroutine != null)
		{
			Agent.StopCoroutine(_runCoroutine);
		}
		if (_isValidCoroutine != null)
		{
			Agent.StopCoroutine(_isValidCoroutine);
		}
		if (_activeTaskCoroutine != null)
		{
			Agent.StopCoroutine(_activeTaskCoroutine);
		}
	}

	public bool RemoveItem(Item item)
	{
		if (item.Project == Project)
		{
			return RemoveItemToHaul(item);
		}
		Debug.LogErrorFormat("Item '{0}' is removed from project assignment with '{1}' for project '{3}'", item.Properties.LocalizedName, Agent.Name, Project.Properties.name);
		return false;
	}

	public void AddWater(Item item)
	{
		if (item.Inventory.TakeItem(item) == item)
		{
			Water += 1000f;
		}
		else
		{
			Debug.LogError("Huh?");
		}
	}

	public void RemoveWater(float amount)
	{
		Water = Mathf.Max(0f, Water - amount);
	}

	public bool AddItemToPickup(Item item)
	{
		ItemToHaul itemToHaul;
		if (Project.Properties.PickupOnly && ReturnCanHaulItem(item))
		{
			return AddItemToHaulUnique(out itemToHaul, item, SubInventoryType.Storage);
		}
		return false;
	}

	public bool AddItemToHaul(Item item, SubInventoryType targetSubInventory = SubInventoryType.Storage)
	{
		if (ReturnCanHaulItem(item) && ((bool)Boat || (bool)item.MoveToInventory || Agent.Community.ReserveIncomingItems(item, targetSubInventory)))
		{
			if (AddItemToHaulUnique(out var _, item, targetSubInventory))
			{
				item.Reserve();
				return true;
			}
			item.UnreserveMoveToInventory();
		}
		return false;
	}

	public bool AddGeneralItemToHaul(Item item, SubInventoryType targetSubInventory = SubInventoryType.Storage)
	{
		ItemToHaul itemToHaul;
		return AddGeneralItemToHaul(out itemToHaul, item, targetSubInventory);
	}

	public bool AddGeneralItemToHaul(out ItemToHaul itemToHaul, Item item, SubInventoryType targetSubInventory = SubInventoryType.Storage)
	{
		if (ReturnCanHaulItem(item))
		{
			if (!Project.GeneralItems.Remove(item))
			{
				throw new NotSupportedException($"Item '{item.Properties.LocalizedName}' was being added as general item to haul for agent '{Agent.Name}' working on project '{Project.Properties.name}', but it is not in the projects general items list!");
			}
			if (AddItemToHaulUnique(out itemToHaul, item, targetSubInventory, isGeneralListItem: true))
			{
				return true;
			}
			Project.GeneralItems.Add(item);
		}
		itemToHaul = null;
		return false;
	}

	public bool RestoreItemToHaul(Item item, SubInventoryType targetSubInventory, bool isGeneralListItem)
	{
		ItemToHaul itemToHaul;
		return TryRestoreItemToHaul(out itemToHaul, item, targetSubInventory, isGeneralListItem);
	}

	public bool TryRestoreItemToHaul(out ItemToHaul itemToHaul, Item item, SubInventoryType targetSubInventory, bool isGeneralListItem)
	{
		if (ReturnIsItemToHaul(item))
		{
			itemToHaul = null;
			return false;
		}
		if (ItemToHaul.TryGet(out itemToHaul, this, item, targetSubInventory, isGeneralListItem))
		{
			ItemToHaul.HaulState state = itemToHaul.State;
			if ((uint)(state - 1) <= 1u)
			{
				_itemsToHaul.Add(itemToHaul);
			}
			return true;
		}
		Debug.LogException(new Exception($"ItemToHaul '{item.Properties}' could not be restored for agent '{Agent.Name}' assigned to project '{Project.Properties}'"));
		return false;
	}

	private bool AddItemToHaulUnique(out ItemToHaul itemToHaul, Item item, SubInventoryType targetSubInventory, bool isGeneralListItem = false)
	{
		if (ReturnIsItemToHaul(item))
		{
			itemToHaul = null;
			return false;
		}
		if (ItemToHaul.TryGet(out itemToHaul, this, item, targetSubInventory, isGeneralListItem))
		{
			ItemToHaul.HaulState state = itemToHaul.State;
			if ((uint)(state - 1) <= 1u)
			{
				_itemsToHaul.Add(itemToHaul);
			}
			return true;
		}
		Debug.LogException(new NotSupportedException("ItemToHaul is in state 'NONE'. this is a bug!"));
		return false;
	}

	public bool RemoveItemToHaul(ItemToHaul itemToHaul)
	{
		if (_itemsToHaul.Remove(itemToHaul))
		{
			itemToHaul.Dispose();
			return true;
		}
		return false;
	}

	public bool RemoveItemToHaul(Item item)
	{
		int count = _itemsToHaul.Count;
		while (0 < count--)
		{
			ItemToHaul itemToHaul = _itemsToHaul[count];
			if (itemToHaul.Item == item)
			{
				if (itemToHaul.State == ItemToHaul.HaulState.Transit)
				{
					Debug.LogError("Item to haul should not be removed when it is in transit!");
				}
				itemToHaul.Dispose();
				_itemsToHaul.RemoveAt(count);
				return true;
			}
		}
		return false;
	}

	public void RemoveItemsToPickup()
	{
		int count = _itemsToHaul.Count;
		while (0 < count--)
		{
			ItemToHaul itemToHaul = _itemsToHaul[count];
			if (ItemToHaul.HaulState.Pickup >= itemToHaul.State)
			{
				itemToHaul.Dispose();
				_itemsToHaul.RemoveAt(count);
			}
		}
	}

	public void ReserveItem(Item item)
	{
		if (ReservedItem != item)
		{
			if (ReservedItem != null)
			{
				Debug.LogError($"Adding a reserved item ({item}) to agent \"{Agent.Name}\" but it still had an associated reserved item ({ReservedItem})");
				ReservedItem.CancelReservation();
			}
			ReservedItem = item;
			item.Reserve();
		}
	}

	public void UnreserveItem(Item item)
	{
		if (ReservedItem == item)
		{
			item.CancelReservation();
			ReservedItem = null;
		}
		else
		{
			Debug.LogError($"Trying to unreserve item \"{item}\" for agent \"{Agent.Name}\" but it was not reserved by this agent (currently reserved item by this agent is \"{ReservedItem}\")");
		}
	}

	public void RestoreReservedItem(Item item)
	{
		if (ReservedItem != null)
		{
			Debug.LogError($"Restoring a reserved item ({item}) to agent \"{Agent.Name}\" but it still had an associated reserved item associated ({ReservedItem})");
			ReservedItem.CancelReservation();
		}
		ReservedItem = item;
	}

	public bool TryReturnItemToHaul(ItemToHaul.HaulState state, out ItemToHaul itemToHaul)
	{
		foreach (ItemToHaul item in _itemsToHaul)
		{
			if (item.State == state)
			{
				itemToHaul = item;
				return true;
			}
		}
		itemToHaul = null;
		return false;
	}

	private bool ReturnCanHaulItem(Item item)
	{
		if (item.Inventory == ReturnTransitInventory())
		{
			return true;
		}
		int num = ReturnRemainingItemToHaulCount();
		int num2 = ReturnItemHaulingCapacity();
		return num < num2;
	}

	private int ReturnRemainingItemToHaulCount()
	{
		int num = 0;
		foreach (ItemToHaul item in _itemsToHaul)
		{
			if (item.State != ItemToHaul.HaulState.Finished)
			{
				num++;
			}
		}
		return num;
	}

	private int ReturnItemHaulingCapacity()
	{
		if (Boat == null)
		{
			return Agent.Inventory.ReturnStorageCapacity();
		}
		return Boat.Buildable.Inventory.ReturnStorageCapacity();
	}

	public Inventory ReturnTransitInventory()
	{
		if (Agent.IsCaptain)
		{
			if (Agent.Boat == Boat)
			{
				return Boat.Buildable.Inventory;
			}
			Debug.LogErrorFormat("'{0}' is a captain, but not of boat '{1}' referenced by the project assignment!", Agent.Name, (Boat == null) ? "null" : Boat.name);
		}
		return Agent.Inventory;
	}

	private bool HasItemsInTransitWithoutReservedStorageSpace()
	{
		foreach (ItemToHaul item in ItemsToHaul)
		{
			if (item.State == ItemToHaul.HaulState.Transit && !item.HasStorageSpaceReserved())
			{
				return true;
			}
		}
		return false;
	}

	public void ReserveBoat(Boat boat)
	{
		if (boat == null)
		{
			Debug.LogErrorFormat("'{0}' could not reserve boat for project '{1}' because it is null!", Agent.Name, Project.Properties.name);
		}
		else if (Boat != null)
		{
			Debug.LogErrorFormat("'{0}' could not reserve a boat '{1}' for project '{2}' because one is already reserved!", Agent.Name, boat.name, Project.Properties.name);
		}
		else if (boat.CurrentMooringPoint == null)
		{
			Debug.LogErrorFormat("'{0}' could not reserve a boat '{1}' for project '{2}' because it is not moored!", Agent.Name, boat.name, Project.Properties.name);
		}
		else if (ReservedEmbarkMooringPoint != null)
		{
			Debug.LogErrorFormat("'{0}' could not reserve a embark mooring point for project '{1}' because one is already reserved!", Agent.Name, Project.Properties.name);
		}
		else if (boat.CurrentMooringPoint.Reserve(Agent, Project))
		{
			Boat = boat;
			ReservedEmbarkMooringPoint = boat.CurrentMooringPoint;
		}
		else
		{
			Debug.LogErrorFormat("'{0}' could not reserve embark mooring point for project '{1}'", Agent.Name, Project.Properties.name);
		}
	}

	public bool ReserveAgentBoat(Agent agent)
	{
		if (agent.IsCaptain && (bool)Agent.Boat)
		{
			if (Boat == null)
			{
				Boat = Agent.Boat;
				return true;
			}
			Debug.LogErrorFormat("Unable to reserve agent '{0}' its boat for project '{1}', because a boat is already reserved", Agent.Name, Project.Properties.name);
		}
		else
		{
			Debug.LogErrorFormat("Unable to 'Reserve' agent '{0}' its boat for project '{1}'! The agent is not a captain.", Agent.Name, Project.Properties.name);
		}
		return false;
	}

	public void RestoreBoat(Boat boat)
	{
		if (boat == null)
		{
			return;
		}
		if ((bool)boat.CurrentMooringPoint)
		{
			if (boat.CurrentMooringPoint.Reserve(Agent, Project))
			{
				ReservedEmbarkMooringPoint = boat.CurrentMooringPoint;
			}
			else
			{
				Debug.LogWarningFormat("'{0}' could not restore embark mooring point reservation for project '{1}'", Agent.Name, Project.Properties.name);
			}
		}
		Boat = boat;
	}

	public bool UnreserveEmbarkMooringPoint()
	{
		bool result = UnreserveMoorinPoint(ReservedEmbarkMooringPoint);
		ReservedEmbarkMooringPoint = null;
		return result;
	}

	public bool ReserveDisembarkMooringPoint(MooringPointBase mooringPoint)
	{
		if (mooringPoint == null)
		{
			Debug.LogErrorFormat("'{0}' could not reserve mooring point for project '{1}' because it is null!", Agent.Name, Project.Properties.name);
			return false;
		}
		if (mooringPoint.MooredBoat != null)
		{
			Debug.LogErrorFormat("'{0}' could not reserve disembark mooring point for project '{1} because a boat is already moored", Agent.Name, Project.Properties.name);
			return false;
		}
		if (ReservedDisembarkMooringPoint != null)
		{
			Debug.LogErrorFormat("'{0}' could not reserve a disembark mooring point for project '{1}' because one is already reserved!", Agent.Name, Project.Properties.name);
			return false;
		}
		if (mooringPoint.Reserve(Agent))
		{
			ReservedDisembarkMooringPoint = mooringPoint;
			return true;
		}
		Debug.LogErrorFormat("'{0}' was unable to reserve a mooring point for project '{0}'", Agent.Name, Project.Properties.name);
		return false;
	}

	public void Disembark()
	{
		if (ReservedDisembarkMooringPoint == null)
		{
			Debug.LogErrorFormat("'{0}' is unable to disembark, because not disembark mooring point was reserved for project '{1}'", Agent.Name, Project.Properties.name);
		}
		else if (Boat == null)
		{
			Debug.LogErrorFormat("'{0}' is unable to disembark, because it is not using a boat for project '{1}'", Agent.Name, Project.Properties.name);
		}
		else if (ReservedDisembarkMooringPoint.MoorBoat(Boat))
		{
			ReservedDisembarkMooringPoint = null;
			Boat.Disembark(Agent);
			Boat = null;
		}
	}

	private bool UnreserveDisembarkMooringPoint()
	{
		bool result = UnreserveMoorinPoint(ReservedDisembarkMooringPoint);
		ReservedDisembarkMooringPoint = null;
		return result;
	}

	private bool UnreserveMoorinPoint(MooringPointBase mooringPoint)
	{
		if (mooringPoint == null)
		{
			return false;
		}
		if (mooringPoint.IsReserved)
		{
			return mooringPoint.Unreserve(Agent);
		}
		return false;
	}

	public bool RemainsPriority(bool assignmentPriorityOnly = false)
	{
		if (ItemsToHaul.Count > 0)
		{
			return true;
		}
		return Agent.Community.ProjectRemainsPriority(Project, Agent, assignmentPriorityOnly);
	}

	public bool KeepsPriorityOver(Project project, bool idle)
	{
		if (AllowsDeprioritization && Project != project && Priority < project.AgentPriorityScore)
		{
			if (idle)
			{
				return IsIdleProject;
			}
			return false;
		}
		return true;
	}

	public Inventory ReturnTargetInventory()
	{
		if (Project.Properties.PickupOnly)
		{
			return ReturnTransitInventory();
		}
		return Project.TargetInventory;
	}

	public bool ReturnIsItemToHaul(Item item)
	{
		foreach (ItemToHaul item2 in _itemsToHaul)
		{
			if (item2.Item == item)
			{
				return true;
			}
		}
		return false;
	}

	private string ReturnItemsToHaulString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < ItemsToHaul.Count; i++)
		{
			if (i > 0)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append("'").Append(ItemsToHaul[i].Item.Properties.LocalizedName).Append("'");
		}
		return stringBuilder.ToString();
	}

	public void OverrideActiveTaskIndex(int activeTaskIndex)
	{
		if (activeTaskIndex < 0 || Project.Properties.TaskQueue.Count <= activeTaskIndex)
		{
			throw new NotSupportedException("Active task index is out of bounds!");
		}
		ActiveTaskIndex = activeTaskIndex;
	}
}
