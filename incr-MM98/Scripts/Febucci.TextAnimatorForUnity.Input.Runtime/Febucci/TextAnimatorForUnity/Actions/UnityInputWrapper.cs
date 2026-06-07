using System;
using Febucci.TextAnimatorCore.Typing;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Febucci.TextAnimatorForUnity.Actions
{
	internal class UnityInputWrapper : IActionState
	{
		private bool inputSystemPassed;

		private IDisposable eventListener;

		public UnityInputWrapper(bool _)
		{
			inputSystemPassed = false;
			eventListener = null;
			eventListener = InputSystem.onAnyButtonPress.CallOnce(PassInput);
		}

		private void PassInput(InputControl control)
		{
			inputSystemPassed = true;
		}

		public ActionStatus Progress(float deltaTime, ref TypingInfo typingInfo)
		{
			if (inputSystemPassed)
			{
				return ActionStatus.Finished;
			}
			return ActionStatus.Running;
		}

		public void Cancel()
		{
			eventListener?.Dispose();
		}
	}
}
