using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class PinnedUi : UIBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private UpdateState state;

		public bool pinned;

		public bool hovered;

		public void Setup()
		{
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
		}

		public void Check()
		{
		}

		public void SetPinned(bool pinned)
		{
		}
	}
}
