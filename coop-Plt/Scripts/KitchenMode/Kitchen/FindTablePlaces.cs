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
using UnityEngine.AI;

namespace Kitchen
{
	[UpdateAfter(typeof(AssembleTableSets))]
	[UpdateInGroup(typeof(TableUpdatesGroup))]
	public class FindTablePlaces : TableUpdateSystem
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public FindTablePlaces _003C_003E4__this;

			public SPerformTableUpdate spec;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, ref DynamicBuffer<CTablePlace> places, ref DynamicBuffer<CTableSetParts> parts)
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

					public LambdaParameterValueProvider_DynamicBuffer<CTablePlace>.Runtime runtime_places;

					public LambdaParameterValueProvider_DynamicBuffer<CTableSetParts>.Runtime runtime_parts;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_DynamicBuffer<CTablePlace> forParameter_places;

				private LambdaParameterValueProvider_DynamicBuffer<CTableSetParts> forParameter_parts;

				public void ScheduleTimeInitialize(FindTablePlaces componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_places.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_parts.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_places = forParameter_places.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_parts = forParameter_parts.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public FindTablePlaces _003C_003E4__this;

			public SPerformTableUpdate spec;

			public EntityCommandBuffer ecb;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CPosition> _ComponentDataFromEntity_CPosition_0;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CApplianceTable> _ComponentDataFromEntity_CApplianceTable_1;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CApplianceChair> _ComponentDataFromEntity_CApplianceChair_2;

			[NoAlias]
			private ComponentDataFromEntity<CInteractionProxy> _ComponentDataFromEntity_CInteractionProxy_3;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref DynamicBuffer<CTablePlace> places, ref DynamicBuffer<CTableSetParts> parts)
			{
				places.Clear();
				foreach (CTableSetParts part in parts)
				{
					CPosition cPosition = _ComponentDataFromEntity_CPosition_0[part];
					int room = _003C_003E4__this.TileManager.GetRoom(cPosition);
					CApplianceTable component = _ComponentDataFromEntity_CApplianceTable_1[part];
					component.ActiveChairs = Orientation.Null;
					Orientation[] all = OrientationHelpers.All;
					foreach (Orientation orientation in all)
					{
						Orientation o = cPosition.Rotation.RotateOrientation(orientation);
						if (component.PreventsSitting(orientation))
						{
							continue;
						}
						Vector3 vector = o.ToOffset() + cPosition;
						if (room != _003C_003E4__this.TileManager.GetRoom(vector))
						{
							continue;
						}
						Entity occupant = _003C_003E4__this.TileManager.GetOccupant(vector);
						if (!_ComponentDataFromEntity_CApplianceChair_2.HasComponent(occupant) || _003C_003E4__this.AssignedPlaces.Contains(occupant) || !_003C_003E4__this.EntityManager.RequireComponent<CPosition>(occupant, out var component2) || (component2.BackwardPosition - cPosition).Chebyshev() > 0.2f)
						{
							continue;
						}
						if (spec.EnforcePaths)
						{
							NavMesh.CalculatePath(spec.PathingSource, vector, -1, _003C_003E4__this.Path);
							if (_003C_003E4__this.Path.status != NavMeshPathStatus.PathComplete)
							{
								continue;
							}
						}
						places.Add(new CTablePlace
						{
							SeatPosition = new CPosition(vector, quaternion.LookRotation(cPosition - vector, new float3(0f, 1f, 0f))),
							TablePosition = cPosition.Position,
							Chair = occupant
						});
						component.ActiveChairs |= orientation;
						if (_ComponentDataFromEntity_CInteractionProxy_3.HasComponent(occupant))
						{
							_ComponentDataFromEntity_CInteractionProxy_3[occupant] = new CInteractionProxy
							{
								Target = part,
								IsActive = true
							};
						}
						_003C_003E4__this.AssignedPlaces.Add(occupant);
						ecb.SetComponent(occupant, new CPosition(vector, quaternion.LookRotation(vector - cPosition, new float3(0f, 1f, 0f))));
					}
					ecb.SetComponent(part, component);
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				spec = displayClass.spec;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.spec = spec;
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
					DynamicBuffer<CTablePlace> places = runtimes.runtime_places.For(i);
					DynamicBuffer<CTableSetParts> parts = runtimes.runtime_parts.For(i);
					OriginalLambdaBody(e, ref places, ref parts);
				}
			}

			public void ScheduleTimeInitialize(FindTablePlaces componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CPosition_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPosition>(true);
				_ComponentDataFromEntity_CApplianceTable_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CApplianceTable>(true);
				_ComponentDataFromEntity_CApplianceChair_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CApplianceChair>(true);
				_ComponentDataFromEntity_CInteractionProxy_3 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CInteractionProxy>(false);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private NavMeshPath Path = new NavMeshPath();

		private HashSet<Entity> AssignedPlaces = new HashSet<Entity>();

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SPerformTableUpdate_11;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
			{
				_003C_003E4__this = this,
				ecb = new EntityCommandBuffer(Allocator.TempJob)
			};
			AssignedPlaces.Clear();
			displayClass.spec = _SingletonEntityQuery_SPerformTableUpdate_11.GetSingleton<SPerformTableUpdate>();
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
			_SingletonEntityQuery_SPerformTableUpdate_11 = GetEntityQuery(ComponentType.ReadOnly<SPerformTableUpdate>());
		}

		public static EntityQuery _003C_003EGetEntityQuery_ForOnUpdate_LambdaJob0_From(ComponentSystemBase componentSystem)
		{
			EntityQueryDesc[] array = new EntityQueryDesc[1];
			(array[0] = new EntityQueryDesc()).All = new ComponentType[2]
			{
				ComponentType.ReadWrite<CTablePlace>(),
				ComponentType.ReadWrite<CTableSetParts>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
