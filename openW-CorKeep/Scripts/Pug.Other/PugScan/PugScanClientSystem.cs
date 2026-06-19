using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;
using UnityEngine.Scripting;

namespace PugScan
{
	[BurstCompile]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(RunSimulationSystemGroup))]
	public class PugScanClientSystem : SystemBase
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_80437136_0
		{
			public struct ResolvedChunk
			{
				public IntPtr item1_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public PugScanResponseRpc Get(int index)
				{
					return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<PugScanResponseRpc>(item1_IntPtr, index);
				}
			}

			public struct TypeHandle
			{
				[ReadOnly]
				private ComponentTypeHandle<PugScanResponseRpc> item1_ComponentTypeHandle_RO;

				public TypeHandle(ref SystemState systemState)
				{
					item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<PugScanResponseRpc>(isReadOnly: true);
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

			public struct Enumerator : IEnumerator<PugScanResponseRpc>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public PugScanResponseRpc Current => _resolvedChunk.Get(_currentEntityIndex);

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
				state.EntityManager.CompleteDependencyBeforeRO<PugScanResponseRpc>();
			}
		}

		private struct TypeHandle
		{
			public IFE_80437136_0.TypeHandle __IFE_80437136_0_TypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_80437136_0_TypeHandle = new IFE_80437136_0.TypeHandle(ref state);
			}
		}

		private EntityArchetype _rpcArchetype;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_80437136_0;

		private EntityQuery __query_80437136_1;

		public void Scan(ScanRequestCD scanRequestCD)
		{
			Entity entity = base.EntityManager.CreateEntity(_rpcArchetype);
			base.EntityManager.SetComponentData(entity, new PugScanRpc
			{
				scanRequestCD = scanRequestCD
			});
		}

		[Preserve]
		protected override void OnCreate()
		{
			_rpcArchetype = base.EntityManager.CreateArchetype(typeof(PugScanRpc), typeof(SendRpcCommandRequest));
		}

		[Preserve]
		protected override void OnUpdate()
		{
			PlayerController player = Manager.main.player;
			if (player != null)
			{
				foreach (PugScanResponseRpc item in IFE_80437136_0.Query(__query_80437136_0, __TypeHandle.__IFE_80437136_0_TypeHandle, ref base.CheckedStateRef))
				{
					switch (item.code)
					{
					case PugScanReturnCode.Success:
						if (!Manager.ui.isShowingMap)
						{
							Manager.ui.ShowMapLightUpHint();
						}
						break;
					case PugScanReturnCode.NotFound:
						Emote.SpawnEmoteText(player.center, Emote.EmoteType.NothingWasFound);
						break;
					case PugScanReturnCode.AlreadyScanned:
						Emote.SpawnEmoteText(player.center, Emote.EmoteType.AlreadyScanned);
						break;
					case PugScanReturnCode.AlreadyExists:
						Emote.SpawnEmoteText(player.center, Emote.EmoteType.NothingHappens);
						break;
					}
				}
			}
			base.EntityManager.DestroyEntity(__query_80437136_1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PugScanResponseRpc>();
			__query_80437136_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugScanResponseRpc>();
			__query_80437136_1 = entityQueryBuilder2.Build(ref state);
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
		public PugScanClientSystem()
		{
		}
	}
}
