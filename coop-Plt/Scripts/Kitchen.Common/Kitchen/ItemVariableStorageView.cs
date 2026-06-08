#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using MessagePack;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	public class ItemVariableStorageView : UpdatableObjectView<ItemVariableStorageView.ViewData>
	{
		public class UpdateView : BurstIncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass0_0
			{
				public EntityContext ctx;

				public BurstContext bctx;

				internal void _003CPopulateNewViewUpdates_003Eb__0(Entity entity, int entityInQueryIndex, in DynamicBuffer<CItemStored> stored_items, in CItemStorage storage, in CLinkedView linked_view)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}
			}

			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass0_1
			{
				public DynamicBuffer<CItemStored> stored;
			}

			[Unity.Entities.DOTSCompilerGenerated]
			[BurstCompile]
			[NoAlias]
			private struct _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 : IJobChunk
			{
				private struct LambdaParameterValueProviders
				{
					[NoAlias]
					public struct Runtimes
					{
						[NoAlias]
						public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

						[NoAlias]
						public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

						[NoAlias]
						public LambdaParameterValueProvider_DynamicBuffer<CItemStored>.Runtime runtime_stored_items;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CItemStorage>.Runtime runtime_storage;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;
					}

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_DynamicBuffer<CItemStored> forParameter_stored_items;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CItemStorage> forParameter_storage;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_stored_items.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_storage.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_stored_items = forParameter_stored_items.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_storage = forParameter_storage.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public unsafe delegate void RunWithoutJobSystem_00000158_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

				internal static class RunWithoutJobSystem_00000158_0024BurstDirectCall
				{
					private static IntPtr Pointer;

					private static IntPtr DeferredCompilation;

					[BurstDiscard]
					private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
					{
						if (Pointer == (IntPtr)0)
						{
							Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000158_0024PostfixBurstDelegate).TypeHandle);
						}
						P_0 = Pointer;
					}

					private static IntPtr GetFunctionPointer()
					{
						IntPtr result = (IntPtr)0;
						GetFunctionPointerDiscard(ref result);
						return result;
					}

					public static void Constructor()
					{
						DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
					}

					public static void Initialize()
					{
					}

					static RunWithoutJobSystem_00000158_0024BurstDirectCall()
					{
						Constructor();
					}

					public unsafe static void Invoke(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
					{
						if (BurstCompiler.IsEnabled)
						{
							IntPtr functionPointer = GetFunctionPointer();
							if (functionPointer != (IntPtr)0)
							{
								((UIntPtr/*delegate* unmanaged[Cdecl]<ArchetypeChunkIterator*, void*, void>*/)(void*)(long)functionPointer)(archetypeChunkIterator, jobData);
								return;
							}
						}
						RunWithoutJobSystem_0024BurstManaged(archetypeChunkIterator, jobData);
					}
				}

				public BurstContext bctx;

				public EntityContext ctx;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in DynamicBuffer<CItemStored> stored_items, in CItemStorage storage, in CLinkedView linked_view)
				{
					ViewData view_data = default(ViewData);
					System.Runtime.CompilerServices.Unsafe.SkipInit(out _003C_003Ec__DisplayClass0_1 _003C_003Ec__DisplayClass0_2);
					_003C_003Ec__DisplayClass0_2.stored = stored_items;
					view_data.Item1 = _003CPopulateNewViewUpdates_003Eg__get_from_index_007C1(0, ref _003C_003Ec__DisplayClass0_2);
					view_data.Item2 = _003CPopulateNewViewUpdates_003Eg__get_from_index_007C1(1, ref _003C_003Ec__DisplayClass0_2);
					view_data.Item3 = _003CPopulateNewViewUpdates_003Eg__get_from_index_007C1(2, ref _003C_003Ec__DisplayClass0_2);
					view_data.Item4 = _003CPopulateNewViewUpdates_003Eg__get_from_index_007C1(3, ref _003C_003Ec__DisplayClass0_2);
					view_data.Item5 = _003CPopulateNewViewUpdates_003Eg__get_from_index_007C1(4, ref _003C_003Ec__DisplayClass0_2);
					bctx.ProposeUpdate(linked_view.Identifier, view_data);
				}

				internal ItemData _003CPopulateNewViewUpdates_003Eg__get_from_index_007C1(int i, ref _003C_003Ec__DisplayClass0_1 P_1)
				{
					ItemData result = default(ItemData);
					if (P_1.stored.Length > i)
					{
						if (ctx.Require<CSplittableItem>(P_1.stored[i].StoredItem, out var comp))
						{
							result.SplitCount = comp.RemainingCount;
							result.SplitMax = comp.TotalCount;
						}
						if (ctx.Require<CItem>(P_1.stored[i].StoredItem, out var comp2))
						{
							result.Item = comp2.ID;
							result.ItemList = comp2.Items;
						}
					}
					return result;
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					bctx = displayClass.bctx;
					ctx = displayClass.ctx;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					displayClass.bctx = bctx;
					displayClass.ctx = ctx;
				}

				public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
				{
					LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
					_runtimes = &runtimes;
					IterateEntities(ref chunk, ref *_runtimes);
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
				{
					int count = chunk.Count;
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), runtimes.runtime_stored_items.For(i), in runtimes.runtime_storage.For(i), in runtimes.runtime_linked_view.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				[BurstCompile]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					RunWithoutJobSystem_00000158_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[BurstCompile]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker;

			protected override void PopulateNewViewUpdates(BurstContext bctx)
			{
				_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
				{
					bctx = bctx,
					ctx = new EntityContext(base.EntityManager)
				};
				_ = base.Entities;
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0);
				jobData.ScheduleTimeInitialize(this, ref displayClass);
				CompleteDependency();
				EntityQuery query = _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
				_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData, query, functionPointer);
				}
				finally
				{
					_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker.End();
				}
				jobData.WriteToDisplayClass(ref displayClass);
			}

			protected internal unsafe override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
				_003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(this);
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem;
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
				_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker = new ProfilerMarker("PopulateNewViewUpdates_LambdaJob0");
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
				entityQueryDesc.All = new ComponentType[3]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CItemStored>(),
					ComponentType.ReadOnly<CItemStorage>()
				};
				entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CHeldAppliance>() };
				return componentSystem.GetEntityQuery(array);
			}

			public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0_RunWithoutJobSystem_00000158_0024BurstDirectCall()
			{
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem_00000158_0024BurstDirectCall.Initialize();
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ItemData
		{
			[Key(0)]
			public int Item;

			[Key(1)]
			public ItemList ItemList;

			[Key(2)]
			public int SplitCount;

			[Key(3)]
			public int SplitMax;

			public bool IsChangedFrom(ItemData check)
			{
				if (Item == check.Item && ItemList.IsEquivalent(check.ItemList) && SplitCount == check.SplitCount)
				{
					return SplitMax != check.SplitMax;
				}
				return true;
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public ItemData Item1;

			[Key(1)]
			public ItemData Item2;

			[Key(2)]
			public ItemData Item3;

			[Key(3)]
			public ItemData Item4;

			[Key(4)]
			public ItemData Item5;

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<ItemVariableStorageView>();
			}

			public bool IsChangedFrom(ViewData check)
			{
				if (!Item1.IsChangedFrom(check.Item1) && !Item2.IsChangedFrom(check.Item2) && !Item3.IsChangedFrom(check.Item3) && !Item4.IsChangedFrom(check.Item4))
				{
					return Item5.IsChangedFrom(check.Item5);
				}
				return true;
			}
		}

		[Header("References")]
		[SerializeField]
		private List<GameObject> Storage;

		[SerializeField]
		private List<GameObject> GenericStorage;

		[Header("Configuration")]
		[SerializeField]
		private bool MoveHeldItemPosition;

		[SerializeField]
		private bool OnlyExactGenericCount = true;

		protected override void UpdateData(ViewData data)
		{
			if (Storage == null)
			{
				return;
			}
			int num = 0;
			num += (SetPrefab(0, data.Item1) ? 1 : 0);
			num += (SetPrefab(1, data.Item2) ? 1 : 0);
			num += (SetPrefab(2, data.Item3) ? 1 : 0);
			num += (SetPrefab(3, data.Item4) ? 1 : 0);
			num += (SetPrefab(4, data.Item5) ? 1 : 0);
			if (GenericStorage != null)
			{
				for (int i = 0; i < GenericStorage.Count; i++)
				{
					GenericStorage[i].SetActive(OnlyExactGenericCount ? (i == num - 1) : (i < num));
				}
			}
			if (MoveHeldItemPosition && num < Storage.Count)
			{
				HeldItemPosition.position = Storage[num].transform.position;
			}
		}

		public bool SetPrefab(int i, ItemData item_data)
		{
			if (i >= Storage.Count)
			{
				return false;
			}
			int item = item_data.Item;
			ItemList itemList = item_data.ItemList;
			if (item == 0 || !itemList.IsValid || !GameData.Main.TryGet<Item>(item, out var output))
			{
				Storage[i].SetActive(value: false);
				return false;
			}
			GameObject gameObject = Storage[i];
			GameObject gameObject2 = UnityEngine.Object.Instantiate(output.Prefab, gameObject.transform.parent, worldPositionStays: true);
			gameObject2.transform.position = gameObject.transform.position;
			gameObject2.transform.rotation = gameObject.transform.rotation;
			gameObject2.transform.localScale = gameObject.transform.localScale;
			gameObject2.SetActive(value: true);
			if (gameObject2.TryGetComponent<ItemGroupView>(out var component))
			{
				component.PerformUpdate(item, itemList);
			}
			if (gameObject2.TryGetComponent<SplittableItemView>(out var component2))
			{
				component2.UpdateData(new SplittableItemView.ViewData
				{
					Remaining = item_data.SplitCount,
					Total = item_data.SplitMax
				});
			}
			ObjectsSplittableView componentInChildren = gameObject2.GetComponentInChildren<ObjectsSplittableView>();
			if ((bool)componentInChildren)
			{
				componentInChildren.UpdateData(new SplittableItemView.ViewData
				{
					Remaining = item_data.SplitCount,
					Total = item_data.SplitMax
				});
			}
			if (gameObject2.TryGetComponent<PassthroughItemView>(out var component3))
			{
				component3.PerformUpdate(item, itemList);
			}
			Storage[i] = gameObject2;
			UnityEngine.Object.Destroy(gameObject);
			return true;
		}
	}
}
