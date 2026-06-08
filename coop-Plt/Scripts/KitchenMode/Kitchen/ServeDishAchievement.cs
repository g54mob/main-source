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
using WebSocketSharp;

namespace Kitchen
{
	[UpdateInGroup(typeof(UpdateCustomerStatesGroup))]
	[UpdateBefore(typeof(GroupHandleAwaitingOrder))]
	public class ServeDishAchievement : AchievementManager
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_DynamicBuffer<CWaitingForItem>.Runtime runtime_waiting;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CWaitingForItem> forParameter_waiting;

				public void ScheduleTimeInitialize(ServeDishAchievement componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_waiting.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_waiting = forParameter_waiting.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public ServeDishAchievement hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			public void OriginalLambdaBody(Entity e, [In] ref DynamicBuffer<CWaitingForItem> waiting)
			{
				hostInstance._003COnUpdate_003Eb__7_0(e, in waiting);
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
					Entity e = runtimes.runtime_e.For(i);
					DynamicBuffer<CWaitingForItem> waiting = runtimes.runtime_waiting.For(i);
					OriginalLambdaBody(e, ref waiting);
				}
			}

			public void ScheduleTimeInitialize(ServeDishAchievement componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				hostInstance = componentSystem;
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		protected string AchievementIdentifier = string.Empty;

		protected Dictionary<string, float> LastAchieveTimes = new Dictionary<string, float>();

		private List<string> Unlocks = new List<string>();

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override string Identifier => AchievementIdentifier;

		protected override bool SkipRateLimit => true;

		protected override void OnUpdate()
		{
			Unlocks.Clear();
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
			foreach (string unlock in Unlocks)
			{
				UnlockDish(unlock);
			}
		}

		public void UnlockDish(string id)
		{
			if (!LastAchieveTimes.TryGetValue(id, out var value) || !(value < base.Time.TotalTime + 5f))
			{
				LastAchieveTimes[id] = base.Time.TotalTime;
				Unlock(id);
			}
		}

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__7_0(Entity e, in DynamicBuffer<CWaitingForItem> waiting)
		{
			foreach (CWaitingForItem item in waiting)
			{
				if (item.Satisfied && base.Data.TryGet<Dish>(item.SourceMenuItem, out var output) && !output.AchievementName.IsNullOrEmpty())
				{
					Unlocks.Add(output.AchievementName);
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadOnly<CWaitingForItem>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
