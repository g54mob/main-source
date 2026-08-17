using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Game.Spawning.New.Summoners;

public class ChallengeSummoner : BaseSummoner
{
	private List<EEnemy> enemyPool;

	private Vector3 pos;

	public ChallengeSummoner(int id, List<EEnemy> defaultEnemies)
	{
		List<EEnemy> list = new List<EEnemy>();
		enemyPool = list;
		base._002Ector(id, defaultEnemies);
	}

	protected unsafe override void Init()
	{
		//IL_0022: Expected I, but got O
		//IL_0080: Expected I, but got O
		//IL_0120: Expected O, but got Ref
		//IL_0148: Expected O, but got I
		//IL_0256: Expected I, but got O
		//IL_01a1: Invalid comparison between I and F4
		//IL_02fc: Expected O, but got I
		//IL_01cc: Expected O, but got Ref
		List<EEnemy> list = new List<EEnemy>();
		enemyPool = list;
		nint num = (nint)typeof(MapController);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v11 (Il2CppClass<Assets.Scripts.Managers.MapController>)+B8]");
		nint num2 = 0;
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		if ((object)MapController._003CcurrentMap_003Ek__BackingField != null)
		{
			float initialCredits = GetInitialCredits();
			List<EEnemy> list2 = new List<EEnemy>();
			nint num3 = (nint)typeof(DataManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v25 (Il2CppClass<DataManager>)+B8]");
			nint num4 = 0;
			DataManager instance = DataManager.Instance;
			bool flag = (object)DataManager.Instance == null;
			num2 = num4;
			if (!flag)
			{
				bool flag2 = instance.unsortedEnemies == null;
				num2 = num4;
				if (!flag2)
				{
					object obj = default(object);
					float num5 = (float)obj * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
					List<object>.Enumerator enumerator = default(List<object>.Enumerator);
					object obj2 = default(object);
					while (enumerator.MoveNext())
					{
						bool flag3 = obj2 == null;
						List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ stack_-50+B0]");
							object obj3 = (nint)0 & (nint)mapData.eMap;
							if ((nint)obj3 != (nint)mapData.eMap)
							{
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ stack_-50+B4]");
							if ((nint)0 > (nint)MapController.index)
							{
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ stack_-50+B8]");
							if (!(0f > num5))
							{
								bool flag4 = list2 == null;
								enumerator2 = (List<object>.Enumerator)(&enumerator);
								if (flag4)
								{
									throw new NullReferenceException();
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ stack_-50+18]");
								list2.Add(EEnemy.Skeleton);
							}
							continue;
						}
						throw new NullReferenceException();
					}
					((List<EnemyData>.Enumerator*)(&enumerator))->Dispose();
					bool flag5 = list2 == null;
					num2 = (nint)(&enumerator);
					if (!flag5)
					{
						List<EEnemy> list3 = enemyPool;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v23 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
						int index = UnityEngine.Random.Range(0, 0);
						EEnemy item = list2.get_Item(index);
						bool flag6 = enemyPool == null;
						num2 = (nint)list2;
						if (!flag6)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rbx_v7 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rbx_v7 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+10]");
							num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rbx_v7 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rbx_v7 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
								if (0 >= (nint)MapController._003CcurrentStage_003Ek__BackingField)
								{
									enemyPool.AddWithResize(item);
									return;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rbx_v7 (System.Collections.Generic.List`1<Actors.Enemies.EEnemy>)+18]");
								object obj4 = (nint)0 + (nint)1;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public List<Enemy> SpawnEnemies(bool onlyElites, Vector3 position)
	{
		//IL_001d: Expected O, but got F4
		bool useWeights = (byte)((onlyElites ? 1u : 0u) ^ 1u) != 0;
		pos = (Vector3)position.x;
		_ = position.z;
		return SpendCredits(useWeights);
	}

	public unsafe override List<Enemy> SpendCredits(bool useWeights = true)
	{
		//IL_01d2: Invalid comparison between F4 and I4
		//IL_0049: Expected O, but got Ref
		//IL_005b: Expected I, but got O
		//IL_014b: Expected I4, but got F4
		//IL_014b: Expected O, but got Ref
		//IL_0184: Invalid comparison between F4 and I4
		List<Enemy> list = new List<Enemy>();
		if (credits > 0f)
		{
			Vector3 vector = default(Vector3);
			int num2 = default(int);
			bool flag = default(bool);
			float num3 = default(float);
			object obj = default(object);
			float extraSizeMultiplier = default(float);
			object obj2 = default(object);
			while (true)
			{
				EnemyCard randomCard = GetRandomCard(useWeights);
				if (randomCard == null)
				{
					break;
				}
				float num = credits - randomCard.cost;
				credits = num;
				Vector3 enemySpawnPositionAroundPoint = SpawnPositions.GetEnemySpawnPositionAroundPoint((Vector3)(&vector), 0f, 8f, num2, flag, num3);
				nint num4 = (nint)typeof(SpawnPositions);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rax_v10 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
				nint num5 = 0;
				float num6 = enemySpawnPositionAroundPoint.x - (float)SpawnPositions.INVALID_POS;
				float num7 = enemySpawnPositionAroundPoint.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rcx_v9 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+4]");
				float num8 = num7 - 0f;
				float num9 = enemySpawnPositionAroundPoint.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rcx_v9 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
				float num10 = num9 - 0f;
				float num11 = num8 * num8;
				float num12 = num6 * num6;
				float num13 = num10 * num10;
				float num14 = num11 + num12;
				float num15 = num14 + num13;
				if (9.9999994E-11f > num15 || (object)EnemyManager.Instance != null)
				{
					Enemy item = EnemyManager.Instance.SpawnEnemy(randomCard.enemy, (Vector3)(&obj), id, (byte)num2 != 0, flag ? EEnemyFlag.Elite : EEnemyFlag.None, (byte)(int)num3 != 0, extraSizeMultiplier);
					if (list != null)
					{
						list.Add(item);
						bool flag2 = credits > 0f;
						obj = obj2;
						vector = pos;
						if (!flag2)
						{
							break;
						}
						continue;
					}
				}
				return (List<Enemy>)(object)new NullReferenceException();
			}
		}
		return list;
	}

	protected override List<EEnemy> GetEnemies()
	{
		return enemyPool;
	}

	public override float GetSummonInterval()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	public override float GetBaseCreditsPerSecond()
	{
		//IL_0006: Expected F4, but got I4
		return 0f;
	}

	public override float GetInitialCredits()
	{
		EnemyManager instance = EnemyManager.Instance;
		SummonerController summonerController = instance.summonerController;
		float baseCreditsPerSecondUncapped = summonerController.stageSummoner.GetBaseCreditsPerSecondUncapped();
		float num = UnityEngine.Random.Range(3f, 5f);
		return num * baseCreditsPerSecondUncapped;
	}

	public override int GetNumTargetEnemies()
	{
		return 999;
	}

	protected override bool UseDirectionBias()
	{
		return false;
	}

	protected override bool ForceSpawn()
	{
		return true;
	}
}
