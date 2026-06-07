using System;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Any")]
	[Category("Any")]
	[Description("The input is executing pressing any device button")]
	[Image(typeof(IconCheckmark), ColorTheme.Type.TextLight)]
	public class InputButtonAny : TInputButtonInputAction
	{
		[NonSerialized]
		private InputAction m_InputAction;

		public override InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Any", InputActionType.Button);
					m_InputAction.AddBinding("/*/<button>");
				}
				return m_InputAction;
			}
		}

		public static InputPropertyButton Create()
		{
			return new InputPropertyButton(new InputButtonAny());
		}

		protected override void ExecuteEventStart(InputAction.CallbackContext context)
		{
			ExecuteEventStart();
		}

		protected override void ExecuteEventCancel(InputAction.CallbackContext context)
		{
			ExecuteEventCancel();
		}

		protected override void ExecuteEventPerform(InputAction.CallbackContext context)
		{
			ExecuteEventPerform();
		}
	}
}
