using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Characters;

public class TP_Soma_Character : TP_Character
{
	private bool _isDarkLord;

	private TP_SoulSteal_Weapon soulStealWeapon;

	private int blueSouls;

	private int redSouls;

	private int yellowSouls;

	private int blueBonusIndex;

	private int blueExtraStacks;

	private int redBonusIndex;

	private int redExtraStacks;

	private int yellowBonusIndex;

	private int yellowExtraStacks;

	public override bool DrainWeaponsImmunity => true;

	protected virtual int[] bonusTresholds => new int[3] { 1000, 2000, 3000 };

	public override void AfterFullInitialization()
	{
		//IL_0050: Expected I, but got O
		//IL_005e: Expected I, but got O
		//IL_006e: Expected O, but got I
		//IL_00ee: Expected O, but got I4
		//IL_00aa: Expected O, but got I
		//IL_00e0: Expected O, but got I4
		base.AfterFullInitialization();
		((CharacterController)this)._isLastBreathEnabled = true;
		GameManager core = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.TP_SOULSTEAL_WEAPON, this, removeFromStore: true, allowDuplicates);
		bool flag = (object)weapon == null;
		Weapon weapon2 = null;
		if (flag)
		{
			goto IL_01b1;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(TP_SoulSteal_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SoulSteal_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SoulSteal_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rax_v31+FFFFFFF8+v148 @ rax_v27*8]");
			if (0 == (nint)typeof(TP_SoulSteal_Weapon))
			{
				obj3 = 1;
				goto IL_01c0;
			}
		}
		obj3 = 0;
		goto IL_01c0;
		IL_01b1:
		soulStealWeapon = (TP_SoulSteal_Weapon)weapon2;
		TP_SoulSteal_Weapon tP_SoulSteal_Weapon = soulStealWeapon;
		if ((object)soulStealWeapon != null)
		{
			tP_SoulSteal_Weapon._isManualFire = true;
			if (((Weapon)tP_SoulSteal_Weapon)._firingTimer != null)
			{
				((Weapon)tP_SoulSteal_Weapon)._firingTimer.Cancel();
			}
		}
		Action onLastBreath = SoulSteal;
		((CharacterController)this)._onLastBreath = onLastBreath;
		return;
		IL_01c0:
		bool flag2 = obj3 == null;
		weapon2 = null;
		if (!flag2)
		{
			weapon2 = weapon;
		}
		goto IL_01b1;
	}

	protected override void OnStop()
	{
		if (!_isDarkLord)
		{
			base.OnStop();
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		CharacterData currentCharacterData = _currentCharacterData;
		if (currentCharacterData._003CcurrentSkin_003Ek__BackingField == SkinType.SKIN_TP_SOMA_DARKLORD)
		{
			Action<GameplaySignals.EnemyKilledImmediateSignal> action = null;
			((TP_Soma_Character)(object)action).OnEnemyKilled((GameplaySignals.EnemyKilledImmediateSignal)this);
			((TP_Soma_Character)(object)_signalBus).OnEnemyKilled((GameplaySignals.EnemyKilledImmediateSignal)action);
			_isDarkLord = true;
		}
	}

	public override void OnQuit()
	{
		//IL_0039: Expected O, but got I4
		//IL_0039: Expected O, but got I
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		base.OnQuit();
		if (_signalBus != null)
		{
			Action<GameplaySignals.EnemyKilledImmediateSignal> action = null;
			((TP_Soma_Character)(object)action).OnEnemyKilled((GameplaySignals.EnemyKilledImmediateSignal)this);
			((TP_Soma_Character)0).OnEnemyKilled((GameplaySignals.EnemyKilledImmediateSignal)1);
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool throwIfMissing = default(bool);
			_signalBus.UnsubscribeInternal(signalType, (object)null, (object)action, throwIfMissing);
		}
	}

	public void OnEnemyKilled(GameplaySignals.EnemyKilledImmediateSignal signal)
	{
		//IL_01cc: Expected O, but got F4
		//IL_01d5: Invalid comparison between F4 and O
		//IL_00ab: Expected I, but got O
		//IL_00b9: Expected I, but got O
		//IL_00c9: Expected O, but got I
		//IL_0149: Expected O, but got I4
		//IL_0105: Expected O, but got I
		//IL_013b: Expected O, but got I4
		if ((object)signal == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [signal @ rdx (VampireSurvivors.Signals.GameplaySignals+EnemyKilledImmediateSignal)+10]");
		if ((nint)0 == 0)
		{
			return;
		}
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.2f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			return;
		}
		float2 float5 = ((ArcadeSprite)signal).position;
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool shouldCallValidatePickups = default(bool);
		bool isRemote = default(bool);
		Pickup pickup = GM.Core.MakePickup(pos, ItemType.TP_ENEMYSOUL, WeaponType.VOID, value, relicType, shouldCallValidatePickups, isRemote, onlineSynchronization: false);
		bool flag = (object)pickup == null;
		Pickup_TP_EnemySoul pickup_TP_EnemySoul = null;
		object obj5;
		if (!flag)
		{
			nint num = (nint)pickup;
			nint num2 = (nint)typeof(Pickup_TP_EnemySoul);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Items.Pickup_TP_EnemySoul>)+130]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Items.Pickup_TP_EnemySoul>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rax_v34+FFFFFFF8+v374 @ rax_v30*8]");
				if (0 == (nint)typeof(Pickup_TP_EnemySoul))
				{
					obj5 = 1;
					goto IL_01f1;
				}
			}
			obj5 = 0;
			goto IL_01f1;
		}
		goto IL_0218;
		IL_01f1:
		bool flag2 = obj5 == null;
		pickup_TP_EnemySoul = null;
		if (!flag2)
		{
			pickup_TP_EnemySoul = (Pickup_TP_EnemySoul)pickup;
		}
		goto IL_0218;
		IL_0218:
		if ((object)pickup_TP_EnemySoul != null && ((UnityEngine.Object)pickup_TP_EnemySoul).m_CachedPtr != (IntPtr)0)
		{
			pickup_TP_EnemySoul.StartSpiralToPlayer(this);
		}
	}

	public void SoulSteal()
	{
		base.IsInvul = true;
		if (3.0000002f > ((CharacterController)this)._invincibilityTimer)
		{
			((CharacterController)this)._invincibilityTimer = 3.0000002f;
		}
		if ((object)soulStealWeapon != null)
		{
			soulStealWeapon.Fire();
		}
	}

	public override void OnAttackAnim(Weapon.FiringAnimation firingAnimation)
	{
		//IL_006f: Expected I, but got O
		if (firingAnimation == Weapon.FiringAnimation.Bazooka && _currentAnimation != CharAnimationType.special)
		{
			((CharacterController)this)._isAnimForced = true;
			_currentAnimation = CharAnimationType.special;
			_spriteAnimation.SetAnimation("special");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Characters.TP_Soma_Character>)+6D0]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.3f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	public override void ClearFromSpecialAnims()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5EA7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		((CharacterController)this)._isAnimForced = false;
		if (!_hasIdleAnimation)
		{
			_spriteAnimation.SetAnimation("walk");
			_currentAnimation = CharAnimationType.walk;
		}
		else
		{
			_spriteAnimation.SetAnimation("idle");
			_currentAnimation = CharAnimationType.idle;
		}
	}

	protected unsafe bool UpdateSoulsCount(ref int total, ref int bonusIndex, ref int extraStacks)
	{
		//IL_001f: Expected O, but got I4
		//IL_019a: Expected I4, but got O
		//IL_005b: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_013f: Expected O, but got I4
		int[] array = bonusTresholds;
		object obj = array.Length - 1;
		if ((nint)obj < array.Length)
		{
			object obj2 = extraStacks * array[obj];
			int[] array2 = bonusTresholds;
			object obj3;
			if (bonusIndex >= array2.Length)
			{
				int[] array3 = bonusTresholds;
				obj3 = array3.Length - 1;
			}
			else
			{
				obj3 = bonusIndex;
			}
			int[] array4 = bonusTresholds;
			if ((nint)obj3 < array4.Length)
			{
				object obj4 = array4[obj3] + obj2;
				if (total < (nint)obj4)
				{
					return false;
				}
				object obj5 = bonusIndex + 1;
				ref int reference = ref *(int*)obj5;
				int[] array5 = bonusTresholds;
				if ((nint)obj5 >= array5.Length)
				{
					ref int reference2 = ref *(int*)(extraStacks + 1);
				}
				return true;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	public unsafe void SoulCollected(int soulType)
	{
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected Ref, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected Ref, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected Ref, but got Unknown
		//IL_002b: Expected O, but got I4
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected Ref, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected Ref, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected Ref, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected Ref, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected Ref, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected Ref, but got Unknown
		bool flag = soulType == 0;
		if (!flag)
		{
			object obj = soulType - 1;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5EAA]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				int num = redSouls + 1;
				redSouls = num;
				if (UpdateSoulsCount(ref *(int*)(this + 1060), ref *(int*)(this + 1076), ref *(int*)(this + 1080)))
				{
					QueueWeaponSelectionSelector(WeaponType.CANDYBOX, "normal");
				}
				return;
			}
			if ((nint)obj == 1)
			{
				int num2 = yellowSouls + 1;
				yellowSouls = num2;
				if (UpdateSoulsCount(ref *(int*)(this + 1064), ref *(int*)(this + 1084), ref *(int*)(this + 1088)))
				{
					GameManager core = GM.Core;
					core._003CGoldFingerManager_003Ek__BackingField.ActivateGoldFinger(this);
				}
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5EA9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int num3 = blueSouls + 1;
		blueSouls = num3;
		if (UpdateSoulsCount(ref *(int*)(this + 1056), ref *(int*)(this + 1068), ref *(int*)(this + 1072)))
		{
			QueueWeaponSelectionSelector(WeaponType.ARMADIO, "passive");
		}
	}

	private unsafe void UpdateBlue()
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Ref, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Ref, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5EA9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int num = blueSouls + 1;
		blueSouls = num;
		if (UpdateSoulsCount(ref *(int*)(this + 1056), ref *(int*)(this + 1068), ref *(int*)(this + 1072)))
		{
			QueueWeaponSelectionSelector(WeaponType.ARMADIO, "passive");
		}
	}

	private unsafe void UpdateRed()
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Ref, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Ref, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5EAA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int num = redSouls + 1;
		redSouls = num;
		if (UpdateSoulsCount(ref *(int*)(this + 1060), ref *(int*)(this + 1076), ref *(int*)(this + 1080)))
		{
			QueueWeaponSelectionSelector(WeaponType.CANDYBOX, "normal");
		}
	}

	private unsafe void UpdateYellow()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Ref, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Ref, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Ref, but got Unknown
		int num = yellowSouls + 1;
		yellowSouls = num;
		if (UpdateSoulsCount(ref *(int*)(this + 1064), ref *(int*)(this + 1084), ref *(int*)(this + 1088)))
		{
			GameManager core = GM.Core;
			core._003CGoldFingerManager_003Ek__BackingField.ActivateGoldFinger(this);
		}
	}
}
