using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Utility;

namespace Assets.Scripts.Game.Spawning.New;

public abstract class BaseSummoner
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Comparison<EnemyCard> _003C_003E9__21_0;

		public static Comparison<EnemyCard> _003C_003E9__22_0;

		public static Func<EnemyCard, float> _003C_003E9__27_0;

		public static Func<EnemyCard, float> _003C_003E9__27_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe int _003CGenerateCards_003Eb__21_0(EnemyCard card1, EnemyCard card2)
		{
			//IL_0073: Expected I4, but got O
			//IL_005c: Expected Ref, but got F4
			if (card1 != null && card2 != null)
			{
				float num = (float)card1 + 36f;
				return ((float*)num)->CompareTo(card2.cost);
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal unsafe int _003CRefreshCardWeights_003Eb__22_0(EnemyCard card1, EnemyCard card2)
		{
			//IL_0073: Expected I4, but got O
			//IL_005c: Expected Ref, but got F4
			if (card1 != null && card2 != null)
			{
				float num = (float)card1 + 36f;
				return ((float*)num)->CompareTo(card2.cost);
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}

		internal float _003CGetRandomCard_003Eb__27_0(EnemyCard c)
		{
			return c.cost;
		}

		internal float _003CGetRandomCard_003Eb__27_1(EnemyCard card)
		{
			return card.weight;
		}
	}

	protected float credits;

	private List<EnemyCard> cards;

	private float giveCreditsTimer;

	private float spendCreditsTimer;

	public const int maxEnemiesPerSecond = 500;

	public const int maxEnemiesPerCycle = 200;

	protected int enemiesThisSecond;

	private int nextSecond;

	protected int id;

	public bool slowmode;

	private float slowmodeMultiplier;

	private float slowmodeOverAtTime;

	private bool isWaveMode;

	private float waveModeOverAtTime;

	private List<EnemyCard> waveModeCards;

	protected List<EEnemy> currentEnemies;

	private List<Enemy> spawnedEnemies;

	public BaseSummoner(int id, List<EEnemy> defaultEnemies)
	{
		//IL_0236: Expected O, but got I4
		//IL_023f: Expected O, but got I4
		//IL_0255: Expected I, but got O
		//IL_011d: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_013c: Expected I, but got O
		//IL_019c: Expected O, but got I4
		//IL_01a5: Expected O, but got I4
		//IL_01bb: Expected I, but got O
		//IL_01f4: Expected O, but got I4
		//IL_01fd: Expected O, but got I4
		//IL_0213: Expected I, but got O
		slowmodeMultiplier = 0.5f;
		List<Enemy> list = new List<Enemy>();
		spawnedEnemies = list;
		TickExtra();
		Init();
		List<EEnemy> list2 = (List<EEnemy>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)defaultEnemies);
		currentEnemies = list2;
		this.id = id;
		float initialCredits = GetInitialCredits();
		float num = default(float);
		credits = num;
		List<EEnemy> enemies = GetEnemies();
		List<EnemyCard> list3 = GenerateCards(enemies);
		cards = list3;
		Action<EStat> b = OnStatUpdated;
		Delegate obj = Delegate.Combine(PlayerStatsNew.A_StatUpdate, b);
		nint num2;
		object obj2;
		object obj3;
		Delegate obj4;
		nint num3;
		if ((object)obj == null)
		{
			PlayerStatsNew.A_StatUpdate = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStat> action = default(Action<EStat>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				obj2 = 0;
				obj3 = 0;
				obj4 = obj;
				num2 = (nint)typeof(Action<EStat>);
				goto IL_02c1;
			}
			PlayerStatsNew.A_StatUpdate = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			obj2 = 0;
			obj3 = 0;
			obj4 = obj;
			num3 = (nint)typeof(Action<EStat>);
			if (flag)
			{
				goto IL_027e;
			}
		}
		Action<PlayerInventory> b2 = OnPlayerInventoryInitialized;
		Delegate obj6 = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b2);
		if ((object)obj6 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerInventory> action2 = default(Action<PlayerInventory>);
		bool flag2 = action2 == null;
		obj2 = 0;
		obj3 = 0;
		obj4 = obj6;
		num3 = (nint)typeof(Action<PlayerInventory>);
		if (flag2)
		{
			goto IL_02b1;
		}
		MyPlayer.A_PlayerInventoryInitialized = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		obj2 = 0;
		obj3 = 0;
		obj4 = obj6;
		num2 = (nint)typeof(Action<PlayerInventory>);
		if (!flag3)
		{
			return;
		}
		goto IL_02c1;
		IL_027e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num3 = num2;
		goto IL_02b1;
		IL_02b1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_027e;
	}

	public void Cleanup()
	{
		//IL_01a6: Expected I, but got O
		//IL_01b7: Expected O, but got I4
		//IL_01c0: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_010c: Expected I, but got O
		//IL_011d: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_0164: Expected I, but got O
		//IL_0175: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		Action<EStat> value = OnStatUpdated;
		Delegate obj = Delegate.Remove(PlayerStatsNew.A_StatUpdate, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerStatsNew.A_StatUpdate = (Action<EStat>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStat> action = default(Action<EStat>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EStat>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			PlayerStatsNew.A_StatUpdate = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<EStat>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01ed;
			}
		}
		Action<PlayerInventory> value2 = OnPlayerInventoryInitialized;
		Delegate obj6 = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value2);
		if ((object)obj6 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = (Action<PlayerInventory>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerInventory> action2 = default(Action<PlayerInventory>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		MyPlayer.A_PlayerInventoryInitialized = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0230;
		IL_01ed:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0220;
		IL_0220:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01ed;
	}

	public void Tick()
	{
		//IL_0252: Invalid comparison between F4 and I4
		//IL_01b7: Expected I4, but got F8
		if (isWaveMode && !(MyTime.time < waveModeOverAtTime))
		{
			isWaveMode = false;
		}
		bool flag = !slowmode;
		float num = 1f;
		if (!flag)
		{
			if (MyTime.time < slowmodeOverAtTime)
			{
				num = slowmodeMultiplier;
			}
			else
			{
				slowmode = false;
				num = 1f;
			}
		}
		float num2 = num * MyTime.fixedDeltaTime;
		float num3 = (giveCreditsTimer = num2 + giveCreditsTimer);
		float num4 = num * MyTime.fixedDeltaTime;
		float num5 = num4 + spendCreditsTimer;
		spendCreditsTimer = num5;
		if (!(num3 < 1f))
		{
			if (!EnemyManager.Instance.HasMaxEnemies())
			{
				float baseCreditsPerSecond = GetBaseCreditsPerSecond();
				float multiplier = GetMultiplier();
				float num6 = multiplier * num3;
				num3 = (credits = num6 + credits);
			}
			giveCreditsTimer = 0f;
		}
		float summonInterval = GetSummonInterval();
		if (!(spendCreditsTimer < num3))
		{
			List<Enemy> list = SpendCredits();
			spendCreditsTimer = 0f;
		}
		if (MyTime.time > (float)nextSecond)
		{
			double num7 = Math.Ceiling(MyTime.time);
			enemiesThisSecond = 0;
			double num8 = num7 + 1.0;
			nextSecond = (int)num8;
		}
		TickExtra();
	}

	protected virtual void TickExtra()
	{
	}

	protected void GenerateCardsForSummoner(List<EEnemy> enemies)
	{
		List<EnemyCard> list = GenerateCards(enemies);
		cards = list;
	}

	protected unsafe virtual List<EnemyCard> GenerateCards(List<EEnemy> enemies)
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_06bf: Expected I, but got O
		//IL_06d5: Expected O, but got I
		//IL_0566: Expected I4, but got F4
		//IL_0573: Expected F4, but got I4
		//IL_019c: Expected O, but got I4
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Expected O, but got Unknown
		//IL_061a: Expected I4, but got F4
		//IL_0627: Expected F4, but got I4
		List<EnemyCard> list = new List<EnemyCard>();
		bool flag = enemies == null;
		List<EnemyCard> list2 = list;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
			EEnemy eEnemy2 = default(EEnemy);
			EEnemy eEnemy = eEnemy2;
			List<EEnemy>.Enumerator enumerator = default(List<EEnemy>.Enumerator);
			while (enumerator.MoveNext())
			{
				if ((object)DataManager.Instance != null)
				{
					EnemyData enemyData = DataManager.Instance.GetEnemyData(eEnemy2);
					EnemyCard enemyCard = new EnemyCard(null, isElite: false);
					enemyCard.costInfluenceOnWeight = 0.6f;
					enemyCard.cost = 1f;
					enemyCard.weight = 1f;
					enemyCard.isElite = false;
					enemyCard.enemy = enemyData;
					DataManager dataManager = (DataManager)(enemyCard + 24);
					EnemyData enemy = enemyCard.enemy;
					if ((object)enemyCard.enemy != null)
					{
						enemyCard.cost = enemy.creditCost;
						if ((object)enemyCard.enemy != null)
						{
							enemyCard.weight = 1f;
							if (enemyCard.isElite)
							{
								bool flag2 = PlayerStats.HasStats();
								bool flag3 = !flag2;
								float num = 1f;
								dataManager = null;
								if (!flag3)
								{
									float stat = PlayerStats.GetStat(EStat.EliteSpawnIncrease);
									num = stat;
									dataManager = (DataManager)39;
								}
								eEnemy = (EEnemy)(enemyCard.cost + enemyCard.cost);
								enemyCard.cost = (float)eEnemy;
								float num2 = num * 0.04f;
								float weight = num2 * enemyCard.weight;
								enemyCard.weight = weight;
							}
							if (list != null)
							{
								int version = list._version + 1;
								list._version = version;
								list2 = (List<EnemyCard>)(object)list._items;
								if (list._items != null)
								{
									bool isElite;
									if (list._size >= list2._size)
									{
										((List<object>)(object)list).AddWithResize((object)enemyCard);
										isElite = false;
									}
									else
									{
										int size = list._size + 1;
										list._size = size;
										if (list._size >= list2._size)
										{
											throw new IndexOutOfRangeException();
										}
										isElite = false;
									}
									EnemyCard enemyCard2 = new EnemyCard(null, isElite);
									enemyCard2.costInfluenceOnWeight = 0.6f;
									enemyCard2.cost = 1f;
									enemyCard2.weight = 1f;
									enemyCard2.isElite = true;
									enemyCard2.enemy = enemyData;
									list2 = (List<EnemyCard>)(enemyCard2 + 24);
									EnemyData enemy2 = enemyCard2.enemy;
									if ((object)enemyCard2.enemy != null)
									{
										enemyCard2.cost = enemy2.creditCost;
										if ((object)enemyCard2.enemy != null)
										{
											enemyCard2.weight = 1f;
											if (enemyCard2.isElite)
											{
												bool flag4 = PlayerStats.HasStats();
												bool flag5 = !flag4;
												float num3 = 1f;
												if (!flag5)
												{
													float stat2 = PlayerStats.GetStat(EStat.EliteSpawnIncrease);
													num3 = stat2;
												}
												eEnemy = (EEnemy)(enemyCard2.cost + enemyCard2.cost);
												enemyCard2.cost = (float)eEnemy;
												float num4 = num3 * 0.04f;
												float weight = num4 * enemyCard2.weight;
												enemyCard2.weight = weight;
											}
											int version2 = list._version + 1;
											list._version = version2;
											list2 = (List<EnemyCard>)(object)list._items;
											if (list._items != null)
											{
												if (list._size >= list2._size)
												{
													((List<object>)(object)list).AddWithResize((object)enemyCard2);
													continue;
												}
												int size2 = list._size + 1;
												list._size = size2;
												if (list._size < list2._size)
												{
													continue;
												}
												throw new IndexOutOfRangeException();
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
			enumerator.Dispose();
			Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__21_0;
			bool flag6 = _003C_003Ec._003C_003E9__21_0 != null;
			list2 = (List<EnemyCard>)(object)typeof(_003C_003Ec);
			if (!flag6)
			{
				Comparison<EnemyCard> comparison2 = (_003C_003Ec._003C_003E9__21_0 = delegate(EnemyCard card1, EnemyCard card2)
				{
					//IL_0073: Expected I4, but got O
					//IL_005c: Expected Ref, but got F4
					if (card1 == null || card2 == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (int)ex;
					}
					float num6 = (float)card1 + 36f;
					return ((float*)num6)->CompareTo(card2.cost);
				});
				nint num5 = (nint)typeof(_003C_003Ec);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ rax_v41 (Il2CppClass<Assets.Scripts.Game.Spawning.New.BaseSummoner+<>c>)+B8]");
				list2 = (List<EnemyCard>)((nint)0 + (nint)8);
				comparison = (Comparison<object>)comparison2;
			}
			if (list != null)
			{
				((List<object>)(object)list).Sort(comparison);
				return list;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void RefreshCardWeights()
	{
		//IL_0052: Expected O, but got I
		//IL_0177: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (obj == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ stack_-78+18]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v30+B8]");
				_ = 0;
				_ = 1065353216;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ stack_-78+20]");
				if ((nint)0 != 0)
				{
					bool flag = PlayerStats.HasStats();
					bool flag2 = !flag;
					float num = 1f;
					if (!flag2)
					{
						float stat = PlayerStats.GetStat(EStat.EliteSpawnIncrease);
						num = stat;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ stack_-78+24]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ stack_-78+24]");
					object obj3 = num2 + 0;
					float num3 = num * 0.04f;
					float num4 = num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ stack_-78+28]");
					float num5 = num4 * 0f;
				}
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__22_0;
			if (_003C_003Ec._003C_003E9__22_0 == null)
			{
				comparison = (Comparison<object>)(_003C_003Ec._003C_003E9__22_0 = delegate(EnemyCard card1, EnemyCard card2)
				{
					//IL_0073: Expected I4, but got O
					//IL_005c: Expected Ref, but got F4
					if (card1 == null || card2 == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (int)ex;
					}
					float num6 = (float)card1 + 36f;
					return ((float*)num6)->CompareTo(card2.cost);
				});
			}
			((List<object>)(object)cards).Sort(comparison);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			while (enumerator.MoveNext())
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			return;
		}
		throw new NullReferenceException();
	}

	public void AddCredits()
	{
		if (!EnemyManager.Instance.HasMaxEnemies())
		{
			float baseCreditsPerSecond = GetBaseCreditsPerSecond();
			float multiplier = GetMultiplier();
			object obj = default(object);
			float num = multiplier * (float)obj;
			float num2 = num + credits;
			credits = num2;
		}
	}

	public float GetCreditsPerSecond()
	{
		float baseCreditsPerSecond = GetBaseCreditsPerSecond();
		float multiplier = GetMultiplier();
		object obj = default(object);
		return multiplier * (float)obj;
	}

	public virtual List<Enemy> SpendCredits(bool useWeights = true)
	{
		//IL_0084: Invalid comparison between F4 and I4
		//IL_0096: Expected O, but got I4
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Expected O, but got Unknown
		//IL_020f: Invalid comparison between F4 and I4
		List<Enemy> list = spawnedEnemies;
		if (spawnedEnemies != null)
		{
			int version = list._version + 1;
			list._version = version;
			list._size = 0;
			if (list._size > 0)
			{
				Array.Clear(list._items, 0, list._size);
			}
			bool flag = !(credits > 0f);
			object obj = 0;
			if (!flag)
			{
				EEnemyFlag flag3 = default(EEnemyFlag);
				bool useDirectionBias = default(bool);
				while (enemiesThisSecond < 500 && (nint)obj < 200)
				{
					if ((object)EnemyManager.Instance != null)
					{
						if (EnemyManager.Instance.HasMaxEnemies() && !ForceSpawn())
						{
							break;
						}
						EnemyCard randomCard = GetRandomCard(useWeights);
						if (randomCard == null)
						{
							break;
						}
						float num = credits - randomCard.cost;
						credits = num;
						bool forceSpawn = ForceSpawn();
						bool flag2 = UseDirectionBias();
						if ((object)EnemyManager.Instance != null)
						{
							Enemy item = EnemyManager.Instance.SpawnEnemy(randomCard.enemy, id, forceSpawn, flag3, useDirectionBias);
							if (spawnedEnemies != null)
							{
								spawnedEnemies.Add(item);
								int num2 = enemiesThisSecond + 1;
								enemiesThisSecond = num2;
								obj++;
								if (!(credits > 0f))
								{
									break;
								}
								continue;
							}
						}
					}
					goto IL_022a;
				}
			}
			return spawnedEnemies;
		}
		goto IL_022a;
		IL_022a:
		return (List<Enemy>)(object)new NullReferenceException();
	}

	protected unsafe EnemyCard GetRandomCard(bool useWeights)
	{
		//IL_0247: Expected O, but got I4
		//IL_0275: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_02db: Expected O, but got Ref
		//IL_003a: Expected O, but got Ref
		//IL_0082: Expected O, but got Ref
		//IL_014b: Expected O, but got I4
		//IL_0167: Expected O, but got Ref
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		//IL_018f: Invalid comparison between O and F4
		List<EnemyCard> list = new List<EnemyCard>();
		bool flag = isWaveMode;
		List<EnemyCard>.Enumerator enumerator = (List<EnemyCard>.Enumerator)72;
		if (!flag)
		{
			enumerator = (List<EnemyCard>.Enumerator)24;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v5 (System.Collections.Generic.List`1<Assets.Scripts.Game.Spawning.New.EnemyCard>+Enumerator<Assets.Scripts.Game.Spawning.New.EnemyCard>)+this @ rcx (Assets.Scripts.Game.Spawning.New.BaseSummoner)]");
		bool flag2 = (nint)0 == 0;
		List<EnemyCard>.Enumerator enumerator2 = (List<EnemyCard>.Enumerator)24;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
			EnemyCard enemyCard = default(EnemyCard);
			while (enumerator3.MoveNext())
			{
				bool flag3 = enemyCard == null;
				List<object>.Enumerator enumerator4 = (List<object>.Enumerator)(&enumerator3);
				if (!flag3)
				{
					if (!(credits < enemyCard.cost))
					{
						bool flag4 = list == null;
						enumerator4 = (List<object>.Enumerator)(&enumerator3);
						if (flag4)
						{
							throw new NullReferenceException();
						}
						list.Add(enemyCard);
					}
					continue;
				}
				throw new NullReferenceException();
			}
			((List<EnemyCard>.Enumerator*)(&enumerator3))->Dispose();
			bool flag5 = list == null;
			enumerator2 = (List<EnemyCard>.Enumerator)(&enumerator3);
			if (!flag5)
			{
				if (list._size != 0)
				{
					if (!useWeights)
					{
						Func<EnemyCard, float> keySelector = _003C_003Ec._003C_003E9__27_0;
						if (_003C_003Ec._003C_003E9__27_0 == null)
						{
							keySelector = (_003C_003Ec._003C_003E9__27_0 = (Func<object, float>)((EnemyCard c) => c.cost));
						}
						IOrderedEnumerable<EnemyCard> source = Enumerable.OrderByDescending(list, keySelector);
						return (EnemyCard)Enumerable.FirstOrDefault((IEnumerable<object>)source);
					}
					Func<EnemyCard, float> selector = _003C_003Ec._003C_003E9__27_1;
					if (_003C_003Ec._003C_003E9__27_1 == null)
					{
						selector = (_003C_003Ec._003C_003E9__27_1 = (Func<object, float>)((EnemyCard card) => card.weight));
					}
					float num = Enumerable.Sum(list, selector);
					enumerator2 = (List<EnemyCard>.Enumerator)MyRandom.random;
					if (MyRandom.random == null)
					{
						goto IL_0210;
					}
					object obj = enumerator2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v666 @ rax_v43+1B8] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm7,xmm0\"");
					float num2 = 0f * num;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					object obj2 = 0;
					while (enumerator3.MoveNext())
					{
						bool flag6 = enemyCard == null;
						List<object>.Enumerator enumerator4 = (List<object>.Enumerator)(&enumerator3);
						if (!flag6)
						{
							obj2 += enemyCard.weight;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
								return enemyCard;
							}
							continue;
						}
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				}
				return null;
			}
		}
		goto IL_0210;
		IL_0210:
		throw new NullReferenceException();
	}

	public void SetSlowmode(float multiplier, float duration)
	{
		slowmodeMultiplier = multiplier;
		slowmode = true;
		float num = duration + MyTime.time;
		slowmodeOverAtTime = num;
	}

	public void SetWaveMode(List<EEnemy> waveEnemies, float duration)
	{
		isWaveMode = true;
		float num = duration + MyTime.time;
		waveModeOverAtTime = num;
		List<EnemyCard> list = GenerateCards(waveEnemies);
		waveModeCards = list;
	}

	protected float GetMultiplier()
	{
		if (UseMultiplier())
		{
			float stat = PlayerStats.GetStat(EStat.Difficulty);
			float stageMultiplier = CombatScaling.GetStageMultiplier();
			float num = stat * 0.7f;
			float num2 = stageMultiplier * 0.4f;
			float num3 = num + 1f;
			return num2 + num3;
		}
		return 1f;
	}

	protected virtual bool UseMultiplier()
	{
		return true;
	}

	private bool CanEarnCredits()
	{
		//IL_0034: Expected I4, but got O
		if ((object)EnemyManager.Instance != null)
		{
			bool flag = EnemyManager.Instance.HasMaxEnemies();
			return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void OnStatUpdated(EStat stat)
	{
		if (stat == EStat.EliteSpawnIncrease)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x18046D2D0\"");
		}
	}

	private void OnPlayerInventoryInitialized(PlayerInventory playerInventory)
	{
		RefreshCardWeights();
	}

	protected abstract void Init();

	protected abstract List<EEnemy> GetEnemies();

	public abstract float GetSummonInterval();

	public abstract float GetBaseCreditsPerSecond();

	public abstract float GetInitialCredits();

	public abstract int GetNumTargetEnemies();

	protected abstract bool UseDirectionBias();

	protected abstract bool ForceSpawn();
}
