using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetOfInterestPrefab : MonoBehaviour
{
	public TextMeshProUGUI t_name;

	public TextMeshProUGUI t_hp;

	public TextMeshProUGUI t_armor;

	public RawImage hpBar;

	public RawImage bloodmark;

	public RawImage poison;

	public CanvasGroup canvasGroup;

	public Color defaultColor;

	public Color invulnerableColor;

	private Enemy enemy;

	private float fadeTimer;

	private float fadeTime = 0.5f;

	private float debuffLerpSpeed = 5f;

	private float bloodmarkRatio;

	private float poisonRatio;

	private float poisonTargetRatio;

	private float bloodmarkTargetRatio;

	private void Awake()
	{
		//IL_03c6: Expected I, but got O
		//IL_03d7: Expected O, but got I4
		//IL_03e0: Expected O, but got I4
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
		//IL_032c: Expected I, but got O
		//IL_033d: Expected O, but got I4
		//IL_0346: Expected O, but got I4
		//IL_0384: Expected I, but got O
		//IL_0395: Expected O, but got I4
		//IL_039e: Expected O, but got I4
		Action<Enemy, DamageContainer> b = OnDamage;
		Delegate obj = Delegate.Combine(Enemy.A_Damage, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_Damage = null;
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
				goto IL_044d;
			}
			Enemy.A_Damage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_03ea;
			}
		}
		Action<Enemy> b2 = OnHealthChange;
		Delegate obj6 = Delegate.Combine(Enemy.A_HealthChange, b2);
		if ((object)obj6 == null)
		{
			Enemy.A_HealthChange = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action2 = default(Action<Enemy>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<Enemy>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_03f5;
			}
			Enemy.A_HealthChange = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<Enemy>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_0405;
			}
		}
		Action<Enemy, int, int> b3 = OnArmorChange;
		Delegate obj8 = Delegate.Combine(Enemy.A_ArmorChanged, b3);
		if ((object)obj8 == null)
		{
			Enemy.A_ArmorChanged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, int, int> action3 = default(Action<Enemy, int, int>);
			bool flag4 = action3 == null;
			num = (nint)typeof(Action<Enemy, int, int>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = 0;
			if (flag4)
			{
				goto IL_0415;
			}
			Enemy.A_ArmorChanged = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num = (nint)typeof(Action<Enemy, int, int>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = 0;
			if (flag5)
			{
				goto IL_042d;
			}
		}
		Action<Enemy, bool> b4 = OnInvulnerableChanged;
		Delegate obj10 = Delegate.Combine(Enemy.A_InvulnerableChanged, b4);
		if ((object)obj10 == null)
		{
			Enemy.A_InvulnerableChanged = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, bool> action4 = default(Action<Enemy, bool>);
		bool flag6 = action4 == null;
		num = (nint)typeof(Action<Enemy, bool>);
		obj2 = obj10;
		obj3 = 0;
		obj4 = 0;
		if (flag6)
		{
			goto IL_043d;
		}
		Enemy.A_InvulnerableChanged = action4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj11 = default(object);
		bool flag7 = obj11 == null;
		num = (nint)typeof(Action<Enemy, bool>);
		obj2 = obj10;
		obj3 = 0;
		obj4 = 0;
		if (!flag7)
		{
			return;
		}
		goto IL_044d;
		IL_0415:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0405;
		IL_042d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0415;
		IL_0405:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03f5;
		IL_043d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_042d;
		IL_03ea:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03f5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03ea;
		IL_044d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_043d;
	}

	private void OnDestroy()
	{
		//IL_03c6: Expected I, but got O
		//IL_03d7: Expected O, but got I4
		//IL_03e0: Expected O, but got I4
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
		//IL_032c: Expected I, but got O
		//IL_033d: Expected O, but got I4
		//IL_0346: Expected O, but got I4
		//IL_0384: Expected I, but got O
		//IL_0395: Expected O, but got I4
		//IL_039e: Expected O, but got I4
		Action<Enemy, DamageContainer> value = OnDamage;
		Delegate obj = Delegate.Remove(Enemy.A_Damage, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_Damage = null;
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
				goto IL_044d;
			}
			Enemy.A_Damage = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<Enemy, DamageContainer>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_03ea;
			}
		}
		Action<Enemy> value2 = OnHealthChange;
		Delegate obj6 = Delegate.Remove(Enemy.A_HealthChange, value2);
		if ((object)obj6 == null)
		{
			Enemy.A_HealthChange = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action2 = default(Action<Enemy>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<Enemy>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_03f5;
			}
			Enemy.A_HealthChange = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<Enemy>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_0405;
			}
		}
		Action<Enemy, int, int> value3 = OnArmorChange;
		Delegate obj8 = Delegate.Remove(Enemy.A_ArmorChanged, value3);
		if ((object)obj8 == null)
		{
			Enemy.A_ArmorChanged = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy, int, int> action3 = default(Action<Enemy, int, int>);
			bool flag4 = action3 == null;
			num = (nint)typeof(Action<Enemy, int, int>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = 0;
			if (flag4)
			{
				goto IL_0415;
			}
			Enemy.A_ArmorChanged = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num = (nint)typeof(Action<Enemy, int, int>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = 0;
			if (flag5)
			{
				goto IL_042d;
			}
		}
		Action<Enemy, bool> value4 = OnInvulnerableChanged;
		Delegate obj10 = Delegate.Remove(Enemy.A_InvulnerableChanged, value4);
		if ((object)obj10 == null)
		{
			Enemy.A_InvulnerableChanged = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, bool> action4 = default(Action<Enemy, bool>);
		bool flag6 = action4 == null;
		num = (nint)typeof(Action<Enemy, bool>);
		obj2 = obj10;
		obj3 = 0;
		obj4 = 0;
		if (flag6)
		{
			goto IL_043d;
		}
		Enemy.A_InvulnerableChanged = action4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj11 = default(object);
		bool flag7 = obj11 == null;
		num = (nint)typeof(Action<Enemy, bool>);
		obj2 = obj10;
		obj3 = 0;
		obj4 = 0;
		if (!flag7)
		{
			return;
		}
		goto IL_044d;
		IL_0415:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0405;
		IL_042d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0415;
		IL_0405:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03f5;
		IL_043d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_042d;
		IL_03ea:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03f5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03ea;
		IL_044d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_043d;
	}

	public unsafe void SetEnemy(Enemy enemy)
	{
		//IL_0045: Expected O, but got Ref
		//IL_022e: Expected O, but got Ref
		//IL_0254: Expected O, but got Ref
		//IL_018a: Expected O, but got I
		//IL_019a: Expected O, but got I
		//IL_01b2: Expected F4, but got I4
		//IL_02c2: Invalid comparison between F4 and I4
		//IL_02a1: Invalid comparison between F4 and I4
		if (!(this.enemy != enemy))
		{
			return;
		}
		this.enemy = enemy;
		Color color = default(Color);
		hpBar.color = (Color)(&color);
		GameObject gameObject = base.gameObject;
		bool active = enemy != null;
		gameObject.SetActive(active);
		if (!(enemy != null))
		{
			return;
		}
		string text = enemy._003CenemyData_003Ek__BackingField.GetName();
		t_name.text = text;
		UpdateHp();
		canvasGroup.alpha = 0f;
		fadeTimer = 0f;
		GameObject gameObject2 = t_armor.gameObject;
		gameObject2.SetActive(value: false);
		if (enemy._003CarmorMax_003Ek__BackingField > 0 && this.enemy == enemy)
		{
			GameObject gameObject3 = t_armor.gameObject;
			gameObject3.SetActive(value: true);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rax_v40+B8]");
			object text2 = 0;
			t_armor.text = (string)text2;
			float num = 0f;
			do
			{
				string text3;
				string text4;
				if (!(num < (float)enemy._003CarmorCurrent_003Ek__BackingField))
				{
					text3 = t_armor.text;
					text4 = "<sprite name=ShieldBroken>";
				}
				else
				{
					text3 = t_armor.text;
					text4 = "<sprite name=Shield>";
				}
				string text5 = text3 + text4;
				t_armor.text = text5;
				num++;
			}
			while (num < (float)enemy._003CarmorMax_003Ek__BackingField);
		}
		bloodmarkRatio = 0f;
		poisonTargetRatio = 0f;
		Transform transform = bloodmark.transform;
		transform.localScale = (Vector3)(&color);
		Transform transform2 = poison.transform;
		Vector3 vector = default(Vector3);
		transform2.localScale = (Vector3)(&vector);
	}

	private void Update()
	{
		//IL_00b5: Invalid comparison between I4 and F4
		//IL_0041: Expected F4, but got I4
		UpdateDebuffs();
		if (!(fadeTimer < 1f))
		{
			return;
		}
		float num = MyTime.deltaTime / fadeTime;
		float num2 = (fadeTimer = num + fadeTimer);
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		canvasGroup.alpha = num2;
	}

	private unsafe void UpdateHp()
	{
		//IL_00d9: Invalid comparison between I4 and F4
		//IL_0124: Expected F4, but got I4
		//IL_014a: Expected O, but got Ref
		if (!(this.enemy != null))
		{
			return;
		}
		Enemy enemy = this.enemy;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C50");
		Enemy enemy2 = this.enemy;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002C50");
		string text = DamageNumbers.FormatDamageNumber(enemy._003Chp_003Ek__BackingField);
		string text2 = DamageNumbers.FormatDamageNumber(enemy2.maxHp);
		string text3 = text + " / " + text2;
		t_hp.text = text3;
		float num = enemy._003Chp_003Ek__BackingField / enemy2.maxHp;
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
		Transform transform = hpBar.transform;
		float num2 = default(float);
		transform.localScale = (Vector3)(&num2);
		float num3 = bloodmarkTargetRatio + poisonTargetRatio;
		if (num3 > 1f)
		{
			float num4 = 1f - bloodmarkTargetRatio;
			poisonTargetRatio = num4;
		}
	}

	private unsafe void UpdateDebuffs()
	{
		//IL_02a2: Expected I, but got O
		//IL_0030: Expected O, but got I4
		//IL_0035: Expected I, but got O
		//IL_02c9: Expected I, but got O
		//IL_0782: Expected F4, but got I4
		//IL_005e: Expected I, but got O
		//IL_031f: Expected I, but got O
		//IL_0327: Expected I, but got O
		//IL_0337: Expected O, but got I
		//IL_0363: Expected I, but got O
		//IL_04a8: Expected F4, but got I4
		//IL_008c: Expected I, but got O
		//IL_0381: Expected O, but got I
		//IL_03ae: Expected I, but got O
		//IL_08da: Invalid comparison between O and F4
		//IL_04e4: Expected F4, but got I4
		//IL_00b3: Expected I, but got O
		//IL_03e5: Expected I, but got O
		//IL_0807: Invalid comparison between O and F4
		//IL_0520: Expected F4, but got I4
		//IL_0418: Invalid comparison between I4 and F4
		//IL_0427: Expected O, but got I4
		//IL_0435: Expected I, but got O
		//IL_0109: Expected I, but got O
		//IL_0111: Expected I, but got O
		//IL_0121: Expected O, but got I
		//IL_014d: Expected I, but got O
		//IL_045e: Expected O, but got I4
		//IL_046c: Expected I, but got O
		//IL_0173: Expected O, but got I
		//IL_01a0: Expected I, but got O
		//IL_048c: Expected O, but got I4
		//IL_049a: Expected I, but got O
		//IL_01ec: Expected I, but got O
		//IL_090e: Expected I, but got O
		//IL_0216: Invalid comparison between O and F4
		//IL_022a: Expected I, but got O
		//IL_05d0: Expected I, but got O
		//IL_0258: Expected I, but got O
		//IL_0601: Expected I, but got O
		//IL_027d: Expected I, but got O
		//IL_0632: Expected I, but got O
		//IL_064e: Expected O, but got Ref
		//IL_0664: Expected I, but got O
		//IL_0695: Expected I, but got O
		//IL_06b0: Expected O, but got Ref
		//IL_06c6: Expected I, but got O
		//IL_06f7: Expected I, but got O
		object obj;
		nint num = default(nint);
		object obj2;
		float num5;
		if ((object)this.enemy != null)
		{
			if (!this.enemy.HasDebuff(EDebuff.Bloodmark))
			{
				obj = 0;
				num = unchecked((nint)null);
				goto IL_0779;
			}
			Enemy enemy = this.enemy;
			bool flag = (object)this.enemy == null;
			num = unchecked((nint)null);
			if (!flag)
			{
				bool flag2 = enemy.debuffs == null;
				num = unchecked((nint)null);
				if (!flag2)
				{
					obj2 = ((Dictionary<System.Int32Enum, object>)(object)enemy.debuffs).get_Item((System.Int32Enum)64);
					bool flag3 = obj2 == null;
					num = 0;
					if (!flag3)
					{
						nint num2 = (nint)typeof(DebuffBloodmark);
						nint num3 = (nint)obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ r8_v18 (Il2CppClass<Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations.DebuffBloodmark>)+130]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r9_v9 (Il2CppClass<System.Object>)+130]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ r8_v18 (Il2CppClass<Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations.DebuffBloodmark>)+130]");
						bool flag4 = num4 < 0;
						num = (nint)typeof(DebuffBloodmark);
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r9_v9 (Il2CppClass<System.Object>)+C8]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rcx_v32+FFFFFFF8+v506 @ rcx_v31*8]");
							bool flag5 = 0 != (nint)typeof(DebuffBloodmark);
							num = (nint)typeof(DebuffBloodmark);
							if (!flag5)
							{
								Enemy enemy2 = this.enemy;
								bool flag6 = (object)this.enemy == null;
								num = (nint)typeof(DebuffBloodmark);
								if (flag6)
								{
									goto IL_0713;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rax_v2 (System.Object)+34]");
								num5 = 0f / enemy2.maxHp;
								bool flag7 = 0f > num5;
								obj = 0;
								num = (nint)typeof(DebuffBloodmark);
								if (flag7)
								{
									goto IL_0779;
								}
								bool flag8 = !(num5 > 1f);
								obj = 0;
								num = (nint)typeof(DebuffBloodmark);
								if (!flag8)
								{
									num5 = 1f;
									obj = 0;
									num = (nint)typeof(DebuffBloodmark);
								}
								goto IL_0787;
							}
						}
						goto IL_0767;
					}
				}
			}
		}
		goto IL_0713;
		IL_0713:
		NullReferenceException ex = new NullReferenceException();
		goto IL_0741;
		IL_0741:
		obj2 = ((Dictionary<EDebuff, EnemyDebuff>)(object)ex).get_Item((EDebuff)num);
		goto IL_0767;
		IL_049f:
		float num6 = 0f;
		goto IL_0758;
		IL_0779:
		num5 = 0f;
		goto IL_0787;
		IL_0787:
		bloodmarkTargetRatio = num5;
		if ((object)this.enemy != null)
		{
			bool flag9 = this.enemy.HasDebuff(EDebuff.Poison);
			bool flag10 = !flag9;
			num = unchecked((nint)null);
			if (flag10)
			{
				goto IL_049f;
			}
			Enemy enemy3 = this.enemy;
			bool flag11 = (object)this.enemy == null;
			num = unchecked((nint)null);
			if (!flag11)
			{
				bool flag12 = enemy3.debuffs == null;
				num = unchecked((nint)null);
				if (!flag12)
				{
					object obj5 = ((Dictionary<System.Int32Enum, object>)(object)enemy3.debuffs).get_Item((System.Int32Enum)1);
					bool flag13 = obj5 == null;
					num = 0;
					if (!flag13)
					{
						nint num7 = (nint)typeof(DebuffPoison);
						nint num8 = (nint)obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ r8_v15 (Il2CppClass<Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations.DebuffPoison>)+130]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r9_v7 (Il2CppClass<System.Object>)+130]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ r8_v15 (Il2CppClass<Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations.DebuffPoison>)+130]");
						bool flag14 = num9 < 0;
						num = (nint)typeof(DebuffPoison);
						ex = (NullReferenceException)obj5;
						if (!flag14)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r9_v7 (Il2CppClass<System.Object>)+C8]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rcx_v27+FFFFFFF8+v397 @ rcx_v26*8]");
							bool flag15 = 0 != (nint)typeof(DebuffPoison);
							num = (nint)typeof(DebuffPoison);
							ex = (NullReferenceException)obj5;
							if (!flag15)
							{
								float damageForHpBar = ((DebuffPoison)obj5).GetDamageForHpBar();
								Enemy enemy4 = this.enemy;
								bool flag16 = (object)this.enemy == null;
								num = (nint)typeof(DebuffPoison);
								if (flag16)
								{
									goto IL_0713;
								}
								num6 = damageForHpBar / enemy4.maxHp;
								bool flag17 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6);
								num = (nint)typeof(DebuffPoison);
								if (flag17)
								{
									goto IL_049f;
								}
								bool flag18 = !(num6 > 1f);
								num = (nint)typeof(DebuffPoison);
								if (!flag18)
								{
									num6 = 1f;
									num = (nint)typeof(DebuffPoison);
								}
								goto IL_0758;
							}
						}
						goto IL_0741;
					}
				}
			}
		}
		goto IL_0713;
		IL_0767:
		EnemyDebuff enemyDebuff = ((Dictionary<EDebuff, EnemyDebuff>)obj2).get_Item((EDebuff)num);
		return;
		IL_0758:
		poisonTargetRatio = num6;
		float num10 = debuffLerpSpeed * MyTime.deltaTime;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num10))
		{
			if (num10 > 1f)
			{
				num10 = 1f;
			}
		}
		else
		{
			num10 = 0f;
		}
		float num11 = bloodmarkTargetRatio - bloodmarkRatio;
		float num12 = num11 * num10;
		float num13 = num12 + bloodmarkRatio;
		bloodmarkRatio = num13;
		float num14 = MyTime.deltaTime * debuffLerpSpeed;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num14))
		{
			if (num14 > 1f)
			{
				num14 = 1f;
			}
		}
		else
		{
			num14 = 0f;
		}
		float num15 = poisonTargetRatio - poisonRatio;
		float num16 = num15 * num14;
		float num17 = num16 + poisonRatio;
		poisonRatio = num17;
		if ((object)hpBar != null)
		{
			Transform transform = hpBar.transform;
			if ((object)transform != null)
			{
				Vector3 localScale = transform.localScale;
				float x = bloodmarkRatio;
				if (bloodmarkRatio > localScale.x)
				{
					x = localScale.x;
				}
				bloodmarkRatio = x;
				float num18 = localScale.x - x;
				float num19 = poisonRatio;
				if (poisonRatio > num18)
				{
					num19 = num18;
				}
				poisonRatio = num19;
				bool flag19 = (object)hpBar == null;
				num = unchecked((nint)null);
				if (!flag19)
				{
					RectTransform rectTransform = hpBar.rectTransform;
					bool flag20 = (object)rectTransform == null;
					num = unchecked((nint)null);
					if (!flag20)
					{
						Rect rect = rectTransform.rect;
						bool flag21 = (object)bloodmark == null;
						num = unchecked((nint)null);
						if (!flag21)
						{
							Transform transform2 = bloodmark.transform;
							bool flag22 = (object)transform2 == null;
							num = unchecked((nint)null);
							if (!flag22)
							{
								float num20 = default(float);
								transform2.localScale = (Vector3)(&num20);
								bool flag23 = (object)poison == null;
								num = unchecked((nint)null);
								if (!flag23)
								{
									Transform transform3 = poison.transform;
									bool flag24 = (object)transform3 == null;
									num = unchecked((nint)null);
									if (!flag24)
									{
										transform3.localScale = (Vector3)(&num20);
										bool flag25 = (object)poison == null;
										num = unchecked((nint)null);
										if (!flag25)
										{
											RectTransform rectTransform2 = poison.rectTransform;
											bool flag26 = (object)rectTransform2 == null;
											num = unchecked((nint)null);
											if (!flag26)
											{
												Vector2 anchoredPosition = default(Vector2);
												rectTransform2.anchoredPosition = anchoredPosition;
												return;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0713;
	}

	private void OnDamage(Enemy enemy, DamageContainer dc)
	{
		if (this.enemy == enemy)
		{
			UpdateHp();
		}
	}

	private unsafe void OnInvulnerableChanged(Enemy enemy, bool invulnerable)
	{
		//IL_0053: Expected O, but got Ref
		if (this.enemy == enemy)
		{
			if (invulnerable)
			{
			}
			object obj = default(object);
			hpBar.color = (Color)(&obj);
		}
	}

	private void OnHealthChange(Enemy enemy)
	{
		if (enemy == this.enemy)
		{
			UpdateHp();
		}
	}

	private void OnArmorChange(Enemy enemy, int current, int max)
	{
		//IL_005d: Expected O, but got I
		//IL_006d: Expected O, but got I
		//IL_0097: Expected O, but got I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		if (!(this.enemy == enemy))
		{
			return;
		}
		GameObject gameObject = t_armor.gameObject;
		gameObject.SetActive(value: true);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B70]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v9+B8]");
		object text = 0;
		t_armor.text = (string)text;
		bool flag = max <= 0;
		object obj2 = 0;
		if (flag)
		{
			return;
		}
		do
		{
			string text2;
			string text3;
			if ((nint)obj2 >= current)
			{
				text2 = t_armor.text;
				text3 = "<sprite name=ShieldBroken>";
			}
			else
			{
				text2 = t_armor.text;
				text3 = "<sprite name=Shield>";
			}
			string text4 = text2 + text3;
			t_armor.text = text4;
			obj2++;
		}
		while ((nint)obj2 < max);
	}
}
