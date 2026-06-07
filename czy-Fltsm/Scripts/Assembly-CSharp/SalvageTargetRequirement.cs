using UnityEngine;

public class SalvageTargetRequirement : ProjectRequirementBase
{
	public override ProjectBlocker Blocker => ProjectBlocker.SharableEmptyItemList;

	public override bool EvaluateCanRun(Project project, Agent agent)
	{
		if (project.SalvageTarget == null)
		{
			return false;
		}
		return project.SalvageTarget.ReturnHasSalvageableItems(project, agent);
	}

	public override bool EvaluateCanFinish(Project project)
	{
		if (project.SalvageTarget == null)
		{
			return true;
		}
		return project.SalvageTarget.ReturnIsSalvaged();
	}

	protected override void OnGUI()
	{
		Header("Salvage Target Requirement", 0, Color.green);
		EditorGUI_HelpBox("Checks if there are items available for salvage from the projects salvage target.");
	}
}
