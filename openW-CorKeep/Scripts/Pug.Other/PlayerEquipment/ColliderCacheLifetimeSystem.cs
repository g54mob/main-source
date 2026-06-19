using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

namespace PlayerEquipment
{
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(InitializationSystemGroup))]
	[BurstCompile]
	public struct ColliderCacheLifetimeSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct TypeHandle
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_000074C9_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_000074C9_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000074C9_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
		internal delegate void __codegen__OnDestroy_000074CA_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnDestroy_000074CA_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_000074CA_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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
				__codegen__OnDestroy_0024BurstManaged(self, state);
			}
		}

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1623299560_0;

		private EntityQuery __query_1623299560_1;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			Entity entity = state.EntityManager.CreateEntity();
			state.EntityManager.AddComponentData(entity, new ColliderCacheCD
			{
				sphereColliderCache = new NativeParallelHashMap<float3x2, BlobAssetReference<Collider>>(16, Allocator.Persistent),
				boxColliderCache = new NativeParallelHashMap<float3x3, BlobAssetReference<Collider>>(16, Allocator.Persistent)
			});
			state.Enabled = false;
		}

		[BurstCompile]
		public void OnDestroy(ref SystemState state)
		{
			if (!__query_1623299560_0.TryGetSingletonRW(out RefRW<ColliderCacheCD> value))
			{
				return;
			}
			foreach (KeyValue<float3x2, BlobAssetReference<Collider>> item in value.ValueRO.sphereColliderCache)
			{
				item.Value.Dispose();
			}
			foreach (KeyValue<float3x3, BlobAssetReference<Collider>> item2 in value.ValueRO.boxColliderCache)
			{
				item2.Value.Dispose();
			}
			value.ValueRW.sphereColliderCache.Dispose();
			value.ValueRW.boxColliderCache.Dispose();
			state.EntityManager.DestroyEntity(__query_1623299560_1.GetSingletonEntity());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ColliderCacheCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1623299560_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ColliderCacheCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_1623299560_1 = entityQueryBuilder2.Build(ref state);
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
			__codegen__OnCreate_000074C9_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			__codegen__OnDestroy_000074CA_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((ColliderCacheLifetimeSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ColliderCacheLifetimeSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ColliderCacheLifetimeSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
		}
	}
}
