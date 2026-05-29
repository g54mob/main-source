using UnityEngine;
using UnityEngine.EventSystems;

public class EnergyNextSpeed : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Character character;

	public HoverTooltip tooltip;

	private string message;

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (character.totalEnergySpeed() < 50f)
		{
			message = "Current Energy Speed is " + character.totalEnergySpeed().ToString("#0.#") + ", meaning the bar fills every " + ticksperFill() + " ticks.";
			message = message + " Next Speed Increase is at  " + nextIncrease().ToString("#0.#") + " Energy Speed";
			tooltip.showTooltip(message);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}

	public int ticksperFill()
	{
		return Mathf.CeilToInt(50f / character.totalEnergySpeed());
	}

	public float nextIncrease()
	{
		return 50f / (float)Mathf.FloorToInt(50f / character.totalEnergySpeed());
	}
}
