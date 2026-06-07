using UnityEngine;
using UnityEngine.EventSystems;

namespace MG_BlocksEngine2.UI
{
	public class BE2_UI_PanelCancel : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		public void OnPointerDown(PointerEventData eventData)
		{
			BE2_UI_ContextMenuManager.instance.CloseContextMenu();
		}
	}
}
