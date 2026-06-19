using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
public class EffectEventClientSystem : SystemBase
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_208701793_0
	{
		public struct ResolvedChunk
		{
			public IntPtr item1_IntPtr;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public EffectEventRpc Get(int index)
			{
				return InternalCompilerInterface.UnsafeGetCopyOfNativeArrayPtrElement<EffectEventRpc>(item1_IntPtr, index);
			}
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<EffectEventRpc> item1_ComponentTypeHandle_RO;

			public TypeHandle(ref SystemState systemState)
			{
				item1_ComponentTypeHandle_RO = systemState.GetComponentTypeHandle<EffectEventRpc>(isReadOnly: true);
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

		public struct Enumerator : IEnumerator<EffectEventRpc>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public EffectEventRpc Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRO<EffectEventRpc>();
		}
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private readonly struct IFE_208701793_1
	{
		public struct ResolvedChunk
		{
			public BufferAccessor<EffectEventBuffer> item1_BufferAccessor;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public DynamicBuffer<EffectEventBuffer> Get(int index)
			{
				return item1_BufferAccessor[index];
			}
		}

		public struct TypeHandle
		{
			private BufferTypeHandle<EffectEventBuffer> item1_BufferTypeHandle_RW;

			public TypeHandle(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW = systemState.GetBufferTypeHandle<EffectEventBuffer>();
			}

			public void Update(ref SystemState systemState)
			{
				item1_BufferTypeHandle_RW.Update(ref systemState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
			{
				return new ResolvedChunk
				{
					item1_BufferAccessor = archetypeChunk.GetBufferAccessor(ref item1_BufferTypeHandle_RW)
				};
			}
		}

		public struct Enumerator : IEnumerator<DynamicBuffer<EffectEventBuffer>>, IEnumerator, IDisposable
		{
			private InternalEntityQueryEnumerator _entityQueryEnumerator;

			private TypeHandle _typeHandle;

			private ResolvedChunk _resolvedChunk;

			private int _currentEntityIndex;

			private int _endEntityIndex;

			public DynamicBuffer<EffectEventBuffer> Current => _resolvedChunk.Get(_currentEntityIndex);

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
			state.EntityManager.CompleteDependencyBeforeRW<EffectEventBuffer>();
		}
	}

	private struct TypeHandle
	{
		public IFE_208701793_0.TypeHandle __IFE_208701793_0_TypeHandle;

		public IFE_208701793_1.TypeHandle __IFE_208701793_1_TypeHandle;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__IFE_208701793_0_TypeHandle = new IFE_208701793_0.TypeHandle(ref state);
			__IFE_208701793_1_TypeHandle = new IFE_208701793_1.TypeHandle(ref state);
		}
	}

	private TypeHandle __TypeHandle;

	private EntityQuery __query_208701793_0;

	private EntityQuery __query_208701793_1;

	private EntityQuery __query_208701793_2;

	[Preserve]
	protected override void OnCreate()
	{
		base.EntityManager.CreateEntity(typeof(EffectEventBuffer));
		RequireForUpdate<EffectEventBuffer>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		float3 float5 = Manager.camera.RenderOrigo.ToFloat3();
		foreach (EffectEventRpc item in IFE_208701793_0.Query(__query_208701793_0, __TypeHandle.__IFE_208701793_0_TypeHandle, ref base.CheckedStateRef))
		{
			EffectEventCD value = item.Value;
			value.position1 -= float5;
			EffectEventExtensions.PlayEffect(value, Entity.Null, base.World);
		}
		foreach (DynamicBuffer<EffectEventBuffer> item2 in IFE_208701793_1.Query(__query_208701793_1, __TypeHandle.__IFE_208701793_1_TypeHandle, ref base.CheckedStateRef))
		{
			for (int i = 0; i < item2.Length; i++)
			{
				EffectEventCD value2 = item2[i].Value;
				value2.position1 -= float5;
				EffectEventExtensions.PlayEffect(value2, Entity.Null, base.World);
			}
			item2.Clear();
		}
		base.EntityManager.DestroyEntity(__query_208701793_2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ReceiveRpcCommandRequest>();
		entityQueryBuilder2 = entityQueryBuilder2.WithAll<EffectEventRpc>();
		__query_208701793_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<EffectEventBuffer>();
		__query_208701793_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		__query_208701793_1.SetChangedVersionFilter(new ComponentType[1]
		{
			new ComponentType(typeof(EffectEventBuffer))
		});
		entityQueryBuilder2 = entityQueryBuilder.WithAll<EffectEventRpc, ReceiveRpcCommandRequest>();
		__query_208701793_2 = entityQueryBuilder2.Build(ref state);
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
	public EffectEventClientSystem()
	{
	}
}
