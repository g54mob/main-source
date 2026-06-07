using System.Collections;
using UnityEngine;

public class ConsumeItem : TaskBase
{
	public float Duration;

	public override TaskType Type => TaskType.ConsumeItem;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		Target moveToTarget = null;
		ItemToHaul itemToHaul;
		while (_assignment.TryReturnItemToHaul(ItemToHaul.HaulState.Pickup, out itemToHaul))
		{
			if (itemToHaul.MoveToTarget != moveToTarget)
			{
				moveToTarget = itemToHaul.MoveToTarget;
				yield return MoveAgentCoroutine(moveToTarget);
			}
			yield return ConsumeCoroutine(itemToHaul.Item);
			itemToHaul.Consume();
		}
	}

	protected override void OnGUI()
	{
		Header("Consume Item", 1, ReturnTypeColor());
		Duration = EditorGUI_FloatField("Duration", Duration);
		EditorGUI_HelpBox("Consumes an item and applies its buffs.");
	}

	private IEnumerator ConsumeCoroutine(Item item)
	{
		_agent.UpdateActivity(GameSettings.Instance.ItemSettings.GetConsumeActivity(item));
		yield return new WaitForSeconds(Duration);
		_agent.Vitals.ConsumeItem(item);
		item.Inventory.TakeItem(item);
		item.Inventory = null;
	}
}
