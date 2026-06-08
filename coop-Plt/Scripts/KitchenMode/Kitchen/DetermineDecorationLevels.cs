#define ENABLE_PROFILER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class DetermineDecorationLevels : GameSystemBase
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_ent;

					public LambdaParameterValueProvider_IComponentData<CGivesDecoration>.Runtime runtime_decoration;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_ent;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CGivesDecoration> forParameter_decoration;

				public void ScheduleTimeInitialize(DetermineDecorationLevels componentSystem)
				{
					forParameter_ent.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_decoration.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_ent = forParameter_ent.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_decoration = forParameter_decoration.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public DetermineDecorationLevels hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			public void OriginalLambdaBody(Entity ent, [In] ref CGivesDecoration decoration)
			{
				hostInstance._003COnUpdate_003Eb__1_0(ent, in decoration);
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
					OriginalLambdaBody(runtimes.runtime_ent.For(i), ref runtimes.runtime_decoration.For(i));
				}
			}

			public void ScheduleTimeInitialize(DetermineDecorationLevels componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				hostInstance = componentSystem;
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private Dictionary<DecorationType, int> Scores = new Dictionary<DecorationType, int>();

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			Scores.Clear();
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			jobData.ScheduleTimeInitialize(this);
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
			DynamicBuffer<CDecorationScore> decorationValue = GetDecorationValue();
			decorationValue.Clear();
			foreach (KeyValuePair<DecorationType, int> score in Scores)
			{
				decorationValue.Add(new CDecorationScore
				{
					Theme = score.Key,
					Value = score.Value
				});
			}
		}

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__1_0(Entity ent, in CGivesDecoration decoration)
		{
			DecorationType[] types = DecorationValues.Types;
			foreach (DecorationType decorationType in types)
			{
				int num = decoration.DecorationValues[decorationType];
				if (num != 0)
				{
					int value = 0;
					Scores.TryGetValue(decorationType, out value);
					Scores[decorationType] = value + num;
				}
			}
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
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[1] { ComponentType.ReadOnly<CGivesDecoration>() };
			entityQueryDesc.None = new ComponentType[2]
			{
				ComponentType.ReadWrite<CHeldBy>(),
				ComponentType.ReadWrite<CDestroyApplianceAtDay>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
