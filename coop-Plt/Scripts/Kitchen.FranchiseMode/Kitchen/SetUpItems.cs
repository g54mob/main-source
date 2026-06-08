#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;

namespace Kitchen
{
	[UpdateAfter(typeof(CreateGarage))]
	[UpdateAfter(typeof(CreateOffice))]
	public class SetUpItems : FranchiseSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass4_0
		{
			public SetUpItems _003C_003E4__this;

			public NativeArray<Entity> slots;

			public NativeArray<CPosition> slot_positions;

			public NativeArray<CPersistentItemStorageLocation> slot_types;

			public EntityCommandBuffer ecb;

			public NativeArray<CItemHolder> slot_holdings;

			internal void _003COnUpdate_003Eb__0(Entity e, in CCreateItem create)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003COnUpdate_003Eb__1(Entity e, in CPersistentItem persist, in CPosition pos)
			{
				LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
			}

			internal void _003COnUpdate_003Eb__2(Entity e, in CPersistentItem persist)
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

					public LambdaParameterValueProvider_IComponentData<CCreateItem>.Runtime runtime_create;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CCreateItem> forParameter_create;

				public void ScheduleTimeInitialize(SetUpItems componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_create.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_create = forParameter_create.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public SetUpItems _003C_003E4__this;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CCreateItem create)
			{
				_003C_003E4__this.UsedSlots.Add(create.Holder);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_create.For(i));
				}
			}

			public void ScheduleTimeInitialize(SetUpItems componentSystem, ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CPersistentItem>.Runtime runtime_persist;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPersistentItem> forParameter_persist;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				public void ScheduleTimeInitialize(SetUpItems componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_persist.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_persist = forParameter_persist.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public NativeArray<Entity> slots;

			public NativeArray<CPosition> slot_positions;

			public NativeArray<CPersistentItemStorageLocation> slot_types;

			public SetUpItems _003C_003E4__this;

			public EntityCommandBuffer ecb;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CPersistentItem persist, in CPosition pos)
			{
				for (int i = 0; i < slots.Length; i++)
				{
					Entity entity = slots[i];
					CPosition cPosition = slot_positions[i];
					CPersistentItemStorageLocation cPersistentItemStorageLocation = slot_types[i];
					if (!_003C_003E4__this.UsedSlots.Contains(entity) && cPersistentItemStorageLocation.Type == persist.Type && !((pos.Position - cPosition.Position).Chebyshev() > 0.2f))
					{
						_003C_003E4__this.UsedSlots.Add(entity);
						ecb.AddComponent(e, new CCreateItem
						{
							Holder = entity,
							ID = persist.ItemID
						});
						return;
					}
				}
				ecb.RemoveComponent<CPosition>(e);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				slots = displayClass.slots;
				slot_positions = displayClass.slot_positions;
				slot_types = displayClass.slot_types;
				_003C_003E4__this = displayClass._003C_003E4__this;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				displayClass.slots = slots;
				displayClass.slot_positions = slot_positions;
				displayClass.slot_types = slot_types;
				displayClass._003C_003E4__this = _003C_003E4__this;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_persist.For(i), in runtimes.runtime_pos.For(i));
				}
			}

			public void ScheduleTimeInitialize(SetUpItems componentSystem, ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1>(jobData), ref *archetypeChunkIterator);
			}
		}

		[Unity.Entities.DOTSCompilerGenerated]
		private struct _003C_003Ec__DisplayClass_OnUpdate_LambdaJob2 : IJobChunk
		{
			private struct LambdaParameterValueProviders
			{
				public struct Runtimes
				{
					public LambdaParameterValueProvider_Entity.Runtime runtime_e;

					public LambdaParameterValueProvider_IComponentData<CPersistentItem>.Runtime runtime_persist;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPersistentItem> forParameter_persist;

				public void ScheduleTimeInitialize(SetUpItems componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_persist.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_persist = forParameter_persist.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public NativeArray<CPersistentItemStorageLocation> slot_types;

			public SetUpItems _003C_003E4__this;

			public NativeArray<Entity> slots;

			public NativeArray<CItemHolder> slot_holdings;

			public EntityCommandBuffer ecb;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CPersistentItem persist)
			{
				for (int i = 0; i < slot_holdings.Length; i++)
				{
					if (slot_types[i].Type == persist.Type && !_003C_003E4__this.UsedSlots.Contains(slots[i]) && slot_holdings[i].HeldItem == default(Entity))
					{
						_003C_003E4__this.UsedSlots.Add(slots[i]);
						ecb.AddComponent(e, new CCreateItem
						{
							Holder = slots[i],
							ID = persist.ItemID
						});
						break;
					}
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				slot_types = displayClass.slot_types;
				_003C_003E4__this = displayClass._003C_003E4__this;
				slots = displayClass.slots;
				slot_holdings = displayClass.slot_holdings;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				displayClass.slot_types = slot_types;
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.slots = slots;
				displayClass.slot_holdings = slot_holdings;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_persist.For(i));
				}
			}

			public void ScheduleTimeInitialize(SetUpItems componentSystem, ref _003C_003Ec__DisplayClass4_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery Slots;

		private NativeHashSet<Entity> UsedSlots;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		private EntityQuery _003C_003EOnUpdate_LambdaJob1_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob1_profilerMarker;

		private EntityQuery _003C_003EOnUpdate_LambdaJob2_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob2_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			Slots = GetEntityQuery(typeof(CPersistentItemStorageLocation), typeof(CItemHolder), typeof(CPosition));
			RequireForUpdate(Slots);
			UsedSlots = new NativeHashSet<Entity>(30, Allocator.Persistent);
		}

		protected override void OnDestroy()
		{
			UsedSlots.Dispose();
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass4_0 displayClass = new _003C_003Ec__DisplayClass4_0
			{
				_003C_003E4__this = this,
				ecb = GetCommandBuffer(ECB.End),
				slots = Slots.ToEntityArray(Allocator.TempJob)
			};
			try
			{
				displayClass.slot_positions = Slots.ToComponentDataArray<CPosition>(Allocator.TempJob);
				try
				{
					displayClass.slot_types = Slots.ToComponentDataArray<CPersistentItemStorageLocation>(Allocator.TempJob);
					try
					{
						displayClass.slot_holdings = Slots.ToComponentDataArray<CItemHolder>(Allocator.TempJob);
						try
						{
							UsedSlots.Clear();
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
							_ = base.Entities;
							_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1 jobData2 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1);
							jobData2.ScheduleTimeInitialize(this, ref displayClass);
							CompleteDependency();
							EntityQuery query2 = _003C_003EOnUpdate_LambdaJob1_entityQuery;
							InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst2 = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst;
							_003C_003EOnUpdate_LambdaJob1_profilerMarker.Begin();
							try
							{
								InternalCompilerInterface.RunJobChunk(ref jobData2, query2, s_RunWithoutJobSystemDelegateFieldNoBurst2);
							}
							finally
							{
								_003C_003EOnUpdate_LambdaJob1_profilerMarker.End();
							}
							jobData2.WriteToDisplayClass(ref displayClass);
							_ = base.Entities;
							_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2 jobData3 = default(_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2);
							jobData3.ScheduleTimeInitialize(this, ref displayClass);
							CompleteDependency();
							EntityQuery query3 = _003C_003EOnUpdate_LambdaJob2_entityQuery;
							InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst3 = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst;
							_003C_003EOnUpdate_LambdaJob2_profilerMarker.Begin();
							try
							{
								InternalCompilerInterface.RunJobChunk(ref jobData3, query3, s_RunWithoutJobSystemDelegateFieldNoBurst3);
							}
							finally
							{
								_003C_003EOnUpdate_LambdaJob2_profilerMarker.End();
							}
							jobData3.WriteToDisplayClass(ref displayClass);
						}
						finally
						{
							((IDisposable)displayClass.slot_holdings/*cast due to .constrained prefix*/).Dispose();
						}
					}
					finally
					{
						((IDisposable)displayClass.slot_types/*cast due to .constrained prefix*/).Dispose();
					}
				}
				finally
				{
					((IDisposable)displayClass.slot_positions/*cast due to .constrained prefix*/).Dispose();
				}
			}
			finally
			{
				((IDisposable)displayClass.slots/*cast due to .constrained prefix*/).Dispose();
			}
		}

		protected internal unsafe override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_003C_003EOnUpdate_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob0.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob0_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob0");
			_003C_003EOnUpdate_LambdaJob1_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob1.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob1_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob1");
			_003C_003EOnUpdate_LambdaJob2_entityQuery = _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob2_From(this);
			_003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_OnUpdate_LambdaJob2.RunWithoutJobSystem;
			_003C_003EOnUpdate_LambdaJob2_profilerMarker = new ProfilerMarker("OnUpdate_LambdaJob2");
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[1] { ComponentType.ReadOnly<CCreateItem>() };
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob1_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[2]
			{
				ComponentType.ReadOnly<CPersistentItem>(),
				ComponentType.ReadOnly<CPosition>()
			};
			entityQueryDesc.None = new ComponentType[2]
			{
				ComponentType.ReadWrite<CCreateItem>(),
				ComponentType.ReadWrite<CItem>()
			};
			return componentSystem.GetEntityQuery(array);
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob2_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[1] { ComponentType.ReadOnly<CPersistentItem>() };
			entityQueryDesc.None = new ComponentType[3]
			{
				ComponentType.ReadWrite<CCreateItem>(),
				ComponentType.ReadWrite<CItem>(),
				ComponentType.ReadWrite<CPosition>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
