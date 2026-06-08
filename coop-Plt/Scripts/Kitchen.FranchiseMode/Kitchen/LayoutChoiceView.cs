#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kitchen.Layouts;
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
	public class LayoutChoiceView : UpdatableObjectView<LayoutChoiceView.ViewData>
	{
		public class UpdateView : IncrementalViewSystemBase<ViewData>
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

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked;

						public LambdaParameterValueProvider_IComponentData<CItemLayoutMap>.Runtime runtime_layout;

						public LambdaParameterValueProvider_IComponentData<CSetting>.Runtime runtime_setting;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CItemLayoutMap> forParameter_layout;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CSetting> forParameter_setting;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
						forParameter_layout.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_setting.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked = forParameter_linked.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_layout = forParameter_layout.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_setting = forParameter_setting.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, ref CLinkedView linked, [In] ref CItemLayoutMap layout, [In] ref CSetting setting)
				{
					hostInstance._003COnUpdate_003Eb__1_0(entity, entityInQueryIndex, ref linked, in layout, in setting);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_linked.For(i), ref runtimes.runtime_layout.For(i), ref runtimes.runtime_setting.For(i));
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

			private LayoutBlueprint Blueprint;

			private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

			protected override void OnUpdate()
			{
				if (Blueprint == null)
				{
					Blueprint = LayoutBlueprint.New;
				}
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
			private void _003COnUpdate_003Eb__1_0(Entity entity, int entityInQueryIndex, ref CLinkedView linked, in CItemLayoutMap layout, in CSetting setting)
			{
				if (!linked.DoNotUpdate)
				{
					linked.DoNotUpdate = true;
					Blueprint.FromEntity(base.EntityManager, layout.Layout);
					SerialisedLayoutBlueprint blueprint = new SerialisedLayoutBlueprint(Blueprint);
					SendUpdate(linked, new ViewData
					{
						Blueprint = blueprint,
						SettingID = setting.RestaurantSetting,
						Seed = setting.FixedSeed,
						ShowSeed = Has<CShowSeed>(entity)
					}, MessageType.SpecificViewUpdate);
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
					ComponentType.ReadWrite<CLinkedView>(),
					ComponentType.ReadOnly<CItemLayoutMap>(),
					ComponentType.ReadOnly<CSetting>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(1)]
			public SerialisedLayoutBlueprint Blueprint;

			[Key(2)]
			public int SettingID;

			[Key(3)]
			public Seed Seed;

			[Key(4)]
			public bool ShowSeed;

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<LayoutChoiceView>();
			}

			public bool IsChangedFrom(ViewData check)
			{
				if (!(Blueprint != check.Blueprint) && SettingID == check.SettingID && Seed.IntValue == check.Seed.IntValue)
				{
					return ShowSeed != check.ShowSeed;
				}
				return true;
			}
		}

		[Header("References")]
		[SerializeField]
		private MeshRenderer Renderer;

		[SerializeField]
		private TextMeshPro Label;

		[SerializeField]
		private TextMeshPro SeedIcon;

		[SerializeField]
		private SiteView DisplayPrefab;

		[Header("State")]
		private ViewData Data;

		private static readonly int Image = Shader.PropertyToID("_Image");

		protected override void UpdateData(ViewData data)
		{
			Data = data;
			if (GameData.Main.TryGet<RestaurantSetting>(data.SettingID, out var output, warn_if_fail: true))
			{
				Label.text = output.Name;
				if (Renderer != null)
				{
					LayoutBlueprint blueprint = data.Blueprint.Deserialise();
					RegisterDisposable(Renderer.material).SetTexture(Image, PrefabSnapshot.GetLayoutSnapshot(DisplayPrefab, blueprint));
				}
				if (SeedIcon != null)
				{
					SeedIcon.gameObject.SetActive(data.ShowSeed && data.Seed.IsSet);
				}
			}
		}
	}
}
