#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class GrantMoneyAfterDuration : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public float profit;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity desk, in CTakesDuration duration, in CPosition pos, in CGrantMoneyAfterDuration reward)
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
					public LambdaParameterValueProvider_Entity.Runtime runtime_desk;

					public LambdaParameterValueProvider_IComponentData<CTakesDuration>.Runtime runtime_duration;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;

					public LambdaParameterValueProvider_IComponentData<CGrantMoneyAfterDuration>.Runtime runtime_reward;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_desk;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CTakesDuration> forParameter_duration;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CGrantMoneyAfterDuration> forParameter_reward;

				public void ScheduleTimeInitialize(GrantMoneyAfterDuration componentSystem)
				{
					forParameter_desk.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_duration.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_reward.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_desk = forParameter_desk.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_duration = forParameter_duration.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_reward = forParameter_reward.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public float profit;

			public EntityCommandBuffer ecb;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity desk, in CTakesDuration duration, in CPosition pos, in CGrantMoneyAfterDuration reward)
			{
				if (duration.Active && !(duration.Remaining > 0f) && reward.Amount >= 0)
				{
					profit += reward.Amount;
					Entity e = ecb.CreateEntity();
					ecb.AddComponent(e, new CMoneyPopup
					{
						Change = reward.Amount
					});
					ecb.AddComponent(e, new CPosition(pos));
					ecb.AddComponent(e, new CLifetime(1f));
					ecb.AddComponent(e, new CRequiresView
					{
						Type = ViewType.MoneyPopup
					});
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				profit = displayClass.profit;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass.profit = profit;
				displayClass.ecb = ecb;
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
					OriginalLambdaBody(runtimes.runtime_desk.For(i), in runtimes.runtime_duration.For(i), in runtimes.runtime_pos.For(i), in runtimes.runtime_reward.For(i));
				}
			}

			public void ScheduleTimeInitialize(GrantMoneyAfterDuration componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SMoney_38;

		private EntityQuery _SingletonEntityQuery_SMoney_39;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
			{
				ecb = GetCommandBuffer(ECB.End),
				profit = 0f
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
			if (displayClass.profit > 0f)
			{
				_SingletonEntityQuery_SMoney_39.SetSingleton((SMoney)(_SingletonEntityQuery_SMoney_38.GetSingleton<SMoney>().Amount + displayClass.profit.ProbabilisticRound()));
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_SingletonEntityQuery_SMoney_38 = GetEntityQuery(ComponentType.ReadOnly<SMoney>());
			_SingletonEntityQuery_SMoney_39 = GetEntityQuery(ComponentType.ReadWrite<SMoney>());
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[3]
			{
				ComponentType.ReadOnly<CTakesDuration>(),
				ComponentType.ReadOnly<CPosition>(),
				ComponentType.ReadOnly<CGrantMoneyAfterDuration>()
			};
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CPreventUse>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
