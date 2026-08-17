using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.Objects.Characters;

public class TP_Maria_Character : CharacterController
{
	private int _followers;

	public float bonusConst;

	public float bonusStats;

	public float overhealingTotal;

	private float OverhealDelay;

	private float OverhealTriggerValue;

	private float OverhealTriggerValue2;

	private bool _canOverheal;

	private Timer _overHealTimer;

	private List<CharacterType> possibleFollowers;

	private List<CharacterType> currentFollowers;

	public override float PPower()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018763CE69h\"");
				if (num == -1f / 0f)
				{
					return -3.4028235E+38f + bonusStats;
				}
				goto IL_00e7;
			}
		}
		num = 3.4028235E+38f;
		goto IL_00e7;
		IL_00e7:
		return num + bonusStats;
	}

	public override void AfterFullInitialization()
	{
		//IL_00a3: Expected O, but got I4
		base.AfterFullInitialization();
		_followers = 0;
		Extensions.Shuffle(possibleFollowers);
		List<CharacterType> list = new List<CharacterType>();
		list._002Ector();
		currentFollowers = list;
		Action<float, float> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
		Delegate obj = Delegate.Combine(base._onHpRecoveryCallback, b);
		bool flag = (object)obj == null;
		int num = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			int num2 = default(int);
			bool flag2 = num2 == 0;
			num = num2;
			if (flag2)
			{
				throw new InvalidCastException();
			}
		}
		base._onHpRecoveryCallback = (Action<float, float>)num;
		_canOverheal = true;
	}

	public override void LevelUp()
	{
		base.LevelUp();
		if (base._level == 2)
		{
			List<CharacterType> list = possibleFollowers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			if ((nint)0 > (nint)0)
			{
				AddRandomFollower();
			}
		}
		if (base._level == 12)
		{
			List<CharacterType> list2 = possibleFollowers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			if ((nint)0 > (nint)0)
			{
				AddRandomFollower();
			}
		}
		if (base._level == 22)
		{
			List<CharacterType> list3 = possibleFollowers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			if ((nint)0 > (nint)0)
			{
				AddRandomFollower();
			}
		}
		if (base._level == 32)
		{
			List<CharacterType> list4 = possibleFollowers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 189 Invalid \"Jump target not found in method: 0x18763D150\"");
			}
		}
	}

	private void AddRandomFollower()
	{
		//IL_004a: Expected O, but got I
		//IL_00a9: Expected O, but got I
		//IL_034f: Expected O, but got I4
		//IL_00f1: Expected O, but got I4
		//IL_015f: Expected I4, but got F4
		//IL_011b: Expected O, but got I8
		//IL_0135: Expected O, but got I8
		//IL_01c3: Expected O, but got I4
		//IL_0311: Expected O, but got I8
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_02da: Expected O, but got I4
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_02a7: Expected O, but got I4
		//IL_0274: Expected O, but got I4
		CharacterType characterType = Extensions.PickRnd(possibleFollowers);
		bool flag = ((List<System.Int32Enum>)(object)possibleFollowers).Remove((System.Int32Enum)characterType);
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)currentFollowers;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r9_v3 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r9_v3 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r9_v3 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v5+18]");
		if (num >= 0)
		{
			list.AddWithResize((System.Int32Enum)characterType);
			nint num2 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r9_v3 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
			nint num2 = 0;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.5f;
		soundConfig.Volume = (float?)(object)1;
		float num3 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num3);
		object obj3 = characterType - 300;
		if ((nint)obj3 <= 10)
		{
			object obj4 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rdx_v11+763D4F4+v369 @ rax_v13*4]");
			object obj5 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v296 @ rcx_v29 (should have been resolved before IL gen)");
		}
		int everyXLevels = default(int);
		bool spawnWithoutAuthority = default(bool);
		CharacterController characterController = GM.Core.AddFollower(characterType, this, AIType.Defensive, (byte)(int)num3 != 0, everyXLevels, spawnWithoutAuthority);
		if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		characterController._003CTrackedByCamera_003Ek__BackingField = false;
		characterController.SetPermanentInvulnerability(on: true);
		object obj6 = characterType - 307;
		characterController._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = false;
		bool flag2 = characterType == CharacterType.TP_FOLLOWER_CARDINAL;
		if (!flag2)
		{
			object obj7 = obj6 - 1;
			if (!flag2)
			{
				object obj8 = obj7 - 1;
				if (!flag2)
				{
					if ((nint)obj8 != 1)
					{
						goto IL_0377;
					}
					CharacterADControl deficiencyControl = characterController._deficiencyControl;
					deficiencyControl._currentType = AIType.AngleDistance;
					deficiencyControl._angleDistance = (float2)1070141403;
				}
				else
				{
					CharacterADControl deficiencyControl = characterController._deficiencyControl;
					deficiencyControl._currentType = AIType.AngleDistance;
					deficiencyControl._angleDistance = (float2)1078530011;
				}
			}
			else
			{
				CharacterADControl deficiencyControl = characterController._deficiencyControl;
				deficiencyControl._currentType = AIType.AngleDistance;
				deficiencyControl._angleDistance = (float2)0;
			}
		}
		else
		{
			CharacterADControl deficiencyControl = characterController._deficiencyControl;
			deficiencyControl._currentType = AIType.AngleDistance;
			deficiencyControl._angleDistance = (float2)3217625051L;
		}
		_ = 1065353216;
		goto IL_0377;
		IL_0377:
		int followers = _followers + 1;
		_followers = followers;
	}

	private unsafe void StatsUp(float value, float rawValue)
	{
		//IL_0092: Expected F4, but got I4
		//IL_0064: Invalid comparison between I4 and F4
		//IL_0287: Expected F4, but got I4
		//IL_0084: Expected F4, but got I4
		//IL_00dc: Expected O, but got Ref
		float num = rawValue - value;
		if (!(num < OverhealTriggerValue))
		{
			float num2 = bonusConst * num;
			float num3 = (overhealingTotal = num2 + overhealingTotal);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FD90");
			if (0f > num3)
			{
				num3 = 0f;
			}
			bonusStats = num3;
			float num4 = 0f;
		}
		else
		{
			float num4 = 0f;
		}
		if (!(num < OverhealTriggerValue2) && _canOverheal)
		{
			List<CharacterController> followers = GM.Core.GetFollowers(this);
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				CharacterController characterController = null;
				List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
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
		}
	}

	public TP_Maria_Character()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0263: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_028b: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_02b3: Expected O, but got I
		//IL_01c0: Expected O, but got I
		bonusConst = 0.001f;
		overhealingTotal = 1f;
		OverhealDelay = 5000f;
		OverhealTriggerValue = 1f;
		OverhealTriggerValue2 = 32f;
		List<CharacterType> list = new List<CharacterType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)307);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 307;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)309);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 309;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)308);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 308;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)310);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 310;
		}
		possibleFollowers = list;
		currentFollowers = new List<CharacterType>();
		base._002Ector();
	}

	private void _003CStatsUp_003Eb__15_0()
	{
		_canOverheal = true;
	}
}
