using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace viperOSK
{
	public class OSK_UI_InputReceiver : OSK_Receiver, ISubmitHandler, IEventSystemHandler, IPointerClickHandler, IDragHandler
	{
		public enum OSK_RECEIVER
		{
			NONE = 0,
			INPUTFIELD = 1,
			TMPRO_INPUTFIELD = 2
		}

		private InputField inputReceiver;

		private TMP_InputField inputTMPReceiver;

		private OSK_RECEIVER receiver;

		public UnityEvent onSelectClick;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void TMPInputFieldReActivate()
		{
		}

		public int SelectionEnd()
		{
			return 0;
		}

		public override void Submit()
		{
		}

		public override void AddText(string newchar)
		{
		}

		public override string Text()
		{
			return null;
		}

		public override string ParsedText()
		{
			return null;
		}

		public override void ToggleCharMask(bool on_off_charmask)
		{
		}

		public override void OnFocus()
		{
		}

		public override void OnFocusLost()
		{
		}

		public override void NewLine()
		{
		}

		public override void Backspace()
		{
		}

		public override void Del()
		{
		}

		public override void ClearText()
		{
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		void ISubmitHandler.OnSubmit(BaseEventData eventData)
		{
		}
	}
}
