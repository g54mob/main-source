using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using EnvironmentEvents.Components;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

[BurstCompile]
public static class EnvironmentEventSpawnOmorothTentacles
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate bool ShouldActivateEvent_00000016_0024PostfixBurstDelegate(in Entity playerEntity, in int2 playerTilePos, ref Unity.Mathematics.Random rnd, in NativeList<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.ComponentLookups componentLookups);

	internal static class ShouldActivateEvent_00000016_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<ShouldActivateEvent_00000016_0024PostfixBurstDelegate>(ShouldActivateEvent).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static bool Invoke(in Entity playerEntity, in int2 playerTilePos, ref Unity.Mathematics.Random rnd, in NativeList<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.ComponentLookups componentLookups)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					return ((delegate* unmanaged[Cdecl]<ref Entity, ref int2, ref Unity.Mathematics.Random, ref NativeList<EnvironmentEventTriggerCD>, ref EnvironmentEventSystem.ComponentLookups, bool>)functionPointer)(ref playerEntity, ref playerTilePos, ref rnd, ref environmentEventTriggerArray, ref componentLookups);
				}
			}
			return ShouldActivateEvent_0024BurstManaged(in playerEntity, in playerTilePos, ref rnd, in environmentEventTriggerArray, in componentLookups);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void InitEvent_00000017_0024PostfixBurstDelegate(in Entity playerEntity, in int2 playerTilePos, ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in NativeArray<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups);

	internal static class InitEvent_00000017_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<InitEvent_00000017_0024PostfixBurstDelegate>(InitEvent).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(in Entity playerEntity, in int2 playerTilePos, ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in NativeArray<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref Entity, ref int2, ref EnvironmentEventSystem.EnvironmentEvent, ref NativeList<int2>, ref Unity.Mathematics.Random, ref NativeArray<EnvironmentEventTriggerCD>, ref EnvironmentEventSystem.SharedData, ref EnvironmentEventSystem.ComponentLookups, void>)functionPointer)(ref playerEntity, ref playerTilePos, ref activeEvent, ref eventPositions, ref rnd, ref environmentEventTriggerArray, ref sharedData, ref componentLookups);
					return;
				}
			}
			InitEvent_0024BurstManaged(in playerEntity, in playerTilePos, ref activeEvent, in eventPositions, ref rnd, in environmentEventTriggerArray, in sharedData, in componentLookups);
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void ExecuteEvent_00000018_0024PostfixBurstDelegate(ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeParallelHashSet<int2> spawnPositions, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups);

	internal static class ExecuteEvent_00000018_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<ExecuteEvent_00000018_0024PostfixBurstDelegate>(ExecuteEvent).Value;
			}
			P_0 = Pointer;
		}

		private static IntPtr GetFunctionPointer()
		{
			nint result = 0;
			GetFunctionPointerDiscard(ref result);
			return result;
		}

		public unsafe static void Invoke(ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeParallelHashSet<int2> spawnPositions, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups)
		{
			if (BurstCompiler.IsEnabled)
			{
				IntPtr functionPointer = GetFunctionPointer();
				if (functionPointer != (IntPtr)0)
				{
					((delegate* unmanaged[Cdecl]<ref EnvironmentEventSystem.EnvironmentEvent, ref NativeParallelHashSet<int2>, ref NativeList<int2>, ref Unity.Mathematics.Random, ref EnvironmentEventSystem.SharedData, ref EnvironmentEventSystem.ComponentLookups, void>)functionPointer)(ref activeEvent, ref spawnPositions, ref eventPositions, ref rnd, ref sharedData, ref componentLookups);
					return;
				}
			}
			ExecuteEvent_0024BurstManaged(ref activeEvent, in spawnPositions, in eventPositions, ref rnd, in sharedData, in componentLookups);
		}
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(ShouldActivateEvent_00000016_0024PostfixBurstDelegate))]
	public static bool ShouldActivateEvent(in Entity playerEntity, in int2 playerTilePos, ref Unity.Mathematics.Random rnd, in NativeList<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		return ShouldActivateEvent_00000016_0024BurstDirectCall.Invoke(in playerEntity, in playerTilePos, ref rnd, in environmentEventTriggerArray, in componentLookups);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(InitEvent_00000017_0024PostfixBurstDelegate))]
	public static void InitEvent(in Entity playerEntity, in int2 playerTilePos, ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in NativeArray<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		InitEvent_00000017_0024BurstDirectCall.Invoke(in playerEntity, in playerTilePos, ref activeEvent, in eventPositions, ref rnd, in environmentEventTriggerArray, in sharedData, in componentLookups);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(ExecuteEvent_00000018_0024PostfixBurstDelegate))]
	public static void ExecuteEvent(ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeParallelHashSet<int2> spawnPositions, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		ExecuteEvent_00000018_0024BurstDirectCall.Invoke(ref activeEvent, in spawnPositions, in eventPositions, ref rnd, in sharedData, in componentLookups);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static bool ShouldActivateEvent_0024BurstManaged(in Entity playerEntity, in int2 playerTilePos, ref Unity.Mathematics.Random rnd, in NativeList<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void InitEvent_0024BurstManaged(in Entity playerEntity, in int2 playerTilePos, ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in NativeArray<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		activeEvent.updateCounter = 5;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void ExecuteEvent_0024BurstManaged(ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeParallelHashSet<int2> spawnPositions, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		if (activeEvent.updateCounter == 5)
		{
			EntityUtility.PlayEffectEventServer(sharedData.ecb, sharedData.effectEventBufferEntity, new EffectEventCD
			{
				position1 = activeEvent.eventPosition.ToFloat3(),
				effectID = EffectID.MysteriousSunkenSeaRumble
			});
			activeEvent.updateTimer.Start(sharedData.currentTick, 1.5f, sharedData.tickRate);
		}
		else
		{
			for (int i = 0; i < 3; i++)
			{
				float2 float5 = rnd.NextFloat2(-1, 1);
				float5 = float5 * 4f + math.normalizesafe(float5) * 2f;
				int2 int5 = activeEvent.eventPosition;
				if (componentLookups.localTransforms.HasComponent(activeEvent.playerEntity))
				{
					int2 int6 = componentLookups.localTransforms[activeEvent.playerEntity].Position.RoundToInt2();
					if (math.distance(int6, activeEvent.eventPosition) < 15f)
					{
						int5 = int6;
					}
				}
				float2 x = int5 + float5;
				int2 int7 = x.RoundToInt2();
				bool flag = true;
				for (int j = 0; j < 2; j++)
				{
					for (int k = 0; k < 2; k++)
					{
						int2 worldPosition = int7 + new int2(j, k);
						TileCD top = sharedData.tileAccessor.GetTop(worldPosition);
						if (top.tileType != TileType.water || top.tileset != 10)
						{
							flag = false;
							break;
						}
					}
					if (!flag)
					{
						break;
					}
				}
				if (flag)
				{
					float3 position = x.ToFloat3();
					EntityUtility.CreateEntity(sharedData.ecb, position, ObjectID.OctopusTentacle, 1, sharedData.databaseBankCD.databaseBankBlob);
					break;
				}
			}
			activeEvent.updateTimer.Start(sharedData.currentTick, rnd.NextFloat(0.7f, 1.2f), sharedData.tickRate);
		}
		activeEvent.updateCounter--;
	}
}
