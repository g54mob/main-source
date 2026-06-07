using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Flotsam/Project")]
public class ProjectProperties : PersistentProperties, IComparable<ProjectProperties>
{
	[Header("Properties")]
	[Tooltip("Assignment type of this project.")]
	[EnumFlag(1)]
	[FormerlySerializedAs("_assignmentType")]
	public AssignmentType AssignmentType;

	[SerializeField]
	private AssignmentType _secondaryAssignmentTypes;

	[SerializeField]
	[Range(0f, 99f)]
	[Tooltip("The priority of this specific project, currently has the smallest effect on the projects assignment priority. Use this to prioritize project within an assignment type.E.g. assign a hight priority to the 'recycle' project than the 'import ")]
	private int _priority;

	[SerializeField]
	private bool _isGlobal;

	[Space]
	[Tooltip("Boolean that determines if the project will be canceled if the player moves to a different tile. This should always be turned on for projects that interact with the world.")]
	public bool StopOnMove;

	[Tooltip("Does this project only pickup items? When enabled the target inventory for items will be projects transit inventory (most likely the inventory of the assigned agent).")]
	public bool PickupOnly;

	[Tooltip("This bool determines if the general list of the project can be empty.")]
	public bool CanHaveEmptyGeneralList;

	[Tooltip("Boolean that determines if the project requires community storage space.")]
	[FormerlySerializedAs("RequiresStorageSpace")]
	public bool RequiresGeneralStorageSpace;

	[Tooltip("Is this task shareable between multiple agents and can it be combined into a combined project? AgentLimit cannot be 1 if this is active.")]
	public bool Shareable;

	[ConditionalHide("Shareable", true)]
	[Tooltip("Maximum amount of agents that can work on this project. If set to -1, an unlimited amount of agents can be assigned to this project.")]
	public int AgentLimit = 1;

	[Tooltip("Does this project allow the agent limit to be overridden at runtime?")]
	public bool AllowAgentLimitOverride;

	[Tooltip("Can a drifter with a higher priority stop an assignment of a drifter with a lower priority")]
	public bool _allowPrioritization;

	[Tooltip("Can a project assignment be stopped in favor a project with a higher priority")]
	public bool _allowDeprioritization;

	[Tooltip("The Priority for this project (Currently only used for vitals projects)")]
	[FormerlySerializedAs("Priority")]
	public VitalProjectPriority VitalPriority = VitalProjectPriority.Normal;

	[Space]
	[Tooltip("Icon to show for this project.")]
	public Sprite Icon;

	[Header("Perpetual Projects")]
	[Tooltip("Is this project perpetual. This means that the project can never be completed and will continue to run. Should only be used for hauling projects.")]
	public bool Perpetual;

	[Tooltip("When should this project be moved to the end of the project queue?")]
	public ProjectRequeueTrigger RequeueTrigger;

	[Header("Description")]
	[Tooltip("Text used to describe agents current project in the game UI.")]
	public LocalizedString DescriptiveText = null;

	[Space]
	[PolymorphicList("List", typeof(ProjectRequirementBase), "requirement")]
	public ProjectRequirementList Requirements = new ProjectRequirementList();

	[Space]
	[PolymorphicList("List", typeof(TaskBase), "task")]
	public TaskList TaskQueue = new TaskList();

	[Header("Persistence")]
	[Tooltip("Does the project allow the target for the project to be null?")]
	public bool AllowTargetTypeNull = true;

	public override Types Type => Types.ProjectProperties;

	public AssignmentType SecondaryAssignmentTypes => _secondaryAssignmentTypes;

	public int Priority => _priority;

	public bool IsGlobal => _isGlobal;

	public bool AllowPrioritization
	{
		get
		{
			if (_allowPrioritization)
			{
				return AgentLimit > 0;
			}
			return false;
		}
	}

	public bool AllowDeprioritization => _allowDeprioritization;

	private void OnEnable()
	{
		base.hideFlags = HideFlags.None;
	}

	public AssignmentPriority ReturnAssignmentPriority(Agent agent)
	{
		AssignmentPriority assignmentPriority = AssignmentPriority.None;
		foreach (Assignment assignment in agent.Assignments)
		{
			if ((AssignmentType & assignment.Type) != AssignmentType.None && assignmentPriority < assignment.Priority)
			{
				assignmentPriority = assignment.Priority;
			}
		}
		return assignmentPriority;
	}

	public bool ReturnNeedsInventorySpace()
	{
		return ReturnHasTaskOfType(TaskQueue.List, TaskType.ReserveFillInventory);
	}

	public bool ReturnIsGlobalHaulingProject()
	{
		return this == GameManager.Settings.ProjectSettings.GlobalHaulingProperties;
	}

	private bool ReturnHasTaskOfType(List<TaskBase> tasks, TaskType type)
	{
		int count = tasks.Count;
		for (int i = 0; i < count; i++)
		{
			if (tasks[i].Type == type)
			{
				return true;
			}
		}
		return false;
	}

	public bool ReturnCanRun(Project project, Agent agent)
	{
		if (Requirements == null)
		{
			return true;
		}
		return Requirements.ReturnCanRun(project, agent);
	}

	public bool ReturnCanFinish(Project project)
	{
		if (Requirements == null)
		{
			return true;
		}
		return Requirements.ReturnCanFinish(project);
	}

	public int CompareTo(ProjectProperties other)
	{
		if (other == null)
		{
			return 1;
		}
		return other.VitalPriority - VitalPriority;
	}
}
