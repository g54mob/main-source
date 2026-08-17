using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class TP_Sonia_Character : TP_Character
{
	private float OverhealDelay = 5000f;

	private float OverhealTriggerValue = 8f;

	private bool _canOverheal;

	private Timer _overHealTimer;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		_canOverheal = true;
		Action<float, float> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
		Delegate obj = Delegate.Combine(((CharacterController)this)._onHpRecoveryCallback, b);
		if ((object)obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj == null)
			{
				throw new InvalidCastException();
			}
		}
		((CharacterController)this)._onHpRecoveryCallback = (Action<float, float>)obj;
	}

	private void BurningMode(float value, float rawValue)
	{
		float num = rawValue - value;
		if (!(num < OverhealTriggerValue) && _canOverheal)
		{
			_canOverheal = false;
			if (_overHealTimer != null)
			{
				_overHealTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_canOverheal = true;
			};
			float duration = OverhealDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer overHealTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_overHealTimer = overHealTimer;
			((CharacterController)this)._classSupport.AddActiveRapidFire(-0.3f, 0.3f, 10000f);
		}
	}

	private void _003CBurningMode_003Eb__5_0()
	{
		_canOverheal = true;
	}
}
