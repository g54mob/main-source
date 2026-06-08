#define ENABLE_PROFILER
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
	public class AchievementCharcoalFactory : AchievementManager
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public bool is_achieved;

			public AchievementCharcoalFactory _003C_003E4__this;

			internal void _003COnUpdate_003Eb__0(Entity e, in CAppliance app, in DynamicBuffer<CAffectedBy> affected_by, in CItemHolder holder)
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

					public LambdaParameterValueProvider_IComponentData<CAppliance>.Runtime runtime_app;

					public LambdaParameterValueProvider_DynamicBuffer<CAffectedBy>.Runtime runtime_affected_by;

					public LambdaParameterValueProvider_IComponentData<CItemHolder>.Runtime runtime_holder;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CAppliance> forParameter_app;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CAffectedBy> forParameter_affected_by;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CItemHolder> forParameter_holder;

				public void ScheduleTimeInitialize(AchievementCharcoalFactory componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_app.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_affected_by.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_holder.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_app = forParameter_app.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_affected_by = forParameter_affected_by.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_holder = forParameter_holder.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public bool is_achieved;

			public AchievementCharcoalFactory _003C_003E4__this;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CAppliance app, in DynamicBuffer<CAffectedBy> affected_by, in CItemHolder holder)
			{
				if (is_achieved || app.ID != AssetReference.DangerHob || !_003C_003E4__this.Require<CItemUndergoingProcess>(holder.HeldItem, out CItemUndergoingProcess _))
				{
					return;
				}
				foreach (CAffectedBy item in affected_by)
				{
					if (_003C_003E4__this.Require<CAppliance>(item.Entity, out CAppliance comp2) && _003C_003E4__this.Require<CAppliesEffect>(item.Entity, out CAppliesEffect comp3) && comp3.IsActive && comp2.ID == AssetReference.GasOverride)
					{
						is_achieved = true;
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				is_achieved = displayClass.is_achieved;
				_003C_003E4__this = displayClass._003C_003E4__this;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass.is_achieved = is_achieved;
				displayClass._003C_003E4__this = _003C_003E4__this;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_app.For(i), runtimes.runtime_affected_by.For(i), in runtimes.runtime_holder.For(i));
				}
			}

			public void ScheduleTimeInitialize(AchievementCharcoalFactory componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
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

		protected override string Identifier => "CHARCOAL_FACTORY";

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
			{
				_003C_003E4__this = this,
				is_achieved = false
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
			if (displayClass.is_achieved)
			{
				Unlock();
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
			{
				ComponentType.ReadOnly<CAppliance>(),
				ComponentType.ReadOnly<CAffectedBy>(),
				ComponentType.ReadOnly<CItemHolder>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
