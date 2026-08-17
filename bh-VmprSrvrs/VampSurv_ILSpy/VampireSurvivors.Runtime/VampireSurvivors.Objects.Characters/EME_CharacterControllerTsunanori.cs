using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerTsunanori : EME_CharacterControllerShowstopper
{
	private WeaponType[] standardPassives = new WeaponType[15]
	{
		WeaponType.POWER,
		WeaponType.AREA,
		WeaponType.SPEED,
		WeaponType.COOLDOWN,
		WeaponType.DURATION,
		WeaponType.AMOUNT,
		WeaponType.MAXHEALTH,
		WeaponType.ARMOR,
		WeaponType.MOVESPEED,
		WeaponType.MAGNET,
		WeaponType.GROWTH,
		WeaponType.LUCK,
		WeaponType.GREED,
		WeaponType.REVIVAL,
		WeaponType.REGEN
	};

	private CharacterType[] kugutsuTypes = new CharacterType[4]
	{
		CharacterType.EME_PUPKATANA_FOLLOWER,
		CharacterType.EME_PUPKNIFE_FOLLOWER,
		CharacterType.EME_PUPGUN_FOLLOWER,
		CharacterType.EME_PUPPUNCH_FOLLOWER
	};

	private WeaponType[] kugutsuWeaponBackup = new WeaponType[4]
	{
		WeaponType.EME_RAPIER1,
		WeaponType.GARLIC,
		WeaponType.EME_RAPIER1,
		WeaponType.GUNS
	};

	private int[] kugutsuLevels = new int[4] { 20, 40, 60, 80 };

	private int kugutsuIndex;

	private List<CharacterType> currentFollowers = new List<CharacterType>();

	private bool _summonAllies = true;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		CharacterData currentCharacterData = _currentCharacterData;
		if (currentCharacterData._003CcurrentSkin_003Ek__BackingField == SkinType.SKIN_EME_SOLO_DUAL || currentCharacterData._003CcurrentSkin_003Ek__BackingField == SkinType.SKIN_EME_SOLO_FLEURET)
		{
			_summonAllies = false;
		}
	}

	public override void LevelUp()
	{
		base.LevelUp();
		if (!_summonAllies)
		{
			return;
		}
		if (((CharacterController)this)._level >= 20)
		{
			List<CharacterType> list = currentFollowers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			if ((nint)0 == 0)
			{
				MakeKugutsu(kugutsuIndex);
				int num = kugutsuIndex + 1;
				kugutsuIndex = num;
			}
		}
		if (((CharacterController)this)._level >= 40)
		{
			List<CharacterType> list2 = currentFollowers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			if ((nint)0 == 1)
			{
				MakeKugutsu(kugutsuIndex);
				int num2 = kugutsuIndex + 1;
				kugutsuIndex = num2;
			}
		}
		if (((CharacterController)this)._level >= 60)
		{
			List<CharacterType> list3 = currentFollowers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			if ((nint)0 == 2)
			{
				MakeKugutsu(kugutsuIndex);
				int num3 = kugutsuIndex + 1;
				kugutsuIndex = num3;
			}
		}
		if (((CharacterController)this)._level >= 80)
		{
			List<CharacterType> list4 = currentFollowers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			if ((nint)0 == 3)
			{
				MakeKugutsu(kugutsuIndex);
				int num4 = kugutsuIndex + 1;
				kugutsuIndex = num4;
			}
		}
	}

	private unsafe void MakeKugutsu(int index)
	{
		//IL_004b: Expected O, but got I
		//IL_005b: Expected O, but got I
		//IL_00bd: Expected O, but got I
		//IL_02e9: Expected O, but got I
		//IL_0272: Expected O, but got I4
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_023f: Expected O, but got I8
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		//IL_0208: Expected O, but got I4
		//IL_01d5: Expected O, but got I4
		CharacterType[] array = kugutsuTypes;
		int num = index % array.Length;
		List<System.Int32Enum> list = (List<System.Int32Enum>)(object)currentFollowers;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r8_v4+18]");
		if (num2 >= 0)
		{
			list.AddWithResize((System.Int32Enum)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[num]));
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rcx_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj3 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ r8_v1 (VampireSurvivors.Data.CharacterType[])+20+v56 @ rdx_v3 (System.Int32)*4]");
			_ = 0;
		}
		bool manualLevelups = default(bool);
		int everyXLevels = default(int);
		bool spawnWithoutAuthority = default(bool);
		CharacterController characterController = GM.Core.AddFollower((CharacterType)(int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref array[num]), this, AIType.Defensive, manualLevelups, everyXLevels, spawnWithoutAuthority);
		if ((object)characterController == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		characterController._003CTrackedByCamera_003Ek__BackingField = false;
		characterController._permanentInvulnerability = false;
		characterController.IsInvul = false;
		characterController._invincibilityTimer = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ r8_v1 (VampireSurvivors.Data.CharacterType[])+20+v56 @ rdx_v3 (System.Int32)*4]");
		object obj4 = -144;
		characterController._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = false;
		int maxWeaponCount = ((CharacterController)this)._maxWeaponBonus + ((CharacterController)this)._maxWeaponCount;
		characterController._maxWeaponCount = maxWeaponCount;
		characterController.IsFollowerSharingPassives = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ r8_v1 (VampireSurvivors.Data.CharacterType[])+20+v56 @ rdx_v3 (System.Int32)*4]");
		bool flag = (nint)0 == 144;
		if (!flag)
		{
			object obj5 = obj4 - 1;
			if (!flag)
			{
				object obj6 = obj5 - 1;
				if (!flag)
				{
					if ((nint)obj6 != 1)
					{
						return;
					}
					CharacterADControl deficiencyControl = characterController._deficiencyControl;
					deficiencyControl._currentType = AIType.AngleDistanceMirrorInput;
					deficiencyControl._angleDistance = (float2)0;
				}
				else
				{
					CharacterADControl deficiencyControl = characterController._deficiencyControl;
					deficiencyControl._currentType = AIType.AngleDistanceMirrorInput;
					deficiencyControl._angleDistance = (float2)1078530011;
				}
			}
			else
			{
				CharacterADControl deficiencyControl = characterController._deficiencyControl;
				deficiencyControl._currentType = AIType.AngleDistanceMirrorInput;
				deficiencyControl._angleDistance = (float2)3217625051L;
			}
		}
		else
		{
			CharacterADControl deficiencyControl = characterController._deficiencyControl;
			deficiencyControl._currentType = AIType.AngleDistanceMirrorInput;
			deficiencyControl._angleDistance = (float2)1070141403;
		}
		_ = 1056964608;
	}

	public EME_CharacterControllerTsunanori()
	{
		base._morphDuration = 13000f;
		((CharacterController)this)._002Ector();
	}
}
