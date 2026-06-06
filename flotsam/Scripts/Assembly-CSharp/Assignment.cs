using System;

[Serializable]
public class Assignment : IComparable<Assignment>
{
	public AssignmentType Type;

	public bool Enabled = true;

	[NonSerialized]
	private AssignmentSetting _settings;

	[NonSerialized]
	private Agent _agent;

	[NonSerialized]
	private int _priorityWeight;

	[NonSerialized]
	private int _orderWeightPrimary;

	[NonSerialized]
	private int _orderWeightSecondary;

	[NonSerialized]
	private int _orderWeight;

	[NonSerialized]
	private int _additionalPriorityWeight;

	[NonSerialized]
	private int _resourceProviderWeight;

	public AssignmentPriority Priority { get; private set; }

	public AssignmentSetting Settings => _settings;

	public int PriorityWeight => _priorityWeight;

	public int OrderWeight => _orderWeight;

	public int OrderWeightSeconday => _orderWeightSecondary;

	public int ResourceProviderWeight => _resourceProviderWeight;

	public Assignment(AssignmentSetting settings, AssignmentPriority priority, int orderWeight, Agent agent, bool enabled = true)
	{
		Type = settings.Type;
		Enabled = enabled;
		_settings = settings;
		_orderWeight = orderWeight;
		_agent = agent;
		_additionalPriorityWeight = ((!settings.AssingmentPriorityOnly) ? 1 : 0);
		SetPriority(enabled ? priority : AssignmentPriority.None);
	}

	public void SetEnabled(bool enabled)
	{
		Enabled = enabled;
	}

	public bool UpdatePriority(AssignmentPriority assignmentPriority)
	{
		if (assignmentPriority == Priority)
		{
			return false;
		}
		SetPriority(assignmentPriority);
		AgentEvent.Dispatch(_agent, this);
		return true;
	}

	public int CompareTo(Assignment other)
	{
		if (other == null)
		{
			return -1;
		}
		return other.ReturnPriority() - ReturnPriority();
	}

	private void SetPriority(AssignmentPriority assignmentPriority)
	{
		Priority = assignmentPriority;
		if (!Enabled || Priority == AssignmentPriority.None)
		{
			_priorityWeight = int.MinValue;
			_additionalPriorityWeight = 0;
			_resourceProviderWeight = 0;
			return;
		}
		ProjectSettings projectSettings = GameSettings.Instance.ProjectSettings;
		_priorityWeight = (int)assignmentPriority * projectSettings.AssingmentPriortyWeight;
		_orderWeightPrimary = _orderWeight * GameSettings.Instance.ProjectSettings.ProjectPrimaryAssignmentWeight;
		_orderWeightSecondary = _orderWeight * GameSettings.Instance.ProjectSettings.ProjectSecondaryAssignmentWeight;
		_additionalPriorityWeight = ((!Settings.AssingmentPriorityOnly) ? 1 : 0);
		_resourceProviderWeight = _priorityWeight + _orderWeightPrimary;
	}

	public int ReturnPriority(Project project, int projectPriority)
	{
		int num = 0;
		if (project.Properties.AssignmentType == Type)
		{
			num = _orderWeightPrimary;
		}
		else
		{
			if (!project.ReturnContainsAssignmentType(Type))
			{
				return int.MinValue;
			}
			num = _orderWeightSecondary;
		}
		return PriorityWeight + _additionalPriorityWeight * (num + projectPriority);
	}

	public int ReturnPriority()
	{
		DrifterAttributes attributes = _agent.Attributes;
		if (Priority == AssignmentPriority.None)
		{
			return 0;
		}
		return (int)Priority * 1000 + attributes.ReturnAssignmentAffinityAmount(this) * 100 + attributes.ReturnAssignmentAttributePoints(this);
	}

	public bool TryReturnSettings(out AssignmentSetting assignmentSettings)
	{
		assignmentSettings = null;
		if (GameManager.Settings == null || GameManager.Settings.ProjectSettings == null || GameManager.Settings.ProjectSettings.AssignmentSettings.IsNullOrEmpty())
		{
			return false;
		}
		for (int i = 0; i < GameManager.Settings.ProjectSettings.AssignmentSettings.Count; i++)
		{
			assignmentSettings = GameManager.Settings.ProjectSettings.AssignmentSettings[i];
			if (assignmentSettings.Type == Type)
			{
				return true;
			}
		}
		return false;
	}
}
