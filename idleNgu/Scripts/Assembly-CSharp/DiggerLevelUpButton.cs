using UnityEngine;
using UnityEngine.EventSystems;

public class DiggerLevelUpButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public GoldDiggerUIController controller;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			controller.upgradeMaxLevelFully();
		}
		else if (eventData.button == PointerEventData.InputButton.Left)
		{
			controller.upgradeMaxLevel();
		}
	}
}
