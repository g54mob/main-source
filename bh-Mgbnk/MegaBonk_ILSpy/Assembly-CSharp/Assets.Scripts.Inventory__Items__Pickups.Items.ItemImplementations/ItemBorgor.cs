using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;
using Utility;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBorgor : ItemBase
{
	public const int maxAmountAbsolute = 20;

	private const float maxSpawnDistance = 35f;

	private float baseChance = 0.02f;

	private float chancePerAmount = 0.01f;

	private float ratioHeal = 0.08f;

	private int flatHealPerAmount = 2;

	private int flatHeal = 10;

	private float chance;

	protected override void OnInitOrAmountChanged()
	{
		//IL_0010: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected I4, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		object obj = amount - 1;
		object obj2 = flatHealPerAmount * amount;
		int num = obj2 + 8;
		flatHeal = num;
		object obj3 = obj * chancePerAmount;
		float num2 = (float)obj3 + baseChance;
		chance = num2;
	}

	private unsafe void OnEnemyDied(Enemy enemy, DamageContainer deathSource)
	{
		//IL_00e0: Expected O, but got Ref
		double num = MyRandom.random.NextDouble();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		if ((nint)MyRandom.random > 0)
		{
			return;
		}
		EnemyMovementRb enemyMovement = enemy.enemyMovement;
		if (35f > enemyMovement.distanceToTarget)
		{
			PoolManager instance = PoolManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002620");
			UnityEngine.Object obj = default(UnityEngine.Object);
			if (obj != null)
			{
				Transform transform = ((GameObject)obj).transform;
				Transform transform2 = enemy.transform;
				Vector3 position = transform2.position;
				object obj2 = default(object);
				transform.position = (Vector3)(&obj2);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1815336B0");
				GameObject gameObject = default(GameObject);
				gameObject.SetActive(value: true);
				Borgar component = ((GameObject)obj).GetComponent<Borgar>();
				component.Set(flatHeal, ratioHeal);
			}
		}
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, DamageContainer> b = OnEnemyDied;
		Delegate obj = Delegate.Combine(Enemy.A_EnemyDied, b);
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		if (action != null)
		{
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, DamageContainer> value = OnEnemyDied;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyDied, value);
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		if (action != null)
		{
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public static int GetMaxAmount()
	{
		return 20;
	}

	public ItemBorgor(ItemInventory itemInventoryRef)
		: base(itemInventoryRef)
	{
	}

	public override void Tick()
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
		float num = baseChance * 100f;
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
