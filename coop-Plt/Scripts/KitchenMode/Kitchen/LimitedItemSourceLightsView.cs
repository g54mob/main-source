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
	public class LimitedItemSourceLightsView : UpdatableObjectView<LimitedItemSourceLightsView.ViewData>
	{
		public class UpdateView : BurstIncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass2_0
			{
				public BurstContext bctx;

				internal void _003CPopulateNewViewUpdates_003Eb__0(Entity entity, int entityInQueryIndex, in CAppliance appliance, in CLinkedView linked_view, in CItemProvider provider)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}
			}

			[BurstCompile]
			[NoAlias]
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
						public LambdaParameterValueProvider_IComponentData<CAppliance>.Runtime runtime_appliance;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CItemProvider>.Runtime runtime_provider;
					}

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CAppliance> forParameter_appliance;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CItemProvider> forParameter_provider;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_appliance.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_provider.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_appliance = forParameter_appliance.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_provider = forParameter_provider.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public unsafe delegate void RunWithoutJobSystem_00000714_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

				internal static class RunWithoutJobSystem_00000714_0024BurstDirectCall
				{
					private static IntPtr Pointer;

					private static IntPtr DeferredCompilation;

					[BurstDiscard]
					private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
					{
						if (Pointer == (IntPtr)0)
						{
							Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000714_0024PostfixBurstDelegate).TypeHandle);
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

					static RunWithoutJobSystem_00000714_0024BurstDirectCall()
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
				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CAppliance appliance, in CLinkedView linked_view, in CItemProvider provider)
				{
					ViewData view_data = new ViewData
					{
						DisplayedType = provider.ProvidedItem,
						Amount = ((provider.Maximum == 0) ? 99 : provider.Available)
					};
					bctx.ProposeUpdate(linked_view, view_data);
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
				{
					bctx = displayClass.bctx;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_appliance.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_provider.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateView componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				[BurstCompile]
				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					RunWithoutJobSystem_00000714_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				[BurstCompile]
				public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker;

			protected override MessageType MessageType => MessageType.SpecificViewUpdate;

			protected override void PopulateNewViewUpdates(BurstContext bctx)
			{
				_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
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
					ComponentType.ReadOnly<CAppliance>(),
					ComponentType.ReadOnly<CItemProvider>()
				};
				entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CHeldAppliance>() };
				return componentSystem.GetEntityQuery(array);
			}

			public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0_RunWithoutJobSystem_00000714_0024BurstDirectCall()
			{
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem_00000714_0024BurstDirectCall.Initialize();
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public int DisplayedType;

			[Key(1)]
			public int Amount;

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<LimitedItemSourceLightsView>();
			}

			public bool IsChangedFrom(ViewData check)
			{
				if (DisplayedType == check.DisplayedType)
				{
					return Amount != check.Amount;
				}
				return true;
			}
		}

		[Serializable]
		public struct ColourLookup : IListLookup<int, Color>
		{
			public Item Item;

			public Color Color;

			public int Key => Item.ID;

			public Color Value => Color;
		}

		[SerializeField]
		[Header("Configuration")]
		private List<ColourLookup> Colours = new List<ColourLookup>();

		[SerializeField]
		private Color Default;

		[SerializeField]
		[Header("References")]
		private List<MeshRenderer> Lights;

		[Header("State")]
		private ViewData Data;

		protected override void UpdateData(ViewData data)
		{
			for (int i = 0; i < Lights.Count; i++)
			{
				if (i < data.Amount && LookupHelpers.TryGet<ColourLookup, int, Color>(Colours, data.DisplayedType, out var value))
				{
					RegisterDisposable(Lights[i].material).color = value;
				}
				else
				{
					RegisterDisposable(Lights[i].material).color = Default;
				}
			}
		}
	}
}
