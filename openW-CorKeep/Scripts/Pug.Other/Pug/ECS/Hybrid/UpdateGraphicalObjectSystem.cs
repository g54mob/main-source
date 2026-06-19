using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interaction;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Core;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Profiling;
using Unity.Transforms;
using UnityEngine.Scripting;

namespace Pug.ECS.Hybrid
{
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[UpdateInGroup(typeof(PresentationSystemGroup), OrderLast = true)]
	public class UpdateGraphicalObjectSystem : SystemBase
	{
		private struct UpdateManagedMethodsJob : IJobChunk
		{
			public EntityTypeHandle EntityTypeHandle;

			public ComponentTypeHandle<LocalToWorld> localToWorldHandle;

			public ComponentTypeHandle<DamageEffectCD> damageEffectHandle;

			public ComponentTypeHandle<HealthCD> healthHandle;

			public ComponentTypeHandle<DirectionCD> directionHandle;

			public ComponentTypeHandle<EntityPartCD> entityPartHandle;

			public ComponentTypeHandle<PaintableObjectCD> paintableObjectType;

			public ComponentTypeHandle<EntityDestroyedCD> entityDestroyedType;

			[ReadOnly]
			public ComponentLookup<InteractorCD> interactorLookup;

			[ReadOnly]
			public BufferTypeHandle<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

			[ReadOnly]
			public BufferTypeHandle<SummarizedConditionEffectsBuffer> summarizedConditionsEffectsBufferLookup;

			[ReadOnly]
			public BufferTypeHandle<ActiveAffixConditionsBuffer> affixBufferLookup;

			public Dictionary<Entity, EntityMonoBehaviour> entityMonoBehaviourLookup;

			public bool particleQualityChanged;

			public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				NativeArray<Entity> nativeArray = chunk.GetNativeArray(EntityTypeHandle);
				NativeArray<LocalToWorld> nativeArray2 = chunk.GetNativeArray(localToWorldHandle);
				NativeArray<DamageEffectCD> nativeArray3 = chunk.GetNativeArray(damageEffectHandle);
				NativeArray<HealthCD> nativeArray4 = chunk.GetNativeArray(healthHandle);
				NativeArray<DirectionCD> nativeArray5 = chunk.GetNativeArray(directionHandle);
				NativeArray<EntityPartCD> nativeArray6 = chunk.GetNativeArray(entityPartHandle);
				NativeArray<PaintableObjectCD> nativeArray7 = chunk.GetNativeArray(paintableObjectType);
				BufferAccessor<ActiveAffixConditionsBuffer> bufferAccessor = chunk.GetBufferAccessor(affixBufferLookup);
				BufferAccessor<SummarizedConditionsBuffer> bufferAccessor2 = chunk.GetBufferAccessor(summarizedConditionsBufferLookup);
				BufferAccessor<SummarizedConditionEffectsBuffer> bufferAccessor3 = chunk.GetBufferAccessor(summarizedConditionsEffectsBufferLookup);
				bool flag = chunk.Has<ActiveAffixConditionsBuffer>();
				bool isCreated = nativeArray2.IsCreated;
				bool isCreated2 = nativeArray3.IsCreated;
				bool isCreated3 = nativeArray4.IsCreated;
				bool isCreated4 = nativeArray5.IsCreated;
				bool isCreated5 = nativeArray6.IsCreated;
				bool isCreated6 = nativeArray7.IsCreated;
				bool flag2 = chunk.Has<EntityDestroyedCD>();
				PlayerController player = Manager.main.player;
				Entity entity = ((player != null) ? player.entity : Entity.Null);
				interactorLookup.TryGetComponent(entity, out var _);
				for (int i = 0; i < chunk.Count; i++)
				{
					Entity key = nativeArray[i];
					if (entityMonoBehaviourLookup.TryGetValue(key, out var value))
					{
						LocalToWorld localToWorld = (isCreated ? nativeArray2[i] : default(LocalToWorld));
						if (particleQualityChanged)
						{
							value.UpdateParticlesEnabled();
						}
						value.UpdatePosition(isCreated, in localToWorld);
						value.UpdateDisableAnimator();
						value.UpdateDestroyedState(flag2 && chunk.IsComponentEnabled(ref entityDestroyedType, i));
						value.UpdateAnimatorSpeedAndOrientation();
						if (isCreated3)
						{
							HealthCD healthCD = nativeArray4[i];
							value.UpdateHealthChangeAnimations(in healthCD);
						}
						if (isCreated2)
						{
							DamageEffectCD damageEffectCD = nativeArray3[i];
							value.UpdateDamageTakenEffect(in damageEffectCD);
						}
						DirectionCD directionCD = (isCreated4 ? nativeArray5[i] : default(DirectionCD));
						value.UpdateAppearanceInMapUI(isCreated4, in directionCD);
						if (isCreated6)
						{
							PaintableObjectCD paintableObjectCD = nativeArray7[i];
							value.UpdatePaintedColor(in paintableObjectCD);
						}
						if (value.HasConditions() && value.conditionEffectsHandler != null)
						{
							EntityPartCD entityPartCD = (isCreated5 ? nativeArray6[i] : default(EntityPartCD));
							DynamicBuffer<ActiveAffixConditionsBuffer> activeAffixesBuffer = (flag ? bufferAccessor[i] : default(DynamicBuffer<ActiveAffixConditionsBuffer>));
							value.conditionEffectsHandler.UpdateConditionsVisuals(value, isCreated5, in entityPartCD, bufferAccessor2[i], bufferAccessor3[i], activeAffixesBuffer);
						}
					}
				}
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
			public ComponentTypeHandle<LocalToWorld> __Unity_Transforms_LocalToWorld_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DamageEffectCD> __DamageEffectCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<HealthCD> __HealthCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<DirectionCD> __DirectionCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<EntityPartCD> __EntityPartCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<PaintableObjectCD> __PaintableObjectCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentTypeHandle<EntityDestroyedCD> __EntityDestroyedCD_RO_ComponentTypeHandle;

			[ReadOnly]
			public ComponentLookup<InteractorCD> __Interaction_InteractorCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferTypeHandle<ActiveAffixConditionsBuffer> __ActiveAffixConditionsBuffer_RO_BufferTypeHandle;

			[ReadOnly]
			public BufferTypeHandle<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferTypeHandle;

			[ReadOnly]
			public BufferTypeHandle<SummarizedConditionEffectsBuffer> __SummarizedConditionEffectsBuffer_RO_BufferTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
				__Unity_Transforms_LocalToWorld_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LocalToWorld>(isReadOnly: true);
				__DamageEffectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DamageEffectCD>(isReadOnly: true);
				__HealthCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HealthCD>(isReadOnly: true);
				__DirectionCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DirectionCD>(isReadOnly: true);
				__EntityPartCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EntityPartCD>(isReadOnly: true);
				__PaintableObjectCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PaintableObjectCD>(isReadOnly: true);
				__EntityDestroyedCD_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EntityDestroyedCD>(isReadOnly: true);
				__Interaction_InteractorCD_RO_ComponentLookup = state.GetComponentLookup<InteractorCD>(isReadOnly: true);
				__ActiveAffixConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<ActiveAffixConditionsBuffer>(isReadOnly: true);
				__SummarizedConditionsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionsBuffer>(isReadOnly: true);
				__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle = state.GetBufferTypeHandle<SummarizedConditionEffectsBuffer>(isReadOnly: true);
			}
		}

		private static readonly ProfilerMarker EMBUpdateMarker = new ProfilerMarker("EMB updates");

		private static readonly ProfilerMarker NonEMBUpdateMarker = new ProfilerMarker("Non-EMB updates");

		private CreateGraphicalObjectSystem _createGraphicalObjectSystem;

		private Dictionary<Entity, EntityMonoBehaviour> _entityMonoBehaviourLookup;

		private EntityQuery _spawnedQuery;

		private EntityQuery _updateManagedMethodsQuery;

		private PugParticleQuality _lastParticleQuality = PugParticleQuality.Undefined;

		private TypeHandle __TypeHandle;

		[Preserve]
		protected override void OnCreate()
		{
			_createGraphicalObjectSystem = base.World.GetExistingSystemManaged<CreateGraphicalObjectSystem>();
			_entityMonoBehaviourLookup = _createGraphicalObjectSystem.entityMonoBehaviourLookup;
			_updateManagedMethodsQuery = new EntityQueryBuilder(Allocator.Temp).WithAll<EntityMonoBehaviourCD>().Build(ref base.CheckedStateRef);
			base.OnCreate();
		}

		[Preserve]
		protected override void OnUpdate()
		{
			bool particleQualityChanged = _lastParticleQuality != (PugParticleQuality)Manager.prefs.particleQuality;
			_lastParticleQuality = (PugParticleQuality)Manager.prefs.particleQuality;
			UpdateManagedMethodsJob jobData = new UpdateManagedMethodsJob
			{
				EntityTypeHandle = InternalCompilerInterface.GetEntityTypeHandle(ref __TypeHandle.__Unity_Entities_Entity_TypeHandle, ref base.CheckedStateRef),
				entityMonoBehaviourLookup = _entityMonoBehaviourLookup,
				localToWorldHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__Unity_Transforms_LocalToWorld_RO_ComponentTypeHandle, ref base.CheckedStateRef),
				damageEffectHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__DamageEffectCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
				healthHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__HealthCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
				directionHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__DirectionCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
				entityPartHandle = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__EntityPartCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
				paintableObjectType = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__PaintableObjectCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
				entityDestroyedType = InternalCompilerInterface.GetComponentTypeHandle(ref __TypeHandle.__EntityDestroyedCD_RO_ComponentTypeHandle, ref base.CheckedStateRef),
				interactorLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Interaction_InteractorCD_RO_ComponentLookup, ref base.CheckedStateRef),
				affixBufferLookup = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__ActiveAffixConditionsBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
				summarizedConditionsBufferLookup = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
				summarizedConditionsEffectsBufferLookup = InternalCompilerInterface.GetBufferTypeHandle(ref __TypeHandle.__SummarizedConditionEffectsBuffer_RO_BufferTypeHandle, ref base.CheckedStateRef),
				particleQualityChanged = particleQualityChanged
			};
			InternalCompilerInterface.JobChunkInterface.RunWithoutJobs(ref jobData, _updateManagedMethodsQuery);
			TimeData time = base.CheckedStateRef.WorldUnmanaged.Time;
			List<IGraphicalObject[]> graphicalObjects = _createGraphicalObjectSystem.m_GraphicalObjects;
			NativeList<Entity> graphicalEntities = _createGraphicalObjectSystem.m_GraphicalEntities;
			for (int i = 0; i < graphicalObjects.Count; i++)
			{
				if (graphicalObjects[i] != null)
				{
					IGraphicalObject[] array = graphicalObjects[i];
					for (int j = 0; j < array.Length; j++)
					{
						array[j].GraphicalUpdate(graphicalEntities[i], base.EntityManager, time);
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			new EntityQueryBuilder(Allocator.Temp).Dispose();
		}

		protected override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			__AssignQueries(ref base.CheckedStateRef);
			__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
		}

		[Preserve]
		public UpdateGraphicalObjectSystem()
		{
		}
	}
}
