using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class PopupMenuRightClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private PopupMenu popupMenu;

		private void Start()
		{
			popupMenu.gameObject.SetActive(value: false);
			popupMenu.OnValueChanged.AddListener(PopupMenuValueChanged);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button != PointerEventData.InputButton.Right)
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

		private void PopupMenuValueChanged(int index)
		{
			Debug.Log("PopupMenu value changed, index:" + index);
		}
	}
}
