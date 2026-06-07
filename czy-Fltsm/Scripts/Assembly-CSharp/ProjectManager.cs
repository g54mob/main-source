using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class ProjectManager : SceneBehaviour
{
	private static GameObject parent;

	private Community _community;

	private List<Project> _projects;

	private List<Project> _idleProjects;

	private List<Agent> _assignableAgents;

	private List<Agent> _unassignableAgents;

	private Dictionary<Project, Agent> _assignments;

	protected override void Awake()
	{
		base.Awake();
		_projects = new List<Project>();
		_idleProjects = new List<Project>();
		_assignableAgents = new List<Agent>();
		_unassignableAgents = new List<Agent>();
		_assignments = new Dictionary<Project, Agent>();
	}

	private void Update()
	{
		List<Project> projects = _community.Projects;
		List<Project> list = ListPool<Project>.Get();
		for (int i = 0; i < projects.Count; i++)
		{
			Project project = projects[i];
			project.UpdateBlockedTime();
			if (project.Requeue)
			{
				projects.RemoveAt(i--);
				list.Add(project);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			Project project = list[j];
			projects.Add(project);
			project.Requeue = false;
		}
		ListPool<Project>.Add(list);
	}

	private void LateUpdate()
	{
		_ = _assignableAgents.Count;
		PopulateProjects();
		foreach (Agent agent in _community.Agents)
		{
			agent.Assignment?.UpdatePriority();
		}
		if (_assignableAgents.Count > 0)
		{
			_assignments.Clear();
			TryAssignAgentToProject(_assignableAgents, _unassignableAgents);
		}
		foreach (Agent unassignableAgent in _unassignableAgents)
		{
			TryAssignAgentToIdleProject(unassignableAgent);
		}
		_assignableAgents.Clear();
		_unassignableAgents.Clear();
	}

	public void Dispose()
	{
		UnityEngine.Object.Destroy(this);
		if (parent.GetComponent<ProjectManager>() == null)
		{
			UnityEngine.Object.Destroy(parent);
			parent = null;
		}
	}

	public static ProjectManager CreateInstance(Community community)
	{
		if (parent == null)
		{
			parent = new GameObject();
			parent.name = "Project Managers";
			UnityEngine.Object.DontDestroyOnLoad(parent);
		}
		ProjectManager projectManager = parent.AddComponent<ProjectManager>();
		projectManager._community = community;
		return projectManager;
	}

	public void AssignProject(Agent agent)
	{
		_assignableAgents.AddUnique(agent);
	}

	public void CancelAssignProject(Agent agent)
	{
		_assignableAgents.Remove(agent);
	}

	private void TryAssignAgentToProject(List<Agent> assignableAgents, List<Agent> unassignableAgents)
	{
		for (int i = 0; i < assignableAgents.Count; i++)
		{
			Agent agent = assignableAgents[i];
			if (agent.IsAlive && TryReturnAssignmentsPrioritizedProject(_projects, agent, out var project))
			{
				if (_assignments.TryGetValue(project, out var value))
				{
					AssignmentPriority assignmentPriority = project.ReturnAssignmentPriority(value);
					AssignmentPriority assignmentPriority2 = project.ReturnAssignmentPriority(agent);
					if (assignmentPriority < assignmentPriority2)
					{
						_assignments[project] = agent;
					}
					else if (assignmentPriority == assignmentPriority2)
					{
						float num = agent.transform.position.DistanceToLeveledSquared(project.ReturnStartPosition(agent));
						float num2 = value.transform.position.DistanceToLeveledSquared(project.ReturnStartPosition(value));
						if (num < num2)
						{
							_assignments[project] = agent;
						}
					}
				}
				else
				{
					_assignments.Add(project, agent);
				}
			}
			else
			{
				assignableAgents.RemoveAt(i--);
				unassignableAgents.Add(agent);
			}
		}
		foreach (KeyValuePair<Project, Agent> assignment in _assignments)
		{
			Project project = assignment.Key;
			Agent agent = assignment.Value;
			if (project.AssignAgent(agent))
			{
				_assignableAgents.Remove(agent);
				continue;
			}
			_assignableAgents.Clear();
			Debug.LogException(new NotSupportedException("A project that is available to be run by an agent was unable to assign said agent."));
		}
	}

	private void TryAssignAgentToIdleProject(Agent agent)
	{
		if (agent.Assignment != null || _idleProjects.Count == 0)
		{
			return;
		}
		for (int i = 0; i < _idleProjects.Count; i++)
		{
			Project project = _idleProjects[i];
			if (project.ReturnAgentPriority(agent) > 0 && project.ReturnHasAssignmentSlotsFree(agent))
			{
				ProjectBlocker projectBlocker = project.ReturnProjectBlockers();
				if (project.ReturnCanAgentRun(agent, idle: true) && (projectBlocker == ProjectBlocker.None || projectBlocker == ProjectBlocker.Idle))
				{
					project.AssignAgent(agent, isIdleProject: true);
				}
				else
				{
					_idleProjects.RemoveAt(i--);
				}
			}
		}
	}

	private bool TryReturnAssignmentsPrioritizedProject(List<Project> projects, Agent agent, out Project project, ProjectBlocker blockersToIgnore = ProjectBlocker.None)
	{
		foreach (Project project2 in projects)
		{
			project2.SetAgentPriority(agent);
		}
		Sorting.SlowSort(projects, SortProjectsByAgentPriority);
		for (int i = 0; i < projects.Count; i++)
		{
			project = projects[i];
			if (project.AgentPriorityScore < 0)
			{
				continue;
			}
			ProjectBlocker projectBlocker = project.ReturnProjectBlockers();
			if (projectBlocker == ProjectBlocker.None || (projectBlocker ^ blockersToIgnore) == ProjectBlocker.None)
			{
				projectBlocker |= project.ReturnAgentBlockers(agent);
				if ((projectBlocker ^ blockersToIgnore) == ProjectBlocker.None)
				{
					return true;
				}
			}
			else
			{
				projects.RemoveAt(i--);
			}
			if (TryReturnBlockingProject(out project, project, projects, agent, blockersToIgnore))
			{
				return true;
			}
		}
		project = null;
		return false;
	}

	private bool TryReturnBlockingProject(out Project blockingProject, Project project, List<Project> projects, Agent agent, ProjectBlocker blockersToIgnore = ProjectBlocker.None)
	{
		if (project != null && project.TryReturnBlockingProject(out blockingProject, agent))
		{
			ProjectBlocker projectBlocker = blockingProject.ReturnProjectBlockers();
			if (projectBlocker == ProjectBlocker.None)
			{
				projectBlocker |= blockingProject.ReturnAgentBlockers(agent);
				if ((projectBlocker ^ blockersToIgnore) == ProjectBlocker.None)
				{
					return true;
				}
				if (TryReturnBlockingProject(out blockingProject, blockingProject, projects, agent, blockersToIgnore))
				{
					return true;
				}
			}
			else
			{
				projects.Remove(blockingProject);
			}
			if (TryReturnBlockingProject(out blockingProject, blockingProject, projects, agent, blockersToIgnore))
			{
				return true;
			}
		}
		blockingProject = null;
		return false;
	}

	private int SortProjectsByAgentPriority(Project lhs, Project rhs)
	{
		return rhs.AgentPriorityScore - lhs.AgentPriorityScore;
	}

	public bool TryReturnAssignmentsPrioritizedBlockedProject(Agent agent, out Project blockedProject, ProjectBlocker acceptedBlockers = ProjectBlocker.All, bool nonFeedbackdProjectsOnly = true)
	{
		List<Project> list = ListPool<Project>.Get(_community.Projects);
		List<Assignment> list2 = ListPool<Assignment>.Get(agent.Assignments);
		Sorting.SlowSort(list2);
		foreach (Assignment item in list2)
		{
			if (item.Priority == AssignmentPriority.None)
			{
				break;
			}
			foreach (Project item2 in list)
			{
				if (item2.ReturnContainsAssignmentType(item.Type) && (item2.Blockers & acceptedBlockers) != ProjectBlocker.None && item2.ReturnCanAgentRun(agent, idle: false))
				{
					ListPool<Project>.Add(list);
					ListPool<Assignment>.Add(list2);
					blockedProject = item2;
					return true;
				}
			}
		}
		ListPool<Project>.Add(list);
		ListPool<Assignment>.Add(list2);
		blockedProject = null;
		return false;
	}

	public bool ProjectRemainsPriority(Project project, Agent agent, bool assignmentPriorityOnly)
	{
		project.SetAgentPriority(agent);
		if (project.AgentPriorityScore < 0)
		{
			return false;
		}
		PopulateProjects();
		if (TryReturnAssignmentsPrioritizedProject(_projects, agent, out var project2, ProjectBlocker.AgentHasAssignment))
		{
			if (!assignmentPriorityOnly || project2.ReturnAssignmentPriority(agent) > project.ReturnAssignmentPriority(agent))
			{
				return project.AgentPriorityScore >= project2.AgentPriorityScore;
			}
			return true;
		}
		return true;
	}

	private bool HasAssignmentOrderPriorty(Agent agent, Project project, Project otherProject)
	{
		foreach (Assignment item in agent.ReturnAssignmentsByPriority())
		{
			if ((project.AssignmentTypes & item.Type) != AssignmentType.None)
			{
				return true;
			}
			if ((otherProject.AssignmentTypes & item.Type) != AssignmentType.None)
			{
				break;
			}
		}
		return false;
	}

	private void PopulateProjects()
	{
		_projects.Clear();
		_projects.AddRange(_community.Projects);
		_idleProjects.Clear();
		foreach (Project project in _projects)
		{
			project.ClearBlockers();
			if (project.IsIdleProject)
			{
				_idleProjects.Add(project);
			}
		}
	}
}
