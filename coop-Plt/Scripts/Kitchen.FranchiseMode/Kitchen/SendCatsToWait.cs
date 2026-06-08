#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class SendCatsToWait : FranchiseSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass3_0
		{
			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CGroupMealPhase phase, ref CPatience patience, in CCustomerSettings settings, in DynamicBuffer<CGroupMember> group)
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

					public LambdaParameterValueProvider_IComponentData<CGroupMealPhase>.Runtime runtime_phase;

					public LambdaParameterValueProvider_IComponentData<CPatience>.Runtime runtime_patience;

					public LambdaParameterValueProvider_IComponentData<CCustomerSettings>.Runtime runtime_settings;

					public LambdaParameterValueProvider_DynamicBuffer<CGroupMember>.Runtime runtime_group;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CGroupMealPhase> forParameter_phase;

				private LambdaParameterValueProvider_IComponentData<CPatience> forParameter_patience;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCustomerSettings> forParameter_settings;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CGroupMember> forParameter_group;

				public void ScheduleTimeInitialize(SendCatsToWait componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_phase.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_patience.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_settings.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_group.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_phase = forParameter_phase.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_patience = forParameter_patience.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_settings = forParameter_settings.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_group = forParameter_group.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public EntityCommandBuffer ecb;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CGroupMealPhase phase, ref CPatience patience, in CCustomerSettings settings, in DynamicBuffer<CGroupMember> group)
			{
				phase.Phase = MenuPhase.Starter;
				patience = settings.NewPhase(PatienceReason.Queue);
				for (int i = 0; i < group.Length; i++)
				{
					CPosition cPosition = new Vector3(Random.Range(-3, 5), 0f, 0f);
					ecb.AddComponent(group[i], new CMoveToLocation
					{
						Location = cPosition,
						DesiredFacing = cPosition + Random.insideUnitCircle.normalized,
						StoppingDistance = 0.5f
					});
					ecb.RemoveComponent<CCustomerLeaving>(group[i]);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_phase.For(i), ref runtimes.runtime_patience.For(i), in runtimes.runtime_settings.For(i), runtimes.runtime_group.For(i));
				}
			}

			public void ScheduleTimeInitialize(SendCatsToWait componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery LeavingPets;

		private EntityQuery PetRequests;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			LeavingPets = GetEntityQuery(typeof(CGroupLeaving));
			PetRequests = GetEntityQuery(typeof(CWaitingForItem));
			RequireForUpdate(LeavingPets);
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass3_0 displayClass = new _003C_003Ec__DisplayClass3_0
			{
				ecb = GetCommandBuffer(ECB.End)
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
			base.EntityManager.AddComponent<CGroupWait>(LeavingPets);
			base.EntityManager.RemoveComponent<CGroupLeaving>(LeavingPets);
			base.EntityManager.RemoveComponent<CWaitingForItem>(PetRequests);
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
				ComponentType.ReadOnly<CGroupLeaving>(),
				ComponentType.ReadWrite<CGroupMealPhase>(),
				ComponentType.ReadWrite<CPatience>(),
				ComponentType.ReadOnly<CCustomerSettings>(),
				ComponentType.ReadOnly<CGroupMember>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
