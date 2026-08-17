using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Objects.Pooling;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemSnek : ItemBase
{
	private float poisonChancePerAmount;

	private float poisonBurstChancePerAmount;

	private float poisonChanceTotal;

	private float poisonBurstChanceTotal;

	public float damageRatio;

	public float damageRatioPerAmount;

	private int procsSinceLastTick;

	private HashSet<Enemy> queuedExplosionEnemies;

	private string damageSource;

	private DamageContainer reuseDc;

	protected override void OnInitOrAmountChanged()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		float num = (float)amount * poisonChancePerAmount;
		float num2 = (float)amount * poisonBurstChancePerAmount;
		poisonChanceTotal = num;
		poisonBurstChanceTotal = num2;
		object obj = amount * damageRatioPerAmount;
		float num3 = (float)obj + 0.5f;
		damageRatio = num3;
	}

	public override void ProcOnHitEffects(DamageContainer dc)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_04a7: Invalid comparison between I4 and F4
		//IL_002d: Invalid comparison between F4 and I4
		//IL_003f: Expected F8, but got I4
		//IL_04d3: Invalid comparison between F4 and I4
		//IL_04f8: Invalid comparison between F8 and I4
		//IL_01be: Expected O, but got I
		//IL_01d1: Expected O, but got I4
		//IL_01f7: Expected O, but got I4
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_02ac: Expected O, but got I4
		//IL_052b: Expected I, but got O
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Expected O, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		if (!(0f < poisonChanceTotal))
		{
			return;
		}
		bool flag = !(poisonChancePerAmount > 0f);
		double num = 0.0;
		if (!flag)
		{
			double num2 = Math.Floor(poisonChanceTotal);
			num = num2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,esi\"");
		if (poisonChanceTotal > 0f && ItemUtility.TryProc(dc.procCoefficient, poisonChanceTotal))
		{
			num++;
		}
		if (!(num > 0.0))
		{
			return;
		}
		int stacks = default(int);
		dc.enemy.AddDebuff(EDebuff.Poison, dc, 5f, stacks);
		if (ItemUtility.TryProc(dc.procCoefficient, poisonBurstChanceTotal))
		{
			reuseDc.Reuse(0f, damageSource);
			DamageContainer damageContainer = reuseDc;
			float damage = damageRatio * dc.damage;
			damageContainer.damage = damage;
			DamageContainer damageContainer2 = reuseDc;
			damageContainer2.enemy = dc.enemy;
			dc.enemy.DamageFromPlayerOther(reuseDc);
			bool flag2 = queuedExplosionEnemies.Add(dc.enemy);
			PoolManager instance = PoolManager.Instance;
			bool flag3 = ((HashSet<Enemy>)(object)instance.snekPool).Add((Enemy)0);
			if ((UnityEngine.Object)flag3 != null)
			{
				Transform transform = ((GameObject)flag3).transform;
				Enemy enemy = dc.enemy;
				Transform transform2 = MyPlayer.Instance.transform;
				Vector3 position = transform2.position;
				Vector3 position2 = (Vector3)(obj - 89);
				_ = position.x;
				_ = position.z;
				Vector3 vector = enemy.collider.ClosestPointOnBounds(position2);
				Vector3 position3 = (Vector3)(obj - 89);
				_ = vector.x;
				_ = vector.z;
				transform.position = position3;
				Transform transform3 = ((GameObject)flag3).transform;
				Vector3 position4 = transform3.position;
				nint num3 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v781 @ rax_v33 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num4 = 0;
				float num5 = (float)Vector3.upVector * 3f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rcx_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
				float num6 = 0f * 3f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rcx_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				float num7 = 0f * 3f;
				Transform transform4 = MyPlayer.Instance.transform;
				Vector3 position5 = transform4.position;
				Transform transform5 = dc.enemy.transform;
				Vector3 position6 = transform5.position;
				float num8 = position5.x - position6.x;
				float num9 = position5.y - position6.y;
				float num10 = position5.z - position6.z;
				Vector3 v = (Vector3)(obj - 89);
				Vector3 vector2 = VectorExtensions.XZVector(v);
				object obj3 = obj - 89;
				object obj4 = obj - 73;
				_ = vector2.x;
				_ = vector2.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				Vector3 position7 = (Vector3)(obj - 89);
				object obj5 = default(object);
				float num11 = (float)obj5 * 0.75f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ rax_v41+8]");
				float num12 = 0f * 0.75f;
				float num13 = num11 + num5;
				float num14 = num12 + num7;
				float num15 = num13 + position4.x;
				float num16 = num14 + position4.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ rax_v41+4]");
				float num17 = 0f * 0.75f;
				float num18 = num17 + num6;
				float num19 = num18 + position4.y;
				transform3.position = position7;
			}
		}
	}

	public override bool HasOnHitEffectProc()
	{
		return true;
	}

	public unsafe ItemSnek(ItemInventory itemInventoryRef)
	{
		//IL_000e: Expected O, but got Ref
		//IL_002a: Expected O, but got Ref
		poisonChancePerAmount = 4f;
		poisonBurstChancePerAmount = 0.05f;
		damageRatio = 0.4f;
		damageRatioPerAmount = 0.4f;
		HashSet<Enemy> hashSet = (HashSet<Enemy>)(object)new HashSet<object>();
		queuedExplosionEnemies = hashSet;
		object obj = default(object);
		damageSource = ((Enum)(&obj)).ToString();
		object obj2 = default(object);
		reuseDc = new DamageContainer(0f, ((Enum)(&obj2)).ToString());
		base._002Ector(itemInventoryRef);
	}

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public unsafe override void Tick()
	{
		//IL_0059: Expected O, but got F4
		//IL_0075: Invalid comparison between F4 and I4
		//IL_0092: Expected O, but got F4
		//IL_00b3: Expected O, but got F4
		//IL_010c: Expected O, but got I
		//IL_0136: Expected I, but got O
		//IL_017c: Expected O, but got I
		//IL_0280: Expected O, but got I
		//IL_01dc: Expected O, but got I
		//IL_02b5: Expected O, but got F4
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected I4, but got Unknown
		//IL_0229: Expected O, but got I
		//IL_0356: Expected O, but got F4
		//IL_035f: Expected F4, but got I4
		//IL_0367: Expected O, but got F4
		HashSet<Enemy> hashSet = queuedExplosionEnemies;
		if (queuedExplosionEnemies != null)
		{
			if (hashSet._count <= 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18105BB00");
			float num2 = default(float);
			float num = num2;
			HashSet<object>.Enumerator enumerator2 = default(HashSet<object>.Enumerator);
			HashSet<object>.Enumerator enumerator = enumerator2;
			HashSet<object>.Enumerator enumerator3 = default(HashSet<object>.Enumerator);
			int num4 = default(int);
			object obj2 = default(object);
			while (enumerator3.MoveNext())
			{
				if (!((UnityEngine.Object)num2 != null))
				{
					continue;
				}
				if (num2 != 0f)
				{
					if (((Enemy)num2).IsDeadOrDyingNextFrame() || !((Enemy)num2).HasDebuff(EDebuff.Poison))
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-80 (System.Single)+128]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-80 (System.Single)+128]");
						object obj = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)1);
						if (obj != null)
						{
							nint num3 = (nint)obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v602 @ r8_v18 (Il2CppClass<System.Object>)+198] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-80 (System.Single)+138]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-80 (System.Single)+138]");
								bool flag = ((Dictionary<System.Int32Enum, AddDebuffContainer>)0).ContainsKey((System.Int32Enum)1);
								bool flag2 = !flag;
								int stacks = num4;
								if (!flag2)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-80 (System.Single)+138]");
									if ((nint)0 == 0)
									{
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-80 (System.Single)+138]");
									AddDebuffContainer addDebuffContainer = ((Dictionary<System.Int32Enum, AddDebuffContainer>)0).get_Item((System.Int32Enum)1);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-80 (System.Single)+138]");
									if ((nint)0 == 0)
									{
										throw new NullReferenceException();
									}
									stacks = num4 + obj2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-80 (System.Single)+138]");
									bool flag3 = ((Dictionary<System.Int32Enum, AddDebuffContainer>)0).Remove((System.Int32Enum)1);
								}
								float poisonDamagePerTick = DebuffPoison.GetPoisonDamagePerTick(stacks);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-80 (System.Single)+128]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ stack_-80 (System.Single)+128]");
									object obj3 = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)1);
									if (obj3 != null)
									{
										((Enemy)num2).RemoveDebuff(EDebuff.Poison, fromDeath: false);
										if (reuseDc != null)
										{
											reuseDc.Reuse(0f, damageSource);
											DamageContainer damageContainer = reuseDc;
											if (reuseDc != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ rax_v41 (System.Object)+10]");
												float damage = 0f * poisonDamagePerTick;
												damageContainer.damage = damage;
												damageContainer.damageEffect = EDamageEffect.Poison;
												((Enemy)num2).DamageFromPlayerOther(reuseDc);
												num = 0f;
												enumerator = (HashSet<object>.Enumerator)poisonDamagePerTick;
												continue;
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((HashSet<Enemy>.Enumerator*)(&enumerator3))->Dispose();
			if (queuedExplosionEnemies != null)
			{
				queuedExplosionEnemies.Clear();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void PreAttack(DamageContainer dc, StatComponents itemAttackModifier)
	{
	}

	public override bool HasPreAttackProc()
	{
		return false;
	}

	public override string GetDescription(LocalizedString localizedString)
	{
		//IL_00da: Expected O, but got I4
		//IL_00fe: Expected I, but got O
		//IL_0117: Expected O, but got I
		//IL_0144: Expected O, but got I
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj = default(object);
		string value = $"+{obj}";
		bool flag = dictionary == null;
		object obj2 = null;
		object obj3 = obj;
		string text = "+{0}";
		if (!flag)
		{
			((Dictionary<object, object>)(object)dictionary).Add((object)"value1", (object)value);
			float num = poisonBurstChancePerAmount * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text2 = $"{arg}%";
			((Dictionary<object, object>)(object)dictionary).Add((object)"value2", (object)text2);
			object[] array = new object[1];
			bool flag2 = array == null;
			nint num2 = 0;
			obj2 = text2;
			obj3 = 1;
			text = (string)(object)typeof(object[]);
			if (!flag2)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v13 (Il2CppClass<System.Object[]>)+40]");
				dictionary.Add((string)0, text2);
				object obj4 = default(object);
				bool flag3 = obj4 == null;
				num2 = 0;
				obj2 = text2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rdx_v13 (Il2CppClass<System.Object[]>)+40]");
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
				num2 = 0;
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
