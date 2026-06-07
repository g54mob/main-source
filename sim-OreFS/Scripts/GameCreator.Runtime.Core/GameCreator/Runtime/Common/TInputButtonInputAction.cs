using System;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TInputButtonInputAction : TInputButton
	{
		public abstract InputAction InputAction { get; }

		public override void OnStartup()
		{
			Enable();
		}

		public override void OnDispose()
		{
			Disable();
			InputAction?.Dispose();
		}

		public override void OnUpdate()
		{
			RequireActiveInputAsset();
			base.OnUpdate();
		}

		private void Enable()
		{
			if (InputAction != null)
			{
				RequireActiveInputAsset();
				InputAction.started -= ExecuteEventStart;
				InputAction.canceled -= ExecuteEventCancel;
				InputAction.performed -= ExecuteEventPerform;
				InputAction.started += ExecuteEventStart;
				InputAction.canceled += ExecuteEventCancel;
				InputAction.performed += ExecuteEventPerform;
			}
		}

		private void Disable()
		{
			if (InputAction != null)
			{
				InputAction.started -= ExecuteEventStart;
				InputAction.canceled -= ExecuteEventCancel;
				InputAction.performed -= ExecuteEventPerform;
			}
		}

		private void RequireActiveInputAsset()
		{
			InputAction inputAction = InputAction;
			if (inputAction == null || !inputAction.enabled)
			{
				InputAction?.Enable();
			}
		}

		protected abstract void ExecuteEventStart(InputAction.CallbackContext context);

		protected abstract void ExecuteEventCancel(InputAction.CallbackContext context);

		protected abstract void ExecuteEventPerform(InputAction.CallbackContext context);
	}
}
