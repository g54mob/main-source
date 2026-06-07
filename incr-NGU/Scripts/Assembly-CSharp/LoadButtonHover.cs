using UnityEngine;
using UnityEngine.EventSystems;

public class LoadButtonHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HoverTooltip tooltip;

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			tooltip.showTooltip("This will open a dialog to select a save file to load.");
		}
		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.OSXPlayer)
		{
			tooltip.showTooltip("This will bring up a prompt to select a file to load from.");
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
	}
}
