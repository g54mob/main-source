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
	public class CardsSubview : UpdatableObjectView<CardsSubview.ViewData>
	{
		public class UpdateView : IncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass0_0
			{
				public UpdateView _003C_003E4__this;

				public List<int> unlock_array;

				internal void _003COnUpdate_003Eb__0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CNewsCards item)
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

						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						public LambdaParameterValueProvider_IComponentData_Tag<CNewsCards>.Runtime runtime_item;
					}

					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData_Tag<CNewsCards> forParameter_item;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_item.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_item = forParameter_item.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public UpdateView _003C_003E4__this;

				public List<int> unlock_array;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CNewsCards item)
				{
					_003C_003E4__this.SendUpdate(linked_view, new ViewData
					{
						Unlocks = unlock_array
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					_003C_003E4__this = displayClass._003C_003E4__this;
					unlock_array = displayClass.unlock_array;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					displayClass._003C_003E4__this = _003C_003E4__this;
					displayClass.unlock_array = unlock_array;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_linked_view.For(i), runtimes.runtime_item.For(i));
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

			[ReadOnly]
			private EntityQuery _SingletonEntityQuery_SEndgameStats_19;

			protected override void OnUpdate()
			{
				_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
				{
					_003C_003E4__this = this
				};
				if (!HasSingleton<SEndgameStats>())
				{
					return;
				}
				try
				{
					DynamicBuffer<CEndgameUnlock> buffer = GetBuffer<CEndgameUnlock>(_SingletonEntityQuery_SEndgameStats_19.GetSingletonEntity());
					displayClass.unlock_array = new List<int>();
					for (int i = 0; i < buffer.Length; i++)
					{
						if (!buffer[i].FromFranchise && buffer[i].Type == CardType.Default && buffer[i].Type == CardType.HalloweenTreat && buffer[i].Type == CardType.HalloweenTrick)
						{
							displayClass.unlock_array.Add(buffer[i].UnlockID);
						}
					}
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
				catch (ArgumentException)
				{
				}
			}

			protected internal unsafe override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
				_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
				_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
				_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
				_SingletonEntityQuery_SEndgameStats_19 = GetEntityQuery(ComponentType.ReadOnly<SEndgameStats>());
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CNewsCards>()
				};
				return componentSystem.GetEntityQuery(array);
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public List<int> Unlocks;

			public bool IsChangedFrom(ViewData check)
			{
				if (check.Unlocks.Count != Unlocks.Count)
				{
					return true;
				}
				for (int i = 0; i < check.Unlocks.Count; i++)
				{
					if (Unlocks[i] != check.Unlocks[i])
					{
						return true;
					}
				}
				return false;
			}

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<CardsSubview>();
			}
		}

		[Header("Configuration")]
		[SerializeField]
		private int PerColumn;

		[SerializeField]
		private Vector3 VerticalOffset;

		[SerializeField]
		private Vector3 HorizontalOffset;

		[SerializeField]
		[Header("References")]
		private Transform ContainerHolder;

		[Header("State")]
		private GameObject Container;

		protected override void UpdateData(ViewData view_data)
		{
			if ((bool)Container)
			{
				UnityEngine.Object.Destroy(Container);
			}
			Container = new GameObject();
			Container.transform.parent = ContainerHolder;
			Container.transform.localRotation = Quaternion.identity;
			Container.transform.localScale = Vector3.one;
			Bounds bounds = default(Bounds);
			for (int i = 0; i < view_data.Unlocks.Count; i++)
			{
				int id = view_data.Unlocks[i];
				UnlockCardElement unlockCardElement = PlaceCard(id, i);
				bounds.Encapsulate(unlockCardElement.transform.localPosition);
			}
			Container.transform.localPosition = new Vector3(0f, 0f, -0.65f) - bounds.center;
		}

		protected UnlockCardElement PlaceCard(int id, int index)
		{
			UnlockCardElement unlockCardElement = Add<UnlockCardElement>(Container.transform);
			unlockCardElement.transform.localRotation = Quaternion.identity;
			unlockCardElement.gameObject.SetActive(value: true);
			unlockCardElement.SetUIMode(is_ui_mode: false);
			unlockCardElement.SetUnlock(id);
			unlockCardElement.transform.localPosition = CardPosition(index);
			unlockCardElement.transform.localScale = Vector3.one * 0.5f;
			return unlockCardElement;
		}

		protected Vector3 CardPosition(int index)
		{
			int num = index % PerColumn;
			int num2 = (index - num) / PerColumn;
			return HorizontalOffset * num2 + VerticalOffset * num;
		}
	}
}
