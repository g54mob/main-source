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
	[UpdateInGroup(typeof(UpdateCustomerStatesGroup))]
	public class HalloweenStartFireWhenLeaving : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass1_0
		{
			public HalloweenStartFireWhenLeaving _003C_003E4__this;

			public EntityContext ctx;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, in CHalloweenOrder halloween, in CCustomerSettings settings, in CAssignedTable table, in CPosition pos)
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

					public LambdaParameterValueProvider_IComponentData<CHalloweenOrder>.Runtime runtime_halloween;

					public LambdaParameterValueProvider_IComponentData<CCustomerSettings>.Runtime runtime_settings;

					public LambdaParameterValueProvider_IComponentData<CAssignedTable>.Runtime runtime_table;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CHalloweenOrder> forParameter_halloween;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCustomerSettings> forParameter_settings;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CAssignedTable> forParameter_table;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				public void ScheduleTimeInitialize(HalloweenStartFireWhenLeaving componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_halloween.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_settings.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_table.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_halloween = forParameter_halloween.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_settings = forParameter_settings.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_table = forParameter_table.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public HalloweenStartFireWhenLeaving _003C_003E4__this;

			public EntityContext ctx;

			public EntityCommandBuffer ecb;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CHalloweenOrder halloween, in CCustomerSettings settings, in CAssignedTable table, in CPosition pos)
			{
				if (halloween.State != TrickTreatStates.TrickStartFire || !_003C_003E4__this.RequireBuffer(table.Table, out DynamicBuffer<CTableSetParts> comp))
				{
					return;
				}
				CEventIndicator.Request(ctx, pos, EventType.HalloweenTrick);
				foreach (CTableSetParts item in comp)
				{
					if (_003C_003E4__this.Has<CAppliance>(item))
					{
						ecb.AddComponent<CIsOnFire>(item);
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				ctx = displayClass.ctx;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.ctx = ctx;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_halloween.For(i), in runtimes.runtime_settings.For(i), in runtimes.runtime_table.For(i), in runtimes.runtime_pos.For(i));
				}
			}

			public void ScheduleTimeInitialize(HalloweenStartFireWhenLeaving componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
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

		protected override void Initialise()
		{
			base.Initialise();
			RequireForUpdate(GetEntityQuery(typeof(CGroupStartLeaving), typeof(CHalloweenOrder)));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass1_0 displayClass = default(_003C_003Ec__DisplayClass1_0);
			displayClass._003C_003E4__this = this;
			displayClass.ecb = GetCommandBuffer(ECB.StateChanges);
			displayClass.ctx = new EntityContext(base.EntityManager, displayClass.ecb);
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[5]
			{
				ComponentType.ReadOnly<CGroupStartLeaving>(),
				ComponentType.ReadOnly<CHalloweenOrder>(),
				ComponentType.ReadOnly<CCustomerSettings>(),
				ComponentType.ReadOnly<CAssignedTable>(),
				ComponentType.ReadOnly<CPosition>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
