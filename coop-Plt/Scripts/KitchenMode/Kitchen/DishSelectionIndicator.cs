#define ENABLE_PROFILER
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
	public class DishSelectionIndicator : ResponsiveObjectView<DishSelectionIndicator.ViewData, DishSelectionIndicator.ResponseData>, IInputConsumer
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

						public LambdaParameterValueProvider_IComponentData<CDishSelectionInfo>.Runtime runtime_info;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_view;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					private LambdaParameterValueProvider_IComponentData<CDishSelectionInfo> forParameter_info;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_view;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_info.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_info = forParameter_info.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_view = forParameter_view.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, ref CDishSelectionInfo info, [In] ref CLinkedView view)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, ref info, in view);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_info.For(i), ref runtimes.runtime_view.For(i));
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, ref CDishSelectionInfo info, in CLinkedView view)
			{
				SendUpdate(view.Identifier, new ViewData
				{
					Player = info.Player.PlayerID
				});
				ResponseData result = default(ResponseData);
				if (ApplyUpdates(view.Identifier, delegate(ResponseData data)
				{
					result = data;
				}, only_final_update: true))
				{
					info.IsComplete |= result.IsComplete;
					info.Dish = result.Dish;
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
					ComponentType.ReadWrite<CDishSelectionInfo>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(1)]
			public int Player;

			public bool IsChangedFrom(ViewData check)
			{
				return Player != check.Player;
			}
		}

		[MessagePackObject(false)]
		public struct ResponseData : IResponseData, IViewResponseData
		{
			[Key(0)]
			public bool IsComplete;

			[Key(1)]
			public int Dish;
		}

		private struct MenuStackElement
		{
			public GridMenuConfig Config;

			public int Index;
		}

		[Header("References")]
		[SerializeField]
		private TextMeshPro Title;

		[SerializeField]
		private GridMenuPaginatedGenericConfig RootMenuConfig;

		[SerializeField]
		private Transform Container;

		[Header("State")]
		private GridMenu GridMenu;

		private int PlayerID;

		private InputLock.Lock Lock;

		private bool IsComplete;

		private int ChosenDish;

		private bool IsInitialised;

		private Stack<MenuStackElement> MenuStack = new Stack<MenuStackElement>();

		private void CloseMenu()
		{
			if (MenuStack.Count > 1)
			{
				int index = MenuStack.Pop().Index;
				MenuStackElement menuStackElement = MenuStack.Pop();
				SetNewMenu(menuStackElement.Config, index, menuStackElement.Index);
			}
			else
			{
				Remove();
			}
		}

		private void SetNewMenu(GridMenuConfig menu, int new_index, int previous_index)
		{
			GridMenu?.Destroy();
			GridMenu = menu.Instantiate(Container, PlayerID, MenuStack.Count > 0);
			GridMenu.OnGoBack += CloseMenu;
			GridMenu.OnRequest += HandleRequest;
			GridMenu.SelectByIndex(new_index);
			MenuStack.Push(new MenuStackElement
			{
				Config = menu,
				Index = previous_index
			});
		}

		private void HandleRequest(object obj)
		{
			if (obj is Dish dish)
			{
				ChosenDish = dish.ID;
			}
		}

		protected override void UpdateData(ViewData data)
		{
			if (InputSourceIdentifier.DefaultInputSource != null)
			{
				if (!Players.Main.Get(data.Player).IsLocalUser)
				{
					base.gameObject.SetActive(value: false);
					return;
				}
				base.gameObject.SetActive(value: true);
				InitialiseForPlayer(data.Player);
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
			RootMenuConfig.Items = new List<IGridItem>();
			foreach (Dish dishUpgrade in GameInfo.DishUpgrades)
			{
				RootMenuConfig.Items.Add(new GridItemDish
				{
					Dish = dishUpgrade
				});
			}
			SetNewMenu(RootMenuConfig, 1, 0);
			Lock = InputSourceIdentifier.DefaultInputSource.SetInputLock(PlayerID, PlayerLockState.NonPause);
		}

		public override void Remove()
		{
			IsComplete = true;
			InputSourceIdentifier.DefaultInputSource.ReleaseLock(PlayerID, Lock);
			base.Remove();
		}

		protected override void OnDestroy()
		{
			LocalInputSourceConsumers.Remove(this);
			base.OnDestroy();
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
				if (GridMenu != null && !GridMenu.HandleInteraction(state) && state.MenuCancel == ButtonState.Pressed)
				{
					CloseMenu();
				}
				if (!IsComplete && ChosenDish == 0)
				{
					return InputConsumerState.Consumed;
				}
				return InputConsumerState.Terminated;
			}
			return InputConsumerState.NotConsumed;
		}

		public override bool HasStateUpdate(out IResponseData state)
		{
			state = new ResponseData
			{
				IsComplete = IsComplete,
				Dish = ChosenDish
			};
			if (!IsComplete)
			{
				return ChosenDish != 0;
			}
			return true;
		}
	}
}
