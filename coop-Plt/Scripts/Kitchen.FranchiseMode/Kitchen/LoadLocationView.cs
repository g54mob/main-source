#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using MessagePack;
using Shapes;
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
	public class LoadLocationView : UpdatableObjectView<LoadLocationView.ViewData>
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

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_view;

						public LambdaParameterValueProvider_IComponentData<CLocationChoice>.Runtime runtime_choice;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLocationChoice> forParameter_choice;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_choice.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_view = forParameter_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_choice = forParameter_choice.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [In] ref CLinkedView view, [In] ref CLocationChoice choice)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, in view, in choice);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_view.For(i), ref runtimes.runtime_choice.For(i));
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, in CLinkedView view, in CLocationChoice choice)
			{
				SendUpdate(view.Identifier, new ViewData
				{
					State = choice.State,
					RestaurantName = choice.RestaurantName.ToString(),
					RestaurantSafeName = choice.RestaurantSafeName.ToString(),
					Setting = choice.Setting,
					Selected = (TryGetSingleton<SSelectedLocation>(out var value) && value.Valid && value.Selected.Slot == choice.Slot),
					Day = choice.Day,
					Slot = choice.Slot,
					FranchiseTier = choice.FranchiseTier,
					BeingLookedAt = Has<CBeingLookedAt>(entity)
				}, MessageType.SpecificViewUpdate);
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
					ComponentType.ReadOnly<CLocationChoice>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public SaveState State;

			[Key(1)]
			public string RestaurantName;

			[Key(2)]
			public string RestaurantSafeName;

			[Key(3)]
			public int Setting;

			[Key(4)]
			public bool Selected;

			[Key(5)]
			public int Day;

			[Key(6)]
			public int Slot;

			[Key(7)]
			public int FranchiseTier;

			[Key(8)]
			public bool BeingLookedAt;

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<LoadLocationView>();
			}

			public bool IsChangedFrom(ViewData check)
			{
				if (State == check.State && !(RestaurantName != check.RestaurantName) && Selected == check.Selected && Day == check.Day && Setting == check.Setting && Slot == check.Slot && FranchiseTier == check.FranchiseTier)
				{
					return BeingLookedAt != check.BeingLookedAt;
				}
				return true;
			}
		}

		public float NotLookedAtScale = 1.1f;

		public float BeingLookedAtScale = 1.7f;

		[Header("References")]
		[SerializeField]
		private TextMeshPro LoadedLabel;

		[SerializeField]
		private GameObject LoadedContainer;

		[SerializeField]
		private TextMeshPro EmptyLabel;

		[SerializeField]
		private GameObject EmptyContainer;

		[SerializeField]
		private GameObject FailedContainer;

		[SerializeField]
		private TextMeshPro FailedLabel;

		[SerializeField]
		private TextMeshPro DayLabel;

		[SerializeField]
		private GameObject DayObject;

		[SerializeField]
		private GameObject TierObject;

		[SerializeField]
		private GameObject SelectedSnowglobe;

		[SerializeField]
		private TextMeshPro TierLabel;

		[SerializeField]
		private List<GameObject> SlotSnowglobePositions = new List<GameObject>();

		[SerializeField]
		private Disc Disc;

		[SerializeField]
		[ColorUsage(true, true)]
		private Color InactiveColour;

		[SerializeField]
		[ColorUsage(true, true)]
		private Color SelectedColour;

		[SerializeField]
		[ColorUsage(true, true)]
		private Color EmptyColour;

		[ColorUsage(true, true)]
		[SerializeField]
		private Color FailedColour;

		[SerializeField]
		private GameObject SnowGlobeContainer;

		[Header("State")]
		private GameObject SnowGlobe;

		private ViewData Data;

		private const int OvertimeDay = 15;

		protected override void UpdateData(ViewData data)
		{
			ViewData data2 = Data;
			Data = data;
			if (DayObject != null)
			{
				DayObject.transform.localScale = Vector3.one * (data.BeingLookedAt ? BeingLookedAtScale : NotLookedAtScale);
			}
			if (TierObject != null)
			{
				TierObject.transform.localScale = Vector3.one * (data.BeingLookedAt ? BeingLookedAtScale : NotLookedAtScale);
			}
			if (SlotSnowglobePositions != null && data.Slot - 1 < SlotSnowglobePositions.Count && SnowGlobeContainer != null)
			{
				SnowGlobeContainer.transform.localPosition = SlotSnowglobePositions[data.Slot - 1].transform.localPosition;
			}
			if ((bool)Disc)
			{
				Disc disc = Disc;
				disc.Color = data.State switch
				{
					SaveState.Empty => data.Selected ? SelectedColour : EmptyColour, 
					SaveState.Loaded => InactiveColour, 
					SaveState.Failed => FailedColour, 
					_ => EmptyColour, 
				};
			}
			SelectedSnowglobe.SetActive(data.State == SaveState.Empty && data.Selected);
			switch (data.State)
			{
			case SaveState.Loaded:
				LoadedContainer.SetActive(value: true);
				EmptyContainer.SetActive(value: false);
				FailedContainer.SetActive(value: false);
				DayObject.SetActive(data.Day > 0);
				DayLabel.SetText(data.Day.ToString());
				TierObject.SetActive(data.FranchiseTier > 0);
				TierLabel.SetText(data.FranchiseTier.ToString());
				HandleNameChange(data.RestaurantName, data.Slot);
				break;
			case SaveState.Empty:
				if (data.Selected)
				{
					EmptyLabel.SetText(base.Localisation["LABEL_LOCATION_ACTIVE"]);
				}
				else
				{
					EmptyLabel.SetText("");
				}
				LoadedContainer.SetActive(value: false);
				EmptyContainer.SetActive(value: true);
				FailedContainer.SetActive(value: false);
				TierObject.SetActive(value: false);
				DayObject.SetActive(value: false);
				break;
			case SaveState.Failed:
				FailedLabel.SetText(base.Localisation["LABEL_LOCATION_FAILED"]);
				LoadedContainer.SetActive(value: false);
				EmptyContainer.SetActive(value: false);
				FailedContainer.SetActive(value: true);
				TierObject.SetActive(value: false);
				DayObject.SetActive(value: false);
				break;
			}
			if (!GameData.Main.TryGet<RestaurantSetting>(data.Setting, out var output))
			{
				if (SnowGlobe != null)
				{
					UnityEngine.Object.Destroy(SnowGlobe);
				}
			}
			else if (data2.Setting != Data.Setting)
			{
				if (SnowGlobe != null)
				{
					UnityEngine.Object.Destroy(SnowGlobe);
				}
				if (!(output.Prefab == null))
				{
					SnowGlobe = UnityEngine.Object.Instantiate(output.Prefab);
					SnowGlobe.transform.parent = SnowGlobeContainer.transform;
					SnowGlobe.transform.Reset();
				}
			}
		}

		private void HandleNameChange(string name, int slot)
		{
			Data.RestaurantName = name;
			LoadedLabel.SetText(Data.RestaurantName);
		}
	}
}
