using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(NetworkReceiveSystemGroup), OrderFirst = true)]
public class NetworkUpdateServerSystem : SystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct TypeHandle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
		}
	}

	private SessionConfiguration _sessionConfiguration;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_998598873_0;

	private EntityQuery __query_998598873_1;

	private EntityQuery __query_998598873_2;

	[Preserve]
	protected override void OnCreate()
	{
		_sessionConfiguration = PlatformConfiguration.Instance?.SessionConfiguration ?? new SessionConfiguration();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		Manager.networking.ServerNetworkUpdate(base.World);
		if (_sessionConfiguration.UseGhostSendSystemOverrides)
		{
			int num = __query_998598873_0.CalculateEntityCount();
			if (num != 0)
			{
				GhostSendSystemData singleton = __query_998598873_1.GetSingleton<GhostSendSystemData>();
				singleton.MaxSendChunks = _sessionConfiguration.GhostSendSystemMaxSendChunks;
				singleton.MaxSendEntities = math.max(_sessionConfiguration.GhostSendSystemMaxSendEntitiesFloor, _sessionConfiguration.GhostSendSystemMaxSendEntitiesCeil / ((num + 1) / 2));
				__query_998598873_2.SetSingleton(singleton);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkStreamConnection>();
		__query_998598873_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<GhostSendSystemData>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_998598873_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<GhostSendSystemData>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_998598873_2 = entityQueryBuilder2.Build(ref state);
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
	public NetworkUpdateServerSystem()
	{
	}
}
