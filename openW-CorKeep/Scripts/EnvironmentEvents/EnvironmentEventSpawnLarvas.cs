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
public static class EnvironmentEventSpawnLarvas
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate bool ShouldActivateEvent_00000013_0024PostfixBurstDelegate(in Entity playerEntity, in int2 playerTilePos, ref Unity.Mathematics.Random rnd, in NativeList<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.ComponentLookups componentLookups);

	internal static class ShouldActivateEvent_00000013_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<ShouldActivateEvent_00000013_0024PostfixBurstDelegate>(ShouldActivateEvent).Value;
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
	internal delegate void InitEvent_00000014_0024PostfixBurstDelegate(in Entity playerEntity, in int2 playerTilePos, ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in NativeArray<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups);

	internal static class InitEvent_00000014_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<InitEvent_00000014_0024PostfixBurstDelegate>(InitEvent).Value;
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
	internal delegate void ExecuteEvent_00000015_0024PostfixBurstDelegate(ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeParallelHashSet<int2> spawnPositions, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups);

	internal static class ExecuteEvent_00000015_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<ExecuteEvent_00000015_0024PostfixBurstDelegate>(ExecuteEvent).Value;
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
	[MonoPInvokeCallback(typeof(ShouldActivateEvent_00000013_0024PostfixBurstDelegate))]
	public static bool ShouldActivateEvent(in Entity playerEntity, in int2 playerTilePos, ref Unity.Mathematics.Random rnd, in NativeList<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		return ShouldActivateEvent_00000013_0024BurstDirectCall.Invoke(in playerEntity, in playerTilePos, ref rnd, in environmentEventTriggerArray, in componentLookups);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(InitEvent_00000014_0024PostfixBurstDelegate))]
	public static void InitEvent(in Entity playerEntity, in int2 playerTilePos, ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in NativeArray<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		InitEvent_00000014_0024BurstDirectCall.Invoke(in playerEntity, in playerTilePos, ref activeEvent, in eventPositions, ref rnd, in environmentEventTriggerArray, in sharedData, in componentLookups);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(ExecuteEvent_00000015_0024PostfixBurstDelegate))]
	public static void ExecuteEvent(ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeParallelHashSet<int2> spawnPositions, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		ExecuteEvent_00000015_0024BurstDirectCall.Invoke(ref activeEvent, in spawnPositions, in eventPositions, ref rnd, in sharedData, in componentLookups);
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
		activeEvent.updateCounter = 4;
		Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(ObjectID.WallClayBlock, sharedData.databaseBankCD.databaseBankBlob);
		activeEvent.int1 = componentLookups.healths[primaryPrefabEntity].maxHealth / 3;
		int num = rnd.NextInt(8, 13);
		NativeList<int2> nativeList = new NativeList<int2>(num, Allocator.Temp);
		for (int i = 1; i <= 4; i++)
		{
			for (int j = -i; j <= i; j++)
			{
				for (int k = -i; k <= i; k++)
				{
					if (math.abs(j) == i || math.abs(k) == i)
					{
						int2 value = activeEvent.eventPosition + new int2(j, k);
						TileCD top = sharedData.tileAccessor.GetTop(value);
						if (top.tileType == TileType.wall && top.tileset == 11)
						{
							nativeList.Add(in value);
						}
					}
				}
			}
			int num2 = math.min(num, nativeList.Length);
			for (int l = 0; l < num2; l++)
			{
				int index = rnd.NextInt(nativeList.Length);
				int2 value2 = nativeList[index];
				eventPositions.Add(in value2);
				nativeList.RemoveAtSwapBack(index);
			}
			num -= num2;
			if (num <= 0)
			{
				break;
			}
		}
		nativeList.Dispose();
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void ExecuteEvent_0024BurstManaged(ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeParallelHashSet<int2> spawnPositions, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		bool flag = activeEvent.updateCounter == 1;
		bool flag2 = false;
		for (int i = 0; i < eventPositions.Length; i++)
		{
			int2 int5 = eventPositions[i];
			if (!sharedData.tileAccessor.HasTypeAndTileset(int5, TileType.wall, 11))
			{
				continue;
			}
			flag2 = true;
			sharedData.ecb.AppendToBuffer(sharedData.tileDamageBufferEntity, new TileDamageBuffer
			{
				damage = (flag ? 1000 : activeEvent.int1),
				position = int5,
				skipWallAndRootsLootDropOnDestroy = true,
				canHitLowColliders = true
			});
			if (flag)
			{
				if (rnd.NextFloat() < 0.2f)
				{
					EntityUtility.CreateEntity(sharedData.ecb, new float3(int5.x, 0f, int5.y), ObjectID.BigLarva, 1, sharedData.databaseBankCD.databaseBankBlob);
				}
				else
				{
					EntityUtility.CreateEntity(sharedData.ecb, new float3(int5.x, 0f, int5.y), ObjectID.Larva, 1, sharedData.databaseBankCD.databaseBankBlob);
				}
			}
		}
		if (flag2)
		{
			EntityUtility.PlayEffectEventServer(sharedData.ecb, sharedData.effectEventBufferEntity, new EffectEventCD
			{
				position1 = activeEvent.eventPosition.ToFloat3(),
				effectID = ((activeEvent.updateCounter == 4 || activeEvent.updateCounter == 3) ? EffectID.SmallRumble : EffectID.Rumble)
			});
		}
		activeEvent.updateTimer.Start(sharedData.currentTick, 1.5f, sharedData.tickRate);
		activeEvent.updateCounter--;
	}
}
