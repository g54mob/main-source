using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pug.UnityExtensions;
using PugTilemap;
using QFSW.QC;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class TheGreatWallSystem : PugSimulationSystemBase
{
	public struct TriggerWallAnimationRPC : IRpcCommand, IComponentData, IQueryTypeParameter
	{
		public NetworkTick startTick;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct PlayerActivatedWall : IComponentData, IQueryTypeParameter
	{
	}

	[NoAlias]
	[BurstCompile]
	private struct TheGreatWallSystem_6025FA32_LambdaJob_0_Job : IJobChunk
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void RunWithoutJobSystem_00004310_0024PostfixBurstDelegate(ref EntityQuery query, IntPtr jobPtr);

		internal static class RunWithoutJobSystem_00004310_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<RunWithoutJobSystem_00004310_0024PostfixBurstDelegate>(RunWithoutJobSystem).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(ref EntityQuery query, IntPtr jobPtr)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref EntityQuery, IntPtr, void>)functionPointer)(ref query, jobPtr);
						return;
					}
				}
				RunWithoutJobSystem_0024BurstManaged(ref query, jobPtr);
			}
		}

		public bool isLowerWallLocal;

		[ReadOnly]
		public EntityTypeHandle __entityTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void OriginalLambdaBody(Entity entity)
		{
			isLowerWallLocal = true;
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __entityTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i));
				}
				return;
			}
			if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
			{
				int j = 0;
				int nextRangeEnd = 0;
				while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out j, out nextRangeEnd))
				{
					for (; j < nextRangeEnd; j++)
					{
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j));
					}
				}
				return;
			}
			ulong num = chunkEnabledMask.ULong0;
			int num2 = math.min(64, count);
			for (int k = 0; k < num2; k++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l));
				}
				num >>= 1;
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(RunWithoutJobSystem_00004310_0024PostfixBurstDelegate))]
		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			RunWithoutJobSystem_00004310_0024BurstDirectCall.Invoke(ref query, jobPtr);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal static void RunWithoutJobSystem_0024BurstManaged(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<TheGreatWallSystem_6025FA32_LambdaJob_0_Job>(jobPtr), ref query);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
		}
	}

	private static bool manualWallLowering;

	public const float WALL_ANIMATION_TIME = 10f;

	public const int DISTANCE_TO_ACTIVATE_WALL = 2;

	private EntityQuery wallLoweredQuery;

	private EntityQuery wallAnimQuery;

	private NetworkTick animationStartTick;

	private bool isLoweringWall;

	private ThreadSafeTimerSimple wallBeingLoweredTimer;

	private EntityQuery subMapQuery;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1875619383_0;

	[Preserve]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_DEBUG_MODE")]
	[Conditional("PUG_MARKETING_BUILD")]
	[Command("lowerGreatWall", "Manually triggers the lowering of the Great Wall.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void LowerGreatWall()
	{
		manualWallLowering = true;
	}

	[Preserve]
	protected override void OnCreate()
	{
		manualWallLowering = false;
		UpdatesInRunGroup();
		wallLoweredQuery = GetEntityQuery(typeof(TheGreatWallHasBeenLoweredCD));
		subMapQuery = GetEntityQuery(typeof(SubMapCD), typeof(SubMapLayerBuffer));
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		if (wallLoweredQuery.IsEmpty)
		{
			NetworkTick serverTick = GetServerTick();
			double elapsedTime = base.CheckedStateRef.WorldUnmanaged.Time.ElapsedTime;
			bool flag = isLoweringWall;
			bool isLowerWallLocal = isLoweringWall;
			TheGreatWallSystem_6025FA32_LambdaJob_0_Execute(ref isLowerWallLocal);
			isLoweringWall = isLowerWallLocal || manualWallLowering;
			if (isLoweringWall && !flag)
			{
				animationStartTick = serverTick;
			}
			if (isLoweringWall)
			{
				Entity entity = base.EntityManager.CreateEntity();
				base.EntityManager.AddComponent<SendRpcCommandRequest>(entity);
				base.EntityManager.AddComponentData(entity, new TriggerWallAnimationRPC
				{
					startTick = animationStartTick
				});
				if (!wallBeingLoweredTimer.isRunning)
				{
					wallBeingLoweredTimer.Start(elapsedTime, 10f);
				}
				if (wallBeingLoweredTimer.IsTimerElapsed(elapsedTime))
				{
					Entity entity2 = base.EntityManager.CreateEntity();
					base.EntityManager.AddComponentData(entity2, default(TheGreatWallHasBeenLoweredCD));
					using NativeArray<Entity> nativeArray = subMapQuery.ToEntityArray(Allocator.Temp);
					for (int i = 0; i < nativeArray.Length; i++)
					{
						DynamicBuffer<SubMapLayerBuffer> buffer = base.EntityManager.GetBuffer<SubMapLayerBuffer>(nativeArray[i]);
						for (int num = buffer.Length - 1; num >= 0; num--)
						{
							if (buffer.ElementAt(num).data.layer.tileType == TileType.greatWall)
							{
								buffer.RemoveAtSwapBack(num);
							}
						}
					}
				}
			}
		}
		base.OnUpdate();
	}

	private void TheGreatWallSystem_6025FA32_LambdaJob_0_Execute(ref bool isLowerWallLocal)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		TheGreatWallSystem_6025FA32_LambdaJob_0_Job value = new TheGreatWallSystem_6025FA32_LambdaJob_0_Job
		{
			isLowerWallLocal = isLowerWallLocal,
			__entityTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle
		};
		if (!__query_1875619383_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			TheGreatWallSystem_6025FA32_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_1875619383_0, jobPtr);
		}
		isLowerWallLocal = value.isLowerWallLocal;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PlayerGhost>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<PlayerActivatedWall>();
		__query_1875619383_0 = entityQueryBuilder2.Build(ref state);
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
	public TheGreatWallSystem()
	{
	}
}
