using UnityEngine;
using UnityEngine.EventSystems;

public class ZoneBackwardsClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public AdventureController ac;

	public Character character;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			ac.zoneSelector.changeZone(-1);
		}
		else
		{
			zoneBack();
		}
	}

	public void zoneBack()
	{
		if (ac.zone != -1 && ac.zone < 1000)
		{
			ac.zoneSelector.changeZone(character.adventure.zone - 1);
		}
	}
}
