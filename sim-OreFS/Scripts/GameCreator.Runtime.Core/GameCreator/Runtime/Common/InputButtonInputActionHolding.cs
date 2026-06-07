using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Input Action While Holding (Button)")]
	[Category("Input System/Input Action While Holding (Button)")]
	[Description("While an Input Action asset of Button type is being held down")]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Blue, typeof(OverlayDot))]
	[Keywords(new string[] { "Unity", "Asset", "Map", "Pressing" })]
	public class InputButtonInputActionHolding : TInputButton
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
		}

		private void OnInputCancel(InputAction.CallbackContext _)
		{
			ExecuteEventCancel();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			if (m_Input.InputAction != null && (m_Input.InputAction.IsPressed() || m_Input.InputAction.WasReleasedThisFrame()))
			{
				ExecuteEventPerform();
			}
		}
	}
}
