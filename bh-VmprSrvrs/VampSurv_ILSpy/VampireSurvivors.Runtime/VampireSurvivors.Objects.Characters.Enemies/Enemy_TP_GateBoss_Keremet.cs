using System;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_TP_GateBoss_Keremet : Enemy_TP_GateBoss
{
	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public bool PlayCoffinAnimation;

		public Action _003C_003E9__1;

		internal void _003CCheckAssassin_003Eb__0()
		{
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			instance.Shake("LightningOniShake");
			Action onComplete = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				onComplete = (_003C_003E9__1 = delegate
				{
					//IL_001c: Expected O, but got I4
					if (PlayCoffinAnimation)
					{
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						soundConfig.Volume = (float?)(object)1;
						soundConfig.Detune = -1000f;
						soundConfig.Rate = 0.5f;
						float time = default(float);
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
					}
				});
			}
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.096f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}

		internal void _003CCheckAssassin_003Eb__1()
		{
			//IL_001c: Expected O, but got I4
			if (PlayCoffinAnimation)
			{
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Detune = -1000f;
				soundConfig.Rate = 0.5f;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
			}
		}
	}

	public CharacterType Assassin2;

	public override void CheckAssassin()
	{
		//IL_0013: Expected I, but got O
		//IL_0076: Expected I, but got O
		//IL_007b: Expected I, but got O
		if (Assassin != CharacterType.VOID)
		{
			nint num = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num2 = 0;
			GameManager core = GM.Core;
			if ((object)GM.Core == null || core._characters == null)
			{
				throw new NullReferenceException();
			}
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				nint num3 = unchecked((nint)null);
				num2 = unchecked((nint)null);
				throw new NullReferenceException();
			}
		}
	}
}
