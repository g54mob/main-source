#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
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
	public class NewsUIView : ResponsiveObjectView<NewsUIView.ViewData, NewsUIView.ResponseData>
	{
		public class UpdateView : ResponsiveViewSystemBase<ViewData, ResponseData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass0_0
			{
				public UpdateView _003C_003E4__this;

				public int reward;

				public NewsItemType type;

				public bool move_to_next_item;

				public bool move_to_prev_item;

				internal void _003COnUpdate_003Eb__0(Entity entity, in CNewsUIView info, in CLinkedView linked_view, in DynamicBuffer<CCapturedUserInput> input_users)
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

						public LambdaParameterValueProvider_IComponentData_Tag<CNewsUIView>.Runtime runtime_info;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						public LambdaParameterValueProvider_DynamicBuffer<CCapturedUserInput>.Runtime runtime_input_users;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData_Tag<CNewsUIView> forParameter_info;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_DynamicBuffer<CCapturedUserInput> forParameter_input_users;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_info.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_input_users.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_info = forParameter_info.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_input_users = forParameter_input_users.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView _003C_003E4__this;

				public int reward;

				public NewsItemType type;

				public bool move_to_next_item;

				public bool move_to_prev_item;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, in CNewsUIView info, in CLinkedView linked_view, in DynamicBuffer<CCapturedUserInput> input_users)
				{
					List<PlayerInputData> inputs = _003C_003E4__this.EntityManager.GatherInputs(input_users);
					_003C_003E4__this.Router.BroadcastUpdate(linked_view, new ViewData
					{
						Inputs = inputs,
						RewardID = reward,
						Type = type
					});
					ResponseData result = default(ResponseData);
					if (_003C_003E4__this.ApplyUpdates(linked_view.Identifier, delegate(ResponseData data)
					{
						result = data;
					}, only_final_update: true))
					{
						move_to_next_item |= result.RequestNextItem;
						move_to_prev_item |= result.RequestPrevItem;
					}
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					_003C_003E4__this = displayClass._003C_003E4__this;
					reward = displayClass.reward;
					type = displayClass.type;
					move_to_next_item = displayClass.move_to_next_item;
					move_to_prev_item = displayClass.move_to_prev_item;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					displayClass._003C_003E4__this = _003C_003E4__this;
					displayClass.reward = reward;
					displayClass.type = type;
					displayClass.move_to_next_item = move_to_next_item;
					displayClass.move_to_prev_item = move_to_prev_item;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_info.For(i), in runtimes.runtime_linked_view.For(i), runtimes.runtime_input_users.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
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

			protected override void OnUpdate()
			{
				_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
				{
					_003C_003E4__this = this,
					reward = 0,
					type = NewsItemType.Generic
				};
				if (TryGetSingletonEntity<CNewsItemActive>(out var value))
				{
					CNewsItem component = GetComponent<CNewsItem>(value);
					displayClass.reward = component.Reward;
					displayClass.type = component.Type;
				}
				displayClass.move_to_next_item = false;
				displayClass.move_to_prev_item = false;
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
				if (displayClass.move_to_prev_item)
				{
					Entity entity = base.EntityManager.CreateEntity(typeof(CRequestMoveNewsItem));
					base.EntityManager.SetComponentData(entity, new CRequestMoveNewsItem
					{
						IsRewind = true
					});
				}
				else if (displayClass.move_to_next_item)
				{
					base.EntityManager.CreateEntity(typeof(CRequestMoveNewsItem));
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
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CNewsUIView>(),
					ComponentType.ReadOnly<CCapturedUserInput>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public List<PlayerInputData> Inputs;

			[Key(1)]
			public int RewardID;

			[Key(2)]
			public NewsItemType Type;

			public bool IsChangedFrom(ViewData check)
			{
				return true;
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ResponseData : IResponseData, IViewResponseData
		{
			[Key(0)]
			public bool RequestNextItem;

			[Key(1)]
			public bool RequestPrevItem;
		}

		[SerializeField]
		[Header("References")]
		private TextMeshPro Title;

		[SerializeField]
		private TextMeshPro Description;

		[SerializeField]
		private InputPromptElement NextPromptElement;

		[SerializeField]
		private InputPromptElement PrevPromptElement;

		[Header("State")]
		private bool RequestNextItem;

		private bool RequestPrevItem;

		private int DisplayedRewardID = -1;

		private NewsItemType DisplayedRewardType;

		private float GracePeriodTimeout;

		public override bool HasStateUpdate(out IResponseData state)
		{
			if (RequestNextItem)
			{
				state = new ResponseData
				{
					RequestNextItem = true
				};
				RequestNextItem = false;
				return true;
			}
			if (RequestPrevItem)
			{
				state = new ResponseData
				{
					RequestPrevItem = true
				};
				RequestPrevItem = false;
				return true;
			}
			state = null;
			return false;
		}

		protected override void UpdateData(ViewData view_data)
		{
			if (DisplayedRewardID != view_data.RewardID || DisplayedRewardType != view_data.Type)
			{
				GracePeriodTimeout = Time.unscaledTime + 1f;
				DisplayedRewardID = view_data.RewardID;
				DisplayedRewardType = view_data.Type;
				bool flag = false;
				GenericLocalisationStruct value;
				if (DisplayedRewardID != 0)
				{
					if (GameData.Main.TryGet<GameDataObject>(DisplayedRewardID, out var output) && output is IUpgrade upgrade)
					{
						Title.text = upgrade.UpgradeName;
						Description.text = upgrade.UpgradeDescription;
						flag = true;
					}
				}
				else if (base.Localisation.NewsItemFallbackLocalisation.Text.TryGetValue(DisplayedRewardType, out value))
				{
					Title.text = value.Name;
					Description.text = value.Description;
					flag = true;
				}
				if (!flag)
				{
					Title.text = "";
					Description.text = "";
				}
			}
			if (GracePeriodTimeout < Time.unscaledTime)
			{
				foreach (PlayerInputData input in view_data.Inputs)
				{
					if (Players.Main.Has(input.PlayerID) && Players.Main.Get(input.PlayerID).IsLocalUser)
					{
						if (input.Input.State.MenuCancel == ButtonState.Pressed)
						{
							RequestPrevItem = true;
						}
						if (input.Input.State.MenuSelect == ButtonState.Pressed)
						{
							RequestNextItem = true;
						}
					}
				}
			}
			PrevPromptElement.transform.parent.gameObject.SetActive(view_data.Type != NewsItemType.Newspaper);
			NextPromptElement.SetButtonForAll(Controls.MenuSelect);
			PrevPromptElement.SetButtonForAll(Controls.MenuCancel);
		}
	}
}
