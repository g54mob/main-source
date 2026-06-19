using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public struct ReceiveBiomeSamplesFromServerSystem : ISystem, ISystemCompilerGenerated
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
	internal delegate void __codegen__OnCreate_000004EE_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnCreate_000004EE_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_000004EE_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
	internal delegate void __codegen__OnUpdate_000004EF_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_000004EF_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_000004EF_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnDestroy_000004F0_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnDestroy_000004F0_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnDestroy_000004F0_0024PostfixBurstDelegate>(__codegen__OnDestroy).Value;
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

	private EntityQuery __query_1648067861_0;

	private EntityQuery __query_1648067861_1;

	private EntityQuery __query_1648067861_2;

	[BurstCompile]
	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<BiomeSamplesCD>();
		state.RequireForUpdate<ClientBiomeSamplesCD>();
		state.EntityManager.CreateSingleton(new BiomeSamplesCD
		{
			BasePosition = new NativeReference<int2>(new int2(1, 1) * int.MaxValue, Allocator.Persistent),
			SamplesPerDimension = 6,
			Samples = new NativeArray<byte>(36, Allocator.Persistent)
		});
	}

	[BurstCompile]
	public void OnDestroy(ref SystemState state)
	{
		__query_1648067861_0.GetSingleton<BiomeSamplesCD>().Samples.Dispose();
		__query_1648067861_0.GetSingleton<BiomeSamplesCD>().BasePosition.Dispose();
	}

	[BurstCompile]
	public unsafe void OnUpdate(ref SystemState state)
	{
		ClientBiomeSamplesCD singleton = __query_1648067861_1.GetSingleton<ClientBiomeSamplesCD>();
		BiomeSamplesCD singleton2 = __query_1648067861_0.GetSingleton<BiomeSamplesCD>();
		if (singleton.BasePosition.Equals(singleton2.BasePosition.Value))
		{
			return;
		}
		singleton2.BasePosition.Value = singleton.BasePosition;
		byte* unsafePtr = singleton.Biomes.GetUnsafePtr();
		int2 baseIndex = ClientBiomeSamplesCD.GetBaseIndex(singleton.LinearBaseIndex);
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < 6; j++)
			{
				int index = i * 6 + j;
				int linearIndex = ClientBiomeSamplesCD.GetLinearIndex(baseIndex, new int2(j, i));
				singleton2.Samples[index] = unsafePtr[linearIndex];
			}
		}
		__query_1648067861_2.SetSingleton(singleton2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1648067861_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientBiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1648067861_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<BiomeSamplesCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1648067861_2 = entityQueryBuilder2.Build(ref state);
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
		__codegen__OnCreate_000004EE_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_000004EF_0024BurstDirectCall.Invoke(self, state);
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnDestroy(IntPtr self, IntPtr state)
	{
		__codegen__OnDestroy_000004F0_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((ReceiveBiomeSamplesFromServerSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ReceiveBiomeSamplesFromServerSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ReceiveBiomeSamplesFromServerSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnDestroy_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((ReceiveBiomeSamplesFromServerSystem*)self.ToPointer())->OnDestroy(ref *(SystemState*)state.ToPointer());
	}
}
