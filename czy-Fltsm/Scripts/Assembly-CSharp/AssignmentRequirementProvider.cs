using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Assignment Requirement Provider", menuName = "Flotsam/Tech Tree/Assignment Requirement Provider")]
public class AssignmentRequirementProvider : TechTreeRequirementProvider
{
	public override TechTreeRequirement CreateRequirementInstance()
	{
		AssignmentRequirement assignmentRequirement = ScriptableObject.CreateInstance<AssignmentRequirement>();
		assignmentRequirement.SetProvider(this);
		return assignmentRequirement;
	}

	public override bool IsProviderFor(TechTreeRequirement techTreeRequirement)
	{
		return techTreeRequirement is AssignmentRequirement;
	}

	public override Sprite GetIcon(TechTreeRequirement techTreeRequirement)
	{
		List<AssignmentSetting> assignmentSettings = GameManager.Settings.ProjectSettings.AssignmentSettings;
		if (techTreeRequirement is AssignmentRequirement assignmentRequirement)
		{
			foreach (AssignmentSetting item in assignmentSettings)
			{
				if (item.Type == assignmentRequirement.Assignment)
				{
					return item.Sprite;
				}
			}
		}
		return null;
	}
}
