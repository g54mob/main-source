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
	public class ApplyItemProcesses : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass1_0
		{
			public ApplyItemProcesses _003C_003E4__this;

			public EntityCommandBuffer ecb;

			public float dt;

			internal void _003COnUpdate_003Eb__1(Entity e, in CItem item)
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

					public LambdaParameterValueProvider_IComponentData<CItemUndergoingProcess>.Runtime runtime_process;

					public LambdaParameterValueProvider_IComponentData<CItem>.Runtime runtime_item;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CItemUndergoingProcess> forParameter_process;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CItem> forParameter_item;

				public void ScheduleTimeInitialize(ApplyItemProcesses componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_process.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_item.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_process = forParameter_process.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_item = forParameter_item.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CItemUndergoingProcess process, in CItem item)
			{
				process.CurrentChange = 0f;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_process.For(i), in runtimes.runtime_item.For(i));
				}
			}

			public void ScheduleTimeInitialize(ApplyItemProcesses componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CItem>.Runtime runtime_item;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CItem> forParameter_item;

				public void ScheduleTimeInitialize(ApplyItemProcesses componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_item.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_item = forParameter_item.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public ApplyItemProcesses _003C_003E4__this;

			public EntityCommandBuffer ecb;

			public float dt;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CItem item)
			{
				_003C_003E4__this.Run(ecb, dt, e, item);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				ecb = displayClass.ecb;
				dt = displayClass.dt;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.ecb = ecb;
				displayClass.dt = dt;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_item.For(i));
				}
			}

			public void ScheduleTimeInitialize(ApplyItemProcesses componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		private EntityQuery _003C_003EOnUpdate_LambdaJob1_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob1_profilerMarker;

		private void Run(EntityCommandBuffer ecb, float dt, Entity e, CItem item)
		{
			if (item.IsPartial)
			{
				return;
			}
			Entity entity = default(Entity);
			CStoredBy component2;
			if (base.EntityManager.RequireComponent<CHeldBy>(e, out var component) && component.Holder != default(Entity))
			{
				entity = component;
			}
			else if (base.EntityManager.RequireComponent<CStoredBy>(e, out component2))
			{
				entity = component2;
			}
			if (!base.EntityManager.RequireComponent<CAppliance>(entity, out var component3) || HasComponent<CIsInactive>(entity) || HasComponent<CPreventUse>(entity))
			{
				return;
			}
			ApplianceProcessPair process;
			bool relevantProcess = GameData.Main.ProcessesView.GetRelevantProcess(item, component3, out process);
			CItemUndergoingProcess component4 = default(CItemUndergoingProcess);
			if (HasComponent<CItemUndergoingProcess>(e))
			{
				component4 = GetComponent<CItemUndergoingProcess>(e);
			}
			Entity entity2 = default(Entity);
			if (!RequireBuffer(entity, out DynamicBuffer<CBeingActedOnBy> comp))
			{
				return;
			}
			float num = 0f;
			bool flag = false;
			foreach (CBeingActedOnBy item2 in comp)
			{
				if (HasComponent<CIsInteractor>(item2.Interactor) && GetComponent<CIsInteractor>(item2.Interactor).Mode != InteractionMode.Items)
				{
					continue;
				}
				CAutomatedInteractorProcessRestriction comp5;
				if (!Require<CAutomatedInteractor>(item2.Interactor, out CAutomatedInteractor comp2))
				{
					num = ((component4.Process == 0 || !Require<CToolUser>(item2.Interactor, out CToolUser comp3)) ? (num + 1f) : ((!Require<CProcessTool>(comp3.CurrentTool, out CProcessTool comp4) || comp4.Process != component4.Process) ? (num + 1f) : (num + comp4.Factor)));
				}
				else if (comp2.TransferOnly)
				{
					if (!component4.IsBeingSplit && component4.Process != 0)
					{
						continue;
					}
					flag = true;
				}
				else if (Require<CAutomatedInteractorProcessRestriction>(item2.Interactor, out comp5))
				{
					if (component4.Process != 0)
					{
						if (comp5.Process != component4.Process)
						{
							continue;
						}
						num += 1f;
					}
					else
					{
						if (comp5.Process != process.Process)
						{
							continue;
						}
						num += 1f;
					}
				}
				else
				{
					num += 1f;
				}
				if (entity2 == default(Entity) || component4.Actor == item2.Interactor)
				{
					entity2 = item2.Interactor;
				}
			}
			float num2 = 1f;
			bool flag2 = false;
			Entity appliance = entity;
			bool flag3 = flag && num == 0f;
			CSplittableItem component6;
			if (relevantProcess && (!HasComponent<CNoBadProcesses>(entity) || !process.IsBad) && ((entity2 != default(Entity) && !flag3) || process.IsAutomatic))
			{
				flag2 = true;
				if (HasComponent<CAffectedBy.Marker>(entity))
				{
					foreach (CAffectedBy item3 in GetBuffer<CAffectedBy>(entity))
					{
						if (HasComponent<CAppliesEffect>(item3) && GetComponent<CAppliesEffect>(item3).IsActive && HasComponent<CApplianceSpeedModifier>(item3))
						{
							CApplianceSpeedModifier component5 = GetComponent<CApplianceSpeedModifier>(item3);
							if (component5.AffectsAllProcesses || component5.Process == process.Process)
							{
								num2 *= 1f + (process.IsBad ? component5.BadSpeed : component5.Speed);
							}
						}
					}
				}
			}
			else if (base.EntityManager.RequireComponent<CSplittableItem>(e, out component6) && component6.RemainingCount > 0 && !component6.AllowMergeSplit)
			{
				if (entity2 != default(Entity))
				{
					flag2 = true;
					appliance = default(Entity);
					process = new ApplianceProcessPair(-1, is_automatic: false, component6.SplitSpeed, is_bad: false);
					if (flag3)
					{
						num = 1f;
					}
				}
				else
				{
					flag2 = false;
					if (HasComponent<CItemUndergoingProcess>(e))
					{
						ecb.RemoveComponent<CItemUndergoingProcess>(e);
					}
				}
			}
			if (flag2)
			{
				if (!HasComponent<CItemUndergoingProcess>(e))
				{
					ecb.AddComponent<CItemUndergoingProcess>(e);
				}
				bool flag4 = Has<SCheatInstantProcesses>();
				bool num3 = Has<SCheatNoBadProcesses>();
				bool flag5 = Has<SCheatNoProcesses>();
				float num4 = process.Speed * num2 * (process.IsAutomatic ? 1f : num) * (float)((!flag4) ? 1 : 10);
				if (num3 && process.IsBad)
				{
					num4 = 0f;
				}
				if (flag5)
				{
					num4 = 0f;
				}
				float num5 = dt * num4;
				if (component4.Process == process.Process)
				{
					component4.IsBad = process.IsBad;
					component4.Progress = Mathf.Clamp01(component4.Progress + num5);
					component4.Actor = (process.IsAutomatic ? default(Entity) : entity2);
					component4.Appliance = appliance;
					component4.IsAutomatic = process.IsAutomatic;
					component4.CurrentChange = num4;
					ecb.SetComponent(e, component4);
				}
				else
				{
					ecb.SetComponent(e, new CItemUndergoingProcess
					{
						Process = process.Process,
						Progress = num5,
						IsBad = process.IsBad,
						Actor = entity2,
						Appliance = appliance,
						IsAutomatic = process.IsAutomatic,
						CurrentChange = num4
					});
				}
			}
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
			{
				_003C_003E4__this = this,
				ecb = new EntityCommandBuffer(Allocator.TempJob),
				dt = base.Time.DeltaTime
			};
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
			_ = base.Entities;
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 jobData2 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1);
			jobData2.ScheduleTimeInitialize(this, ref displayClass);
			CompleteDependency();
			EntityQuery query2 = _003C_003EOnUpdate_LambdaJob1_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst2 = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst;
			_003C_003EOnUpdate_LambdaJob1_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData2, query2, s_RunWithoutJobSystemDelegateFieldNoBurst2);
			}
			finally
			{
				_003C_003EOnUpdate_LambdaJob1_profilerMarker.End();
			}
			jobData2.WriteToDisplayClass(ref displayClass);
			displayClass.ecb.Playback(base.EntityManager);
			displayClass.ecb.Dispose();
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_003C_003EOnUpdate_LambdaJob1_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob1_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob1");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadWrite<CItemUndergoingProcess>(),
				ComponentType.ReadOnly<CItem>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadOnly<CItem>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
