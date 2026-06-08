#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class DeskIterateDiscount : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass1_0
		{
			public DeskIterateDiscount _003C_003E4__this;

			public float time;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CApplianceDeskIterate desk, ref CGrantsShopDiscount discount)
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
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CApplianceDeskIterate>.Runtime runtime_desk;

					public LambdaParameterValueProvider_IComponentData<CGrantsShopDiscount>.Runtime runtime_discount;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CApplianceDeskIterate> forParameter_desk;

				private LambdaParameterValueProvider_IComponentData<CGrantsShopDiscount> forParameter_discount;

				public void ScheduleTimeInitialize(DeskIterateDiscount componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_desk.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_discount.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_desk = forParameter_desk.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_discount = forParameter_discount.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public DeskIterateDiscount _003C_003E4__this;

			public float time;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CApplianceDeskIterate desk, ref CGrantsShopDiscount discount)
			{
				if (desk.RequestUpdate)
				{
					desk.RequestUpdate = false;
					int num = Random.Range(0, _003C_003E4__this.Discounts.Length);
					discount.Amount = _003C_003E4__this.Discounts[num] / 100f;
					desk.AverageTime = 15f - (float)num;
					desk.NextUpdateTime = time + (0.75f + 0.5f * Random.value) * desk.AverageTime;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				time = displayClass.time;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.time = time;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_desk.For(i), ref runtimes.runtime_discount.For(i));
				}
			}

			public void ScheduleTimeInitialize(DeskIterateDiscount componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		public readonly float[] Discounts = new float[11]
		{
			1f, 2f, 3f, 4f, 5f, 6f, 7f, 8f, 9f, 10f,
			20f
		};

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
			{
				_003C_003E4__this = this,
				time = base.Time.TotalTime
			};
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
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadWrite<CApplianceDeskIterate>(),
				ComponentType.ReadWrite<CGrantsShopDiscount>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
