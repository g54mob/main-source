#define ENABLE_PROFILER
using System;
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
using UnityEngine.VFX;

namespace Kitchen
{
	[Serializable]
	public class BlueprintStoreView : UpdatableObjectView<BlueprintStoreView.ViewData>
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

						public LambdaParameterValueProvider_IComponentData<CBlueprintStore>.Runtime runtime_store;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CBlueprintStore> forParameter_store;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_store.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_store = forParameter_store.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [In] ref CBlueprintStore store, [In] ref CLinkedView linked_view)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, in store, in linked_view);
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), ref runtimes.runtime_store.For(i), ref runtimes.runtime_linked_view.For(i));
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, in CBlueprintStore store, in CLinkedView linked_view)
			{
				CCabinetModifier cCabinetModifier = (HasComponent<CCabinetModifier>(entity) ? GetComponent<CCabinetModifier>(entity) : default(CCabinetModifier));
				SendUpdate(linked_view, new ViewData
				{
					InUse = store.InUse,
					Appliance = store.ApplianceID,
					HasUpgradeEvent = store.HasBeenUpgraded,
					HasCopyEvent = store.HasBeenCopied,
					HasMakeFreeEvent = store.HasBeenMadeFree,
					IsUpgrading = cCabinetModifier.Upgrades,
					IsCopying = cCabinetModifier.Duplicates,
					IsMakingFree = cCabinetModifier.MakesFree
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
				EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
				entityQueryDesc.All = new ComponentType[2]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CBlueprintStore>()
				};
				entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CHeldAppliance>() };
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public bool InUse;

			[Key(1)]
			public int Appliance;

			[Key(2)]
			public bool HasUpgradeEvent;

			[Key(3)]
			public bool HasCopyEvent;

			[Key(4)]
			public bool IsUpgrading;

			[Key(5)]
			public bool IsCopying;

			[Key(6)]
			public bool HasMakeFreeEvent;

			[Key(7)]
			public bool IsMakingFree;

			public bool IsChangedFrom(ViewData check)
			{
				if (InUse == check.InUse && Appliance == check.Appliance && HasUpgradeEvent == check.HasUpgradeEvent && HasCopyEvent == check.HasCopyEvent && HasMakeFreeEvent == check.HasMakeFreeEvent && IsUpgrading == check.IsUpgrading && IsCopying == check.IsCopying)
				{
					return IsMakingFree != check.IsMakingFree;
				}
				return true;
			}

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<BlueprintStoreView>();
			}
		}

		[SerializeField]
		[Header("References")]
		private Animator Animator;

		[SerializeField]
		private TextMeshPro Title;

		[SerializeField]
		private MeshRenderer Renderer;

		[SerializeField]
		private VisualEffect MakeFreeEffect;

		[SerializeField]
		private GameObject IsMakingFree;

		[SerializeField]
		private VisualEffect UpgradeEffect;

		[SerializeField]
		private GameObject IsUpgrading;

		[SerializeField]
		private VisualEffect CopyEffect;

		[SerializeField]
		private GameObject IsCopying;

		[SerializeField]
		private GameObject CopyBlueprint;

		[SerializeField]
		private TextMeshPro CopyTitle;

		[SerializeField]
		private MeshRenderer CopyRenderer;

		[SerializeField]
		private MeshRenderer CopyBlueprintMaterial;

		[Header("State")]
		private ViewData Data;

		private static readonly int IsActive = Animator.StringToHash("IsActive");

		protected override void UpdateData(ViewData view_data)
		{
			if (IsUpgrading != null)
			{
				IsUpgrading.SetActive(view_data.IsUpgrading);
			}
			if (IsMakingFree != null)
			{
				IsMakingFree.SetActive(view_data.IsMakingFree);
			}
			if (IsCopying != null)
			{
				IsCopying.SetActive(view_data.IsCopying);
			}
			if (CopyRenderer != null)
			{
				RegisterDisposable(CopyRenderer.material).SetFloat("_IsBlowout", 1f);
			}
			if (CopyBlueprintMaterial != null)
			{
				RegisterDisposable(CopyBlueprintMaterial.material).SetFloat("_IsCopy", 1f);
			}
			CopyBlueprint.SetActive(view_data.HasCopyEvent);
			if (!view_data.InUse)
			{
				Animator.SetBool(IsActive, value: false);
				return;
			}
			Animator.SetBool(IsActive, value: true);
			if (Data.Appliance != view_data.Appliance && GameData.Main.TryGet<Appliance>(view_data.Appliance, out var output))
			{
				if (Renderer != null)
				{
					RegisterDisposable(Renderer.material).SetTexture("_Image", PrefabSnapshot.GetSnapshot(output.Prefab));
				}
				if (Title != null)
				{
					Title.text = output.Name;
				}
				if (CopyRenderer != null)
				{
					RegisterDisposable(CopyRenderer.material).SetTexture("_Image", PrefabSnapshot.GetSnapshot(output.Prefab));
				}
				if (CopyTitle != null)
				{
					CopyTitle.text = output.Name;
				}
			}
			if (!Data.HasUpgradeEvent && view_data.HasUpgradeEvent)
			{
				UpgradeEffect.SendEvent("Burst");
			}
			if (!Data.HasCopyEvent && view_data.HasCopyEvent)
			{
				CopyEffect.SendEvent("BurstCopy");
			}
			if (!Data.HasMakeFreeEvent && view_data.HasMakeFreeEvent)
			{
				MakeFreeEffect.SendEvent("BurstMakeFree");
			}
			Data = view_data;
		}
	}
}
