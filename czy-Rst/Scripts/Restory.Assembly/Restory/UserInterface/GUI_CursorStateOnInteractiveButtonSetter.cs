using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface
{
	public class GUI_CursorStateOnInteractiveButtonSetter : GUI_CursorStateOnPointEnterSetter
	{
		[SerializeField]
		private Selectable button;

		public override bool CanSwitchState => button.interactable;
	}
}
