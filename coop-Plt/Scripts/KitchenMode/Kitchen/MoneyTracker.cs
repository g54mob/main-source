#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class MoneyTracker : GenericSystemBase
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			public int day;

			public EntityCommandBuffer ecb;

			public CMoneyTrackRecord record_value;

			internal bool _003COnUpdate_003Eb__0(CMoneyTrackRecord e)
			{
				return e.Day == day;
			}

			internal void _003COnUpdate_003Eb__1(Entity e, in CMoneyTrackEvent evt)
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

					public LambdaParameterValueProvider_IComponentData<CMoneyTrackEvent>.Runtime runtime_evt;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CMoneyTrackEvent> forParameter_evt;

				public void ScheduleTimeInitialize(MoneyTracker componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_evt.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_evt = forParameter_evt.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public EntityCommandBuffer ecb;

			public CMoneyTrackRecord record_value;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CMoneyTrackEvent evt)
			{
				ecb.AddComponent<CTracked>(e);
				record_value.Add(evt);
			}

			public void ReadFromDisplayClass(_003C_003Ec__DisplayClass6_0 displayClass)
			{
				ecb = displayClass.ecb;
				record_value = displayClass.record_value;
			}

			public void WriteToDisplayClass(_003C_003Ec__DisplayClass6_0 displayClass)
			{
				displayClass.ecb = ecb;
				displayClass.record_value = record_value;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_evt.For(i));
				}
			}

			public void ScheduleTimeInitialize(MoneyTracker componentSystem, _003C_003Ec__DisplayClass6_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery Records;

		private EntityQuery UpdateQuery;

		private EntityQuery OldEvents;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		public CMoneyTrackRecord GetRecord()
		{
			int day = GetOrDefault<SDay>().Day;
			return Records.FirstMatching((CMoneyTrackRecord e) => e.Day == day);
		}

		public static Entity AddEvent(EntityContext ctx, int identifier, int amount)
		{
			Entity entity = ctx.CreateEntity();
			ctx.Set(entity, new CMoneyTrackEvent
			{
				Identifier = identifier,
				Amount = amount
			});
			return entity;
		}

		protected override void Initialise()
		{
			base.Initialise();
			Records = GetEntityQuery(typeof(CMoneyTrackRecord));
			UpdateQuery = GetEntityQuery(new QueryHelper().All(typeof(CMoneyTrackEvent)).None(typeof(CTracked), typeof(CEventDependsOnGroup)));
			OldEvents = GetEntityQuery(new QueryHelper().All(typeof(CMoneyTrackEvent), typeof(CTracked)));
			RequireForUpdate(UpdateQuery);
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass6_0();
			CS_0024_003C_003E8__locals9.day = GetOrDefault<SDay>().Day;
			CS_0024_003C_003E8__locals9.ecb = GetCommandBuffer(ECB.End);
			Entity e = Records.FirstMatchingEntity((CMoneyTrackRecord cMoneyTrackRecord) => cMoneyTrackRecord.Day == CS_0024_003C_003E8__locals9.day);
			if (!Require<CMoneyTrackRecord>(e, out CS_0024_003C_003E8__locals9.record_value))
			{
				e = base.EntityManager.CreateEntity(typeof(CMoneyTrackRecord));
				CS_0024_003C_003E8__locals9.record_value.Day = CS_0024_003C_003E8__locals9.day;
			}
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0);
			jobData.ScheduleTimeInitialize(this, CS_0024_003C_003E8__locals9);
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
			jobData.WriteToDisplayClass(CS_0024_003C_003E8__locals9);
			Set(e, CS_0024_003C_003E8__locals9.record_value);
			base.EntityManager.DestroyEntity(OldEvents);
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
			entityQueryDesc.All = new ComponentType[1] { ComponentType.ReadOnly<CMoneyTrackEvent>() };
			entityQueryDesc.None = new ComponentType[2]
			{
				ComponentType.ReadWrite<CEventDependsOnGroup>(),
				ComponentType.ReadWrite<CTracked>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
