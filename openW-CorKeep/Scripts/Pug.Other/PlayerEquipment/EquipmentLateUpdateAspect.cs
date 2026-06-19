using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Transforms;

namespace PlayerEquipment
{
	public readonly struct EquipmentLateUpdateAspect : IAspect, IQueryTypeParameter, IAspectCreate<EquipmentLateUpdateAspect>
	{
		public struct Lookup : InternalCompilerInterface.IAspectLookup<EquipmentLateUpdateAspect>
		{
			[ReadOnly]
			private ComponentLookup<EquippedObjectCD> EquipmentLateUpdateAspect_equippedObjectCDCAc;

			private BufferLookup<GhostEffectEventBuffer> EquipmentLateUpdateAspect_ghostEffectEventBufferBAc;

			private ComponentLookup<GhostEffectEventBufferPointerCD> EquipmentLateUpdateAspect_ghostEffectEventBufferPointerCDCAc;

			private ComponentLookup<EquipmentSlotCD> EquipmentLateUpdateAspect_equipmentCDCAc;

			[ReadOnly]
			private ComponentLookup<LocalTransform> EquipmentLateUpdateAspect_localTransformCAc;

			public EquipmentLateUpdateAspect this[Entity entity] => new EquipmentLateUpdateAspect(EquipmentLateUpdateAspect_equippedObjectCDCAc.GetRefRO(entity), EquipmentLateUpdateAspect_ghostEffectEventBufferBAc[entity], EquipmentLateUpdateAspect_ghostEffectEventBufferPointerCDCAc.GetRefRW(entity), EquipmentLateUpdateAspect_equipmentCDCAc.GetRefRW(entity), EquipmentLateUpdateAspect_localTransformCAc.GetRefRO(entity));

			public Lookup(ref SystemState state)
			{
				EquipmentLateUpdateAspect_equippedObjectCDCAc = state.GetComponentLookup<EquippedObjectCD>(isReadOnly: true);
				EquipmentLateUpdateAspect_ghostEffectEventBufferBAc = state.GetBufferLookup<GhostEffectEventBuffer>();
				EquipmentLateUpdateAspect_ghostEffectEventBufferPointerCDCAc = state.GetComponentLookup<GhostEffectEventBufferPointerCD>();
				EquipmentLateUpdateAspect_equipmentCDCAc = state.GetComponentLookup<EquipmentSlotCD>();
				EquipmentLateUpdateAspect_localTransformCAc = state.GetComponentLookup<LocalTransform>(isReadOnly: true);
			}

			public void Update(ref SystemState state)
			{
				EquipmentLateUpdateAspect_equippedObjectCDCAc.Update(ref state);
				EquipmentLateUpdateAspect_ghostEffectEventBufferBAc.Update(ref state);
				EquipmentLateUpdateAspect_ghostEffectEventBufferPointerCDCAc.Update(ref state);
				EquipmentLateUpdateAspect_equipmentCDCAc.Update(ref state);
				EquipmentLateUpdateAspect_localTransformCAc.Update(ref state);
			}
		}

		public struct ResolvedChunk
		{
			public NativeArray<EquippedObjectCD> EquipmentLateUpdateAspect_equippedObjectCDNaC;

			public BufferAccessor<GhostEffectEventBuffer> EquipmentLateUpdateAspect_ghostEffectEventBufferBa;

			public NativeArray<GhostEffectEventBufferPointerCD> EquipmentLateUpdateAspect_ghostEffectEventBufferPointerCDNaC;

			public NativeArray<EquipmentSlotCD> EquipmentLateUpdateAspect_equipmentCDNaC;

			public NativeArray<LocalTransform> EquipmentLateUpdateAspect_localTransformNaC;

			public int Length;

			public EquipmentLateUpdateAspect this[int index] => new EquipmentLateUpdateAspect(new RefRO<EquippedObjectCD>(EquipmentLateUpdateAspect_equippedObjectCDNaC, index), EquipmentLateUpdateAspect_ghostEffectEventBufferBa[index], new RefRW<GhostEffectEventBufferPointerCD>(EquipmentLateUpdateAspect_ghostEffectEventBufferPointerCDNaC, index), new RefRW<EquipmentSlotCD>(EquipmentLateUpdateAspect_equipmentCDNaC, index), new RefRO<LocalTransform>(EquipmentLateUpdateAspect_localTransformNaC, index));
		}

		public struct TypeHandle
		{
			[ReadOnly]
			private ComponentTypeHandle<EquippedObjectCD> EquipmentLateUpdateAspect_equippedObjectCDCAc;

			private BufferTypeHandle<GhostEffectEventBuffer> EquipmentLateUpdateAspect_ghostEffectEventBufferBAc;

			private ComponentTypeHandle<GhostEffectEventBufferPointerCD> EquipmentLateUpdateAspect_ghostEffectEventBufferPointerCDCAc;

			private ComponentTypeHandle<EquipmentSlotCD> EquipmentLateUpdateAspect_equipmentCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<LocalTransform> EquipmentLateUpdateAspect_localTransformCAc;

			public TypeHandle(ref SystemState state)
			{
				EquipmentLateUpdateAspect_equippedObjectCDCAc = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
				EquipmentLateUpdateAspect_ghostEffectEventBufferBAc = state.GetBufferTypeHandle<GhostEffectEventBuffer>();
				EquipmentLateUpdateAspect_ghostEffectEventBufferPointerCDCAc = state.GetComponentTypeHandle<GhostEffectEventBufferPointerCD>();
				EquipmentLateUpdateAspect_equipmentCDCAc = state.GetComponentTypeHandle<EquipmentSlotCD>();
				EquipmentLateUpdateAspect_localTransformCAc = state.GetComponentTypeHandle<LocalTransform>(isReadOnly: true);
			}

			public void Update(ref SystemState state)
			{
				EquipmentLateUpdateAspect_equippedObjectCDCAc.Update(ref state);
				EquipmentLateUpdateAspect_ghostEffectEventBufferBAc.Update(ref state);
				EquipmentLateUpdateAspect_ghostEffectEventBufferPointerCDCAc.Update(ref state);
				EquipmentLateUpdateAspect_equipmentCDCAc.Update(ref state);
				EquipmentLateUpdateAspect_localTransformCAc.Update(ref state);
			}

			public ResolvedChunk Resolve(ArchetypeChunk chunk)
			{
				ResolvedChunk result = default(ResolvedChunk);
				result.EquipmentLateUpdateAspect_equippedObjectCDNaC = chunk.GetNativeArray(ref EquipmentLateUpdateAspect_equippedObjectCDCAc);
				result.EquipmentLateUpdateAspect_ghostEffectEventBufferBa = chunk.GetBufferAccessor(ref EquipmentLateUpdateAspect_ghostEffectEventBufferBAc);
				result.EquipmentLateUpdateAspect_ghostEffectEventBufferPointerCDNaC = chunk.GetNativeArray(ref EquipmentLateUpdateAspect_ghostEffectEventBufferPointerCDCAc);
				result.EquipmentLateUpdateAspect_equipmentCDNaC = chunk.GetNativeArray(ref EquipmentLateUpdateAspect_equipmentCDCAc);
				result.EquipmentLateUpdateAspect_localTransformNaC = chunk.GetNativeArray(ref EquipmentLateUpdateAspect_localTransformCAc);
				result.Length = chunk.Count;
				return result;
			}
		}

		public struct Enumerator : IEnumerator<EquipmentLateUpdateAspect>, IEnumerator, IDisposable, IEnumerable<EquipmentLateUpdateAspect>, IEnumerable
		{
			private ResolvedChunk _Resolved;

			private InternalEntityQueryEnumerator _QueryEnumerator;

			private TypeHandle _Handle;

			public EquipmentLateUpdateAspect Current => _Resolved[_QueryEnumerator.IndexInChunk];

			object IEnumerator.Current
			{
				get
				{
					throw new NotImplementedException();
				}
			}

			internal Enumerator(EntityQuery query, TypeHandle typeHandle)
			{
				_QueryEnumerator = new InternalEntityQueryEnumerator(query);
				_Handle = typeHandle;
				_Resolved = default(ResolvedChunk);
			}

			public void Dispose()
			{
				_QueryEnumerator.Dispose();
			}

			public bool MoveNext()
			{
				if (_QueryEnumerator.MoveNextHotLoop())
				{
					return true;
				}
				return MoveNextCold();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private bool MoveNextCold()
			{
				ArchetypeChunk chunk;
				bool num = _QueryEnumerator.MoveNextColdLoop(out chunk);
				if (num)
				{
					_Resolved = _Handle.Resolve(chunk);
				}
				return num;
			}

			public Enumerator GetEnumerator()
			{
				return this;
			}

			void IEnumerator.Reset()
			{
				throw new NotImplementedException();
			}

			IEnumerator<EquipmentLateUpdateAspect> IEnumerable<EquipmentLateUpdateAspect>.GetEnumerator()
			{
				throw new NotImplementedException();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				throw new NotImplementedException();
			}
		}

		public readonly RefRW<EquipmentSlotCD> equipmentCD;

		public readonly RefRO<EquippedObjectCD> equippedObjectCD;

		public readonly DynamicBuffer<GhostEffectEventBuffer> ghostEffectEventBuffer;

		public readonly RefRW<GhostEffectEventBufferPointerCD> ghostEffectEventBufferPointerCD;

		public readonly RefRO<LocalTransform> localTransform;

		public EquipmentLateUpdateAspect(RefRO<EquippedObjectCD> equipmentlateupdateaspect_equippedobjectcdRef, DynamicBuffer<GhostEffectEventBuffer> equipmentlateupdateaspect_ghosteffecteventbufferDb, RefRW<GhostEffectEventBufferPointerCD> equipmentlateupdateaspect_ghosteffecteventbufferpointercdRef, RefRW<EquipmentSlotCD> equipmentlateupdateaspect_equipmentcdRef, RefRO<LocalTransform> equipmentlateupdateaspect_localtransformRef)
		{
			equippedObjectCD = equipmentlateupdateaspect_equippedobjectcdRef;
			ghostEffectEventBuffer = equipmentlateupdateaspect_ghosteffecteventbufferDb;
			ghostEffectEventBufferPointerCD = equipmentlateupdateaspect_ghosteffecteventbufferpointercdRef;
			equipmentCD = equipmentlateupdateaspect_equipmentcdRef;
			localTransform = equipmentlateupdateaspect_localtransformRef;
		}

		public EquipmentLateUpdateAspect CreateAspect(Entity entity, ref SystemState systemState)
		{
			return new Lookup(ref systemState)[entity];
		}

		public void AddComponentRequirementsTo(ref UnsafeList<ComponentType> all)
		{
			UnsafeList<ComponentType> unsafeList = new UnsafeList<ComponentType>(8, Allocator.Temp, NativeArrayOptions.ClearMemory);
			unsafeList.Add(ComponentType.ReadOnly<EquippedObjectCD>());
			unsafeList.Add(ComponentType.ReadWrite<GhostEffectEventBuffer>());
			unsafeList.Add(ComponentType.ReadWrite<GhostEffectEventBufferPointerCD>());
			unsafeList.Add(ComponentType.ReadWrite<EquipmentSlotCD>());
			unsafeList.Add(ComponentType.ReadOnly<LocalTransform>());
			UnsafeList<ComponentType> withThese = unsafeList;
			InternalCompilerInterface.MergeWith(ref all, ref withThese);
			withThese.Dispose();
		}

		public static int GetRequiredComponentTypeCount()
		{
			return 5;
		}

		public static void AddRequiredComponentTypes(ref Span<ComponentType> componentTypes)
		{
			componentTypes[0] = ComponentType.ReadOnly<EquippedObjectCD>();
			componentTypes[1] = ComponentType.ReadWrite<GhostEffectEventBuffer>();
			componentTypes[2] = ComponentType.ReadWrite<GhostEffectEventBufferPointerCD>();
			componentTypes[3] = ComponentType.ReadWrite<EquipmentSlotCD>();
			componentTypes[4] = ComponentType.ReadOnly<LocalTransform>();
		}

		public static Enumerator Query(EntityQuery query, TypeHandle typeHandle)
		{
			return new Enumerator(query, typeHandle);
		}

		public void CompleteDependencyBeforeRO(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRO<GhostEffectEventBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<GhostEffectEventBufferPointerCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRO<LocalTransform>();
		}

		public void CompleteDependencyBeforeRW(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRW<GhostEffectEventBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<GhostEffectEventBufferPointerCD>();
			state.EntityManager.CompleteDependencyBeforeRW<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRO<LocalTransform>();
		}
	}
}
