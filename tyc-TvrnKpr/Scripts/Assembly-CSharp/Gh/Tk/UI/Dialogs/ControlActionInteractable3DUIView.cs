using UnityEngine;
using UnityEngine.InputSystem;

namespace Gh.Tk.UI.Dialogs
{
	public class ControlActionInteractable3DUIView : Button3DUIView
	{
		private InputAction _action;

		private int _bindingIndex1;

		private int _bindingIndex2;

		[SerializeField]
		private BaseInteractable3DUIView _issueInfoBinding1;

		[SerializeField]
		private BaseInteractable3DUIView _issueInfoBinding2;

		public void SetData(InputAction action, int bindingIndex1, int bindingIndex2)
		{
		}

		public override void CheckState()
		{
		}
	}
}
