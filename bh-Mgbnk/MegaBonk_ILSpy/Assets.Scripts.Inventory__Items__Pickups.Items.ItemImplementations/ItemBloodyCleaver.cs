using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemBloodyCleaver : ItemBase
{
	private int bloodmarkStacksPerLifestealPerAmount = 1;

	private int bloodmarkStacksPerLifesteal;

	private float bloodmarkChancePerAmount = 0.5f;

	private float totalBloodmarkChance;

	private static string damageSource;

	private DamageContainer dc;

	private Dictionary<Enemy, int> lifestealProcTracker;

	protected override void OnInitOrAmountChanged()
	{
		int num = bloodmarkStacksPerLifestealPerAmount * amount;
		bloodmarkStacksPerLifesteal = num;
		float num2 = (float)amount * bloodmarkChancePerAmount;
		totalBloodmarkChance = num2;
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, int> b = OnLifestealProc;
		Delegate obj = Delegate.Combine(PlayerHealth.A_LifestealProc, b);
		if ((object)obj == null)
		{
			PlayerHealth.A_LifestealProc = (Action<Enemy, int>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, int> action = default(Action<Enemy, int>);
		if (action != null)
		{
			PlayerHealth.A_LifestealProc = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, int>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, int>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, int> value = OnLifestealProc;
		Delegate obj = Delegate.Remove(PlayerHealth.A_LifestealProc, value);
		if ((object)obj == null)
		{
			PlayerHealth.A_LifestealProc = (Action<Enemy, int>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, int> action = default(Action<Enemy, int>);
		if (action != null)
		{
			PlayerHealth.A_LifestealProc = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, int>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, int>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_003c: Invalid comparison between F4 and I4
		//IL_004e: Expected F8, but got I4
		//IL_0138: Invalid comparison between F8 and I4
		//IL_0093: Expected F8, but got I4
		if (!ItemUtility.TryProc(dc.procCoefficient, totalBloodmarkChance))
		{
			return;
		}
		bool flag = !(bloodmarkChancePerAmount > 0f);
		double num = 0.0;
		if (!flag)
		{
			double num2 = Math.Floor(totalBloodmarkChance);
			num = num2;
		}
		float baseProcChance = totalBloodmarkChance - (float)num;
		bool flag2 = ItemUtility.TryProc(dc.procCoefficient, baseProcChance);
		double num3 = num + 1.0;
		if (!flag2)
		{
			num3 = num;
		}
		if (num3 > 0.0)
		{
			double num4 = 0.0;
			int stacks = default(int);
			do
			{
				dc.enemy.AddDebuff(EDebuff.Bloodmark, dc, 5f, stacks);
				num4++;
			}
			while (num4 < num3);
		}
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	private void OnLifestealProc(Enemy enemy, int lifestealAmount)
	{
		if (lifestealAmount > 0 && !enemy.IsDeadOrDyingNextFrame())
		{
			int num = (lifestealProcTracker.TryGetValue(enemy, out var value) ? value : 0);
			int value2 = num + lifestealAmount;
			((Dictionary<object, int>)(object)lifestealProcTracker).set_Item((object)enemy, value2);
		}
	}

	public override void Tick()
	{
		if (lifestealProcTracker != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
			Dictionary<Enemy, int>.Enumerator enumerator = default(Dictionary<Enemy, int>.Enumerator);
			Enemy enemy = default(Enemy);
			int stacks = default(int);
			while (enumerator.MoveNext())
			{
				if ((object)enemy != null)
				{
					enemy.AddDebuff(EDebuff.Bloodmark, dc, 4f, stacks);
					continue;
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			if (lifestealProcTracker != null)
			{
				lifestealProcTracker.Clear();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public ItemBloodyCleaver(ItemInventory itemInventoryRef)
	{
		DamageContainer damageContainer = new DamageContainer(0f, damageSource);
		dc = damageContainer;
		lifestealProcTracker = new Dictionary<Enemy, int>();
		base._002Ector(itemInventoryRef);
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	protected unsafe override Dictionary<string, object> GetLocalizationKeys()
	{
		//IL_0098: Expected O, but got Ref
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.Lifesteal);
		if (text == null)
		{
			text = "";
		}
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num = bloodmarkChancePerAmount * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			object obj = default(object);
			string key = ((Enum)(&obj)).ToString();
			string text2 = LocalizationUtility.GetLocalizedString("DamageSources", key);
			if (text2 == null)
			{
				text2 = "";
			}
			((Dictionary<object, object>)(object)dictionary).Add((object)"bloodmark", (object)text2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}

	unsafe static ItemBloodyCleaver()
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		damageSource = text;
	}
}
