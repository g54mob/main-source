#define ENABLE_PROFILER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	[UpdateBefore(typeof(AddNewViews))]
	public class MaintainViewBounds : BurstIncrementalViewSystemBase<MaintainInViewData>
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

					public LambdaParameterValueProvider_IComponentData<CMaintainInView>.Runtime runtime_maintain;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CMaintainInView> forParameter_maintain;

				public void ScheduleTimeInitialize(MaintainViewBounds componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_maintain.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_maintain = forParameter_maintain.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public MaintainViewBounds hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			public void OriginalLambdaBody(Entity e, [In] ref CLinkedView linked_view, [In] ref CMaintainInView maintain)
			{
				hostInstance._003CPopulateNewViewUpdates_003Eb__5_0(e, in linked_view, in maintain);
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_linked_view.For(i), ref runtimes.runtime_maintain.For(i));
				}
			}

			public void ScheduleTimeInitialize(MaintainViewBounds componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				hostInstance = componentSystem;
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private HashSet<MaintainInViewData> MaintainCache;

		private HashSet<MaintainInViewData> MaintainTemp;

		private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker;

		protected override MessageType MessageType => MessageType.MaintainInBounds;

		protected override void Initialise()
		{
			base.Initialise();
			MaintainCache = new HashSet<MaintainInViewData>();
			MaintainTemp = new HashSet<MaintainInViewData>();
		}

		protected override void PopulateNewViewUpdates(BurstContext bctx)
		{
			MaintainTemp.Clear();
			_ = base.Entities;
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0);
			jobData.ScheduleTimeInitialize(this);
			CompleteDependency();
			EntityQuery query = _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst;
			_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, s_RunWithoutJobSystemDelegateFieldNoBurst);
			}
			finally
			{
				_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker.End();
			}
			foreach (MaintainInViewData item in MaintainTemp)
			{
				if (!MaintainCache.Contains(item))
				{
					MaintainInViewData view_data = item;
					view_data.ShouldMaintain = true;
					bctx.ProposeUpdate(item.View, view_data);
				}
			}
			foreach (MaintainInViewData item2 in MaintainCache)
			{
				if (!MaintainTemp.Contains(item2))
				{
					MaintainInViewData view_data2 = item2;
					view_data2.ShouldMaintain = false;
					bctx.ProposeUpdate(item2.View, view_data2);
				}
			}
			HashSet<MaintainInViewData> maintainTemp = MaintainTemp;
			HashSet<MaintainInViewData> maintainCache = MaintainCache;
			MaintainCache = maintainTemp;
			MaintainTemp = maintainCache;
		}

		[CompilerGenerated]
		private void _003CPopulateNewViewUpdates_003Eb__5_0(Entity e, in CLinkedView linked_view, in CMaintainInView maintain)
		{
			MaintainTemp.Add(new MaintainInViewData
			{
				View = linked_view,
				Radius = maintain.Radius + 0.5f
			});
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem;
			_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker = new ProfilerMarker("PopulateNewViewUpdates_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CLinkedView>(),
				ComponentType.ReadOnly<CMaintainInView>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
