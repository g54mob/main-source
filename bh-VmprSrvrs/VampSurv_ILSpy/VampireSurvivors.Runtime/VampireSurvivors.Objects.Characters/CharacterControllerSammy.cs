using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerSammy : CharacterController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__7_4;

		public static Action _003C_003E9__7_1;

		public static Action _003C_003E9__7_2;

		public static Action _003C_003E9__7_3;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CLevelUp_003Eb__7_1()
		{
			//IL_001d: Expected O, but got I4
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			GM.Core.TriggerGoldFever(10000f);
			object obj = 5000;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				Action onComplete = _003C_003E9__7_4;
				if (_003C_003E9__7_4 == null)
				{
					onComplete = (_003C_003E9__7_4 = delegate
					{
						GM.Core.TriggerGoldFever(10000f);
					});
				}
				float duration = (float)obj * 0.001f;
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				obj += 10000;
			}
			while ((nint)obj < 35000);
			GM.Core.TurnOnVacuumForGold();
			SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		}

		internal void _003CLevelUp_003Eb__7_4()
		{
			GM.Core.TriggerGoldFever(10000f);
		}

		internal void _003CLevelUp_003Eb__7_2()
		{
			//IL_002b: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Loop = false;
			soundConfig.Rate = 1f;
			SoundManager.PlayMusic(BgmType.BGM_HB, soundConfig);
		}

		internal void _003CLevelUp_003Eb__7_3()
		{
			SoundManager.StopMusic(BgmType.BGM_HB);
			GM.Core.SetupMusicBanger();
		}
	}

	private Action<float> _onCoinPickupCallback;

	private GrangattiWeapon _hungerWeapon;

	private Timer _timeout1;

	private Timer _timeout2;

	private Timer _timeout3;

	public override void AfterFullInitialization()
	{
		//IL_007f: Expected I, but got O
		//IL_008d: Expected I, but got O
		//IL_009d: Expected O, but got I
		//IL_011d: Expected O, but got I4
		//IL_00d9: Expected O, but got I
		//IL_010f: Expected O, but got I4
		base.AfterFullInitialization();
		Action<float> action = null;
		float value = default(float);
		((CharacterControllerSammy)(object)action).OnCoinPickup(value);
		_onCoinPickupCallback = action;
		GameManager core = GM.Core;
		((CharacterControllerSammy)(object)core._003COnCoinPickup_003Ek__BackingField).OnCoinPickup(value);
		Weapon weaponByType = base._weaponsManager.GetWeaponByType(WeaponType.STIGRANGATTI);
		bool flag = (object)weaponByType == null;
		Weapon hungerWeapon = weaponByType;
		if (flag)
		{
			goto IL_01b2;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(GrangattiWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.GrangattiWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.GrangattiWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rax_v35+FFFFFFF8+v245 @ rax_v30*8]");
			if (0 == (nint)typeof(GrangattiWeapon))
			{
				obj3 = 1;
				goto IL_01c1;
			}
		}
		obj3 = 0;
		goto IL_01c1;
		IL_01b2:
		_hungerWeapon = (GrangattiWeapon)hungerWeapon;
		GrangattiWeapon hungerWeapon2 = _hungerWeapon;
		if ((object)_hungerWeapon != null && ((UnityEngine.Object)hungerWeapon2).m_CachedPtr != (IntPtr)0)
		{
			GrangattiWeapon hungerWeapon3 = _hungerWeapon;
			hungerWeapon3.goldChance = 0.165;
		}
		return;
		IL_01c1:
		bool flag2 = obj3 == null;
		hungerWeapon = null;
		if (!flag2)
		{
			hungerWeapon = weaponByType;
		}
		goto IL_01b2;
	}

	public override void OnQuit()
	{
		base.OnQuit();
		SoundManager.StopMusic(BgmType.BGM_HB);
		if (_timeout1 != null)
		{
			_timeout1.Cancel();
		}
		if (_timeout2 != null)
		{
			_timeout2.Cancel();
		}
		if (_timeout3 != null)
		{
			_timeout3.Cancel();
		}
	}

	public override void LevelUp()
	{
		//IL_00b9: Expected O, but got I4
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		base.LevelUp();
		GrangattiWeapon hungerWeapon = _hungerWeapon;
		if ((object)_hungerWeapon != null && ((UnityEngine.Object)hungerWeapon).m_CachedPtr != (IntPtr)0)
		{
			GrangattiWeapon hungerWeapon2 = _hungerWeapon;
			object obj = (object)_hungerWeapon ^ (object)_hungerWeapon;
			object obj2 = (object)_hungerWeapon & obj;
			bool flag = (nint)obj2 < 0;
			bool flag2 = (nint)_hungerWeapon < 0;
			bool flag3 = (object)_hungerWeapon == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,qword ptr [rax+190h]\"");
			bool flag4 = flag2 == flag;
			object obj3 = !flag4;
			object obj4 = obj3 | flag3;
			if (obj4 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [188A10490h]\"");
				hungerWeapon2.goldChance = hungerWeapon2.goldChance;
			}
		}
		if (base._level != 30)
		{
			return;
		}
		Action onComplete = delegate
		{
			SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 500f);
			if (_timeout1 != null)
			{
				_timeout1.Cancel();
			}
			Action onComplete2 = _003C_003Ec._003C_003E9__7_1;
			if (_003C_003Ec._003C_003E9__7_1 == null)
			{
				onComplete2 = (_003C_003Ec._003C_003E9__7_1 = delegate
				{
					//IL_001d: Expected O, but got I4
					//IL_0071: Unknown result type (might be due to invalid IL or missing references)
					//IL_0076: Expected O, but got Unknown
					GM.Core.TriggerGoldFever(10000f);
					object obj5 = 5000;
					bool useRealTime3 = default(bool);
					MonoBehaviour autoDestroyOwner3 = default(MonoBehaviour);
					int repeat3 = default(int);
					TimerType type3 = default(TimerType);
					do
					{
						Action onComplete5 = _003C_003Ec._003C_003E9__7_4;
						if (_003C_003Ec._003C_003E9__7_4 == null)
						{
							onComplete5 = (_003C_003Ec._003C_003E9__7_4 = delegate
							{
								GM.Core.TriggerGoldFever(10000f);
							});
						}
						float duration = (float)obj5 * 0.001f;
						Timer timer2 = Timers.Register(duration, onComplete5, null, isLooped: false, useRealTime3, autoDestroyOwner3, repeat3, type3, isOnlineTimer: false, canPause: false);
						obj5 += 10000;
					}
					while ((nint)obj5 < 35000);
					GM.Core.TurnOnVacuumForGold();
					SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
				});
			}
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			TimerType type2 = default(TimerType);
			Timer timeout = Timers.Register(0.5f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_timeout1 = timeout;
			if (_timeout2 != null)
			{
				_timeout2.Cancel();
			}
			Action onComplete3 = _003C_003Ec._003C_003E9__7_2;
			if (_003C_003Ec._003C_003E9__7_2 == null)
			{
				onComplete3 = (_003C_003Ec._003C_003E9__7_2 = delegate
				{
					//IL_002b: Expected O, but got I4
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Volume = (float?)(object)1;
					soundConfig.Loop = false;
					soundConfig.Rate = 1f;
					SoundManager.PlayMusic(BgmType.BGM_HB, soundConfig);
				});
			}
			Timer timeout2 = Timers.Register(0.6f, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_timeout2 = timeout2;
			if (_timeout3 != null)
			{
				_timeout3.Cancel();
			}
			Action onComplete4 = _003C_003Ec._003C_003E9__7_3;
			if (_003C_003Ec._003C_003E9__7_3 == null)
			{
				onComplete4 = (_003C_003Ec._003C_003E9__7_3 = delegate
				{
					SoundManager.StopMusic(BgmType.BGM_HB);
					GM.Core.SetupMusicBanger();
				});
			}
			Timer timeout3 = Timers.Register(31.000002f, onComplete4, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			_timeout3 = timeout3;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public void OnCoinPickup(float value)
	{
		//IL_0060: Expected O, but got I4
		float num = value * GameManager.GoldMultiplier;
		float num2 = base.PGreed();
		float num3 = base.PGrowth();
		object obj = default(object);
		float num4 = (float)obj * num;
		float xp = num4 * (float)obj;
		GM.Core.AddPlayerXp(xp, XPMultiplierMode.IgnoreGameKiller);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Gem, soundConfig, 1f, 1, time);
		GM.Core.FirePlayerXpUpdated();
	}

	private void _003CLevelUp_003Eb__7_0()
	{
		SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 500f);
		if (_timeout1 != null)
		{
			_timeout1.Cancel();
		}
		Action onComplete = _003C_003Ec._003C_003E9__7_1;
		if (_003C_003Ec._003C_003E9__7_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__7_1 = delegate
			{
				//IL_001d: Expected O, but got I4
				//IL_0071: Unknown result type (might be due to invalid IL or missing references)
				//IL_0076: Expected O, but got Unknown
				GM.Core.TriggerGoldFever(10000f);
				object obj = 5000;
				bool useRealTime2 = default(bool);
				MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
				int repeat2 = default(int);
				TimerType type2 = default(TimerType);
				do
				{
					Action onComplete4 = _003C_003Ec._003C_003E9__7_4;
					if (_003C_003Ec._003C_003E9__7_4 == null)
					{
						onComplete4 = (_003C_003Ec._003C_003E9__7_4 = delegate
						{
							GM.Core.TriggerGoldFever(10000f);
						});
					}
					float duration = (float)obj * 0.001f;
					Timer timer = Timers.Register(duration, onComplete4, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
					obj += 10000;
				}
				while ((nint)obj < 35000);
				GM.Core.TurnOnVacuumForGold();
				SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
			});
		}
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timeout = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_timeout1 = timeout;
		if (_timeout2 != null)
		{
			_timeout2.Cancel();
		}
		Action onComplete2 = _003C_003Ec._003C_003E9__7_2;
		if (_003C_003Ec._003C_003E9__7_2 == null)
		{
			onComplete2 = (_003C_003Ec._003C_003E9__7_2 = delegate
			{
				//IL_002b: Expected O, but got I4
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Loop = false;
				soundConfig.Rate = 1f;
				SoundManager.PlayMusic(BgmType.BGM_HB, soundConfig);
			});
		}
		Timer timeout2 = Timers.Register(0.6f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_timeout2 = timeout2;
		if (_timeout3 != null)
		{
			_timeout3.Cancel();
		}
		Action onComplete3 = _003C_003Ec._003C_003E9__7_3;
		if (_003C_003Ec._003C_003E9__7_3 == null)
		{
			onComplete3 = (_003C_003Ec._003C_003E9__7_3 = delegate
			{
				SoundManager.StopMusic(BgmType.BGM_HB);
				GM.Core.SetupMusicBanger();
			});
		}
		Timer timeout3 = Timers.Register(31.000002f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_timeout3 = timeout3;
	}
}
