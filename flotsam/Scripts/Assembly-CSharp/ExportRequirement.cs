using UnityEngine;

public class ExportRequirement : ProjectRequirementBase
{
	public override ProjectBlocker Blocker => ProjectBlocker.ExportRequirement;

	public override bool EvaluateCanRun(Project project, Agent agent)
	{
		Producer component = project.Target.GetComponent<Producer>();
		if ((bool)component)
		{
			int num = component.Buildable.Inventory.ReturnCount(SubInventoryType.Export);
			if (num == 0)
			{
				return false;
			}
			if (component.IsProducingItems)
			{
				return agent.Inventory.StorageCapacity <= num;
			}
			return true;
		}
		return false;
	}

	protected override void OnGUI()
	{
		Header("Export Requirement", 0, Color.red);
		EditorGUI_HelpBox("Checks if the export inventory has enough resources to fill the agents inventory.");
	}
}
