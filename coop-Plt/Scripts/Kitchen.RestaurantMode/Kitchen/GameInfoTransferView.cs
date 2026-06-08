#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
	public class GameInfoTransferView : UpdatableObjectView<GameInfoTransferView.ViewData>
	{
		public class UpdateView : IncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass5_0
			{
				public UpdateView _003C_003E4__this;

				public DataObjectList dish_ids;

				public DataObjectList upgrade_ids;

				public SceneType scene_type;

				public Bounds bounds;

				internal void _003COnUpdate_003Eb__0(Entity entity, in SGameInfoTransferView recipe, in CLinkedView linked_view)
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

						public LambdaParameterValueProvider_IComponentData_Tag<SGameInfoTransferView>.Runtime runtime_recipe;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData_Tag<SGameInfoTransferView> forParameter_recipe;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_recipe.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_recipe = forParameter_recipe.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView _003C_003E4__this;

				public DataObjectList dish_ids;

				public DataObjectList upgrade_ids;

				public SceneType scene_type;

				public Bounds bounds;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, in SGameInfoTransferView recipe, in CLinkedView linked_view)
				{
					_003C_003E4__this.SendUpdate(linked_view, new ViewData
					{
						Unlocks = dish_ids,
						Upgrades = upgrade_ids,
						CurrentScene = scene_type,
						CurrentGameplayBounds = bounds
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass5_0 displayClass)
				{
					_003C_003E4__this = displayClass._003C_003E4__this;
					dish_ids = displayClass.dish_ids;
					upgrade_ids = displayClass.upgrade_ids;
					scene_type = displayClass.scene_type;
					bounds = displayClass.bounds;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass5_0 displayClass)
				{
					displayClass._003C_003E4__this = _003C_003E4__this;
					displayClass.dish_ids = dish_ids;
					displayClass.upgrade_ids = upgrade_ids;
					displayClass.scene_type = scene_type;
					displayClass.bounds = bounds;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_recipe.For(i), in runtimes.runtime_linked_view.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass5_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery Unlocks;

			private EntityQuery Upgrades;

			private List<int> UnlockList = new List<int>();

			private List<int> UpgradeList = new List<int>();

			private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

			[ReadOnly]
			private EntityQuery _SingletonEntityQuery_SCurrentScene_50;

			protected override void Initialise()
			{
				base.Initialise();
				Unlocks = GetEntityQuery(typeof(CProgressionUnlock));
				Upgrades = GetEntityQuery(typeof(CDishUpgrade));
			}

			protected override void OnUpdate()
			{
				_003C_003Ec__DisplayClass5_0 displayClass = new _003C_003Ec__DisplayClass5_0
				{
					_003C_003E4__this = this
				};
				if (!HasSingleton<SGameInfoTransferView>())
				{
					Entity entity = base.EntityManager.CreateEntity(typeof(SGameInfoTransferView), typeof(CRequiresView));
					base.EntityManager.SetComponentData(entity, new CRequiresView
					{
						Type = ViewType.RecipeInfo
					});
				}
				displayClass.dish_ids = default(DataObjectList);
				NativeArray<CProgressionUnlock> nativeArray = Unlocks.ToComponentDataArray<CProgressionUnlock>(Allocator.TempJob);
				for (int i = 0; i < nativeArray.Length; i++)
				{
					if (nativeArray[i].IsActive)
					{
						displayClass.dish_ids.Add(nativeArray[i].ID);
					}
				}
				displayClass.upgrade_ids = default(DataObjectList);
				foreach (CDishUpgrade item in Upgrades.ToComponentDataArray<CDishUpgrade>(Allocator.Temp))
				{
					displayClass.upgrade_ids.Add(item.DishID);
				}
				displayClass.scene_type = ((!HasSingleton<SCurrentScene>()) ? SceneType.Franchise : _SingletonEntityQuery_SCurrentScene_50.GetSingleton<SCurrentScene>().Type);
				displayClass.bounds = base.Bounds;
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
				nativeArray.Dispose();
			}

			protected internal unsafe override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
				_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
				_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
				_SingletonEntityQuery_SCurrentScene_50 = GetEntityQuery(ComponentType.ReadOnly<SCurrentScene>());
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<SGameInfoTransferView>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public DataObjectList Unlocks;

			[Key(1)]
			public DataObjectList Upgrades;

			[Key(2)]
			public SceneType CurrentScene;

			[Key(3)]
			public Bounds CurrentGameplayBounds;

			public bool IsChangedFrom(ViewData check)
			{
				if (CurrentScene != check.CurrentScene)
				{
					return true;
				}
				if (CurrentGameplayBounds != check.CurrentGameplayBounds)
				{
					return true;
				}
				if (check.Unlocks.Count != Unlocks.Count)
				{
					return true;
				}
				if (check.Upgrades.Count != Upgrades.Count)
				{
					return true;
				}
				for (int i = 0; i < check.Unlocks.Count; i++)
				{
					if (check.Unlocks[i] != Unlocks[i])
					{
						return true;
					}
				}
				for (int j = 0; j < check.Upgrades.Count; j++)
				{
					if (check.Upgrades[j] != Upgrades[j])
					{
						return true;
					}
				}
				return false;
			}
		}

		protected override void UpdateData(ViewData view_data)
		{
			GameInfo.CurrentlyAvailableDishes.Clear();
			GameInfo.AllCurrentCards.Clear();
			GameInfo.DishUpgrades.Clear();
			GameInfo.CurrentGameplayBounds = view_data.CurrentGameplayBounds;
			GameInfo.CurrentScene = view_data.CurrentScene;
			foreach (int unlock in view_data.Unlocks)
			{
				if (GameData.Main.TryGet<Dish>(unlock, out var output))
				{
					GameInfo.CurrentlyAvailableDishes.Add(output);
				}
				if (GameData.Main.TryGet<ICard>(unlock, out var output2))
				{
					GameInfo.AllCurrentCards.Add(output2);
				}
			}
			foreach (int upgrade in view_data.Upgrades)
			{
				if (GameData.Main.TryGet<Dish>(upgrade, out var output3))
				{
					GameInfo.DishUpgrades.Add(output3);
				}
			}
		}
	}
}
