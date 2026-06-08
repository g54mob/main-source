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
	public class FranchiseCardSetView : UpdatableObjectView<FranchiseCardSetView.ViewData>
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

						public LambdaParameterValueProvider_IComponentData<SFranchiseSelector>.Runtime runtime_selector;

						public LambdaParameterValueProvider_DynamicBuffer<CAvailableFranchises>.Runtime runtime_franchises;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<SFranchiseSelector> forParameter_selector;

					[ReadOnly]
					private LambdaParameterValueProvider_DynamicBuffer<CAvailableFranchises> forParameter_franchises;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_selector.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_franchises.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked = forParameter_linked.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_selector = forParameter_selector.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_franchises = forParameter_franchises.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView hostInstance;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				public void OriginalLambdaBody(Entity entity, int entityInQueryIndex, [In] ref CLinkedView linked, [In] ref SFranchiseSelector selector, [In] ref DynamicBuffer<CAvailableFranchises> franchises)
				{
					hostInstance._003COnUpdate_003Eb__0_0(entity, entityInQueryIndex, in linked, in selector, in franchises);
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
						ref CLinkedView linked = ref runtimes.runtime_linked.For(i);
						ref SFranchiseSelector selector = ref runtimes.runtime_selector.For(i);
						DynamicBuffer<CAvailableFranchises> franchises = runtimes.runtime_franchises.For(i);
						OriginalLambdaBody(entity, entityInQueryIndex, ref linked, ref selector, ref franchises);
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
			private void _003COnUpdate_003Eb__0_0(Entity entity, int entityInQueryIndex, in CLinkedView linked, in SFranchiseSelector selector, in DynamicBuffer<CAvailableFranchises> franchises)
			{
				if (selector.SelectedFranchise == default(Entity) || !Has<CFranchiseItem>(selector.SelectedFranchise))
				{
					SendUpdate(linked, new ViewData
					{
						Cards = DataObjectList.Empty,
						FranchiseIndex = selector.SelectedIndex,
						FranchiseCount = franchises.Length
					}, MessageType.SpecificViewUpdate);
					return;
				}
				DataObjectList cards = DataObjectList.Empty;
				if (Require<CFranchiseItem>(selector.SelectedFranchise, out CFranchiseItem comp))
				{
					cards = comp.Cards;
				}
				SendUpdate(linked, new ViewData
				{
					Name = GetComponent<CFranchiseItem>(selector.SelectedFranchise).Name.Value,
					Cards = cards,
					FranchiseIndex = selector.SelectedIndex,
					FranchiseCount = franchises.Length
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
				(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<SFranchiseSelector>(),
					ComponentType.ReadOnly<CAvailableFranchises>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public string Name;

			[Key(1)]
			public DataObjectList Cards;

			[Key(2)]
			public int FranchiseIndex;

			[Key(3)]
			public int FranchiseCount;

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<FranchiseCardSetView>();
			}

			public bool IsChangedFrom(ViewData check)
			{
				if (!check.Cards.IsEquivalent(Cards))
				{
					return true;
				}
				if (Name != check.Name)
				{
					return true;
				}
				if (FranchiseIndex != check.FranchiseIndex)
				{
					return true;
				}
				if (FranchiseCount != check.FranchiseCount)
				{
					return true;
				}
				return false;
			}
		}

		[Header("References")]
		[SerializeField]
		private TextMeshPro ActiveFranchiseLabel;

		[SerializeField]
		private TextMeshPro Label;

		[SerializeField]
		private MeshRenderer Renderer;

		[SerializeField]
		private MeshRenderer BackingRenderer;

		[SerializeField]
		private VisualEffect Projector;

		[Header("State")]
		private ViewData Data;

		private static readonly int Image = Shader.PropertyToID("_Image");

		protected override void UpdateData(ViewData data)
		{
			_ = Data;
			Data = data;
			bool flag = data.Cards.Count > 0;
			Texture2D texture2D = null;
			for (int num = Data.Cards.Count - 1; num >= 0; num--)
			{
				int id = Data.Cards[num];
				if (GameData.Main.TryGet<Unlock>(id, out var output) && output is Dish { Type: DishType.Base } dish && dish.IconPrefab != null)
				{
					texture2D = PrefabSnapshot.GetSnapshot(dish.IconPrefab);
					break;
				}
			}
			if (texture2D == null)
			{
				texture2D = new Texture2D(1, 1);
			}
			if (Label != null)
			{
				Label.text = data.Name;
			}
			if (Projector != null)
			{
				bool num2 = !Projector.gameObject.activeSelf;
				Projector.gameObject.SetActive(flag);
				if (num2 && flag)
				{
					Projector.Simulate(0.01f, 1000u);
				}
				if (flag)
				{
					Projector.SetTexture("Image", texture2D);
				}
			}
			if (BackingRenderer != null)
			{
				RegisterDisposable(BackingRenderer.material).color = (flag ? new Color(0.45f, 0.45f, 0.45f, 0.05f) : new Color(0.24f, 0.26f, 0.26f, 0f));
			}
			if (Renderer != null)
			{
				Renderer.gameObject.SetActive(flag);
				RegisterDisposable(Renderer.material).SetTexture(Image, texture2D);
			}
			if (ActiveFranchiseLabel != null)
			{
				ActiveFranchiseLabel.text = base.Localisation[flag ? "ACTIVE_FRANCHISE" : "NO_ACTIVE_FRANCHISE"] + "\n<size=-50><color=grey>" + (flag ? $"{Data.FranchiseIndex}/{Data.FranchiseCount - 1}" : base.Localisation["FRANCHISES_AVAILABLE", new object[1] { Data.FranchiseCount - 1 }]) + "</color></size>";
				ActiveFranchiseLabel.color = (flag ? new Color(0.62f, 1f, 0f) : new Color(0.7f, 0.7f, 0.7f));
			}
		}
	}
}
