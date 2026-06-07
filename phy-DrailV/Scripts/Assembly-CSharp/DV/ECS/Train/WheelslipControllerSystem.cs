#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DV.Utils;
using DV.Wheels;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace DV.ECS.Train
{
	public class WheelslipControllerSystem : SystemBase
	{
		[UpdateInGroup(typeof(LateSimulationSystemGroup))]
		public class LateUpdateSystem : SystemBase
		{
			[Unity.Entities.DOTSCompilerGenerated]
			private struct _003C_003Ec__DisplayClass_Apply_Wheelslip : IJobChunk
			{
				private struct LambdaParameterValueProviders
				{
					public struct Runtimes
					{
						public LambdaParameterValueProvider_ManagedComponentData<TrainCar>.Runtime runtime_trainCar;

						public LambdaParameterValueProvider_ManagedComponentData<WheelslipController>.Runtime runtime_wheelslipController;

						public LambdaParameterValueProvider_IComponentData<WheelslipOutputData>.Runtime runtime_outputData;
					}

					private LambdaParameterValueProvider_ManagedComponentData<TrainCar> forParameter_trainCar;

					private LambdaParameterValueProvider_ManagedComponentData<WheelslipController> forParameter_wheelslipController;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<WheelslipOutputData> forParameter_outputData;

					public void ScheduleTimeInitialize(LateUpdateSystem componentSystem)
					{
						forParameter_trainCar.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_wheelslipController.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_outputData.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_trainCar = forParameter_trainCar.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_wheelslipController = forParameter_wheelslipController.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_outputData = forParameter_outputData.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(TrainCar trainCar, WheelslipController wheelslipController, in WheelslipOutputData outputData)
				{
					wheelslipController.ApplyWheelslip(outputData.wheelslip, outputData.orientedMaxWheelslipRpm, outputData.totalForceLimit);
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
						OriginalLambdaBody(runtimes.runtime_trainCar.For(i), runtimes.runtime_wheelslipController.For(i), in runtimes.runtime_outputData.For(i));
					}
				}

				public void ScheduleTimeInitialize(LateUpdateSystem componentSystem)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtilityEx.AsRef<_003C_003Ec__DisplayClass_Apply_Wheelslip>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery _003C_003EApply_Wheelslip_entityQuery;

			private ProfilerMarker _003C_003EApply_Wheelslip_profilerMarker;

			protected override void OnUpdate()
			{
				_ = base.Entities;
				_003C_003Ec__DisplayClass_Apply_Wheelslip jobData = default(_003C_003Ec__DisplayClass_Apply_Wheelslip);
				jobData.ScheduleTimeInitialize(this);
				CompleteDependency();
				EntityQuery query = _003C_003EApply_Wheelslip_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Apply_Wheelslip.s_RunWithoutJobSystemDelegateFieldNoBurst;
				_003C_003EApply_Wheelslip_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
				}
				finally
				{
					_003C_003EApply_Wheelslip_profilerMarker.End();
				}
			}

			protected internal unsafe override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
				_003C_003EApply_Wheelslip_entityQuery = _003C_003EGetEntityQuery_ForApply_Wheelslip_From(this);
				_003C_003Ec__DisplayClass_Apply_Wheelslip.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Apply_Wheelslip.RunWithoutJobSystem;
				_003C_003EApply_Wheelslip_profilerMarker = new ProfilerMarker("Apply_Wheelslip");
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForApply_Wheelslip_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
				entityQueryDesc.All = new ComponentType[3]
				{
					ComponentType.ReadWrite<TrainCar>(),
					ComponentType.ReadWrite<WheelslipController>(),
					ComponentType.ReadOnly<WheelslipOutputData>()
				};
				entityQueryDesc.Any = new ComponentType[2]
				{
					ComponentType.ReadWrite<TrainCarPositionMonitorSystem.IsMovingTag>(),
					ComponentType.ReadWrite<IsWheelslippingTag>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		public struct WheelslipInputData : IComponentData
		{
			public float generatedForce;

			public float brakingForce;

			public float wheelslipToAdhesionDrop;

			public float maxWheelslipRpm;

			public ushort numberOfPoweredAxles;

			public bool preventWheelslip;

			public bool isEngineBraking;
		}

		public struct WheelslipOutputData : IComponentData
		{
			public float wheelslip;

			public float wheelslipSmoothRefVel;

			public float orientedMaxWheelslipRpm;

			public float totalForceLimit;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public readonly struct IsWheelslippingTag : IComponentData
		{
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass5_0
		{
			public bool wheelslipAllowed;

			public float deltaTime;

			public EntityCommandBuffer.Concurrent endSimulationEcbConcurrent;

			public EntityCommandBuffer.Concurrent beginSimulationEcbConcurrent;

			internal void _003COnUpdate_003Eb__1(ref WheelslipOutputData outputData, in Entity entity, in int entityInQueryIndex, in WheelslipInputData inputData, in AdhesionControllerSystem.WheelSlideData wheelSlideData, in AdhesionControllerSystem.StaticSharedAdhesionCalculationData sharedAdhesionCalcData, in AdhesionControllerSystem.AdhesionWheelslipOutputData adhesionInputData)
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

					public LambdaParameterValueProvider_ManagedComponentData<WheelslipController>.Runtime runtime_wsc;

					public LambdaParameterValueProvider_IComponentData<WheelslipInputData>.Runtime runtime_inputData;

					public LambdaParameterValueProvider_IComponentData<WheelslipOutputData>.Runtime runtime_outputData;
				}

				private LambdaParameterValueProvider_ManagedComponentData<TrainCar> forParameter_trainCar;

				private LambdaParameterValueProvider_ManagedComponentData<WheelslipController> forParameter_wsc;

				private LambdaParameterValueProvider_IComponentData<WheelslipInputData> forParameter_inputData;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<WheelslipOutputData> forParameter_outputData;

				public void ScheduleTimeInitialize(WheelslipControllerSystem componentSystem)
				{
					forParameter_trainCar.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_wsc.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_inputData.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_outputData.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_trainCar = forParameter_trainCar.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_wsc = forParameter_wsc.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_inputData = forParameter_inputData.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_outputData = forParameter_outputData.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(TrainCar trainCar, WheelslipController wsc, ref WheelslipInputData inputData, in WheelslipOutputData outputData)
			{
				inputData.preventWheelslip = wsc.preventWheelslip;
				inputData.isEngineBraking = wsc.IsEngineBraking;
				inputData.numberOfPoweredAxles = (ushort)wsc.NumberOfPoweredAxles;
				inputData.generatedForce = wsc.DrivingForce.generatedForce;
				inputData.brakingForce = trainCar.RearBogie.brakingForce;
				inputData.wheelslipToAdhesionDrop = wsc.wheelslipToAdhesionDrop.Evaluate(outputData.wheelslip);
				inputData.maxWheelslipRpm = wsc.maxWheelslipRpm;
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
					OriginalLambdaBody(runtimes.runtime_trainCar.For(i), runtimes.runtime_wsc.For(i), ref runtimes.runtime_inputData.For(i), in runtimes.runtime_outputData.For(i));
				}
			}

			public void ScheduleTimeInitialize(WheelslipControllerSystem componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtilityEx.AsRef<_003C_003Ec__DisplayClass_Copy_TrainCar_Data>(jobData), ref *archetypeChunkIterator);
			}
		}

		[NoAlias]
		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		private struct _003C_003Ec__DisplayClass_Calculate_Wheelslip : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<WheelslipOutputData>.Runtime runtime_outputData;

					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

					[NoAlias]
					public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<WheelslipInputData>.Runtime runtime_inputData;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<AdhesionControllerSystem.WheelSlideData>.Runtime runtime_wheelSlideData;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<AdhesionControllerSystem.StaticSharedAdhesionCalculationData>.Runtime runtime_sharedAdhesionCalcData;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<AdhesionControllerSystem.AdhesionWheelslipOutputData>.Runtime runtime_adhesionInputData;
				}

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<WheelslipOutputData> forParameter_outputData;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<WheelslipInputData> forParameter_inputData;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<AdhesionControllerSystem.WheelSlideData> forParameter_wheelSlideData;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<AdhesionControllerSystem.StaticSharedAdhesionCalculationData> forParameter_sharedAdhesionCalcData;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<AdhesionControllerSystem.AdhesionWheelslipOutputData> forParameter_adhesionInputData;

				public void ScheduleTimeInitialize(WheelslipControllerSystem componentSystem)
				{
					forParameter_outputData.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_inputData.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_wheelSlideData.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_sharedAdhesionCalcData.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_adhesionInputData.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_outputData = forParameter_outputData.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
						runtime_inputData = forParameter_inputData.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_wheelSlideData = forParameter_wheelSlideData.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_sharedAdhesionCalcData = forParameter_sharedAdhesionCalcData.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_adhesionInputData = forParameter_adhesionInputData.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public bool wheelslipAllowed;

			public float deltaTime;

			public EntityCommandBuffer.Concurrent endSimulationEcbConcurrent;

			public EntityCommandBuffer.Concurrent beginSimulationEcbConcurrent;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			internal void OriginalLambdaBody(ref WheelslipOutputData outputData, in Entity entity, in int entityInQueryIndex, in WheelslipInputData inputData, in AdhesionControllerSystem.WheelSlideData wheelSlideData, in AdhesionControllerSystem.StaticSharedAdhesionCalculationData sharedAdhesionCalcData, in AdhesionControllerSystem.AdhesionWheelslipOutputData adhesionInputData)
			{
				float num5;
				if (wheelslipAllowed && !inputData.isEngineBraking && !inputData.preventWheelslip && wheelSlideData.wheelSlide <= 0f)
				{
					float num = inputData.brakingForce * (float)(int)sharedAdhesionCalcData.bogieCount;
					float num2 = math.clamp(math.abs(inputData.generatedForce) - num, 0f, float.PositiveInfinity);
					float num3 = math.select(0f, num2 / (float)(int)inputData.numberOfPoweredAxles, inputData.numberOfPoweredAxles != 0);
					float num4 = adhesionInputData.wheelslipForceLimitPerAxle * inputData.wheelslipToAdhesionDrop;
					outputData.totalForceLimit = num4 * (float)(int)inputData.numberOfPoweredAxles;
					num5 = math.select(math.select(0, 1, num3 > 1f), math.clamp((num3 - num4) / num4, 0f, 1f), num4 != 0f);
					float orientedMaxWheelslipRpm = math.sign(inputData.generatedForce) * inputData.maxWheelslipRpm;
					outputData.orientedMaxWheelslipRpm = orientedMaxWheelslipRpm;
				}
				else
				{
					outputData.totalForceLimit = adhesionInputData.wheelslipForceLimitPerAxle * (float)(int)inputData.numberOfPoweredAxles;
					num5 = 0f;
				}
				float wheelslip = outputData.wheelslip;
				outputData.wheelslip = Mathf.SmoothDamp(smoothTime: math.select(0.1f, 0.5f, num5 > outputData.wheelslip), current: outputData.wheelslip, target: num5, currentVelocity: ref outputData.wheelslipSmoothRefVel, maxSpeed: float.PositiveInfinity, deltaTime: deltaTime);
				if (outputData.wheelslip > 0f && outputData.wheelslip < 0.01f && num5 == 0f)
				{
					outputData.wheelslip = (outputData.wheelslipSmoothRefVel = 0f);
				}
				if (wheelslip != outputData.wheelslip)
				{
					if (outputData.wheelslip > 0f)
					{
						endSimulationEcbConcurrent.AddComponent<IsWheelslippingTag>(entityInQueryIndex, entity);
					}
					else
					{
						beginSimulationEcbConcurrent.RemoveComponent<IsWheelslippingTag>(entityInQueryIndex, entity);
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass5_0 displayClass)
			{
				wheelslipAllowed = displayClass.wheelslipAllowed;
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
					OriginalLambdaBody(ref runtimes.runtime_outputData.For(i), in runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_inputData.For(i), in runtimes.runtime_wheelSlideData.For(i), in runtimes.runtime_sharedAdhesionCalcData.For(i), in runtimes.runtime_adhesionInputData.For(i));
				}
			}

			public void ScheduleTimeInitialize(WheelslipControllerSystem componentSystem, ref _003C_003Ec__DisplayClass5_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}
		}

		private const float WHEELSLIP_RISE_SMOOTH_TIME = 0.5f;

		private const float WHEELSLIP_FALL_SMOOTH_TIME = 0.1f;

		private EntityCommandBufferSystem beginSimulationEcbSystem;

		private EntityCommandBufferSystem endSimulationEcbSystem;

		private EntityQuery _003C_003ECopy_TrainCar_Data_entityQuery;

		private ProfilerMarker _003C_003ECopy_TrainCar_Data_profilerMarker;

		private EntityQuery _003C_003ECalculate_Wheelslip_entityQuery;

		protected override void OnCreate()
		{
			beginSimulationEcbSystem = base.World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
			endSimulationEcbSystem = base.World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass5_0 displayClass = default(_003C_003Ec__DisplayClass5_0);
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
				displayClass.wheelslipAllowed = Globals.G.GameParams.WheelslipAllowed;
				displayClass.beginSimulationEcbConcurrent = beginSimulationEcbSystem.CreateCommandBuffer().ToConcurrent();
				displayClass.endSimulationEcbConcurrent = entityCommandBuffer.ToConcurrent();
				_ = base.Entities;
				JobHandle dependency = base.Dependency;
				_003C_003Ec__DisplayClass_Calculate_Wheelslip jobData2 = default(_003C_003Ec__DisplayClass_Calculate_Wheelslip);
				jobData2.ScheduleTimeInitialize(this, ref displayClass);
				dependency = JobChunkExtensions.ScheduleSingle(jobData2, _003C_003ECalculate_Wheelslip_entityQuery, dependency);
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
			_003C_003ECalculate_Wheelslip_entityQuery = _003C_003EGetEntityQuery_ForCalculate_Wheelslip_From(this);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCopy_TrainCar_Data_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[4]
			{
				ComponentType.ReadWrite<TrainCar>(),
				ComponentType.ReadWrite<WheelslipController>(),
				ComponentType.ReadWrite<WheelslipInputData>(),
				ComponentType.ReadOnly<WheelslipOutputData>()
			};
			entityQueryDesc.Any = new ComponentType[2]
			{
				ComponentType.ReadWrite<TrainCarPositionMonitorSystem.IsMovingTag>(),
				ComponentType.ReadWrite<IsWheelslippingTag>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCalculate_Wheelslip_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[5]
			{
				ComponentType.ReadWrite<WheelslipOutputData>(),
				ComponentType.ReadOnly<WheelslipInputData>(),
				ComponentType.ReadOnly<AdhesionControllerSystem.WheelSlideData>(),
				ComponentType.ReadOnly<AdhesionControllerSystem.StaticSharedAdhesionCalculationData>(),
				ComponentType.ReadOnly<AdhesionControllerSystem.AdhesionWheelslipOutputData>()
			};
			entityQueryDesc.Any = new ComponentType[2]
			{
				ComponentType.ReadWrite<TrainCarPositionMonitorSystem.IsMovingTag>(),
				ComponentType.ReadWrite<IsWheelslippingTag>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
