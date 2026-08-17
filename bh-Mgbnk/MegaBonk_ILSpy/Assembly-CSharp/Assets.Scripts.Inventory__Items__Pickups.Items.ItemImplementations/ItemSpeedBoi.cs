using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemSpeedBoi(ItemInventory itemInventoryRef) : ItemBase(itemInventoryRef)
{
	private float damageMultiplierDuringFreeze = 2f;

	private float duration;

	private float durationPerAmount = 2f;

	private float normalCooldown = 10f;

	private float slowdownReadyAtTime;

	public static Action A_Slowdown;

	private float slowdownHpRatio = 0.5f;

	public override void Init()
	{
		//IL_025b: Expected I, but got O
		//IL_026c: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_02c6: Expected I, but got O
		//IL_02d7: Expected O, but got I4
		//IL_02ed: Expected I, but got O
		//IL_0168: Expected I, but got O
		//IL_0313: Expected I, but got O
		//IL_0324: Expected O, but got I4
		//IL_033a: Expected I, but got O
		//IL_0368: Expected O, but got I4
		//IL_037e: Expected I, but got O
		//IL_03ac: Expected O, but got I4
		//IL_03c2: Expected I, but got O
		Action<PlayerHealth, DamageContainer, bool> b = new Action<object, object, bool>(OnTakeDamage);
		Delegate obj = Delegate.Combine(PlayerHealth.A_TakeDamage, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0430;
			}
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_027b;
			}
		}
		Action action2 = RefreshTimeScale;
		Delegate obj6 = Delegate.Combine(MyTime.A_TimeScaleChange, action2);
		if ((object)obj6 == null)
		{
			MyTime.A_TimeScaleChange = null;
		}
		else
		{
			bool flag2 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag2)
			{
				obj7 = obj6;
			}
			bool flag3 = (object)obj7 == null;
			num2 = (nint)MyTime.A_TimeScaleChange;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_03f8;
			}
			MyTime.A_TimeScaleChange = (Action)obj7;
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj6;
			}
			bool flag5 = (object)obj8 == null;
			num = (nint)MyTime.A_TimeScaleChange;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0408;
			}
		}
		num = (nint)GameManager.A_StageStarted;
		Action action3 = ResetStats;
		Delegate obj9 = Delegate.Combine(GameManager.A_StageStarted, action3);
		if ((object)obj9 == null)
		{
			GameManager.A_StageStarted = null;
			return;
		}
		bool flag6 = (object)obj9.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag6)
		{
			obj10 = obj9;
		}
		bool flag7 = (object)obj10 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj9;
		nint num5 = (nint)typeof(Action);
		if (flag7)
		{
			goto IL_0420;
		}
		GameManager.A_StageStarted = (Action)obj10;
		bool flag8 = (object)obj9.GetType() != typeof(Action);
		Delegate obj11 = null;
		if (!flag8)
		{
			obj11 = obj9;
		}
		bool flag9 = (object)obj11 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj9;
		nint num6 = (nint)typeof(Action);
		if (!flag9)
		{
			return;
		}
		goto IL_0430;
		IL_0430:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0420;
		IL_027b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0420:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0408;
		IL_0408:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_03f8;
		IL_03f8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_027b;
	}

	public override void Cleanup()
	{
		//IL_025b: Expected I, but got O
		//IL_026c: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_02c6: Expected I, but got O
		//IL_02d7: Expected O, but got I4
		//IL_02ed: Expected I, but got O
		//IL_0168: Expected I, but got O
		//IL_0313: Expected I, but got O
		//IL_0324: Expected O, but got I4
		//IL_033a: Expected I, but got O
		//IL_0368: Expected O, but got I4
		//IL_037e: Expected I, but got O
		//IL_03ac: Expected O, but got I4
		//IL_03c2: Expected I, but got O
		Action<PlayerHealth, DamageContainer, bool> value = new Action<object, object, bool>(OnTakeDamage);
		Delegate obj = Delegate.Remove(PlayerHealth.A_TakeDamage, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerHealth.A_TakeDamage = (Action<PlayerHealth, DamageContainer, bool>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action = default(Action<PlayerHealth, DamageContainer, bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0430;
			}
			PlayerHealth.A_TakeDamage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_027b;
			}
		}
		Action action2 = RefreshTimeScale;
		Delegate obj6 = Delegate.Remove(MyTime.A_TimeScaleChange, action2);
		if ((object)obj6 == null)
		{
			MyTime.A_TimeScaleChange = null;
		}
		else
		{
			bool flag2 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag2)
			{
				obj7 = obj6;
			}
			bool flag3 = (object)obj7 == null;
			num2 = (nint)MyTime.A_TimeScaleChange;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_03f8;
			}
			MyTime.A_TimeScaleChange = (Action)obj7;
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj6;
			}
			bool flag5 = (object)obj8 == null;
			num = (nint)MyTime.A_TimeScaleChange;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_0408;
			}
		}
		num = (nint)GameManager.A_StageStarted;
		Action action3 = ResetStats;
		Delegate obj9 = Delegate.Remove(GameManager.A_StageStarted, action3);
		if ((object)obj9 == null)
		{
			GameManager.A_StageStarted = null;
			return;
		}
		bool flag6 = (object)obj9.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag6)
		{
			obj10 = obj9;
		}
		bool flag7 = (object)obj10 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj9;
		nint num5 = (nint)typeof(Action);
		if (flag7)
		{
			goto IL_0420;
		}
		GameManager.A_StageStarted = (Action)obj10;
		bool flag8 = (object)obj9.GetType() != typeof(Action);
		Delegate obj11 = null;
		if (!flag8)
		{
			obj11 = obj9;
		}
		bool flag9 = (object)obj11 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj9;
		nint num6 = (nint)typeof(Action);
		if (!flag9)
		{
			return;
		}
		goto IL_0430;
		IL_0430:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0420;
		IL_027b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0420:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0408;
		IL_0408:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_03f8;
		IL_03f8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_027b;
	}

	private void RefreshTimeScale()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_003e: Invalid comparison between F4 and O
		float num = MyTime._003CtimeScale_003Ek__BackingField - 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.01f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			StatModifier statModifier = new StatModifier();
			statModifier.stat = EStat.DamageMultiplier;
			statModifier.modification = 1f;
			statModifier.modifyType = EStatModifyType.Multiplication;
			SetStat(statModifier);
		}
	}

	protected override void OnInitOrAmountChanged()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		object obj = amount * durationPerAmount;
		float num = (float)obj + 8f;
		bool flag = 1f > num;
		float num2 = 1f;
		if (!flag)
		{
			bool flag2 = num > 15f;
			num2 = 15f;
			if (!flag2)
			{
				duration = num;
				return;
			}
		}
		duration = num2;
	}

	private void OnTakeDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
		//IL_0036: Invalid comparison between F4 and I4
		int combinedHp = ph.GetCombinedHp();
		int combinedMaxHp = ph.GetCombinedMaxHp();
		int num = combinedHp / combinedMaxHp;
		if (slowdownHpRatio > (float)num && !(slowdownReadyAtTime > MyTime.time))
		{
			float num2 = MyTime.time + duration;
			float num3 = num2 + normalCooldown;
			slowdownReadyAtTime = num3;
			MyTime.SetTimeScale(0.3f, duration);
			StatModifier statModifier = new StatModifier();
			statModifier.stat = EStat.DamageMultiplier;
			statModifier.modification = damageMultiplierDuringFreeze;
			statModifier.modifyType = EStatModifyType.Multiplication;
			SetStat(statModifier);
			Action a_Slowdown = A_Slowdown;
			if (A_Slowdown != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v150.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private void Slowdown()
	{
		if (!(slowdownReadyAtTime > MyTime.time))
		{
			float num = MyTime.time + duration;
			float num2 = num + normalCooldown;
			slowdownReadyAtTime = num2;
			MyTime.SetTimeScale(0.3f, duration);
			StatModifier statModifier = new StatModifier();
			statModifier.stat = EStat.DamageMultiplier;
			statModifier.modification = damageMultiplierDuringFreeze;
			statModifier.modifyType = EStatModifyType.Multiplication;
			SetStat(statModifier);
			Action a_Slowdown = A_Slowdown;
			if (A_Slowdown != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v163.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private void ResetStats()
	{
		StatModifier statModifier = new StatModifier();
		statModifier.stat = EStat.DamageMultiplier;
		statModifier.modification = 1f;
		statModifier.modifyType = EStatModifyType.Multiplication;
		SetStat(statModifier);
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

	protected override Dictionary<string, object> GetLocalizationKeys()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = EnumUtility.EnumToReadable(EStat.MaxHealth);
		if (text == null)
		{
			text = "";
		}
		if (dictionary != null)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"stat1", (object)text);
			float num = slowdownHpRatio * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string value = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg2 = default(object);
			string value2 = $"{arg2}x";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)value2);
			return dictionary;
		}
		return (Dictionary<string, object>)(object)new NullReferenceException();
	}
}
