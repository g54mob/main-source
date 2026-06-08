#define ENABLE_PROFILER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[UpdateAfter(typeof(CreateChairs))]
	[UpdateInGroup(typeof(TableUpdatesGroup), OrderFirst = true)]
	public class ClearUnusedChairs : RestaurantTableUpdateSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass1_0
		{
			public ClearUnusedChairs _003C_003E4__this;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, ref DynamicBuffer<CGhostChairTableCandidates> candidates, in CApplianceGhostChair chair, in CPosition pos)
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

					public LambdaParameterValueProvider_DynamicBuffer<CGhostChairTableCandidates>.Runtime runtime_candidates;

					public LambdaParameterValueProvider_IComponentData<CApplianceGhostChair>.Runtime runtime_chair;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_DynamicBuffer<CGhostChairTableCandidates> forParameter_candidates;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CApplianceGhostChair> forParameter_chair;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				public void ScheduleTimeInitialize(ClearUnusedChairs componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_candidates.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_chair.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_candidates = forParameter_candidates.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_chair = forParameter_chair.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public ClearUnusedChairs _003C_003E4__this;

			public EntityCommandBuffer ecb;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CApplianceTable> _ComponentDataFromEntity_CApplianceTable_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CPosition> _ComponentDataFromEntity_CPosition_1;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref DynamicBuffer<CGhostChairTableCandidates> candidates, in CApplianceGhostChair chair, in CPosition pos)
			{
				_003C_003E4__this.RemoveList.Clear();
				bool flag = false;
				for (int i = 0; i < candidates.Length; i++)
				{
					CGhostChairTableCandidates cGhostChairTableCandidates = candidates[i];
					Vector3 vector = ((Vector3)math.mul(cGhostChairTableCandidates.Rotation, new float3(0f, 0f, -1f)) + pos.Position).Rounded();
					Entity occupant = _003C_003E4__this.TileManager.GetOccupant(vector);
					bool flag2 = false;
					if (occupant == cGhostChairTableCandidates.Table && _ComponentDataFromEntity_CApplianceTable_0.HasComponent(occupant))
					{
						CApplianceTable cApplianceTable = _ComponentDataFromEntity_CApplianceTable_0[occupant];
						CPosition cPosition = _ComponentDataFromEntity_CPosition_1[occupant];
						Orientation o = OrientationHelpers.RotateOrientation(o: OrientationHelpers.GetRelativeOrientation(cPosition, pos), q: math.inverse(cPosition.Rotation));
						if (!cApplianceTable.PreventsSitting(o))
						{
							flag2 = true;
							if (cGhostChairTableCandidates.Table == chair.Table)
							{
								flag = true;
							}
						}
					}
					if (!flag2)
					{
						_003C_003E4__this.RemoveList.Add(i);
					}
				}
				if (!flag)
				{
					ecb.DestroyEntity(e);
					return;
				}
				for (int num = _003C_003E4__this.RemoveList.Count - 1; num >= 0; num--)
				{
					candidates.RemoveAt(_003C_003E4__this.RemoveList[num]);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass1_0 displayClass)
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
					DynamicBuffer<CGhostChairTableCandidates> candidates = runtimes.runtime_candidates.For(i);
					OriginalLambdaBody(e, ref candidates, in runtimes.runtime_chair.For(i), in runtimes.runtime_pos.For(i));
				}
			}

			public void ScheduleTimeInitialize(ClearUnusedChairs componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CApplianceTable_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CApplianceTable>(true);
				_ComponentDataFromEntity_CPosition_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPosition>(true);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private List<int> RemoveList = new List<int>();

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
			{
				_003C_003E4__this = this,
				ecb = new EntityCommandBuffer(Allocator.TempJob)
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
			displayClass.ecb.Playback(base.EntityManager);
			displayClass.ecb.Dispose();
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
				ComponentType.ReadOnly<CApplianceChair>(),
				ComponentType.ReadWrite<CGhostChairTableCandidates>(),
				ComponentType.ReadOnly<CApplianceGhostChair>(),
				ComponentType.ReadOnly<CPosition>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
