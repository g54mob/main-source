using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace viperOSK
{
	public class OSK_UI_CustomReceiver : OSK_Receiver, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, ISelectHandler, ISubmitHandler
	{
		public UnityEvent onSelect;

		public UnityEvent onSelectClick;

		private void Awake()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		void ISubmitHandler.OnSubmit(BaseEventData eventData)
		{
		}

		public override int Selection(Vector3 hitpoint, bool charhit = false)
		{
			return 0;
		}

		public override void Deselect()
		{
		}

		public override void SelectionHighlight(Color32 c, bool all = false)
		{
		}

		private void Update()
		{
		}
	}
}
