using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Battlehub.RTEditor
{
	public class DragField : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler, IDropHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
	{
		public InputField Field;

		public float IncrementFactor = 0.1f;

		public Texture2D DragCursor;

		private void Start()
		{
			if (Field == null)
			{
				Debug.LogWarning("Set Field");
			}
		}

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
		}

		void IDropHandler.OnDrop(PointerEventData eventData)
		{
		}

		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			if (!(Field == null) && Field.contentType == InputField.ContentType.DecimalNumber && float.TryParse(Field.text, out var result))
			{
				result += IncrementFactor * eventData.delta.x;
				Field.text = result.ToString();
			}
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			Cursor.SetCursor(DragCursor, new Vector2(24f, 24f), CursorMode.Auto);
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}
	}
}
