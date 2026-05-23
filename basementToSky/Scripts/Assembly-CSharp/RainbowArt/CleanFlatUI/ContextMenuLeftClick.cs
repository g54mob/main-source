using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace RainbowArt.CleanFlatUI
{
	public class ContextMenuLeftClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private ContextMenu contextMenu;

		[SerializeField]
		private RectTransform areaScope;

		private void Start()
		{
			contextMenu.gameObject.SetActive(value: false);
			contextMenu.OnValueChanged.AddListener(ContextMenuValueChanged);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				Vector2 screenPoint = Mouse.current.position.ReadValue();
				Vector2 localPoint = Vector2.zero;
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(contextMenu.gameObject.GetComponent<RectTransform>().parent as RectTransform, screenPoint, eventData.enterEventCamera, out localPoint))
				{
					contextMenu.Show(localPoint, areaScope);
				}
			}
		}

		private void ContextMenuValueChanged(int index)
		{
			Debug.Log("ContextMenu value changed, index:" + index);
		}
	}
}
