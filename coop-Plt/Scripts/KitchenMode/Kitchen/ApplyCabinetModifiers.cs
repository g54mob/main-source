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
	[UpdateInGroup(typeof(ApplyEffectsGroup))]
	public class ApplyCabinetModifiers : GameSystemBase
	{
		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_ent;

					public LambdaParameterValueProvider_IComponentData<CCabinetModifier>.Runtime runtime_modifier;

					public LambdaParameterValueProvider_DynamicBuffer<CAffectedBy>.Runtime runtime_affected_by;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_ent;

				private LambdaParameterValueProvider_IComponentData<CCabinetModifier> forParameter_modifier;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CAffectedBy> forParameter_affected_by;

				public void ScheduleTimeInitialize(ApplyCabinetModifiers componentSystem)
				{
					forParameter_ent.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_modifier.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_affected_by.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_ent = forParameter_ent.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_modifier = forParameter_modifier.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_affected_by = forParameter_affected_by.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public ApplyCabinetModifiers hostInstance;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			public void OriginalLambdaBody(Entity ent, ref CCabinetModifier modifier, [In] ref DynamicBuffer<CAffectedBy> affected_by)
			{
				hostInstance._003COnUpdate_003Eb__0_0(ent, ref modifier, in affected_by);
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
					Entity ent = runtimes.runtime_ent.For(i);
					ref CCabinetModifier modifier = ref runtimes.runtime_modifier.For(i);
					DynamicBuffer<CAffectedBy> affected_by = runtimes.runtime_affected_by.For(i);
					OriginalLambdaBody(ent, ref modifier, ref affected_by);
				}
			}

			public void ScheduleTimeInitialize(ApplyCabinetModifiers componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				hostInstance = componentSystem;
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
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
		}

		[CompilerGenerated]
		private void _003COnUpdate_003Eb__0_0(Entity ent, ref CCabinetModifier modifier, in DynamicBuffer<CAffectedBy> affected_by)
		{
			modifier.Reset();
			foreach (CAffectedBy item in affected_by)
			{
				if (HasComponent<CAppliesEffect>(item) && GetComponent<CAppliesEffect>(item).IsActive && HasComponent<CCabinetModifier>(item))
				{
					CCabinetModifier component = GetComponent<CCabinetModifier>(item);
					modifier.Combine(component);
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
			entityQueryDesc.All = new ComponentType[2]
			{
				ComponentType.ReadWrite<CCabinetModifier>(),
				ComponentType.ReadOnly<CAffectedBy>()
			};
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CAppliesEffect>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
