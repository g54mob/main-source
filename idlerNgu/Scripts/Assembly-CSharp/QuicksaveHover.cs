using UnityEngine;
using UnityEngine.EventSystems;

public class QuicksaveHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public HoverTooltip tooltip;

	public OpenFileDialog dialogue;

	public Character character;

	private string message;

	public void OnPointerEnter(PointerEventData eventData)
	{
		InvokeRepeating("showMessage", 0f, 1f);
	}

	public void showMessage()
	{
		if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			if (character.platform == platform.Kong)
			{
				message = "You can click this button to have your save safely stored on a server, which you can retrieve at any time or from another device! Just make sure you're logged into your Kongregate account!";
			}
			else if (character.platform == platform.AG)
			{
				message = "You can click this button to have your save safely stored on a server, which you can retrieve at any time or from another device! Just make sure you're logged into your Armor Games account!";
			}
		}
		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.OSXPlayer)
		{
			message = "You can click this button to have your save safely stored on a server, which you can retrieve at any time or from another device! Just make sure you're logged into your Steam account!";
		}
		message = message + "\n\nYour game will be saved online in <b>" + dialogue.onlineSaveTimeRemaining() + "</b> seconds";
		tooltip.showTooltip(message);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.hideTooltip();
		CancelInvoke("showMessage");
	}
}
