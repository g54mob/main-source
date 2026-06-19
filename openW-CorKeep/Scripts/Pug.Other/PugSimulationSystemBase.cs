using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;
using Unity.Physics;
using UnityEngine.Scripting;

public abstract class PugSimulationSystemBase : SystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct TypeHandle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
		}
	}

	private BeginSimulationEntityCommandBufferSystem ecbSystem;

	private WorldInfoSystem worldInfoSystem;

	private bool commandBufferCreated;

	private bool tileAccessorCreated;

	private bool tileAccessorUpdated;

	private AttackSystem.Helper attackHelper;

	private bool attackHelperCreated;

	private bool attackHelperUpdated;

	private bool needDatabase;

	private bool needLootBank;

	private bool needServerSeed;

	private bool needTileUpdateBuffer;

	private bool needTileDamageBuffer;

	private bool needSpawnGroups;

	private bool updatesInRunGroup;

	private bool allowToRunBeforeInit;

	protected BlobAssetReference<PugDatabase.PugDatabaseBank> database;

	protected BlobAssetReference<LootTableBankBlob> lootBank;

	protected uint serverSeed;

	protected Entity tileUpdateBufferSingletonEntity;

	protected Entity tileDamageBufferSingletonEntity;

	private TileAccessor tileAccessor;

	protected EntityQuery _queryRequiredForUpdate;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_135769800_0;

	private EntityQuery __query_135769800_1;

	private EntityQuery __query_135769800_2;

	private EntityQuery __query_135769800_3;

	private EntityQuery __query_135769800_4;

	private EntityQuery __query_135769800_5;

	private EntityQuery __query_135769800_6;

	private EntityQuery __query_135769800_7;

	protected bool isServer => base.World.IsServer();

	protected WorldInfoCD WorldInfo => worldInfoSystem?.WorldInfo ?? default(WorldInfoCD);

	protected void UpdatesInRunGroup()
	{
		updatesInRunGroup = true;
	}

	protected void NeedSpawnGroupsTable()
	{
		if (!needSpawnGroups)
		{
			RequireForUpdate<SpawnGroupsTableCD>();
		}
		needSpawnGroups = true;
	}

	protected void NeedDatabase()
	{
		if (!needDatabase)
		{
			RequireForUpdate<PugDatabase.DatabaseBankCD>();
		}
		needDatabase = true;
	}

	protected void NeedLootBank()
	{
		if (!needLootBank)
		{
			RequireForUpdate<LootTableBankCD>();
		}
		needLootBank = true;
	}

	protected void NeedServerSeed()
	{
		if (!needServerSeed)
		{
			RequireForUpdate<ServerSeedCD>();
		}
		needServerSeed = true;
	}

	protected void NeedTileUpdateBuffer()
	{
		if (!needTileUpdateBuffer)
		{
			RequireForUpdate<TileUpdateBuffer>();
		}
		needTileUpdateBuffer = true;
	}

	protected void NeedTileDamageBuffer()
	{
		if (!needTileDamageBuffer)
		{
			RequireForUpdate<TileDamageBuffer>();
		}
		needTileDamageBuffer = true;
	}

	protected void AllowToRunBeforeInit()
	{
		allowToRunBeforeInit = true;
	}

	protected virtual EntityCommandBuffer CreateCommandBuffer()
	{
		commandBufferCreated = true;
		return ecbSystem.CreateCommandBuffer();
	}

	protected virtual TileAccessor CreateTileAccessor(bool readOnly = true)
	{
		if (!tileAccessorCreated)
		{
			tileAccessor = new TileAccessor(ref base.CheckedStateRef, readOnly);
			tileAccessorCreated = true;
			tileAccessorUpdated = true;
		}
		if (!tileAccessorUpdated)
		{
			tileAccessor.Update(ref base.CheckedStateRef);
			tileAccessorUpdated = true;
		}
		return tileAccessor;
	}

	protected PhysicsWorld GetPhysicsWorld()
	{
		return __query_135769800_0.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld;
	}

	protected NetworkTick GetServerTick()
	{
		__query_135769800_1.TryGetSingleton<NetworkTime>(out var value);
		return value.ServerTick;
	}

	protected AttackSystem.Helper GetAttackHelper()
	{
		if (!attackHelperCreated)
		{
			if (!__query_135769800_2.TryGetSingleton<ClientServerTickRate>(out var value))
			{
				value.ResolveDefaults();
			}
			attackHelper = new AttackSystem.Helper(ref base.CheckedStateRef, value.SimulationTickRate);
			attackHelperCreated = true;
			attackHelperUpdated = false;
		}
		if (!attackHelperUpdated)
		{
			if (!__query_135769800_2.TryGetSingleton<ClientServerTickRate>(out var value2))
			{
				value2.ResolveDefaults();
			}
			__query_135769800_1.TryGetSingleton<NetworkTime>(out var value3);
			attackHelper.Update(ref base.CheckedStateRef, value3.ServerTick, (uint)value2.SimulationTickRate);
			attackHelperUpdated = true;
		}
		return attackHelper;
	}

	[Preserve]
	protected override void OnCreate()
	{
		if (_queryRequiredForUpdate != default(EntityQuery))
		{
			RequireForUpdate(_queryRequiredForUpdate);
		}
		worldInfoSystem = base.World.GetExistingSystemManaged<WorldInfoSystem>();
		ecbSystem = base.World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>();
		if (base.World.IsServer() && !allowToRunBeforeInit && !Attribute.IsDefined(GetType(), typeof(AlwaysUpdateSystemAttribute), inherit: true))
		{
			RequireForUpdate<InitialLoadingDoneCD>();
		}
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		if (needDatabase && !database.IsCreated)
		{
			database = __query_135769800_3.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
		}
		if (needLootBank && !lootBank.IsCreated)
		{
			lootBank = __query_135769800_4.GetSingleton<LootTableBankCD>().Value;
		}
		if (needServerSeed && serverSeed == 0)
		{
			serverSeed = __query_135769800_5.GetSingleton<ServerSeedCD>().Value;
		}
		if (needTileUpdateBuffer && tileUpdateBufferSingletonEntity == Entity.Null)
		{
			tileUpdateBufferSingletonEntity = __query_135769800_6.GetSingletonEntity();
		}
		if (needTileDamageBuffer && tileDamageBufferSingletonEntity == Entity.Null)
		{
			tileDamageBufferSingletonEntity = __query_135769800_7.GetSingletonEntity();
		}
		base.OnStartRunning();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (!updatesInRunGroup && commandBufferCreated)
		{
			ecbSystem.AddJobHandleForProducer(base.Dependency);
		}
		commandBufferCreated = false;
		tileAccessorUpdated = false;
		attackHelperUpdated = false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_135769800_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_135769800_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_135769800_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_135769800_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<LootTableBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_135769800_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ServerSeedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_135769800_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileUpdateBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_135769800_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TileDamageBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_135769800_7 = entityQueryBuilder2.Build(ref state);
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
	protected PugSimulationSystemBase()
	{
	}
}
