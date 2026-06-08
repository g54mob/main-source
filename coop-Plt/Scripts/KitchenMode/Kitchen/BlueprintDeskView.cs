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

namespace Kitchen
{
	[Serializable]
	public class BlueprintDeskView : UpdatableObjectView<BlueprintDeskView.ViewData>
	{
		public class UpdateView : IncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass0_0
			{
				public UpdateView _003C_003E4__this;

				public bool show;

				internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, in CGrantsExtraBlueprint grants, in CApplianceDeskIterate iterate, in CLinkedView linked_view)
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

						public LambdaParameterValueProvider_IComponentData<CGrantsExtraBlueprint>.Runtime runtime_grants;

						public LambdaParameterValueProvider_IComponentData<CApplianceDeskIterate>.Runtime runtime_iterate;

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CGrantsExtraBlueprint> forParameter_grants;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CApplianceDeskIterate> forParameter_iterate;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_grants.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_iterate.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_grants = forParameter_grants.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_iterate = forParameter_iterate.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView _003C_003E4__this;

				public bool show;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CGrantsExtraBlueprint grants, in CApplianceDeskIterate iterate, in CLinkedView linked_view)
				{
					_003C_003E4__this.SendUpdate(linked_view, new ViewData
					{
						GrantsBlueprint = grants.ID,
						IsLocked = iterate.IsLocked,
						Show = show
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					_003C_003E4__this = displayClass._003C_003E4__this;
					show = displayClass.show;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					displayClass._003C_003E4__this = _003C_003E4__this;
					displayClass.show = show;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_grants.For(i), in runtimes.runtime_iterate.For(i), in runtimes.runtime_linked_view.For(i));
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
					show = Has<SIsDayTime>()
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
				EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
				entityQueryDesc.All = new ComponentType[3]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CGrantsExtraBlueprint>(),
					ComponentType.ReadOnly<CApplianceDeskIterate>()
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
			public int GrantsBlueprint;

			[Key(1)]
			public bool IsLocked;

			[Key(2)]
			public bool Show;

			public bool IsChangedFrom(ViewData check)
			{
				if (GrantsBlueprint == check.GrantsBlueprint && IsLocked == check.IsLocked)
				{
					return Show != check.Show;
				}
				return true;
			}

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<BlueprintDeskView>();
			}
		}

		[Header("References")]
		[SerializeField]
		private TextMeshPro Title;

		[SerializeField]
		private MeshRenderer Renderer;

		[SerializeField]
		private GameObject LockedIndicator;

		[SerializeField]
		private Animator Animator;

		private static readonly int IsActive = Animator.StringToHash("IsActive");

		protected override void UpdateData(ViewData view_data)
		{
			if (GameData.Main.TryGet<Appliance>(view_data.GrantsBlueprint, out var output))
			{
				Animator.SetBool(IsActive, view_data.Show && !view_data.IsLocked);
				if (Renderer != null)
				{
					RegisterDisposable(Renderer.material).SetTexture("_Image", PrefabSnapshot.GetSnapshot(output.Prefab));
				}
				if (Title != null)
				{
					Title.text = output.Name;
				}
				if (LockedIndicator != null)
				{
					LockedIndicator.SetActive(view_data.IsLocked);
				}
			}
			else
			{
				Animator.SetBool(IsActive, value: true);
			}
		}
	}
}
