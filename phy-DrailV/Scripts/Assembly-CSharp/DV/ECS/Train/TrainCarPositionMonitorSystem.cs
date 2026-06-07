#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DV.OriginShift;
using DV.Utils;
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
	public class TrainCarPositionMonitorSystem : SystemBase
	{
		[UpdateInGroup(typeof(LateSimulationSystemGroup))]
		public class LateUpdateSystem : SystemBase
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass3_0
			{
				public EntityCommandBuffer beginSimulationEcb;

				internal void _003COnUpdate_003Eb__0(TrainCar trainCar, in Entity entity)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}

				internal void _003COnUpdate_003Eb__1(TrainCar trainCar, in Entity entity)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}

				internal void _003COnUpdate_003Eb__2(TrainCar trainCar, in Entity entity, in TrainCarPositionData data)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}
			}

			[Unity.Entities.DOTSCompilerGenerated]
			private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
			{
				private struct LambdaParameterValueProviders
				{
					public struct Runtimes
					{
						public LambdaParameterValueProvider_ManagedComponentData<TrainCar>.Runtime runtime_trainCar;

						public LambdaParameterValueProvider_Entity.Runtime runtime_entity;
					}

					private LambdaParameterValueProvider_ManagedComponentData<TrainCar> forParameter_trainCar;

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					public void ScheduleTimeInitialize(LateUpdateSystem componentSystem)
					{
						forParameter_trainCar.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_trainCar = forParameter_trainCar.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public EntityCommandBuffer beginSimulationEcb;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(TrainCar trainCar, in Entity entity)
				{
					trainCar.OnInvalidPosition();
					beginSimulationEcb.RemoveComponent<InvalidPositionTag>(entity);
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					beginSimulationEcb = displayClass.beginSimulationEcb;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					displayClass.beginSimulationEcb = beginSimulationEcb;
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
						OriginalLambdaBody(runtimes.runtime_trainCar.For(i), in runtimes.runtime_entity.For(i));
					}
				}

				public void ScheduleTimeInitialize(LateUpdateSystem componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtilityEx.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			[Unity.Entities.DOTSCompilerGenerated]
			private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 : IJobChunk
			{
				private struct LambdaParameterValueProviders
				{
					public struct Runtimes
					{
						public LambdaParameterValueProvider_ManagedComponentData<TrainCar>.Runtime runtime_trainCar;

						public LambdaParameterValueProvider_Entity.Runtime runtime_entity;
					}

					private LambdaParameterValueProvider_ManagedComponentData<TrainCar> forParameter_trainCar;

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					public void ScheduleTimeInitialize(LateUpdateSystem componentSystem)
					{
						forParameter_trainCar.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_trainCar = forParameter_trainCar.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public EntityCommandBuffer beginSimulationEcb;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(TrainCar trainCar, in Entity entity)
				{
					trainCar.OnOutOfWorld();
					beginSimulationEcb.RemoveComponent<OutOfWorldTag>(entity);
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					beginSimulationEcb = displayClass.beginSimulationEcb;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					displayClass.beginSimulationEcb = beginSimulationEcb;
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
						OriginalLambdaBody(runtimes.runtime_trainCar.For(i), in runtimes.runtime_entity.For(i));
					}
				}

				public void ScheduleTimeInitialize(LateUpdateSystem componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtilityEx.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1>(jobData), ref *archetypeChunkIterator);
				}
			}

			[Unity.Entities.DOTSCompilerGenerated]
			private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob2 : IJobChunk
			{
				private struct LambdaParameterValueProviders
				{
					public struct Runtimes
					{
						public LambdaParameterValueProvider_ManagedComponentData<TrainCar>.Runtime runtime_trainCar;

						public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

						public LambdaParameterValueProvider_IComponentData<TrainCarPositionData>.Runtime runtime_data;
					}

					private LambdaParameterValueProvider_ManagedComponentData<TrainCar> forParameter_trainCar;

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<TrainCarPositionData> forParameter_data;

					public void ScheduleTimeInitialize(LateUpdateSystem componentSystem)
					{
						forParameter_trainCar.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_data.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_trainCar = forParameter_trainCar.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_data = forParameter_data.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public EntityCommandBuffer beginSimulationEcb;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(TrainCar trainCar, in Entity entity, in TrainCarPositionData data)
				{
					if (trainCar.isStationary != data.isStationary)
					{
						trainCar.OnMovementStateChanged(!data.isStationary);
					}
					trainCar.UpdateSleepState(data.isStationary, data.isEligibleForSleep);
					beginSimulationEcb.RemoveComponent<SleepFlagsChangedTag>(entity);
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					beginSimulationEcb = displayClass.beginSimulationEcb;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					displayClass.beginSimulationEcb = beginSimulationEcb;
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
						OriginalLambdaBody(runtimes.runtime_trainCar.For(i), in runtimes.runtime_entity.For(i), in runtimes.runtime_data.For(i));
					}
				}

				public void ScheduleTimeInitialize(LateUpdateSystem componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtilityEx.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityCommandBufferSystem beginSimulationEcbSystem;

			private TrainCarPositionMonitorSystem system;

			private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

			private EntityQuery _003C_003EOnUpdate_LambdaJob1_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob1_profilerMarker;

			private EntityQuery _003C_003EOnUpdate_LambdaJob2_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob2_profilerMarker;

			protected override void OnCreate()
			{
				beginSimulationEcbSystem = base.World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
				system = base.World.GetOrCreateSystem<TrainCarPositionMonitorSystem>();
			}

			protected override void OnUpdate()
			{
				_003C_003Ec__DisplayClass3_0 displayClass = default(_003C_003Ec__DisplayClass3_0);
				system.Dependency.Complete();
				displayClass.beginSimulationEcb = beginSimulationEcbSystem.CreateCommandBuffer();
				_ = base.Entities;
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
				jobData.ScheduleTimeInitialize(this, ref displayClass);
				CompleteDependency();
				EntityQuery query = _003C_003EOnUpdate_LambdaJob0_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst;
				_003C_003EOnUpdate_LambdaJob0_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
				}
				finally
				{
					_003C_003EOnUpdate_LambdaJob0_profilerMarker.End();
				}
				jobData.WriteToDisplayClass(ref displayClass);
				_ = base.Entities;
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 jobData2 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1);
				jobData2.ScheduleTimeInitialize(this, ref displayClass);
				CompleteDependency();
				EntityQuery query2 = _003C_003EOnUpdate_LambdaJob1_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst2 = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst;
				_003C_003EOnUpdate_LambdaJob1_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData2, query2, s_RunWithoutJobSystemDelegateFieldNoBurst2);
				}
				finally
				{
					_003C_003EOnUpdate_LambdaJob1_profilerMarker.End();
				}
				jobData2.WriteToDisplayClass(ref displayClass);
				_ = base.Entities;
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2 jobData3 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2);
				jobData3.ScheduleTimeInitialize(this, ref displayClass);
				CompleteDependency();
				EntityQuery query3 = _003C_003EOnUpdate_LambdaJob2_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst3 = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst;
				_003C_003EOnUpdate_LambdaJob2_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData3, query3, s_RunWithoutJobSystemDelegateFieldNoBurst3);
				}
				finally
				{
					_003C_003EOnUpdate_LambdaJob2_profilerMarker.End();
				}
				jobData3.WriteToDisplayClass(ref displayClass);
			}

			protected internal unsafe override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
				_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
				_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
				_003C_003EOnUpdate_LambdaJob1_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(this);
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.RunWithoutJobSystem;
				_003C_003EOnUpdate_LambdaJob1_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob1");
				_003C_003EOnUpdate_LambdaJob2_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob2_From(this);
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.RunWithoutJobSystem;
				_003C_003EOnUpdate_LambdaJob2_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob2");
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadOnly<InvalidPositionTag>(),
					ComponentType.ReadWrite<TrainCar>()
				};
				return componentSystem.GetEntityQuery(array);
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadOnly<OutOfWorldTag>(),
					ComponentType.ReadWrite<TrainCar>()
				};
				return componentSystem.GetEntityQuery(array);
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob2_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
				{
					ComponentType.ReadOnly<SleepFlagsChangedTag>(),
					ComponentType.ReadWrite<TrainCar>(),
					ComponentType.ReadOnly<TrainCarPositionData>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		public struct TrainCarPositionData : IComponentData
		{
			public float3 prevPosition;

			public float prevYRotation;

			public float stationaryTimer;

			public bool isInteriorLoaded;

			public bool isEligibleForSleep;

			public bool isStationary;

			public bool wakeUp;
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public readonly struct SleepFlagsChangedTag : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public readonly struct IsMovingTag : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public readonly struct InvalidPositionTag : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public readonly struct OutOfWorldTag : IComponentData
		{
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass7_0
		{
			public EntityCommandBuffer.Concurrent endSimulationEcbConcurrent;

			public float yResetThresholdMax;

			public float deltaTime;

			internal void _003COnUpdate_003Eb__0(ref TrainCarPositionData data, in Entity entity, in int entityInQueryIndex, in LocalToWorld transform)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		[NoAlias]
		private struct _003C_003Ec__DisplayClass_Check_TrainCar_Positions : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<TrainCarPositionData>.Runtime runtime_data;

					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

					[NoAlias]
					public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<LocalToWorld>.Runtime runtime_transform;
				}

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<TrainCarPositionData> forParameter_data;

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

				[NoAlias]
				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<LocalToWorld> forParameter_transform;

				public void ScheduleTimeInitialize(TrainCarPositionMonitorSystem componentSystem)
				{
					forParameter_data.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_transform.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_data = forParameter_data.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
						runtime_transform = forParameter_transform.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public EntityCommandBuffer.Concurrent endSimulationEcbConcurrent;

			public float yResetThresholdMax;

			public float deltaTime;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			internal void OriginalLambdaBody(ref TrainCarPositionData data, in Entity entity, in int entityInQueryIndex, in LocalToWorld transform)
			{
				float3 float5 = transform.AbsolutePosition();
				if (NumberUtil.AnyInfinityMinMaxNaN(float5))
				{
					endSimulationEcbConcurrent.AddComponent<InvalidPositionTag>(entityInQueryIndex, entity);
					return;
				}
				if (float5.y < -1f || float5.y > yResetThresholdMax)
				{
					endSimulationEcbConcurrent.AddComponent<OutOfWorldTag>(entityInQueryIndex, entity);
				}
				float y = math.EulerZXY(transform.Rotation).y;
				if (data.wakeUp || math.lengthsq(float5 - data.prevPosition) > math.select(0.0001f, 4.0000004E-06f, data.isInteriorLoaded) || math.abs(Mathf.DeltaAngle(y, data.prevYRotation)) > 0.0002f)
				{
					data.prevPosition = float5;
					data.prevYRotation = y;
					data.stationaryTimer = 0f;
					data.isEligibleForSleep = false;
					data.wakeUp = false;
					if (data.isStationary)
					{
						data.isStationary = false;
						endSimulationEcbConcurrent.AddComponent<IsMovingTag>(entityInQueryIndex, entity);
						endSimulationEcbConcurrent.AddComponent<SleepFlagsChangedTag>(entityInQueryIndex, entity);
					}
				}
				else
				{
					if (data.isEligibleForSleep && data.isStationary)
					{
						return;
					}
					if (data.stationaryTimer < 1f)
					{
						data.stationaryTimer += deltaTime;
					}
					else if (data.stationaryTimer >= 1f)
					{
						data.stationaryTimer = 0f;
						data.isEligibleForSleep = true;
						if (!data.isStationary)
						{
							data.isStationary = true;
							endSimulationEcbConcurrent.RemoveComponent<IsMovingTag>(entityInQueryIndex, entity);
							endSimulationEcbConcurrent.AddComponent<SleepFlagsChangedTag>(entityInQueryIndex, entity);
						}
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass7_0 displayClass)
			{
				endSimulationEcbConcurrent = displayClass.endSimulationEcbConcurrent;
				yResetThresholdMax = displayClass.yResetThresholdMax;
				deltaTime = displayClass.deltaTime;
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
					OriginalLambdaBody(ref runtimes.runtime_data.For(i), in runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_transform.For(i));
				}
			}

			public void ScheduleTimeInitialize(TrainCarPositionMonitorSystem componentSystem, ref _003C_003Ec__DisplayClass7_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}
		}

		private const float STATIONARY_THRESHOLD = 0.0001f;

		private const float STATIONARY_THRESHOLD_PLAYER = 4.0000004E-06f;

		private const float ROTATION_THRESHOLD_RAD = 0.0002f;

		private const float STATIONARY_TIME_REQUIRED_FOR_SLEEP = 1f;

		private const float Y_RESET_THRESHOLD_MIN = -1f;

		private EntityCommandBufferSystem endSimulationEcbSystem;

		private EntityQuery _003C_003ECheck_TrainCar_Positions_entityQuery;

		protected override void OnCreate()
		{
			endSimulationEcbSystem = base.World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass7_0 displayClass = default(_003C_003Ec__DisplayClass7_0);
			if (!SingletonBehaviour<AppUtil>.Instance.IsTimePausedSafer && !SingletonBehaviour<CarSpawner>.Instance.PoolSetupInProgress)
			{
				EntityCommandBuffer entityCommandBuffer = endSimulationEcbSystem.CreateCommandBuffer();
				displayClass.deltaTime = base.Time.DeltaTime;
				displayClass.endSimulationEcbConcurrent = entityCommandBuffer.ToConcurrent();
				displayClass.yResetThresholdMax = ((SingletonBehaviour<LevelInfo>.Instance != null) ? (LevelInfo.WorldBoundarySize.y * 1.5f) : 3000f);
				_ = base.Entities;
				JobHandle dependency = base.Dependency;
				_003C_003Ec__DisplayClass_Check_TrainCar_Positions jobData = default(_003C_003Ec__DisplayClass_Check_TrainCar_Positions);
				jobData.ScheduleTimeInitialize(this, ref displayClass);
				dependency = JobChunkExtensions.ScheduleParallel(jobData, _003C_003ECheck_TrainCar_Positions_entityQuery, dependency);
				base.Dependency = dependency;
				endSimulationEcbSystem.AddJobHandleForProducer(base.Dependency);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003ECheck_TrainCar_Positions_entityQuery = _003C_003EGetEntityQuery_ForCheck_TrainCar_Positions_From(this);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCheck_TrainCar_Positions_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadWrite<TrainCarPositionData>(),
				ComponentType.ReadOnly<LocalToWorld>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
