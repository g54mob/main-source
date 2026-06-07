using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Jundroo.DevConsole
{
	public class ConsoleInputField : InputField
	{
		private bool _arrowupKeyPreviousFrame;

		private DeveloperConsole _developerConsole;

		public bool IsCursorAtEnd => base.caretPosition == base.text.Length;

		public bool IsCursorAtStart => base.caretPosition == 0;

		public override void OnUpdateSelected(BaseEventData eventData)
		{
			int num = base.caretPosition;
			if (!_developerConsole.HandleInputKeys())
			{
				base.OnUpdateSelected(eventData);
			}
			else
			{
				eventData.Use();
			}
			if (num != 0 && base.caretPosition == 0 && _arrowupKeyPreviousFrame)
			{
				MoveTextEnd(shift: false);
			}
			_arrowupKeyPreviousFrame = Input.GetKey(KeyCode.UpArrow);
		}

		protected override void Awake()
		{
			base.Awake();
			_developerConsole = base.transform.root.GetComponentInChildren<DeveloperConsole>();
		}

		protected override void LateUpdate()
		{
			bool num = base.isFocused;
			base.LateUpdate();
			if (num != base.isFocused)
			{
				MoveTextEnd(shift: false);
			}
		}
	}
}
