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
	public class BringNextCustomerAfterDuration : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public bool should_accelerate;

			public Vector3 position;

			public int accelerator_id;

			internal void _003COnUpdate_003Eb__0(Entity desk, in CTakesDuration duration, in CAppliance app, in CPosition pos, in CAccelerateTimeAfterDuration accelerate)
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

					public LambdaParameterValueProvider_IComponentData<CAppliance>.Runtime runtime_app;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;

					public LambdaParameterValueProvider_IComponentData_Tag<CAccelerateTimeAfterDuration>.Runtime runtime_accelerate;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_desk;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CTakesDuration> forParameter_duration;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CAppliance> forParameter_app;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData_Tag<CAccelerateTimeAfterDuration> forParameter_accelerate;

				public void ScheduleTimeInitialize(BringNextCustomerAfterDuration componentSystem)
				{
					forParameter_desk.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_duration.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_app.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_accelerate.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_desk = forParameter_desk.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_duration = forParameter_duration.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_app = forParameter_app.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_accelerate = forParameter_accelerate.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public bool should_accelerate;

			public Vector3 position;

			public int accelerator_id;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity desk, in CTakesDuration duration, in CAppliance app, in CPosition pos, in CAccelerateTimeAfterDuration accelerate)
			{
				if (duration.Active && !(duration.Remaining > 0f))
				{
					should_accelerate = true;
					position = pos;
					accelerator_id = app;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				should_accelerate = displayClass.should_accelerate;
				position = displayClass.position;
				accelerator_id = displayClass.accelerator_id;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass.should_accelerate = should_accelerate;
				displayClass.position = position;
				displayClass.accelerator_id = accelerator_id;
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
					OriginalLambdaBody(runtimes.runtime_desk.For(i), in runtimes.runtime_duration.For(i), in runtimes.runtime_app.For(i), in runtimes.runtime_pos.For(i), runtimes.runtime_accelerate.For(i));
				}
			}

			public void ScheduleTimeInitialize(BringNextCustomerAfterDuration componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery ScheduledCustomers;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SMoney_36;

		private EntityQuery _SingletonEntityQuery_SMoney_37;

		protected override void Initialise()
		{
			base.Initialise();
			ScheduledCustomers = GetEntityQuery(typeof(CScheduledCustomer));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
			{
				should_accelerate = false,
				position = default(Vector3),
				accelerator_id = 0
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
			if (!displayClass.should_accelerate)
			{
				return;
			}
			CSoundEvent.Create(base.EntityManager, SoundEvent.BookingDeskRing);
			if (Has<SPracticeMode>())
			{
				base.EntityManager.CreateEntity(typeof(SpawnPracticeCats.CRequestNewPracticeCustomers));
				return;
			}
			STime orCreate = GetOrCreate<STime>();
			SDay orCreate2 = GetOrCreate<SDay>();
			using NativeArray<CScheduledCustomer> nativeArray = ScheduledCustomers.ToComponentDataArray<CScheduledCustomer>(Allocator.Temp);
			float num = 1f;
			foreach (CScheduledCustomer item in nativeArray)
			{
				if (!(item.TimeOfDay < orCreate.TimeOfDay) && item.TimeOfDay < num)
				{
					num = item.TimeOfDay;
				}
			}
			orCreate.SecondsSinceDayBegan = (orCreate.TimeOfDayUnbounded = (orCreate.TimeOfDay = Mathf.Max(num, orCreate.TimeOfDay))) * orCreate.DayLength;
			Set(orCreate);
			int num2 = 3 + orCreate2.Day / 2;
			if (num2 > 0)
			{
				CSoundEvent.Create(base.EntityManager, SoundEvent.ItemDelivered);
				EntityCommandBuffer commandBuffer = GetCommandBuffer(ECB.End);
				Entity e = commandBuffer.CreateEntity();
				commandBuffer.AddComponent(e, new CMoneyPopup
				{
					Change = num2
				});
				commandBuffer.AddComponent(e, new CPosition(displayClass.position));
				commandBuffer.AddComponent(e, new CLifetime(1f));
				commandBuffer.AddComponent(e, new CRequiresView
				{
					Type = ViewType.MoneyPopup
				});
				MoneyTracker.AddEvent(new EntityContext(base.EntityManager, commandBuffer), displayClass.accelerator_id, num2);
				_SingletonEntityQuery_SMoney_37.SetSingleton((SMoney)(_SingletonEntityQuery_SMoney_36.GetSingleton<SMoney>().Amount + num2));
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_SingletonEntityQuery_SMoney_36 = GetEntityQuery(ComponentType.ReadOnly<SMoney>());
			_SingletonEntityQuery_SMoney_37 = GetEntityQuery(ComponentType.ReadWrite<SMoney>());
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[4]
			{
				ComponentType.ReadOnly<CTakesDuration>(),
				ComponentType.ReadOnly<CAppliance>(),
				ComponentType.ReadOnly<CPosition>(),
				ComponentType.ReadOnly<CAccelerateTimeAfterDuration>()
			};
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CPreventUse>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
