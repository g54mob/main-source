using UnityEngine;
using UnityEngine.EventSystems;

namespace RainbowArt.CleanFlatUI
{
	public class ContextMenuRightClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private ContextMenu contextMenu;

		[SerializeField]
		private RectTransform areaScope;

		private void Start()
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		private void ContextMenuValueChanged(int index)
		{
		}
	}
}
