using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemIdleJuice : ItemBase
{
	private float damagePerAmount = 1f;

	private float maxDamage;

	private float damagePerSecond = 0.04f;

	private Vector3 campfirePos;

	private float setupTime = 0.6f;

	private float distThreshold = 1.75f;

	private float startCampfireTime;

	private bool isCampActive;

	private float currentDamage;

	private float nextUpdateDamageTime;

	private float updateDamageInterval = 1f;

	protected override void OnInitOrAmountChanged()
	{
		float num = (float)amount * damagePerAmount;
		maxDamage = num;
	}

	public override void Tick()
	{
		//IL_024d: Expected I, but got O
		//IL_00b7: Expected F8, but got I4
		//IL_012e: Expected O, but got F4
		//IL_01b2: Expected O, but got F4
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		nint num = (nint)typeof(Math);
		float num2 = (float)campfirePos - position.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemIdleJuice)+40]");
		float num3 = 0f - position.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemIdleJuice)+44]");
		float num4 = 0f - position.z;
		float num5 = num3 * num3;
		float num6 = num2 * num2;
		float num7 = num4 * num4;
		float num8 = num5 + num6;
		float num9 = num8 + num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rcx_v7 (Il2CppClass<System.Math>)+E4]");
		double num10;
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			num10 = 0.0;
		}
		else
		{
			num10 = Math.Sqrt(num9);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
		if (num10 > (double)distThreshold)
		{
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 position2 = transform2.position;
			campfirePos = (Vector3)position2.x;
			_ = position2.z;
			bool flag = !isCampActive;
			float num11 = MyTime.time + setupTime;
			startCampfireTime = num11;
			if (flag)
			{
				goto IL_0319;
			}
			isCampActive = false;
			StatModifier statModifier = new StatModifier();
			statModifier.modifyType = EStatModifyType.Flat;
			statModifier.stat = EStat.DamageMultiplier;
			SetStat(statModifier);
			currentDamage = 0f;
		}
		if (!isCampActive)
		{
			goto IL_0319;
		}
		goto IL_03f5;
		IL_03f5:
		if (isCampActive && maxDamage > currentDamage && MyTime.time > nextUpdateDamageTime)
		{
			float num12 = currentDamage + damagePerSecond;
			float num13 = MyTime.time + updateDamageInterval;
			nextUpdateDamageTime = num13;
			currentDamage = num12;
			if (num12 > maxDamage)
			{
				currentDamage = maxDamage;
			}
			StatModifier statModifier2 = new StatModifier();
			statModifier2.modification = currentDamage;
			statModifier2.modifyType = EStatModifyType.Flat;
			statModifier2.stat = EStat.DamageMultiplier;
			SetStat(statModifier2);
		}
		return;
		IL_0319:
		if (MyTime.time > startCampfireTime)
		{
			currentDamage = 0f;
			Transform transform3 = MyPlayer.Instance.transform;
			Vector3 position3 = transform3.position;
			campfirePos = (Vector3)position3.x;
			_ = position3.z;
			float num14 = MyTime.time + setupTime;
			isCampActive = true;
			startCampfireTime = num14;
		}
		goto IL_03f5;
	}

	private void CreateCamp()
	{
		//IL_0034: Expected O, but got F4
		currentDamage = 0f;
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		campfirePos = (Vector3)position.x;
		_ = position.z;
		float num = MyTime.time + setupTime;
		isCampActive = true;
		startCampfireTime = num;
	}

	private void RemoveCamp()
	{
		isCampActive = false;
		StatModifier statModifier = new StatModifier();
		statModifier.modifyType = EStatModifyType.Flat;
		statModifier.stat = EStat.DamageMultiplier;
		SetStat(statModifier);
		currentDamage = 0f;
	}

	public ItemIdleJuice(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
	}

	public override bool HasOnHitEffectProc()
	{
		return false;
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_0095: Expected O, but got I4
		//IL_00b9: Expected I, but got O
		//IL_00d2: Expected O, but got I
		//IL_00ff: Expected O, but got I
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		float num = damagePerAmount * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj = default(object);
		string text = $"+{obj}%";
		bool flag = dictionary == null;
		object obj2 = null;
		object obj3 = obj;
		string text2 = "+{0}%";
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)text);
			object[] array = new object[1];
			bool flag2 = array == null;
			nint num2 = 0;
			obj2 = text;
			obj3 = 1;
			text2 = (string)(object)typeof(object[]);
			if (!flag2)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v10 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text);
				object obj4 = default(object);
				bool flag3 = obj4 == null;
				num2 = 0;
				obj2 = text;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v10 (Il2CppClass<System.Object[]>)+40]");
				obj3 = 0;
				text2 = (string)(object)dictionary;
				if (flag3)
				{
					((Dictionary<string, object>)(object)text2).Add((string)obj3, obj2);
					object obj5 = default(object);
					throw obj5;
				}
				if (array.Length <= 0)
				{
					return (string)(object)new IndexOutOfRangeException();
				}
				text2 = (string)(array + 32);
				array[0] = dictionary;
				bool flag4 = localizedString == null;
				num2 = 0;
				obj2 = text;
				obj3 = dictionary;
				if (!flag4)
				{
					return localizedString.GetLocalizedString(array);
				}
			}
		}
		throw new NullReferenceException();
	}
}
