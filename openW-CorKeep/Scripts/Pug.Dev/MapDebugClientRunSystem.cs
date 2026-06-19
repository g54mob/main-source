using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Pug.UnityExtensions;
using PugMod;
using QFSW.QC;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class MapDebugClientRunSystem : PugSimulationSystemBase
{
	private struct MapDebugClientRunSystem_3C7F634B_LambdaJob_0_Job : IJobChunk
	{
		public EntityCommandBuffer ecb;

		public QuantumConsole console;

		[ReadOnly]
		public EntityTypeHandle __eTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<RegenerateTerrainResponse> __responseTypeHandle;

		private void OriginalLambdaBody(Entity e, in RegenerateTerrainResponse response)
		{
			ecb.DestroyEntity(e);
			if (!response.Success)
			{
				console.LogToConsole("Failed to regenerate terrain, most likely because terrain generation is already in progress.");
			}
			else
			{
				Manager.ui.mapUI.Clear();
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __eTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __responseTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RegenerateTerrainResponse>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RegenerateTerrainResponse>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RegenerateTerrainResponse>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RegenerateTerrainResponse>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<MapDebugClientRunSystem_3C7F634B_LambdaJob_0_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct MapDebugClientRunSystem_3C7F634B_LambdaJob_1_Job : IJobChunk
	{
		public MapDebugClientRunSystem __this;

		public EntityCommandBuffer ecb;

		public QuantumConsole console;

		[ReadOnly]
		public EntityTypeHandle __eTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<RevealWholeMapProgressUpdate> __responseTypeHandle;

		private void OriginalLambdaBody(Entity e, in RevealWholeMapProgressUpdate response)
		{
			ecb.DestroyEntity(e);
			console.RemoveLogTrace();
			string text = $"({response.SubmapsUpdated}/{response.TotalSubMapsToUpdate})";
			if (response.SubmapsUpdated == response.TotalSubMapsToUpdate)
			{
				console.LogToConsole("Map has been revealed " + text);
				__this._numDotsAppend = 1;
			}
			else
			{
				string text2 = new string('.', __this._numDotsAppend) + new string(' ', 3 - __this._numDotsAppend);
				console.LogToConsole("Revealing map" + text2 + " " + text);
				__this._numDotsAppend = __this._numDotsAppend % 3 + 1;
			}
		}

		[CompilerGenerated]
		public void Execute(in ArchetypeChunk chunk, int batchIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			IntPtr nativeArrayPtr = InternalCompilerInterface.UnsafeGetChunkEntityArrayIntPtr(chunk, __eTypeHandle);
			IntPtr nativeArrayPtr2 = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk, ref __responseTypeHandle);
			int count = chunk.Count;
			if (!useEnabledMask)
			{
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, i), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RevealWholeMapProgressUpdate>(nativeArrayPtr2, i));
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
						OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, j), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RevealWholeMapProgressUpdate>(nativeArrayPtr2, j));
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
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, k), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RevealWholeMapProgressUpdate>(nativeArrayPtr2, k));
				}
				num >>= 1;
			}
			num = chunkEnabledMask.ULong1;
			for (int l = 64; l < count; l++)
			{
				if ((num & 1) != 0L)
				{
					OriginalLambdaBody(InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Entity>(nativeArrayPtr, l), in InternalCompilerInterface.UnsafeGetRefToNativeArrayPtrElement<RevealWholeMapProgressUpdate>(nativeArrayPtr2, l));
				}
				num >>= 1;
			}
		}

		public static void RunWithoutJobSystem(ref EntityQuery query, IntPtr jobPtr)
		{
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobsInternal(ref InternalCompilerInterface.UnsafeAsRef<MapDebugClientRunSystem_3C7F634B_LambdaJob_1_Job>(jobPtr), ref query);
		}

		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}

	private struct TypeHandle
	{
		[ReadOnly]
		public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<RegenerateTerrainResponse> __RegenerateTerrainResponse_RO_ComponentTypeHandle;

		[ReadOnly]
		public ComponentTypeHandle<RevealWholeMapProgressUpdate> __RevealWholeMapProgressUpdate_RO_ComponentTypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
			__RegenerateTerrainResponse_RO_ComponentTypeHandle = state.GetComponentTypeHandle<RegenerateTerrainResponse>(isReadOnly: true);
			__RevealWholeMapProgressUpdate_RO_ComponentTypeHandle = state.GetComponentTypeHandle<RevealWholeMapProgressUpdate>(isReadOnly: true);
		}
	}

	private const int RECOMMENDED_MAX_EXPLORE_RADIUS = 128;

	private static bool _hasShownLargeRevealRadiusWarning;

	private static bool _hasShownRegenerationWarning;

	private int _numDotsAppend = 1;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_902204373_0;

	private EntityQuery __query_902204373_1;

	[Preserve]
	protected override void OnCreate()
	{
		UpdatesInRunGroup();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		EntityCommandBuffer ecb = CreateCommandBuffer();
		QuantumConsole console = Manager.menu.quantumConsole;
		MapDebugClientRunSystem_3C7F634B_LambdaJob_0_Execute(ref ecb, ref console);
		MapDebugClientRunSystem_3C7F634B_LambdaJob_1_Execute(ref ecb, ref console);
	}

	[Preserve]
	[CommandWithModSupport("revealExploredAreas", "Reveals all explored areas. Might take some time.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void TriggerMapReveal(int explorePlayerRadius = 64)
	{
		if (!_hasShownLargeRevealRadiusWarning && explorePlayerRadius > 128)
		{
			_hasShownLargeRevealRadiusWarning = true;
			Manager.menu.quantumConsole.LogToConsole($"WARNING: You are trying to reveal a large area ({explorePlayerRadius} tiles). " + "World generation might take a very long time, and the game won't close normally until it has completed. " + $"Consider using a smaller radius (recommended max {128} tiles). " + "Repeat command to proceed despite this warning.");
			return;
		}
		EntityManager entityManager = Manager.ecs.ClientWorld.EntityManager;
		Entity entity = Manager.main.player.entity;
		int2 playerPosition = entityManager.GetComponentData<LocalTransform>(entity).Position.xz.RoundToInt2();
		Entity entity2 = entityManager.CreateEntity(typeof(RevealWholeMapRequest), typeof(SendRpcCommandRequest));
		entityManager.SetComponentData(entity2, new RevealWholeMapRequest
		{
			playerPosition = playerPosition,
			generationRadius = explorePlayerRadius
		});
		Manager.menu.quantumConsole.LogToConsole("Awaiting server response...");
	}

	[Preserve]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_DEBUG_MODE")]
	[Conditional("PUG_MARKETING_BUILD")]
	[Command("regenerateExploredAreas", "Regenerates all explored terrain. Might take some time.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public static void TriggerWorldRegeneration()
	{
		if (!_hasShownRegenerationWarning)
		{
			Manager.menu.quantumConsole.LogToConsole("WARNING: You are about to delete all map data and regenerate the world. This cannot be undone and your save file will get overwritten if saves are enabled. Repeat the command to proceed.");
			_hasShownRegenerationWarning = true;
			return;
		}
		EntityManager entityManager = Manager.ecs.ClientWorld.EntityManager;
		Entity entity = entityManager.CreateEntity(typeof(RegenerateTerrainRequest), typeof(SendRpcCommandRequest));
		entityManager.AddComponentData(entity, default(RegenerateTerrainRequest));
	}

	private void MapDebugClientRunSystem_3C7F634B_LambdaJob_0_Execute(ref EntityCommandBuffer ecb, ref QuantumConsole console)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__RegenerateTerrainResponse_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		MapDebugClientRunSystem_3C7F634B_LambdaJob_0_Job value = new MapDebugClientRunSystem_3C7F634B_LambdaJob_0_Job
		{
			ecb = ecb,
			console = console,
			__eTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__responseTypeHandle = __TypeHandle.__RegenerateTerrainResponse_RO_ComponentTypeHandle
		};
		if (!__query_902204373_0.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			MapDebugClientRunSystem_3C7F634B_LambdaJob_0_Job.RunWithoutJobSystem(ref __query_902204373_0, jobPtr);
		}
		ecb = value.ecb;
		console = value.console;
	}

	private void MapDebugClientRunSystem_3C7F634B_LambdaJob_1_Execute(ref EntityCommandBuffer ecb, ref QuantumConsole console)
	{
		__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref base.CheckedStateRef);
		__TypeHandle.__RevealWholeMapProgressUpdate_RO_ComponentTypeHandle.Update(ref base.CheckedStateRef);
		MapDebugClientRunSystem_3C7F634B_LambdaJob_1_Job value = new MapDebugClientRunSystem_3C7F634B_LambdaJob_1_Job
		{
			__this = this,
			ecb = ecb,
			console = console,
			__eTypeHandle = __TypeHandle.__Unity_Entities_Entity_TypeHandle,
			__responseTypeHandle = __TypeHandle.__RevealWholeMapProgressUpdate_RO_ComponentTypeHandle
		};
		if (!__query_902204373_1.IsEmptyIgnoreFilter)
		{
			base.CheckedStateRef.CompleteDependency();
			IntPtr jobPtr = InternalCompilerInterface.AddressOf(ref value);
			MapDebugClientRunSystem_3C7F634B_LambdaJob_1_Job.RunWithoutJobSystem(ref __query_902204373_1, jobPtr);
		}
		ecb = value.ecb;
		console = value.console;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<RegenerateTerrainResponse>();
		__query_902204373_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<RevealWholeMapProgressUpdate>();
		__query_902204373_1 = entityQueryBuilder2.Build(ref state);
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
	public MapDebugClientRunSystem()
	{
	}
}
