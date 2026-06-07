using System;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.Events;

public class Project : IPersistentReference, IComparable<Project>
{
	[Header("Properties")]
	public ProjectProperties Properties;

	[Tooltip("Target items for this project.")]
	public List<Item> GeneralItems = new List<Item>();

	public float BlockedTime;

	private AssignmentType _assignmentTypeFlags;

	private int _assignmentLimit;

	private bool _isGlobalHaulingProject;

	private ProjectBlocker _blocker;

	private ProjectSettings _projectSettings;

	private int _priority;

	private IBlockingProjectProvider _blockingProjectProvider;

	private Dictionary<ProjectBlocker, PlaceableAlertProperties> _malfunctions = new Dictionary<ProjectBlocker, PlaceableAlertProperties>();

	private bool _intializedReturnAgentBlockersFields;

	private bool _needsInventorySpace;

	[Tooltip("Target game object of the project.")]
	public GameObject Target { get; private set; }

	public ISalvageTarget SalvageTarget { get; set; }

	public List<ProjectAssignment> Assignments { get; private set; }

	public int AssignmentLimit
	{
		get
		{
			return _assignmentLimit;
		}
		set
		{
			if (Properties == null || Properties.AllowAgentLimitOverride)
			{
				_assignmentLimit = value;
			}
		}
	}

	public bool IsCommunityProject => Community.PlayerCommunity.Projects.Contains(this);

	public bool IsBlocked => Blockers != ProjectBlocker.None;

	public ProjectBlocker Blockers { get; private set; }

	public bool Requeue { get; set; }

	public Target NavigationTarget { get; private set; }

	public VitalType Vital { get; set; } = VitalType.None;

	public AssignmentType AssignmentTypes => _assignmentTypeFlags;

	public Buildable TargetBuildable { get; private set; }

	public Inventory TargetInventory { get; private set; }

	public int AgentPriorityScore { get; private set; }

	public bool IsIdleProject => (AssignmentTypes & AssignmentType.Idle) != 0;

	public int PersistentIndex { get; set; } = -1;

	public ProjectFinishedEvent FinishedEvent { get; private set; } = new ProjectFinishedEvent();

	public UnityEvent ProjectAssignmentsUpdated { get; private set; } = new UnityEvent();

	public event UnityAction MalfunctionsUpdated;

	public Project(ProjectProperties properties, GameObject target)
	{
		if (properties == null)
		{
			Debugger.Error("Can't create a new project without giving properties!");
			return;
		}
		Properties = properties;
		Assignments = ListPool<ProjectAssignment>.Get();
		_projectSettings = GameManager.Settings.ProjectSettings;
		_assignmentTypeFlags = properties.AssignmentType | properties.SecondaryAssignmentTypes;
		_assignmentLimit = properties.AgentLimit;
		_isGlobalHaulingProject = properties.ReturnIsGlobalHaulingProject();
		Target = target;
		if (Target == null)
		{
			Debugger.Warning($"Target for {properties.name} project is null.");
		}
		else
		{
			NavigationTarget = Target.GetComponentInChildren<Target>();
			TargetBuildable = Target.GetComponentInChildren<Buildable>();
			TargetInventory = Target.GetComponent<Inventory>();
		}
		if (Properties.Shareable && AssignmentLimit == 1)
		{
			Debugger.Error("A project can not be shareable and have an agent limit of 1!");
		}
		if (!properties.Shareable && AssignmentLimit == -1)
		{
			Debugger.Error("A project can not have an agent limit of -1 and not be shareable!");
		}
	}

	public Project(ProjectProperties properties, GameObject target, List<Item> items)
		: this(properties, target)
	{
		if (items != null)
		{
			GeneralItems.Capacity = items.Count;
			AddItems(items);
		}
	}

	public Project(ProjectProperties properties, GameObject target, ISalvageTarget salvageTarget)
		: this(properties, target)
	{
		SalvageTarget = salvageTarget;
	}

	public void Destroy()
	{
		foreach (ProjectAssignment assignment in Assignments)
		{
			assignment.Destroy();
		}
		Assignments.Clear();
		RemoveAllGeneralItems();
		FinishedEvent.RemoveAllListeners();
		ProjectAssignmentsUpdated.RemoveAllListeners();
	}

	public void SetBlockingProjectProvider(IBlockingProjectProvider blockingProjectProvider)
	{
		_blockingProjectProvider = blockingProjectProvider;
	}

	public void AddAssignmentType(AssignmentType assignmentType)
	{
		_assignmentTypeFlags |= assignmentType;
	}

	public bool AssignAgent(Agent agent, bool isIdleProject = false)
	{
		ProjectAssignment assignment;
		return TryAssignAgent(out assignment, agent, isIdleProject);
	}

	public void SetPriority(int priority)
	{
		_priority = Mathf.Clamp(priority, -49, 49) * GameManager.Settings.ProjectSettings.ProjectPriorityWeight;
	}

	public void SetAgentPriority(Agent agent)
	{
		AgentPriorityScore = ReturnAgentPriority(agent);
	}

	public bool TryAssignAgent(out ProjectAssignment assignment, Agent agent, bool isIdleProject)
	{
		if (ReturnHasAgentAssigned(agent))
		{
			assignment = null;
			return false;
		}
		assignment = new ProjectAssignment(this, agent, isIdleProject);
		if (assignment.Start())
		{
			if (TryReturnDeprioritizedAssignment(out var assignmentToStop))
			{
				assignmentToStop.Stop(ProjectFlags.Priority);
			}
			Assignments.Add(assignment);
			AgentEvent.Dispatch(GameEventType.AgentStartAssignment, agent);
			if (ProjectAssignmentsUpdated != null)
			{
				ProjectAssignmentsUpdated.Invoke();
			}
			Requeue = Properties.RequeueTrigger == ProjectRequeueTrigger.AgentAssigned;
			return true;
		}
		return false;
	}

	public void UnassignAgent(Agent agent)
	{
		if (TryReturnAgentAssignment(agent, out var _))
		{
			throw new NotImplementedException("Cancel assignment");
		}
	}

	internal void OnAssignmentFinished(ProjectAssignment assignment)
	{
		if (Assignments.Remove(assignment))
		{
			AgentEvent.Dispatch(GameEventType.AgentFinishAssignment, assignment.Agent);
		}
		if (ReturnCanFinish())
		{
			Finish(success: true);
		}
		else if (Vital != VitalType.None)
		{
			Debug.LogErrorFormat("'{0}' finished vitals project '{1}' unsuccesfully!", assignment.Agent.Name, Properties.name);
			RemoveAllGeneralItems();
			Finish(success: false);
		}
		if (ProjectAssignmentsUpdated != null)
		{
			ProjectAssignmentsUpdated.Invoke();
		}
	}

	public void Stop(ProjectFlags flags)
	{
		int count = Assignments.Count;
		while (0 < count--)
		{
			Assignments[count].Stop(flags);
		}
		foreach (Item generalItem in GeneralItems)
		{
			generalItem.CancelReservation();
			generalItem.UnreserveMoveToInventory();
			generalItem.Project = null;
		}
		GeneralItems.Clear();
		if (Assignments.Count == 0)
		{
			Finish(success: false);
		}
		else
		{
			Debug.LogException(new Exception($"Unable to stop '{Properties}' project, there are still {Assignments.Count} assignments active!"));
		}
	}

	private void Finish(bool success)
	{
		FinishedEvent.Invoke(this, success);
		FinishedEvent.RemoveAllListeners();
	}

	public void UpdateBlockedTime()
	{
		if (IsCommunityProject)
		{
			Blockers = ReturnProjectBlockers();
			if (Blockers == ProjectBlocker.None)
			{
				BlockedTime = 0f;
			}
			else
			{
				BlockedTime += Time.deltaTime;
			}
		}
	}

	public void AddItem(Item item)
	{
		if (item.Project == null || !item.Project.IsCommunityProject)
		{
			item.Project = this;
			GeneralItems.AddUnique(item);
		}
	}

	public void AddItems(List<Item> items)
	{
		int count = items.Count;
		for (int i = 0; i < count; i++)
		{
			AddItem(items[i]);
		}
	}

	public void RemoveItem(Item item)
	{
		if (item.Project != this)
		{
			return;
		}
		using (List<ProjectAssignment>.Enumerator enumerator = Assignments.GetEnumerator())
		{
			while (enumerator.MoveNext() && !enumerator.Current.RemoveItem(item))
			{
			}
		}
		item.Project = null;
		if (GeneralItems.Remove(item))
		{
			item.CancelReservation();
		}
	}

	public void RemoveAllGeneralItems()
	{
		for (int num = GeneralItems.Count - 1; num >= 0; num--)
		{
			RemoveItem(GeneralItems[num]);
		}
	}

	public int CompareTo(Project other)
	{
		if (other == null)
		{
			return 1;
		}
		if (Properties == null)
		{
			return 1;
		}
		return Properties.CompareTo(other.Properties);
	}

	public bool ReturnCanRun(Agent agent, ProjectBlocker blockersToIgnore = ProjectBlocker.None)
	{
		ProjectBlocker blockers;
		return ReturnCanRun(agent, out blockers, blockersToIgnore);
	}

	public bool ReturnCanRun(Agent agent, out ProjectBlocker blockers, ProjectBlocker blockersToIgnore = ProjectBlocker.None)
	{
		blockers = ReturnProjectBlockers() | ReturnAgentBlockers(agent);
		foreach (TaskBase item in Properties.TaskQueue.List)
		{
			blockers |= item.ReturnBlockers(agent);
			blockers |= item.ReturnBlockers(this);
		}
		return (blockers ^ blockersToIgnore) == ProjectBlocker.None;
	}

	public bool ReturnCanAgentRun(Agent agent, bool idle)
	{
		return ReturnAgentBlockers(agent, idle) == ProjectBlocker.None;
	}

	public bool ReturnHasAssignmentSlotsFree(Agent agent)
	{
		if (AssignmentLimit == -1 || Assignments.Count < AssignmentLimit)
		{
			return true;
		}
		if (Properties._allowPrioritization)
		{
			int num = ReturnAgentPriority(agent);
			foreach (ProjectAssignment assignment in Assignments)
			{
				if (assignment.Priority < num)
				{
					return true;
				}
			}
		}
		return false;
	}

	internal bool ReturnHasAgentAssigned(Agent agent)
	{
		foreach (ProjectAssignment assignment in Assignments)
		{
			if (assignment.Agent == agent)
			{
				return true;
			}
		}
		return false;
	}

	private bool TryReturnDeprioritizedAssignment(out ProjectAssignment assignmentToStop)
	{
		assignmentToStop = null;
		if (Properties.AllowPrioritization && Assignments.Count == Properties.AgentLimit)
		{
			List<ProjectAssignment> assignments = Assignments;
			assignmentToStop = assignments[assignments.Count - 1];
			int index = Assignments.Count - 1;
			while (0 < index--)
			{
				ProjectAssignment projectAssignment = Assignments[index];
				if (projectAssignment.Priority < assignmentToStop.Priority)
				{
					assignmentToStop = projectAssignment;
				}
			}
		}
		return assignmentToStop != null;
	}

	private bool TryReturnAgentAssignment(Agent agent, out ProjectAssignment assignment)
	{
		int count = Assignments.Count;
		for (int i = 0; i < count; i++)
		{
			assignment = Assignments[i];
			if (assignment.Agent == agent)
			{
				return true;
			}
		}
		assignment = null;
		return false;
	}

	public List<Agent> ReturnAssignedAgents(List<Agent> listToPopulate = null)
	{
		if (listToPopulate == null)
		{
			listToPopulate = new List<Agent>();
		}
		foreach (ProjectAssignment assignment in Assignments)
		{
			listToPopulate.AddUnique(assignment.Agent);
		}
		return listToPopulate;
	}

	private bool ReturnCanFinish()
	{
		if (0 < Assignments.Count)
		{
			return false;
		}
		if (!Properties.ReturnCanFinish(this))
		{
			return false;
		}
		foreach (TaskBase item in Properties.TaskQueue.List)
		{
			if (!item.ReturnCanFinish(this))
			{
				return false;
			}
		}
		if (GeneralItems.Count > 0)
		{
			return false;
		}
		if (Properties.Perpetual)
		{
			Requeue = Properties.RequeueTrigger == ProjectRequeueTrigger.CanFinish;
			return false;
		}
		return true;
	}

	public bool IsValid()
	{
		if (!Properties.AllowTargetTypeNull)
		{
			return Target != null;
		}
		return true;
	}

	public bool ReturnMatchesAssignmentType(AssignmentType assignmentType)
	{
		return _assignmentTypeFlags == assignmentType;
	}

	public bool ReturnContainsAssignmentType(AssignmentType assignmentType)
	{
		return (_assignmentTypeFlags & assignmentType) == assignmentType;
	}

	public AssignmentPriority ReturnAssignmentPriority(Agent agent)
	{
		AssignmentType assignmentType = _assignmentTypeFlags;
		AssignmentPriority assignmentPriority = AssignmentPriority.None;
		if (_isGlobalHaulingProject)
		{
			assignmentType |= Community.PlayerCommunity.Inventory.ReturnResourceProvidersAssignmentTypes();
		}
		foreach (Assignment assignment in agent.Assignments)
		{
			if ((assignmentType & assignment.Type) != AssignmentType.None && assignmentPriority < assignment.Priority)
			{
				assignmentPriority = assignment.Priority;
			}
		}
		return assignmentPriority;
	}

	public int ReturnAgentPriority(Agent agent)
	{
		int num = -1073741824;
		int projectPriority = _priority + Properties.Priority;
		foreach (Assignment assignment in agent.Assignments)
		{
			int num2 = assignment.ReturnPriority(this, projectPriority);
			if (num < num2)
			{
				num = num2;
			}
		}
		foreach (TaskBase item in Properties.TaskQueue.List)
		{
			if (item.TryReturnAgentPriority(out var priority, this, agent, _projectSettings.ProjectPrimaryAssignmentWeight) && num < priority)
			{
				num = priority + _priority;
			}
		}
		return num;
	}

	public int ReturnPriority(Agent agent)
	{
		AssignmentType assignmentType = _assignmentTypeFlags;
		int num = 0;
		if (_isGlobalHaulingProject)
		{
			assignmentType |= Community.PlayerCommunity.Inventory.ReturnResourceProvidersAssignmentTypes();
		}
		foreach (Assignment assignment in agent.Assignments)
		{
			if ((assignmentType & assignment.Type) != AssignmentType.None)
			{
				int num2 = assignment.ReturnPriority();
				if (num < num2)
				{
					num = num2;
				}
			}
		}
		return num;
	}

	public int ReturnItemCount(ItemProperties itemProperties)
	{
		int num = 0;
		foreach (Item generalItem in GeneralItems)
		{
			if (generalItem.Properties == itemProperties)
			{
				num++;
			}
		}
		foreach (ProjectAssignment assignment in Assignments)
		{
			foreach (ItemToHaul item in assignment.ItemsToHaul)
			{
				if (item.State != ItemToHaul.HaulState.Finished && item.Item.Properties == itemProperties)
				{
					num++;
				}
			}
		}
		return num;
	}

	public Item.Tags ReturnAllItemTags()
	{
		Item.Tags tags = Item.Tags.Resource;
		foreach (Item generalItem in GeneralItems)
		{
			tags |= generalItem.Properties.Tags;
		}
		foreach (ProjectAssignment assignment in Assignments)
		{
			if (assignment.ItemsToHaul == null)
			{
				continue;
			}
			foreach (ItemToHaul item in assignment.ItemsToHaul)
			{
				tags |= item.Item.Properties.Tags;
			}
		}
		return tags;
	}

	public bool ContainsItem(Item item)
	{
		if (GeneralItems.Contains(item))
		{
			return true;
		}
		foreach (ProjectAssignment assignment in Assignments)
		{
			if (assignment.ReturnIsItemToHaul(item))
			{
				return true;
			}
		}
		return false;
	}

	public ProjectBlocker ReturnProjectBlockers()
	{
		if (_blocker == ProjectBlocker.None)
		{
			_blocker = ReturnBlocker();
			UpdateMalfunctions();
		}
		return _blocker;
	}

	private ProjectBlocker ReturnBlocker()
	{
		if (Assignments.Count >= AssignmentLimit && AssignmentLimit > -1 && !Properties._allowDeprioritization)
		{
			return ProjectBlocker.AgentSlotsFull;
		}
		if (Properties.RequiresGeneralStorageSpace && !Community.PlayerCommunity.Inventory.ReturnFitsAnyItem(GeneralItems))
		{
			return ProjectBlocker.StorageSpace;
		}
		if (SalvageTarget != null)
		{
			ProjectBlocker projectBlocker = SalvageTarget.ReturnProjectBlockers(this);
			if (projectBlocker != ProjectBlocker.None)
			{
				return projectBlocker;
			}
		}
		if (Properties.Shareable && !Properties.CanHaveEmptyGeneralList && GeneralItems.Count <= 0)
		{
			return ProjectBlocker.SharableEmptyItemList;
		}
		foreach (TaskBase item in Properties.TaskQueue.List)
		{
			ProjectBlocker projectBlocker = item.ReturnBlockers(this);
			if (projectBlocker != ProjectBlocker.None)
			{
				return projectBlocker;
			}
		}
		return ProjectBlocker.None;
	}

	public void ClearBlockers()
	{
		_blocker = ProjectBlocker.None;
	}

	public ProjectBlocker ReturnAgentBlockers(Agent agent, bool idle = false)
	{
		ProjectBlocker projectBlocker = ProjectBlocker.None;
		InitializeReturnAgentBlockersFields();
		if (!agent.IsAlive)
		{
			projectBlocker |= ProjectBlocker.AgentIsDead;
		}
		if (agent.Assignment != null && agent.Assignment.KeepsPriorityOver(this, idle))
		{
			projectBlocker |= ProjectBlocker.AgentHasAssignment;
		}
		if (!ReturnHasAssignmentSlotsFree(agent))
		{
			projectBlocker |= ProjectBlocker.AgentSlotsFull;
		}
		foreach (ProjectRequirementBase item in Properties.Requirements.List)
		{
			if (!item.EvaluateCanRun(this, agent))
			{
				projectBlocker |= item.Blocker;
			}
		}
		foreach (TaskBase item2 in Properties.TaskQueue.List)
		{
			projectBlocker |= item2.ReturnBlockers(agent);
		}
		if (_needsInventorySpace && agent.ReturnInventory().ReturnIsFull())
		{
			projectBlocker |= ProjectBlocker.InventorySpace;
		}
		return projectBlocker;
	}

	public Vector3 ReturnStartPosition(Agent agent)
	{
		if (_isGlobalHaulingProject)
		{
			return agent.Community.Inventory.ReturnAvailableResourceProviderItem().Owner.transform.position;
		}
		if ((AssignmentTypes & AssignmentType.Hauling) != AssignmentType.None && GeneralItems.Count > 0)
		{
			return GeneralItems[0].Owner.transform.position;
		}
		return Target.transform.position;
	}

	public bool TryReturnBlockingProject(out Project blockingProject, Agent agent)
	{
		blockingProject = null;
		if (_blockingProjectProvider != null)
		{
			return _blockingProjectProvider.TryReturnBlockingProject(out blockingProject, agent);
		}
		return false;
	}

	public void PopulateMalfunctions(List<PlaceableAlertProperties> malfunctions)
	{
		foreach (PlaceableAlertProperties value in _malfunctions.Values)
		{
			if (!malfunctions.Contains(value))
			{
				malfunctions.Add(value);
			}
		}
	}

	private void UpdateMalfunctions()
	{
		ProjectMalfunction[] malfunctions = GameSettings.Instance.ProjectSettings.Malfunctions;
		if (_blocker == ProjectBlocker.None)
		{
			if (_malfunctions.Count > 0)
			{
				_malfunctions.Clear();
				this.MalfunctionsUpdated?.Invoke();
			}
			return;
		}
		bool flag = false;
		ProjectMalfunction[] array = malfunctions;
		for (int i = 0; i < array.Length; i++)
		{
			ProjectMalfunction projectMalfunction = array[i];
			flag = (((projectMalfunction.Blocker & _blocker) != ProjectBlocker.None) ? _malfunctions.TryAdd(projectMalfunction.Blocker, projectMalfunction.AlertProperties) : _malfunctions.Remove(projectMalfunction.Blocker));
		}
		if (flag)
		{
			this.MalfunctionsUpdated?.Invoke();
		}
	}

	private void InitializeReturnAgentBlockersFields()
	{
		if (!_intializedReturnAgentBlockersFields)
		{
			_needsInventorySpace = Properties.ReturnNeedsInventorySpace();
			_intializedReturnAgentBlockersFields = true;
		}
	}

	public bool RestoreAssignment(ProjectAssignment assignment)
	{
		if (ReturnHasAgentAssigned(assignment.Agent))
		{
			Debug.LogErrorFormat("Unable to restore '{0}' assignment to project '{1}'! The agent is already assigned");
			return false;
		}
		Assignments.Add(assignment);
		return true;
	}
}
