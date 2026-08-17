using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons;

public class LEM_Banana2_Weapon : LEM_Banana1_Weapon
{
	private const float BonusCritChanceMultiplier = 2f;

	private const float HiddenWeaponFireChance = 0.001f;

	private LEM_Banana2_Hidden_Weapon _hiddenWeapon;

	private bool _totalDamageCalculated;

	public override bool DespawnOnExplode => false;

	protected override void OnStart()
	{
		//IL_004f: Expected I, but got O
		//IL_005d: Expected I, but got O
		//IL_006d: Expected O, but got I
		//IL_00ed: Expected O, but got I4
		//IL_00a9: Expected O, but got I
		//IL_00df: Expected O, but got I4
		base.OnStart();
		GameManager core = GM.Core;
		Weapon weapon = core._weaponsFacade.CreateDetachedWeapon(WeaponType.LEM_BANANA2_HIDDEN, ((Equipment)this)._003COwner_003Ek__BackingField);
		bool flag = (object)weapon == null;
		Weapon hiddenWeapon = weapon;
		if (flag)
		{
			goto IL_0114;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(LEM_Banana2_Hidden_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Banana2_Hidden_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Banana2_Hidden_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v20+FFFFFFF8+v121 @ rax_v15*8]");
			if (0 == (nint)typeof(LEM_Banana2_Hidden_Weapon))
			{
				obj3 = 1;
				goto IL_0123;
			}
		}
		obj3 = 0;
		goto IL_0123;
		IL_0114:
		_hiddenWeapon = (LEM_Banana2_Hidden_Weapon)hiddenWeapon;
		return;
		IL_0123:
		bool flag2 = obj3 == null;
		hiddenWeapon = null;
		if (!flag2)
		{
			hiddenWeapon = weapon;
		}
		goto IL_0114;
	}

	public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
	{
		((Weapon)this).InitWeapon(characterController, weaponType);
		((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
		AddOuterSaboteur();
		Action<GameplaySignals.WeaponAddedToCharacterSignal> action = null;
		((LEM_Banana2_Weapon)(object)action).AddCritChanceBonusToWeapon((GameplaySignals.WeaponAddedToCharacterSignal)this);
		((LEM_Banana2_Weapon)(object)_signalBus).AddCritChanceBonusToWeapon((GameplaySignals.WeaponAddedToCharacterSignal)action);
		AddCritChanceBonusToActiveWeapons();
		AddInnerSaboteur();
	}

	private void AddCritChanceBonusToWeapon(GameplaySignals.WeaponAddedToCharacterSignal sig)
	{
		if (sig.Weapon != ((Equipment)this)._equipmentType)
		{
			WeaponData data = sig.Data;
			float num = data._003CcritChance_003Ek__BackingField + data._003CcritChance_003Ek__BackingField;
			data._003CcritChance_003Ek__BackingField = num;
		}
	}

	private unsafe void AddCritChanceBonusToActiveWeapons()
	{
		//IL_0069: Expected O, but got I4
		//IL_0071: Expected O, but got Ref
		CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
		{
			List<object> list = new List<object>(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField);
			List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
			if (enumerator.MoveNext())
			{
				List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)0;
				List<Equipment>.Enumerator enumerator3 = (List<Equipment>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_005d: Expected O, but got I
		//IL_0091: Invalid comparison between F4 and I
		base.Fire(skipTriggers);
		List<float> critChancesArray = _critChancesArray;
		int critIndex = _critIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)critIndex % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			object obj2 = default(object);
			float num3 = (float)obj2 * 0.001f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v7+20+v51 @ rdx_v5 (System.Int32)*4]");
			if (num3 > 0f)
			{
				_hiddenWeapon.Fire();
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void CheckForFiringHiddenWeapon()
	{
		//IL_0053: Expected O, but got I
		//IL_0087: Invalid comparison between F4 and I
		List<float> critChancesArray = _critChancesArray;
		int critIndex = _critIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)critIndex % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			object obj2 = default(object);
			float num3 = (float)obj2 * 0.001f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v7+20+v51 @ rdx_v5 (System.Int32)*4]");
			if (num3 > 0f)
			{
				_hiddenWeapon.Fire();
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void FireHiddenWeapon()
	{
		_hiddenWeapon.Fire();
	}

	public override float CalculateTotalDamage()
	{
		if (!_totalDamageCalculated)
		{
			LEM_Banana2_Hidden_Weapon hiddenWeapon = _hiddenWeapon;
			float num = ((Weapon)hiddenWeapon)._003CStatsInflictedDamage_003Ek__BackingField + ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
			_totalDamageCalculated = true;
			((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField = num;
		}
		return ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
	}

	public override void Cleanup()
	{
		Action<GameplaySignals.WeaponAddedToCharacterSignal> action = null;
		((LEM_Banana2_Weapon)(object)action).AddCritChanceBonusToWeapon((GameplaySignals.WeaponAddedToCharacterSignal)this);
		((LEM_Banana2_Weapon)(object)_signalBus).AddCritChanceBonusToWeapon((GameplaySignals.WeaponAddedToCharacterSignal)action);
		_hiddenWeapon.Cleanup();
		base.Cleanup();
	}
}
