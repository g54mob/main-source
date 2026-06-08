#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Linq;
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
	public class NewsItemView : UpdatableObjectView<NewsItemView.ViewData>
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

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						public LambdaParameterValueProvider_IComponentData<CNewsItem>.Runtime runtime_selector;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CNewsItem> forParameter_selector;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_selector.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_selector = forParameter_selector.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [In] ref CLinkedView linked_view, [In] ref CNewsItem selector)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, in linked_view, in selector);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_linked_view.For(i), ref runtimes.runtime_selector.For(i));
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CNewsItem selector)
			{
				bool active = HasComponent<CNewsItemActive>(entity);
				CExpChange expChange = ((selector.Type == NewsItemType.LevelProgress) ? GetComponent<CExpChange>(entity) : default(CExpChange));
				SendUpdate(linked_view, new ViewData
				{
					RewardID = selector.Reward,
					Type = selector.Type,
					Active = active,
					ExpChange = expChange,
					Reason = selector.LossReason
				});
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
					ComponentType.ReadOnly<CNewsItem>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int RewardID;

			[Key(1)]
			public NewsItemType Type;

			[Key(2)]
			public bool Active;

			[Key(3)]
			public CExpChange ExpChange;

			[Key(4)]
			public LossReason Reason;

			public bool IsChangedFrom(ViewData check)
			{
				if (RewardID == check.RewardID && Type == check.Type && Active == check.Active)
				{
					return Reason != check.Reason;
				}
				return true;
			}
		}

		[Serializable]
		public struct EffectLookup
		{
			public NewsItemType Type;

			public GameObject Prefab;
		}

		[Header("References")]
		[SerializeField]
		private AnimationCurve MovementCurve;

		[SerializeField]
		private Transform Container;

		[SerializeField]
		private List<EffectLookup> Containers = new List<EffectLookup>();

		[SerializeField]
		private Animator Animator;

		[Header("State")]
		private int RewardItem;

		private Vector3 TargetPosition;

		private Vector3 BasePosition;

		private float MovementTransitionTime;

		private GameObject ActiveContainer;

		private static readonly int IsActive = Animator.StringToHash("IsActive");

		public override void SetPosition(UpdateViewPositionData pos)
		{
			Transform transform = base.transform;
			BasePosition = transform.localPosition;
			TargetPosition = pos.Position;
			MovementTransitionTime = Time.unscaledTime;
			transform.localRotation = pos.Rotation;
		}

		protected override void UpdatePosition()
		{
		}

		private void Update()
		{
			float num = Time.unscaledTime - MovementTransitionTime;
			if (num <= 1f)
			{
				base.transform.localPosition = BasePosition + MovementCurve.Evaluate(Mathf.Clamp01(num)) * (TargetPosition - BasePosition);
			}
		}

		protected override void UpdateData(ViewData view_data)
		{
			RewardItem = view_data.RewardID;
			if (ActiveContainer == null)
			{
				ActiveContainer = UnityEngine.Object.Instantiate(Containers.First((EffectLookup e) => e.Type == view_data.Type).Prefab);
				ActiveContainer.transform.parent = Container;
				ActiveContainer.transform.localPosition = Vector3.zero;
				PurgeComponentCache();
			}
			if (ActiveContainer != null)
			{
				if (ActiveContainer.TryGetComponent<INewsItemSubview>(out var component))
				{
					if (component is LevelProgressSubview levelProgressSubview && view_data.Active)
					{
						levelProgressSubview.SetChange(view_data.ExpChange);
					}
					if (component is NewspaperSubview newspaperSubview)
					{
						newspaperSubview.SetLossReason(view_data.Reason);
					}
					component.SetItem(view_data.RewardID);
				}
				if (ActiveContainer.TryGetComponent<Animator>(out var component2))
				{
					component2.SetBool(IsActive, view_data.Active);
				}
			}
			if ((bool)Animator)
			{
				Animator.SetBool(IsActive, view_data.Active);
			}
		}
	}
}
