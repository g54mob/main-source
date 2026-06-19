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
using Unity.Physics;

[BurstCompile]
public static class EnvironmentEventBaseCaveIn
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate bool ShouldActivateEvent_0000000D_0024PostfixBurstDelegate(in Entity playerEntity, in int2 playerTilePos, ref Unity.Mathematics.Random rnd, in NativeList<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.ComponentLookups componentLookups);

	internal static class ShouldActivateEvent_0000000D_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<ShouldActivateEvent_0000000D_0024PostfixBurstDelegate>(ShouldActivateEvent).Value;
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
	internal delegate void InitEvent_0000000E_0024PostfixBurstDelegate(in Entity playerEntity, in int2 playerTilePos, ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in NativeArray<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups);

	internal static class InitEvent_0000000E_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<InitEvent_0000000E_0024PostfixBurstDelegate>(InitEvent).Value;
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
	internal delegate void ExecuteEvent_0000000F_0024PostfixBurstDelegate(ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeParallelHashSet<int2> spawnPositions, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups);

	internal static class ExecuteEvent_0000000F_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<ExecuteEvent_0000000F_0024PostfixBurstDelegate>(ExecuteEvent).Value;
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
	[MonoPInvokeCallback(typeof(ShouldActivateEvent_0000000D_0024PostfixBurstDelegate))]
	public static bool ShouldActivateEvent(in Entity playerEntity, in int2 playerTilePos, ref Unity.Mathematics.Random rnd, in NativeList<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		return ShouldActivateEvent_0000000D_0024BurstDirectCall.Invoke(in playerEntity, in playerTilePos, ref rnd, in environmentEventTriggerArray, in componentLookups);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(InitEvent_0000000E_0024PostfixBurstDelegate))]
	public static void InitEvent(in Entity playerEntity, in int2 playerTilePos, ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in NativeArray<EnvironmentEventTriggerCD> environmentEventTriggerArray, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		InitEvent_0000000E_0024BurstDirectCall.Invoke(in playerEntity, in playerTilePos, ref activeEvent, in eventPositions, ref rnd, in environmentEventTriggerArray, in sharedData, in componentLookups);
	}

	[BurstCompile]
	[MonoPInvokeCallback(typeof(ExecuteEvent_0000000F_0024PostfixBurstDelegate))]
	public static void ExecuteEvent(ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeParallelHashSet<int2> spawnPositions, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		ExecuteEvent_0000000F_0024BurstDirectCall.Invoke(ref activeEvent, in spawnPositions, in eventPositions, ref rnd, in sharedData, in componentLookups);
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
		activeEvent.updateCounter = 10;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	internal static void ExecuteEvent_0024BurstManaged(ref EnvironmentEventSystem.EnvironmentEvent activeEvent, in NativeParallelHashSet<int2> spawnPositions, in NativeList<int2> eventPositions, ref Unity.Mathematics.Random rnd, in EnvironmentEventSystem.SharedData sharedData, in EnvironmentEventSystem.ComponentLookups componentLookups)
	{
		CollisionFilter filter = new CollisionFilter
		{
			BelongsTo = uint.MaxValue,
			CollidesWith = 131905u
		};
		if (activeEvent.updateCounter == 10)
		{
			EntityUtility.PlayEffectEventServer(sharedData.ecb, sharedData.effectEventBufferEntity, new EffectEventCD
			{
				position1 = activeEvent.eventPosition.ToFloat3(),
				effectID = EffectID.CaveInEffect
			});
			activeEvent.updateTimer.Start(sharedData.currentTick, 2f, sharedData.tickRate);
		}
		else
		{
			EntityUtility.PlayEffectEventServer(sharedData.ecb, sharedData.effectEventBufferEntity, new EffectEventCD
			{
				position1 = activeEvent.eventPosition.ToFloat3(),
				effectID = EffectID.Rumble
			});
			RandomCD random = new RandomCD
			{
				Value = new Unity.Mathematics.Random(rnd.NextUInt())
			};
			int num = 10;
			for (int i = 0; i < num; i++)
			{
				float2 float5 = rnd.NextFloat2(-1, 1) * 5f;
				float2 x = activeEvent.eventPosition + float5;
				int2 int5 = x.RoundToInt2();
				if (!spawnPositions.Contains(int5) && !sharedData.collisionWorld.SphereCast(new float3(x.x, 0f, x.y), 0.48f, float3.zero, 0f, filter) && sharedData.tileAccessor.GetTop(int5).tileType == TileType.ground)
				{
					Biome biome = sharedData.biomeLookup.GetBiome(int5);
					float3 float6 = int5.ToFloat3();
					ObjectID objectID = ObjectID.FallingRockMortarProjectile;
					if (biome == Biome.Excavation)
					{
						objectID = ObjectID.FallingExcavationRockMortarProjectile;
					}
					Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(objectID, sharedData.databaseBankCD.databaseBankBlob);
					MortarProjectileCD projectile = componentLookups.mortarProjectiles[primaryPrefabEntity];
					EntityUtility.SpawnMortarProjectile(sharedData.ecb, float6, sharedData.databaseBankCD.databaseBankBlob, objectID, 30, hitTiles: false, 0, float6, Entity.Null, projectile, 0f, 0f, 3f, 0f, 0, canShootOnWaterAndPits: false, default(BehaviourTagsCD), componentLookups.summarizedConditionsBufferLookup, default(FactionCD), sharedData.conditionsTableCD, ref random, componentLookups.mortarProjectileDamageEffectLookup);
					spawnPositions.Add(int5);
					break;
				}
			}
			activeEvent.updateTimer.Start(sharedData.currentTick, rnd.NextFloat(0.2f, 0.8f), sharedData.tickRate);
		}
		activeEvent.updateCounter--;
	}
}
