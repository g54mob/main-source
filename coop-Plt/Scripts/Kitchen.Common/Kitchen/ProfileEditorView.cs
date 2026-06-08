#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Controllers;
using Kitchen.Modules;
using MessagePack;
using Platforms;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	public class ProfileEditorView : ResponsiveObjectView<ProfileEditorView.ViewData, ProfileEditorView.ResponseData>, IInputConsumer
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

						public LambdaParameterValueProvider_IComponentData<ManageProfileEditors.CProfileEditor>.Runtime runtime_editor;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					private LambdaParameterValueProvider_IComponentData<ManageProfileEditors.CProfileEditor> forParameter_editor;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_editor.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_editor = forParameter_editor.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, ref ManageProfileEditors.CProfileEditor editor, [In] ref CLinkedView linked_view)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, ref editor, in linked_view);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_editor.For(i), ref runtimes.runtime_linked_view.For(i));
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, ref ManageProfileEditors.CProfileEditor editor, in CLinkedView linked_view)
			{
				SendUpdate(linked_view, new ViewData
				{
					PlayerID = editor.PlayerID
				});
				ResponseData result = default(ResponseData);
				if (ApplyUpdates(linked_view.Identifier, delegate(ResponseData data)
				{
					result = data;
				}, only_final_update: true))
				{
					editor.IsComplete = result.IsComplete;
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
					ComponentType.ReadWrite<ManageProfileEditors.CProfileEditor>()
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

			public bool IsChangedFrom(ViewData check)
			{
				return PlayerID != check.PlayerID;
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ResponseData : IResponseData, IViewResponseData
		{
			[Key(0)]
			public bool IsComplete;
		}

		private enum Menu
		{
			None = 0,
			MainChoice = 1,
			ProfileList = 2
		}

		[Header("References")]
		[SerializeField]
		private Animator Animator;

		[Header("State")]
		private bool IsComplete;

		private int PlayerID;

		private InputLock.Lock Lock;

		private Dictionary<Type, ProfileEditorSubmenu> Menus;

		private Type ActiveMenu;

		private ModuleList ModuleList;

		private PanelElement Panel;

		private bool ShouldAppear => PlatformSettings.UseAdvancedProfilesMode;

		public override void Initialise()
		{
			base.Initialise();
			if (!ShouldAppear)
			{
				return;
			}
			if ((bool)Animator)
			{
				Animator.Update(0f);
			}
			Panel = Add<PanelElement>();
			ModuleList = new ModuleList();
			Menus = new Dictionary<Type, ProfileEditorSubmenu>();
			Menus.Add(typeof(ManageProfileMenu), new ManageProfileMenu(base.transform, ModuleList));
			Menus.Add(typeof(SelectProfileMenu), new SelectProfileMenu(base.transform, ModuleList));
			Menus.Add(typeof(ControlsMenu), new ControlsMenu(base.transform, ModuleList));
			Menus.Add(typeof(LoadProfileMenu), new LoadProfileMenu(base.transform, ModuleList));
			Menus.Add(typeof(DeleteProfileMenu), new DeleteProfileMenu(base.transform, ModuleList));
			foreach (KeyValuePair<Type, ProfileEditorSubmenu> menu in Menus)
			{
				menu.Value.OnRequestMenu += delegate(object _, (Type, bool) t)
				{
					SetActiveMenu(t.Item1);
				};
				menu.Value.OnRequestSkipStackMenu += delegate(object _, (Type, bool) t)
				{
					SetActiveMenu(t.Item1);
				};
				menu.Value.OnRequestAction += OnRequestAction;
				menu.Value.OnPreviousMenu += delegate
				{
					OnRequestAction(null, ProfileMenuAction.Back);
				};
			}
			ProfileStore.Main.Load();
		}

		private void OnRequestAction(object _, ProfileMenuAction e)
		{
			switch (e)
			{
			case ProfileMenuAction.Back:
				LeaveCurrentMenu();
				break;
			case ProfileMenuAction.Close:
				CloseEditor();
				break;
			}
		}

		protected override void UpdateData(ViewData view_data)
		{
			if (!ShouldAppear)
			{
				base.gameObject.SetActive(value: false);
			}
			else if (InputSourceIdentifier.DefaultInputSource != null)
			{
				if (!Players.Main.Get(view_data.PlayerID).IsLocalUser)
				{
					base.gameObject.SetActive(value: false);
					return;
				}
				base.gameObject.SetActive(value: true);
				InitialiseForPlayer(view_data.PlayerID);
			}
		}

		private void InitialiseForPlayer(int player)
		{
			LocalInputSourceConsumers.Register(this);
			if (Lock.Type != PlayerLockState.Unlocked)
			{
				InputSourceIdentifier.DefaultInputSource.ReleaseLock(PlayerID, Lock);
			}
			PlayerID = player;
			Lock = InputSourceIdentifier.DefaultInputSource.SetInputLock(PlayerID, PlayerLockState.NonPause);
			LeaveCurrentMenu(do_not_close: true);
			Panel.SetColour(PlayerID);
		}

		private void SetActiveMenu(Type menu_type)
		{
			ModuleList.Clear();
			if (!Menus.TryGetValue(menu_type, out var value))
			{
				CloseEditor();
				return;
			}
			ActiveMenu = menu_type;
			value.SetupWithPlayer(PlayerID);
			Panel.SetColour(PlayerID);
			Panel.SetTarget(ModuleList);
		}

		private void LeaveCurrentMenu(bool do_not_close = false)
		{
			if (!do_not_close && (ActiveMenu == typeof(SelectProfileMenu) || ActiveMenu == typeof(ManageProfileMenu)))
			{
				CloseEditor();
			}
			else
			{
				SetActiveMenu(Players.Main.Get(PlayerID).HasProfile ? typeof(ManageProfileMenu) : typeof(SelectProfileMenu));
			}
		}

		private void CloseEditor()
		{
			IsComplete = true;
			InputSourceIdentifier.DefaultInputSource.ReleaseLock(PlayerID, Lock);
			LocalInputSourceConsumers.Remove(this);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			LocalInputSourceConsumers.Remove(this);
		}

		public InputConsumerState TakeInput(int player_id, InputState state)
		{
			if (PlayerID != 0 && player_id == PlayerID)
			{
				if (state.MenuTrigger == ButtonState.Pressed)
				{
					IsComplete = true;
					InputSourceIdentifier.DefaultInputSource.ReleaseLock(PlayerID, Lock);
					return InputConsumerState.Terminated;
				}
				if (!ModuleList.HandleInteraction(state) && state.MenuCancel == ButtonState.Pressed)
				{
					LeaveCurrentMenu();
				}
				if (!IsComplete)
				{
					return InputConsumerState.Consumed;
				}
				return InputConsumerState.Terminated;
			}
			return InputConsumerState.NotConsumed;
		}

		public override void Remove()
		{
			IsComplete = true;
			InputSourceIdentifier.DefaultInputSource.ReleaseLock(PlayerID, Lock);
			base.Remove();
		}

		public override bool HasStateUpdate(out IResponseData state)
		{
			state = null;
			if (IsComplete)
			{
				state = new ResponseData
				{
					IsComplete = IsComplete
				};
			}
			return IsComplete;
		}
	}
}
