#define ENABLE_PROFILER
using System;
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
	public class ConveyItemsView : UpdatableObjectView<ConveyItemsView.ViewData>
	{
		public class UpdateView : BurstIncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass0_0
			{
				public BurstContext bctx;

				internal void _003CPopulateNewViewUpdates_003Eb__0(Entity entity, int entityInQueryIndex, in CConveyPushItems push, in CLinkedView linked_view, in CConveyPushRotatable target)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}

				internal void _003CPopulateNewViewUpdates_003Eb__1(Entity entity, int entityInQueryIndex, in CConveyPushItems push, in CLinkedView linked_view)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}
			}

			[NoAlias]
			[BurstCompile]
			[Unity.Entities.DOTSCompilerGenerated]
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
						public LambdaParameterValueProvider_IComponentData<CConveyPushItems>.Runtime runtime_push;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CConveyPushRotatable>.Runtime runtime_target;
					}

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CConveyPushItems> forParameter_push;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CConveyPushRotatable> forParameter_target;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_push.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_target.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_push = forParameter_push.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_target = forParameter_target.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public unsafe delegate void RunWithoutJobSystem_00000670_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

				internal static class RunWithoutJobSystem_00000670_0024BurstDirectCall
				{
					private static IntPtr Pointer;

					private static IntPtr DeferredCompilation;

					[BurstDiscard]
					private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
					{
						if (Pointer == (IntPtr)0)
						{
							Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000670_0024PostfixBurstDelegate).TypeHandle);
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

					static RunWithoutJobSystem_00000670_0024BurstDirectCall()
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

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CConveyPushItems push, in CLinkedView linked_view, in CConveyPushRotatable target)
				{
					Orientation target2 = target.Target;
					bctx.ProposeUpdate(linked_view, new ViewData
					{
						PushAmount = push.Progress / push.Delay,
						State = push.State,
						SmartActive = (push.GrabSpecificType && push.SpecificType != 0),
						SmartFilter = push.SpecificType,
						SmartFilterComponents = push.SpecificComponents,
						PushDirection = target2
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					bctx = displayClass.bctx;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					displayClass.bctx = bctx;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_push.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_target.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				[BurstCompile]
				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					RunWithoutJobSystem_00000670_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				[BurstCompile]
				public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			[BurstCompile]
			[Unity.Entities.DOTSCompilerGenerated]
			[NoAlias]
			private struct _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1 : IJobChunk
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
						public LambdaParameterValueProvider_IComponentData<CConveyPushItems>.Runtime runtime_push;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;
					}

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CConveyPushItems> forParameter_push;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_push.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_push = forParameter_push.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public unsafe delegate void RunWithoutJobSystem_00000679_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

				internal static class RunWithoutJobSystem_00000679_0024BurstDirectCall
				{
					private static IntPtr Pointer;

					private static IntPtr DeferredCompilation;

					[BurstDiscard]
					private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
					{
						if (Pointer == (IntPtr)0)
						{
							Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000679_0024PostfixBurstDelegate).TypeHandle);
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

					static RunWithoutJobSystem_00000679_0024BurstDirectCall()
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

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CConveyPushItems push, in CLinkedView linked_view)
				{
					Orientation pushDirection = Orientation.Up;
					bctx.ProposeUpdate(linked_view, new ViewData
					{
						PushAmount = push.Progress / push.Delay,
						State = push.State,
						SmartActive = (push.GrabSpecificType && push.SpecificType != 0),
						SmartFilter = push.SpecificType,
						SmartFilterComponents = push.SpecificComponents,
						PushDirection = pushDirection
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					bctx = displayClass.bctx;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					displayClass.bctx = bctx;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_push.For(i), in runtimes.runtime_linked_view.For(i));
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
					RunWithoutJobSystem_00000679_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[BurstCompile]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker;

			private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob1_entityQuery;

			private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker;

			protected override void PopulateNewViewUpdates(BurstContext bctx)
			{
				_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
				{
					bctx = bctx
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
				_ = base.Entities;
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1 jobData2 = default(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1);
				jobData2.ScheduleTimeInitialize(this, ref displayClass);
				CompleteDependency();
				EntityQuery query2 = _003C_003EPopulateNewViewUpdates_LambdaJob1_entityQuery;
				InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer2 = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst);
				_003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker.Begin();
				try
				{
					InternalCompilerInterface.RunJobChunk(ref jobData2, query2, functionPointer2);
				}
				finally
				{
					_003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker.End();
				}
				jobData2.WriteToDisplayClass(ref displayClass);
			}

			protected internal unsafe override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
				_003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(this);
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem;
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
				_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker = new ProfilerMarker("PopulateNewViewUpdates_LambdaJob0");
				_003C_003EPopulateNewViewUpdates_LambdaJob1_entityQuery = _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob1_From(this);
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.RunWithoutJobSystem;
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst);
				_003C_003EPopulateNewViewUpdates_LambdaJob1_profilerMarker = new ProfilerMarker("PopulateNewViewUpdates_LambdaJob1");
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CConveyPushItems>(),
					ComponentType.ReadOnly<CConveyPushRotatable>()
				};
				return componentSystem.GetEntityQuery(array);
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob1_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
				entityQueryDesc.All = new ComponentType[2]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CConveyPushItems>()
				};
				entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CConveyPushRotatable>() };
				return componentSystem.GetEntityQuery(array);
			}

			public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0_RunWithoutJobSystem_00000670_0024BurstDirectCall()
			{
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem_00000670_0024BurstDirectCall.Initialize();
			}

			public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1_RunWithoutJobSystem_00000679_0024BurstDirectCall()
			{
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob1.RunWithoutJobSystem_00000679_0024BurstDirectCall.Initialize();
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public float PushAmount;

			[Key(1)]
			public CConveyPushItems.ConveyState State;

			[Key(2)]
			public bool SmartActive;

			[Key(3)]
			public int SmartFilter;

			[Key(4)]
			public ItemList SmartFilterComponents;

			[Key(5)]
			public Orientation PushDirection;

			public bool IsChangedFrom(ViewData check)
			{
				if (PushDirection == check.PushDirection && !(Math.Abs(PushAmount - check.PushAmount) > 0.001f) && State == check.State && SmartActive == check.SmartActive && SmartFilter == check.SmartFilter)
				{
					return !SmartFilterComponents.IsEquivalent(check.SmartFilterComponents);
				}
				return true;
			}

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<ConveyItemsView>();
			}
		}

		[Header("References")]
		[SerializeField]
		private GameObject PushObject;

		[SerializeField]
		private GameObject SmartActive;

		[SerializeField]
		private GameObject SmartInactive;

		[SerializeField]
		private GameObject TypeContainer;

		[SerializeField]
		private Animator Animator;

		[Header("State")]
		private ViewData Data;

		private static readonly int Direction = Animator.StringToHash("Direction");

		protected override void UpdateData(ViewData view_data)
		{
			ViewData data = Data;
			Data = view_data;
			switch (view_data.State)
			{
			case CConveyPushItems.ConveyState.None:
				PushObject.transform.localPosition = Vector3.zero;
				break;
			case CConveyPushItems.ConveyState.Push:
				PushObject.transform.localPosition = Data.PushDirection.ToOffset() * Data.PushAmount;
				break;
			case CConveyPushItems.ConveyState.Grab:
				PushObject.transform.localPosition = Vector3.forward * (-1f + Data.PushAmount);
				break;
			}
			bool flag = view_data.State == CConveyPushItems.ConveyState.Grab;
			if (SmartActive != null)
			{
				SmartActive.SetActive(flag && view_data.SmartActive);
			}
			if (SmartInactive != null)
			{
				SmartInactive.SetActive(!view_data.SmartActive);
			}
			if (Animator != null)
			{
				Animator.SetInteger(Direction, (int)view_data.PushDirection);
			}
			if (TypeContainer != null && (data.SmartFilter != view_data.SmartFilter || !data.SmartFilterComponents.IsEquivalent(view_data.SmartFilterComponents)))
			{
				SetPrefab(GameData.Main.GetPrefab(view_data.SmartFilter), view_data.SmartFilter, view_data.SmartFilterComponents);
			}
		}

		public void SetPrefab(GameObject prefab, int item, ItemList components)
		{
			GameObject typeContainer = TypeContainer;
			GameObject gameObject = UnityEngine.Object.Instantiate(prefab, typeContainer.transform.parent, worldPositionStays: true);
			gameObject.transform.position = typeContainer.transform.position;
			gameObject.transform.rotation = typeContainer.transform.rotation;
			gameObject.transform.localScale = typeContainer.transform.localScale;
			gameObject.SetActive(typeContainer.activeSelf);
			if (gameObject.TryGetComponent<ItemGroupView>(out var component))
			{
				component.PerformUpdate(item, components);
			}
			if (gameObject.TryGetComponent<PassthroughItemView>(out var component2))
			{
				component2.PerformUpdate(item, components);
			}
			TypeContainer = gameObject;
			UnityEngine.Object.Destroy(typeContainer);
		}
	}
}
