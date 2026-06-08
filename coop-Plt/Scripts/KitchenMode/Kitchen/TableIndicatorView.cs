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
	public class TableIndicatorView : UpdatableObjectView<TableIndicatorView.ViewData>
	{
		public class UpdateView : IncrementalViewSystemBase<ViewData>
		{
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

						public LambdaParameterValueProvider_IComponentData<CTableSetIndicator>.Runtime runtime_indicator;

						public LambdaParameterValueProvider_IComponentData<CIndicator>.Runtime runtime_table_set;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CTableSetIndicator> forParameter_indicator;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CIndicator> forParameter_table_set;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_indicator.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_table_set.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_indicator = forParameter_indicator.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_table_set = forParameter_table_set.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [In] ref CLinkedView linked_view, [In] ref CTableSetIndicator indicator, [In] ref CIndicator table_set)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, in linked_view, in indicator, in table_set);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_linked_view.For(i), ref runtimes.runtime_indicator.For(i), ref runtimes.runtime_table_set.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem)
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CTableSetIndicator indicator, in CIndicator table_set)
			{
				ItemList effectors = default(ItemList);
				if (RequireBuffer(table_set.Source, out DynamicBuffer<CTableAffectedBy> comp))
				{
					foreach (CTableAffectedBy item in comp)
					{
						if (item.EffectRepresentation != 0)
						{
							effectors.Add(item.EffectRepresentation);
						}
					}
				}
				SendUpdate(linked_view, new ViewData
				{
					Count = indicator.Count,
					Decorations = indicator.Decoration,
					IsBeingLookedAt = indicator.InteractionTarget,
					Effectors = effectors
				});
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
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CTableSetIndicator>(),
					ComponentType.ReadOnly<CIndicator>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int Count;

			[Key(1)]
			public DecorationValues Decorations;

			[Key(2)]
			public bool IsBeingLookedAt;

			[Key(3)]
			public ItemList Effectors;

			public bool IsChangedFrom(ViewData check)
			{
				if (Count != check.Count || Decorations.IsChangedFrom(check.Decorations) || IsBeingLookedAt != check.IsBeingLookedAt)
				{
					return true;
				}
				return !Effectors.IsEquivalent(check.Effectors);
			}
		}

		[SerializeField]
		[Header("References")]
		private GameObject Container;

		[SerializeField]
		private Animator Animator;

		[SerializeField]
		private TextMeshPro CountText;

		[SerializeField]
		private IconSetElement Icons;

		[SerializeField]
		private IconSetElement IconsExpanded;

		[Header("State")]
		private ViewData Data;

		public override void Initialise()
		{
			base.Initialise();
			Animator.Update(0f);
		}

		private void Update()
		{
			bool flag = !ViewStateCommunicator.Main.HasPopup();
			if (Container.activeSelf != flag)
			{
				Container.SetActive(flag);
			}
		}

		protected override void UpdateData(ViewData view_data)
		{
			ViewData data = Data;
			Data = view_data;
			if (Data.Count != data.Count)
			{
				CountText.text = $"{Data.Count}";
			}
			if (view_data.IsBeingLookedAt == data.IsBeingLookedAt && view_data.Effectors.IsEquivalent(data.Effectors))
			{
				return;
			}
			IconsExpanded.Clear();
			Icons.Clear();
			IconSetElement iconSetElement = (view_data.IsBeingLookedAt ? IconsExpanded : Icons);
			int[] array = view_data.Effectors.AsArray();
			Array.Sort(array);
			int[] array2 = array;
			foreach (int id in array2)
			{
				if (GameData.Main.TryGet<EffectRepresentation>(id, out var output))
				{
					if (output.Name != "")
					{
						iconSetElement.Add(output.Icon, output.Name + ": " + output.Description);
					}
					else
					{
						iconSetElement.Add(output.Icon, output.Description ?? "");
					}
				}
			}
			if (!view_data.IsBeingLookedAt)
			{
				iconSetElement.Centre();
			}
		}
	}
}
