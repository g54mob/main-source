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
	public class AttachmentView : UpdatableObjectView<AttachmentView.ViewData>
	{
		public class UpdateView : BurstIncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass0_0
			{
				public EntityContext ctx;

				public BurstContext bctx;

				internal void _003CPopulateNewViewUpdates_003Eb__0(Entity entity, int entityInQueryIndex, in DynamicBuffer<CAttachments> attach, in CLinkedView linked_view, in CApplianceTable table)
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
						public LambdaParameterValueProvider_DynamicBuffer<CAttachments>.Runtime runtime_attach;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CApplianceTable>.Runtime runtime_table;
					}

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_DynamicBuffer<CAttachments> forParameter_attach;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CApplianceTable> forParameter_table;

					public void ScheduleTimeInitialize(UpdateView componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_attach.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_table.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_attach = forParameter_attach.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_table = forParameter_table.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public unsafe delegate void RunWithoutJobSystem_00000614_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

				internal static class RunWithoutJobSystem_00000614_0024BurstDirectCall
				{
					private static IntPtr Pointer;

					private static IntPtr DeferredCompilation;

					[BurstDiscard]
					private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
					{
						if (Pointer == (IntPtr)0)
						{
							Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000614_0024PostfixBurstDelegate).TypeHandle);
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

					static RunWithoutJobSystem_00000614_0024BurstDirectCall()
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

				public EntityContext ctx;

				public BurstContext bctx;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in DynamicBuffer<CAttachments> attach, in CLinkedView linked_view, in CApplianceTable table)
				{
					FixedListInt64 attachments = default(FixedListInt64);
					FixedListInt64 active = default(FixedListInt64);
					for (int i = 0; i < attach.Length; i++)
					{
						if (ctx.Require<CAttachedEffect>(attach[i], out var comp))
						{
							attachments.Add(in comp.Source);
							if (ctx.Require<CAppliesEffect>(attach[i], out var comp2))
							{
								active.Add(comp2.IsActive ? 1 : 0);
							}
							else
							{
								active.Add(1);
							}
						}
					}
					bctx.ProposeUpdate(linked_view, new ViewData
					{
						Attachments = attachments,
						Active = active,
						ActiveChairs = table.ActiveChairs
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					ctx = displayClass.ctx;
					bctx = displayClass.bctx;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					displayClass.ctx = ctx;
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
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), runtimes.runtime_attach.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_table.For(i));
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
					RunWithoutJobSystem_00000614_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
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
				(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
				{
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CAttachments>(),
					ComponentType.ReadOnly<CApplianceTable>()
				};
				return componentSystem.GetEntityQuery(array);
			}

			public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0_RunWithoutJobSystem_00000614_0024BurstDirectCall()
			{
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem_00000614_0024BurstDirectCall.Initialize();
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : ISpecificViewData, IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public FixedListInt64 Attachments;

			[Key(1)]
			public FixedListInt64 Active;

			[Key(2)]
			public Orientation ActiveChairs;

			public bool IsChangedFrom(ViewData check)
			{
				if (ActiveChairs != check.ActiveChairs)
				{
					return true;
				}
				if (Attachments.Length != check.Attachments.Length)
				{
					return true;
				}
				for (int i = 0; i < Attachments.Length; i++)
				{
					if (Attachments[i] != check.Attachments[i])
					{
						return true;
					}
				}
				if (Active.Length != check.Active.Length)
				{
					return true;
				}
				for (int j = 0; j < Active.Length; j++)
				{
					if (Active[j] != check.Active[j])
					{
						return true;
					}
				}
				return false;
			}

			public IUpdatableObject GetRelevantSubview(IObjectView view)
			{
				return view.GetSubView<AttachmentView>();
			}
		}

		[Serializable]
		public struct EffectLookup
		{
			public Effect Effect;

			public GameObject Inactive;

			public GameObject Active;
		}

		[Serializable]
		public struct OrientedObject
		{
			public Orientation Orientation;

			public GameObject Active;
		}

		[SerializeField]
		[Header("References")]
		private List<EffectLookup> EffectLookups = new List<EffectLookup>();

		[SerializeField]
		private List<OrientedObject> OrientedObjects = new List<OrientedObject>();

		protected override void UpdateData(ViewData view_data)
		{
			foreach (OrientedObject orientedObject in OrientedObjects)
			{
				orientedObject.Active.SetActive((orientedObject.Orientation & view_data.ActiveChairs) != 0);
			}
			foreach (EffectLookup effectLookup in EffectLookups)
			{
				bool flag = false;
				bool flag2 = false;
				for (int i = 0; i < view_data.Attachments.Length; i++)
				{
					if (view_data.Attachments[i] == effectLookup.Effect.ID)
					{
						flag2 = (float)view_data.Active[i] > 0.5f;
						flag = true;
					}
				}
				if (effectLookup.Active != null)
				{
					effectLookup.Active.SetActive(flag && flag2);
				}
				if (effectLookup.Inactive != null)
				{
					effectLookup.Inactive.SetActive(flag && !flag2);
				}
			}
		}
	}
}
