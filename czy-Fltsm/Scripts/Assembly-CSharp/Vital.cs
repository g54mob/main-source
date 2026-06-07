using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Vital
{
	public enum Type
	{
		Hunger = 1,
		Thirst = 2,
		Rest = 3,
		Learning = 4,
		Disease = 5,
		Pollution = 6,
		None = 1024
	}

	public Vitals Vitals { get; private set; }

	public Agent Agent { get; private set; }

	public VitalProperties Properties { get; private set; }

	public abstract VitalType VitalType { get; }

	public Project Project { get; protected set; }

	public UnityEvent Updated { get; } = new UnityEvent();

	protected Vital(Vitals vitals)
	{
		Vitals = vitals;
		Agent = vitals.Agent;
		Properties = vitals.Properties;
	}

	public virtual void Start()
	{
	}

	public virtual void LateUpdate()
	{
	}

	public virtual void OnDestroy()
	{
	}

	public abstract void Reset();

	public abstract void ConsumeItem(Item item);

	public virtual bool RetryInstantiateProject()
	{
		return false;
	}

	public bool StartProject()
	{
		if (Project == null || Project.Target == null || Project.ReturnHasAgentAssigned(Agent) || !Project.ReturnCanRun(Agent))
		{
			if (Project != null && !Project.ReturnHasAgentAssigned(Agent) && Project.Target == null)
			{
				Debug.LogException(new Exception($"Vital project '{Project.Properties}' for agent '{Agent.Name}' its target == NULL. The project is getting destroyed."));
				Project.Destroy();
				OnProjectFinished(Project, succes: false);
			}
			return false;
		}
		return Project.AssignAgent(Agent);
	}

	protected bool InstantiateProject(ProjectProperties properties, GameObject target, List<Item> items = null)
	{
		if (Project == null)
		{
			Project = new Project(properties, target, items);
			Project.Vital = VitalType;
			Project.FinishedEvent.AddListener(OnProjectFinished);
			AgentEvent.Dispatch(GameEventType.AgentVitalProjectsUpdated, Agent);
			return true;
		}
		Debug.LogException(new NotSupportedException($"Vital '{VitalType}' is trying to instantiate project '{properties}', but it already has a '{Project.Properties}' project instance!"));
		return false;
	}

	public abstract void OnDayStarted();

	public virtual void OnKillAgent()
	{
		if (Project != null)
		{
			Project.FinishedEvent.RemoveListener(OnProjectFinished);
			Project.Stop(ProjectFlags.Cancelled);
			Project = null;
		}
	}

	private void OnProjectFinished(Project project, bool succes)
	{
		project.FinishedEvent.RemoveListener(OnProjectFinished);
		if (Project == project)
		{
			Project = null;
		}
		else
		{
			Debug.LogException(new NotImplementedException("Project mismatch!"));
		}
	}

	public bool HasProject()
	{
		return Project != null;
	}

	public void RestoreProjectReference(Project project)
	{
		Project = project;
		if (Project != null)
		{
			Project.FinishedEvent.AddListener(OnProjectFinished);
		}
	}
}
