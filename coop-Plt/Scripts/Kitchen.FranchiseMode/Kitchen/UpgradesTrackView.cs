#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
	public class UpgradesTrackView : UpdatableObjectView<UpgradesTrackView.ViewData>
	{
		public class UpdateView : IncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass0_0
			{
				public UpdateView _003C_003E4__this;

				public int current_level;

				internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, in CLinkedView view, in CUpgradesTracker xp)
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

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_view;

						public LambdaParameterValueProvider_IComponentData_Tag<CUpgradesTracker>.Runtime runtime_xp;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData_Tag<CUpgradesTracker> forParameter_xp;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_xp.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_view = forParameter_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_xp = forParameter_xp.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView _003C_003E4__this;

				public int current_level;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView view, in CUpgradesTracker xp)
				{
					_003C_003E4__this.SendUpdate(view.Identifier, new ViewData
					{
						Level = current_level
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					_003C_003E4__this = displayClass._003C_003E4__this;
					current_level = displayClass.current_level;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					displayClass._003C_003E4__this = _003C_003E4__this;
					displayClass.current_level = current_level;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_view.For(i), runtimes.runtime_xp.For(i));
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
					current_level = GetOrDefault<SPlayerLevel>().Level
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
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CUpgradesTracker>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int Level;

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<UpgradesTrackView>();
			}

			public bool IsChangedFrom(ViewData check)
			{
				return Level != check.Level;
			}
		}

		public struct LevelObject
		{
			public int Level;

			public GameObject Locked;

			public GameObject Unlocked;
		}

		[Header("References")]
		[SerializeField]
		private TextMeshPro DishesLabel;

		[SerializeField]
		private TextMeshPro LayoutsLabel;

		[SerializeField]
		private List<LevelObject> DishObjects = new List<LevelObject>();

		[SerializeField]
		private List<LevelObject> LayoutsObjects = new List<LevelObject>();

		[SerializeField]
		private LayoutSampleView LayoutProfileTemplate;

		[SerializeField]
		private GameObject LayoutProfileTemplateLocked;

		[SerializeField]
		private DishChoiceView DishTemplate;

		[SerializeField]
		private GameObject DishTemplateLocked;

		[SerializeField]
		private Vector3 DishStart;

		[SerializeField]
		private Vector3 DishOffsetRow;

		[SerializeField]
		private Vector3 DishOffsetColumn;

		[SerializeField]
		private int DishesPerRow;

		[SerializeField]
		private Vector3 LayoutStart;

		[SerializeField]
		private Vector3 LayoutOffsetRow;

		[SerializeField]
		private Vector3 LayoutOffsetColumn;

		[SerializeField]
		private int LayoutsPerRow;

		private bool IsInitialised;

		protected void Setup(List<LevelUpgradeSet> level_sets)
		{
			DishTemplate.GameObject.SetActive(value: false);
			DishTemplateLocked.SetActive(value: false);
			LayoutProfileTemplate.gameObject.SetActive(value: false);
			LayoutProfileTemplateLocked.SetActive(value: false);
			int num = 0;
			int num2 = 0;
			foreach (LevelUpgradeSet level_set in level_sets)
			{
				foreach (LevelUpgrade upgrade2 in level_set.Upgrades)
				{
					IUpgrade upgrade = upgrade2.Upgrade;
					if (!(upgrade is Dish dish))
					{
						if (upgrade is LayoutProfile profile)
						{
							Vector3 localPosition = LayoutStart + LayoutOffsetRow * (num2 % LayoutsPerRow) + LayoutOffsetColumn * (num2 / LayoutsPerRow);
							LayoutSampleView layoutSampleView = UnityEngine.Object.Instantiate(LayoutProfileTemplate);
							layoutSampleView.transform.parent = LayoutProfileTemplate.transform.parent;
							layoutSampleView.transform.localPosition = localPosition;
							layoutSampleView.UpdateBlueprint(profile);
							layoutSampleView.transform.localScale = Vector3.one;
							GameObject gameObject = UnityEngine.Object.Instantiate(LayoutProfileTemplateLocked);
							gameObject.transform.parent = LayoutProfileTemplateLocked.transform.parent;
							gameObject.transform.localPosition = localPosition;
							gameObject.transform.localScale = Vector3.one;
							DishObjects.Add(new LevelObject
							{
								Level = upgrade2.Level,
								Locked = gameObject,
								Unlocked = layoutSampleView.gameObject
							});
							num2++;
						}
					}
					else
					{
						Vector3 localPosition2 = DishStart + DishOffsetRow * (num % DishesPerRow) + DishOffsetColumn * (num / DishesPerRow);
						DishChoiceView dishChoiceView = UnityEngine.Object.Instantiate(DishTemplate);
						dishChoiceView.transform.parent = DishTemplate.transform.parent;
						dishChoiceView.transform.localPosition = localPosition2;
						dishChoiceView.UpdateData(new DishChoiceView.ViewData
						{
							Dish = dish.ID
						});
						dishChoiceView.transform.localScale = Vector3.one;
						GameObject gameObject2 = UnityEngine.Object.Instantiate(DishTemplateLocked);
						gameObject2.transform.parent = DishTemplateLocked.transform.parent;
						gameObject2.transform.localPosition = localPosition2;
						gameObject2.transform.localScale = Vector3.one;
						DishObjects.Add(new LevelObject
						{
							Level = upgrade2.Level,
							Locked = gameObject2,
							Unlocked = dishChoiceView.gameObject
						});
						num++;
					}
				}
			}
		}

		protected override void UpdateData(ViewData data)
		{
			List<LevelUpgradeSet> level_sets = GameData.Main.Get<LevelUpgradeSet>().ToList();
			if (!IsInitialised)
			{
				IsInitialised = true;
				Setup(level_sets);
			}
			(int, int) tuple = Count<Dish>(level_sets, data.Level);
			foreach (LevelObject dishObject in DishObjects)
			{
				bool flag = dishObject.Level > data.Level;
				dishObject.Locked.SetActive(flag);
				dishObject.Unlocked.SetActive(!flag);
			}
			if (DishesLabel != null)
			{
				DishesLabel.text = $"{tuple.Item1}/{tuple.Item2}";
			}
			(int, int) tuple2 = Count<LayoutProfile>(level_sets, data.Level);
			foreach (LevelObject layoutsObject in LayoutsObjects)
			{
				bool flag2 = layoutsObject.Level > data.Level;
				layoutsObject.Locked.SetActive(flag2);
				layoutsObject.Unlocked.SetActive(!flag2);
			}
			if (LayoutsLabel != null)
			{
				LayoutsLabel.text = $"{tuple2.Item1}/{tuple2.Item2}";
			}
		}

		public (int, int) Count<T>(List<LevelUpgradeSet> level_sets, int level)
		{
			int num = 0;
			int num2 = 0;
			foreach (LevelUpgradeSet level_set in level_sets)
			{
				foreach (LevelUpgrade upgrade2 in level_set.Upgrades)
				{
					IUpgrade upgrade = upgrade2.Upgrade;
					if (upgrade is T)
					{
						_ = (T)upgrade;
						num++;
						if (upgrade2.Level <= level)
						{
							num2++;
						}
					}
				}
			}
			return (num2, num);
		}
	}
}
