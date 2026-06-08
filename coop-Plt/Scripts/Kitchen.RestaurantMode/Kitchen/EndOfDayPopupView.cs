#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
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
	public class EndOfDayPopupView : InterfaceObjectView<EndOfDayPopupView.ViewData, EndOfDayPopupView.ResponseData>
	{
		public class UpdateView : ResponsiveViewSystemBase<ViewData, ResponseData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass1_0
			{
				public UpdateView _003C_003E4__this;

				public CMoneyTrackRecord record;

				internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, ref CPopup popup_info, in CPopupEndDayData data, in CLinkedView linked_view, in DynamicBuffer<CCapturedUserInput> input_users)
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

						public LambdaParameterValueProvider_IComponentData<CPopupEndDayData>.Runtime runtime_data;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						public LambdaParameterValueProvider_DynamicBuffer<CCapturedUserInput>.Runtime runtime_input_users;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					private LambdaParameterValueProvider_IComponentData<CPopup> forParameter_popup_info;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CPopupEndDayData> forParameter_data;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_DynamicBuffer<CCapturedUserInput> forParameter_input_users;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_popup_info.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_data.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
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
							runtime_data = forParameter_data.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_input_users = forParameter_input_users.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView _003C_003E4__this;

				public CMoneyTrackRecord record;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, ref CPopup popup_info, in CPopupEndDayData data, in CLinkedView linked_view, in DynamicBuffer<CCapturedUserInput> input_users)
				{
					List<PlayerInputData> inputs = _003C_003E4__this.EntityManager.GatherInputs(input_users);
					_003C_003E4__this.SendUpdate(linked_view, new ViewData
					{
						Inputs = inputs,
						PopupData = data,
						Identifiers = record.Identifiers,
						Amounts = record.Amounts
					});
					ResponseData result = default(ResponseData);
					if (_003C_003E4__this.ApplyUpdates(linked_view.Identifier, delegate(ResponseData responseData)
					{
						result = responseData;
					}, only_final_update: true) && result.Dismiss)
					{
						popup_info.Dismiss = true;
					}
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					_003C_003E4__this = displayClass._003C_003E4__this;
					record = displayClass.record;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
				{
					displayClass._003C_003E4__this = _003C_003E4__this;
					displayClass.record = record;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_popup_info.For(i), in runtimes.runtime_data.For(i), in runtimes.runtime_linked_view.For(i), runtimes.runtime_input_users.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
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

			protected override void Initialise()
			{
				base.Initialise();
				RequireForUpdate(GetEntityQuery(typeof(CPopupEndDayData)));
			}

			protected override void OnUpdate()
			{
				_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
				{
					_003C_003E4__this = this,
					record = base.World.GetExistingSystem<MoneyTracker>().GetRecord()
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
				(array[0] = new EntityQueryDesc()).All = new ComponentType[4]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadWrite<CPopup>(),
					ComponentType.ReadOnly<CPopupEndDayData>(),
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
			public CPopupEndDayData PopupData;

			[Key(2)]
			public DataObjectList Identifiers;

			[Key(3)]
			public DataObjectList Amounts;

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
			public bool Dismiss;
		}

		[Header("State")]
		private bool IsDismissed;

		private ConsentElement Consent;

		private InputPromptElement PromptElement;

		private ViewData Data;

		private ModuleList ModuleList;

		protected Vector2 DefaultElementSize = new Vector2(4f, 0.6f);

		private MoneyDisplayRow PreviousRow;

		private MoneyDisplayRow SumRow;

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
			ModuleList = new ModuleList();
			ModuleList.AddModule(Add<TextElement>((Transform)null).SetLabel(base.Localisation["DAY_END_DESCRIPTION"]).SetSize(DefaultElementSize.x, DefaultElementSize.y));
			ModuleList.AddModule(Add<SpacerElement>((Transform)null));
			ModuleList.AddModule(Add<LabelElement>((Transform)null).SetLabel(base.Localisation["MONEY_TITLE"]).SetSize(DefaultElementSize.x, DefaultElementSize.y));
			MoneyDisplayRow module = AddRow(base.Localisation["MONEY_TOTAL"], view_data.PopupData.Base + view_data.PopupData.PlayerBonus, is_sum_row: true);
			int num = 0;
			for (int i = 0; i < view_data.Identifiers.Count; i++)
			{
				int id = view_data.Identifiers[i];
				int num2 = view_data.Amounts[i];
				GameData.Main.TryGet<GameDataObject>(id, out var output);
				if (!(output is Dish dish))
				{
					if (output is Appliance appliance)
					{
						AddRow(appliance.Name, num2);
					}
					else
					{
						num += num2;
					}
				}
				else
				{
					AddRow(dish.Name, num2);
				}
			}
			if (num != 0)
			{
				AddRow(base.Localisation["MONEY_OTHER"], num);
			}
			if (view_data.PopupData.PlayerBonus > 0)
			{
				AddRow(base.Localisation["MONEY_PLAYER"], view_data.PopupData.PlayerBonus);
			}
			ModuleList.AddModule(module);
			ModuleList.AddModule(Add<SpacerElement>((Transform)null));
			PanelElement panelElement = Add<PanelElement>((Transform)null);
			panelElement.SetTarget(ModuleList);
			PromptElement = panelElement.AddPrompt();
			(Consent = Add<ConsentElement>((Transform)null)).Attach(panelElement);
			Consent.Mode = ConsentElement.ConsentMode.AnyRequired;
			Consent.Setup(view_data.Inputs);
			Vector3 localPosition = -ModuleList.BoundingBox.center;
			Transform transform = Container.transform;
			localPosition.z = transform.localPosition.z;
			transform.localPosition = localPosition;
		}

		private MoneyDisplayRow AddRow(string text, int value, bool is_sum_row = false)
		{
			MoneyDisplayRow moneyDisplayRow = Add<MoneyDisplayRow>(Container);
			moneyDisplayRow.SetValue(value).SetLabel(text);
			if (is_sum_row)
			{
				moneyDisplayRow.SetLine(active: true);
				SumRow = moneyDisplayRow;
			}
			else
			{
				ModuleList.AddModule(moneyDisplayRow);
				if (PreviousRow != null)
				{
					moneyDisplayRow.QueueAfter(PreviousRow);
				}
				else
				{
					moneyDisplayRow.StartLerp();
				}
				PreviousRow = moneyDisplayRow;
				if (SumRow != null)
				{
					SumRow.AddToSum(moneyDisplayRow);
				}
			}
			return moneyDisplayRow;
		}

		private void FinishMoneyRows()
		{
			if (!(SumRow == null))
			{
				SumRow.FinishNow();
			}
		}

		protected override void HandleUpdate(ViewData view_data)
		{
			Consent.SetPlayers(view_data.Inputs);
			for (int i = 0; i < view_data.Inputs.Count; i++)
			{
				PlayerInputData playerInputData = view_data.Inputs[i];
				if (playerInputData.Input.State.MenuSelect == ButtonState.Pressed)
				{
					if (!SumRow.IsFinished())
					{
						SumRow.FinishNow();
						return;
					}
					Consent.SetConsent(playerInputData.PlayerID, !Consent.GetConsent(playerInputData.PlayerID));
				}
				if (playerInputData.Input.State.MenuCancel == ButtonState.Pressed)
				{
					Consent.SetConsent(playerInputData.PlayerID, value: false);
				}
			}
			PromptElement.SetButtonForAll(Controls.MenuSelect);
		}

		private void Update()
		{
			if (!IsDismissed && Consent != null && Consent.IsCompleted)
			{
				IsDismissed = true;
			}
		}

		public override bool HasStateUpdate(out IResponseData state)
		{
			state = null;
			if (IsDismissed)
			{
				state = new ResponseData
				{
					Dismiss = true
				};
			}
			return IsDismissed;
		}
	}
}
