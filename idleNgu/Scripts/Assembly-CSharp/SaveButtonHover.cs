using UnityEngine;
using UnityEngine.EventSystems;

public class SaveButtonHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HoverTooltip tooltip;

	public Character character;

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			tooltip.showTooltip("Clicking this button will generate a permanent save file. Sometimes the autosave can be lost by the browser, so regular saving means less chance of losing anything! You can save as many times as you like, and also gain a <b>" + character.checkAPAdded(200L) + " AP bonus</b> when you save your game at least once per day! Time until next manual save AP reward: " + timeLeft());
		}
		if (Application.platform != RuntimePlatform.WindowsPlayer && Application.platform != RuntimePlatform.WindowsEditor && Application.platform != RuntimePlatform.LinuxPlayer)
		{
			_ = Application.platform;
			_ = 1;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}

	public string timeLeft()
	{
		if (character.settings.dailySaveRewardTime.totalseconds >= 82800.0)
		{
			return "READY";
		}
		return NumberOutput.timeOutput(82800.0 - character.settings.dailySaveRewardTime.totalseconds);
	}
}
