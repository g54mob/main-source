using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.UI.Player;

namespace VampireSurvivors.Objects.Characters;

public class TP_FakeTrio_Character : TP_Character
{
	private bool _spawnFollowersNextFrame;

	private SkinType mySkin;

	private CharacterController follower1;

	private CharacterController follower2;

	private bool _canRetaliate;

	private float RetaliationDelay;

	private float OverhealDelay;

	private float OverhealTriggerValue;

	private bool _canOverheal;

	private Timer _overHealTimer;

	private List<WeaponType> knives;

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_008e: Expected O, but got I
		//IL_01aa: Expected O, but got I
		//IL_00e8: Expected O, but got I
		//IL_0204: Expected O, but got I
		base.MakeLevelOne();
		CharacterData currentCharacterData = _currentCharacterData;
		mySkin = currentCharacterData._003CcurrentSkin_003Ek__BackingField;
		if (currentCharacterData._003CcurrentSkin_003Ek__BackingField == SkinType.DEFAULT)
		{
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			List<System.Int32Enum> list = (List<System.Int32Enum>)(object)arcanaManager._003CActiveArcanas_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v11+18]");
			if (num >= 0)
			{
				list.AddWithResize((System.Int32Enum)10);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				object obj2 = (nint)0 + (nint)1;
				_ = 10;
			}
			GameManager core2 = GM.Core;
			core2._arcanaManager.TriggerArcana(ArcanaType.T10_BEGINNING);
			GameManager core3 = GM.Core;
			ArcanaManager arcanaManager2 = core3._arcanaManager;
			int num2 = arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField + 1;
			arcanaManager2._003CMaxArcanasPerRun_003Ek__BackingField = num2;
		}
		if (mySkin == SkinType.SKIN_TP_FAKE_TRIO_SYPHA)
		{
			GameManager core4 = GM.Core;
			ArcanaManager arcanaManager3 = core4._arcanaManager;
			List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)arcanaManager3._003CActiveArcanas_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v6+18]");
			if (num3 >= 0)
			{
				list2.AddWithResize((System.Int32Enum)14);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				object obj4 = (nint)0 + (nint)1;
				_ = 14;
			}
			GameManager core5 = GM.Core;
			core5._arcanaManager.TriggerArcana(ArcanaType.T14_JEWELS);
			GameManager core6 = GM.Core;
			ArcanaManager arcanaManager4 = core6._arcanaManager;
			int num4 = arcanaManager4._003CMaxArcanasPerRun_003Ek__BackingField + 1;
			arcanaManager4._003CMaxArcanasPerRun_003Ek__BackingField = num4;
		}
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		_spawnFollowersNextFrame = true;
		if (mySkin != SkinType.SKIN_TP_FAKE_TRIO_GRANT)
		{
			return;
		}
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
		_canOverheal = true;
	}

	private void SpawnFollowers()
	{
		//IL_0200: Expected O, but got I4
		object obj = mySkin - 1085;
		bool flag = obj == null;
		bool flag2 = !flag;
		CharacterType characterType = (CharacterType)((flag2 ? 1 : 0) + 338);
		bool flag3 = mySkin == SkinType.SKIN_TP_FAKE_TRIO_GRANT;
		if (mySkin == SkinType.SKIN_TP_FAKE_TRIO_GRANT)
		{
			characterType = CharacterType.TP_FW_FAKE_SYPHA;
		}
		CharacterType characterType2 = CharacterType.TP_FW_FAKE_TREVOR;
		if (!flag3)
		{
			characterType2 = CharacterType.TP_FW_FAKE_GRANT;
		}
		bool manualLevelups = default(bool);
		int everyXLevels = default(int);
		bool spawnWithoutAuthority = default(bool);
		CharacterController characterController = GM.Core.AddFollower(characterType, this, AIType.Defensive, manualLevelups, everyXLevels, spawnWithoutAuthority);
		follower1 = characterController;
		CharacterController characterController2 = follower1;
		characterController2._003CTrackedByCamera_003Ek__BackingField = true;
		CharacterController characterController3 = follower1;
		characterController3._permanentInvulnerability = false;
		characterController3.IsInvul = false;
		characterController3._invincibilityTimer = 0f;
		CharacterController characterController4 = follower1;
		characterController4._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = false;
		CharacterController characterController5 = follower1;
		characterController5.IsFollowerSharingPassives = true;
		CharacterController characterController6 = follower1;
		int maxWeaponCount = ((CharacterController)this)._maxWeaponBonus + ((CharacterController)this)._maxWeaponCount;
		characterController6._maxWeaponCount = maxWeaponCount;
		CharacterController characterController7 = follower1;
		HealthBar healthBar = RenderingExtensions.SetScale(characterController7._healthBar, 0.00125f);
		CharacterController characterController8 = GM.Core.AddFollower(characterType2, this, AIType.Defensive, manualLevelups, everyXLevels, spawnWithoutAuthority);
		follower2 = characterController8;
		CharacterController characterController9 = follower2;
		characterController9._003CTrackedByCamera_003Ek__BackingField = true;
		CharacterController characterController10 = follower2;
		characterController10._permanentInvulnerability = false;
		characterController10.IsInvul = false;
		characterController10._invincibilityTimer = 0f;
		CharacterController characterController11 = follower2;
		characterController11._003CCountsAsMainCharacterForRevivals_003Ek__BackingField = false;
		CharacterController characterController12 = follower2;
		characterController12.IsFollowerSharingPassives = true;
		CharacterController characterController13 = follower2;
		int maxWeaponCount2 = ((CharacterController)this)._maxWeaponBonus + ((CharacterController)this)._maxWeaponCount;
		characterController13._maxWeaponCount = maxWeaponCount2;
		CharacterController characterController14 = follower2;
		HealthBar healthBar2 = RenderingExtensions.SetScale(characterController14._healthBar, 0.00125f);
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (_spawnFollowersNextFrame)
		{
			_spawnFollowersNextFrame = false;
			if (_coherenceSync.HasStateAuthority)
			{
				SpawnFollowers();
			}
		}
	}

	private void FireAllKnives()
	{
		//IL_0044: Expected O, but got I4
		CharacterWeaponsManager weaponsManager = ((CharacterController)this)._weaponsManager;
		Predicate<Equipment> match = delegate(Equipment x)
		{
			//IL_0067: Expected I4, but got O
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected I4, but got Unknown
			if ((object)x != null)
			{
				List<WeaponType> list2 = knives;
				if (knives != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj3 = default(object);
					object obj2 = obj3 >> 31;
					return (byte)(obj2 ^ 1) != 0;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		};
		List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField).FindAll((Predicate<object>)match);
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = 0;
		}
	}

	public override bool GetDamaged(float damageAmount)
	{
		//IL_00e0: Invalid comparison between F4 and I
		//IL_0088: Expected F4, but got I
		if (_canRetaliate && mySkin == SkinType.SKIN_TP_FAKE_TRIO_GRANT)
		{
			_canRetaliate = false;
			FireAllKnives();
			float num = base.PSpeed();
			float num2 = default(float);
			bool flag = !(1f < num2);
			float num3 = 1f;
			if (!flag)
			{
				num3 = num2;
			}
			float num4 = RetaliationDelay / num3;
			float num5 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10FB4]");
			if (num5 < 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10FB4]");
				num4 = 0f;
			}
			Action onComplete = delegate
			{
				_canRetaliate = true;
			};
			float duration = num4 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
		return base.GetDamaged(damageAmount);
	}

	private void OverhealTrigger(float value, float rawValue)
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
			FireAllKnives();
		}
	}

	public TP_FakeTrio_Character()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0383: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_03ab: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_03d3: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_03fb: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_0423: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_044b: Expected O, but got I
		//IL_02fe: Expected O, but got I
		_canRetaliate = true;
		RetaliationDelay = 2000f;
		OverhealDelay = 1000f;
		OverhealTriggerValue = 8f;
		_canOverheal = true;
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)7);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 7;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)8);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 8;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1423);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1423;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1424);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1424;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1615);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1615;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1616);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1616;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1606);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1606;
		}
		knives = list;
		((CharacterController)this)._002Ector();
	}

	private bool _003CFireAllKnives_003Eb__15_0(Equipment x)
	{
		//IL_0067: Expected I4, but got O
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected I4, but got Unknown
		if ((object)x != null)
		{
			List<WeaponType> list = knives;
			if (knives != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj2 = default(object);
				object obj = obj2 >> 31;
				return (byte)(obj ^ 1) != 0;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void _003CGetDamaged_003Eb__16_0()
	{
		_canRetaliate = true;
	}

	private void _003COverhealTrigger_003Eb__17_0()
	{
		_canOverheal = true;
	}
}
