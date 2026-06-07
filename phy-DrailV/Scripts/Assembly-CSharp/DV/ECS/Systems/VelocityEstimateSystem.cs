using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DV.ECS.Components;
using DV.Utils;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace DV.ECS.Systems
{
	[UpdateInGroup(typeof(PresentationSystemGroup))]
	public class VelocityEstimateSystem : SystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass4_0
		{
			public EntityCommandBuffer.Concurrent beginSimulationEcbConcurrent;

			public ComponentDataFromEntity<VelocityEstimate> velocities;

			public ComponentDataFromEntity<LocalToWorld> localToWorlds;

			public float delta;

			public ComponentDataFromEntity<PreviousFrameLocalToWorld> prevLocalToWorlds;

			internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, in SkipOneVelocityEstimateFrame skipTarget)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003COnUpdate_003Eb__1(ref PreviousFrameLocalToWorld prevPos, ref VelocityEstimate velocityEstimate, in LocalToWorld ltw)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003COnUpdate_003Eb__2(ref VelocityParent parent, in LocalToWorld ltw, in VelocityEstimate velocityEstimate)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[NoAlias]
		[BurstCompile]
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_CalculateSkipVelocity : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

					[NoAlias]
					public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<SkipOneVelocityEstimateFrame>.Runtime runtime_skipTarget;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<SkipOneVelocityEstimateFrame> forParameter_skipTarget;

				public void ScheduleTimeInitialize(VelocityEstimateSystem componentSystem)
				{
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_skipTarget.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
						runtime_skipTarget = forParameter_skipTarget.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public EntityCommandBuffer.Concurrent beginSimulationEcbConcurrent;

			[ReadOnly]
			public ComponentDataFromEntity<VelocityEstimate> velocities;

			[ReadOnly]
			public ComponentDataFromEntity<LocalToWorld> localToWorlds;

			public float delta;

			[NativeDisableParallelForRestriction]
			public ComponentDataFromEntity<PreviousFrameLocalToWorld> prevLocalToWorlds;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in SkipOneVelocityEstimateFrame skipTarget)
			{
				beginSimulationEcbConcurrent.DestroyEntity(entityInQueryIndex, entity);
				if (velocities.Exists(skipTarget.target))
				{
					VelocityEstimate velocityEstimate = velocities[skipTarget.target];
					LocalToWorld localToWorld = localToWorlds[skipTarget.target];
					float3 translation = localToWorld.Position - velocityEstimate.globalVelocity * delta;
					quaternion rotation = math.mul(math.inverse(quaternion.Euler(velocityEstimate.globalAngularVelocity * delta)), localToWorld.Rotation);
					prevLocalToWorlds[skipTarget.target] = new PreviousFrameLocalToWorld
					{
						value = float4x4.TRS(translation, rotation, new float3(1f, 1f, 1f))
					};
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				beginSimulationEcbConcurrent = displayClass.beginSimulationEcbConcurrent;
				velocities = displayClass.velocities;
				localToWorlds = displayClass.localToWorlds;
				delta = displayClass.delta;
				prevLocalToWorlds = displayClass.prevLocalToWorlds;
			}

			public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
				_runtimes = &runtimes;
				IterateEntities(ref chunk, ref *_runtimes);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_skipTarget.For(i));
				}
			}

			public void ScheduleTimeInitialize(VelocityEstimateSystem componentSystem, ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}
		}

		[BurstCompile]
		[NoAlias]
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_EstimateGlobalVelocity : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<PreviousFrameLocalToWorld>.Runtime runtime_prevPos;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<VelocityEstimate>.Runtime runtime_velocityEstimate;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<LocalToWorld>.Runtime runtime_ltw;
				}

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<PreviousFrameLocalToWorld> forParameter_prevPos;

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<VelocityEstimate> forParameter_velocityEstimate;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<LocalToWorld> forParameter_ltw;

				public void ScheduleTimeInitialize(VelocityEstimateSystem componentSystem)
				{
					forParameter_prevPos.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_velocityEstimate.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_ltw.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_prevPos = forParameter_prevPos.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_velocityEstimate = forParameter_velocityEstimate.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_ltw = forParameter_ltw.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public float delta;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			internal void OriginalLambdaBody(ref PreviousFrameLocalToWorld prevPos, ref VelocityEstimate velocityEstimate, in LocalToWorld ltw)
			{
				float3 position = ltw.Position;
				LocalToWorld localToWorld = new LocalToWorld
				{
					Value = prevPos.value
				};
				float3 position2 = localToWorld.Position;
				quaternion rotation = ltw.Rotation;
				quaternion rotation2 = localToWorld.Rotation;
				quaternion q = math.mul(rotation, math.inverse(rotation2));
				velocityEstimate.globalAngularVelocity = math.Euler(q) / delta;
				velocityEstimate.globalVelocity = (position - position2) / delta;
				prevPos.value = ltw.Value;
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				delta = displayClass.delta;
			}

			public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
				_runtimes = &runtimes;
				IterateEntities(ref chunk, ref *_runtimes);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(ref runtimes.runtime_prevPos.For(i), ref runtimes.runtime_velocityEstimate.For(i), in runtimes.runtime_ltw.For(i));
				}
			}

			public void ScheduleTimeInitialize(VelocityEstimateSystem componentSystem, ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		[NoAlias]
		private struct _003C_003Ec__DisplayClass_EstimateRelativeParentGlobalVelocity : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<VelocityParent>.Runtime runtime_parent;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<LocalToWorld>.Runtime runtime_ltw;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<VelocityEstimate>.Runtime runtime_velocityEstimate;
				}

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<VelocityParent> forParameter_parent;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<LocalToWorld> forParameter_ltw;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<VelocityEstimate> forParameter_velocityEstimate;

				public void ScheduleTimeInitialize(VelocityEstimateSystem componentSystem)
				{
					forParameter_parent.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_ltw.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_velocityEstimate.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_parent = forParameter_parent.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_ltw = forParameter_ltw.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_velocityEstimate = forParameter_velocityEstimate.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			[ReadOnly]
			public ComponentDataFromEntity<VelocityEstimate> velocities;

			[ReadOnly]
			public ComponentDataFromEntity<LocalToWorld> localToWorlds;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			internal void OriginalLambdaBody(ref VelocityParent parent, in LocalToWorld ltw, in VelocityEstimate velocityEstimate)
			{
				VelocityEstimate velocityEstimate2 = velocities[parent.parent];
				LocalToWorld localToWorld = localToWorlds[parent.parent];
				float3 velocityAtRelativePoint = GetVelocityAtRelativePoint(velocityEstimate2.globalVelocity, velocityEstimate2.globalAngularVelocity, ltw.Position - localToWorld.Position);
				parent.relativeToParentVelocity.globalVelocity = velocityEstimate.globalVelocity - velocityAtRelativePoint;
				parent.relativeToParentVelocity.globalAngularVelocity = velocityEstimate.globalAngularVelocity - velocityEstimate2.globalAngularVelocity;
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				velocities = displayClass.velocities;
				localToWorlds = displayClass.localToWorlds;
			}

			public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
				_runtimes = &runtimes;
				IterateEntities(ref chunk, ref *_runtimes);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(ref runtimes.runtime_parent.For(i), in runtimes.runtime_ltw.For(i), in runtimes.runtime_velocityEstimate.For(i));
				}
			}

			public void ScheduleTimeInitialize(VelocityEstimateSystem componentSystem, ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}
		}

		[NoAlias]
		[BurstCompile]
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_CalculateLocalVelocity : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<VelocityEstimate>.Runtime runtime_velocityEstimate;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<LocalToWorld>.Runtime runtime_ltw;
				}

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<VelocityEstimate> forParameter_velocityEstimate;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<LocalToWorld> forParameter_ltw;

				public void ScheduleTimeInitialize(VelocityEstimateSystem componentSystem)
				{
					forParameter_velocityEstimate.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_ltw.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_velocityEstimate = forParameter_velocityEstimate.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_ltw = forParameter_ltw.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			internal void OriginalLambdaBody(ref VelocityEstimate velocityEstimate, in LocalToWorld ltw)
			{
				velocityEstimate.localVelocity = math.mul(math.inverse(ltw.Rotation), velocityEstimate.globalVelocity);
				velocityEstimate.localAngularVelocity = math.mul(math.inverse(ltw.Rotation), velocityEstimate.globalAngularVelocity);
			}

			public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
				_runtimes = &runtimes;
				IterateEntities(ref chunk, ref *_runtimes);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(ref runtimes.runtime_velocityEstimate.For(i), in runtimes.runtime_ltw.For(i));
				}
			}

			public void ScheduleTimeInitialize(VelocityEstimateSystem componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		[NoAlias]
		private struct _003C_003Ec__DisplayClass_CalculateRelativeParentLocalVelocity : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<VelocityParent>.Runtime runtime_parent;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<LocalToWorld>.Runtime runtime_ltw;
				}

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<VelocityParent> forParameter_parent;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<LocalToWorld> forParameter_ltw;

				public void ScheduleTimeInitialize(VelocityEstimateSystem componentSystem)
				{
					forParameter_parent.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_ltw.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_parent = forParameter_parent.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_ltw = forParameter_ltw.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			internal void OriginalLambdaBody(ref VelocityParent parent, in LocalToWorld ltw)
			{
				parent.relativeToParentVelocity.localVelocity = math.mul(math.inverse(ltw.Rotation), parent.relativeToParentVelocity.globalVelocity);
				parent.relativeToParentVelocity.localAngularVelocity = math.mul(math.inverse(ltw.Rotation), parent.relativeToParentVelocity.globalAngularVelocity);
			}

			public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
				_runtimes = &runtimes;
				IterateEntities(ref chunk, ref *_runtimes);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(ref runtimes.runtime_parent.For(i), in runtimes.runtime_ltw.For(i));
				}
			}

			public void ScheduleTimeInitialize(VelocityEstimateSystem componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			}
		}

		private static CachedArchetype skipFrameEventEntityArchetype;

		private BeginSimulationEntityCommandBufferSystem beginSimulationEcbSystem;

		private EntityQuery _003C_003ECalculateSkipVelocity_entityQuery;

		private EntityQuery _003C_003EEstimateGlobalVelocity_entityQuery;

		private EntityQuery _003C_003EEstimateRelativeParentGlobalVelocity_entityQuery;

		private EntityQuery _003C_003ECalculateLocalVelocity_entityQuery;

		private EntityQuery _003C_003ECalculateRelativeParentLocalVelocity_entityQuery;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void StaticInit()
		{
			skipFrameEventEntityArchetype = new CachedArchetype(ComponentType.ReadWrite<SkipOneVelocityEstimateFrame>());
		}

		protected override void OnCreate()
		{
			beginSimulationEcbSystem = base.World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass4_0 displayClass = new _003C_003Ec__DisplayClass4_0
			{
				delta = base.Time.DeltaTime,
				velocities = GetComponentDataFromEntity<VelocityEstimate>(),
				prevLocalToWorlds = GetComponentDataFromEntity<PreviousFrameLocalToWorld>(),
				localToWorlds = GetComponentDataFromEntity<LocalToWorld>(),
				beginSimulationEcbConcurrent = beginSimulationEcbSystem.CreateCommandBuffer().ToConcurrent()
			};
			_ = base.Entities;
			JobHandle dependency = base.Dependency;
			_003C_003Ec__DisplayClass_CalculateSkipVelocity jobData = default(_003C_003Ec__DisplayClass_CalculateSkipVelocity);
			jobData.ScheduleTimeInitialize(this, ref displayClass);
			dependency = JobChunkExtensions.ScheduleSingle(jobData, _003C_003ECalculateSkipVelocity_entityQuery, dependency);
			base.Dependency = dependency;
			_ = base.Entities;
			JobHandle dependency2 = base.Dependency;
			_003C_003Ec__DisplayClass_EstimateGlobalVelocity jobData2 = default(_003C_003Ec__DisplayClass_EstimateGlobalVelocity);
			jobData2.ScheduleTimeInitialize(this, ref displayClass);
			dependency2 = JobChunkExtensions.ScheduleParallel(jobData2, _003C_003EEstimateGlobalVelocity_entityQuery, dependency2);
			base.Dependency = dependency2;
			_ = base.Entities;
			JobHandle dependency3 = base.Dependency;
			_003C_003Ec__DisplayClass_EstimateRelativeParentGlobalVelocity jobData3 = default(_003C_003Ec__DisplayClass_EstimateRelativeParentGlobalVelocity);
			jobData3.ScheduleTimeInitialize(this, ref displayClass);
			dependency3 = JobChunkExtensions.ScheduleParallel(jobData3, _003C_003EEstimateRelativeParentGlobalVelocity_entityQuery, dependency3);
			base.Dependency = dependency3;
			_ = base.Entities;
			JobHandle dependency4 = base.Dependency;
			_003C_003Ec__DisplayClass_CalculateLocalVelocity jobData4 = default(_003C_003Ec__DisplayClass_CalculateLocalVelocity);
			jobData4.ScheduleTimeInitialize(this);
			dependency4 = JobChunkExtensions.ScheduleParallel(jobData4, _003C_003ECalculateLocalVelocity_entityQuery, dependency4);
			base.Dependency = dependency4;
			_ = base.Entities;
			JobHandle dependency5 = base.Dependency;
			_003C_003Ec__DisplayClass_CalculateRelativeParentLocalVelocity jobData5 = default(_003C_003Ec__DisplayClass_CalculateRelativeParentLocalVelocity);
			jobData5.ScheduleTimeInitialize(this);
			dependency5 = JobChunkExtensions.ScheduleParallel(jobData5, _003C_003ECalculateRelativeParentLocalVelocity_entityQuery, dependency5);
			base.Dependency = dependency5;
			beginSimulationEcbSystem.AddJobHandleForProducer(base.Dependency);
		}

		public static void SkipOneFrame(Entity entity, Option<EntityCommandBuffer> beginPresentationEcb = default(Option<EntityCommandBuffer>))
		{
			if (!beginPresentationEcb.IsSome(out var value))
			{
				value = World.DefaultGameObjectInjectionWorld.GetExistingSystem<BeginPresentationEntityCommandBufferSystem>().CreateCommandBuffer();
			}
			Entity e = value.CreateEntity(skipFrameEventEntityArchetype.Archetype);
			value.AddComponent(e, new SkipOneVelocityEstimateFrame
			{
				target = entity
			});
		}

		private static float3 GetVelocityAtRelativePoint(float3 linearVelocity, float3 angularVelocity, float3 relPos)
		{
			return linearVelocity + math.cross(angularVelocity, relPos);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003ECalculateSkipVelocity_entityQuery = _003C_003EGetEntityQuery_ForCalculateSkipVelocity_From(this);
			_003C_003EEstimateGlobalVelocity_entityQuery = _003C_003EGetEntityQuery_ForEstimateGlobalVelocity_From(this);
			_003C_003EEstimateRelativeParentGlobalVelocity_entityQuery = _003C_003EGetEntityQuery_ForEstimateRelativeParentGlobalVelocity_From(this);
			_003C_003ECalculateLocalVelocity_entityQuery = _003C_003EGetEntityQuery_ForCalculateLocalVelocity_From(this);
			_003C_003ECalculateRelativeParentLocalVelocity_entityQuery = _003C_003EGetEntityQuery_ForCalculateRelativeParentLocalVelocity_From(this);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCalculateSkipVelocity_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadOnly<SkipOneVelocityEstimateFrame>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForEstimateGlobalVelocity_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
			{
				ComponentType.ReadWrite<PreviousFrameLocalToWorld>(),
				ComponentType.ReadWrite<VelocityEstimate>(),
				ComponentType.ReadOnly<LocalToWorld>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForEstimateRelativeParentGlobalVelocity_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
			{
				ComponentType.ReadWrite<VelocityParent>(),
				ComponentType.ReadOnly<LocalToWorld>(),
				ComponentType.ReadOnly<VelocityEstimate>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCalculateLocalVelocity_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadWrite<VelocityEstimate>(),
				ComponentType.ReadOnly<LocalToWorld>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCalculateRelativeParentLocalVelocity_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadWrite<VelocityParent>(),
				ComponentType.ReadOnly<LocalToWorld>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
