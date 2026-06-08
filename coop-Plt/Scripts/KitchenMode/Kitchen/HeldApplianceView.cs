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
	public class HeldApplianceView : UpdatableObjectView<HeldApplianceView.ViewData>
	{
		public class UpdateHeldApplianceView : IncrementalViewSystemBase<ViewData>
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

						public LambdaParameterValueProvider_IComponentData_Tag<CHeldAppliance>.Runtime runtime_item;

						public LambdaParameterValueProvider_IComponentData<CAppliance>.Runtime runtime_appliance;

						public LambdaParameterValueProvider_IComponentData<CHeldBy>.Runtime runtime_holder;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData_Tag<CHeldAppliance> forParameter_item;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CAppliance> forParameter_appliance;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CHeldBy> forParameter_holder;

					public void ScheduleTimeInitialize(UpdateHeldApplianceView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_item.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_appliance.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_holder.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_item = forParameter_item.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_appliance = forParameter_appliance.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_holder = forParameter_holder.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateHeldApplianceView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [In] ref CLinkedView linked_view, [In] ref CHeldAppliance item, [In] ref CAppliance appliance, [In] ref CHeldBy holder)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, in linked_view, in item, in appliance, in holder);
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
						Entity entity = runtimes.runtime_entity.For(i);
						int entityInQueryIndex = runtimes.runtime_entityInQueryIndex.For(i);
						ref CLinkedView linked_view = ref runtimes.runtime_linked_view.For(i);
						CHeldAppliance item = runtimes.runtime_item.For(i);
						OriginalLambdaBody(entity, entityInQueryIndex, ref linked_view, ref item, ref runtimes.runtime_appliance.For(i), ref runtimes.runtime_holder.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateHeldApplianceView componentSystem)
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CHeldAppliance item, in CAppliance appliance, in CHeldBy holder)
			{
				int drawUsing = 0;
				if (HasComponent<CDrawApplianceUsing>(entity))
				{
					drawUsing = GetComponent<CDrawApplianceUsing>(entity).DrawApplianceID;
				}
				SendUpdate(linked_view, new ViewData
				{
					ID = appliance.ID,
					DrawUsing = drawUsing
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
				(array[0] = new EntityQueryDesc()).All = new ComponentType[4]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CHeldAppliance>(),
					ComponentType.ReadOnly<CAppliance>(),
					ComponentType.ReadOnly<CHeldBy>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int ID;

			[Key(1)]
			public int DrawUsing;

			public bool IsChangedFrom(ViewData check)
			{
				if (ID == check.ID)
				{
					return DrawUsing == check.DrawUsing;
				}
				return false;
			}
		}

		[SerializeField]
		[Header("References")]
		private GameObject Container;

		[SerializeField]
		private GameObject DefaultContainer;

		[SerializeField]
		private List<Renderer> IconRenderers;

		[Header("State")]
		private ViewData Data;

		private static readonly int Image = Shader.PropertyToID("_Image");

		protected override void UpdateData(ViewData view_data)
		{
			ViewData data = Data;
			Data = view_data;
			if (Data.ID == data.ID && Data.DrawUsing == data.DrawUsing)
			{
				return;
			}
			if (GameData.Main.TryGet<Appliance>(Data.ID, out var output))
			{
				if (output.HeldAppliancePrefab != null)
				{
					Transform parent = Container.transform.parent;
					if (Container != null)
					{
						UnityEngine.Object.Destroy(Container);
					}
					GameObject original = output.HeldAppliancePrefab;
					if (Data.DrawUsing != 0 && GameData.Main.TryGet<Decor>(Data.DrawUsing, out var output2, warn_if_fail: true))
					{
						original = GameData.Main.DecoratorPrefabView.GetPrefab(output2);
					}
					Container = UnityEngine.Object.Instantiate(original);
					Container.transform.parent = parent;
					Container.transform.localScale = Vector3.one;
					Container.transform.localPosition = Vector3.zero;
					Container.transform.localRotation = Quaternion.identity;
					DefaultContainer.SetActive(value: false);
				}
				else
				{
					foreach (Renderer iconRenderer in IconRenderers)
					{
						RegisterDisposable(iconRenderer.material);
						iconRenderer.material.SetTexture(Image, PrefabSnapshot.GetSnapshot(GameData.Main.GetPrefab(Data.ID)));
					}
					Container.SetActive(value: false);
					DefaultContainer.SetActive(value: true);
				}
			}
			PurgeComponentCache();
		}

		public override void SetPosition(UpdateViewPositionData pos)
		{
		}

		protected override void UpdatePosition()
		{
		}
	}
}
