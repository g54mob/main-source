using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;
using Cpp2ILInjected;
using UnityEngine;

public class ZapBar : MonoBehaviour
{
	public GameObject zapIcon;

	public GameObject zapBar;

	public Transform barFill;

	private PassiveAbilityZooma zapAbility;

	private void Start()
	{
		//IL_0012: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		PlayerInventory instance = (PlayerInventory)(object)MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			instance = (PlayerInventory)instance.banishesUsed;
			if (instance.banishesUsed != 0)
			{
				if (!((PlayerInventory)instance.banishesUsed).HasPassive(EPassive.Zap))
				{
					return;
				}
				bool flag = (object)zapIcon == null;
				instance = (PlayerInventory)(object)zapIcon;
				if (!flag)
				{
					zapIcon.SetActive(value: true);
					bool flag2 = (object)zapBar == null;
					instance = (PlayerInventory)(object)zapBar;
					if (!flag2)
					{
						zapBar.SetActive(value: true);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void FixedUpdate()
	{
		//IL_0026: Expected O, but got Ref
		//IL_0086: Expected I, but got O
		//IL_008e: Expected I, but got O
		//IL_009e: Expected O, but got I
		//IL_00da: Expected O, but got I
		//IL_00ff: Expected O, but got I4
		//IL_01f5: Expected I, but got O
		//IL_01fd: Expected I, but got O
		//IL_020d: Expected O, but got I
		//IL_0139: Expected O, but got I
		//IL_015e: Expected O, but got I4
		if (zapAbility != null)
		{
			Transform transform = barFill.transform;
			object obj = default(object);
			transform.localScale = (Vector3)(&obj);
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		PassiveAbilityZooma passiveAbility = (PassiveAbilityZooma)inventory.passiveAbility;
		if (inventory.passiveAbility == null)
		{
			zapAbility = null;
			return;
		}
		nint num = (nint)typeof(PassiveAbilityZooma);
		nint num2 = (nint)passiveAbility;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ r10_v1 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations.PassiveAbilityZooma>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r11_v1 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations.PassiveAbilityZooma>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ r10_v1 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations.PassiveAbilityZooma>)+130]");
		PassiveAbilityZooma passiveAbilityZooma;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ r11_v1 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations.PassiveAbilityZooma>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rax_v18+FFFFFFF8+v203 @ rax_v7*8]");
			bool flag = 0 == (nint)typeof(PassiveAbilityZooma);
			passiveAbilityZooma = (PassiveAbilityZooma)1;
			if (flag)
			{
				goto IL_01a3;
			}
		}
		passiveAbilityZooma = null;
		goto IL_01a3;
		IL_01a3:
		bool flag2 = passiveAbilityZooma == null;
		PassiveAbilityZooma passiveAbilityZooma2 = null;
		if (!flag2)
		{
			passiveAbilityZooma2 = (PassiveAbilityZooma)inventory.passiveAbility;
		}
		PassiveAbilityZooma passiveAbilityZooma3;
		do
		{
			zapAbility = passiveAbilityZooma2;
			nint num4 = (nint)typeof(PassiveAbilityZooma);
			nint num5 = (nint)passiveAbility;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r10_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations.PassiveAbilityZooma>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r11_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations.PassiveAbilityZooma>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r10_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations.PassiveAbilityZooma>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r11_v2 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations.PassiveAbilityZooma>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rax_v15+FFFFFFF8+v267 @ rax_v11*8]");
				bool flag3 = 0 == (nint)typeof(PassiveAbilityZooma);
				passiveAbilityZooma3 = (PassiveAbilityZooma)1;
				if (flag3)
				{
					continue;
				}
			}
			passiveAbilityZooma3 = null;
		}
		while (passiveAbilityZooma3 != null);
	}
}
