using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	[RequireComponent(typeof(Selectable))]
	[AddComponentMenu(null)]
	public class ScrollRectSelectableChild : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		public bool useCustomEdgePadding;

		public float customEdgePadding;

		private ScrollRect parentScrollRect;

		private Selectable _selectable;

		private RectTransform parentScrollRectContentTransform => null;

		private Selectable selectable => null;

		private RectTransform rectTransform => null;

		private void Start()
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}
	}
}
