#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
using Kitchen.Modules;
using KitchenData;
using MessagePack;
using TMPro;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	public class CardSelectorView : UpdatableObjectView<CardSelectorView.ViewData>
	{
		public class UpdateView : IncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass1_0
			{
				public UpdateView _003C_003E4__this;

				public bool has_franchise_active;

				public DataObjectList cards;

				internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CFranchiseCardViewer pedestal)
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

						public LambdaParameterValueProvider_IComponentData<CFranchiseCardViewer>.Runtime runtime_pedestal;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CFranchiseCardViewer> forParameter_pedestal;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_pedestal.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_pedestal = forParameter_pedestal.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView _003C_003E4__this;

				public bool has_franchise_active;

				public DataObjectList cards;

				[NoAlias]
				[ReadOnly]
				private ComponentDataFromEntity<CBeingLookedAt> _ComponentDataFromEntity_CBeingLookedAt_0;

				[NoAlias]
				[ReadOnly]
				private ComponentDataFromEntity<CBeingGrabbed> _ComponentDataFromEntity_CBeingGrabbed_1;

				[NoAlias]
				[ReadOnly]
				private ComponentDataFromEntity<CBeingActedOn> _ComponentDataFromEntity_CBeingActedOn_2;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CFranchiseCardViewer pedestal)
				{
					bool flag = _ComponentDataFromEntity_CBeingLookedAt_0.HasComponent(entity) || _ComponentDataFromEntity_CBeingGrabbed_1.HasComponent(entity) || _ComponentDataFromEntity_CBeingActedOn_2.HasComponent(entity);
					_003C_003E4__this.SendUpdate(linked_view, new ViewData
					{
						CardID = ((has_franchise_active && flag) ? cards[pedestal.Index] : 0),
						CardIndex = pedestal.Index,
						CardCount = ((has_franchise_active && flag) ? cards.Count : 0),
						HasFranchise = has_franchise_active
					}, MessageType.SpecificViewUpdate);
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					_003C_003E4__this = displayClass._003C_003E4__this;
					has_franchise_active = displayClass.has_franchise_active;
					cards = displayClass.cards;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					displayClass._003C_003E4__this = _003C_003E4__this;
					displayClass.has_franchise_active = has_franchise_active;
					displayClass.cards = cards;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_pedestal.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
					_ComponentDataFromEntity_CBeingLookedAt_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CBeingLookedAt>(true);
					_ComponentDataFromEntity_CBeingGrabbed_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CBeingGrabbed>(true);
					_ComponentDataFromEntity_CBeingActedOn_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CBeingActedOn>(true);
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

			protected override void Initialise()
			{
				base.Initialise();
				RequireForUpdate(GetEntityQuery(typeof(CFranchiseCardViewer)));
			}

			protected override void OnUpdate()
			{
				_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
				{
					_003C_003E4__this = this
				};
				if (HasSingleton<SFranchiseSelector>())
				{
					SFranchiseSelector orCreate = GetOrCreate<SFranchiseSelector>();
					displayClass.has_franchise_active = base.EntityManager.HasComponent<CFranchiseItem>(orCreate.SelectedFranchise);
					displayClass.cards = DataObjectList.Empty;
					if (Require<CFranchiseItem>(orCreate.SelectedFranchise, out CFranchiseItem comp))
					{
						displayClass.cards = comp.Cards;
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
					ComponentType.ReadOnly<CFranchiseCardViewer>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int CardID;

			[Key(1)]
			public int CardIndex;

			[Key(2)]
			public int CardCount;

			[Key(3)]
			public bool HasFranchise;

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<CardSelectorView>();
			}

			public bool IsChangedFrom(ViewData check)
			{
				if (CardID == check.CardID && CardIndex == check.CardIndex && CardCount == check.CardCount)
				{
					return HasFranchise != check.HasFranchise;
				}
				return true;
			}
		}

		[Header("References")]
		[SerializeField]
		private TextMeshPro Label;

		[SerializeField]
		private UnlockCardElement Card;

		[SerializeField]
		private GameObject Container;

		[SerializeField]
		private InputPromptElement InputPrompt;

		protected override void UpdateData(ViewData data)
		{
			if (data.CardID == 0 || !GameData.Main.TryGet<ICard>(data.CardID, out var output, warn_if_fail: true))
			{
				Label.text = (data.HasFranchise ? base.Localisation["VIEW_CARDS"] : "");
				Container.SetActive(value: false);
				return;
			}
			Container.SetActive(value: true);
			Card.SetUnlock(output);
			Card.SetUIMode(is_ui_mode: false);
			if (Label != null)
			{
				Label.text = $"{data.CardIndex + 1}/{data.CardCount}";
			}
			if (InputPrompt != null)
			{
				InputPrompt.SetButtonForAll(Controls.Interact1);
			}
		}
	}
}
