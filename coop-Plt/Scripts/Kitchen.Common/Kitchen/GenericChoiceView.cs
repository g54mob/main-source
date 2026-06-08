#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
using JetBrains.Annotations;
using Kitchen.Modules;
using KitchenData;
using MessagePack;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	public class GenericChoiceView : InterfaceObjectView<GenericChoiceView.ViewData, GenericChoiceView.ResponseData>
	{
		public class UpdateView : ResponsiveViewSystemBase<ViewData, ResponseData>
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

						public LambdaParameterValueProvider_IComponentData<CPopup>.Runtime runtime_popup_info;

						public LambdaParameterValueProvider_IComponentData<CGenericChoicePopup>.Runtime runtime_details;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						public LambdaParameterValueProvider_DynamicBuffer<CCapturedUserInput>.Runtime runtime_input_users;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					private LambdaParameterValueProvider_IComponentData<CPopup> forParameter_popup_info;

					private LambdaParameterValueProvider_IComponentData<CGenericChoicePopup> forParameter_details;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_DynamicBuffer<CCapturedUserInput> forParameter_input_users;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_popup_info.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_details.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_input_users.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_popup_info = forParameter_popup_info.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_details = forParameter_details.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_input_users = forParameter_input_users.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, ref CPopup popup_info, ref CGenericChoicePopup details, [In] ref CLinkedView linked_view, [In] ref DynamicBuffer<CCapturedUserInput> input_users)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, ref popup_info, ref details, in linked_view, in input_users);
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
						Entity entity = runtimes.runtime_entity.For(i);
						int entityInQueryIndex = runtimes.runtime_entityInQueryIndex.For(i);
						ref CPopup popup_info = ref runtimes.runtime_popup_info.For(i);
						ref CGenericChoicePopup details = ref runtimes.runtime_details.For(i);
						ref CLinkedView linked_view = ref runtimes.runtime_linked_view.For(i);
						DynamicBuffer<CCapturedUserInput> input_users = runtimes.runtime_input_users.For(i);
						OriginalLambdaBody(entity, entityInQueryIndex, ref popup_info, ref details, ref linked_view, ref input_users);
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, ref CPopup popup_info, ref CGenericChoicePopup details, in CLinkedView linked_view, in DynamicBuffer<CCapturedUserInput> input_users)
			{
				List<PlayerInputData> inputs = base.EntityManager.GatherInputs(input_users);
				IManagedPopupData popupData = null;
				if (Require<CPopupFloat>(entity, out CPopupFloat comp))
				{
					popupData = comp;
				}
				if (Require<CPopupRecipe>(entity, out CPopupRecipe comp2))
				{
					popupData = comp2;
				}
				if (Require<CPopupSpeedrunCompleted>(entity, out CPopupSpeedrunCompleted comp3))
				{
					popupData = comp3;
				}
				SendUpdate(linked_view, new ViewData
				{
					Inputs = inputs,
					Type = details.Type,
					TextSet = details.TextSet,
					IsPaused = HasComponent<CGamePauseRequest>(entity),
					PopupData = popupData
				});
				ResponseData result = default(ResponseData);
				if (ApplyUpdates(linked_view.Identifier, delegate(ResponseData data)
				{
					result = data;
				}, only_final_update: true) && result.Choice != GenericChoiceDecision.None)
				{
					details.Decision = result.Choice;
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
				(array[0] = new EntityQueryDesc()).All = new ComponentType[4]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadWrite<CGenericChoicePopup>(),
					ComponentType.ReadWrite<CPopup>(),
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
			public GenericChoiceType Type;

			[Key(2)]
			public PopupType TextSet;

			[Key(3)]
			public bool IsPaused;

			[Key(4)]
			public IManagedPopupData PopupData;

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
			public GenericChoiceDecision Choice;
		}

		[Header("State")]
		private GenericChoiceDecision Choice;

		[UsedImplicitly]
		private bool IsUpdated;

		private ConsentElement Consent;

		private ConsentElement CancelConsent;

		private InputPromptElement PromptElement;

		private InputPromptElement CancelPromptElement;

		private ViewData Data;

		private void Start()
		{
			ViewStateCommunicator.Main.AddPopup(this);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			ViewStateCommunicator.Main.RemovePopup(this);
		}

		protected override void FirstUpdate(ViewData view_data)
		{
			base.FirstUpdate(view_data);
			Data = view_data;
			TextPanelElement.Style style = TextPanelElement.Style.Default;
			PopupDetails popupDetails = default(PopupDetails);
			if (view_data.PopupData is CPopupRecipe cPopupRecipe)
			{
				style = TextPanelElement.Style.Recipe;
				if (GameData.Main.TryGet<Dish>(cPopupRecipe.ID, out var output, warn_if_fail: true))
				{
					popupDetails.Title = output.Name;
					popupDetails.Description = base.Localisation[cPopupRecipe.ID] + "\n\n" + base.Localisation["TIP_RECIPE_MENU"];
				}
			}
			else if (view_data.PopupData is CPopupSpeedrunCompleted cPopupSpeedrunCompleted)
			{
				popupDetails.Title = base.Localisation["STATS_COMPLETED_POPUP"];
				if (cPopupSpeedrunCompleted.PreviousBestMilliseconds == 0 || cPopupSpeedrunCompleted.ThisRunMilliseconds < cPopupSpeedrunCompleted.PreviousBestMilliseconds)
				{
					popupDetails.Description = "<align=\"center\">" + base.Localisation["STATS_PERSONAL_BEST"] + "</align><br>";
				}
				string text = SpeedrunScore.FromMilliseconds(cPopupSpeedrunCompleted.ThisRunMilliseconds).ToString();
				ref string description = ref popupDetails.Description;
				description = description + "<align=\"center\">" + base.Localisation["STATS_TIME"] + ":   " + text + "</align>";
				if (cPopupSpeedrunCompleted.PreviousBestMilliseconds != 0)
				{
					string text2 = SpeedrunScore.FromMilliseconds(cPopupSpeedrunCompleted.PreviousBestMilliseconds).ToString();
					description = ref popupDetails.Description;
					description = description + "<br><align=\"center\">" + base.Localisation["STATS_PREV_BEST"] + ":   " + text2;
				}
			}
			else
			{
				PopupDetails popupDetails2 = ((!(view_data.PopupData is CPopupFloat cPopupFloat)) ? base.Localisation[view_data.TextSet] : base.Localisation[view_data.TextSet, cPopupFloat.Value]);
				popupDetails = popupDetails2;
			}
			TextPanelElement textPanelElement = Add<TextPanelElement>(Container).SetStyle(style).SetText(popupDetails.Title, popupDetails.Description);
			PromptElement = textPanelElement.AddPrompt();
			(Consent = Add<ConsentElement>(Container)).Attach(textPanelElement);
			if (view_data.Type == GenericChoiceType.OnlyAccept)
			{
				Consent.Mode = ConsentElement.ConsentMode.AnyRequired;
			}
			Consent.Setup(view_data.Inputs);
			if (view_data.Type != GenericChoiceType.OnlyAccept)
			{
				TextPanelElement textPanelElement2 = Add<TextPanelElement>(Container).SetStyle(TextPanelElement.Style.Button, Element.ThemeColour.Cancel).SetText(popupDetails.Title, popupDetails.Description);
				textPanelElement2.Position = new Vector2(0f, textPanelElement.BoundingBox.min.y - 1f);
				CancelPromptElement = textPanelElement2.AddPrompt();
				(CancelConsent = Add<ConsentElement>(Container)).Attach(textPanelElement2);
				textPanelElement2.SetText("", base.Localisation["POPUP_CANCEL"]);
				CancelConsent.Setup(view_data.Inputs);
			}
			IsUpdated = true;
		}

		protected override void HandleUpdate(ViewData view_data)
		{
			Consent.SetPlayers(view_data.Inputs);
			if (CancelConsent != null)
			{
				CancelConsent.SetPlayers(view_data.Inputs);
			}
			for (int i = 0; i < view_data.Inputs.Count; i++)
			{
				PlayerInputData playerInputData = view_data.Inputs[i];
				if (playerInputData.Input.State.MenuSelect == ButtonState.Pressed)
				{
					Consent.SetConsent(playerInputData.PlayerID, !Consent.GetConsent(playerInputData.PlayerID));
					if (view_data.Type == GenericChoiceType.AcceptOrConsentCancel && CancelConsent != null)
					{
						CancelConsent.SetConsent(playerInputData.PlayerID, value: false);
					}
				}
				if (view_data.Type == GenericChoiceType.AcceptOrCancel && playerInputData.Input.State.MenuCancel == ButtonState.Pressed)
				{
					Choice = GenericChoiceDecision.Cancel;
					return;
				}
				if (view_data.Type == GenericChoiceType.AcceptOrConsentCancel && playerInputData.Input.State.MenuCancel == ButtonState.Pressed)
				{
					Consent.SetConsent(playerInputData.PlayerID, value: false);
					if (CancelConsent != null)
					{
						CancelConsent.SetConsent(playerInputData.PlayerID, !CancelConsent.GetConsent(playerInputData.PlayerID));
					}
					return;
				}
			}
			PromptElement.SetButtonForAll(Controls.MenuSelect);
			if (CancelPromptElement != null)
			{
				CancelPromptElement.SetButtonForAll(Controls.MenuCancel);
			}
		}

		private void Update()
		{
			if (Choice == GenericChoiceDecision.None)
			{
				if (Consent.IsCompleted)
				{
					Choice = GenericChoiceDecision.Accept;
				}
				if (CancelConsent != null && CancelConsent.IsCompleted)
				{
					Choice = GenericChoiceDecision.Cancel;
				}
			}
		}

		public override bool HasStateUpdate(out IResponseData state)
		{
			state = null;
			if (Choice != GenericChoiceDecision.None)
			{
				state = new ResponseData
				{
					Choice = Choice
				};
			}
			return Choice != GenericChoiceDecision.None;
		}
	}
}
