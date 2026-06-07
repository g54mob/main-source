using UnityEngine;
using UnityEngine.EventSystems;

namespace UIScripts
{
	public class ClickToEditHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private bool hovering;

		public void OnPointerEnter(PointerEventData eventData)
		{
			SetEditCursor(val: true);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			SetEditCursor(val: false);
		}

		public void SetEditCursor(bool val)
		{
			hovering = val;
			Cursor.SetCursor(val ? UIPrefabsHolder.Instance.editCursor : null, Vector2.zero, CursorMode.Auto);
		}

		private void OnDisable()
		{
			if (hovering)
			{
				SetEditCursor(val: false);
			}
		}
	}
}
