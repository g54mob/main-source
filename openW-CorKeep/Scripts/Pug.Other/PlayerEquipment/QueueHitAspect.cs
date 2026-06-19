using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using PlayerState;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Internal;

namespace PlayerEquipment
{
	public readonly struct QueueHitAspect : IAspect, IQueryTypeParameter, IAspectCreate<QueueHitAspect>
	{
		public struct Lookup : InternalCompilerInterface.IAspectLookup<QueueHitAspect>
		{
			private BufferLookup<AnimationBuffer> QueueHitAspect_animationBufferBAc;

			private ComponentLookup<AnimationBufferPointer> QueueHitAspect_animationBufferPointerCAc;

			[ReadOnly]
			private ComponentLookup<EquippedObjectCD> QueueHitAspect_equippedObjectCDCAc;

			private ComponentLookup<PlayerAttackCooldownCD> QueueHitAspect_playerAttackCooldownCDCAc;

			[ReadOnly]
			private ComponentLookup<EquipmentSlotCD> QueueHitAspect_equipmentSlotCDCAc;

			private ComponentLookup<PlayerAttackCD> QueueHitAspect_playerAttackCDCAc;

			private ComponentLookup<PlayerOrientationCD> QueueHitAspect_playerOrientationCDCAc;

			private ComponentLookup<PlayerRoutineCD> QueueHitAspect_playerRoutineCDCAc;

			private ComponentLookup<PlayerStateCD> QueueHitAspect_playerStateCDCAc;

			public QueueHitAspect this[Entity entity] => new QueueHitAspect(QueueHitAspect_animationBufferBAc[entity], QueueHitAspect_animationBufferPointerCAc.GetRefRW(entity), QueueHitAspect_equippedObjectCDCAc.GetRefRO(entity), QueueHitAspect_playerAttackCooldownCDCAc.GetRefRW(entity), QueueHitAspect_equipmentSlotCDCAc.GetRefRO(entity), QueueHitAspect_playerAttackCDCAc.GetRefRW(entity), QueueHitAspect_playerOrientationCDCAc.GetRefRW(entity), QueueHitAspect_playerRoutineCDCAc.GetRefRW(entity), QueueHitAspect_playerStateCDCAc.GetRefRW(entity));

			public Lookup(ref SystemState state)
			{
				QueueHitAspect_animationBufferBAc = state.GetBufferLookup<AnimationBuffer>();
				QueueHitAspect_animationBufferPointerCAc = state.GetComponentLookup<AnimationBufferPointer>();
				QueueHitAspect_equippedObjectCDCAc = state.GetComponentLookup<EquippedObjectCD>(isReadOnly: true);
				QueueHitAspect_playerAttackCooldownCDCAc = state.GetComponentLookup<PlayerAttackCooldownCD>();
				QueueHitAspect_equipmentSlotCDCAc = state.GetComponentLookup<EquipmentSlotCD>(isReadOnly: true);
				QueueHitAspect_playerAttackCDCAc = state.GetComponentLookup<PlayerAttackCD>();
				QueueHitAspect_playerOrientationCDCAc = state.GetComponentLookup<PlayerOrientationCD>();
				QueueHitAspect_playerRoutineCDCAc = state.GetComponentLookup<PlayerRoutineCD>();
				QueueHitAspect_playerStateCDCAc = state.GetComponentLookup<PlayerStateCD>();
			}

			public void Update(ref SystemState state)
			{
				QueueHitAspect_animationBufferBAc.Update(ref state);
				QueueHitAspect_animationBufferPointerCAc.Update(ref state);
				QueueHitAspect_equippedObjectCDCAc.Update(ref state);
				QueueHitAspect_playerAttackCooldownCDCAc.Update(ref state);
				QueueHitAspect_equipmentSlotCDCAc.Update(ref state);
				QueueHitAspect_playerAttackCDCAc.Update(ref state);
				QueueHitAspect_playerOrientationCDCAc.Update(ref state);
				QueueHitAspect_playerRoutineCDCAc.Update(ref state);
				QueueHitAspect_playerStateCDCAc.Update(ref state);
			}
		}

		public struct ResolvedChunk
		{
			public BufferAccessor<AnimationBuffer> QueueHitAspect_animationBufferBa;

			public NativeArray<AnimationBufferPointer> QueueHitAspect_animationBufferPointerNaC;

			public NativeArray<EquippedObjectCD> QueueHitAspect_equippedObjectCDNaC;

			public NativeArray<PlayerAttackCooldownCD> QueueHitAspect_playerAttackCooldownCDNaC;

			public NativeArray<EquipmentSlotCD> QueueHitAspect_equipmentSlotCDNaC;

			public NativeArray<PlayerAttackCD> QueueHitAspect_playerAttackCDNaC;

			public NativeArray<PlayerOrientationCD> QueueHitAspect_playerOrientationCDNaC;

			public NativeArray<PlayerRoutineCD> QueueHitAspect_playerRoutineCDNaC;

			public NativeArray<PlayerStateCD> QueueHitAspect_playerStateCDNaC;

			public int Length;

			public QueueHitAspect this[int index] => new QueueHitAspect(QueueHitAspect_animationBufferBa[index], new RefRW<AnimationBufferPointer>(QueueHitAspect_animationBufferPointerNaC, index), new RefRO<EquippedObjectCD>(QueueHitAspect_equippedObjectCDNaC, index), new RefRW<PlayerAttackCooldownCD>(QueueHitAspect_playerAttackCooldownCDNaC, index), new RefRO<EquipmentSlotCD>(QueueHitAspect_equipmentSlotCDNaC, index), new RefRW<PlayerAttackCD>(QueueHitAspect_playerAttackCDNaC, index), new RefRW<PlayerOrientationCD>(QueueHitAspect_playerOrientationCDNaC, index), new RefRW<PlayerRoutineCD>(QueueHitAspect_playerRoutineCDNaC, index), new RefRW<PlayerStateCD>(QueueHitAspect_playerStateCDNaC, index));
		}

		public struct TypeHandle
		{
			private BufferTypeHandle<AnimationBuffer> QueueHitAspect_animationBufferBAc;

			private ComponentTypeHandle<AnimationBufferPointer> QueueHitAspect_animationBufferPointerCAc;

			[ReadOnly]
			private ComponentTypeHandle<EquippedObjectCD> QueueHitAspect_equippedObjectCDCAc;

			private ComponentTypeHandle<PlayerAttackCooldownCD> QueueHitAspect_playerAttackCooldownCDCAc;

			[ReadOnly]
			private ComponentTypeHandle<EquipmentSlotCD> QueueHitAspect_equipmentSlotCDCAc;

			private ComponentTypeHandle<PlayerAttackCD> QueueHitAspect_playerAttackCDCAc;

			private ComponentTypeHandle<PlayerOrientationCD> QueueHitAspect_playerOrientationCDCAc;

			private ComponentTypeHandle<PlayerRoutineCD> QueueHitAspect_playerRoutineCDCAc;

			private ComponentTypeHandle<PlayerStateCD> QueueHitAspect_playerStateCDCAc;

			public TypeHandle(ref SystemState state)
			{
				QueueHitAspect_animationBufferBAc = state.GetBufferTypeHandle<AnimationBuffer>();
				QueueHitAspect_animationBufferPointerCAc = state.GetComponentTypeHandle<AnimationBufferPointer>();
				QueueHitAspect_equippedObjectCDCAc = state.GetComponentTypeHandle<EquippedObjectCD>(isReadOnly: true);
				QueueHitAspect_playerAttackCooldownCDCAc = state.GetComponentTypeHandle<PlayerAttackCooldownCD>();
				QueueHitAspect_equipmentSlotCDCAc = state.GetComponentTypeHandle<EquipmentSlotCD>(isReadOnly: true);
				QueueHitAspect_playerAttackCDCAc = state.GetComponentTypeHandle<PlayerAttackCD>();
				QueueHitAspect_playerOrientationCDCAc = state.GetComponentTypeHandle<PlayerOrientationCD>();
				QueueHitAspect_playerRoutineCDCAc = state.GetComponentTypeHandle<PlayerRoutineCD>();
				QueueHitAspect_playerStateCDCAc = state.GetComponentTypeHandle<PlayerStateCD>();
			}

			public void Update(ref SystemState state)
			{
				QueueHitAspect_animationBufferBAc.Update(ref state);
				QueueHitAspect_animationBufferPointerCAc.Update(ref state);
				QueueHitAspect_equippedObjectCDCAc.Update(ref state);
				QueueHitAspect_playerAttackCooldownCDCAc.Update(ref state);
				QueueHitAspect_equipmentSlotCDCAc.Update(ref state);
				QueueHitAspect_playerAttackCDCAc.Update(ref state);
				QueueHitAspect_playerOrientationCDCAc.Update(ref state);
				QueueHitAspect_playerRoutineCDCAc.Update(ref state);
				QueueHitAspect_playerStateCDCAc.Update(ref state);
			}

			public ResolvedChunk Resolve(ArchetypeChunk chunk)
			{
				ResolvedChunk result = default(ResolvedChunk);
				result.QueueHitAspect_animationBufferBa = chunk.GetBufferAccessor(ref QueueHitAspect_animationBufferBAc);
				result.QueueHitAspect_animationBufferPointerNaC = chunk.GetNativeArray(ref QueueHitAspect_animationBufferPointerCAc);
				result.QueueHitAspect_equippedObjectCDNaC = chunk.GetNativeArray(ref QueueHitAspect_equippedObjectCDCAc);
				result.QueueHitAspect_playerAttackCooldownCDNaC = chunk.GetNativeArray(ref QueueHitAspect_playerAttackCooldownCDCAc);
				result.QueueHitAspect_equipmentSlotCDNaC = chunk.GetNativeArray(ref QueueHitAspect_equipmentSlotCDCAc);
				result.QueueHitAspect_playerAttackCDNaC = chunk.GetNativeArray(ref QueueHitAspect_playerAttackCDCAc);
				result.QueueHitAspect_playerOrientationCDNaC = chunk.GetNativeArray(ref QueueHitAspect_playerOrientationCDCAc);
				result.QueueHitAspect_playerRoutineCDNaC = chunk.GetNativeArray(ref QueueHitAspect_playerRoutineCDCAc);
				result.QueueHitAspect_playerStateCDNaC = chunk.GetNativeArray(ref QueueHitAspect_playerStateCDCAc);
				result.Length = chunk.Count;
				return result;
			}
		}

		public struct Enumerator : IEnumerator<QueueHitAspect>, IEnumerator, IDisposable, IEnumerable<QueueHitAspect>, IEnumerable
		{
			private ResolvedChunk _Resolved;

			private InternalEntityQueryEnumerator _QueryEnumerator;

			private TypeHandle _Handle;

			public QueueHitAspect Current => _Resolved[_QueryEnumerator.IndexInChunk];

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

			IEnumerator<QueueHitAspect> IEnumerable<QueueHitAspect>.GetEnumerator()
			{
				throw new NotImplementedException();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				throw new NotImplementedException();
			}
		}

		public readonly RefRW<PlayerStateCD> playerStateCD;

		public readonly RefRW<PlayerAttackCD> playerAttackCD;

		public readonly RefRW<PlayerRoutineCD> playerRoutineCD;

		public readonly RefRO<EquipmentSlotCD> equipmentSlotCD;

		public readonly RefRO<EquippedObjectCD> equippedObjectCD;

		public readonly RefRW<PlayerAttackCooldownCD> playerAttackCooldownCD;

		public readonly DynamicBuffer<AnimationBuffer> animationBuffer;

		public readonly RefRW<AnimationBufferPointer> animationBufferPointer;

		public readonly RefRW<PlayerOrientationCD> playerOrientationCD;

		public QueueHitAspect(DynamicBuffer<AnimationBuffer> queuehitaspect_animationbufferDb, RefRW<AnimationBufferPointer> queuehitaspect_animationbufferpointerRef, RefRO<EquippedObjectCD> queuehitaspect_equippedobjectcdRef, RefRW<PlayerAttackCooldownCD> queuehitaspect_playerattackcooldowncdRef, RefRO<EquipmentSlotCD> queuehitaspect_equipmentslotcdRef, RefRW<PlayerAttackCD> queuehitaspect_playerattackcdRef, RefRW<PlayerOrientationCD> queuehitaspect_playerorientationcdRef, RefRW<PlayerRoutineCD> queuehitaspect_playerroutinecdRef, RefRW<PlayerStateCD> queuehitaspect_playerstatecdRef)
		{
			animationBuffer = queuehitaspect_animationbufferDb;
			animationBufferPointer = queuehitaspect_animationbufferpointerRef;
			equippedObjectCD = queuehitaspect_equippedobjectcdRef;
			playerAttackCooldownCD = queuehitaspect_playerattackcooldowncdRef;
			equipmentSlotCD = queuehitaspect_equipmentslotcdRef;
			playerAttackCD = queuehitaspect_playerattackcdRef;
			playerOrientationCD = queuehitaspect_playerorientationcdRef;
			playerRoutineCD = queuehitaspect_playerroutinecdRef;
			playerStateCD = queuehitaspect_playerstatecdRef;
		}

		public QueueHitAspect CreateAspect(Entity entity, ref SystemState systemState)
		{
			return new Lookup(ref systemState)[entity];
		}

		public void AddComponentRequirementsTo(ref UnsafeList<ComponentType> all)
		{
			UnsafeList<ComponentType> unsafeList = new UnsafeList<ComponentType>(8, Allocator.Temp, NativeArrayOptions.ClearMemory);
			unsafeList.Add(ComponentType.ReadWrite<AnimationBuffer>());
			unsafeList.Add(ComponentType.ReadWrite<AnimationBufferPointer>());
			unsafeList.Add(ComponentType.ReadOnly<EquippedObjectCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerAttackCooldownCD>());
			unsafeList.Add(ComponentType.ReadOnly<EquipmentSlotCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerAttackCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerOrientationCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerRoutineCD>());
			unsafeList.Add(ComponentType.ReadWrite<PlayerStateCD>());
			UnsafeList<ComponentType> withThese = unsafeList;
			InternalCompilerInterface.MergeWith(ref all, ref withThese);
			withThese.Dispose();
		}

		public static int GetRequiredComponentTypeCount()
		{
			return 9;
		}

		public static void AddRequiredComponentTypes(ref Span<ComponentType> componentTypes)
		{
			componentTypes[0] = ComponentType.ReadWrite<AnimationBuffer>();
			componentTypes[1] = ComponentType.ReadWrite<AnimationBufferPointer>();
			componentTypes[2] = ComponentType.ReadOnly<EquippedObjectCD>();
			componentTypes[3] = ComponentType.ReadWrite<PlayerAttackCooldownCD>();
			componentTypes[4] = ComponentType.ReadOnly<EquipmentSlotCD>();
			componentTypes[5] = ComponentType.ReadWrite<PlayerAttackCD>();
			componentTypes[6] = ComponentType.ReadWrite<PlayerOrientationCD>();
			componentTypes[7] = ComponentType.ReadWrite<PlayerRoutineCD>();
			componentTypes[8] = ComponentType.ReadWrite<PlayerStateCD>();
		}

		public static Enumerator Query(EntityQuery query, TypeHandle typeHandle)
		{
			return new Enumerator(query, typeHandle);
		}

		public void CompleteDependencyBeforeRO(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRO<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRO<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerAttackCooldownCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerAttackCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerOrientationCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerRoutineCD>();
			state.EntityManager.CompleteDependencyBeforeRO<PlayerStateCD>();
		}

		public void CompleteDependencyBeforeRW(ref SystemState state)
		{
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBuffer>();
			state.EntityManager.CompleteDependencyBeforeRW<AnimationBufferPointer>();
			state.EntityManager.CompleteDependencyBeforeRO<EquippedObjectCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerAttackCooldownCD>();
			state.EntityManager.CompleteDependencyBeforeRO<EquipmentSlotCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerAttackCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerOrientationCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerRoutineCD>();
			state.EntityManager.CompleteDependencyBeforeRW<PlayerStateCD>();
		}
	}
}
