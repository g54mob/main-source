using System;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_OnRevive_Vacuum : CharacterSkillCard_Base
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__1_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnOwnerRevived_003Eb__1_0()
		{
			//IL_004d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Vacuum, soundConfig, 1000f, 1, time);
			GM.Core.TurnOnVacuum();
		}
	}

	public SubSkillCard_OnRevive_Vacuum(ArcanaType type)
		: base(type)
	{
	}

	public override void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
	{
		base.OnOwnerRevived(percentage, instantRevival);
		Action onComplete = _003C_003Ec._003C_003E9__1_0;
		if (_003C_003Ec._003C_003E9__1_0 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__1_0 = delegate
			{
				//IL_004d: Expected O, but got I4
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 1f;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Vacuum, soundConfig, 1000f, 1, time);
				GM.Core.TurnOnVacuum();
			});
		}
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}
}
