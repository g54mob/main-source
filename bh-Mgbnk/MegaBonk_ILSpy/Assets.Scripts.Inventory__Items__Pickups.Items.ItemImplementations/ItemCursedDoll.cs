using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Pool;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;

public class ItemCursedDoll : ItemBase
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Enemy> _003C_003E9__10_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CTick_003Eb__10_0(Enemy enemy)
		{
			//IL_006f: Expected I4, but got O
			if (enemy == null)
			{
				return true;
			}
			if ((object)enemy != null)
			{
				return enemy.IsDead();
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private int maxNumCursedEnemies;

	private float damageMaxHpPercentage;

	private int enemiesCursedPerDoll;

	private int maxNumCursesPerCheck;

	private DamageContainer reuseDc;

	private string damageSource;

	private HashSet<Enemy> cursedEnemies;

	private float attackCooldown;

	private float nextAttackTime;

	protected override void OnInitOrAmountChanged()
	{
		int num = enemiesCursedPerDoll * amount;
		maxNumCursedEnemies = num;
	}

	public unsafe override void Tick()
	{
		//IL_0054: Expected O, but got I
		//IL_02db: Expected O, but got F4
		//IL_008a: Expected O, but got I
		//IL_02f7: Invalid comparison between F4 and I4
		//IL_0305: Expected O, but got F4
		//IL_094d: Expected I, but got O
		//IL_0963: Expected O, but got I
		//IL_031c: Expected O, but got F4
		//IL_00e9: Expected O, but got I4
		//IL_02a6: Expected O, but got I4
		//IL_02ae: Expected O, but got Ref
		//IL_035b: Expected O, but got I
		//IL_00fd: Expected O, but got F4
		//IL_0119: Invalid comparison between F4 and I4
		//IL_0127: Expected O, but got F4
		//IL_037a: Expected O, but got I
		//IL_013e: Expected O, but got F4
		//IL_0432: Expected O, but got F4
		//IL_03c2: Expected I, but got O
		//IL_015a: Expected O, but got F4
		//IL_08f5: Expected I, but got O
		//IL_0479: Expected I, but got O
		//IL_03e6: Expected O, but got F4
		//IL_04a9: Expected I, but got O
		//IL_01a5: Expected O, but got F4
		//IL_0423: Expected O, but got Ref
		//IL_08be: Expected O, but got I4
		//IL_08cd: Expected I, but got O
		//IL_0599: Expected F4, but got I4
		//IL_05a7: Expected I, but got O
		//IL_01f0: Expected O, but got F4
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_064b: Expected O, but got F4
		//IL_0287: Expected O, but got I4
		//IL_028f: Expected O, but got Ref
		if (nextAttackTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + attackCooldown;
		nextAttackTime = num;
		Dictionary<uint, Enemy> dictionary = (Dictionary<uint, Enemy>)(object)cursedEnemies;
		float num2 = default(float);
		object obj2 = default(object);
		if (cursedEnemies != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.UInt32, Assets.Scripts.Actors.Enemies.Enemy>)+20]");
			if ((nint)0 >= (nint)maxNumCursedEnemies)
			{
				goto IL_07a1;
			}
			dictionary = (Dictionary<uint, Enemy>)(object)EnemyManager.Instance;
			if ((object)EnemyManager.Instance != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.UInt32, Assets.Scripts.Actors.Enemies.Enemy>)+28]");
				dictionary = (Dictionary<uint, Enemy>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.UInt32, Assets.Scripts.Actors.Enemies.Enemy>)+28]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.UInt32, Assets.Scripts.Actors.Enemies.Enemy>)+28]");
					Dictionary<uint, Enemy>.ValueCollection values = ((Dictionary<uint, Enemy>)0).Values;
					if (values != null)
					{
						if (values.Count == 0)
						{
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
						object obj = 0;
						Dictionary<uint, Enemy>.ValueCollection.Enumerator enumerator = default(Dictionary<uint, Enemy>.ValueCollection.Enumerator);
						while (true)
						{
							if (enumerator.MoveNext())
							{
								if (!((UnityEngine.Object)num2 != null))
								{
									continue;
								}
								bool flag = num2 == 0f;
								HashSet<Enemy> hashSet = (HashSet<Enemy>)num2;
								if (flag)
								{
									throw new NullReferenceException();
								}
								if (((Enemy)num2).IsDead() || ((Enemy)num2).IsTeleporting())
								{
									continue;
								}
								bool flag2 = cursedEnemies == null;
								hashSet = cursedEnemies;
								if (flag2)
								{
									throw new NullReferenceException();
								}
								if (((HashSet<object>)(object)cursedEnemies).Contains((object)num2))
								{
									continue;
								}
								hashSet = cursedEnemies;
								if (cursedEnemies == null)
								{
									throw new NullReferenceException();
								}
								bool flag3 = cursedEnemies.Add((Enemy)num2);
								obj++;
								if ((nint)obj < maxNumCursesPerCheck)
								{
									dictionary = (Dictionary<uint, Enemy>)(object)cursedEnemies;
									if (cursedEnemies != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rcx_v8 (System.Collections.Generic.Dictionary`2<System.UInt32, Assets.Scripts.Actors.Enemies.Enemy>)+20]");
										if ((nint)0 >= (nint)maxNumCursedEnemies)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
											obj2 = 0;
											dictionary = (Dictionary<uint, Enemy>)(&enumerator);
											break;
										}
										continue;
									}
									hashSet = (HashSet<Enemy>)(object)dictionary;
									throw new NullReferenceException();
								}
							}
							enumerator.Dispose();
							obj2 = 0;
							dictionary = (Dictionary<uint, Enemy>)(&enumerator);
							break;
						}
						goto IL_07a1;
					}
				}
			}
		}
		goto IL_069c;
		IL_07a1:
		if (cursedEnemies != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18105BB00");
			float num3 = num2;
			HashSet<object>.Enumerator enumerator2 = default(HashSet<object>.Enumerator);
			HashSet<object>.Enumerator enumerator3 = default(HashSet<object>.Enumerator);
			while (enumerator2.MoveNext())
			{
				if (!((UnityEngine.Object)num2 != null))
				{
					continue;
				}
				bool flag4 = num2 == 0f;
				UnityEngine.Object obj3 = (UnityEngine.Object)num2;
				if (!flag4)
				{
					if (((Enemy)num2).IsDead())
					{
						continue;
					}
					obj3 = PoolManager.Instance;
					if ((object)PoolManager.Instance != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rcx_v10 (UnityEngine.Object)+1F0]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rcx_v10 (UnityEngine.Object)+1F0]");
						obj3 = (UnityEngine.Object)0;
						if (!flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rcx_v10 (UnityEngine.Object)+1F0]");
							GameObject gameObject = ((ObjectPool<GameObject>)0).Get();
							nint num4;
							if (gameObject != null)
							{
								bool flag6 = (object)gameObject == null;
								num4 = (nint)gameObject;
								if (flag6)
								{
									throw new NullReferenceException();
								}
								Transform transform = gameObject.transform;
								Vector3 headPosition = ((Enemy)num2).GetHeadPosition();
								bool flag7 = (object)transform == null;
								num4 = (nint)(&obj2);
								if (flag7)
								{
									throw new NullReferenceException();
								}
								transform.position = (Vector3)(&enumerator3);
							}
							bool flag8 = ((Enemy)num2).IsBoss();
							DamageContainer damageContainer = reuseDc;
							if (!flag8)
							{
								float[] array = new float[1];
								bool flag9 = array == null;
								num4 = (nint)typeof(float[]);
								if (flag9)
								{
									throw new NullReferenceException();
								}
								bool flag10 = array.Length <= 0;
								num4 = (nint)typeof(float[]);
								if (flag10)
								{
									throw new IndexOutOfRangeException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ stack_-B8 (System.Single)+84]");
								num3 = (array[0] = 0f * damageMaxHpPercentage);
								if (array.Length != 0)
								{
									for (num4 = 1; num4 < array.Length; num4++)
									{
										if (num4 < array.Length)
										{
											if (array[num4] > num3)
											{
												if (num4 >= array.Length)
												{
													throw new IndexOutOfRangeException();
												}
												num3 = array[num4];
											}
											continue;
										}
										throw new IndexOutOfRangeException();
									}
								}
								else
								{
									num3 = 0f;
									num4 = (nint)typeof(float[]);
								}
								if (reuseDc == null)
								{
									throw new NullReferenceException();
								}
							}
							else
							{
								num4 = (nint)MyPlayer.Instance;
								bool flag11 = (object)MyPlayer.Instance == null;
								obj3 = MyPlayer.Instance;
								if (flag11)
								{
									throw new NullReferenceException();
								}
								if (reuseDc == null)
								{
									throw new NullReferenceException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1579 @ rcx_v14 (Il2CppClass<System.Single[]>)+12C]");
								num3 = 0f * 0.7f;
							}
							object obj4 = 28;
							num4 = (nint)reuseDc;
							if (reuseDc != null)
							{
								num4 += 40;
								DamageContainer damageContainer2 = reuseDc;
								if (reuseDc != null)
								{
									damageContainer2.damageEffect = EDamageEffect.Cursed;
									((Enemy)num2).DamageFromPlayerOther(reuseDc);
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
			((HashSet<Enemy>.Enumerator*)(&enumerator2))->Dispose();
			Predicate<object> match = (Predicate<object>)_003C_003Ec._003C_003E9__10_0;
			bool flag12 = _003C_003Ec._003C_003E9__10_0 != null;
			dictionary = (Dictionary<uint, Enemy>)(object)typeof(_003C_003Ec);
			if (!flag12)
			{
				Predicate<Enemy> predicate = (_003C_003Ec._003C_003E9__10_0 = (Predicate<object>)delegate(Enemy enemy)
				{
					//IL_006f: Expected I4, but got O
					if (enemy == null)
					{
						return true;
					}
					if ((object)enemy == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					return enemy.IsDead();
				});
				nint num5 = (nint)typeof(_003C_003Ec);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1382 @ rax_v64 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemCursedDoll+<>c>)+B8]");
				dictionary = (Dictionary<uint, Enemy>)((nint)0 + (nint)8);
				match = (Predicate<object>)predicate;
			}
			if (cursedEnemies != null)
			{
				int num6 = ((HashSet<object>)(object)cursedEnemies).RemoveWhere(match);
				return;
			}
		}
		goto IL_069c;
		IL_069c:
		throw new NullReferenceException();
	}

	private void OnEnemyDied(Enemy enemy)
	{
		if (((HashSet<object>)(object)cursedEnemies).Contains((object)enemy))
		{
			bool flag = ((HashSet<object>)(object)cursedEnemies).Remove((object)enemy);
		}
	}

	public override void Init()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy> b = OnEnemyDied;
		Delegate obj = Delegate.Combine(Enemy.A_EnemyReleasedFromPool, b);
		if ((object)obj == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action = default(Action<Enemy>);
		if (action != null)
		{
			Enemy.A_EnemyReleasedFromPool = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public override void Cleanup()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy> value = OnEnemyDied;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyReleasedFromPool, value);
		if ((object)obj == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action = default(Action<Enemy>);
		if (action != null)
		{
			Enemy.A_EnemyReleasedFromPool = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public unsafe ItemCursedDoll(ItemInventory itemInventoryRef)
	{
		//IL_0089: Expected O, but got Ref
		//IL_0018: Expected O, but got Ref
		damageMaxHpPercentage = 0.3f;
		enemiesCursedPerDoll = 2;
		maxNumCursesPerCheck = 5;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		DamageContainer damageContainer = new DamageContainer(1f, text);
		reuseDc = damageContainer;
		object obj2 = default(object);
		damageSource = ((Enum)(&obj2)).ToString();
		cursedEnemies = (HashSet<Enemy>)(object)new HashSet<object>();
		attackCooldown = 1f;
		base._002Ector(itemInventoryRef);
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
		float num = damageMaxHpPercentage * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj = default(object);
		string text = $"{obj}%";
		bool flag = dictionary == null;
		object obj2 = null;
		object obj3 = obj;
		string text2 = "{0}%";
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
