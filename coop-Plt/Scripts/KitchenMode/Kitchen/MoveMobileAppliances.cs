#define ENABLE_PROFILER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kitchen.Layouts;
using KitchenData;
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
	public class MoveMobileAppliances : GameSystemBase
	{
		public enum TargetPriority
		{
			None = 0,
			Base = 1,
			Unclean = 2,
			Dirt = 3
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public MoveMobileAppliances _003C_003E4__this;

			public float dt;

			internal void _003COnUpdate_003Eb__0(Entity e, ref CPosition pos, ref CMobileAppliance mobile)
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

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_pos;

					public LambdaParameterValueProvider_IComponentData<CMobileAppliance>.Runtime runtime_mobile;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_pos;

				private LambdaParameterValueProvider_IComponentData<CMobileAppliance> forParameter_mobile;

				public void ScheduleTimeInitialize(MoveMobileAppliances componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_pos.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
					forParameter_mobile.ScheduleTimeInitialize(componentSystem, isReadOnly: false);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_pos = forParameter_pos.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_mobile = forParameter_mobile.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public MoveMobileAppliances _003C_003E4__this;

			public float dt;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CAllowMobilePathing> _ComponentDataFromEntity_CAllowMobilePathing_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CMess> _ComponentDataFromEntity_CMess_1;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, ref CPosition pos, ref CMobileAppliance mobile)
			{
				Vector3 vector = mobile.Target - pos.Position;
				if (vector.sqrMagnitude < 0.01f || vector.sqrMagnitude > 1.5f)
				{
					Vector3 vector2 = pos.Position.Rounded();
					_003C_003E4__this.Directions.ShuffleInPlace();
					int room = _003C_003E4__this.TileManager.GetRoom(vector2);
					TargetPriority targetPriority = TargetPriority.None;
					Vector3 target = Vector3.zero;
					foreach (LayoutPosition direction in _003C_003E4__this.Directions)
					{
						Vector3 vector3 = (Vector3)direction + vector2;
						Entity occupant = _003C_003E4__this.TileManager.GetOccupant(vector3);
						if ((!(occupant != default(Entity)) || _ComponentDataFromEntity_CAllowMobilePathing_0.HasComponent(occupant)) && _003C_003E4__this.TileManager.GetRoom(vector3) == room)
						{
							if (!mobile.AimForDirt)
							{
								mobile.Target = vector3;
								return;
							}
							Entity occupant2 = _003C_003E4__this.TileManager.GetOccupant(vector3, OccupancyLayer.Floor);
							if (_ComponentDataFromEntity_CMess_1.HasComponent(occupant2))
							{
								target = vector3;
								targetPriority = TargetPriority.Dirt;
								break;
							}
							if (occupant2 == default(Entity))
							{
								targetPriority = TargetPriority.Unclean;
								target = vector3;
							}
							else if (targetPriority == TargetPriority.None)
							{
								target = vector3;
								targetPriority = TargetPriority.Base;
							}
						}
					}
					if (targetPriority != TargetPriority.None)
					{
						mobile.Target = target;
					}
					else
					{
						mobile.Target = vector2;
					}
				}
				else
				{
					pos.Rotation = quaternion.LookRotation(vector, new float3(0f, 1f, 0f));
					pos.Position += vector.normalized * dt * mobile.Speed * 0.5f;
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				dt = displayClass.dt;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				displayClass._003C_003E4__this = _003C_003E4__this;
				displayClass.dt = dt;
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), ref runtimes.runtime_pos.For(i), ref runtimes.runtime_mobile.For(i));
				}
			}

			public void ScheduleTimeInitialize(MoveMobileAppliances componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CAllowMobilePathing_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CAllowMobilePathing>(true);
				_ComponentDataFromEntity_CMess_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CMess>(true);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private List<LayoutPosition> Directions;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
			{
				_003C_003E4__this = this
			};
			if (Directions == null)
			{
				Directions = new List<LayoutPosition>(LayoutHelpers.Directions);
			}
			displayClass.dt = base.Time.DeltaTime;
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
			EntityQueryDesc entityQueryDesc = (array[0] = new EntityQueryDesc());
			entityQueryDesc.All = new ComponentType[2]
			{
				ComponentType.ReadWrite<CPosition>(),
				ComponentType.ReadWrite<CMobileAppliance>()
			};
			entityQueryDesc.None = new ComponentType[2]
			{
				ComponentType.ReadWrite<CDisableAutomation>(),
				ComponentType.ReadWrite<CHeldAppliance>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
