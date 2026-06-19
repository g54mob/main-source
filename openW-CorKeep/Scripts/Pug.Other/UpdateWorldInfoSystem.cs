using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.Properties;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;

[BurstCompile]
[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public struct UpdateWorldInfoSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1767277023_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ObjectDataCD Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<ObjectDataCD>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<ObjectDataCD> item1_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<ObjectDataCD>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<ObjectDataCD>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public ObjectDataCD Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRO<ObjectDataCD>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1767277023_1
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public BossStatueCD Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<BossStatueCD>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<BossStatueCD> item1_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<BossStatueCD>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<BossStatueCD>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public BossStatueCD Current => _resolvedChunk.Get(_currentEntityIndex);

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				if (!entityQuery.IsEmptyIgnoreFilter)
				{
					CompleteDependencies(ref state);
					typeHandle.Update(ref state);
				}
				_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
				_currentEntityIndex = -1;
				_endEntityIndex = -1;
				_typeHandle = typeHandle;
				_resolvedChunk = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_entityQueryEnumerator.Dispose();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool MoveNext()
			{
				_currentEntityIndex++;
				if (_currentEntityIndex >= _endEntityIndex)
				{
					if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
					{
						if (movedToNewChunk)
						{
							_resolvedChunk = _typeHandle.Resolve(chunk);
						}
						_currentEntityIndex = entityStartIndex;
						_endEntityIndex = entityEndIndex;
						return true;
					}
					return false;
				}
				return true;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
		{
			return new Enumerator(entityQuery, typeHandle, ref state);
		}

		public static void CompleteDependencies(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRO<BossStatueCD>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1767277023_0.TypeHandle __IFE_1767277023_0_TypeHandle;

		public IFE_1767277023_1.TypeHandle __IFE_1767277023_1_TypeHandle;

		[ReadOnly]
		public ComponentLookup<WorldInfoCD> __WorldInfoCD_RO_ComponentLookup;

		public ComponentLookup<WorldInfoCD> __WorldInfoCD_RW_ComponentLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1767277023_0_TypeHandle = new IFE_1767277023_0.TypeHandle(ref state);
			__IFE_1767277023_1_TypeHandle = new IFE_1767277023_1.TypeHandle(ref state);
			__WorldInfoCD_RO_ComponentLookup = state.GetComponentLookup<WorldInfoCD>(isReadOnly: true);
			__WorldInfoCD_RW_ComponentLookup = state.GetComponentLookup<WorldInfoCD>();
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void __codegen__OnUpdate_00004853_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnUpdate_00004853_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00004853_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
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
	internal delegate void __codegen__OnStopRunning_00004855_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

	internal static class __codegen__OnStopRunning_00004855_0024BurstDirectCall
	{
		private static IntPtr Pointer;

		[BurstDiscard]
		private static void GetFunctionPointerDiscard(ref IntPtr P_0)
		{
			if (Pointer == (IntPtr)0)
			{
				Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00004855_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
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
			__codegen__OnStopRunning_0024BurstManaged(self, state);
		}
	}

	public const int VariableUpdateRateOffset = 0;

	public const int VariableUpdateMinimumUpdateRate = 1;

	private int _isMainStoryBossProperty;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1767277023_0;

	private EntityQuery __query_1767277023_1;

	private EntityQuery __query_1767277023_2;

	private EntityQuery __query_1767277023_3;

	private EntityQuery __query_1767277023_4;

	private EntityQuery __query_1767277023_5;

	private EntityQuery __query_1767277023_6;

	private EntityQuery __query_1767277023_7;

	private EntityQuery __query_1767277023_8;

	private EntityQuery __query_1767277023_9;

	private EntityQuery __query_1767277023_10;

	public void OnCreate(ref SystemState state)
	{
		state.RequireForUpdate<PugPrefabBuffer>();
		state.RequireForUpdate<KilledEnemiesBuffer>();
		state.RequireForUpdate<DatabaseCD>();
		if (!__query_1767277023_3.HasSingleton<KilledEnemiesBuffer>())
		{
			state.EntityManager.CreateSingletonBuffer<KilledEnemiesBuffer>();
		}
		_isMainStoryBossProperty = Property.StringToHash("isMainStoryBoss");
	}

	public void OnStartRunning(ref SystemState state)
	{
		if (__query_1767277023_4.HasSingleton<WorldInfoCD>())
		{
			return;
		}
		Entity entity = Entity.Null;
		DynamicBuffer<PugPrefabBuffer> singletonBuffer = __query_1767277023_5.GetSingletonBuffer<PugPrefabBuffer>();
		for (int i = 0; i < singletonBuffer.Length; i++)
		{
			if (InternalCompilerInterface.HasComponentAfterCompletingDependency(ref __TypeHandle.__WorldInfoCD_RO_ComponentLookup, ref state, singletonBuffer[i].Value))
			{
				entity = state.EntityManager.Instantiate(singletonBuffer[i].Value);
				break;
			}
		}
		WorldInfoCD componentAfterCompletingDependency = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__WorldInfoCD_RO_ComponentLookup, ref state, entity);
		if (Manager.saves.IsWorldModeEnabled(WorldMode.Creative))
		{
			componentAfterCompletingDependency.simulationDisabled = true;
		}
		componentAfterCompletingDependency.worldModeMask = Manager.saves.GetWorldMode();
		InternalCompilerInterface.SetComponentAfterCompletingDependency(ref __TypeHandle.__WorldInfoCD_RW_ComponentLookup, ref state, componentAfterCompletingDependency, entity);
	}

	[BurstCompile]
	public void OnStopRunning(ref SystemState state)
	{
	}

	[BurstCompile]
	public void OnUpdate(ref SystemState state)
	{
		NetworkTime singleton = __query_1767277023_6.GetSingleton<NetworkTime>();
		if (!VariableSystemUpdate.ShouldUpdate(ref state, singleton, 0, 1f))
		{
			return;
		}
		WorldInfoCD singleton2 = __query_1767277023_4.GetSingleton<WorldInfoCD>();
		singleton2.greatWallHasBeenLowered = __query_1767277023_7.HasSingleton<TheGreatWallHasBeenLoweredCD>();
		singleton2.slimeMerchantExists = false;
		foreach (ObjectDataCD item in IFE_1767277023_0.Query(__query_1767277023_0, __TypeHandle.__IFE_1767277023_0_TypeHandle, ref state))
		{
			if (item.objectID == ObjectID.SlimeMerchant)
			{
				singleton2.slimeMerchantExists = true;
				break;
			}
		}
		bool flag = false;
		singleton2.larvaBossStatueIsActivated = false;
		singleton2.hiveBossStatueIsActivated = false;
		foreach (BossStatueCD item2 in IFE_1767277023_1.Query(__query_1767277023_1, __TypeHandle.__IFE_1767277023_1_TypeHandle, ref state))
		{
			if (item2.acceptsCrystalID == ObjectID.SlimeBossCrystal)
			{
				flag |= item2.hasCrystal;
			}
			else if (item2.acceptsCrystalID == ObjectID.LarvaBossCrystal)
			{
				singleton2.larvaBossStatueIsActivated |= item2.hasCrystal;
			}
			else if (item2.acceptsCrystalID == ObjectID.HiveBossCrystal)
			{
				singleton2.hiveBossStatueIsActivated |= item2.hasCrystal;
			}
		}
		singleton2.coreIsActivated = flag && singleton2.larvaBossStatueIsActivated && singleton2.hiveBossStatueIsActivated;
		singleton2.numberPlayers = __query_1767277023_2.CalculateEntityCount();
		singleton2.bossesKilled = 0;
		singleton2.coreBossHasBeenKilled = false;
		singleton2.wallBossHasBeenKilled = false;
		DynamicBuffer<KilledEnemiesBuffer> singletonBuffer = __query_1767277023_8.GetSingletonBuffer<KilledEnemiesBuffer>();
		PropertyLookup objectPropertyLookup = __query_1767277023_9.GetSingleton<DatabaseCD>().ObjectPropertyLookup;
		foreach (KilledEnemiesBuffer item3 in singletonBuffer)
		{
			if (objectPropertyLookup.HasProperty((int)item3.objectData.objectID, _isMainStoryBossProperty))
			{
				singleton2.bossesKilled++;
			}
			switch (item3.objectData.objectID)
			{
			case ObjectID.CoreBoss:
				singleton2.coreBossHasBeenKilled = true;
				break;
			case ObjectID.WallBoss:
				singleton2.wallBossHasBeenKilled = true;
				break;
			case ObjectID.BirdBoss:
				singleton2.birdBossBeenKilled = true;
				break;
			case ObjectID.OctopusBoss:
				singleton2.octopusBossHasBeenKilled = true;
				break;
			case ObjectID.ScarabBoss:
				singleton2.scarabHasBeenKilled = true;
				break;
			case ObjectID.HydraBossNature:
				singleton2.hydraBossNatureHasBeenKilled = true;
				break;
			case ObjectID.HydraBossSea:
				singleton2.hydraBossSeaHasBeenKilled = true;
				break;
			case ObjectID.HydraBossDesert:
				singleton2.hydraBossDesertHasBeenKilled = true;
				break;
			case ObjectID.GiantCicadaBoss:
				singleton2.giantCicadaBossHasBeenKilled = true;
				break;
			case ObjectID.RobotBoss:
				singleton2.robotBossHasBeenKilled = true;
				break;
			}
		}
		__query_1767277023_10.SetSingleton(singleton2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithNone<EntityDestroyedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<MerchantCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<ObjectDataCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_1767277023_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<BossStatueCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeDisabledEntities);
		__query_1767277023_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkStreamInGame>();
		__query_1767277023_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<KilledEnemiesBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1767277023_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1767277023_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<PugPrefabBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1767277023_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1767277023_6 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<TheGreatWallHasBeenLoweredCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1767277023_7 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<KilledEnemiesBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1767277023_8 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<DatabaseCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1767277023_9 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<WorldInfoCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1767277023_10 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
	{
		((UpdateWorldInfoSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		__codegen__OnUpdate_00004853_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
	{
		((UpdateWorldInfoSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
	}

	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
	{
		__codegen__OnStopRunning_00004855_0024BurstDirectCall.Invoke(self, state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((UpdateWorldInfoSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UpdateWorldInfoSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[BurstCompile]
	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
	{
		((UpdateWorldInfoSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
	}
}
