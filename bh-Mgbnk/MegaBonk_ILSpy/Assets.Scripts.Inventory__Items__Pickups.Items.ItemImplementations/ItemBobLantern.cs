using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBobLantern : ItemBase
{
	private float cooldownMin = 5f;

	private float cooldownMax = 45f;

	private float cooldownReductionPerAmount = 3f;

	private float cooldown;

	private float nextExplodeTime;

	private float radius;

	private float radiusMin = 50f;

	private float radiusMax = 250f;

	private float radiusPerAmount = 10f;

	private GameObject explosionPrefab;

	protected override void OnInitOrAmountChanged()
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		float num = cooldownMin;
		object obj = amount * cooldownReductionPerAmount;
		float num2 = cooldownMax - (float)obj;
		if (!(cooldownMin > num2))
		{
			num = cooldownMax;
			if (!(num2 > cooldownMax))
			{
				num = num2;
			}
		}
		cooldown = num;
		float num3 = MyTime.time + 2f;
		object obj2 = amount * radiusPerAmount;
		float num4 = (float)obj2 + radiusMin;
		nextExplodeTime = num3;
		float num5 = radiusMin;
		if (!(radiusMin > num4))
		{
			num5 = radiusMax;
			if (!(num4 > radiusMax))
			{
				num5 = num4;
			}
		}
		radius = num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 117 Invalid \"Jump target not found in method: 0x18043AEE0\"");
	}

	public override void Tick()
	{
		if (!(nextExplodeTime > MyTime.time))
		{
			Explode();
		}
	}

	private void RefreshExplosionSize()
	{
		if (explosionPrefab != null)
		{
			LanternExplosion component = explosionPrefab.GetComponent<LanternExplosion>();
			component.SetRadius(radius);
		}
	}

	private unsafe void Explode()
	{
		//IL_00d8: Expected O, but got Ref
		//IL_0071: Expected O, but got Ref
		float num = MyTime.time + cooldown;
		nextExplodeTime = num;
		if (explosionPrefab == null)
		{
			EffectManager instance = EffectManager.Instance;
			GameObject gameObject = UnityEngine.Object.Instantiate(instance.lanternExplosion);
			explosionPrefab = gameObject;
			KillEnemyTrigger component = explosionPrefab.GetComponent<KillEnemyTrigger>();
			IntPtr intPtr = default(IntPtr);
			string customDamageSource = ((Enum)(&intPtr)).ToString();
			component.customDamageSource = customDamageSource;
			RefreshExplosionSize();
		}
		Transform transform = explosionPrefab.transform;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 position = transform2.position;
		object obj = default(object);
		transform.position = (Vector3)(&obj);
		GameObject gameObject2 = explosionPrefab.gameObject;
		gameObject2.SetActive(value: true);
	}

	public ItemBobLantern(ItemInventory itemInventoryRef)
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
		//IL_0100: Expected O, but got I4
		//IL_0124: Expected I, but got O
		//IL_013d: Expected O, but got I
		//IL_016a: Expected O, but got I
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj = default(object);
		string value = $"{obj}";
		bool flag = dictionary == null;
		object obj2 = null;
		object obj3 = obj;
		string text = "{0}";
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value2 = $"{arg}";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string text2 = $"{arg2}";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value3", (object)text2);
			object[] array = new object[1];
			bool flag2 = array == null;
			nint num = 0;
			obj2 = text2;
			obj3 = 1;
			text = (string)(object)typeof(object[]);
			if (!flag2)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rdx_v16 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text2);
				object obj4 = default(object);
				bool flag3 = obj4 == null;
				num = 0;
				obj2 = text2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rdx_v16 (Il2CppClass<System.Object[]>)+40]");
				obj3 = 0;
				text = (string)(object)dictionary;
				if (flag3)
				{
					((Dictionary<string, object>)(object)text).Add((string)obj3, obj2);
					object obj5 = default(object);
					throw obj5;
				}
				if (array.Length <= 0)
				{
					return (string)(object)new IndexOutOfRangeException();
				}
				text = (string)(array + 32);
				array[0] = dictionary;
				bool flag4 = localizedString == null;
				num = 0;
				obj2 = text2;
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
