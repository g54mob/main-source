using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;

[BurstCompile]
[UpdateAfter(typeof(HydraBossSystem))]
[UpdateAfter(typeof(SnakeBossSystem))]
[UpdateInGroup(typeof(BeforePredictedFixedStepSimulationSystemGroup))]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
public struct BaitFeedbackSystem : ISystem, ISystemCompilerGenerated
{
	[BurstCompile]
	private struct BaitFeedbackJob : IJob
	{
		[ReadOnly]
		public NativeList<Entity> newBaits;

		[ReadOnly]
		public NativeList<BaitableCD> baitables;

		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> ownerReferenceLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> localTransformLookup;

		public BufferLookup<GhostEffectEventBuffer> ghostEffectEventBufferLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerLookup;

		public NetworkTick currentTick;

		public void Execute()
		{
			if (newBaits.Length == 0)
			{
				return;
			}
			for (int i = 0; i < newBaits.Length; i++)
			{
				Entity entity = newBaits[i];
				if (!ownerReferenceLookup.TryGetComponent(entity, out var componentData) || !localTransformLookup.TryGetComponent(entity, out var componentData2) || !localTransformLookup.TryGetComponent(componentData.owner, out var componentData3) || math.distance(componentData2.Position, componentData3.Position) > 10f)
				{
					continue;
				}
				DynamicBuffer<GhostEffectEventBuffer> buffer = ghostEffectEventBufferLookup[componentData.owner];
				ref GhostEffectEventBufferPointerCD valueRW = ref ghostEffectEventBufferPointerLookup.GetRefRW(componentData.owner).ValueRW;
				bool flag = false;
				for (int j = 0; j < baitables.Length; j++)
				{
					if (baitables[j].baitEntity == entity)
					{
						flag = true;
						break;
					}
				}
				GhostEffectEventBuffer item = new GhostEffectEventBuffer
				{
					Tick = currentTick,
					value = new EffectEventCD
					{
						effectID = EffectID.Emote,
						localOnlyEffect = 1,
						entity = componentData.owner,
						value1 = (flag ? 21 : 45)
					}
				};
				buffer.AddToRingBuffer(ref valueRW, in item);
			}
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentLookup<OwnerReferenceCD> __OwnerReferenceCD_RO_ComponentLookup;

		[ReadOnly]
		public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RO_ComponentLookup;

		public BufferLookup<GhostEffectEventBuffer> __GhostEffectEventBuffer_RW_BufferLookup;

		public ComponentLookup<GhostEffectEventBufferPointerCD> __GhostEffectEventBufferPointerCD_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__OwnerReferenceCD_RO_ComponentLookup = state.GetComponentLookup<OwnerReferenceCD>(isReadOnly: true);
			__Unity_Transforms_LocalTransform_RO_ComponentLookup = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			__GhostEffectEventBuffer_RW_BufferLookup = state.GetBufferLookup<GhostEffectEventBuffer>();
			__GhostEffectEventBufferPointerCD_RW_ComponentLookup = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnCreate_00000441_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_00000441_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00000441_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnCreate_0024BurstManaged(self, state);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00000442_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00000442_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00000442_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(IntPtr self, IntPtr state)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
					return;
				}
			}
			__codegen__OnUpdate_0024BurstManaged(self, state);
		}
	}

	private EntityQuery _baitQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1640995924_0;

	private EntityQuery __query_1640995924_1;

	private EntityQuery __query_1640995924_2;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		_baitQuery = __query_1640995924_0;
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		JobHandle outJobHandle;
		NativeList<Entity> newBaits = _baitQuery.ToEntityListAsync(state.WorldUpdateAllocator, state.Dependency, out outJobHandle);
		EntityQuery _query_1640995924_ = __query_1640995924_1;
		JobHandle outJobHandle2;
		NativeList<BaitableCD> baitables = _query_1640995924_.ToComponentDataListAsync<BaitableCD>(state.WorldUpdateAllocator, out outJobHandle2);
		JobHandle dependsOn = JobHandle.CombineDependencies(outJobHandle, outJobHandle2, state.Dependency);
		__query_1640995924_2.TryGetSingleton<NetworkTime>(out var value);
		state.Dependency = IJobExtensions.Schedule(new BaitFeedbackJob
		{
			newBaits = newBaits,
			baitables = baitables,
			ownerReferenceLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OwnerReferenceCD_RO_ComponentLookup, ref state),
			localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RO_ComponentLookup, ref state),
			ghostEffectEventBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__GhostEffectEventBuffer_RW_BufferLookup, ref state),
			ghostEffectEventBufferPointerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__GhostEffectEventBufferPointerCD_RW_ComponentLookup, ref state),
			currentTick = value.ServerTick
		}, dependsOn);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BaitCD, OwnerReferenceCD, LocalTransform>();
		entityQueryBuilder2 = entityQueryBuilder2.WithNone<BaitCheckedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_1640995924_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BaitableCD>();
		__query_1640995924_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1640995924_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		__codegen__OnCreate_00000441_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00000442_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((BaitFeedbackSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BaitFeedbackSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((BaitFeedbackSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}
}
