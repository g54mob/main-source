using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Input Action Perform (Button)")]
	[Category("Input System/Input Action Perform (Button)")]
	[Description("When an Input Action asset of Button type runs the Performed phase")]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Blue, typeof(OverlayArrowRight))]
	[Keywords(new string[] { "Unity", "Asset", "Map", "Release" })]
	public class InputButtonInputActionPerform : TInputButton
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
				m_Input.InputAction.performed -= OnInputPerform;
				m_Input.InputAction.canceled += OnInputCancel;
				m_Input.InputAction.started += OnInputStart;
				m_Input.InputAction.performed += OnInputPerform;
			}
		}

		public override void OnDispose()
		{
			base.OnDispose();
			if (m_Input?.InputAction != null)
			{
				m_Input.InputAction.canceled -= OnInputCancel;
				m_Input.InputAction.started -= OnInputStart;
				m_Input.InputAction.performed -= OnInputPerform;
			}
		}

		private void OnInputStart(InputAction.CallbackContext _)
		{
			ExecuteEventStart();
		}

		private void OnInputCancel(InputAction.CallbackContext _)
		{
			ExecuteEventCancel();
		}

		private void OnInputPerform(InputAction.CallbackContext _)
		{
			ExecuteEventPerform();
		}
	}
}
