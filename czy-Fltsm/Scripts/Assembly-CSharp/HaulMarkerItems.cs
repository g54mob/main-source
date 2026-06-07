using System.Collections;

public class HaulMarkerItems : SalvageTaskBase
{
	public override TaskType Type => TaskType.SalvageMarker;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		new AgentActionEvent(GameEventType.AgentActionStartedWorking, agent, Attribute).Dispatch();
		ItemToHaul itemToSalvage;
		while (_assignment.TryReturnItemToHaul(ItemToHaul.HaulState.Pickup, out itemToSalvage))
		{
			yield return SalvageItem(itemToSalvage);
			agent.Vitals.Pollution.Increase(itemToSalvage.Item.Properties.SalvagePollution);
		}
		new AgentActionEvent(GameEventType.AgentActionStoppedWorking, agent, Attribute).Dispatch();
	}

	protected override void OnGUI()
	{
		Header("Haul Marker Items", 2, ReturnTypeColor());
		Attribute = (DrifterAttributes.AttributeType)(object)EditorGUI_EnumField("Attribute", Attribute);
		EditorGUI_PropertyField("AnimationEventType", "Rig Animation Event Type");
		EditorGUI_HelpBox("Hauls items from within the markers radius to a storge in town.");
	}

	protected override void OnItemSalvaged(ItemToHaul salvagedItem)
	{
		ItemEvent.Dispatch(GameEventType.ItemSalvaged, salvagedItem.Item);
		new AgentActionItemPropertiesEvent(GameEventType.AgentActionSalvagedMarkerItem, _assignment.Agent, salvagedItem.Item.Properties, Attribute).Dispatch();
	}
}
