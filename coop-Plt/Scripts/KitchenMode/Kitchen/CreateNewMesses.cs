#define ENABLE_PROFILER
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kitchen.Layouts;
using KitchenData;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	public class CreateNewMesses : GameSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass0_0
		{
			public bool has_created_spill;

			public EntityCommandBuffer ecb;

			public CreateNewMesses _003C_003E4__this;

			public Vector3 front_door_tile;

			internal void _003COnUpdate_003Eb__0(Entity e, in CMessRequest request, in CPosition position)
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

					public LambdaParameterValueProvider_IComponentData<CMessRequest>.Runtime runtime_request;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_position;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CMessRequest> forParameter_request;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_position;

				public void ScheduleTimeInitialize(CreateNewMesses componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_request.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_position.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_request = forParameter_request.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_position = forParameter_position.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public bool has_created_spill;

			public EntityCommandBuffer ecb;

			public CreateNewMesses _003C_003E4__this;

			public Vector3 front_door_tile;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CStackableMess> _ComponentDataFromEntity_CStackableMess_0;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CMessRequest request, in CPosition position)
			{
				if (has_created_spill)
				{
					return;
				}
				ecb.DestroyEntity(e);
				int num = ((request.ID == 0) ? AssetReference.CustomerMess : request.ID);
				bool overwrite = request.OverwriteOtherMesses;
				if (!_003C_003E4__this.FindMessLocation(position, front_door_tile, out var output, out var occ, num, ref overwrite))
				{
					return;
				}
				if (occ != default(Entity))
				{
					if (!overwrite)
					{
						num = _ComponentDataFromEntity_CStackableMess_0[occ].NextMess;
					}
					ecb.DestroyEntity(occ);
				}
				Vector2 insideUnitCircle = Random.insideUnitCircle;
				output += new Vector3(insideUnitCircle.x, 0f, insideUnitCircle.y) * 0.25f;
				Entity e2 = ecb.CreateEntity();
				ecb.AddComponent(e2, new CCreateAppliance
				{
					ID = num,
					ForceLayer = OccupancyLayer.Floor
				});
				ecb.AddComponent(e2, new CPosition(output));
				ecb.AddComponent(e2, default(CMess));
				has_created_spill = true;
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				has_created_spill = displayClass.has_created_spill;
				ecb = displayClass.ecb;
				_003C_003E4__this = displayClass._003C_003E4__this;
				front_door_tile = displayClass.front_door_tile;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				displayClass.has_created_spill = has_created_spill;
				displayClass.ecb = ecb;
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.front_door_tile = front_door_tile;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_request.For(i), in runtimes.runtime_position.For(i));
				}
			}

			public void ScheduleTimeInitialize(CreateNewMesses componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CStackableMess_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CStackableMess>(true);
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
				has_created_spill = false,
				ecb = new EntityCommandBuffer(Allocator.TempJob),
				front_door_tile = GetFrontDoor()
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

		protected bool FindMessLocation(Vector3 location, Vector3 front_door, out Vector3 output, out Entity occ, int mess, ref bool overwrite)
		{
			Vector3 vector = location.Rounded();
			foreach (LayoutPosition item in (HasStatus(RestaurantStatus.MessRangeIncrease) ? LayoutHelpers.AllNearbyRange2 : LayoutHelpers.AllNearby).Shuffle())
			{
				Vector3 vector2 = (Vector3)item + vector;
				if (vector2 == front_door || base.TileManager.GetOccupant(vector2) != default(Entity))
				{
					continue;
				}
				occ = base.TileManager.GetOccupant(vector2, OccupancyLayer.Floor);
				bool flag = HasComponent<CStackableMess>(occ);
				bool flag2 = flag && GetComponent<CStackableMess>(occ).BaseMess == mess;
				if ((occ == default(Entity) || flag2 || (overwrite && flag)) && base.TileManager.CanReach(vector, vector2))
				{
					output = vector2;
					if (!flag || flag2)
					{
						overwrite = false;
					}
					return true;
				}
			}
			occ = default(Entity);
			output = Vector3.negativeInfinity;
			return false;
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
				ComponentType.ReadOnly<CMessRequest>(),
				ComponentType.ReadOnly<CPosition>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
