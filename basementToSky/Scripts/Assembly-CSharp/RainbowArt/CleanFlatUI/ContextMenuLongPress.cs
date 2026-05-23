using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace RainbowArt.CleanFlatUI
{
	public class ContextMenuLongPress : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerUpHandler, IPointerDownHandler
	{
		[SerializeField]
		private ContextMenu contextMenu;

		[SerializeField]
		private RectTransform areaScope;

		private Camera cachedEnterEventCamera;

		private bool isPressed;

		private float elapsedTime;

		private float duration = 0.3f;

		private void Start()
		{
			contextMenu.gameObject.SetActive(value: false);
			contextMenu.OnValueChanged.AddListener(ContextMenuValueChanged);
		}

		private void Update()
		{
			if (isPressed)
			{
				elapsedTime += Time.deltaTime;
				if (elapsedTime >= duration)
				{
					showContextMenu();
					isPressed = false;
					elapsedTime = 0f;
				}
			}
		}

		private void showContextMenu()
		{
			if (cachedEnterEventCamera != null)
			{
				Vector2 screenPoint = Mouse.current.position.ReadValue();
				Vector2 localPoint = Vector2.zero;
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(areaScope, screenPoint, cachedEnterEventCamera, out localPoint))
				{
					UpdatePosition();
				}
			}
		}

		private void UpdatePosition()
		{
			Vector2 screenPoint = Mouse.current.position.ReadValue();
			Vector2 localPoint = Vector2.zero;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(contextMenu.gameObject.GetComponent<RectTransform>().parent as RectTransform, screenPoint, cachedEnterEventCamera, out localPoint);
			contextMenu.Show(localPoint, areaScope);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			cachedEnterEventCamera = eventData.enterEventCamera;
			isPressed = true;
			elapsedTime = 0f;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			cachedEnterEventCamera = eventData.enterEventCamera;
			isPressed = false;
			elapsedTime = 0f;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				cachedEnterEventCamera = null;
			}
		}

		private void ContextMenuValueChanged(int index)
		{
			Debug.Log("ContextMenu value changed, index:" + index);
		}
	}
}
