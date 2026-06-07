using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Input Action Start (Button)")]
	[Category("Input System/Input Action Start (Button)")]
	[Description("When an Input Action asset of Button type runs the Started phase")]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Blue, typeof(OverlayArrowLeft))]
	[Keywords(new string[] { "Unity", "Asset", "Map", "Press" })]
	public class InputButtonInputActionStart : TInputButton
	{
		[SerializeField]
		private InputActionFromAsset m_Input = new InputActionFromAsset();

		public override void OnStartup()
		{
			base.OnStartup();
			if (m_Input?.InputAction != null)
			{
				m_Input.InputAction.canceled -= OnInputCancel;
				m_Input.InputAction.started -= OnInputStart;
				m_Input.InputAction.canceled += OnInputCancel;
				m_Input.InputAction.started += OnInputStart;
			}
		}

		public override void OnDispose()
		{
			base.OnDispose();
			if (m_Input?.InputAction != null)
			{
				m_Input.InputAction.canceled -= OnInputCancel;
				m_Input.InputAction.started -= OnInputStart;
			}
		}

		private void OnInputStart(InputAction.CallbackContext _)
		{
			ExecuteEventStart();
			ExecuteEventPerform();
		}

		private void OnInputCancel(InputAction.CallbackContext _)
		{
			ExecuteEventCancel();
		}
	}
}
