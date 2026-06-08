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
using UnityEngine.Animations.Rigging;

namespace Kitchen
{
	[Serializable]
	public class PlayerHoldingSubview : UpdatableObjectView<PlayerHoldingSubview.ViewData>
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

						public LambdaParameterValueProvider_IComponentData<CItemHolder>.Runtime runtime_holding;

						public LambdaParameterValueProvider_IComponentData<CToolUser>.Runtime runtime_tool_user;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CItemHolder> forParameter_holding;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CToolUser> forParameter_tool_user;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_holding.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_tool_user.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_holding = forParameter_holding.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_tool_user = forParameter_tool_user.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [In] ref CLinkedView linked_view, [In] ref CItemHolder holding, [In] ref CToolUser tool_user)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, in linked_view, in holding, in tool_user);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_linked_view.For(i), ref runtimes.runtime_holding.For(i), ref runtimes.runtime_tool_user.For(i));
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CItemHolder holding, in CToolUser tool_user)
			{
				ViewData update = default(ViewData);
				if (Require<CItem>(tool_user.CurrentTool, out CItem comp))
				{
					update.UsingToolID = comp.ID;
				}
				if (HasComponent<CAttemptingInteraction>(entity))
				{
					CAttemptingInteraction component = GetComponent<CAttemptingInteraction>(entity);
					update.IsInteracting = component.Result == InteractionResult.Performed && component.Type == InteractionType.Act;
					update.IsReadyToInteract = component.Result != InteractionResult.None;
				}
				update.IsHolding = holding.HeldItem != default(Entity);
				if (HasComponent<CItem>(holding))
				{
					update.HeldItemID = GetComponent<CItem>(holding).ID;
				}
				SendUpdate(linked_view, update);
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
					ComponentType.ReadOnly<CPlayer>(),
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CItemHolder>(),
					ComponentType.ReadOnly<CToolUser>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public bool IsReadyToInteract;

			[Key(1)]
			public bool IsInteracting;

			[Key(2)]
			public int HeldItemID;

			[Key(3)]
			public int UsingToolID;

			[Key(4)]
			public bool IsHolding;

			public bool IsChangedFrom(ViewData check)
			{
				if (IsReadyToInteract == check.IsReadyToInteract && HeldItemID == check.HeldItemID && IsInteracting == check.IsInteracting && UsingToolID == check.UsingToolID)
				{
					return IsHolding != check.IsHolding;
				}
				return true;
			}

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<PlayerHoldingSubview>();
			}
		}

		[Header("References")]
		[SerializeField]
		private List<PosedConstraint> Constraints;

		[SerializeField]
		private TwoBoneIKConstraint PrimaryHandConstraint;

		[SerializeField]
		private List<Transform> StoragePositions = new List<Transform>();

		[SerializeField]
		private Animator Animator;

		[SerializeField]
		private GameObject ToolContainer;

		[Header("State")]
		private List<IObjectView> StorageItems = new List<IObjectView>();

		private ToolAttachPoint HoldPose;

		private ViewData Data;

		private bool UseHoldPose;

		private IObjectView CurrentTool;

		private static readonly int IsHolding = Animator.StringToHash("IsHolding");

		private static readonly int IsReadyToInteract = Animator.StringToHash("IsReadyToInteract");

		private static readonly int IsInteracting = Animator.StringToHash("IsInteracting");

		public override void Initialise()
		{
			base.Initialise();
			foreach (Transform storagePosition in StoragePositions)
			{
				_ = storagePosition;
				StorageItems.Add(null);
			}
		}

		private void Update()
		{
			if ((bool)Animator)
			{
				Animator.SetBool(IsHolding, UseHoldPose);
				Animator.SetBool(IsReadyToInteract, Data.IsReadyToInteract);
				Animator.SetBool(IsInteracting, Data.IsInteracting);
			}
		}

		protected override void UpdateData(ViewData view_data)
		{
			ViewData data = Data;
			Data = view_data;
			if (data.UsingToolID != Data.UsingToolID || data.HeldItemID != Data.HeldItemID || data.IsHolding != Data.IsHolding)
			{
				SetHoldPose(Data.UsingToolID, Data.IsHolding);
			}
		}

		private void CreateTool(int tool_id)
		{
			if ((bool)ToolContainer)
			{
				if (tool_id == 0 || !GameData.Main.TryGet<Item>(tool_id, out var output))
				{
					ToolContainer.SetActive(value: false);
					return;
				}
				GameObject toolContainer = ToolContainer;
				GameObject gameObject = UnityEngine.Object.Instantiate(output.Prefab, toolContainer.transform.parent, worldPositionStays: true);
				gameObject.transform.position = toolContainer.transform.position;
				gameObject.transform.rotation = toolContainer.transform.rotation;
				gameObject.transform.localScale = toolContainer.transform.localScale;
				gameObject.SetActive(value: true);
				ToolContainer = gameObject;
				UnityEngine.Object.Destroy(toolContainer);
			}
		}

		private void SetHoldPose(int tool_id, bool is_holding)
		{
			UseHoldPose = is_holding;
			if (tool_id != 0 && GameData.Main.TryGet<Item>(tool_id, out var output, warn_if_fail: true) && output.HoldPose != ToolAttachPoint.NoPose)
			{
				UseHoldPose |= !output.HoldPose.HasFreeHand();
				SetHoldPose(output.HoldPose);
			}
			else
			{
				SetHoldPose(ToolAttachPoint.Generic);
			}
		}

		public override void SetHeldItem(IObjectView held_item, int storage_index, bool is_tool)
		{
			if (storage_index >= 0)
			{
				PlaceItemIntoStorage(held_item, storage_index);
			}
			else if (is_tool)
			{
				if ((bool)ToolContainer && held_item != CurrentTool)
				{
					if ((MonoBehaviour)CurrentTool != null && CurrentTool.GameObject.transform.parent == ToolContainer.transform)
					{
						CurrentTool.ParentDestroyed();
					}
					held_item?.SetParent(ToolContainer.transform);
					CurrentTool = held_item;
				}
			}
			else
			{
				base.SetHeldItem(held_item, storage_index, is_tool);
			}
		}

		public bool PlaceItemIntoStorage(IObjectView obj, int index)
		{
			if (index < 0 || index >= StorageItems.Count)
			{
				return false;
			}
			IObjectView objectView = StorageItems[index];
			if (obj != objectView)
			{
				if ((MonoBehaviour)objectView != null && objectView.GameObject.transform.parent == StoragePositions[index])
				{
					objectView.ParentDestroyed();
				}
				obj?.SetParent(StoragePositions[index]);
				StorageItems[index] = obj;
			}
			return true;
		}

		private void SetHoldPose(ToolAttachPoint hold_pose)
		{
			HoldPose = hold_pose;
			if ((bool)PrimaryHandConstraint)
			{
				PrimaryHandConstraint.weight = ((!HoldPose.HasFreeHand()) ? 1 : 0);
			}
			foreach (PosedConstraint constraint in Constraints)
			{
				constraint.SetPose(hold_pose);
			}
		}
	}
}
