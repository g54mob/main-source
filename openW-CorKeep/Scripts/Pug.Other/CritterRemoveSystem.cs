using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class CritterRemoveSystem : PugSimulationSystemBase
{
	private EntityQuery playerQ;

	private List<EntityQuery> queriesToCheck = new List<EntityQuery>();

	private List<int> maxCounts = new List<int>();

	private EntityQuery nonPersistentCrittersQ;

	private WorldInfoSystem _worldInfoSystem;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		playerQ = GetEntityQuery(typeof(PlayerGhost));
		EntityQueryDesc entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { typeof(CritterCD) };
		entityQueryDesc.None = new ComponentType[2]
		{
			typeof(FireflyCD),
			typeof(AllowLargerAmount)
		};
		EntityQueryDesc entityQueryDesc2 = entityQueryDesc;
		queriesToCheck.Add(GetEntityQuery(entityQueryDesc2));
		maxCounts.Add(50);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[2]
		{
			typeof(CritterCD),
			typeof(AllowLargerAmount)
		};
		entityQueryDesc.None = new ComponentType[1] { typeof(FireflyCD) };
		EntityQueryDesc entityQueryDesc3 = entityQueryDesc;
		queriesToCheck.Add(GetEntityQuery(entityQueryDesc3));
		maxCounts.Add(50);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { typeof(FireflyCD) };
		entityQueryDesc.None = new ComponentType[1] { typeof(AllowLargerAmount) };
		EntityQueryDesc entityQueryDesc4 = entityQueryDesc;
		queriesToCheck.Add(GetEntityQuery(entityQueryDesc4));
		maxCounts.Add(500);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[2]
		{
			typeof(FireflyCD),
			typeof(AllowLargerAmount)
		};
		EntityQueryDesc entityQueryDesc5 = entityQueryDesc;
		queriesToCheck.Add(GetEntityQuery(entityQueryDesc5));
		maxCounts.Add(100);
		entityQueryDesc = new EntityQueryDesc();
		entityQueryDesc.All = new ComponentType[1] { typeof(CritterCD) };
		entityQueryDesc.None = new ComponentType[1] { typeof(IsPersistentCritterCD) };
		EntityQueryDesc entityQueryDesc6 = entityQueryDesc;
		nonPersistentCrittersQ = GetEntityQuery(entityQueryDesc6);
		_worldInfoSystem = base.World.GetExistingSystemManaged<WorldInfoSystem>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (_worldInfoSystem.WorldInfo.simulationDisabled)
		{
			NativeArray<Entity> nativeArray = nonPersistentCrittersQ.ToEntityArray(Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				base.EntityManager.DestroyEntity(nativeArray[i]);
			}
			nativeArray.Dispose();
		}
		int num = playerQ.CalculateEntityCount();
		if (num == 0)
		{
			return;
		}
		Random rng = PugRandom.GetRng();
		for (int j = 0; j < queriesToCheck.Count; j++)
		{
			int num2 = queriesToCheck[j].CalculateEntityCount() - maxCounts[j] * num;
			if (num2 <= 0)
			{
				continue;
			}
			using NativeArray<Entity> nativeArray2 = queriesToCheck[j].ToEntityArray(Allocator.Temp);
			NativeParallelHashSet<Entity> nativeParallelHashSet = new NativeParallelHashSet<Entity>(num2 * 2, Allocator.Temp);
			for (int k = 0; k < num2; k++)
			{
				nativeParallelHashSet.Add(nativeArray2[rng.NextInt(nativeArray2.Length)]);
			}
			using NativeArray<Entity> entities = nativeParallelHashSet.ToNativeArray(Allocator.Temp);
			base.EntityManager.DestroyEntity(entities);
			nativeParallelHashSet.Dispose();
		}
		base.OnUpdate();
	}

	[Preserve]
	public CritterRemoveSystem()
	{
	}
}
