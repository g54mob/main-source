#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Profiling;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(InteractionGroup), OrderFirst = true)]
	[UpdateAfter(typeof(AttemptInteraction))]
	public class AttemptAutomatedInteraction : GenericSystemBase
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003C_003Ec__DisplayClass2_0
		{
			public AttemptAutomatedInteraction _003C_003E4__this;

			public EntityCommandBuffer ecb;

			internal void _003COnUpdate_003Eb__0(Entity e, int entityInQueryIndex, in CAutomatedInteractor auto, in CPosition position)
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

					public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

					public LambdaParameterValueProvider_IComponentData<CAutomatedInteractor>.Runtime runtime_auto;

					public LambdaParameterValueProvider_IComponentData<CPosition>.Runtime runtime_position;
				}

				[ReadOnly]
				private LambdaParameterValueProvider_Entity forParameter_e;

				[ReadOnly]
				private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CAutomatedInteractor> forParameter_auto;

				[ReadOnly]
				private LambdaParameterValueProvider_IComponentData<CPosition> forParameter_position;

				public void ScheduleTimeInitialize(AttemptAutomatedInteraction componentSystem)
				{
					forParameter_e.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_auto.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					forParameter_position.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
				}

				public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
				{
					return new Runtimes
					{
						runtime_e = forParameter_e.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
						runtime_auto = forParameter_auto.PrepareToExecuteOnEntitiesIn(ref p0),
						runtime_position = forParameter_position.PrepareToExecuteOnEntitiesIn(ref p0)
					};
				}
			}

			public AttemptAutomatedInteraction _003C_003E4__this;

			public EntityCommandBuffer ecb;

			private LambdaParameterValueProviders _lambdaParameterValueProviders;

			[NativeDisableUnsafePtrRestriction]
			private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

			private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

			internal void OriginalLambdaBody(Entity e, int entityInQueryIndex, in CAutomatedInteractor auto, in CPosition position)
			{
				if (_003C_003E4__this.Require<CAutomatedInteractorRandomActiveInterval>(e, out CAutomatedInteractorRandomActiveInterval comp) && !comp.Active)
				{
					return;
				}
				Vector3 forwardPosition = position.ForwardPosition;
				Entity occupant = _003C_003E4__this.TileManager.GetOccupant(forwardPosition);
				if (!_003C_003E4__this.TileManager.CanReach(position, forwardPosition) || occupant == default(Entity))
				{
					return;
				}
				ecb.AddComponent(e, new CAttemptingInteraction
				{
					Target = occupant,
					Type = auto.Type,
					IsHeld = auto.IsHeld,
					Location = forwardPosition,
					Mode = InteractionMode.Items,
					TransferOnly = auto.TransferOnly
				});
				if (auto.Type == InteractionType.Act)
				{
					if (!_003C_003E4__this.Has<CBeingActedOn>(occupant))
					{
						ecb.AddComponent<CBeingActedOn>(occupant);
					}
					if (_003C_003E4__this.HasBuffer<CBeingActedOnBy>(occupant))
					{
						ecb.AppendToBuffer(occupant, new CBeingActedOnBy
						{
							Interactor = e,
							IsTransferOnly = auto.TransferOnly
						});
					}
				}
				else if (!_003C_003E4__this.Has<CBeingGrabbed>(occupant))
				{
					ecb.AddComponent(occupant, new CBeingGrabbed
					{
						Interactor = e
					});
				}
			}

			public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_003C_003E4__this = displayClass._003C_003E4__this;
				ecb = displayClass.ecb;
			}

			public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass2_0 displayClass)
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
					OriginalLambdaBody(runtimes.runtime_e.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_auto.For(i), in runtimes.runtime_position.For(i));
				}
			}

			public void ScheduleTimeInitialize(AttemptAutomatedInteraction componentSystem, ref _003C_003Ec__DisplayClass2_0 displayClass)
			{
				_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
				ReadFromDisplayClass(ref displayClass);
			}

			public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
			{
				JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_OnUpdate_LambdaJob0>(jobData), ref *archetypeChunkIterator);
			}
		}

		private EntityQuery InteractivesQuery;

		private EntityQuery _003C_003EOnUpdate_LambdaJob0_entityQuery;

		private ProfilerMarker _003C_003EOnUpdate_LambdaJob0_profilerMarker;

		protected override void Initialise()
		{
			base.Initialise();
			InteractivesQuery = GetEntityQuery(typeof(CAutomatedInteractor));
		}

		protected override void OnUpdate()
		{
			_003C_003Ec__DisplayClass2_0 displayClass = new _003C_003Ec__DisplayClass2_0
			{
				_003C_003E4__this = this
			};
			base.EntityManager.RemoveComponent(InteractivesQuery, typeof(CAttemptingInteraction));
			displayClass.ecb = new EntityCommandBuffer(Allocator.TempJob);
			try
			{
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
			}
			finally
			{
				((IDisposable)displayClass.ecb/*cast due to .constrained prefix*/).Dispose();
			}
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
				ComponentType.ReadOnly<CAutomatedInteractor>(),
				ComponentType.ReadOnly<CPosition>()
			};
			entityQueryDesc.None = new ComponentType[1] { ComponentType.ReadWrite<CDisableAutomation>() };
			return componentSystem.GetEntityQuery(array);
		}
	}
}
