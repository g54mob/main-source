using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Mace2Crit_Projectile : TP_Mace2Standard_Projectile
{
	private bool m_CanRegisterNewFrameFreeze = true;

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		if (obj2 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v5+10]");
		if ((nint)0 == 0 || !m_CanRegisterNewFrameFreeze)
		{
			return;
		}
		m_CanRegisterNewFrameFreeze = false;
		Action onComplete = delegate
		{
			//IL_0046: Expected O, but got I
			//IL_014f: Expected O, but got I4
			//IL_01d0: Expected O, but got F4
			//IL_017e: Expected F4, but got I4
			m_CanRegisterNewFrameFreeze = true;
			object CS_0024_003C_003E8__locals1 = _trueWeapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdi_v2 (System.Object)+170]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdi_v2 (System.Object)+168]");
				bool flag = (nint)0 == 0;
				_ = 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdi_v2 (System.Object)+168]");
					((Timer)0).Cancel();
				}
				Action onComplete2 = delegate
				{
					((TP_Mace2_Weapon)CS_0024_003C_003E8__locals1)._canFreeze = true;
				};
				bool flag2 = default(bool);
				MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
				int repeat2 = default(int);
				TimerType type2 = default(TimerType);
				Timer timer2 = Timers.Register(0.1f, onComplete2, null, isLooped: false, flag2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
				GameManager core = GM.Core;
				PlayerOptionsData config = core._playerOptions.Config;
				if (config._003CScreenShakeEnabled_003Ek__BackingField)
				{
					GameManager core2 = GM.Core;
					if (!core2._003CFreezingFrame_003Ek__BackingField)
					{
						core2.FrameFreeze(null, 150f);
					}
				}
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 1f;
				object obj3 = UnityEngine.Random.value;
				float detune = 0.1f * -500f;
				soundConfig.Detune = detune;
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Crystal6, soundConfig, 500f, 5, flag2 ? 1 : 0);
			}
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.080000006f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void _003COnHasHitAnObject_003Eb__1_0()
	{
		//IL_0046: Expected O, but got I
		//IL_014f: Expected O, but got I4
		//IL_01d0: Expected O, but got F4
		//IL_017e: Expected F4, but got I4
		m_CanRegisterNewFrameFreeze = true;
		object CS_0024_003C_003E8__locals1 = _trueWeapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdi_v2 (System.Object)+170]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdi_v2 (System.Object)+168]");
		bool flag = (nint)0 == 0;
		_ = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdi_v2 (System.Object)+168]");
			((Timer)0).Cancel();
		}
		Action onComplete = delegate
		{
			((TP_Mace2_Weapon)CS_0024_003C_003E8__locals1)._canFreeze = true;
		};
		bool flag2 = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			if (!core2._003CFreezingFrame_003Ek__BackingField)
			{
				core2.FrameFreeze(null, 150f);
			}
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		float detune = 0.1f * -500f;
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Crystal6, soundConfig, 500f, 5, flag2 ? 1 : 0);
	}
}
