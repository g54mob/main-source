using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class PopupMenuLongPress : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerUpHandler, IPointerDownHandler
	{
		[SerializeField]
		private PopupMenu popupMenu;

		private Camera cachedEnterEventCamera;

		private bool isPressed;

		private float elapsedTime;

		private float duration = 0.3f;

		private void Start()
		{
			popupMenu.gameObject.SetActive(value: false);
			popupMenu.OnValueChanged.AddListener(PopupMenuValueChanged);
		}

		private void Update()
		{
			if (isPressed)
			{
				elapsedTime += Time.deltaTime;
				if (elapsedTime >= duration)
				{
					showPopupMenu();
					isPressed = false;
					elapsedTime = 0f;
				}
			}
		}

		private void showPopupMenu()
		{
			if (!(cachedEnterEventCamera != null))
			{
				return;
			}
			RectTransform rectTransform = popupMenu.GetComponent<RectTransform>().parent as RectTransform;
			if (!(rectTransform == null))
			{
				RectTransform component = GetComponent<RectTransform>();
				float width = component.rect.width;
				float height = component.rect.height;
				Vector3[] array = new Vector3[4];
				component.GetWorldCorners(array);
				Vector3[] array2 = new Vector3[4];
				for (int i = 0; i < 4; i++)
				{
					array2[i] = rectTransform.InverseTransformPoint(array[i]);
				}
				Vector3 position = array2[0];
				popupMenu.ShowPopupMenu(position, width, height);
			}
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

		private void PopupMenuValueChanged(int index)
		{
			Debug.Log("PopupMenu value changed, index:" + index);
		}
	}
}
