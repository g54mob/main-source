#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class MoveHoldersIntoProviders : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public MoveHoldersIntoProviders _003C_003E4__this;

			public GameData data;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CItemHolder holder, ref CItemProvider provider)
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
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CItemHolder>.Runtime runtime_holder;

					public LambdaParameterValueProvider_IComponentData<CItemProvider>.Runtime runtime_provider;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CItemHolder> forParameter_holder;

				private LambdaParameterValueProvider_IComponentData<CItemProvider> forParameter_provider;

				public void ScheduleTimeInitialize(MoveHoldersIntoProviders componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_holder.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_provider.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_holder = forParameter_holder.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_provider = forParameter_provider.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public GameData data;

			public EntityCommandBuffer ecb;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CItem> _ComponentDataFromEntity_CItem_0;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CDynamicItemProvider> _ComponentDataFromEntity_CDynamicItemProvider_1;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CItemHolder holder, ref CItemProvider provider)
			{
				if (!provider.AutoGrabFromHolder || holder.HeldItem == default(Entity))
				{
					return;
				}
				CItem cItem = _ComponentDataFromEntity_CItem_0[holder.HeldItem];
				if (!data.TryGet<Item>(cItem, out var output, warn_if_fail: true))
				{
					return;
				}
				bool flag = _ComponentDataFromEntity_CDynamicItemProvider_1.HasComponent(e);
				if (provider.PreventReturns || (provider.ProvidedItem != output.ID && (!flag || provider.Available != 0)) || (provider.Maximum > 0 && provider.Available == provider.Maximum))
				{
					return;
				}
				if (provider.Available == 0 && flag)
				{
					if (output is ItemGroup)
					{
						return;
					}
					ItemStorage itemStorageFlags = output.ItemStorageFlags;
					ItemStorage storageFlags = _ComponentDataFromEntity_CDynamicItemProvider_1[e].StorageFlags;
					if (!itemStorageFlags.HasFlag(storageFlags))
					{
						return;
					}
				}
				ecb.DestroyEntity(holder.HeldItem);
				holder.HeldItem = default(Entity);
				if (provider.Maximum > 0)
				{
					provider.Available++;
					provider.SetAsItem(output.ID);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				data = displayClass.data;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass.data = data;
				displayClass.ecb = ecb;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_holder.For(i), ref runtimes.runtime_provider.For(i));
				}
			}

			public void ScheduleTimeInitialize(MoveHoldersIntoProviders componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CItem_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CItem>(true);
				_ComponentDataFromEntity_CDynamicItemProvider_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CDynamicItemProvider>(true);
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
				ecb = GetCommandBuffer(ECB.End),
				data = base.Data
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadWrite<CItemHolder>(),
				ComponentType.ReadWrite<CItemProvider>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
