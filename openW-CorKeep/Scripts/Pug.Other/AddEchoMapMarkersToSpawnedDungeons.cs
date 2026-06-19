using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[DisableAutoCreation]
public struct AddEchoMapMarkersToSpawnedDungeons : ISystem, ISystemCompilerGenerated
{
	private struct MarkerInfo
	{
		public FixedString32Bytes DungeonName;

		public int MarkerVariation;
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_1361390755_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			public IntPtr item2_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public (DungeonNameSerializedCD, Translation) Get(int index)
			{
				return (InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<DungeonNameSerializedCD>(item1_IntPtr, index), InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<Translation>(item2_IntPtr, index));
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<DungeonNameSerializedCD> item1_ComponentTypeHandle_RO;

			[ReadOnly]
			private ComponentTypeHandle<Translation> item2_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<DungeonNameSerializedCD>(isReadOnly: true);
				item2_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<Translation>(isReadOnly: true);
			}

			public void Update(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO.Update(ref systemState);
				item2_ComponentTypeHandle_RO.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item1_ComponentTypeHandle_RO),
					item2_IntPtr = InternalCompilerInterface.UnsafeGetChunkNativeArrayReadOnlyIntPtrWithoutChecks(in archetypeChunk, ref item2_ComponentTypeHandle_RO)
				};
			}
		}

		public struct Enumerator : IEnumerator<(DungeonNameSerializedCD, Translation)>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public (DungeonNameSerializedCD, Translation) Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<DungeonNameSerializedCD>();
			state.EntityManager.CompleteDependencyBeforeRO<Translation>();
		}
	}

	private struct TypeHandle
	{
		public IFE_1361390755_0.TypeHandle __IFE_1361390755_0_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_1361390755_0_TypeHandle = new IFE_1361390755_0.TypeHandle(ref state);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_1361390755_0;

	private EntityQuery __query_1361390755_1;

	public void OnUpdate(ref SystemState state)
	{
		state.Enabled = false;
		if (__query_1361390755_1.TryGetSingleton<WorldVersionSerializedCD>(out var value) && value.Version >= 10)
		{
			return;
		}
		Debug.Log("Converting world to version 10; retroactively adding echo map markers to spawned dungeons");
		EntityArchetype archetype = state.EntityManager.CreateArchetype(typeof(Translation), typeof(ObjectDataSerializedCD), typeof(CustomSceneObjectSerializedCD));
		NativeList<MarkerInfo> nativeList = new NativeList<MarkerInfo>(16, Allocator.Temp);
		nativeList.Add(new MarkerInfo
		{
			DungeonName = "FishingMerchantArea",
			MarkerVariation = 30
		});
		nativeList.Add(new MarkerInfo
		{
			DungeonName = "WorshipMuralNature",
			MarkerVariation = 31
		});
		nativeList.Add(new MarkerInfo
		{
			DungeonName = "ShrineRoom",
			MarkerVariation = 32
		});
		nativeList.Add(new MarkerInfo
		{
			DungeonName = "BindingStringScene",
			MarkerVariation = 33
		});
		nativeList.Add(new MarkerInfo
		{
			DungeonName = "TitanTemple",
			MarkerVariation = 34
		});
		nativeList.Add(new MarkerInfo
		{
			DungeonName = "AlienTerminal1",
			MarkerVariation = 35
		});
		nativeList.Add(new MarkerInfo
		{
			DungeonName = "AlienTerminal2",
			MarkerVariation = 36
		});
		nativeList.Add(new MarkerInfo
		{
			DungeonName = "AlienTerminal3",
			MarkerVariation = 37
		});
		NativeHashMap<FixedString32Bytes, Translation> nativeHashMap = new NativeHashMap<FixedString32Bytes, Translation>(16, Allocator.Temp);
		foreach (var item4 in IFE_1361390755_0.Query(__query_1361390755_0, __TypeHandle.__IFE_1361390755_0_TypeHandle, ref state))
		{
			DungeonNameSerializedCD item = item4.Item1;
			Translation item2 = item4.Item2;
			FixedString32Bytes key = DungeonNameSerializedCD.AsFixedString32Bytes(item);
			nativeHashMap.Add(key, item2);
		}
		foreach (MarkerInfo item5 in nativeList)
		{
			if (nativeHashMap.TryGetValue(item5.DungeonName, out var item3))
			{
				Entity entity = state.EntityManager.CreateEntity(archetype);
				state.EntityManager.SetComponentData(entity, new Translation
				{
					Value = math.round(item3.Value)
				});
				state.EntityManager.SetComponentData(entity, new ObjectDataSerializedCD
				{
					ObjectID = ObjectID.MapMarker,
					Variation = item5.MarkerVariation
				});
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<DungeonNameSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<Translation>();
		__query_1361390755_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldVersionSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_1361390755_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	public void OnCreateForCompiler(ref SystemState state)
	{
		__AssignQueries(ref state);
		__TypeHandle.__AssignHandles(ref state);
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
	{
		((AddEchoMapMarkersToSpawnedDungeons*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
	}

	[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
	internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
	{
		((AddEchoMapMarkersToSpawnedDungeons*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
	}
}
