using System;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Weapons;

public class TP_NeutronPickup_Weapon : Weapon
{
	protected override void MakeLevelOne()
	{
		base.MakeLevelOne();
		Action onComplete = delegate
		{
			base.Fire(skipTriggers: true);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		((Equipment)this)._003CShowInRecap_003Ek__BackingField = false;
	}

	public override float PPower()
	{
		return 900f;
	}

	public override float PAmount()
	{
		return 1f;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	private void _003CMakeLevelOne_003Eb__0_0()
	{
		base.Fire(skipTriggers: true);
	}
}
