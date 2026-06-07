using UnityEngine;
using UnityEngine.EventSystems;

public class PanelDismiss : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public MenuPanel parentPanel;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (null != parentPanel)
		{
			parentPanel.Hide();
		}
	}
}
