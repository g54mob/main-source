#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KitchenData;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class SpawnTableDirt : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public SpawnTableDirt _003C_003E4__this;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, ref DynamicBuffer<CDirtItem> dirt_items, in DynamicBuffer<CTableSetParts> parts, in CTableSpawnDirt request)
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

					public LambdaParameterValueProvider_DynamicBuffer<CDirtItem>.Runtime runtime_dirt_items;

					public LambdaParameterValueProvider_DynamicBuffer<CTableSetParts>.Runtime runtime_parts;

					public LambdaParameterValueProvider_IComponentData<CTableSpawnDirt>.Runtime runtime_request;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_DynamicBuffer<CDirtItem> forParameter_dirt_items;

				[ReadOnly]
				private LambdaParameterValueProvider_DynamicBuffer<CTableSetParts> forParameter_parts;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CTableSpawnDirt> forParameter_request;

				public void ScheduleTimeInitialize(SpawnTableDirt componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_dirt_items.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_parts.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_request.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_dirt_items = forParameter_dirt_items.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_parts = forParameter_parts.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_request = forParameter_request.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public SpawnTableDirt _003C_003E4__this;

			public EntityCommandBuffer ecb;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref DynamicBuffer<CDirtItem> dirt_items, in DynamicBuffer<CTableSetParts> parts, in CTableSpawnDirt request)
			{
				_003C_003E4__this.SpawnDirt(parts, dirt_items, ecb, e, request);
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
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
					Entity e = runtimes.runtime_e.For(i);
					DynamicBuffer<CDirtItem> dirt_items = runtimes.runtime_dirt_items.For(i);
					OriginalLambdaBody(e, ref dirt_items, runtimes.runtime_parts.For(i), in runtimes.runtime_request.For(i));
				}
			}

			public void ScheduleTimeInitialize(SpawnTableDirt componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
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
			_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
			{
				_003C_003E4__this = this,
				ecb = GetCommandBuffer(ECB.End)
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

		private void SpawnDirt(DynamicBuffer<CTableSetParts> parts, DynamicBuffer<CDirtItem> dirt_items, EntityCommandBuffer ecb, Entity e, CTableSpawnDirt request)
		{
			if (parts.IsEmpty)
			{
				return;
			}
			CTableSetParts cTableSetParts = parts[0];
			foreach (CDirtItem item in dirt_items)
			{
				int iD = item.ID;
				bool flag = false;
				if (Require<CHalloweenOrder>(e, out CHalloweenOrder comp))
				{
					flag = comp.State == TrickTreatStates.TrickExtraRubbish;
				}
				if (!request.BlockExtendedDirt && (flag || (Random.value < 0.5f && HasStatus(RestaurantStatus.LeaveExtendedDirt))) && base.Data.TryGet<Item>(iD, out var output) && output.ExtendedDirtItem != null)
				{
					iD = output.ExtendedDirtItem.ID;
				}
				Entity entity = ecb.CreateEntity();
				ecb.AddComponent(entity, new CCreateItem
				{
					ID = iD
				});
				ecb.AddComponent(entity, new CStoredBy
				{
					Storage = cTableSetParts
				});
				ecb.AppendToBuffer(cTableSetParts, new CItemStored
				{
					StoredItem = entity
				});
			}
			dirt_items.Clear();
			for (int i = 0; i < parts.Length; i++)
			{
				CTableSetParts cTableSetParts2 = parts[i];
				if (request.ReuseConsumables || Has<CPreserveTableConsumables>(cTableSetParts2))
				{
					continue;
				}
				DynamicBuffer<CAttachments> buffer = GetBuffer<CAttachments>(cTableSetParts2);
				for (int j = 0; j < buffer.Length; j++)
				{
					CAttachments cAttachments = buffer[j];
					if (HasComponent<CDestroyAfterTableUsed>(cAttachments))
					{
						ecb.DestroyEntity(cAttachments);
					}
				}
			}
			ecb.RemoveComponent<CTableSpawnDirt>(e);
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
				ComponentType.ReadOnly<CTableSpawnDirt>(),
				ComponentType.ReadWrite<CDirtItem>(),
				ComponentType.ReadOnly<CTableSetParts>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
