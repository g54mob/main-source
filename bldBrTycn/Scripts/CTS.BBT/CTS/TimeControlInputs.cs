using CTS.BBT;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class TimeControlInputs : CTSBehaviour
	{
		[SerializeField]
		private MonoCondition[] _changeConditions;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			InputManager.game.live.timeControlPause.onComplete += OnInputPause;
			InputManager.game.live.timeControlSlow.onComplete += OnInputSlow;
			InputManager.game.live.timeControlNormal.onComplete += OnInputNormal;
			InputManager.game.live.timeControlFast.onComplete += OnInputFast;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			InputManager.game.live.timeControlPause.onComplete -= OnInputPause;
			InputManager.game.live.timeControlSlow.onComplete -= OnInputSlow;
			InputManager.game.live.timeControlNormal.onComplete -= OnInputNormal;
			InputManager.game.live.timeControlFast.onComplete -= OnInputFast;
		}

		private void OnInputPause(InputAction.CallbackContext ctx)
		{
			ChangeMode(ETimeModes.Pause);
		}

		private void OnInputSlow(InputAction.CallbackContext ctx)
		{
			ChangeMode(ETimeModes.SlowMo);
		}

		private void OnInputNormal(InputAction.CallbackContext ctx)
		{
			ChangeMode(ETimeModes.Normal);
		}

		private void OnInputFast(InputAction.CallbackContext ctx)
		{
			ChangeMode(ETimeModes.Fast);
		}

		private void ChangeMode(ETimeModes mode)
		{
			if (MonoSingleton<TimeController>.Instance.ObjectLock.IsLocked())
			{
				return;
			}
			MonoCondition[] changeConditions = _changeConditions;
			for (int i = 0; i < changeConditions.Length; i++)
			{
				if (!changeConditions[i].IsConditionValid())
				{
					return;
				}
			}
			MonoSingleton<TimeController>.Instance.TimeMode = mode;
		}
	}
}
