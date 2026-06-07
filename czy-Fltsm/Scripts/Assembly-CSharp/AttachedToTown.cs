using System;
using UnityEngine;

public class AttachedToTown : ProjectRequirementBase
{
	public override ProjectBlocker Blocker => ProjectBlocker.ConstructionNotAttachedToTown;

	public override bool EvaluateCanRun(Project project, Agent agent)
	{
		if (project.Target != null)
		{
			Construction component = project.Target.GetComponent<Construction>();
			if (component == null || component.CanStartBuilding())
			{
				return true;
			}
		}
		else
		{
			Debug.LogException(new Exception($"Project.Target is null for '{project.Properties}'"));
		}
		return false;
	}

	protected override void OnGUI()
	{
		Header("Attached To Town Requirement", 0, Color.green);
		EditorGUI_HelpBox("Checks if the target construction is attached to the town.");
	}
}
