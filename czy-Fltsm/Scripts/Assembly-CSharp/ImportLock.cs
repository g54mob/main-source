using System.Collections;
using UnityEngine;

public class ImportLock : TaskBase
{
	public override TaskType Type => TaskType.ImportLock;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		Producer component = project.Target.GetComponent<Producer>();
		if (!(component == null) && !(component.ProductionProperties == null) && !(component.ProductionProperties.ProductionProject == null) && !component.IsProducingItems && !component.IsBlockedByImport)
		{
			AssignmentPriority assignmentPriority = component.ProductionProperties.ProductionProject.ReturnAssignmentPriority(agent);
			int num = component.Buildable.Inventory.ReturnCount(SubInventoryType.Import);
			component.IsBlockedByImport = AssignmentPriority.None < assignmentPriority && num == 0;
		}
		yield break;
	}

	protected override void OnGUI()
	{
		Header("Import lock", 0, Color.red);
		EditorGUI_HelpBox("Sets the 'IsBlockedByImport' flag on a producer when: The producer is not producing; The agent can start producing in the target; The import or fuel (when required) inventory is empty.");
	}
}
