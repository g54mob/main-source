using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.ECS.Hybrid;
using Unity.Collections;
using Unity.Entities;
using UnityEngine.Scripting;

[UpdateInGroup(typeof(PresentationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
public class TriggerAnimationsSystem : SystemBase
{
	public struct TriggerAnimationBuffer : IBufferElementData
	{
		public Entity Entity;

		public int AnimID;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct TypeHandle
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1377070520_0;

	[Preserve]
	protected override void OnCreate()
	{
		base.EntityManager.CreateSingletonBuffer<TriggerAnimationBuffer>();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		Dictionary<Entity, EntityMonoBehaviour> entityMonoBehaviourLookup = base.World.GetExistingSystemManaged<CreateGraphicalObjectSystem>().entityMonoBehaviourLookup;
		DynamicBuffer<TriggerAnimationBuffer> singletonBuffer = __query_1377070520_0.GetSingletonBuffer<TriggerAnimationBuffer>();
		foreach (TriggerAnimationBuffer item in singletonBuffer)
		{
			if (entityMonoBehaviourLookup.TryGetValue(item.Entity, out var value) && value != null)
			{
				value.TryPlayAnimation(item.AnimID);
			}
		}
		singletonBuffer.Clear();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<TriggerAnimationBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1377070520_0 = entityQueryBuilder2.Build(ref state);
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
	public TriggerAnimationsSystem()
	{
	}
}
