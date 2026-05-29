using UnityEngine;
using UnityEngine.EventSystems;

public class AutoMergeTooltip : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HoverTooltip tooltip;

	public Character character;

	public int id;

	private string message = "";

	public void OnPointerEnter(PointerEventData eventData)
	{
		switch (id)
		{
		case 1:
			InvokeRepeating("displayMergeTime", 0f, 1f);
			break;
		case 2:
			InvokeRepeating("displayBoostTime", 0f, 1f);
			break;
		}
	}

	public void displayMergeTime()
	{
		message = "Setting this toggle on will automatically merge every applicable item in your inventory with your currently equipped gear.";
		message = message + "\n\n Time Until next merge: " + NumberOutput.timeOutput((double)character.inventoryController.autoMergeTime() - character.inventory.mergeTime.totalseconds);
		tooltip.showTooltip(message);
	}

	public void displayBoostTime()
	{
		message = "Setting this toggle on will automatically apply all boosts in your inventory to your equipment, going in order from: Head, Chest, Eggs, Boots, Weapon, Accessories, and Infinity Cube. Did I say Eggs instead of Legs? Yes, yes I did.";
		message = message + "\n\n Time Until next boost: " + NumberOutput.timeOutput((double)character.inventoryController.autoBoostTime() - character.inventory.boostTime.totalseconds);
		tooltip.showTooltip(message);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CancelInvoke();
		tooltip.hideTooltip();
	}
}
