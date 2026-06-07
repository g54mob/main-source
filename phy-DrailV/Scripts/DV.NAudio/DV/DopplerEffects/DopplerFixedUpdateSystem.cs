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
using UnityEngine;
using UnityEngine.Jobs;

namespace DV.DopplerEffects
{
	[DisableAutoCreation]
	[AlwaysUpdateSystem]
	public class DopplerFixedUpdateSystem : SystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass3_0
		{
			public bool shouldSkipVelocity;

			public float invTime;

			internal void _003COnUpdate_003Eb__0(ref Doppler.DopplerData data)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}
		}

		[NoAlias]
		[BurstCompile]
		[Unity.Entities.DOTSCompilerGenerated]
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

				public void ScheduleTimeInitialize(DopplerFixedUpdateSystem componentSystem)
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

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
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

			public void ScheduleTimeInitialize(DopplerFixedUpdateSystem componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}
		}

		private EntityQuery transformQuery;

		private EntityQuery skipQuery;

		private EntityQuery _003C_003ECalculate_Velocity_entityQuery;

		protected override void OnCreate()
		{
			transformQuery = GetEntityQuery(ComponentType.ReadOnly<Transform>(), ComponentType.ReadWrite<Doppler.DopplerData>(), ComponentType.Exclude<Doppler.DopplerUpdateInLateUpdateTag>());
			skipQuery = GetEntityQuery(ComponentType.ReadOnly<Doppler.DopplerPauseUpdate>());
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass3_0 displayClass = default(_003C_003Ec__DisplayClass3_0);
			if (!SingletonBehaviour<ADopplerListener>.Instance || skipQuery.CalculateEntityCount() != 0)
			{
				return;
			}
			float fixedDeltaTime = UnityEngine.Time.fixedDeltaTime;
			displayClass.invTime = 1f / fixedDeltaTime;
			if (Mathf.Approximately(fixedDeltaTime, 0f) || float.IsInfinity(displayClass.invTime))
			{
				return;
			}
			displayClass.shouldSkipVelocity = SingletonBehaviour<DopplerStopRequests>.Instance.SkipFramesFixed > 0;
			if (displayClass.shouldSkipVelocity)
			{
				SingletonBehaviour<DopplerStopRequests>.Instance.SkipFramesFixed--;
			}
			displayClass.shouldSkipVelocity |= SingletonBehaviour<DopplerStopRequests>.Instance.SkipBlocked;
			ADopplerListener instance = SingletonBehaviour<ADopplerListener>.Instance;
			float3 position = instance.GetPosition();
			if (instance.UpdateMode == Doppler.UpdateMode.FixedUpdate)
			{
				if (!displayClass.shouldSkipVelocity)
				{
					instance.velocity = (position - instance.oldPosition) * displayClass.invTime;
				}
				instance.oldPosition = position;
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
			_003C_003Ec__DisplayClass_Calculate_Velocity jobData = default(_003C_003Ec__DisplayClass_Calculate_Velocity);
			jobData.ScheduleTimeInitialize(this, ref displayClass);
			dependency = JobChunkExtensions.ScheduleParallel(jobData, _003C_003ECalculate_Velocity_entityQuery, dependency);
			base.Dependency = dependency;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003ECalculate_Velocity_entityQuery = _003C_003EGetEntityQuery_ForCalculate_Velocity_From(this);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForCalculate_Velocity_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadOnly<Doppler.DopplerUpdateInFixedUpdateTag>(),
				ComponentType.ReadWrite<Doppler.DopplerData>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
