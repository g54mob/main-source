using UnityEngine.EventSystems;

namespace ModApi.Flight.UI
{
	public class InputResponderDelegates
	{
		public delegate bool InputPinchResponderDelegate(PinchEventData eventData);

		public delegate bool InputResponderDelegate(PointerEventData eventData);

		public delegate bool InputSelectionResponderDelegate(BaseEventData eventData);

		public delegate bool IsRespondingDelegate();
	}
}
