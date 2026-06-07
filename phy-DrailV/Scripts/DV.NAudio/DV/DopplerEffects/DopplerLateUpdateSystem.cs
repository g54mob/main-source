#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DV.Utils;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Jobs;

namespace DV.DopplerEffects
{
	[UpdateInGroup(typeof(PresentationSystemGroup))]
	[AlwaysUpdateSystem]
	public class DopplerLateUpdateSystem : SystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass4_0
		{
			public bool shouldSkipVelocity;

			public float invTime;

			public float3 listenerPos;

			public float3 listenerVel;

			internal void _003COnUpdate_003Eb__1(ref Doppler.DopplerData data)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003COnUpdate_003Eb__2(ref Doppler.DopplerData data)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_Copy_And_Apply_Data : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_ManagedComponentData<Doppler>.Runtime runtime_doppler;

					public LambdaParameterValueProvider_IComponentData<Doppler.DopplerData>.Runtime runtime_data;
				}

				private LambdaParameterValueProvider_ManagedComponentData<Doppler> forParameter_doppler;

				private LambdaParameterValueProvider_IComponentData<Doppler.DopplerData> forParameter_data;

				public void ScheduleTimeInitialize(DopplerLateUpdateSystem componentSystem)
				{
					forParameter_doppler.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_data.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_doppler = forParameter_doppler.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_data = forParameter_data.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Doppler doppler, ref Doppler.DopplerData data)
			{
				data.desiredPitch = doppler.desiredPitch;
				data.spatialBlend = (byte)(doppler.GetSpatialBlend() * 255f);
				if (data.skipFrames != 0)
				{
					data.skipFrames--;
				}
				else
				{
					doppler.ApplyPitch(data.finalPitch);
				}
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
					OriginalLambdaBody(runtimes.runtime_doppler.For(i), ref runtimes.runtime_data.For(i));
				}
			}

			public void ScheduleTimeInitialize(DopplerLateUpdateSystem componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtilityEx.AsRef<_003C_003Ec__DisplayClass_Copy_And_Apply_Data>(jobData), ref *archetypeChunkIterator);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		[BurstCompile]
		[NoAlias]
		private struct _003C_003Ec__DisplayClass_Calculate_Velocity : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<Doppler.DopplerData>.Runtime runtime_data;
				}

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<Doppler.DopplerData> forParameter_data;

				public void ScheduleTimeInitialize(DopplerLateUpdateSystem componentSystem)
				{
					forParameter_data.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_data = forParameter_data.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public bool shouldSkipVelocity;

			public float invTime;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			internal void OriginalLambdaBody(ref Doppler.DopplerData data)
			{
				if (!shouldSkipVelocity)
				{
					data.velocity = (data.newPos - data.oldPos) * invTime;
				}
				data.oldPos = data.newPos;
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				shouldSkipVelocity = displayClass.shouldSkipVelocity;
				invTime = displayClass.invTime;
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
					OriginalLambdaBody(ref runtimes.runtime_data.For(i));
				}
			}

			public void ScheduleTimeInitialize(DopplerLateUpdateSystem componentSystem, ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}
		}

		[NoAlias]
		[BurstCompile]
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_Calculate_Pitch : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<Doppler.DopplerData>.Runtime runtime_data;
				}

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<Doppler.DopplerData> forParameter_data;

				public void ScheduleTimeInitialize(DopplerLateUpdateSystem componentSystem)
				{
					forParameter_data.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_data = forParameter_data.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public float3 listenerPos;

			public float3 listenerVel;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			internal void OriginalLambdaBody(ref Doppler.DopplerData data)
			{
				if (data.spatialBlend == 0)
				{
					data.finalPitch = data.desiredPitch;
					return;
				}
				float3 float5 = data.newPos - listenerPos;
				float num = 1f / math.max(math.length(float5), 1E-08f);
				float x = math.dot(listenerVel, float5) * num;
				float x2 = math.dot(data.velocity, float5) * num;
				x = math.max(x, -339.999f);
				x2 = math.max(x2, -339.999f);
				float end = ((340f + x) / (340f + x2) - 1f) * 1f + 1f;
				end = math.lerp(1f, end, (float)(int)data.spatialBlend / 255f);
				float num2 = data.desiredPitch * end;
				if (math.abs(num2 / data.finalPitch - 1f) > 0.001f)
				{
					data.finalPitch = num2;
				}
				else if (data.skipFrames == 0)
				{
					data.skipFrames = 1;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				listenerPos = displayClass.listenerPos;
				listenerVel = displayClass.listenerVel;
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
					OriginalLambdaBody(ref runtimes.runtime_data.For(i));
				}
			}

			public void ScheduleTimeInitialize(DopplerLateUpdateSystem componentSystem, ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}
		}

		private const float PITCH_RATIO_THRESHOLD = 0.001f;

		private EntityQuery transformQuery;

		private EntityQuery skipQuery;

		private EntityQuery _003C_003ECopy_And_Apply_Data_entityQuery;

		private ProfilerMarker _003C_003ECopy_And_Apply_Data_profilerMarker;

		private EntityQuery _003C_003ECalculate_Velocity_entityQuery;

		private EntityQuery _003C_003ECalculate_Pitch_entityQuery;

		protected override void OnCreate()
		{
			transformQuery = GetEntityQuery(ComponentType.ReadOnly<Transform>(), ComponentType.ReadWrite<Doppler.DopplerData>(), ComponentType.ReadOnly<Doppler.DopplerUpdateInLateUpdateTag>());
			skipQuery = GetEntityQuery(ComponentType.ReadOnly<Doppler.DopplerPauseUpdate>());
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass4_0 displayClass = default(_003C_003Ec__DisplayClass4_0);
			if (!SingletonBehaviour<ADopplerListener>.Instance || skipQuery.CalculateEntityCount() != 0)
			{
				return;
			}
			float deltaTime = UnityEngine.Time.deltaTime;
			displayClass.invTime = 1f / deltaTime;
			if (Mathf.Approximately(deltaTime, 0f) || float.IsInfinity(displayClass.invTime))
			{
				return;
			}
			displayClass.shouldSkipVelocity = SingletonBehaviour<DopplerStopRequests>.Instance.SkipFramesLate > 0;
			if (displayClass.shouldSkipVelocity)
			{
				SingletonBehaviour<DopplerStopRequests>.Instance.SkipFramesLate--;
			}
			displayClass.shouldSkipVelocity |= SingletonBehaviour<DopplerStopRequests>.Instance.SkipBlocked;
			ADopplerListener instance = SingletonBehaviour<ADopplerListener>.Instance;
			displayClass.listenerPos = instance.GetPosition();
			if (instance.UpdateMode == Doppler.UpdateMode.LateUpdate)
			{
				if (!displayClass.shouldSkipVelocity)
				{
					instance.velocity = (displayClass.listenerPos - instance.oldPosition) * displayClass.invTime;
				}
				instance.oldPosition = displayClass.listenerPos;
			}
			_ = base.Entities;
			_003C_003Ec__DisplayClass_Copy_And_Apply_Data jobData = default(_003C_003Ec__DisplayClass_Copy_And_Apply_Data);
			jobData.ScheduleTimeInitialize(this);
			CompleteDependency();
			EntityQuery query = _003C_003ECopy_And_Apply_Data_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Copy_And_Apply_Data.s_RunWithoutJobSystemDelegateFieldNoBurst;
			_003C_003ECopy_And_Apply_Data_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
			}
			finally
			{
				_003C_003ECopy_And_Apply_Data_profilerMarker.End();
			}
			JobHandle jobhandle;
			NativeArray<Entity> entities = transformQuery.ToEntityArrayAsync(Allocator.TempJob, out jobhandle);
			TransformAccessArray transformAccessArray = transformQuery.GetTransformAccessArray();
			ComponentDataFromEntity<Doppler.DopplerData> componentDataFromEntity = GetComponentDataFromEntity<Doppler.DopplerData>();
			base.Dependency = new DopplerCopyPositionJob
			{
				entities = entities,
				dopplerDataFromEntity = componentDataFromEntity
			}.Schedule(transformAccessArray, jobhandle);
			_ = base.Entities;
			JobHandle dependency = base.Dependency;
			_003C_003Ec__DisplayClass_Calculate_Velocity jobData2 = default(_003C_003Ec__DisplayClass_Calculate_Velocity);
			jobData2.ScheduleTimeInitialize(this, ref displayClass);
			dependency = JobChunkExtensions.ScheduleParallel(jobData2, _003C_003ECalculate_Velocity_entityQuery, dependency);
			base.Dependency = dependency;
			displayClass.listenerVel = instance.velocity;
			_ = base.Entities;
			JobHandle dependency2 = base.Dependency;
			_003C_003Ec__DisplayClass_Calculate_Pitch jobData3 = default(_003C_003Ec__DisplayClass_Calculate_Pitch);
			jobData3.ScheduleTimeInitialize(this, ref displayClass);
			dependency2 = JobChunkExtensions.ScheduleParallel(jobData3, _003C_003ECalculate_Pitch_entityQuery, dependency2);
			base.Dependency = dependency2;
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003ECopy_And_Apply_Data_entityQuery = _003C_003EGetEntityQuery_ForCopy_And_Apply_Data_From(this);
			_003C_003Ec__DisplayClass_Copy_And_Apply_Data.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_Copy_And_Apply_Data.RunWithoutJobSystem;
			_003C_003ECopy_And_Apply_Data_profilerMarker = new ProfilerMarker("Copy_And_Apply_Data");
			_003C_003ECalculate_Velocity_entityQuery = _003C_003EGetEntityQuery_ForCalculate_Velocity_From(this);
			_003C_003ECalculate_Pitch_entityQuery = _003C_003EGetEntityQuery_ForCalculate_Pitch_From(this);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCopy_And_Apply_Data_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadWrite<Doppler>(),
				ComponentType.ReadWrite<Doppler.DopplerData>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCalculate_Velocity_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadOnly<Doppler.DopplerUpdateInLateUpdateTag>(),
				ComponentType.ReadWrite<Doppler.DopplerData>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCalculate_Pitch_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<Doppler.DopplerData>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
