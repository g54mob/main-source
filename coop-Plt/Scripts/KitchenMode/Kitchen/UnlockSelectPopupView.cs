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
	[Serializable]
	public class UnlockSelectPopupView : ResponsiveObjectView<UnlockSelectPopupView.ViewData, UnlockSelectPopupView.ResponseData>
	{
		public class UpdateView : ResponsiveViewSystemBase<ViewData, ResponseData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass0_0
			{
				public UpdateView _003C_003E4__this;

				public EntityCommandBuffer ecb;

				internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, ref CPopup popup_info, in CLinkedView linked_view, in DynamicBuffer<CUnlockSelectPopupOption> unlocks, in DynamicBuffer<CCapturedUserInput> input_users)
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

						public LambdaParameterValueProvider_IComponentData<CPopup>.Runtime runtime_popup_info;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						public LambdaParameterValueProvider_DynamicBuffer<CUnlockSelectPopupOption>.Runtime runtime_unlocks;

						public LambdaParameterValueProvider_DynamicBuffer<CCapturedUserInput>.Runtime runtime_input_users;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					private LambdaParameterValueProvider_IComponentData<CPopup> forParameter_popup_info;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_DynamicBuffer<CUnlockSelectPopupOption> forParameter_unlocks;

					[ReadOnly]
					private LambdaParameterValueProvider_DynamicBuffer<CCapturedUserInput> forParameter_input_users;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_popup_info.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_unlocks.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_input_users.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_popup_info = forParameter_popup_info.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_unlocks = forParameter_unlocks.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_input_users = forParameter_input_users.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView _003C_003E4__this;

				public EntityCommandBuffer ecb;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, ref CPopup popup_info, in CLinkedView linked_view, in DynamicBuffer<CUnlockSelectPopupOption> unlocks, in DynamicBuffer<CCapturedUserInput> input_users)
				{
					List<PlayerInputData> inputs = _003C_003E4__this.EntityManager.GatherInputs(input_users);
					int length = unlocks.Length;
					int[] array = new int[length];
					for (int i = 0; i < length; i++)
					{
						array[i] = unlocks[i].ID;
					}
					int[] array2 = new int[length];
					bool flag = false;
					bool flag2 = false;
					float pollProgress = 1f;
					for (int j = 0; j < unlocks.Length; j++)
					{
						CUnlockSelectPopupOption cUnlockSelectPopupOption = unlocks[j];
						if (_003C_003E4__this.Require<CPollRequested>(cUnlockSelectPopupOption.Entity, out CPollRequested comp))
						{
							array2[j] = comp.Votes;
							flag |= comp.IsComplete;
							flag2 |= comp.IsForced;
							pollProgress = comp.PollProgress;
						}
					}
					_003C_003E4__this.Require<CUnlockSelectPopupType>(entity, out CUnlockSelectPopupType comp2);
					_003C_003E4__this.Router.BroadcastUpdate(linked_view, new ViewData
					{
						Inputs = inputs,
						Unlocks = array,
						TwitchVotes = array2,
						VoteComplete = flag,
						VoteIsForced = flag2,
						PollProgress = pollProgress,
						Type = comp2.RewardType
					});
					ResponseData result = default(ResponseData);
					if (_003C_003E4__this.ApplyUpdates(linked_view.Identifier, delegate(ResponseData data)
					{
						result = data;
					}, only_final_update: true) && result.Consensus >= 0)
					{
						ecb.AddComponent(entity, new CUnlockSelectPopupResult
						{
							Selection = unlocks[result.Consensus].Entity
						});
					}
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					_003C_003E4__this = displayClass._003C_003E4__this;
					ecb = displayClass.ecb;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					displayClass._003C_003E4__this = _003C_003E4__this;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_popup_info.For(i), in runtimes.runtime_linked_view.For(i), runtimes.runtime_unlocks.For(i), runtimes.runtime_input_users.For(i));
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
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CUnlockSelectPopup>(),
					ComponentType.ReadWrite<CPopup>(),
					ComponentType.ReadOnly<CUnlockSelectPopupOption>(),
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
			public int[] Unlocks;

			[Key(2)]
			public int[] TwitchVotes;

			[Key(3)]
			public bool VoteComplete;

			[Key(4)]
			public bool VoteIsForced;

			[Key(5)]
			public float PollProgress;

			[Key(6)]
			public UnlockRewardType Type;

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
			public int Consensus;
		}

		[SerializeField]
		[Header("References")]
		private TextMeshPro Description;

		[SerializeField]
		private VoteBar Bar;

		[SerializeField]
		private DecorationBonusSetElement BonusSetModule1;

		[SerializeField]
		private DecorationBonusSetElement BonusSetModule2;

		[SerializeField]
		private TextPanelElement Recipe1;

		[SerializeField]
		private TextPanelElement Recipe2;

		[SerializeField]
		private RecipeLocalisation Recipes;

		[Header("State")]
		private bool IsUpdated;

		private int Consensus = -1;

		private UnlockCardElement Card1;

		private UnlockCardElement Card2;

		private ConsentElement Consent1;

		private ConsentElement Consent2;

		private bool IsSingleCardMode;

		private void Start()
		{
			ViewStateCommunicator.Main.AddPopup(this);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			ViewStateCommunicator.Main.RemovePopup(this);
		}

		public override void Initialise()
		{
			base.Initialise();
			Card1 = ModuleDirectory.Add<UnlockCardElement>(base.transform);
			Card1.transform.localPosition = new Vector3(-2.2f, -1.65f, 0f);
			BonusSetModule1.transform.localPosition = new Vector3(-5f, 1.7f, 0f);
			Recipe1 = ModuleDirectory.Add<TextPanelElement>(base.transform, new Vector2(-5.7f, -0.25f));
			Recipe1.SetVisible(visible: false);
			Consent1 = ModuleDirectory.Add<ConsentElement>(base.transform);
			Consent1.Attach(Card1, 0.5f);
			Card2 = ModuleDirectory.Add<UnlockCardElement>(base.transform);
			Card2.transform.localPosition = new Vector3(2.2f, -1.65f, 0f);
			BonusSetModule2.transform.localPosition = new Vector3(5f, 1.7f, 0f);
			Recipe2 = ModuleDirectory.Add<TextPanelElement>(base.transform, new Vector2(5.7f, -0.25f));
			Recipe2.SetVisible(visible: false);
			Consent2 = ModuleDirectory.Add<ConsentElement>(base.transform);
			Consent2.Attach(Card2, 0.5f);
		}

		private void SetupDecorationPanel(DecorationBonusSetElement element, Unlock unlock)
		{
			if (!(unlock is UnlockCard unlockCard))
			{
				return;
			}
			foreach (UnlockEffect effect in unlockCard.Effects)
			{
				if (effect is ThemeAddEffect themeAddEffect)
				{
					element.Set(themeAddEffect.AddsTheme);
					break;
				}
			}
		}

		private void SetupRecipeInfo(TextPanelElement text, Unlock unlock)
		{
			if (!(text == null))
			{
				text.SetVisible(visible: false);
				if (unlock is Dish dish && Recipes.Has(dish))
				{
					text.SetVisible(visible: true);
					text.SetRecipe(dish);
					text.SetStyle(TextPanelElement.Style.Default);
				}
			}
		}

		protected override void UpdateData(ViewData view_data)
		{
			bool flag = false;
			bool flag2 = false;
			if (!IsUpdated)
			{
				if (view_data.Unlocks.Length != 0 && GameData.Main.TryGet<Unlock>(view_data.Unlocks[0], out var output, warn_if_fail: true))
				{
					Card1.SetUnlock(output);
					Bar.SetColour1(output.Colour);
					flag |= output.CardType == CardType.FranchiseTier;
					flag2 |= output.CardType == CardType.ThemeUnlock;
					SetupDecorationPanel(BonusSetModule1, output);
					SetupRecipeInfo(Recipe1, output);
				}
				else
				{
					Card1.SetUnlock(null);
				}
				if (view_data.Unlocks.Length > 1 && GameData.Main.TryGet<Unlock>(view_data.Unlocks[1], out output, warn_if_fail: true))
				{
					flag |= output.CardType == CardType.FranchiseTier;
					flag2 |= output.CardType == CardType.ThemeUnlock;
					Card2.SetUnlock(output);
					Bar.SetColour2(output.Colour);
					SetupDecorationPanel(BonusSetModule2, output);
					SetupRecipeInfo(Recipe2, output);
					IsSingleCardMode = false;
				}
				else
				{
					Card2.SetUnlock(null);
					IsSingleCardMode = true;
					Card2.gameObject.SetActive(value: false);
					Card1.Position = new Vector2(0f, Card1.Position.y);
					Consent1.Position = new Vector2(0f, Consent1.Position.y);
				}
				Consent1.Setup(view_data.Inputs);
				Consent2.Setup(view_data.Inputs);
				IsUpdated = true;
				if (Description != null)
				{
					if (IsSingleCardMode)
					{
						Description.text = GameData.Main.GlobalLocalisation["TIP_CARD_MENU"];
					}
					else
					{
						if (view_data.Type == UnlockRewardType.Standard)
						{
							Description.text = GameData.Main.GlobalLocalisation.Text[flag2 ? "THEME_UNLOCKED" : (flag ? "FRANCHISE_CARD_UNLOCKED" : "CARD_UNLOCKED")];
						}
						else
						{
							Description.text = "";
						}
						Description.text = Description.text + "\n\n" + GameData.Main.GlobalLocalisation["TIP_CARD_MENU"];
					}
				}
			}
			else
			{
				Consent1.SetPlayers(view_data.Inputs);
				Consent2.SetPlayers(view_data.Inputs);
			}
			int num = -2;
			for (int i = 0; i < view_data.Inputs.Count; i++)
			{
				PlayerInputData playerInputData = view_data.Inputs[i];
				int playerID = playerInputData.PlayerID;
				int num2 = ((!Consent1.GetConsent(playerID)) ? (Consent2.GetConsent(playerID) ? 1 : (-1)) : 0);
				if (IsSingleCardMode)
				{
					if (playerInputData.Input.State.MenuSelect == ButtonState.Pressed || playerInputData.Input.State.MenuLeft == ButtonState.Pressed || playerInputData.Input.State.MenuRight == ButtonState.Pressed)
					{
						num2 = 0;
					}
				}
				else
				{
					if (playerInputData.Input.State.MenuLeft == ButtonState.Pressed)
					{
						num2 = ((num2 == 0) ? (-1) : 0);
					}
					if (playerInputData.Input.State.MenuRight == ButtonState.Pressed)
					{
						num2 = ((num2 != 1) ? 1 : (-1));
					}
				}
				if (playerInputData.Input.State.MenuCancel == ButtonState.Pressed)
				{
					num2 = -1;
				}
				if (num2 >= view_data.Unlocks.Length)
				{
					num2 = -1;
				}
				Consent1.SetConsent(playerID, num2 == 0);
				Consent2.SetConsent(playerID, num2 == 1);
				if (num == -2)
				{
					num = num2;
				}
				if (num != num2)
				{
					num = -1;
				}
			}
			if (view_data.TwitchVotes != null && view_data.TwitchVotes.Length == 2 && (view_data.TwitchVotes[0] > 0 || view_data.TwitchVotes[1] > 0))
			{
				Bar.gameObject.SetActive(value: true);
				Bar.SetValues(view_data.TwitchVotes[0], view_data.TwitchVotes[1], view_data.PollProgress);
				if (!view_data.VoteComplete)
				{
					return;
				}
				int num3 = view_data.TwitchVotes[0] - view_data.TwitchVotes[1];
				if (num3 != 0)
				{
					if (view_data.VoteIsForced)
					{
						Consent1.FillSpeed = 0.25f;
						Consent2.FillSpeed = 0.25f;
						Consent1.SetAllConsents(num3 > 0);
						Consent2.SetAllConsents(num3 < 0);
					}
					Bar.SetColour1((num3 > 0) ? new Color(0.5f, 0.87f, 0.25f) : new Color(0.75f, 0.29f, 0.53f));
					Bar.SetColour2((num3 > 0) ? new Color(0.75f, 0.29f, 0.53f) : new Color(0.5f, 0.87f, 0.25f));
				}
				else
				{
					Bar.SetColour1(new Color(0.93f, 0.8f, 0.16f));
					Bar.SetColour2(new Color(0.93f, 0.8f, 0.16f));
				}
			}
			else
			{
				Bar.gameObject.SetActive(value: false);
			}
		}

		private void Update()
		{
			if (Consensus < 0)
			{
				if (Consent1.IsCompleted)
				{
					Consensus = 0;
				}
				if (Consent2.IsCompleted)
				{
					Consensus = 1;
				}
			}
		}

		public override bool HasStateUpdate(out IResponseData state)
		{
			state = null;
			if (Consensus < 0)
			{
				return false;
			}
			state = new ResponseData
			{
				Consensus = Consensus
			};
			return true;
		}
	}
}
