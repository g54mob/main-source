#define ENABLE_PROFILER
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MessagePack;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.CodeGeneratedJobForEach;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Kitchen
{
	[Serializable]
	public class CustomerView : UpdatableObjectView<CustomerView.ViewData>
	{
		public class UpdateSystem : BurstIncrementalViewSystemBase<ViewData>
		{
			[StructLayout(LayoutKind.Auto)]
			[CompilerGenerated]
			private struct _003C_003Ec__DisplayClass0_0
			{
				public EntityContext ctx;

				public Vector3 front_door;

				public BurstContext bctx;

				public SGameTime game_time;

				internal void _003CPopulateNewViewUpdates_003Eb__0(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CCustomer customer, in CCustomerState state)
				{
					LambdaForEachDescriptionConstructionMethods.ThrowCodeGenInvalidMethodCalledException();
				}
			}

			[NoAlias]
			[Unity.Entities.DOTSCompilerGenerated]
			[BurstCompile]
			private struct _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 : IJobChunk
			{
				private struct LambdaParameterValueProviders
				{
					[NoAlias]
					public struct Runtimes
					{
						[NoAlias]
						public LambdaParameterValueProvider_Entity.Runtime runtime_entity;

						[NoAlias]
						public LambdaParameterValueProvider_EntityInQueryIndex.Runtime runtime_entityInQueryIndex;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CLinkedView>.Runtime runtime_linked_view;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CCustomer>.Runtime runtime_customer;

						[NoAlias]
						public LambdaParameterValueProvider_IComponentData<CCustomerState>.Runtime runtime_state;
					}

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_Entity forParameter_entity;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_EntityInQueryIndex forParameter_entityInQueryIndex;

					[NoAlias]
					[ReadOnly]
					private LambdaParameterValueProvider_IComponentData<CLinkedView> forParameter_linked_view;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CCustomer> forParameter_customer;

					[ReadOnly]
					[NoAlias]
					private LambdaParameterValueProvider_IComponentData<CCustomerState> forParameter_state;

					public void ScheduleTimeInitialize(UpdateSystem componentSystem)
					{
						forParameter_entity.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_entityInQueryIndex.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_linked_view.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_customer.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
						forParameter_state.ScheduleTimeInitialize(componentSystem, isReadOnly: true);
					}

					public Runtimes PrepareToExecuteOnEntitiesInMethod(ref ArchetypeChunk p0, int p1, int p2)
					{
						return new Runtimes
						{
							runtime_entity = forParameter_entity.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_entityInQueryIndex = forParameter_entityInQueryIndex.PrepareToExecuteOnEntitiesIn(ref p0, p1, p2),
							runtime_linked_view = forParameter_linked_view.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_customer = forParameter_customer.PrepareToExecuteOnEntitiesIn(ref p0),
							runtime_state = forParameter_state.PrepareToExecuteOnEntitiesIn(ref p0)
						};
					}
				}

				public unsafe delegate void RunWithoutJobSystem_00000AF8_0024PostfixBurstDelegate(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData);

				internal static class RunWithoutJobSystem_00000AF8_0024BurstDirectCall
				{
					private static IntPtr Pointer;

					private static IntPtr DeferredCompilation;

					[BurstDiscard]
					private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
					{
						if (Pointer == (IntPtr)0)
						{
							Pointer = (IntPtr)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(RunWithoutJobSystem_00000AF8_0024PostfixBurstDelegate).TypeHandle);
						}
						P_0 = Pointer;
					}

					private static IntPtr GetFunctionPointer()
					{
						IntPtr result = (IntPtr)0;
						GetFunctionPointerDiscard(ref result);
						return result;
					}

					public static void Constructor()
					{
						DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
					}

					public static void Initialize()
					{
					}

					static RunWithoutJobSystem_00000AF8_0024BurstDirectCall()
					{
						Constructor();
					}

					public unsafe static void Invoke(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
					{
						if (BurstCompiler.IsEnabled)
						{
							IntPtr functionPointer = GetFunctionPointer();
							if (functionPointer != (IntPtr)0)
							{
								((UIntPtr/*delegate* unmanaged[Cdecl]<ArchetypeChunkIterator*, void*, void>*/)(void*)(long)functionPointer)(archetypeChunkIterator, jobData);
								return;
							}
						}
						RunWithoutJobSystem_0024BurstManaged(archetypeChunkIterator, jobData);
					}
				}

				public EntityContext ctx;

				public Vector3 front_door;

				public BurstContext bctx;

				public SGameTime game_time;

				private LambdaParameterValueProviders _lambdaParameterValueProviders;

				[NativeDisableUnsafePtrRestriction]
				private unsafe LambdaParameterValueProviders.Runtimes* _runtimes;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldNoBurst;

				private static InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate s_RunWithoutJobSystemDelegateFieldBurst;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				internal void OriginalLambdaBody(Entity entity, int entityInQueryIndex, in CLinkedView linked_view, in CCustomer customer, in CCustomerState state)
				{
					bool isMoving = false;
					Vector3 moveTarget = Vector3.zero;
					Vector3 desiredFacing = Vector3.zero;
					float stoppingDistance = 0.1f;
					if (ctx.Require<CMoveToLocation>(entity, out var comp))
					{
						isMoving = true;
						moveTarget = comp;
						desiredFacing = comp.DesiredFacing;
						stoppingDistance = comp.StoppingDistance;
					}
					if (ctx.Has<CCustomerLeaving>(entity))
					{
						isMoving = true;
						moveTarget = new Vector3(-30f, 0f, front_door.z);
						stoppingDistance = 0.1f;
					}
					bctx.ProposeUpdate(linked_view, new ViewData
					{
						Scale = customer.Scale,
						IsMoving = isMoving,
						MoveTarget = moveTarget,
						DesiredFacing = desiredFacing,
						StoppingDistance = stoppingDistance,
						IsPaused = game_time.IsPaused,
						State = state,
						Speed = customer.Speed,
						HasLeftoversBag = (ctx.Has<CCustomerHasLeftoversBag>(entity) && ctx.Has<CCustomerLeaving>(entity))
					});
				}

				public void ReadFromDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					ctx = displayClass.ctx;
					front_door = displayClass.front_door;
					bctx = displayClass.bctx;
					game_time = displayClass.game_time;
				}

				public void WriteToDisplayClass(ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					displayClass.ctx = ctx;
					displayClass.front_door = front_door;
					displayClass.bctx = bctx;
					displayClass.game_time = game_time;
				}

				public unsafe void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
				{
					LambdaParameterValueProviders.Runtimes runtimes = _lambdaParameterValueProviders.PrepareToExecuteOnEntitiesInMethod(ref chunk, chunkIndex, firstEntityIndex);
					_runtimes = &runtimes;
					IterateEntities(ref chunk, ref *_runtimes);
				}

				[MethodImpl(MethodImplOptions.NoInlining)]
				public void IterateEntities(ref ArchetypeChunk chunk, [NoAlias] ref LambdaParameterValueProviders.Runtimes runtimes)
				{
					int count = chunk.Count;
					for (int i = 0; i < count; i++)
					{
						OriginalLambdaBody(runtimes.runtime_entity.For(i), runtimes.runtime_entityInQueryIndex.For(i), in runtimes.runtime_linked_view.For(i), in runtimes.runtime_customer.For(i), in runtimes.runtime_state.For(i));
					}
				}

				public void ScheduleTimeInitialize(UpdateSystem componentSystem, ref _003C_003Ec__DisplayClass0_0 displayClass)
				{
					_lambdaParameterValueProviders.ScheduleTimeInitialize(componentSystem);
					ReadFromDisplayClass(ref displayClass);
				}

				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				[BurstCompile]
				public unsafe static void RunWithoutJobSystem(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					RunWithoutJobSystem_00000AF8_0024BurstDirectCall.Invoke(archetypeChunkIterator, jobData);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Unity.Entities.MonoPInvokeCallback(typeof(InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate))]
				[BurstCompile]
				public unsafe static void RunWithoutJobSystem_0024BurstManaged(ArchetypeChunkIterator* archetypeChunkIterator, void* jobData)
				{
					JobChunkExtensions.RunWithoutJobs(ref UnsafeUtility.AsRef<_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0>(jobData), ref *archetypeChunkIterator);
				}
			}

			private EntityQuery _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;

			private ProfilerMarker _003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker;

			protected override void PopulateNewViewUpdates(BurstContext bctx)
			{
				_003C_003Ec__DisplayClass0_0 displayClass = new _003C_003Ec__DisplayClass0_0
				{
					bctx = bctx
				};
				if (TryGetSingleton<SGameTime>(out displayClass.game_time))
				{
					displayClass.ctx = new EntityContext(base.EntityManager);
					displayClass.front_door = GetFrontDoor(get_external_tile: true);
					_ = base.Entities;
					_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0 jobData = default(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0);
					jobData.ScheduleTimeInitialize(this, ref displayClass);
					CompleteDependency();
					EntityQuery query = _003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery;
					InternalCompilerInterface.JobChunkRunWithoutJobSystemDelegate functionPointer = (JobsUtility.JobCompilerEnabled ? _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst : _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
					_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker.Begin();
					try
					{
						InternalCompilerInterface.RunJobChunk(ref jobData, query, functionPointer);
					}
					finally
					{
						_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker.End();
					}
					jobData.WriteToDisplayClass(ref displayClass);
				}
			}

			protected internal unsafe override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
				_003C_003EPopulateNewViewUpdates_LambdaJob0_entityQuery = _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(this);
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst = _003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem;
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldBurst = InternalCompilerInterface.BurstCompile(_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.s_RunWithoutJobSystemDelegateFieldNoBurst);
				_003C_003EPopulateNewViewUpdates_LambdaJob0_profilerMarker = new ProfilerMarker("PopulateNewViewUpdates_LambdaJob0");
			}

			public static EntityQuery _003C_003EGetEntityQuery_ForPopulateNewViewUpdates_LambdaJob0_From(ComponentSystemBase componentSystem)
			{
				EntityQueryDesc[] array = new EntityQueryDesc[1];
				(array[0] = new EntityQueryDesc()).All = new ComponentType[3]
				{
					ComponentType.ReadOnly<CCustomer>(),
					ComponentType.ReadOnly<CLinkedView>(),
					ComponentType.ReadOnly<CCustomerState>()
				};
				return componentSystem.GetEntityQuery(array);
			}

			public static void Initialize_0024_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0_RunWithoutJobSystem_00000AF8_0024BurstDirectCall()
			{
				_003C_003Ec__DisplayClass_PopulateNewViewUpdates_LambdaJob0.RunWithoutJobSystem_00000AF8_0024BurstDirectCall.Initialize();
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>
		{
			[Key(0)]
			public float Scale;

			[Key(1)]
			public Vector3 SerializableMoveTarget;

			[Key(2)]
			public Vector3 SerializableDesiredFacing;

			[Key(3)]
			public bool IsMoving;

			[Key(4)]
			public float StoppingDistance;

			[Key(5)]
			public bool IsPaused;

			[Key(6)]
			public CCustomerState.State State;

			[Key(7)]
			public float Speed;

			[Key(8)]
			public Vector3 MoveTarget;

			[Key(9)]
			public Vector3 DesiredFacing;

			[FormerlySerializedAs("HasTakeawayBag")]
			[Key(10)]
			public bool HasLeftoversBag;

			public bool IsChangedFrom(ViewData check)
			{
				if (!(Math.Abs(Scale - check.Scale) > 0.01f) && !(MoveTarget != check.MoveTarget) && !(DesiredFacing != check.DesiredFacing) && IsMoving == check.IsMoving && !(Math.Abs(StoppingDistance - check.StoppingDistance) > 0.01f) && IsPaused == check.IsPaused && State == check.State && !(Math.Abs(Speed - check.Speed) > 0.01f))
				{
					return HasLeftoversBag != check.HasLeftoversBag;
				}
				return true;
			}
		}

		[Header("References")]
		[SerializeField]
		private NavMeshAgent Agent;

		[SerializeField]
		private Rigidbody Rigidbody;

		[SerializeField]
		private Animator Animator;

		[SerializeField]
		[FormerlySerializedAs("TakeawayBag")]
		private GameObject LeftoversBag;

		[Header("Configuration")]
		private Vector3 MovingToward;

		private Quaternion DesiredFacing = Quaternion.identity;

		private ViewData Data;

		[Header("State")]
		private bool AgentShouldBeActive;

		private float BaseSpeed;

		private float BaseAngularSpeed;

		private Vector3 LastRecordedPosition;

		private float PositionTime;

		private float StuckTime;

		private static readonly int Property = Animator.StringToHash("MovementSpeed");

		private static readonly int ShouldSit = Animator.StringToHash("ShouldSit");

		private static readonly int ShouldQueue = Animator.StringToHash("ShouldQueue");

		public override void SetPosition(UpdateViewPositionData pos)
		{
			if (!(this == null) && (pos.Force || (base.transform.localPosition - pos.Position).Chebyshev() > 0.5f))
			{
				base.SetPosition(pos);
				Agent.Warp(pos.Position);
			}
		}

		protected override void UpdatePosition()
		{
		}

		private void Update()
		{
			Animator.SetFloat(Property, Agent.velocity.magnitude);
			Animator.SetBool(ShouldSit, Data.State == CCustomerState.State.AtTable);
			Animator.SetBool(ShouldQueue, Data.State == CCustomerState.State.Queue);
			if (Agent.enabled != AgentShouldBeActive)
			{
				Agent.enabled = AgentShouldBeActive;
			}
			if (Vector3.Distance(base.transform.localPosition, Data.MoveTarget) < 0.25f + Agent.stoppingDistance)
			{
				Agent.updateRotation = false;
				Rigidbody.MoveRotation(Quaternion.RotateTowards(Rigidbody.rotation, DesiredFacing, 360f * Time.deltaTime));
			}
			else
			{
				Agent.updateRotation = true;
			}
			if (!Agent.enabled)
			{
				return;
			}
			CheckForStuck();
			if (Vector3.Distance(Agent.destination, MovingToward) > 0.05f && Agent.isOnNavMesh)
			{
				MovingToward = Data.MoveTarget;
				Agent.SetDestination(Data.MoveTarget);
				if (Data.DesiredFacing != Data.MoveTarget)
				{
					DesiredFacing = Quaternion.LookRotation(Data.DesiredFacing - Data.MoveTarget, Vector3.up);
				}
			}
		}

		private void CheckForStuck()
		{
			float time = Time.time;
			if (!(time - PositionTime > 2f))
			{
				return;
			}
			PositionTime = time;
			Vector3 nextPosition = Agent.nextPosition;
			Vector3 vector = nextPosition - LastRecordedPosition;
			Vector3 vector2 = nextPosition - Agent.destination;
			LastRecordedPosition = nextPosition;
			if (vector2.sqrMagnitude > 0.001f && vector.sqrMagnitude < 2f)
			{
				if (StuckTime > 0.01f && time - StuckTime > 10f)
				{
					Agent.nextPosition = Data.MoveTarget;
					Agent.Warp(Data.MoveTarget);
					StuckTime = time;
				}
				Agent.ResetPath();
				Agent.SetDestination(Data.MoveTarget);
				Agent.enabled = false;
			}
			else
			{
				StuckTime = time;
			}
		}

		protected override void UpdateData(ViewData view_data)
		{
			if (BaseSpeed == 0f)
			{
				BaseSpeed = Agent.speed;
			}
			if (BaseAngularSpeed == 0f)
			{
				BaseAngularSpeed = Agent.angularSpeed;
			}
			ViewData data = Data;
			Data = view_data;
			if (Mathf.Abs(base.transform.position.y) > 0.001f)
			{
				Vector3 position = base.transform.position;
				position.y = 0f;
				base.transform.position = position;
			}
			if (LeftoversBag != null)
			{
				LeftoversBag.SetActive(Data.HasLeftoversBag);
			}
			if (Data.Scale != data.Scale)
			{
				base.transform.localScale = new Vector3(Data.Scale, Data.Scale, Data.Scale);
			}
			AgentShouldBeActive = Data.IsMoving && !Data.IsPaused;
			Agent.enabled = AgentShouldBeActive;
			Agent.stoppingDistance = Data.StoppingDistance;
			Agent.speed = BaseSpeed * view_data.Speed;
			Agent.angularSpeed = BaseAngularSpeed * view_data.Speed;
			if (Agent.enabled && Data.MoveTarget != MovingToward && Agent.isOnNavMesh)
			{
				MovingToward = Data.MoveTarget;
				Agent.SetDestination(Data.MoveTarget);
				if (Data.DesiredFacing != Data.MoveTarget)
				{
					DesiredFacing = Quaternion.LookRotation(Data.DesiredFacing - Data.MoveTarget, Vector3.up);
				}
			}
			if (data.IsPaused != Data.IsPaused)
			{
				Rigidbody.isKinematic = Data.IsPaused;
			}
		}
	}
}
