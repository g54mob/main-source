using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks;

public class SpecialAttackController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<EnemySpecialAttack, int> _003C_003E9__8_0;

		public static Func<EnemySpecialAttack, int> _003C_003E9__8_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003CTick_003Eb__8_0(EnemySpecialAttack a)
		{
			//IL_0035: Expected I4, but got O
			if (a != null)
			{
				return a.priority;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal int _003CTick_003Eb__8_1(EnemySpecialAttack _)
		{
			//IL_0026: Expected I4, but got O
			if (MyRandom.random != null)
			{
				return MyRandom.random.Next();
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	private static bool enabled = true;

	private HashSet<EnemySpecialAttack> attacks;

	private Dictionary<EnemySpecialAttack, float> cooldowns;

	private float updateRate;

	private float nextCheckTime;

	private Enemy enemy;

	private bool isAttacking;

	private float attackOverAtTime;

	private EnemySpecialAttack currentAttack;

	public SpecialAttackController(Enemy enemy)
	{
		//IL_00ea: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		updateRate = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		this.enemy = enemy;
		double num = MyRandom.random.NextDouble();
		double num2 = MyRandom.random.NextDouble();
		float num3 = MyTime.time + 3f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm2,xmm0\"");
		float num4 = 0f * 5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,xmm8\"");
		float num5 = updateRate + num3;
		float num6 = num4 + num5;
		nextCheckTime = num6;
		HashSet<EnemySpecialAttack> hashSet = (HashSet<EnemySpecialAttack>)(object)new HashSet<object>();
		attacks = hashSet;
		Dictionary<EnemySpecialAttack, float> dictionary = new Dictionary<EnemySpecialAttack, float>();
		cooldowns = dictionary;
		EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
		EnemySpecialAttack[] specialAttacks = enemyData.specialAttacks;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < specialAttacks.Length)
		{
			EnemySpecialAttack enemySpecialAttack = specialAttacks[obj];
			bool flag = attacks.Add(specialAttacks[obj]);
			float value = MyTime.time + enemySpecialAttack.initialCooldown;
			((Dictionary<object, float>)(object)cooldowns).Add((object)specialAttacks[obj], value);
			obj++;
			obj2 = obj;
		}
	}

	public unsafe void Tick()
	{
		//IL_03a4: Expected O, but got I
		//IL_03b6: Invalid comparison between F4 and I
		//IL_03da: Expected O, but got I
		//IL_0429: Expected O, but got I4
		//IL_0487: Expected O, but got I4
		if (!enabled)
		{
			return;
		}
		GameManager instance = GameManager.Instance;
		if ((object)GameManager.Instance != null)
		{
			bool flag = GameManager.Instance.IsTimeFreeze();
			if (flag)
			{
				return;
			}
			if (isAttacking == flag)
			{
				bool flag2 = (object)this.enemy == null;
				instance = (GameManager)(object)this.enemy;
				if (!flag2)
				{
					if (this.enemy.IsTeleporting())
					{
						return;
					}
					instance = (GameManager)(object)typeof(MyTime);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rcx_v23 (GameManager)+B8]");
					object obj = 0;
					float num = nextCheckTime;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v36+4]");
					if (num > 0f)
					{
						return;
					}
					Enemy enemy = this.enemy;
					if ((object)this.enemy != null)
					{
						if (enemy.state != EEnemyState.Default)
						{
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rcx_v23 (GameManager)+B8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ rax_v39+4]");
						float num2 = 0f + updateRate;
						nextCheckTime = num2;
						Func<EnemySpecialAttack, int> keySelector = _003C_003Ec._003C_003E9__8_0;
						if (_003C_003Ec._003C_003E9__8_0 == null)
						{
							Func<EnemySpecialAttack, int> func = (_003C_003Ec._003C_003E9__8_0 = delegate(EnemySpecialAttack a)
							{
								//IL_0035: Expected I4, but got O
								if (a == null)
								{
									NullReferenceException ex = new NullReferenceException();
									return (int)ex;
								}
								return a.priority;
							});
							object obj3 = 0;
							keySelector = func;
						}
						IOrderedEnumerable<EnemySpecialAttack> source = Enumerable.OrderBy(attacks, keySelector);
						Func<EnemySpecialAttack, int> keySelector2 = _003C_003Ec._003C_003E9__8_1;
						if (_003C_003Ec._003C_003E9__8_1 == null)
						{
							Func<EnemySpecialAttack, int> func2 = (_003C_003Ec._003C_003E9__8_1 = delegate
							{
								//IL_0026: Expected I4, but got O
								if (MyRandom.random == null)
								{
									NullReferenceException ex = new NullReferenceException();
									return (int)ex;
								}
								return MyRandom.random.Next();
							});
							object obj3 = 0;
							keySelector2 = func2;
						}
						IOrderedEnumerable<EnemySpecialAttack> orderedEnumerable = Enumerable.ThenBy(source, keySelector2);
						List<object> list = Enumerable.ToList((IEnumerable<object>)orderedEnumerable);
						bool flag3 = list == null;
						instance = (GameManager)orderedEnumerable;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
							nint num3 = 0;
							List<object>.Enumerator enumerator = default(List<object>.Enumerator);
							object obj4 = default(object);
							object obj5 = default(object);
							while (true)
							{
								if (enumerator.MoveNext())
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822672F0");
									if (obj4 != null)
									{
										bool flag4 = obj5 == null;
										instance = null;
										if (flag4)
										{
											throw new NullReferenceException();
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v826 @ stack_-60 (System.Object)+10]");
										if ((nint)0 == 0)
										{
											continue;
										}
									}
									bool flag5 = cooldowns == null;
									instance = (GameManager)(object)cooldowns;
									if (!flag5)
									{
										float num4 = ((Dictionary<object, float>)(object)cooldowns).get_Item(obj5);
										bool flag6 = num4 > MyTime.time;
										num3 = 0;
										if (!flag6)
										{
											Enemy enemy2 = this.enemy;
											bool flag7 = (object)this.enemy == null;
											instance = (GameManager)(object)cooldowns;
											if (flag7)
											{
												throw new NullReferenceException();
											}
											instance = (GameManager)(object)enemy2.enemyMovement;
											if ((object)enemy2.enemyMovement == null)
											{
												throw new NullReferenceException();
											}
											if (obj5 == null)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rcx_v23 (GameManager)+DC]");
											nint num5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v826 @ stack_-60 (System.Object)+44]");
											bool flag8 = num5 > 0;
											num3 = 0;
											if (!flag8)
											{
												UseSpecialAttack((EnemySpecialAttack)obj5);
												((List<EnemySpecialAttack>.Enumerator*)(&enumerator))->Dispose();
												return;
											}
										}
										continue;
									}
									throw new NullReferenceException();
								}
								((List<EnemySpecialAttack>.Enumerator*)(&enumerator))->Dispose();
								return;
							}
							throw new NullReferenceException();
						}
					}
				}
			}
			else
			{
				if (!(MyTime.time > attackOverAtTime))
				{
					return;
				}
				isAttacking = false;
				bool flag9 = (object)this.enemy == null;
				instance = (GameManager)(object)this.enemy;
				if (!flag9)
				{
					this.enemy.EndSpecialAttack();
					instance = (GameManager)(object)currentAttack;
					if (currentAttack != null)
					{
						float num6 = MyTime.time + (float)instance.whatIsProjectileObstruction;
						nextCheckTime = num6;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void UseSpecialAttack(EnemySpecialAttack attack)
	{
		GameObject enemyAttack = PoolManager.Instance.GetEnemyAttack(attack);
		if (enemyAttack != null)
		{
			EnemySpecialAttackPrefab component = enemyAttack.GetComponent<EnemySpecialAttackPrefab>();
			component.Set(attack, enemy);
			isAttacking = true;
			currentAttack = attack;
			enemy.StartSpecialAttack();
			float num = MyTime.time + attack.attackChargeTime;
			float num2 = num + attack.endLag;
			attackOverAtTime = num2;
			float num3 = attack.attackCooldown;
			if (attack.attackCooldownMax > attack.attackCooldown)
			{
				float num4 = UnityEngine.Random.Range(attack.attackCooldown, attack.attackCooldownMax);
				num3 = num4;
			}
			float value = num3 + MyTime.time;
			((Dictionary<object, float>)(object)cooldowns).set_Item((object)attack, value);
		}
		else
		{
			string text = "Attasck prefab was null, pool is too small? Attack: " + attack.attackName;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
	}

	private void FinishAttack()
	{
		isAttacking = false;
		enemy.EndSpecialAttack();
		EnemySpecialAttack enemySpecialAttack = currentAttack;
		float num = MyTime.time + enemySpecialAttack.nextSpecialAttackCooldown;
		nextCheckTime = num;
	}
}
