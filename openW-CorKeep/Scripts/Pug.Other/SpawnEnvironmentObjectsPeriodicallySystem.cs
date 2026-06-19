using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using QFSW.QC;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class SpawnEnvironmentObjectsPeriodicallySystem : PugSimulationSystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct TypeHandle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
		}
	}

	private const float timeToRespawnAllMaps = 900f;

	private const float furthestPlayerSpawnDistance = 200f;

	private EntityArchetype spawnEnvArchetype;

	private EntityQuery spawnEnvQ;

	private EntityQuery spawnEnvAreaQ;

	private EntityQuery subMapQ;

	private EntityQuery playersQ;

	private float respawnTimer;

	private int lastSubMapRespawned;

	private int lastSubMapPartRespawned;

	private static int2 manualSpawnPosition;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_108742872_0;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		spawnEnvArchetype = base.EntityManager.CreateArchetype(typeof(SpawnEnvironmentObjectsCD));
		spawnEnvQ = GetEntityQuery(typeof(SpawnEnvironmentObjectsCD));
		subMapQ = GetEntityQuery(typeof(SubMapCD));
		playersQ = GetEntityQuery(typeof(PlayerGhost), typeof(LocalTransform));
		respawnTimer = 30f;
		lastSubMapRespawned = UnityEngine.Random.Range(0, int.MaxValue);
		lastSubMapPartRespawned = 0;
		manualSpawnPosition = int.MaxValue;
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer entityCommandBuffer = CreateCommandBuffer();
		EntityArchetype archetype = spawnEnvArchetype;
		respawnTimer -= base.CheckedStateRef.WorldUnmanaged.Time.DeltaTime;
		if (__query_108742872_0.GetSingleton<WorldGenerationTypeCD>().Value == WorldGenerationType.Creative || !spawnEnvQ.IsEmpty || subMapQ.IsEmpty || respawnTimer > 0f)
		{
			base.OnUpdate();
			return;
		}
		using NativeArray<Entity> nativeArray = subMapQ.ToEntityArray(Allocator.Temp);
		using NativeArray<LocalTransform> nativeArray2 = playersQ.ToComponentDataArray<LocalTransform>(Allocator.Temp);
		lastSubMapRespawned = (lastSubMapRespawned + 1) % nativeArray.Length;
		SubMapCD component = GetComponent<SubMapCD>(nativeArray[lastSubMapRespawned]);
		SpawnEnvironmentObjectsCD component2 = new SpawnEnvironmentObjectsCD
		{
			respawn = true,
			position = component.position()
		};
		if (lastSubMapRespawned == 0)
		{
			lastSubMapPartRespawned = (lastSubMapPartRespawned + 1) % 16;
		}
		int x = lastSubMapPartRespawned % 4;
		int y = lastSubMapPartRespawned / 4;
		int2 int5 = new int2(x, y);
		component2.position += int5 * component2.size;
		bool flag = true;
		for (int i = 0; i < nativeArray2.Length; i++)
		{
			if (math.distance(component2.position, nativeArray2[i].Position.RoundToInt2()) < 200f)
			{
				flag = false;
				break;
			}
		}
		if (!flag)
		{
			Entity e = entityCommandBuffer.CreateEntity(archetype);
			entityCommandBuffer.SetComponent(e, component2);
		}
		respawnTimer = 900f / (float)nativeArray.Length / (float)(component.size().x / component2.size.x * component.size().y / component2.size.y);
		if (manualSpawnPosition.x != int.MaxValue)
		{
			SpawnEnvironmentObjectsCD component3 = new SpawnEnvironmentObjectsCD
			{
				respawn = true,
				position = manualSpawnPosition
			};
			Entity e2 = entityCommandBuffer.CreateEntity(archetype);
			entityCommandBuffer.SetComponent(e2, component3);
			manualSpawnPosition = int.MaxValue;
		}
		base.OnUpdate();
	}

	[Preserve]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_DEBUG_MODE")]
	[Conditional("PUG_MARKETING_BUILD")]
	[Command("triggerRespawn", "Trigger respawn in 16x16 area at position.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void TriggerRespawn(Vector2 position)
	{
		int2 size = default(SpawnEnvironmentObjectsCD).size;
		manualSpawnPosition = (int2)math.floor(position.ToFloat2() / size) * size;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationTypeCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_108742872_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public SpawnEnvironmentObjectsPeriodicallySystem()
	{
	}
}
