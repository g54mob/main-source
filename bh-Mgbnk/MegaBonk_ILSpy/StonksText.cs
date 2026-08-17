using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class StonksText : MonoBehaviour
{
	private int amount;

	public TextMeshProUGUI t_gold;

	private bool active;

	private float rotationSpeed = 1f;

	private float maxRotationAngle = 10f;

	private float timeCounter;

	private float lerp;

	private float lerp2;

	private float scaleOffset;

	private void Awake()
	{
		//IL_02a8: Expected I, but got O
		//IL_02b9: Expected O, but got I4
		//IL_02c2: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_020e: Expected I, but got O
		//IL_021f: Expected O, but got I4
		//IL_0228: Expected O, but got I4
		//IL_0266: Expected I, but got O
		//IL_0277: Expected O, but got I4
		//IL_0280: Expected O, but got I4
		Action<EStatusEffect, bool> b = OnStatusEffectAdded;
		Delegate obj = Delegate.Combine(PlayerStatusEffects.A_StatusEffectAdded, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerStatusEffects.A_StatusEffectAdded = (Action<EStatusEffect, bool>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStatusEffect, bool> action = default(Action<EStatusEffect, bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EStatusEffect, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_035a;
			}
			PlayerStatusEffects.A_StatusEffectAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<EStatusEffect, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_02ef;
			}
		}
		Action<EStatusEffect> b2 = OnStatusEffectRemoved;
		Delegate obj6 = Delegate.Combine(PlayerStatusEffects.A_StatusEffectRemoved, b2);
		if ((object)obj6 == null)
		{
			PlayerStatusEffects.A_StatusEffectRemoved = (Action<EStatusEffect>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStatusEffect> action2 = default(Action<EStatusEffect>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<EStatusEffect>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_02fa;
			}
			PlayerStatusEffects.A_StatusEffectRemoved = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<EStatusEffect>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_030a;
			}
		}
		Action<Enemy, DamageContainer> b3 = OnEnemyDied;
		Delegate obj8 = Delegate.Combine(Enemy.A_EnemyDied, b3);
		if ((object)obj8 == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action3 = default(Action<Enemy, DamageContainer>);
		bool flag4 = action3 == null;
		num = (nint)typeof(Action<Enemy, DamageContainer>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_034a;
		}
		Enemy.A_EnemyDied = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		num = (nint)typeof(Action<Enemy, DamageContainer>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (!flag5)
		{
			return;
		}
		goto IL_035a;
		IL_035a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_034a;
		IL_02ef:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02fa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02ef;
		IL_030a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02fa;
		IL_034a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_030a;
	}

	public unsafe void Reset()
	{
		//IL_0061: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F6C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		amount = 0;
		Transform transform = t_gold.transform;
		Vector3 localScale = transform.localScale;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
		t_gold.text = "$0";
	}

	private unsafe void OnStatusEffectAdded(EStatusEffect eStatusEffect, bool isNewEffect)
	{
		//IL_009a: Expected O, but got Ref
		if (eStatusEffect == EStatusEffect.Stonks && isNewEffect)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F6C]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			amount = 0;
			Transform transform = t_gold.transform;
			Vector3 localScale = transform.localScale;
			object obj = default(object);
			transform.localScale = (Vector3)(&obj);
			t_gold.text = "$0";
			active = true;
		}
	}

	private void OnStatusEffectRemoved(EStatusEffect eStatusEffect)
	{
		if (eStatusEffect == EStatusEffect.Stonks)
		{
			active = false;
		}
	}

	private unsafe void OnEnemyDied(Enemy e, DamageContainer deathSource)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected I4, but got Unknown
		//IL_00d7: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F6D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int gold = e._003CenemyData_003Ek__BackingField.GetGold();
		int num = amount + gold;
		amount = num;
		Transform transform = t_gold.transform;
		if (2.5f > transform.localScale.x)
		{
			Transform transform2 = t_gold.transform;
			Vector3 localScale = transform2.localScale;
			object obj = default(object);
			transform2.localScale = (Vector3)(&obj);
		}
		int num2 = this + 32;
		string text = ((int*)num2)->ToString();
		string text2 = "$" + text;
		t_gold.text = text2;
	}

	private unsafe void Update()
	{
		//IL_0289: Invalid comparison between I4 and F4
		//IL_00bd: Expected F4, but got I4
		//IL_00cf: Expected O, but got Ref
		//IL_012e: Invalid comparison between I4 and F4
		//IL_0179: Expected F4, but got I4
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		//IL_0345: Invalid comparison between I4 and F4
		//IL_01b5: Expected F4, but got I4
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_03bf: Invalid comparison between I4 and F4
		//IL_01f1: Expected F4, but got I4
		//IL_042f: Invalid comparison between I4 and F4
		//IL_022d: Expected F4, but got I4
		//IL_024a: Expected O, but got Ref
		//IL_0260: Expected O, but got Ref
		if (!active)
		{
			return;
		}
		Transform transform = t_gold.transform;
		Transform transform2 = t_gold.transform;
		Vector3 localScale = transform2.localScale;
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 5f;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = default(float);
		transform.localScale = (Vector3)(&num2);
		float time = Time.time;
		float num3 = time + time;
		float num4 = num3 * 0.25f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		float num5 = num4 * 4f;
		float num6 = num3 - num5;
		if (!(0f > num6))
		{
			if (num6 > 4f)
			{
				num6 = 4f;
			}
		}
		else
		{
			num6 = 0f;
		}
		float num7 = num6 - 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num7 & 0;
		float num8 = 2f - (float)obj;
		float num9 = num8 - 1f;
		float time2 = Time.time;
		float num10 = time2 * 4f;
		float num11 = num10 * 0.25f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		float num12 = num11 * 4f;
		float num13 = num10 - num12;
		if (!(0f > num13))
		{
			if (num13 > 4f)
			{
				num13 = 4f;
			}
		}
		else
		{
			num13 = 0f;
		}
		float num14 = num13 - 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj2 = num14 & 0;
		float num15 = 2f - (float)obj2;
		float num16 = num15 - 1f;
		float deltaTime2 = Time.deltaTime;
		float num17 = deltaTime2 + deltaTime2;
		if (!(0f > num17))
		{
			if (num17 > 1f)
			{
				num17 = 1f;
			}
		}
		else
		{
			num17 = 0f;
		}
		float num18 = num9 - lerp;
		float num19 = num18 * num17;
		float num20 = num19 + lerp;
		lerp = num20;
		float deltaTime3 = Time.deltaTime;
		float num21 = deltaTime3 + deltaTime3;
		if (!(0f > num21))
		{
			if (num21 > 1f)
			{
				num21 = 1f;
			}
		}
		else
		{
			num21 = 0f;
		}
		float num22 = num16 - lerp2;
		float num23 = num22 * num21;
		float num24 = (lerp2 = num23 + lerp2) * 0.25f;
		float num25 = num24 + 1f;
		scaleOffset = num25;
		Transform transform3 = t_gold.transform;
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num2));
		transform3.rotation = (Quaternion)(&num2);
	}

	private void OnDestroy()
	{
		//IL_02d0: Expected I, but got O
		//IL_02e1: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_0236: Expected I, but got O
		//IL_0247: Expected O, but got I4
		//IL_0250: Expected O, but got I4
		//IL_028e: Expected I, but got O
		//IL_029f: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		Action<Enemy, DamageContainer> value = OnEnemyDied;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyDied, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<Enemy, DamageContainer>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0337;
			}
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_02f4;
			}
		}
		Action<EStatusEffect, bool> value2 = OnStatusEffectAdded;
		Delegate obj6 = Delegate.Remove(PlayerStatusEffects.A_StatusEffectAdded, value2);
		if ((object)obj6 == null)
		{
			PlayerStatusEffects.A_StatusEffectAdded = (Action<EStatusEffect, bool>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStatusEffect, bool> action2 = default(Action<EStatusEffect, bool>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<EStatusEffect, bool>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_02ff;
			}
			PlayerStatusEffects.A_StatusEffectAdded = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<EStatusEffect, bool>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_030f;
			}
		}
		Action<EStatusEffect> value3 = OnStatusEffectRemoved;
		Delegate obj8 = Delegate.Remove(PlayerStatusEffects.A_StatusEffectRemoved, value3);
		if ((object)obj8 == null)
		{
			PlayerStatusEffects.A_StatusEffectRemoved = (Action<EStatusEffect>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<EStatusEffect> action3 = default(Action<EStatusEffect>);
		bool flag4 = action3 == null;
		num = (nint)typeof(Action<EStatusEffect>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_0327;
		}
		PlayerStatusEffects.A_StatusEffectRemoved = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		num = (nint)typeof(Action<EStatusEffect>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (!flag5)
		{
			return;
		}
		goto IL_0337;
		IL_0337:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0327;
		IL_02f4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02ff:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02f4;
		IL_030f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02ff;
		IL_0327:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_030f;
	}
}
