#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DV.Utils;
using DV.WeatherSystem;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Transforms;
using UnityEngine;

namespace DV.ECS.Train
{
	public class AdhesionControllerSystem : SystemBase
	{
		[UpdateInGroup(typeof(LateSimulationSystemGroup))]
		public class LateUpdateSystem : SystemBase
		{
			[Unity.Entities.DOTSCompilerGenerated]
			private struct _003C_003Ec__DisplayClass_Apply_Wheel_Slide : IJobChunk
			{
				private struct LambdaParameterValueProviders
				{
					public struct Runtimes
					{
						public LambdaParameterValueProvider_ManagedComponentData<TrainCar>.Runtime runtime_trainCar;

						public LambdaParameterValueProvider_IComponentData<WheelSlideData>.Runtime runtime_data;
					}

					private LambdaParameterValueProvider_ManagedComponentData<TrainCar> forParameter_trainCar;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<WheelSlideData> forParameter_data;

					public void ScheduleTimeInitialize(LateUpdateSystem componentSystem)
					{
						forParameter_trainCar.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_data.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_trainCar = forParameter_trainCar.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_data = forParameter_data.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(TrainCar trainCar, in WheelSlideData data)
				{
					trainCar.adhesionController.ApplyWheelSlide(data.wheelSlide);
				}

				public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
				{
					LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
					_runtimes = &runtimes;
					IterateEntities(ref chunk, ref *_runtimes);
				}

				public void IterateEntities(ref ArchetypeChunk chunk, ref LambdaParameterValueProviders.Runtimes runtimes)
				{
					int count = chunk.Count;
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(runtimes.runtime_trainCar.For(i), in runtimes.runtime_data.For(i));
					}
				}

				public void ScheduleTimeInitialize(LateUpdateSystem componentSystem)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtilityEx.AsRef<_003C_003Ec__DisplayClass_Apply_Wheel_Slide>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery _003C_003EApply_Wheel_Slide_entityQuery;

			private ProfilerMarker _003C_003EApply_Wheel_Slide_profilerMarker;

			protected override void OnUpdate()
			{
				_ = base.Entities;
				_003C_003Ec__DisplayClass_Apply_Wheel_Slide jobData = default(_003C_003Ec__DisplayClass_Apply_Wheel_Slide);
				jobData.ScheduleTimeInitialize(this);
				CompleteDependency();
				EntityQuery query = _003C_003EApply_Wheel_Slide_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Apply_Wheel_Slide.s_RunWithoutJobSystemDelegateFieldNoBurst;
				_003C_003EApply_Wheel_Slide_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
				}
				finally
				{
					_003C_003EApply_Wheel_Slide_profilerMarker.End();
				}
			}

			protected internal unsafe override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
				_003C_003EApply_Wheel_Slide_entityQuery = _003C_003EGetEntityQuery_ForApply_Wheel_Slide_From(this);
				_003C_003Ec__DisplayClass_Apply_Wheel_Slide.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Apply_Wheel_Slide.RunWithoutJobSystem;
				_003C_003EApply_Wheel_Slide_profilerMarker = new ProfilerMarker("Apply_Wheel_Slide");
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForApply_Wheel_Slide_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
				{
					ComponentType.ReadOnly<IsWheelSlidingTag>(),
					ComponentType.ReadWrite<TrainCar>(),
					ComponentType.ReadOnly<WheelSlideData>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		public struct StaticSharedAdhesionCalculationData : IComponentData
		{
			public byte bogieCount;

			public byte numOfAxles;
		}

		public struct StaticAdhesionCalculationData : IComponentData
		{
			public float wheelSlideFrictionCoef;

			public float wheelslipFrictionCoef;
		}

		public struct AdhesionCalculationData : IComponentData
		{
			public float absSpeed;

			public float sandCoef;

			public float weightPerAxle;

			public float engineBrakingForcePerAxle;

			public float brakingForce;

			public bool isDerailed;

			public bool isGrounded;
		}

		public struct WheelSlideData : IComponentData
		{
			public float wheelSlide;

			public float wheelSlideSmoothRefVel;
		}

		public struct AdhesionWheelslipOutputData : IComponentData
		{
			public float wheelslipForceLimitPerAxle;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public readonly struct IsWheelSlidingTag : IComponentData
		{
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass12_0
		{
			public float wetness;

			public bool wheelSlideAllowed;

			public float deltaTime;

			public EntityCommandBuffer.Concurrent endSimulationEcbConcurrent;

			public EntityCommandBuffer.Concurrent beginSimulationEcbConcurrent;

			internal void _003COnUpdate_003Eb__1(ref WheelSlideData wheelSlideData, ref AdhesionWheelslipOutputData wheelslipData, in Entity entity, in int entityInQueryIndex, in LocalToWorld transform, in AdhesionCalculationData calcData, in StaticAdhesionCalculationData staticCalcData, in StaticSharedAdhesionCalculationData staticSharedCalcData)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_Copy_TrainCar_Data : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_ManagedComponentData<TrainCar>.Runtime runtime_trainCar;

					public LambdaParameterValueProvider_IComponentData<AdhesionCalculationData>.Runtime runtime_data;
				}

				private LambdaParameterValueProvider_ManagedComponentData<TrainCar> forParameter_trainCar;

				private LambdaParameterValueProvider_IComponentData<AdhesionCalculationData> forParameter_data;

				public void ScheduleTimeInitialize(AdhesionControllerSystem componentSystem)
				{
					forParameter_trainCar.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_data.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_trainCar = forParameter_trainCar.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_data = forParameter_data.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(TrainCar trainCar, ref AdhesionCalculationData data)
			{
				data.absSpeed = trainCar.GetAbsSpeed();
				data.sandCoef = (trainCar.adhesionController.wheelslipController.IsSome(out var value) ? value.SandCoef : 1f);
				data.weightPerAxle = trainCar.massController.WeightPerAxle;
				data.engineBrakingForcePerAxle = ((!trainCar.adhesionController.wheelslipController.IsSome() || value.preventWheelslip) ? 0f : value.EngineBrakingForcePerAxle);
				data.brakingForce = trainCar.RearBogie.brakingForce;
				data.isDerailed = trainCar.derailed;
				data.isGrounded = trainCar.groundFriction.IsGrounded;
			}

			public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
			{
				LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
				_runtimes = &runtimes;
				IterateEntities(ref chunk, ref *_runtimes);
			}

			public void IterateEntities(ref ArchetypeChunk chunk, ref LambdaParameterValueProviders.Runtimes runtimes)
			{
				int count = chunk.Count;
				for (int i = 0; i < count; i++)
				{
					OriginalLambdaBody(runtimes.runtime_trainCar.For(i), ref runtimes.runtime_data.For(i));
				}
			}

			public void ScheduleTimeInitialize(AdhesionControllerSystem componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtilityEx.AsRef<_003C_003Ec__DisplayClass_Copy_TrainCar_Data>(jobData), ref *archetypeChunkIterator);
			}
		}

		[NoAlias]
		[BurstCompile]
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_Calculate_Adhesion : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<WheelSlideData>.Runtime runtime_wheelSlideData;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<AdhesionWheelslipOutputData>.Runtime runtime_wheelslipData;

					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

					[NoAlias]
					public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<LocalToWorld>.Runtime runtime_transform;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<AdhesionCalculationData>.Runtime runtime_calcData;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<StaticAdhesionCalculationData>.Runtime runtime_staticCalcData;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<StaticSharedAdhesionCalculationData>.Runtime runtime_staticSharedCalcData;
				}

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<WheelSlideData> forParameter_wheelSlideData;

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<AdhesionWheelslipOutputData> forParameter_wheelslipData;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<LocalToWorld> forParameter_transform;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<AdhesionCalculationData> forParameter_calcData;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<StaticAdhesionCalculationData> forParameter_staticCalcData;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<StaticSharedAdhesionCalculationData> forParameter_staticSharedCalcData;

				public void ScheduleTimeInitialize(AdhesionControllerSystem componentSystem)
				{
					forParameter_wheelSlideData.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_wheelslipData.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_transform.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_calcData.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_staticCalcData.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_staticSharedCalcData.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_wheelSlideData = forParameter_wheelSlideData.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_wheelslipData = forParameter_wheelslipData.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
						runtime_transform = forParameter_transform.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_calcData = forParameter_calcData.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_staticCalcData = forParameter_staticCalcData.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_staticSharedCalcData = forParameter_staticSharedCalcData.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public float wetness;

			public bool wheelSlideAllowed;

			public float deltaTime;

			public EntityCommandBuffer.Concurrent endSimulationEcbConcurrent;

			public EntityCommandBuffer.Concurrent beginSimulationEcbConcurrent;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			internal void OriginalLambdaBody(ref WheelSlideData wheelSlideData, ref AdhesionWheelslipOutputData wheelslipData, in Entity entity, in int entityInQueryIndex, in LocalToWorld transform, in AdhesionCalculationData calcData, in StaticAdhesionCalculationData staticCalcData, in StaticSharedAdhesionCalculationData staticSharedCalcData)
			{
				float num = math.select(1f, math.select(0.01f, 1f, calcData.isGrounded), calcData.isDerailed);
				num *= calcData.sandCoef;
				num *= math.select(1f, 1f - NumberUtil.MapClamp(wetness, 0f, 0.5f, 0f, 0.5f), wetness > 0f);
				float num2 = math.abs(math.Euler(transform.Rotation).x % 360f);
				if (num2 > 180f)
				{
					num2 = math.abs(num2 - 360f);
				}
				num *= 1f - math.clamp(5f * math.clamp(num2 / 90f, 0f, 1f), 0f, 0.9999999f);
				float wheelSlide = wheelSlideData.wheelSlide;
				float num5;
				if (wheelSlideAllowed && calcData.absSpeed > 0.005f)
				{
					float num3 = staticCalcData.wheelSlideFrictionCoef * num * calcData.weightPerAxle;
					num3 *= math.lerp(1f, 0.2f, wheelSlideData.wheelSlide);
					float num4 = calcData.brakingForce * (float)(int)staticSharedCalcData.bogieCount / (float)(int)staticSharedCalcData.numOfAxles + calcData.engineBrakingForcePerAxle;
					num5 = math.select(math.select(0f, 1f, num4 > 1f), math.clamp((num4 - num3) / num3, 0f, 1f), num3 != 0f);
				}
				else
				{
					num5 = 0f;
				}
				float smoothTime = math.select(0.1f, 0.3f, num5 > wheelSlideData.wheelSlide);
				wheelSlideData.wheelSlide = Mathf.SmoothDamp(wheelSlideData.wheelSlide, num5, ref wheelSlideData.wheelSlideSmoothRefVel, smoothTime, float.PositiveInfinity, deltaTime);
				if (wheelSlideData.wheelSlide > 0f && wheelSlideData.wheelSlide < 0.01f && num5 == 0f)
				{
					wheelSlideData.wheelSlide = (wheelSlideData.wheelSlideSmoothRefVel = 0f);
				}
				wheelslipData.wheelslipForceLimitPerAxle = staticCalcData.wheelslipFrictionCoef * num * calcData.weightPerAxle;
				if (wheelSlide == 0f && wheelSlideData.wheelSlide > 0f)
				{
					endSimulationEcbConcurrent.AddComponent<IsWheelSlidingTag>(entityInQueryIndex, entity);
				}
				else if (wheelSlide > 0f && wheelSlideData.wheelSlide == 0f)
				{
					beginSimulationEcbConcurrent.RemoveComponent<IsWheelSlidingTag>(entityInQueryIndex, entity);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass12_0 displayClass)
			{
				wetness = displayClass.wetness;
				wheelSlideAllowed = displayClass.wheelSlideAllowed;
				deltaTime = displayClass.deltaTime;
				endSimulationEcbConcurrent = displayClass.endSimulationEcbConcurrent;
				beginSimulationEcbConcurrent = displayClass.beginSimulationEcbConcurrent;
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
					OriginalLambdaBody(ref runtimes.runtime_wheelSlideData.For(i), ref runtimes.runtime_wheelslipData.For(i), in runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_transform.For(i), in runtimes.runtime_calcData.For(i), in runtimes.runtime_staticCalcData.For(i), in runtimes.runtime_staticSharedCalcData.For(i));
				}
			}

			public void ScheduleTimeInitialize(AdhesionControllerSystem componentSystem, ref _003C_003Ec__DisplayClass12_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}
		}

		private const float SLOPE_COEF_MULTIPLIER = 5f;

		private const float FRICTION_MODIFIER_DERAILED_GROUNDED = 1f;

		private const float FRICTION_MODIFIER_DERAILED_NOT_GROUNDED = 0.01f;

		private const float WETNESS_FRICTION_MODIFIER_MAX = 0.5f;

		private const float WETNESS_HIGHEST_IMPACT_THRESHOLD = 0.5f;

		private const float WHEEL_SLIDE_SPEED_THRESHOLD = 0.005f;

		private const float WHEEL_SLIDE_ADHESION_REDUCE_MULTIPLIER = 0.2f;

		private const float WHEELSLIDE_RISE_SMOOTH_TIME = 0.3f;

		private const float WHEELSLIDE_FALL_SMOOTH_TIME = 0.1f;

		private EntityCommandBufferSystem beginSimulationEcbSystem;

		private EntityCommandBufferSystem endSimulationEcbSystem;

		private EntityQuery _003C_003ECopy_TrainCar_Data_entityQuery;

		private ProfilerMarker _003C_003ECopy_TrainCar_Data_profilerMarker;

		private EntityQuery _003C_003ECalculate_Adhesion_entityQuery;

		protected override void OnCreate()
		{
			beginSimulationEcbSystem = base.World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
			endSimulationEcbSystem = base.World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass12_0 displayClass = default(_003C_003Ec__DisplayClass12_0);
			if (!SingletonBehaviour<AppUtil>.Instance.IsTimePausedSafer && !SingletonBehaviour<CarSpawner>.Instance.PoolSetupInProgress)
			{
				EntityCommandBuffer entityCommandBuffer = endSimulationEcbSystem.CreateCommandBuffer();
				_ = base.Entities;
				_003C_003Ec__DisplayClass_Copy_TrainCar_Data jobData = default(_003C_003Ec__DisplayClass_Copy_TrainCar_Data);
				jobData.ScheduleTimeInitialize(this);
				CompleteDependency();
				EntityQuery query = _003C_003ECopy_TrainCar_Data_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Copy_TrainCar_Data.s_RunWithoutJobSystemDelegateFieldNoBurst;
				_003C_003ECopy_TrainCar_Data_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
				}
				finally
				{
					_003C_003ECopy_TrainCar_Data_profilerMarker.End();
				}
				displayClass.deltaTime = base.Time.DeltaTime;
				GameParams gameParams = Globals.G.GameParams;
				displayClass.wheelSlideAllowed = gameParams.WheelSlideAllowed;
				displayClass.wetness = ((!gameParams.AdhesionInfluencedByWeather) ? 0f : (SingletonBehaviour<WeatherDriver>.Instance?.WetnessValue.CurrentValue ?? 0f));
				displayClass.beginSimulationEcbConcurrent = beginSimulationEcbSystem.CreateCommandBuffer().ToConcurrent();
				displayClass.endSimulationEcbConcurrent = entityCommandBuffer.ToConcurrent();
				_ = base.Entities;
				JobHandle dependency = base.Dependency;
				_003C_003Ec__DisplayClass_Calculate_Adhesion jobData2 = default(_003C_003Ec__DisplayClass_Calculate_Adhesion);
				jobData2.ScheduleTimeInitialize(this, ref displayClass);
				dependency = JobChunkExtensions.ScheduleParallel(jobData2, _003C_003ECalculate_Adhesion_entityQuery, dependency);
				base.Dependency = dependency;
				beginSimulationEcbSystem.AddJobHandleForProducer(base.Dependency);
				endSimulationEcbSystem.AddJobHandleForProducer(base.Dependency);
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003ECopy_TrainCar_Data_entityQuery = _003C_003EGetEntityQuery_ForCopy_TrainCar_Data_From(this);
			_003C_003Ec__DisplayClass_Copy_TrainCar_Data.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Copy_TrainCar_Data.RunWithoutJobSystem;
			_003C_003ECopy_TrainCar_Data_profilerMarker = new ProfilerMarker("Copy_TrainCar_Data");
			_003C_003ECalculate_Adhesion_entityQuery = _003C_003EGetEntityQuery_ForCalculate_Adhesion_From(this);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCopy_TrainCar_Data_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[2]
			{
				ComponentType.ReadWrite<TrainCar>(),
				ComponentType.ReadWrite<AdhesionCalculationData>()
			};
			entityQueryDesc.Any = new ComponentType[3]
			{
				ComponentType.ReadWrite<TrainCarPositionMonitorSystem.IsMovingTag>(),
				ComponentType.ReadWrite<IsWheelSlidingTag>(),
				ComponentType.ReadWrite<WheelslipControllerSystem.IsWheelslippingTag>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCalculate_Adhesion_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[6]
			{
				ComponentType.ReadWrite<WheelSlideData>(),
				ComponentType.ReadWrite<AdhesionWheelslipOutputData>(),
				ComponentType.ReadOnly<LocalToWorld>(),
				ComponentType.ReadOnly<AdhesionCalculationData>(),
				ComponentType.ReadOnly<StaticAdhesionCalculationData>(),
				ComponentType.ReadOnly<StaticSharedAdhesionCalculationData>()
			};
			entityQueryDesc.Any = new ComponentType[3]
			{
				ComponentType.ReadWrite<TrainCarPositionMonitorSystem.IsMovingTag>(),
				ComponentType.ReadWrite<IsWheelSlidingTag>(),
				ComponentType.ReadWrite<WheelslipControllerSystem.IsWheelslippingTag>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
