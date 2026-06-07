using CTS.BBT;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class PauseInput : CTSBehaviour
	{
		private ETimeModes _lastTimeMode;

		[SerializeField]
		private MonoCondition[] _conditions;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			InputManager.game.live.pause.onComplete += OnInputPause;
			TimeController.TimeModeChanged += OnTimeScaleChanged;
			_lastTimeMode = ((MonoSingleton<TimeController>.Instance.TimeMode == ETimeModes.Pause) ? ETimeModes.Normal : MonoSingleton<TimeController>.Instance.TimeMode);
		}

		private void OnTimeScaleChanged(ETimeModes timeModes)
		{
			if (timeModes != ETimeModes.Pause)
			{
				_lastTimeMode = timeModes;
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			InputManager.game.live.pause.onComplete -= OnInputPause;
			TimeController.TimeModeChanged -= OnTimeScaleChanged;
		}

		private void OnInputPause(InputAction.CallbackContext ctx)
		{
			if (MonoSingleton<TimeController>.Instance.ObjectLock.IsLocked())
			{
				return;
			}
			MonoCondition[] conditions = _conditions;
			for (int i = 0; i < conditions.Length; i++)
			{
				if (!conditions[i].IsConditionValid())
				{
					return;
				}
			}
			if (MonoSingleton<TimeController>.Instance.TimeMode == ETimeModes.Pause)
			{
				MonoSingleton<TimeController>.Instance.TimeMode = _lastTimeMode;
			}
			else
			{
				MonoSingleton<TimeController>.Instance.TimeMode = ETimeModes.Pause;
			}
		}
	}
}
