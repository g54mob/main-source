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
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		private void PopupMenuValueChanged(int index)
		{
		}
	}
}
