#define ENABLE_PROFILER
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Profiling;

namespace Kitchen
{
	[FilterModes(AllowedModes = GameSetupMode.All)]
	public class EntityViewManager : GenericSystemBase
	{
		[Unity.Entities.DOTSCompilerGenerated]
		[NoAlias]
		[BurstCompile]
		private struct _003C_003Ec__DisplayClass_AfterLoading_LambdaJob0 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				[NoAlias]
				public struct Runtimes
				{
					[NoAlias]
					public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

					[NoAlias]
					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;
				}

				[ReadOnly]
				[NoAlias]
				private LambdaParameterValueProvider_Entity forParameter_entity;

				[NoAlias]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				public void ScheduleTimeInitialize(EntityViewManager componentSystem)
				{
					forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public unsafe delegate void RunWithoutJobSystem_00000DEB_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

			internal static class RunWithoutJobSystem_00000DEB_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000DEB_0024PostfixBurstDelegate).TypeHandle);
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

				static RunWithoutJobSystem_00000DEB_0024BurstDirectCall()
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

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void OriginalLambdaBody(Entity entity, ref CPosition pos)
			{
				pos.ForceSnap = true;
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
					OriginalLambdaBody(runtimes.runtime_entity.For(i), ref runtimes.runtime_pos.For(i));
				}
			}

			public void ScheduleTimeInitialize(EntityViewManager componentSystem)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
			}

			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				RunWithoutJobSystem_00000DEB_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
			public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_AfterLoading_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		public Dictionary<ViewIdentifier, IObjectView> EntityViews;

		private EntityQuery _003C_003EAfterLoading_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EAfterLoading_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			EntityViews = new Dictionary<ViewIdentifier, IObjectView>();
		}

		public void PerformFullRefresh()
		{
			base.EntityManager.AddComponent<CRefreshView>(GetEntityQuery(typeof(CLinkedView)));
		}

		protected override void OnUpdate()
		{
		}

		public override void BeforeLoading(SaveSystemType system_type)
		{
			base.BeforeLoading(system_type);
			foreach (KeyValuePair<ViewIdentifier, IObjectView> entityView in EntityViews)
			{
				if (entityView.Value != null && entityView.Value.GameObject != null)
				{
					entityView.Value.Remove();
				}
			}
			EntityViews.Clear();
		}

		public override void AfterLoading(SaveSystemType system_type)
		{
			base.AfterLoading(system_type);
			EntityQuery entityQuery = GetEntityQuery(typeof(CLinkedView));
			base.EntityManager.RemoveComponent<CLinkedView>(entityQuery);
			_ = base.Entities;
			_003C_003Ec__DisplayClass_AfterLoading_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_AfterLoading_LambdaJob0);
			jobData.ScheduleTimeInitialize(this);
			CompleteDependency();
			EntityQuery query = _003C_003EAfterLoading_LambdaJob0_entityQuery;
			InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_AfterLoading_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_AfterLoading_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EAfterLoading_LambdaJob0_profilerMarker.Begin();
			try
			{
				InternalCompilerInterface.RunJobChunk(ref jobData, query, functionPointer);
			}
			finally
			{
				_003C_003EAfterLoading_LambdaJob0_profilerMarker.End();
			}
		}

		protected override void OnDestroy()
		{
			foreach (KeyValuePair<ViewIdentifier, IObjectView> entityView in EntityViews)
			{
				try
				{
					entityView.Value.Remove();
				}
				catch
				{
				}
			}
			EntityViews.Clear();
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EAfterLoading_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForAfterLoading_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_AfterLoading_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_AfterLoading_LambdaJob0.RunWithoutJobSystem;
			_003C_003Ec__DisplayClass_AfterLoading_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_AfterLoading_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
			_003C_003EAfterLoading_LambdaJob0_profilerMarker = new ProfilerMarker("AfterLoading_LambdaJob0");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForAfterLoading_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadWrite<CPosition>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static void Initialize_0024_003C_003Ec__DisplayClass_AfterLoading_LambdaJob0_RunWithoutJobSystem_00000DEB_0024BurstDirectCall()
		{
			_003C_003Ec__DisplayClass_AfterLoading_LambdaJob0.RunWithoutJobSystem_00000DEB_0024BurstDirectCall.Initialize();
		}
	}
}
