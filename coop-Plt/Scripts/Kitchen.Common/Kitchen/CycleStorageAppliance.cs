#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	public class CycleStorageAppliance : GenericSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public EntityContext ctx;

			internal void _003COnUpdate_003Eb__0(Entity e, ref DynamicBuffer<CItemStored> stored_items, ref CItemStorage storage, in CItemHolder held_item, in CCycleItemStorage cycle)
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

					public LambdaParameterValueProvider_DynamicBuffer<CItemStored>.Runtime runtime_stored_items;

					public LambdaParameterValueProvider_IComponentData<CItemStorage>.Runtime runtime_storage;

					public LambdaParameterValueProvider_IComponentData<CItemHolder>.Runtime runtime_held_item;

					public LambdaParameterValueProvider_IComponentData<CCycleItemStorage>.Runtime runtime_cycle;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_DynamicBuffer<CItemStored> forParameter_stored_items;

				private LambdaParameterValueProvider_IComponentData<CItemStorage> forParameter_storage;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CItemHolder> forParameter_held_item;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCycleItemStorage> forParameter_cycle;

				public void ScheduleTimeInitialize(CycleStorageAppliance componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_stored_items.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_storage.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_held_item.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_cycle.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_stored_items = forParameter_stored_items.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_storage = forParameter_storage.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_held_item = forParameter_held_item.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_cycle = forParameter_cycle.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public EntityContext ctx;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref DynamicBuffer<CItemStored> stored_items, ref CItemStorage storage, in CItemHolder held_item, in CCycleItemStorage cycle)
			{
				if (storage.IsStack)
				{
					if (cycle.Reverse)
					{
						if (stored_items.Length > 0)
						{
							Entity storedItem = stored_items[stored_items.Length - 1].StoredItem;
							if (storedItem != default(Entity))
							{
								ctx.UpdateHolder(storedItem, e);
								ctx.Remove<CStoredBy>(storedItem);
								stored_items[stored_items.Length - 1] = Entity.Null;
							}
						}
						if (held_item.HeldItem != default(Entity))
						{
							stored_items.Insert(0, held_item.HeldItem);
							ctx.Set(held_item, new CStoredBy
							{
								Storage = e
							});
							ctx.UpdateHolder(held_item.HeldItem);
						}
					}
					else
					{
						if (held_item.HeldItem != default(Entity))
						{
							stored_items.Add(held_item.HeldItem);
							ctx.Set(held_item, new CStoredBy
							{
								Storage = e
							});
							ctx.UpdateHolder(held_item.HeldItem);
						}
						if (stored_items.Length > 0)
						{
							Entity storedItem2 = stored_items[0].StoredItem;
							if (storedItem2 != default(Entity))
							{
								ctx.UpdateHolder(storedItem2, e);
								ctx.Remove<CStoredBy>(storedItem2);
								stored_items[0] = default(CItemStored);
							}
						}
					}
				}
				else
				{
					for (int i = stored_items.Length; i < storage.Capacity; i++)
					{
						stored_items.Add(default(CItemStored));
					}
					if (held_item.HeldItem != default(Entity))
					{
						stored_items[storage.ActiveIndex] = held_item.HeldItem;
						ctx.Set(held_item, new CStoredBy
						{
							Storage = e
						});
						ctx.UpdateHolder(held_item.HeldItem);
					}
					storage.ActiveIndex = (storage.ActiveIndex + ((!cycle.Reverse) ? 1 : (-1)) + storage.Capacity) % storage.Capacity;
					if (storage.ActiveIndex < stored_items.Length && stored_items[storage.ActiveIndex].StoredItem != default(Entity))
					{
						ctx.UpdateHolder(stored_items[storage.ActiveIndex], e);
						ctx.Remove<CStoredBy>(stored_items[storage.ActiveIndex]);
						stored_items[storage.ActiveIndex] = default(CItemStored);
					}
				}
				ctx.Remove<CCycleItemStorage>(e);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				ctx = displayClass.ctx;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass.ctx = ctx;
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
					Entity e = runtimes.runtime_e.For(i);
					DynamicBuffer<CItemStored> stored_items = runtimes.runtime_stored_items.For(i);
					OriginalLambdaBody(e, ref stored_items, ref runtimes.runtime_storage.For(i), in runtimes.runtime_held_item.For(i), in runtimes.runtime_cycle.For(i));
				}
			}

			public void ScheduleTimeInitialize(CycleStorageAppliance componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
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
			_003C_003Ec__DisplayClass0_0 displayClass = default(_003C_003Ec__DisplayClass0_0);
			EntityCommandBuffer commandBuffer = GetCommandBuffer(ECB.End);
			displayClass.ctx = new EntityContext(base.EntityManager, commandBuffer);
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
			(array[0] = new EntityQueryDesc()).All = new ComponentType[4]
			{
				ComponentType.ReadWrite<CItemStored>(),
				ComponentType.ReadWrite<CItemStorage>(),
				ComponentType.ReadOnly<CItemHolder>(),
				ComponentType.ReadOnly<CCycleItemStorage>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
