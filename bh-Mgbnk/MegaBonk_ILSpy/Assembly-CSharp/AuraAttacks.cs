using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class AuraAttacks : MonoBehaviour
{
	private Dictionary<EWeapon, ConstantAttack> auras;

	public AegisAttack aegisAttack;

	private void Awake()
	{
		//IL_039e: Expected I, but got O
		//IL_03af: Expected O, but got I4
		//IL_03b8: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_012e: Expected I, but got O
		//IL_013f: Expected O, but got I4
		//IL_0148: Expected O, but got I4
		//IL_0186: Expected I, but got O
		//IL_0197: Expected O, but got I4
		//IL_01a0: Expected O, but got I4
		//IL_022d: Expected I, but got O
		//IL_023e: Expected O, but got I4
		//IL_0247: Expected O, but got I4
		//IL_0285: Expected I, but got O
		//IL_0296: Expected O, but got I4
		//IL_029f: Expected O, but got I4
		//IL_0304: Expected I, but got O
		//IL_0315: Expected O, but got I4
		//IL_031e: Expected O, but got I4
		//IL_035c: Expected I, but got O
		//IL_036d: Expected O, but got I4
		//IL_0376: Expected O, but got I4
		Action<WeaponBase> b = OnWeaponAdded;
		Delegate obj = Delegate.Combine(WeaponInventory.A_WeaponAdded, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			WeaponInventory.A_WeaponAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<WeaponBase> action = default(Action<WeaponBase>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<WeaponBase>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0470;
			}
			WeaponInventory.A_WeaponAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<WeaponBase>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_03e5;
			}
		}
		Action<WeaponBase> b2 = OnWeaponRemoved;
		Delegate obj6 = Delegate.Combine(WeaponInventory.A_WeaponRemoved, b2);
		if ((object)obj6 == null)
		{
			WeaponInventory.A_WeaponRemoved = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<WeaponBase> action2 = default(Action<WeaponBase>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<WeaponBase>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_03f0;
			}
			WeaponInventory.A_WeaponRemoved = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<WeaponBase>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_0400;
			}
		}
		Action<WeaponBase> b3 = OnWeaponToggle;
		Delegate obj8 = Delegate.Combine(WeaponInventory.A_WeaponToggled, b3);
		if ((object)obj8 == null)
		{
			WeaponInventory.A_WeaponToggled = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<WeaponBase> action3 = default(Action<WeaponBase>);
			bool flag4 = action3 == null;
			num = (nint)typeof(Action<WeaponBase>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = 0;
			if (flag4)
			{
				goto IL_0410;
			}
			WeaponInventory.A_WeaponToggled = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num = (nint)typeof(Action<WeaponBase>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = 0;
			if (flag5)
			{
				goto IL_0428;
			}
		}
		Action<PlayerInventory> b4 = OnInventoryInitialized;
		Delegate obj10 = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b4);
		if ((object)obj10 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerInventory> action4 = default(Action<PlayerInventory>);
		bool flag6 = action4 == null;
		num = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj10;
		obj3 = 0;
		obj4 = 0;
		if (flag6)
		{
			goto IL_0460;
		}
		MyPlayer.A_PlayerInventoryInitialized = action4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj11 = default(object);
		bool flag7 = obj11 == null;
		num = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj10;
		obj3 = 0;
		obj4 = 0;
		if (!flag7)
		{
			return;
		}
		goto IL_0470;
		IL_0410:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0400;
		IL_0428:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0410;
		IL_0400:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03f0;
		IL_0460:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0428;
		IL_03e5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03f0:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03e5;
		IL_0470:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0460;
	}

	private void OnDestroy()
	{
		//IL_039e: Expected I, but got O
		//IL_03af: Expected O, but got I4
		//IL_03b8: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_00a1: Expected O, but got I4
		//IL_012e: Expected I, but got O
		//IL_013f: Expected O, but got I4
		//IL_0148: Expected O, but got I4
		//IL_0186: Expected I, but got O
		//IL_0197: Expected O, but got I4
		//IL_01a0: Expected O, but got I4
		//IL_022d: Expected I, but got O
		//IL_023e: Expected O, but got I4
		//IL_0247: Expected O, but got I4
		//IL_0285: Expected I, but got O
		//IL_0296: Expected O, but got I4
		//IL_029f: Expected O, but got I4
		//IL_0304: Expected I, but got O
		//IL_0315: Expected O, but got I4
		//IL_031e: Expected O, but got I4
		//IL_035c: Expected I, but got O
		//IL_036d: Expected O, but got I4
		//IL_0376: Expected O, but got I4
		Action<WeaponBase> value = OnWeaponAdded;
		Delegate obj = Delegate.Remove(WeaponInventory.A_WeaponAdded, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			WeaponInventory.A_WeaponAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<WeaponBase> action = default(Action<WeaponBase>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<WeaponBase>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0470;
			}
			WeaponInventory.A_WeaponAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<WeaponBase>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_03e5;
			}
		}
		Action<WeaponBase> value2 = OnWeaponRemoved;
		Delegate obj6 = Delegate.Remove(WeaponInventory.A_WeaponRemoved, value2);
		if ((object)obj6 == null)
		{
			WeaponInventory.A_WeaponRemoved = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<WeaponBase> action2 = default(Action<WeaponBase>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<WeaponBase>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_03f0;
			}
			WeaponInventory.A_WeaponRemoved = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<WeaponBase>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_0400;
			}
		}
		Action<WeaponBase> value3 = OnWeaponToggle;
		Delegate obj8 = Delegate.Remove(WeaponInventory.A_WeaponToggled, value3);
		if ((object)obj8 == null)
		{
			WeaponInventory.A_WeaponToggled = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<WeaponBase> action3 = default(Action<WeaponBase>);
			bool flag4 = action3 == null;
			num = (nint)typeof(Action<WeaponBase>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = 0;
			if (flag4)
			{
				goto IL_0410;
			}
			WeaponInventory.A_WeaponToggled = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num = (nint)typeof(Action<WeaponBase>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = 0;
			if (flag5)
			{
				goto IL_0428;
			}
		}
		Action<PlayerInventory> value4 = OnInventoryInitialized;
		Delegate obj10 = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value4);
		if ((object)obj10 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerInventory> action4 = default(Action<PlayerInventory>);
		bool flag6 = action4 == null;
		num = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj10;
		obj3 = 0;
		obj4 = 0;
		if (flag6)
		{
			goto IL_0460;
		}
		MyPlayer.A_PlayerInventoryInitialized = action4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj11 = default(object);
		bool flag7 = obj11 == null;
		num = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj10;
		obj3 = 0;
		obj4 = 0;
		if (!flag7)
		{
			return;
		}
		goto IL_0470;
		IL_0410:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0400;
		IL_0428:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0410;
		IL_0400:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03f0;
		IL_0460:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0428;
		IL_03e5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03f0:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03e5;
		IL_0470:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0460;
	}

	private void OnInventoryInitialized(PlayerInventory inventory)
	{
		Refresh();
	}

	private void Start()
	{
		Refresh();
		Transform transform = base.transform;
		transform.parentInternal = null;
	}

	private void Refresh()
	{
		if (!(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		if (instance.inventory != null)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			WeaponInventory weaponInventory = inventory.weaponInventory;
			Dictionary<EWeapon, WeaponBase>.ValueCollection values = weaponInventory.weapons.Values;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
			Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator enumerator = default(Dictionary<EWeapon, WeaponBase>.ValueCollection.Enumerator);
			WeaponBase weaponBase = default(WeaponBase);
			while (enumerator.MoveNext())
			{
				OnWeaponAdded(weaponBase);
			}
			enumerator.Dispose();
		}
	}

	private unsafe void OnWeaponAdded(WeaponBase weaponBase)
	{
		//IL_00f7: Expected O, but got Ref
		MyPlayer instance = MyPlayer.Instance;
		if (instance.inventory == null)
		{
			return;
		}
		WeaponData weaponData = weaponBase.weaponData;
		if (weaponData.isAura && !((Dictionary<System.Int32Enum, object>)(object)auras).ContainsKey((System.Int32Enum)weaponData.eWeapon))
		{
			WeaponData weaponData2 = weaponBase.weaponData;
			GameObject gameObject = UnityEngine.Object.Instantiate(weaponData2.attack);
			Transform transform = gameObject.transform;
			MyPlayer instance2 = MyPlayer.Instance;
			transform.parentInternal = instance2.feet;
			Transform transform2 = gameObject.transform;
			float num = default(float);
			transform2.localPosition = (Vector3)(&num);
			ConstantAttack component = gameObject.GetComponent<ConstantAttack>();
			WeaponData weaponData3 = weaponBase.weaponData;
			((Dictionary<System.Int32Enum, object>)(object)auras).Add((System.Int32Enum)weaponData3.eWeapon, (object)component);
			component.Set(weaponBase);
			WeaponData weaponData4 = weaponBase.weaponData;
			if (weaponData4.eWeapon == EWeapon.Aegis)
			{
				AegisAttack component2 = gameObject.GetComponent<AegisAttack>();
				aegisAttack = component2;
			}
		}
	}

	private void OnWeaponRemoved(WeaponBase weaponBase)
	{
		WeaponData weaponData = weaponBase.weaponData;
		if (((Dictionary<System.Int32Enum, object>)(object)auras).ContainsKey((System.Int32Enum)weaponData.eWeapon))
		{
			WeaponData weaponData2 = weaponBase.weaponData;
			object obj = ((Dictionary<System.Int32Enum, object>)(object)auras).get_Item((System.Int32Enum)weaponData2.eWeapon);
			GameObject obj2 = ((Component)obj).gameObject;
			UnityEngine.Object.Destroy(obj2);
			WeaponData weaponData3 = weaponBase.weaponData;
			bool flag = ((Dictionary<System.Int32Enum, object>)(object)auras).Remove((System.Int32Enum)weaponData3.eWeapon);
		}
	}

	private void OnWeaponToggle(WeaponBase weaponBase)
	{
		if (!weaponBase._003Cenabled_003Ek__BackingField)
		{
			WeaponData weaponData = weaponBase.weaponData;
			if (((Dictionary<System.Int32Enum, object>)(object)auras).ContainsKey((System.Int32Enum)weaponData.eWeapon))
			{
				WeaponData weaponData2 = weaponBase.weaponData;
				object obj = ((Dictionary<System.Int32Enum, object>)(object)auras).get_Item((System.Int32Enum)weaponData2.eWeapon);
				GameObject obj2 = ((Component)obj).gameObject;
				UnityEngine.Object.Destroy(obj2);
				WeaponData weaponData3 = weaponBase.weaponData;
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)auras).Remove((System.Int32Enum)weaponData3.eWeapon);
			}
		}
		else
		{
			OnWeaponAdded(weaponBase);
		}
	}

	private unsafe void Update()
	{
		//IL_0054: Expected O, but got Ref
		//IL_006a: Expected I, but got O
		//IL_00c0: Expected O, but got I
		//IL_00df: Expected O, but got I
		//IL_0102: Expected O, but got I
		//IL_0162: Expected O, but got Ref
		//IL_0266: Expected I, but got O
		//IL_01af: Expected O, but got Ref
		//IL_01b4: Expected I, but got O
		Dictionary<EWeapon, ConstantAttack>.ValueCollection values = auras.Values;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
		nint num = 0;
		Dictionary<EWeapon, ConstantAttack>.ValueCollection.Enumerator enumerator = default(Dictionary<EWeapon, ConstantAttack>.ValueCollection.Enumerator);
		Component component = default(Component);
		object obj = default(object);
		float num3 = default(float);
		Dictionary<EWeapon, ConstantAttack>.ValueCollection.Enumerator enumerator3 = default(Dictionary<EWeapon, ConstantAttack>.ValueCollection.Enumerator);
		float num6 = default(float);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = (object)component == null;
				Dictionary<EWeapon, ConstantAttack>.ValueCollection.Enumerator enumerator2 = (Dictionary<EWeapon, ConstantAttack>.ValueCollection.Enumerator)(&enumerator);
				if (!flag)
				{
					nint num2 = (nint)component;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v300 @ rax_v13 (Il2CppClass<UnityEngine.Component>)+1B8] (should have been resolved before IL gen)");
					if (obj == null)
					{
						enumerator2 = (Dictionary<EWeapon, ConstantAttack>.ValueCollection.Enumerator)MyPlayer.Instance;
						if ((object)MyPlayer.Instance == null)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v8 (System.Collections.Generic.Dictionary`2<EWeapon, Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>+ValueCollection<EWeapon, Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>+Enumerator<EWeapon,…");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v8 (System.Collections.Generic.Dictionary`2<EWeapon, Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>+ValueCollection<EWeapon, Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>+Enumerator<EWeapon,…");
						enumerator2 = (Dictionary<EWeapon, ConstantAttack>.ValueCollection.Enumerator)0;
						if (flag2)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v8 (System.Collections.Generic.Dictionary`2<EWeapon, Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>+ValueCollection<EWeapon, Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>+Enumerator<EWeapon,…");
						Transform transform = ((Component)0).transform;
						bool flag3 = (object)transform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v8 (System.Collections.Generic.Dictionary`2<EWeapon, Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>+ValueCollection<EWeapon, Assets.Scripts.Game.Combat.ConstantAttacks.ConstantAttack>+Enumerator<EWeapon,…");
						enumerator2 = (Dictionary<EWeapon, ConstantAttack>.ValueCollection.Enumerator)0;
						if (flag3)
						{
							throw new NullReferenceException();
						}
						Vector3 up = transform.up;
						Transform transform2 = component.transform;
						bool flag4 = (object)transform2 == null;
						enumerator2 = (Dictionary<EWeapon, ConstantAttack>.ValueCollection.Enumerator)component;
						if (flag4)
						{
							break;
						}
						transform2.up = (Vector3)(&num3);
						Transform transform3 = component.transform;
						nint num4 = (nint)component;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v488 @ rax_v34 (Il2CppClass<UnityEngine.Component>)+1A8] (should have been resolved before IL gen)");
						float num5 = MyTime.time * 20f;
						float angle = num5 * (float)enumerator3;
						transform3.Rotate((Vector3)(&num6), angle, Space.World);
						num = unchecked((nint)null);
					}
					continue;
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	public AuraAttacks()
	{
		Dictionary<EWeapon, ConstantAttack> dictionary = new Dictionary<EWeapon, ConstantAttack>();
		auras = dictionary;
		base._002Ector();
	}
}
