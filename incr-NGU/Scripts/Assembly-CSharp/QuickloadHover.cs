using UnityEngine;
using UnityEngine.EventSystems;

public class QuickloadHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HoverTooltip tooltip;

	public OpenFileDialog file;

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			tooltip.showTooltip("This will load your online save. Keep in mind that there's a 2 minute cooldown between clicking online loads!");
		}
		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.OSXPlayer)
		{
			tooltip.showTooltip("This will load your online save. Keep in mind that there's a 2 minute cooldown between clicking online loads!");
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
