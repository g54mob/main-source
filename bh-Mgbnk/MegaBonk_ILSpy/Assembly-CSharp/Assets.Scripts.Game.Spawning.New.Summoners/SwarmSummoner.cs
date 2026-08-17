using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Utility;
using Cpp2ILInjected;

namespace Assets.Scripts.Game.Spawning.New.Summoners;

public class SwarmSummoner : BaseSummoner
{
	private List<EEnemy> finalSwarmEnemies;

	public const float swarmSummonInterval = 0.5f;

	private int ghostTier;

	private bool hasSwappedEnemy;

	private List<Enemy> spawnedEnemies;

	private float swarmHpMultiplier;

	private float swarmSpeedMultiplier;

	protected override void Init()
	{
	}

	protected override void TickExtra()
	{
		if (!hasSwappedEnemy)
		{
			if (MyTime.finalSwarmTimer > 60f && ghostTier == 0)
			{
				List<EEnemy> list = new List<EEnemy>();
				list.Add(EEnemy.GreaterGhost);
				List<EnemyCard> list2 = base.GenerateCards(list);
				base.cards = list2;
				ghostTier = 1;
			}
			if (MyTime.finalSwarmTimer > 360f && ghostTier == 1)
			{
				List<EEnemy> list3 = new List<EEnemy>();
				list3.Add(EEnemy.GhostPurple);
				List<EnemyCard> list4 = base.GenerateCards(list3);
				base.cards = list4;
				ghostTier = 2;
			}
			if (MyTime.finalSwarmTimer > 720f && ghostTier == 2)
			{
				List<EEnemy> list5 = new List<EEnemy>();
				list5.Add(EEnemy.GhostRed);
				List<EnemyCard> list6 = base.GenerateCards(list5);
				base.cards = list6;
				ghostTier = 3;
			}
		}
	}

	protected override List<EEnemy> GetEnemies()
	{
		if ((object)GameManager.Instance != null)
		{
			if (!GameManager.Instance.IsFinalSwarm())
			{
				return currentEnemies;
			}
			return finalSwarmEnemies;
		}
		return (List<EEnemy>)(object)new NullReferenceException();
	}

	public override float GetSummonInterval()
	{
		return 0.5f;
	}

	public override float GetBaseCreditsPerSecond()
	{
		//IL_0019: Expected O, but got I4
		//IL_0036: Expected F4, but got O
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_012a: Expected F4, but got O
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		if (currentEnemies != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
			object obj = 0;
			List<EEnemy>.Enumerator enumerator = default(List<EEnemy>.Enumerator);
			List<EEnemy>.Enumerator enumerator2 = default(List<EEnemy>.Enumerator);
			EEnemy eEnemy = default(EEnemy);
			List<EEnemy>.Enumerator enumerator3;
			while (enumerator.MoveNext())
			{
				bool flag = (object)DataManager.Instance == null;
				float num = (float)enumerator2;
				if (!flag)
				{
					EnemyData enemyData = DataManager.Instance.GetEnemyData(eEnemy);
					bool flag2 = (object)enemyData == null;
					enumerator3 = enumerator2;
					if (!flag2)
					{
						obj += enemyData.creditCost;
						continue;
					}
					num = (float)enumerator3;
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			enumerator.Dispose();
			List<EEnemy> list = currentEnemies;
			bool flag3 = currentEnemies == null;
			enumerator3 = enumerator2;
			if (!flag3)
			{
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v13 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
				object obj3 = obj2 / 0;
				int numTargetEnemies = GetNumTargetEnemies();
				object obj4 = numTargetEnemies * obj3;
				return (float)obj4 * 0.05f;
			}
		}
		throw new NullReferenceException();
	}

	public override float GetInitialCredits()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	public override int GetNumTargetEnemies()
	{
		//IL_0112: Expected I4, but got O
		//IL_00b6: Invalid comparison between I4 and F4
		//IL_003a: Expected O, but got I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_00ff: Expected F4, but got I4
		//IL_00d2: Invalid comparison between F4 and I4
		//IL_00f1: Expected F4, but got I4
		if ((object)GameManager.Instance != null)
		{
			if (!GameManager.Instance.IsFinalSwarm())
			{
				object obj = MapController.index * 65;
				float stat = PlayerStats.GetStat(EStat.Difficulty);
				float num = stat + 1f;
				object obj2 = obj + 240;
				float num2 = num * (float)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
				int result = default(int);
				return result;
			}
			if ((object)EnemyManager.Instance != null)
			{
				int numMaxEnemies = EnemyManager.Instance.GetNumMaxEnemies();
				float num3 = MyTime.finalSwarmTimer * 2.5f;
				if (!(0f > num3))
				{
					if (num3 > (float)numMaxEnemies)
					{
						num3 = numMaxEnemies;
					}
				}
				else
				{
					num3 = 0f;
				}
				float multiplier = GetMultiplier();
				float num4 = num3 + 50f;
				float num5 = multiplier * num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
				int result2 = default(int);
				return result2;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	protected override bool UseDirectionBias()
	{
		return true;
	}

	public override List<Enemy> SpendCredits(bool useWeights = true)
	{
		//IL_00a5: Invalid comparison between F4 and I4
		//IL_021c: Invalid comparison between F4 and I4
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
			if ((object)EnemyManager.Instance != null)
			{
				if (!EnemyManager.Instance.HasMaxEnemies())
				{
					bool flag = !(credits > 0f);
					int num = 0;
					if (!flag)
					{
						EEnemyFlag flag3 = default(EEnemyFlag);
						bool useDirectionBias = default(bool);
						while (enemiesThisSecond < 500 && num < 200)
						{
							EnemyCard randomCard = GetRandomCard(useWeights);
							if (randomCard == null)
							{
								break;
							}
							float num2 = credits - randomCard.cost;
							credits = num2;
							bool flag2 = UseDirectionBias();
							if ((object)EnemyManager.Instance != null)
							{
								Enemy enemy = EnemyManager.Instance.SpawnEnemy(randomCard.enemy, id, forceSpawn: false, flag3, useDirectionBias);
								if (!(enemy != null))
								{
									break;
								}
								if ((object)enemy != null)
								{
									enemy.speedMultiplier = swarmSpeedMultiplier;
									enemy.SetSwarmMultiplierHp(swarmHpMultiplier);
									if (spawnedEnemies != null)
									{
										spawnedEnemies.Add(enemy);
										int num3 = enemiesThisSecond + 1;
										enemiesThisSecond = num3;
										num++;
										if (!(credits > 0f))
										{
											break;
										}
										continue;
									}
								}
							}
							goto IL_0237;
						}
					}
				}
				return spawnedEnemies;
			}
		}
		goto IL_0237;
		IL_0237:
		return (List<Enemy>)(object)new NullReferenceException();
	}

	protected override bool ForceSpawn()
	{
		return false;
	}

	public SwarmSummoner(int id, List<EEnemy> defaultEnemies)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		List<EEnemy> list = new List<EEnemy>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v6+18]");
		if (num >= 0)
		{
			list.AddWithResize(EEnemy.Ghost);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16;
		}
		finalSwarmEnemies = list;
		List<Enemy> list2 = new List<Enemy>();
		spawnedEnemies = list2;
		swarmHpMultiplier = 1.3f;
		swarmSpeedMultiplier = 1.2f;
		base._002Ector(id, defaultEnemies);
	}
}
