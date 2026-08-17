using System;
using System.Collections.Generic;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Game.Combat.EnemyDebuffs;

public static class DebuffFactory
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public EDebuff eDebuff;

		public ObjectPool<EnemyDebuff> newPool;

		public int maxObjects;

		internal EnemyDebuff _003CCreatePool_003Eb__0()
		{
			ObjectPool<EnemyDebuff> objectPool = newPool;
			if (newPool != null)
			{
				if (objectPool._003CCountAll_003Ek__BackingField < maxObjects)
				{
					return CreateDebuff(eDebuff);
				}
				return null;
			}
			return (EnemyDebuff)(object)new NullReferenceException();
		}
	}

	private static Dictionary<EDebuff, ObjectPool<EnemyDebuff>> debuffPools;

	private static int created;

	private static int returned;

	private static int getted;

	public static void Init()
	{
		//IL_0124: Expected I, but got O
		Action b = Reset;
		Delegate obj = Delegate.Combine(GameManager.A_StageStarted, b);
		if ((object)obj == null)
		{
			GameManager.A_StageStarted = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			GameManager.A_StageStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public static void Cleanup()
	{
		//IL_0124: Expected I, but got O
		Action value = Reset;
		Delegate obj = Delegate.Remove(GameManager.A_StageStarted, value);
		if ((object)obj == null)
		{
			GameManager.A_StageStarted = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			GameManager.A_StageStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public static void Reset()
	{
		if (debuffPools != null)
		{
			Dictionary<EDebuff, ObjectPool<EnemyDebuff>>.ValueCollection values = debuffPools.Values;
			if (values != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
				Dictionary<EDebuff, ObjectPool<EnemyDebuff>>.ValueCollection.Enumerator enumerator = default(Dictionary<EDebuff, ObjectPool<EnemyDebuff>>.ValueCollection.Enumerator);
				ObjectPool<EnemyDebuff> objectPool = default(ObjectPool<EnemyDebuff>);
				while (enumerator.MoveNext())
				{
					if (objectPool != null)
					{
						objectPool.Clear();
						continue;
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				if (debuffPools != null)
				{
					debuffPools.Clear();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe static EnemyDebuff GetDebuff(EDebuff eDebuff, Enemy enemy, DamageContainer dc, float duration, int stacks)
	{
		//IL_023b: Expected O, but got Ref
		EDebuff key;
		Enemy enemy2;
		if (debuffPools != null)
		{
			bool flag = ((Dictionary<System.Int32Enum, object>)(object)debuffPools).ContainsKey((System.Int32Enum)eDebuff);
			key = eDebuff;
			enemy2 = enemy;
			if (flag)
			{
				goto IL_02e8;
			}
			_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass5_0();
			if (CS_0024_003C_003E8__locals10 != null)
			{
				int maxObjects = EnemyManager.maxNumEnemiesPooled + EnemyManager.maxNumEnemiesPooled;
				CS_0024_003C_003E8__locals10.maxObjects = maxObjects;
				CS_0024_003C_003E8__locals10.eDebuff = eDebuff;
				CS_0024_003C_003E8__locals10.newPool = null;
				Func<EnemyDebuff> createFunc = delegate
				{
					ObjectPool<EnemyDebuff> newPool2 = CS_0024_003C_003E8__locals10.newPool;
					return (EnemyDebuff)((CS_0024_003C_003E8__locals10.newPool != null) ? ((object)((newPool2._003CCountAll_003Ek__BackingField < CS_0024_003C_003E8__locals10.maxObjects) ? CreateDebuff(CS_0024_003C_003E8__locals10.eDebuff) : null)) : ((object)new NullReferenceException()));
				};
				Action<EnemyDebuff> actionOnGet = OnTakeFromPool;
				Action<EnemyDebuff> actionOnRelease = OnReturnedToPool;
				Action<EnemyDebuff> action = OnDestroyPoolObject;
				Action<EnemyDebuff> actionOnDestroy = default(Action<EnemyDebuff>);
				bool collectionCheck = default(bool);
				int defaultCapacity = default(int);
				int maxSize = default(int);
				ObjectPool<EnemyDebuff> newPool = new ObjectPool<EnemyDebuff>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
				CS_0024_003C_003E8__locals10.newPool = newPool;
				if (debuffPools != null)
				{
					((Dictionary<System.Int32Enum, object>)(object)debuffPools).Add((System.Int32Enum)eDebuff, (object)CS_0024_003C_003E8__locals10.newPool);
					key = eDebuff;
					enemy2 = enemy;
					goto IL_02e8;
				}
			}
		}
		goto IL_026a;
		IL_02e8:
		if (debuffPools != null)
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)debuffPools).get_Item((System.Int32Enum)key);
			if (obj != null)
			{
				EnemyDebuff enemyDebuff = ((ObjectPool<EnemyDebuff>)obj).Get();
				if (enemyDebuff != null)
				{
					enemyDebuff._003CticksLeft_003Ek__BackingField = 0;
					enemyDebuff.enemy = enemy2;
					int numStacks = default(int);
					enemyDebuff.AddStacks(numStacks);
					int ticks = enemyDebuff.GetTicks(duration);
					if (ticks > enemyDebuff._003CticksLeft_003Ek__BackingField)
					{
						int ticks2 = enemyDebuff.GetTicks(duration);
						enemyDebuff._003CticksLeft_003Ek__BackingField = ticks2;
					}
					enemyDebuff.OnRefresh();
					enemyDebuff.OnAdded();
				}
				else
				{
					object obj2 = default(object);
					string text = ((Enum)(&obj2)).ToString();
					string text2 = "Failed to get debuff, maybe pool limit reached: " + text;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					enemyDebuff = null;
				}
				return enemyDebuff;
			}
		}
		goto IL_026a;
		IL_026a:
		return (EnemyDebuff)(object)new NullReferenceException();
	}

	private static ObjectPool<EnemyDebuff> CreatePool(EDebuff eDebuff, int maxObjects)
	{
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass5_0();
		if (CS_0024_003C_003E8__locals10 != null)
		{
			CS_0024_003C_003E8__locals10.eDebuff = eDebuff;
			CS_0024_003C_003E8__locals10.maxObjects = maxObjects;
			CS_0024_003C_003E8__locals10.newPool = null;
			Func<EnemyDebuff> createFunc = delegate
			{
				ObjectPool<EnemyDebuff> newPool2 = CS_0024_003C_003E8__locals10.newPool;
				return (EnemyDebuff)((CS_0024_003C_003E8__locals10.newPool != null) ? ((object)((newPool2._003CCountAll_003Ek__BackingField < CS_0024_003C_003E8__locals10.maxObjects) ? CreateDebuff(CS_0024_003C_003E8__locals10.eDebuff) : null)) : ((object)new NullReferenceException()));
			};
			Action<EnemyDebuff> actionOnGet = OnTakeFromPool;
			Action<EnemyDebuff> actionOnRelease = OnReturnedToPool;
			Action<EnemyDebuff> action = OnDestroyPoolObject;
			Action<EnemyDebuff> actionOnDestroy = default(Action<EnemyDebuff>);
			bool collectionCheck = default(bool);
			int defaultCapacity = default(int);
			int maxSize = default(int);
			ObjectPool<EnemyDebuff> newPool = new ObjectPool<EnemyDebuff>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, collectionCheck, defaultCapacity, maxSize);
			CS_0024_003C_003E8__locals10.newPool = newPool;
			return CS_0024_003C_003E8__locals10.newPool;
		}
		return (ObjectPool<EnemyDebuff>)(object)new NullReferenceException();
	}

	private static EnemyDebuff CreatePooledItem(EDebuff eDebuff, ObjectPool<EnemyDebuff> pool, int maxSize)
	{
		if (pool != null)
		{
			if (pool._003CCountAll_003Ek__BackingField < maxSize)
			{
				return CreateDebuff(eDebuff);
			}
			return null;
		}
		return (EnemyDebuff)(object)new NullReferenceException();
	}

	public static void ReturnDebuff(EDebuff eDebuff, EnemyDebuff enemyDebuff)
	{
		object obj = ((Dictionary<System.Int32Enum, object>)(object)debuffPools).get_Item((System.Int32Enum)eDebuff);
		((ObjectPool<EnemyDebuff>)obj).Release(enemyDebuff);
	}

	private unsafe static EnemyDebuff CreateDebuff(EDebuff eDebuff)
	{
		//IL_0114: Expected O, but got I4
		//IL_027a: Expected I, but got O
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0267: Expected I, but got O
		//IL_0033: Expected I, but got O
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_02a1: Expected O, but got Ref
		//IL_0074: Expected O, but got I4
		//IL_01d5: Expected O, but got I4
		//IL_01b4: Expected I, but got O
		string damageSource = default(string);
		EnemyDebuff result;
		if (eDebuff > EDebuff.Stun)
		{
			if (eDebuff != EDebuff.Echo)
			{
				if (eDebuff != EDebuff.Bloodmark)
				{
					goto IL_027f;
				}
				DebuffBloodmark debuffBloodmark = new DebuffBloodmark();
				DamageContainer damageContainer = new DamageContainer(0f, damageSource);
				damageContainer.damageSource = DebuffBloodmark.damageSource;
				damageContainer.procCoefficient = 0f;
				damageContainer.direction = (Vector3)0;
				_ = 0;
				damageContainer.crit = false;
				damageContainer.knockback = 0f;
				damageContainer.enemy = null;
				damageContainer.damageEffect = EDamageEffect.None;
				damageContainer.damageBlockedByArmor = 0;
				damageContainer.isExecute = false;
				damageContainer.canProcJoe = false;
				debuffBloodmark.dc = damageContainer;
				debuffBloodmark.baseDamageMultiplier = 0.75f;
				result = debuffBloodmark;
				goto IL_0330;
			}
			nint num = (nint)typeof(DebuffEcho);
		}
		else
		{
			object obj = eDebuff - 1;
			bool flag = eDebuff == EDebuff.Poison;
			if (!flag)
			{
				object obj2 = obj - 1;
				nint num;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						if ((nint)obj3 == 1)
						{
							DebuffFire debuffFire = new DebuffFire();
							DamageContainer damageContainer2 = new DamageContainer(0f, damageSource);
							damageContainer2.damageSource = DebuffFire.damageSource;
							damageContainer2.procCoefficient = 0f;
							damageContainer2.direction = (Vector3)0;
							_ = 0;
							damageContainer2.crit = false;
							damageContainer2.knockback = 0f;
							damageContainer2.enemy = null;
							damageContainer2.damageEffect = EDamageEffect.None;
							damageContainer2.damageBlockedByArmor = 0;
							damageContainer2.isExecute = false;
							damageContainer2.canProcJoe = false;
							debuffFire.dc = damageContainer2;
							result = debuffFire;
							goto IL_0330;
						}
						if (eDebuff == EDebuff.Stun)
						{
							num = (nint)typeof(DebuffStun);
							goto IL_0317;
						}
					}
					goto IL_027f;
				}
				num = (nint)typeof(DebuffIce);
			}
			else
			{
				nint num = (nint)typeof(DebuffPoison);
			}
		}
		goto IL_0317;
		IL_0317:
		result = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		goto IL_0330;
		IL_027f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002360");
		object obj4 = default(object);
		string text = ((Enum)(&obj4)).ToString();
		string message = "Debuff factory not implemented for: " + text;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		Exception ex = new Exception(message);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
		IL_0330:
		return result;
	}

	private static void OnTakeFromPool(EnemyDebuff obj)
	{
		if (obj != null)
		{
			obj._003CticksLeft_003Ek__BackingField = 0;
			obj.OnResetState();
		}
	}

	private static void OnReturnedToPool(EnemyDebuff obj)
	{
	}

	private static void OnDestroyPoolObject(EnemyDebuff obj)
	{
	}

	static DebuffFactory()
	{
		Dictionary<EDebuff, ObjectPool<EnemyDebuff>> dictionary = new Dictionary<EDebuff, ObjectPool<EnemyDebuff>>();
		debuffPools = dictionary;
	}
}
