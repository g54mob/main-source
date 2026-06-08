#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kitchen.Modules;
using KitchenData;
using MessagePack;
using TMPro;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	public class ParametersDisplayView : UpdatableObjectView<ParametersDisplayView.ViewData>
	{
		public class UpdateView : GameViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass3_0
			{
				public UpdateView _003C_003E4__this;

				public bool is_night;

				public int standard_groups;

				public CreateCustomerSchedule.SAnalysis schedule;

				public DecorationValues deco_values;

				public int extra_groups;

				internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view)
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
						public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

						public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView _003C_003E4__this;

				public bool is_night;

				public int standard_groups;

				public CreateCustomerSchedule.SAnalysis schedule;

				public DecorationValues deco_values;

				public int extra_groups;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView linked_view)
				{
					_003C_003E4__this.SendUpdate(linked_view, new ViewData
					{
						IsNight = is_night,
						ExpectedGroupCount = standard_groups,
						MinimumGroupSize = schedule.SmallestGroupPossibility,
						MaximumGroupSize = schedule.LargestGroupPossibility,
						Decoration = deco_values,
						ExtraGroups = extra_groups
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					_003C_003E4__this = displayClass._003C_003E4__this;
					is_night = displayClass.is_night;
					standard_groups = displayClass.standard_groups;
					schedule = displayClass.schedule;
					deco_values = displayClass.deco_values;
					extra_groups = displayClass.extra_groups;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					displayClass._003C_003E4__this = _003C_003E4__this;
					displayClass.is_night = is_night;
					displayClass.standard_groups = standard_groups;
					displayClass.schedule = schedule;
					displayClass.deco_values = deco_values;
					displayClass.extra_groups = extra_groups;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_linked_view.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass3_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery Schedule;

			private EntityQuery ExtraSchedule;

			private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

			protected override void Initialise()
			{
				base.Initialise();
				Schedule = GetEntityQuery(typeof(CScheduledCustomer));
				ExtraSchedule = GetEntityQuery(typeof(CScheduledCustomer), typeof(CExtraScheduledCustomer));
				RequireSingletonForUpdate<SKitchenParameters>();
				RequireSingletonForUpdate<SDay>();
				RequireSingletonForUpdate<STime>();
			}

			protected override void OnUpdate()
			{
				_003C_003Ec__DisplayClass3_0 displayClass = default(_003C_003Ec__DisplayClass3_0);
				displayClass._003C_003E4__this = this;
				displayClass.schedule = GetOrCreate<CreateCustomerSchedule.SAnalysis>();
				displayClass.is_night = HasSingleton<SIsNightTime>();
				displayClass.extra_groups = ExtraSchedule.CalculateEntityCount();
				displayClass.standard_groups = Schedule.CalculateEntityCount() - displayClass.extra_groups;
				Entity entity = GetEntity<SGlobalStatusList>();
				if (!base.EntityManager.HasComponent<CDecorationScore>(entity))
				{
					base.EntityManager.AddBuffer<CDecorationScore>(entity);
				}
				DynamicBuffer<CDecorationScore> buffer = GetBuffer<CDecorationScore>(entity);
				displayClass.deco_values = default(DecorationValues);
				for (int i = 0; i < buffer.Length; i++)
				{
					CDecorationScore cDecorationScore = buffer[i];
					displayClass.deco_values[cDecorationScore] = cDecorationScore.Value;
				}
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
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CParametersDisplay>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int ExpectedGroupCount;

			[Key(1)]
			public int MinimumGroupSize;

			[Key(2)]
			public int MaximumGroupSize;

			[Key(3)]
			public bool IsNight;

			[Key(4)]
			public DecorationValues Decoration;

			[Key(5)]
			public int ExtraGroups;

			public bool IsChangedFrom(ViewData check)
			{
				if (IsNight == check.IsNight && ExpectedGroupCount == check.ExpectedGroupCount && MinimumGroupSize == check.MinimumGroupSize && MaximumGroupSize == check.MaximumGroupSize && ExtraGroups == check.ExtraGroups)
				{
					return Decoration.IsChangedFrom(check.Decoration);
				}
				return true;
			}
		}

		[Header("References")]
		[SerializeField]
		private TextMeshPro CustomersPerHour;

		[SerializeField]
		private TextMeshPro GroupSize;

		[SerializeField]
		private DecorationBonusSetElement BonusSetModule;

		public override void Initialise()
		{
			base.Initialise();
			CustomersPerHour.text = "1";
			GroupSize.text = "1-2";
		}

		protected override void UpdateData(ViewData view_data)
		{
			base.gameObject.SetActive(view_data.IsNight);
			if (view_data.ExtraGroups <= 0)
			{
				CustomersPerHour.text = $"{Mathf.Round(view_data.ExpectedGroupCount)}";
			}
			else
			{
				CustomersPerHour.text = $"{Mathf.Round(view_data.ExpectedGroupCount)} + {view_data.ExtraGroups}";
			}
			GroupSize.text = $"{view_data.MinimumGroupSize} - {view_data.MaximumGroupSize}";
			BonusSetModule.Set(view_data.Decoration);
		}
	}
}
