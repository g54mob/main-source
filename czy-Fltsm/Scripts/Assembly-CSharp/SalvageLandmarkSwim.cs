using System.Collections;
using PajamaLlama.Math;
using UnityEngine;

public class SalvageLandmarkSwim : SalvageTaskBase
{
	public override TaskType Type => TaskType.SalvageLandmarkSwim;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		ItemToHaul itemToHaul;
		while (_assignment.TryReturnItemToHaul(ItemToHaul.HaulState.Pickup, out itemToHaul))
		{
			yield return SalvageItem(itemToHaul);
		}
		yield return MoveToWater(agent, project);
	}

	private IEnumerator MoveToWater(Agent agent, Project project)
	{
		MooringPointBase mooringPoint = project.NavigationTarget.ReturnClosestMooringPoint(agent);
		yield return MoveAgentCoroutine(mooringPoint.EmbarkTarget);
		GridNode node = GameManager.GraphManager.WaterSurfaceGraph.ReturnNode(mooringPoint.MooringTarget.Position.Vector2TopDown());
		agent.ReturnNavigator(alwaysReturnDrifter: true).AttachToNode(node);
	}

	protected override void OnItemSalvaged(ItemToHaul salvagedItem)
	{
		new AgentActionItemPropertiesEvent(GameEventType.AgentActionSalvagedLandmarkItem, _assignment.Agent, salvagedItem.Item.Properties, Attribute).Dispatch();
	}

	protected override void OnGUI()
	{
		Header("Salvage landmark while swimming", 2, Color.white);
		EditorGUI_HelpBox("Landmark swimming");
		EditorGUI_PropertyField("AnimationEventType", "Rig Animation Event Type");
		Attribute = (DrifterAttributes.AttributeType)(object)EditorGUI_EnumField("Attribute", Attribute);
	}
}
