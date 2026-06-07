using System;
using I2.Loc;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Assignment Requirement", menuName = "Flotsam/Tech Tree/Assignment Requirement")]
public class AssignmentRequirement : TechTreeRequirement
{
	private enum PointRequirements
	{
		None = 0,
		Expertise = 1,
		ExpertiseAndAttributeEffects = 2
	}

	[SerializeField]
	private AssignmentType _assignment;

	[SerializeField]
	private PointRequirements _pointRequirement;

	[SerializeField]
	[ConditionalEnumHide("_pointRequirement", 0, false, Inverse = true)]
	[FormerlySerializedAs("_level")]
	private int _requiredPoints;

	public AssignmentType Assignment => _assignment;

	public int RequiredPoints => _requiredPoints;

	public override bool IsMet()
	{
		if (_assignment == AssignmentType.None)
		{
			return true;
		}
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if (agent.TryReturnAttribute(_assignment, out var attribute))
			{
				switch (_pointRequirement)
				{
				case PointRequirements.None:
					return true;
				case PointRequirements.Expertise:
					return _requiredPoints <= attribute.Expertise;
				case PointRequirements.ExpertiseAndAttributeEffects:
					return _requiredPoints <= attribute.Expertise + agent.Attributes.ReturnAttributeEffectPoints(attribute.Type);
				}
				Debug.LogException(new NotImplementedException());
			}
		}
		return false;
	}

	public override bool TryGetAmount(out int amount)
	{
		amount = _requiredPoints;
		return true;
	}

	public override string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return GetLocalizedName();
	}

	public LocalizedString GetLocalizedName()
	{
		foreach (AssignmentSetting assignmentSetting in GameManager.Settings.ProjectSettings.AssignmentSettings)
		{
			if (assignmentSetting.Type == _assignment)
			{
				return assignmentSetting.Name;
			}
		}
		return null;
	}
}
