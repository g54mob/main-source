#define ENABLE_PROFILER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class ActivateCraneModeViaPing : RestaurantSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass4_0
		{
			public float dt;

			public ActivateCraneModeViaPing _003C_003E4__this;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CActivatingCraneMode crane_mode, ref CBlockPing block_ping, in CInputData inputs)
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

					public LambdaParameterValueProvider_IComponentData<CActivatingCraneMode>.Runtime runtime_crane_mode;

					public LambdaParameterValueProvider_IComponentData<CBlockPing>.Runtime runtime_block_ping;

					public LambdaParameterValueProvider_IComponentData<CInputData>.Runtime runtime_inputs;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CActivatingCraneMode> forParameter_crane_mode;

				private LambdaParameterValueProvider_IComponentData<CBlockPing> forParameter_block_ping;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CInputData> forParameter_inputs;

				public void ScheduleTimeInitialize(ActivateCraneModeViaPing componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_crane_mode.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_block_ping.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_inputs.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_crane_mode = forParameter_crane_mode.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_block_ping = forParameter_block_ping.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_inputs = forParameter_inputs.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public float dt;

			public ActivateCraneModeViaPing _003C_003E4__this;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CActivatingCraneMode crane_mode, ref CBlockPing block_ping, in CInputData inputs)
			{
				if (crane_mode.IsDeactivated)
				{
					if (inputs.State.SecondaryAction2 == ButtonState.Released)
					{
						crane_mode.Reactivate();
					}
				}
				else if (inputs.State.SecondaryAction2 == ButtonState.Held)
				{
					crane_mode.Progress += dt;
				}
				else
				{
					crane_mode.Progress = 0f;
				}
				block_ping.IsEnablingCraneMode |= crane_mode.Progress > 0.3f;
				block_ping.IsEnablingCraneMode &= inputs.State.SecondaryAction2 != ButtonState.Up;
				if (crane_mode.IsComplete)
				{
					_003C_003E4__this.TogglingCraneMode.Add(e);
					crane_mode.Deactivate();
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				dt = displayClass.dt;
				_003C_003E4__this = displayClass._003C_003E4__this;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				displayClass.dt = dt;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_crane_mode.For(i), ref runtimes.runtime_block_ping.For(i), in runtimes.runtime_inputs.For(i));
				}
			}

			public void ScheduleTimeInitialize(ActivateCraneModeViaPing componentSystem, ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery PlayersWithoutCraneMode;

		private HashSet<Entity> TogglingCraneMode = new HashSet<Entity>();

		private EntityQuery Upgrade;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			PlayersWithoutCraneMode = GetEntityQuery(new QueryHelper().All(typeof(CPlayer), typeof(CInputData)).None(typeof(CActivatingCraneMode)));
			Upgrade = GetEntityQuery(typeof(CUpgradeAdvancedBuildMode));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass4_0 displayClass = new _003C_003Ec__DisplayClass4_0
			{
				_003C_003E4__this = this
			};
			bool flag = !Upgrade.IsEmpty;
			base.EntityManager.AddComponent<CActivatingCraneMode>(PlayersWithoutCraneMode);
			TogglingCraneMode.Clear();
			displayClass.dt = base.Time.DeltaTime;
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
			foreach (Entity item in TogglingCraneMode)
			{
				if (Has<CIsCraneMode>(item))
				{
					Unset<CIsCraneMode>(item);
				}
				else if (flag)
				{
					Set<CIsCraneMode>(item);
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
			{
				ComponentType.ReadWrite<CActivatingCraneMode>(),
				ComponentType.ReadWrite<CBlockPing>(),
				ComponentType.ReadOnly<CInputData>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
