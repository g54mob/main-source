using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;

public class PassiveAbilityFloating : PassiveAbility
{
	private float floatingDamagePerLevel = 0.01f;

	private float lastSetDamage;

	private float updateDamageAtTime;

	private float updateDamageCooldown = 0.5f;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public unsafe override void Tick()
	{
		//IL_0141: Expected F4, but got I4
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_017a: Invalid comparison between O and F4
		//IL_00e0: Expected O, but got Ref
		if (!(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		if (instance.playerInput.IsHoldingJump())
		{
			MyPlayer instance2 = MyPlayer.Instance;
			if (instance2.playerMovement.CanFloat())
			{
				MyPlayer instance3 = MyPlayer.Instance;
				PlayerMovement playerMovement = instance3.playerMovement;
				Vector3 velocity = playerMovement.rb.velocity;
				MyPlayer instance4 = MyPlayer.Instance;
				PlayerMovement playerMovement2 = instance4.playerMovement;
				float num = default(float);
				playerMovement2.rb.velocity = (Vector3)(&num);
			}
		}
		MyPlayer instance5 = MyPlayer.Instance;
		float num2;
		if (instance5.playerMovement.IsTouchingGround())
		{
			num2 = 0f;
		}
		else
		{
			MyPlayer instance6 = MyPlayer.Instance;
			int characterLevel = instance6.inventory.GetCharacterLevel();
			num2 = (float)characterLevel * floatingDamagePerLevel;
		}
		if (!(MyTime.time < updateDamageAtTime))
		{
			float num3 = MyTime.time + updateDamageCooldown;
			updateDamageAtTime = num3;
			float num4 = num2 - lastSetDamage;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj = num4 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.005f))
			{
				StatModifier statModifier = new StatModifier();
				statModifier.modification = num2;
				statModifier.modifyType = EStatModifyType.Flat;
				statModifier.stat = EStat.DamageMultiplier;
				SetStat(statModifier);
				lastSetDamage = num2;
			}
		}
	}

	public override EPassive GetPassiveType()
	{
		return EPassive.Float;
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_01ff: Expected O, but got I
		//IL_00be: Expected O, but got I4
		//IL_00cc: Expected I, but got O
		//IL_00e2: Expected I, but got O
		//IL_00fb: Expected O, but got I
		//IL_0123: Expected O, but got I
		//IL_012b: Expected I, but got O
		//IL_0230: Expected O, but got I
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected I, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.DamageMultiplier);
		if (text == null)
		{
			text = "";
		}
		bool flag = dictionary == null;
		IntPtr intPtr = default(IntPtr);
		object obj = (nint)intPtr;
		object obj2 = "stat1";
		nint num = 12;
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num2 = floatingDamagePerLevel * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text2 = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)text2);
			object[] array = new object[1];
			bool flag2 = array == null;
			obj = text2;
			obj2 = 1;
			num = (nint)typeof(object[]);
			if (!flag2)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v12 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text2);
				object obj3 = default(object);
				bool flag3 = obj3 == null;
				obj = text2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v12 (Il2CppClass<System.Object[]>)+40]");
				obj2 = 0;
				num = (nint)dictionary;
				if (flag3)
				{
					((Dictionary<string, object>)num).Add((string)obj2, obj);
					object obj4 = default(object);
					throw obj4;
				}
				if (array.Length <= 0)
				{
					return (string)(object)new IndexOutOfRangeException();
				}
				num = (nint)(array + 32);
				array[0] = dictionary;
				bool flag4 = localizedString == null;
				obj = text2;
				obj2 = dictionary;
				if (!flag4)
				{
					return localizedString.GetLocalizedString(array);
				}
			}
		}
		throw new NullReferenceException();
	}
}
