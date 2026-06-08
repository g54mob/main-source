#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
using Kitchen.Modules;
using MessagePack;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class GenericPopupView : BaseDismissableView<GenericPopupView.ViewData, GenericPopupView.ResponseData>
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

						public LambdaParameterValueProvider_IComponentData<CPlayerGenericPopup>.Runtime runtime_info;

						public LambdaParameterValueProvider_IComponentData<CPopup>.Runtime runtime_dismiss;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					private LambdaParameterValueProvider_IComponentData<CPlayerGenericPopup> forParameter_info;

					private LambdaParameterValueProvider_IComponentData<CPopup> forParameter_dismiss;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_info.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_dismiss.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_info = forParameter_info.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_dismiss = forParameter_dismiss.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, ref CPlayerGenericPopup info, ref CPopup dismiss, [In] ref CLinkedView linked_view)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, ref info, ref dismiss, in linked_view);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), ref runtimes.runtime_info.For(i), ref runtimes.runtime_dismiss.For(i), ref runtimes.runtime_linked_view.For(i));
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, ref CPlayerGenericPopup info, ref CPopup dismiss, in CLinkedView linked_view)
			{
				if (!HasComponent<CPlayer>(info.Player))
				{
					dismiss.Dismiss = true;
					return;
				}
				CInputData input = default(CInputData);
				int playerID = 0;
				if (HasComponent<CInputData>(info.Player))
				{
					input = GetComponent<CInputData>(info.Player);
				}
				if (HasComponent<CPlayer>(info.Player))
				{
					playerID = GetComponent<CPlayer>(info.Player).ID;
				}
				SendUpdate(linked_view, new ViewData
				{
					PlayerID = playerID,
					Input = input
				});
				ResponseData result = default(ResponseData);
				if (ApplyUpdates(linked_view.Identifier, delegate(ResponseData data)
				{
					result = data;
				}, only_final_update: true))
				{
					dismiss.Dismiss = result.IsComplete;
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
					ComponentType.ReadWrite<CPlayerGenericPopup>(),
					ComponentType.ReadWrite<CPopup>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int PlayerID;

			[Key(1)]
			public CInputData Input;

			public bool IsChangedFrom(ViewData check)
			{
				return true;
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ResponseData : IResponseData, IViewResponseData, IDismissableResponse
		{
			[Key(0)]
			public bool IsComplete { get; set; }
		}

		[Serializable]
		public struct ButtonPrompts
		{
			public string Button;

			public InputPromptElement PromptElement;
		}

		[Header("Configuration")]
		[SerializeField]
		private bool Undismissable;

		[SerializeField]
		private bool DiscordLink;

		[SerializeField]
		[Header("References")]
		private List<ButtonPrompts> Prompts = new List<ButtonPrompts>();

		private void Start()
		{
			ViewStateCommunicator.Main.AddPopup(this);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			ViewStateCommunicator.Main.RemovePopup(this);
		}

		protected override void UpdateData(ViewData view_data)
		{
			if (DiscordLink && view_data.Input.State.SecondaryAction1 == ButtonState.Pressed)
			{
				Application.OpenURL("https://discord.plateupgame.com");
			}
			foreach (ButtonPrompts prompt in Prompts)
			{
				prompt.PromptElement.SetButtonForUser(prompt.Button, view_data.PlayerID);
			}
			if (!Undismissable && (view_data.Input.State.MenuSelect == ButtonState.Pressed || view_data.Input.State.MenuCancel == ButtonState.Pressed || view_data.Input.State.MenuTrigger == ButtonState.Pressed || view_data.Input.State.InteractAction == ButtonState.Pressed || view_data.Input.State.GrabAction == ButtonState.Pressed))
			{
				IsComplete = true;
			}
		}
	}
}
