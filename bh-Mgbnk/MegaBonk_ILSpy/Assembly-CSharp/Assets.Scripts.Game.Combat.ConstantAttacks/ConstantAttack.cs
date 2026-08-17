using System;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.ConstantAttacks;

public abstract class ConstantAttack : MonoBehaviour
{
	public WeaponBase weaponBase;

	public void Set(WeaponBase weaponBase)
	{
		this.weaponBase = weaponBase;
		Init();
	}

	protected void Awake()
	{
		//IL_0255: Expected I, but got O
		//IL_000a: Expected I, but got O
		//IL_020b: Expected I, but got O
		//IL_0214: Expected O, but got I4
		//IL_021d: Expected O, but got I4
		//IL_00bc: Expected I, but got O
		//IL_00c5: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_0104: Expected I, but got O
		//IL_0171: Expected I, but got O
		//IL_017a: Expected O, but got I4
		//IL_0183: Expected O, but got I4
		//IL_01c9: Expected I, but got O
		//IL_01d2: Expected O, but got I4
		//IL_01db: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r8_v5 (Il2CppClass<Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>)+1A0]");
		Action<EStat> action = new Action<EStat>(this, (IntPtr)0);
		bool flag = (object)this == null;
		nint num = (nint)PlayerStatsNew.A_StatUpdate;
		Action<EStat> action2 = action;
		if (flag)
		{
			goto IL_026b;
		}
		nint num2 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r8_v5 (Il2CppClass<Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>)+1A0]");
		action._002Ector((object)this, (IntPtr)0);
		Delegate obj = Delegate.Combine(PlayerStatsNew.A_StatUpdate, action);
		object obj2;
		object obj3;
		if ((object)obj == null)
		{
			PlayerStatsNew.A_StatUpdate = (Action<EStat>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStat> action3 = default(Action<EStat>);
			if (action3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EStat>);
				obj2 = 0;
				obj3 = 0;
				action2 = (Action<EStat>)obj;
				goto IL_026b;
			}
			PlayerStatsNew.A_StatUpdate = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj4 = default(object);
			bool flag2 = obj4 == null;
			num = (nint)typeof(Action<EStat>);
			obj2 = 0;
			obj3 = 0;
			action2 = (Action<EStat>)obj;
			if (flag2)
			{
				goto IL_0277;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ r8_v8 (Il2CppClass<Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>)+190]");
		Action<EStat, EWeapon> b = new Action<EStat, EWeapon>(this, (IntPtr)0);
		nint num3 = (nint)this;
		Delegate obj5 = Delegate.Combine(WeaponBase.A_WeaponStatUpdate, b);
		if ((object)obj5 == null)
		{
			WeaponBase.A_WeaponStatUpdate = (Action<EStat, EWeapon>)obj5;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EStat, EWeapon> action4 = default(Action<EStat, EWeapon>);
		bool flag3 = action4 == null;
		num = (nint)typeof(Action<EStat, EWeapon>);
		obj2 = 0;
		obj3 = 0;
		action2 = (Action<EStat>)obj5;
		if (!flag3)
		{
			WeaponBase.A_WeaponStatUpdate = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj6 = default(object);
			bool flag4 = obj6 == null;
			num = (nint)typeof(Action<EStat, EWeapon>);
			obj2 = 0;
			obj3 = 0;
			action2 = (Action<EStat>)obj5;
			if (!flag4)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0277;
		IL_0277:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_026b:
		throw new NullReferenceException();
	}

	protected void OnDestroy()
	{
		//IL_0255: Expected I, but got O
		//IL_000a: Expected I, but got O
		//IL_020b: Expected I, but got O
		//IL_0214: Expected O, but got I4
		//IL_021d: Expected O, but got I4
		//IL_00bc: Expected I, but got O
		//IL_00c5: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_0104: Expected I, but got O
		//IL_0171: Expected I, but got O
		//IL_017a: Expected O, but got I4
		//IL_0183: Expected O, but got I4
		//IL_01c9: Expected I, but got O
		//IL_01d2: Expected O, but got I4
		//IL_01db: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r8_v5 (Il2CppClass<Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>)+1A0]");
		Action<EStat> action = new Action<EStat>(this, (IntPtr)0);
		bool flag = (object)this == null;
		nint num = (nint)PlayerStatsNew.A_StatUpdate;
		Action<EStat> action2 = action;
		if (flag)
		{
			goto IL_026b;
		}
		nint num2 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ r8_v5 (Il2CppClass<Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>)+1A0]");
		action._002Ector((object)this, (IntPtr)0);
		Delegate obj = Delegate.Remove(PlayerStatsNew.A_StatUpdate, action);
		object obj2;
		object obj3;
		if ((object)obj == null)
		{
			PlayerStatsNew.A_StatUpdate = (Action<EStat>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStat> action3 = default(Action<EStat>);
			if (action3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EStat>);
				obj2 = 0;
				obj3 = 0;
				action2 = (Action<EStat>)obj;
				goto IL_026b;
			}
			PlayerStatsNew.A_StatUpdate = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj4 = default(object);
			bool flag2 = obj4 == null;
			num = (nint)typeof(Action<EStat>);
			obj2 = 0;
			obj3 = 0;
			action2 = (Action<EStat>)obj;
			if (flag2)
			{
				goto IL_0277;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ r8_v8 (Il2CppClass<Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>)+190]");
		Action<EStat, EWeapon> value = new Action<EStat, EWeapon>(this, (IntPtr)0);
		nint num3 = (nint)this;
		Delegate obj5 = Delegate.Remove(WeaponBase.A_WeaponStatUpdate, value);
		if ((object)obj5 == null)
		{
			WeaponBase.A_WeaponStatUpdate = (Action<EStat, EWeapon>)obj5;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EStat, EWeapon> action4 = default(Action<EStat, EWeapon>);
		bool flag3 = action4 == null;
		num = (nint)typeof(Action<EStat, EWeapon>);
		obj2 = 0;
		obj3 = 0;
		action2 = (Action<EStat>)obj5;
		if (!flag3)
		{
			WeaponBase.A_WeaponStatUpdate = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj6 = default(object);
			bool flag4 = obj6 == null;
			num = (nint)typeof(Action<EStat, EWeapon>);
			obj2 = 0;
			obj3 = 0;
			action2 = (Action<EStat>)obj5;
			if (!flag4)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0277;
		IL_0277:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_026b:
		throw new NullReferenceException();
	}

	protected abstract void Init();

	protected abstract void OnWeaponStatUpdate(EStat stat, EWeapon weapon);

	protected abstract void OnStatUpdate(EStat stat);

	public abstract float GetAuraRotationSpeed();

	public virtual bool IsManualRotation()
	{
		return false;
	}
}
