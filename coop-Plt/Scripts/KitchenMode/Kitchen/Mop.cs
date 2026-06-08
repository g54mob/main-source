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
	public class Mop : GenericSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass1_0
		{
			public Mop _003C_003E4__this;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, in CToolClean clean, in CToolInUse user)
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

					public LambdaParameterValueProvider_IComponentData<CToolClean>.Runtime runtime_clean;

					public LambdaParameterValueProvider_IComponentData<CToolInUse>.Runtime runtime_user;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CToolClean> forParameter_clean;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CToolInUse> forParameter_user;

				public void ScheduleTimeInitialize(Mop componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_clean.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_user.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_clean = forParameter_clean.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_user = forParameter_user.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public Mop _003C_003E4__this;

			public EntityCommandBuffer ecb;

			[NoAlias]
			[ReadOnly]
			private ComponentDataFromEntity<CIsInteractor> _ComponentDataFromEntity_CIsInteractor_0;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CPosition> _ComponentDataFromEntity_CPosition_1;

			[ReadOnly]
			[NoAlias]
			private ComponentDataFromEntity<CMess> _ComponentDataFromEntity_CMess_2;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, in CToolClean clean, in CToolInUse user)
			{
				if (!_ComponentDataFromEntity_CIsInteractor_0.HasComponent(user.User) || !_ComponentDataFromEntity_CPosition_1.HasComponent(user.User))
				{
					return;
				}
				CPosition cPosition = _ComponentDataFromEntity_CPosition_1[user.User];
				Entity occupant = _003C_003E4__this.TileManager.GetOccupant(cPosition.Position, OccupancyLayer.Floor);
				if (occupant != default(Entity))
				{
					if (clean.CanRefresh && _003C_003E4__this.Require<CAppliance>(occupant, out CAppliance comp) && comp.ID == clean.WaterAppliance && _003C_003E4__this.Require<CTakesDuration>(occupant, out CTakesDuration comp2))
					{
						comp2.Remaining = comp2.Total;
						_003C_003E4__this.Set(occupant, comp2);
					}
					if (clean.CanReplace && _ComponentDataFromEntity_CMess_2.HasComponent(occupant))
					{
						ecb.DestroyEntity(occupant);
					}
				}
				else if (clean.WaterAppliance != 0)
				{
					Entity e2 = ecb.CreateEntity();
					ecb.AddComponent(e2, new CCreateAppliance
					{
						ID = clean.WaterAppliance,
						ForceLayer = OccupancyLayer.Floor
					});
					ecb.AddComponent(e2, CPosition.Rounded(cPosition));
					CSoundEvent.Create(ecb, SoundEvent.MopWater);
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), in runtimes.runtime_clean.For(i), in runtimes.runtime_user.For(i));
				}
			}

			public void ScheduleTimeInitialize(Mop componentSystem, ref _003C_003Ec__DisplayClass1_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
				_ComponentDataFromEntity_CIsInteractor_0 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CIsInteractor>(true);
				_ComponentDataFromEntity_CPosition_1 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CPosition>(true);
				_ComponentDataFromEntity_CMess_2 = ((ComponentSystemBase)componentSystem).GetComponentDataFromEntity<CMess>(true);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			RequireForUpdate(GetEntityQuery(typeof(CToolClean)));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass1_0 displayClass = new _003C_003Ec__DisplayClass1_0
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
				ComponentType.ReadOnly<CToolClean>(),
				ComponentType.ReadOnly<CToolInUse>()
			};
			return componentSystem.GetEntityQuery(array);
		}
	}
}
