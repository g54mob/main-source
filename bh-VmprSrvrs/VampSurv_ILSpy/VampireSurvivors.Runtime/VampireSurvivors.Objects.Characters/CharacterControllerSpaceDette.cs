using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerSpaceDette : CharacterController
{
	private Phaser2Weapon StartingWeapon;

	private float _baseWeaponPower;

	private int _nextTreshold;

	private int _extraFollowersAmount;

	private int _maxFollowers;

	private int[] _thresholds;

	private int _finalThreshold;

	private List<CharacterType> possibleFollowers;

	private List<CharacterType> currentFollowers;

	public override void AfterFullInitialization()
	{
		//IL_004b: Expected I, but got O
		//IL_0059: Expected I, but got O
		//IL_0069: Expected O, but got I
		//IL_00e9: Expected O, but got I4
		//IL_00a5: Expected O, but got I
		//IL_00db: Expected O, but got I4
		base.AfterFullInitialization();
		Weapon weaponByType = base._weaponsManager.GetWeaponByType(WeaponType.PHASER2);
		bool flag = (object)weaponByType == null;
		Weapon startingWeapon = weaponByType;
		if (flag)
		{
			goto IL_0182;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(Phaser2Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Phaser2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Phaser2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v30+FFFFFFF8+v131 @ rax_v25*8]");
			if (0 == (nint)typeof(Phaser2Weapon))
			{
				obj3 = 1;
				goto IL_0191;
			}
		}
		obj3 = 0;
		goto IL_0191;
		IL_0182:
		StartingWeapon = (Phaser2Weapon)startingWeapon;
		Phaser2Weapon startingWeapon2 = StartingWeapon;
		if ((object)StartingWeapon != null && ((UnityEngine.Object)startingWeapon2).m_CachedPtr != (IntPtr)0)
		{
			Phaser2Weapon startingWeapon3 = StartingWeapon;
			WeaponData currentWeaponData = ((Weapon)startingWeapon3)._currentWeaponData;
			currentWeaponData._003Cpower_003Ek__BackingField = _baseWeaponPower;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 275 Invalid \"Jump target not found in method: 0x1875C0290\"");
		throw new NullReferenceException();
		IL_0191:
		bool flag2 = obj3 == null;
		startingWeapon = null;
		if (!flag2)
		{
			startingWeapon = weaponByType;
		}
		goto IL_0182;
	}

	private void CalculateTreshold()
	{
		//IL_0015: Expected O, but got I
		List<CharacterType> list = currentFollowers;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		object obj = 0;
		int[] thresholds = _thresholds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 < (nint)thresholds.Length)
		{
			_nextTreshold = thresholds[obj];
			return;
		}
		int nextTreshold = ++_extraFollowersAmount * _finalThreshold;
		_nextTreshold = nextTreshold;
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		List<CharacterType> list = currentFollowers;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 < (nint)_maxFollowers)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if (config._003CRunEnemies_003Ek__BackingField > _nextTreshold)
			{
				AddRandomFollower();
				CalculateTreshold();
			}
		}
	}

	public override void LevelUp()
	{
		base.LevelUp();
		Phaser2Weapon startingWeapon = StartingWeapon;
		if ((object)StartingWeapon == null || ((UnityEngine.Object)startingWeapon).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Phaser2Weapon startingWeapon2 = StartingWeapon;
		float num = (float)base._level * 0.1f;
		float num2 = num + _baseWeaponPower;
		LimitBreakData accumulatedLimitBreaks = startingWeapon2.accumulatedLimitBreaks;
		if ((object)accumulatedLimitBreaks._003Cpower_003Ek__BackingField != null)
		{
			Phaser2Weapon startingWeapon3 = StartingWeapon;
			LimitBreakData accumulatedLimitBreaks2 = startingWeapon3.accumulatedLimitBreaks;
			if ((object)accumulatedLimitBreaks2._003Cpower_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			object obj = default(object);
			num2 += (float)obj;
		}
		Phaser2Weapon startingWeapon4 = StartingWeapon;
		WeaponData currentWeaponData = ((Weapon)startingWeapon4)._currentWeaponData;
		currentWeaponData._003Cpower_003Ek__BackingField = num2;
	}

	private void AddRandomFollower()
	{
		//IL_0028: Expected O, but got I
		//IL_0081: Expected O, but got I
		//IL_020d: Expected O, but got I4
		//IL_0233: Expected O, but got I4
		//IL_0161: Expected I4, but got F4
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		CharacterType characterType = Extensions.PickRnd(possibleFollowers);
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)currentFollowers;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v1 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v1 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v1 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v6+18]");
		if (num >= 0)
		{
			list.AddWithResize((System.Int32Enum)characterType);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ r9_v1 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.5f;
		float num2 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num2);
		object obj3 = UnityEngine.Random.RandomRangeInt(0, 4);
		bool flag = obj3 == null;
		AIType aiType;
		if (!flag)
		{
			object obj4 = obj3 - 1;
			if (flag)
			{
				goto IL_0118;
			}
			object obj5 = obj4 - 1;
			aiType = AIType.MirrorInput;
			if (!flag)
			{
				if ((nint)obj5 != 1)
				{
					goto IL_0118;
				}
				aiType = AIType.DelayedPositionCopy;
			}
		}
		else
		{
			aiType = AIType.Aggressive;
		}
		goto IL_0142;
		IL_0142:
		int everyXLevels = default(int);
		bool spawnWithoutAuthority = default(bool);
		CharacterController characterController = GM.Core.AddFollower(characterType, this, aiType, (byte)(int)num2 != 0, everyXLevels, spawnWithoutAuthority);
		if ((object)characterController != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			characterController._003CTrackedByCamera_003Ek__BackingField = false;
			characterController.IsFollowerSharingPassives = false;
			characterController.SetPermanentInvulnerability(on: true);
			characterController._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = false;
		}
		return;
		IL_0118:
		aiType = AIType.Defensive;
		goto IL_0142;
	}

	public CharacterControllerSpaceDette()
	{
		//IL_0042: Expected O, but got I
		//IL_009c: Expected O, but got I
		//IL_01a4: Expected O, but got I
		//IL_0106: Expected O, but got I
		_baseWeaponPower = 0.1f;
		_maxFollowers = 30;
		_thresholds = new int[12]
		{
			100, 250, 500, 1000, 2000, 3000, 4000, 5000, 6000, 7000,
			8000, 9000
		};
		_finalThreshold = 10000;
		List<CharacterType> list = new List<CharacterType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v7+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)162);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 162;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v9+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)161);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 161;
		}
		possibleFollowers = list;
		currentFollowers = new List<CharacterType>();
		base._002Ector();
	}
}
