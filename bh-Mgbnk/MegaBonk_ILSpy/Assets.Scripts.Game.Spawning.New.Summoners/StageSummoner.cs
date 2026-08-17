using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Game.Spawning.New.Summoners;

public class StageSummoner : BaseSummoner
{
	private List<EEnemy> enemyPool;

	private float capReduction;

	public unsafe bool AddEnemyToPoolAndPickNewCard(List<EEnemy> eEnemy, out EEnemy selectedEnemy)
	{
		//IL_0415: Expected O, but got Ref
		//IL_0119: Expected I, but got O
		//IL_03e5: Expected I, but got O
		//IL_025e: Expected O, but got I
		//IL_02ee: Expected O, but got I
		//IL_0461: Expected I4, but got O
		ref EEnemy reference = ref *(EEnemy*)null;
		List<EEnemy> list = enemyPool;
		bool flag = enemyPool == null;
		List<EEnemy> list2 = (List<EEnemy>)(object)this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v2 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0331;
			}
			float baseCreditsPerSecond = GetBaseCreditsPerSecond();
			float multiplier = GetMultiplier();
			object obj = default(object);
			float num = multiplier * (float)obj;
			float summonInterval = GetSummonInterval();
			List<EEnemy> list3 = new List<EEnemy>();
			bool flag2 = enemyPool == null;
			list2 = list3;
			if (!flag2)
			{
				float num2 = num * multiplier;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
				nint num3 = 0;
				List<EEnemy>.Enumerator enumerator = default(List<EEnemy>.Enumerator);
				EEnemy eEnemy2 = default(EEnemy);
				while (enumerator.MoveNext())
				{
					if ((object)DataManager.Instance != null)
					{
						EnemyData enemyData = DataManager.Instance.GetEnemyData(eEnemy2);
						if ((object)enemyData != null)
						{
							bool flag3 = num2 < enemyData.creditCost;
							num3 = unchecked((nint)null);
							if (flag3)
							{
								continue;
							}
							list2 = (List<EEnemy>)(object)DataManager.Instance;
							bool flag4 = !(MyTime.stageTimer > enemyData.canSpawnAfterTime);
							num3 = unchecked((nint)null);
							if (!flag4)
							{
								if (list3 == null)
								{
									throw new NullReferenceException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BD0");
								num3 = 0;
							}
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				bool flag5 = list3 == null;
				list2 = (List<EEnemy>)(&enumerator);
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v21 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
					if ((nint)0 <= (nint)0)
					{
						goto IL_0331;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v21 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
					int index = UnityEngine.Random.Range(0, 0);
					EEnemy eEnemy3 = list3.get_Item(index);
					reference = ref *(EEnemy*)(int)eEnemy3;
					bool flag6 = enemyPool == null;
					list2 = enemyPool;
					if (!flag6)
					{
						bool flag7 = ((List<System.Int32Enum>)(object)enemyPool).Remove((System.Int32Enum)eEnemy3);
						list2 = currentEnemies;
						if (currentEnemies != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v3 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v3 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+10]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v3 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v3 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v3 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r9_v7+18]");
								if (num5 >= 0)
								{
									currentEnemies.AddWithResize(selectedEnemy);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v3 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
									object obj3 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v3 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
									nint num6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ r9_v7+18]");
									if (num6 >= 0)
									{
										IndexOutOfRangeException ex = new IndexOutOfRangeException();
										return (byte)(int)ex != 0;
									}
									_ = selectedEnemy;
								}
								List<EEnemy> enemies = GetEnemies();
								List<EnemyCard> list4 = base.GenerateCards(enemies);
								base.cards = list4;
								return true;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0331:
		return false;
	}

	protected override void Init()
	{
	}

	protected override List<EEnemy> GetEnemies()
	{
		return currentEnemies;
	}

	public override float GetSummonInterval()
	{
		float stat = PlayerStats.GetStat(EStat.Difficulty);
		float num = stat * 0.5f;
		float num2 = 1f - num;
		if (!(0.1f > num2))
		{
			if (num2 > 2f)
			{
				return 2f + 2f;
			}
		}
		else
		{
			num2 = 0.1f;
		}
		return num2 + num2;
	}

	public float GetBaseCreditsPerSecondUncapped()
	{
		float num = MyTime.stageTimer / 60f;
		float stat = PlayerStats.GetStat(EStat.EnemyAmountMultiplier);
		float num2 = num * 0.5f;
		float num3 = num2 + 1f;
		return stat * num3;
	}

	public override float GetBaseCreditsPerSecond()
	{
		//IL_0090: Expected F4, but got I4
		if (IsGainingCredits())
		{
			float baseCreditsPerSecondUncapped = GetBaseCreditsPerSecondUncapped();
			int enemiesFromSummoner = EnemyManager.Instance.GetEnemiesFromSummoner(id);
			int numTargetEnemies = GetNumTargetEnemies();
			bool flag = enemiesFromSummoner < numTargetEnemies;
			float result = baseCreditsPerSecondUncapped;
			if (!flag)
			{
				result = baseCreditsPerSecondUncapped * capReduction;
			}
			return result;
		}
		return 0f;
	}

	public override float GetInitialCredits()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	public override int GetNumTargetEnemies()
	{
		//IL_011b: Expected I4, but got O
		//IL_004f: Invalid comparison between I4 and F4
		//IL_009a: Expected F4, but got I4
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		if ((object)MapController._003CcurrentMap_003Ek__BackingField != null)
		{
			float num = MyTime.stageTimer / mapData.stageDuration;
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
			float num2 = num * 200f;
			float num3 = num2 + 5f;
			float stat = PlayerStats.GetStat(EStat.EnemyAmountMultiplier);
			float num7;
			if (base.UseMultiplier())
			{
				float stat2 = PlayerStats.GetStat(EStat.Difficulty);
				float stageMultiplier = CombatScaling.GetStageMultiplier();
				float num4 = stat2 * 0.7f;
				float num5 = stageMultiplier * 0.4f;
				float num6 = num4 + 1f;
				num7 = num5 + num6;
			}
			else
			{
				num7 = 1f;
			}
			float num8 = num3 * num7;
			float num9 = num8 * stat;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
			int result = default(int);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	protected override bool UseDirectionBias()
	{
		//IL_0081: Expected I4, but got O
		if (GameManager.Instance != null)
		{
			GameManager instance = GameManager.Instance;
			if ((object)GameManager.Instance != null)
			{
				return !instance._003CisCrypt_003Ek__BackingField;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return true;
	}

	protected override bool ForceSpawn()
	{
		return false;
	}

	private bool IsGainingCredits()
	{
		//IL_0226: Expected I4, but got O
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		if ((object)MapController._003CcurrentMap_003Ek__BackingField != null)
		{
			if (mapData.eMap != EMap.Graveyard)
			{
				goto IL_0212;
			}
			GameManager instance = GameManager.Instance;
			if ((object)GameManager.Instance != null)
			{
				if (instance._003CisCrypt_003Ek__BackingField && !instance._003CisDungeonTimerStarted_003Ek__BackingField)
				{
					goto IL_020c;
				}
				if (!(RsgController.Instance != null))
				{
					goto IL_0147;
				}
				RsgController instance2 = RsgController.Instance;
				if ((object)RsgController.Instance != null)
				{
					GraveyardBossRoom roomBoss = instance2.roomBoss;
					if ((object)instance2.roomBoss != null)
					{
						if (!roomBoss._003CisFightingBoss_003Ek__BackingField)
						{
							goto IL_0147;
						}
						goto IL_020c;
					}
				}
			}
		}
		goto IL_0218;
		IL_0212:
		return true;
		IL_0218:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_020c:
		return false;
		IL_0147:
		GameManager instance3 = GameManager.Instance;
		if ((object)GameManager.Instance != null)
		{
			if (!instance3._003CisCrypt_003Ek__BackingField || !instance3._003CisDungeonOvertime_003Ek__BackingField)
			{
				GameManager instance4 = GameManager.Instance;
				if (!instance4._003CisCrypt_003Ek__BackingField || !ChallengesTracker.HasChallengeModifier("crypt"))
				{
					goto IL_0212;
				}
			}
			goto IL_020c;
		}
		goto IL_0218;
	}

	private bool IsTargetEnemiesReached()
	{
		//IL_0096: Expected I4, but got O
		//IL_0030: Expected O, but got I4
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected I4, but got Unknown
		if ((object)EnemyManager.Instance != null)
		{
			int enemiesFromSummoner = EnemyManager.Instance.GetEnemiesFromSummoner(id);
			int numTargetEnemies = GetNumTargetEnemies();
			object obj = enemiesFromSummoner - numTargetEnemies;
			int num = enemiesFromSummoner ^ numTargetEnemies;
			int num2 = enemiesFromSummoner ^ obj;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = (nint)obj < 0;
			return flag2 == flag;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe StageSummoner(int id, List<EEnemy> defaultEnemies)
	{
		//IL_009f: Expected O, but got I
		List<EEnemy> list = new List<EEnemy>();
		enemyPool = list;
		capReduction = 0.25f;
		base._002Ector(id, defaultEnemies);
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		List<EEnemy> list2 = new List<EEnemy>();
		DataManager instance = DataManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		System.Int32Enum int32Enum = default(System.Int32Enum);
		List<EEnemy>.Enumerator enumerator2 = default(List<EEnemy>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (int32Enum == (System.Int32Enum)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ stack_-78 (System.Int32Enum)+B0]");
				object obj = (nint)0 & (nint)mapData.eMap;
				if ((nint)obj == (nint)mapData.eMap)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ stack_-78 (System.Int32Enum)+B4]");
					if ((nint)0 <= (nint)MapController.index)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ stack_-78 (System.Int32Enum)+18]");
						list2.Add(EEnemy.Skeleton);
					}
				}
				continue;
			}
			((List<EnemyData>.Enumerator*)(&enumerator))->Dispose();
			((List<System.Int32Enum>)(object)enemyPool).AddRange((IEnumerable<System.Int32Enum>)list2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18115DC70");
			while (true)
			{
				if (enumerator2.MoveNext())
				{
					bool flag = enemyPool == null;
					List<System.Int32Enum> list3 = (List<System.Int32Enum>)(object)enemyPool;
					if (!flag)
					{
						if (((List<System.Int32Enum>)(object)enemyPool).Contains(int32Enum))
						{
							list3 = (List<System.Int32Enum>)(object)enemyPool;
							if (enemyPool == null)
							{
								break;
							}
							bool flag2 = ((List<System.Int32Enum>)(object)enemyPool).Remove(int32Enum);
						}
						continue;
					}
					throw new NullReferenceException();
				}
				enumerator2.Dispose();
				return;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}
}
