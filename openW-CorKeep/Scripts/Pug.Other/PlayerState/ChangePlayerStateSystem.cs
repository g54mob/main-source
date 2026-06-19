using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.NetCode;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace PlayerState
{
	[BurstCompile]
	[UpdateInGroup(typeof(PlayerStateSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation | WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct ChangePlayerStateSystem : ISystem, ISystemStartStop, ISystemCompilerGenerated
	{
		[BurstCompile]
		[WithAll(new Type[] { typeof(Simulate) })]
		private struct ChangeStateJob : IJobEntity, IJobChunk
		{
			public struct InternalCompilerQueryAndHandleData
			{
				public struct TypeHandle
				{
					public ChangePlayerStateAspect.TypeHandle __PlayerState_ChangePlayerStateAspect_RW_AspectTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					public void __AssignHandles(ref SystemState state)
					{
						__PlayerState_ChangePlayerStateAspect_RW_AspectTypeHandle = new ChangePlayerStateAspect.TypeHandle(ref state);
					}

					public void Update(ref SystemState state)
					{
						__PlayerState_ChangePlayerStateAspect_RW_AspectTypeHandle.Update(ref state);
					}
				}

				public TypeHandle __TypeHandle;

				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<Simulate>();
					entityQueryBuilder2 = entityQueryBuilder2.WithAspect<ChangePlayerStateAspect>();
					DefaultQuery = entityQueryBuilder2.Build(ref state);
					entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					if (assignDefaultQuery)
					{
						__AssignQueries(ref state);
					}
					__TypeHandle.__AssignHandles(ref state);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void Run(ref ChangeStateJob job, EntityQuery query)
				{
					job.__TypeHandle = __TypeHandle;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle Schedule(ref ChangeStateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle ScheduleParallel(ref ChangeStateJob job, EntityQuery query, JobHandle dependency)
				{
					job.__TypeHandle = __TypeHandle;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void UpdateBaseEntityIndexArray(ref ChangeStateJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public JobHandle UpdateBaseEntityIndexArray(ref ChangeStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public void AssignEntityManager(ref ChangeStateJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout(LayoutKind.Sequential, Size = 1)]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			public ChangePlayerStateShared changePlayerStateShared;

			public ChangePlayerStateLookup changePlayerStateLookup;

			public bool isServer;

			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			private void Execute(ChangePlayerStateAspect changePlayerStateAspect)
			{
				ref PlayerStateCD valueRW = ref changePlayerStateAspect.playerStateCD.ValueRW;
				if (valueRW.nextState == PlayerStateEnum.Null)
				{
					valueRW.SetNextState(PlayerStateEnum.Walk);
				}
				changePlayerStateAspect.playerMovementForceCD.ValueRW.Value = float3.zero;
				if (valueRW.nextPoppedStateMask == PlayerStateEnum.Null && (valueRW.nextState == valueRW.level1State || valueRW.isStateLocked))
				{
					valueRW.nextStateLocked = false;
					return;
				}
				bool num = valueRW.nextState != valueRW.level1State && !valueRW.nextStatePushed;
				bool flag = valueRW.nextState != valueRW.level1State && valueRW.nextStatePushed;
				if (num)
				{
					ExitState(valueRW.level1State, ref changePlayerStateAspect, ref changePlayerStateShared, ref changePlayerStateLookup);
					ExitState(valueRW.level2State, ref changePlayerStateAspect, ref changePlayerStateShared, ref changePlayerStateLookup);
					ExitState(valueRW.level3State, ref changePlayerStateAspect, ref changePlayerStateShared, ref changePlayerStateLookup);
					valueRW.level1State = PlayerStateEnum.Null;
					valueRW.level2State = PlayerStateEnum.Null;
					valueRW.level3State = PlayerStateEnum.Null;
				}
				else if (valueRW.nextPoppedStateMask != PlayerStateEnum.Null)
				{
					if ((valueRW.nextPoppedStateMask & valueRW.level2State) != PlayerStateEnum.Null)
					{
						ExitState(valueRW.level2State, ref changePlayerStateAspect, ref changePlayerStateShared, ref changePlayerStateLookup);
						valueRW.level2State = valueRW.level3State;
						valueRW.level3State = PlayerStateEnum.Null;
					}
					if ((valueRW.nextPoppedStateMask & valueRW.level1State) != PlayerStateEnum.Null)
					{
						ExitState(valueRW.level1State, ref changePlayerStateAspect, ref changePlayerStateShared, ref changePlayerStateLookup);
						valueRW.level1State = valueRW.level2State;
						valueRW.level2State = valueRW.level3State;
						valueRW.level3State = PlayerStateEnum.Null;
					}
				}
				if (num)
				{
					valueRW.level1State = valueRW.nextState;
					valueRW.isStateLocked = valueRW.nextStateLocked;
					EnterState(valueRW.level1State, ref changePlayerStateAspect, ref changePlayerStateShared, ref changePlayerStateLookup, isServer);
				}
				else if (flag)
				{
					if (valueRW.level3State != PlayerStateEnum.Null)
					{
						UnityEngine.Debug.LogError("PlayerStateSystem: Trying to push a fourth level state, which is not supported yet.");
						valueRW.nextStateLocked = false;
						valueRW.nextStatePushed = false;
						valueRW.nextState = valueRW.level1State;
						return;
					}
					if (valueRW.HasAnyState(valueRW.nextState))
					{
						UnityEngine.Debug.LogError("PlayerStateSystem: Trying to push state already in states.");
						valueRW.nextStateLocked = false;
						valueRW.nextStatePushed = false;
						valueRW.nextState = valueRW.level1State;
						return;
					}
					valueRW.level3State = valueRW.level2State;
					valueRW.level2State = valueRW.level1State;
					valueRW.level1State = valueRW.nextState;
					valueRW.isStateLocked = valueRW.nextStateLocked;
					EnterState(valueRW.level1State, ref changePlayerStateAspect, ref changePlayerStateShared, ref changePlayerStateLookup, isServer);
				}
				else if (valueRW.nextPoppedStateMask != PlayerStateEnum.Null)
				{
					ResetState(valueRW.level1State, ref changePlayerStateAspect, ref changePlayerStateShared, ref changePlayerStateLookup);
				}
				valueRW.nextPoppedStateMask = PlayerStateEnum.Null;
				valueRW.nextState = valueRW.level1State;
				valueRW.nextStateLocked = false;
				valueRW.nextStatePushed = false;
			}

			private static void EnterState(PlayerStateEnum state, ref ChangePlayerStateAspect changePlayerStateAspect, ref ChangePlayerStateShared changePlayerStateShared, ref ChangePlayerStateLookup changePlayerStateLookup, bool isServer)
			{
				switch (state)
				{
				case PlayerStateEnum.SpawningFromCore:
					SpawningFromCore.EnterState(changePlayerStateAspect, changePlayerStateShared);
					break;
				case PlayerStateEnum.Walk:
					Walk.EnterState(changePlayerStateAspect, changePlayerStateShared);
					break;
				case PlayerStateEnum.Release:
					Release.EnterState(in changePlayerStateAspect, in changePlayerStateShared, in changePlayerStateLookup);
					break;
				case PlayerStateEnum.Anticipation:
					Anticipation.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.NoClip:
				case PlayerStateEnum.IgnoreAllInput:
					NoClip.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.Death:
					Death.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup, isServer);
					break;
				case PlayerStateEnum.PlaceObject:
					PlaceObject.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.Dig:
					Dig.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.Flatten:
					Flatten.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.RefillWater:
					RefillWater.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.PlaceWater:
					PlaceWater.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.Sleep:
					Sleep.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.Casting:
					Casting.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.MinecartRiding:
					MinecartRiding.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.Fishing:
					Fishing.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.BoatRiding:
					BoatRiding.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.VehicleRiding:
					VehicleRiding.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.UseOffHand:
					UseOffHand.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.Teleporting:
					Teleporting.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.Sitting:
					Sitting.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				case PlayerStateEnum.PlayingInstrument:
					PlayingInstrument.EnterState(changePlayerStateAspect, changePlayerStateShared, changePlayerStateLookup);
					break;
				}
			}

			private static void ResetState(PlayerStateEnum state, ref ChangePlayerStateAspect changePlayerStateAspect, ref ChangePlayerStateShared changePlayerStateShared, ref ChangePlayerStateLookup changePlayerStateLookup)
			{
				switch (state)
				{
				case PlayerStateEnum.Walk:
					Walk.ResetState(changePlayerStateAspect, changePlayerStateShared);
					break;
				case PlayerStateEnum.MinecartRiding:
					MinecartRiding.ResetState(changePlayerStateAspect, changePlayerStateShared);
					break;
				case PlayerStateEnum.BoatRiding:
					BoatRiding.ResetState(changePlayerStateAspect, changePlayerStateShared);
					break;
				case PlayerStateEnum.VehicleRiding:
					VehicleRiding.ResetState(changePlayerStateAspect, changePlayerStateShared);
					break;
				case PlayerStateEnum.Sitting:
					Sitting.ResetState(changePlayerStateAspect, changePlayerStateShared);
					break;
				}
			}

			private static void ExitState(PlayerStateEnum state, ref ChangePlayerStateAspect changePlayerStateAspect, ref ChangePlayerStateShared changePlayerStateShared, ref ChangePlayerStateLookup changePlayerStateLookup)
			{
				switch (state)
				{
				case PlayerStateEnum.SpawningFromCore:
					SpawningFromCore.ExitState(changePlayerStateAspect);
					break;
				case PlayerStateEnum.Walk:
					Walk.ExitState(changePlayerStateAspect);
					break;
				case PlayerStateEnum.Release:
					Release.ExitState(changePlayerStateAspect);
					break;
				case PlayerStateEnum.Anticipation:
					Anticipation.ExitState(changePlayerStateAspect, changePlayerStateShared);
					break;
				case PlayerStateEnum.NoClip:
				case PlayerStateEnum.IgnoreAllInput:
					NoClip.ExitState(changePlayerStateAspect, changePlayerStateLookup);
					break;
				case PlayerStateEnum.Death:
					Death.ExitState(changePlayerStateAspect, changePlayerStateLookup);
					break;
				case PlayerStateEnum.PlaceObject:
					PlaceObject.ExitState(changePlayerStateAspect, changePlayerStateShared);
					break;
				case PlayerStateEnum.Dig:
					Dig.ExitState(changePlayerStateAspect, changePlayerStateShared);
					break;
				case PlayerStateEnum.Flatten:
					Flatten.ExitState(changePlayerStateAspect, changePlayerStateShared);
					break;
				case PlayerStateEnum.RefillWater:
					RefillWater.ExitState(changePlayerStateAspect, changePlayerStateShared);
					break;
				case PlayerStateEnum.PlaceWater:
					PlaceWater.ExitState(changePlayerStateAspect, changePlayerStateShared);
					break;
				case PlayerStateEnum.Sleep:
					Sleep.ExitState(changePlayerStateAspect, changePlayerStateLookup, changePlayerStateShared);
					break;
				case PlayerStateEnum.Casting:
					Casting.ExitState(changePlayerStateAspect, changePlayerStateLookup, changePlayerStateShared);
					break;
				case PlayerStateEnum.MinecartRiding:
					MinecartRiding.ExitState(changePlayerStateAspect, changePlayerStateLookup, changePlayerStateShared);
					break;
				case PlayerStateEnum.Fishing:
					Fishing.ExitState(changePlayerStateAspect, changePlayerStateShared);
					break;
				case PlayerStateEnum.BoatRiding:
					BoatRiding.ExitState(changePlayerStateAspect, changePlayerStateLookup, changePlayerStateShared);
					break;
				case PlayerStateEnum.VehicleRiding:
					VehicleRiding.ExitState(changePlayerStateAspect, changePlayerStateLookup, changePlayerStateShared);
					break;
				case PlayerStateEnum.UseOffHand:
					UseOffHand.ExitState(changePlayerStateAspect);
					break;
				case PlayerStateEnum.Teleporting:
					Teleporting.ExitState(changePlayerStateAspect);
					break;
				case PlayerStateEnum.Sitting:
					Sitting.ExitState(changePlayerStateAspect, changePlayerStateLookup, changePlayerStateShared);
					break;
				case PlayerStateEnum.PlayingInstrument:
					PlayingInstrument.ExitState(changePlayerStateAspect);
					break;
				}
			}

			[CompilerGenerated]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				ChangePlayerStateAspect.ResolvedChunk resolvedChunk = __TypeHandle.__PlayerState_ChangePlayerStateAspect_RW_AspectTypeHandle.Resolve(chunk);
				int count = chunk.Count;
				int num = 0;
				if (!useEnabledMask)
				{
					for (int i = 0; i < count; i++)
					{
						ChangePlayerStateAspect changePlayerStateAspect = resolvedChunk[i];
						Execute(changePlayerStateAspect);
						num++;
					}
					return;
				}
				if (math.countbits(chunkEnabledMask.ULong0 ^ (chunkEnabledMask.ULong0 << 1)) + math.countbits(chunkEnabledMask.ULong1 ^ (chunkEnabledMask.ULong1 << 1)) - 1 <= 4)
				{
					int nextRangeBegin = 0;
					int nextRangeEnd = 0;
					while (InternalCompilerInterface.UnsafeTryGetNextEnabledBitRange(chunkEnabledMask, nextRangeEnd, out nextRangeBegin, out nextRangeEnd))
					{
						while (nextRangeBegin < nextRangeEnd)
						{
							ChangePlayerStateAspect changePlayerStateAspect2 = resolvedChunk[nextRangeBegin];
							Execute(changePlayerStateAspect2);
							nextRangeBegin++;
							num++;
						}
					}
					return;
				}
				ulong num2 = chunkEnabledMask.ULong0;
				int num3 = math.min(64, count);
				for (int j = 0; j < num3; j++)
				{
					if ((num2 & 1) != 0L)
					{
						ChangePlayerStateAspect changePlayerStateAspect3 = resolvedChunk[j];
						Execute(changePlayerStateAspect3);
						num++;
					}
					num2 >>= 1;
				}
				num2 = chunkEnabledMask.ULong1;
				for (int k = 64; k < count; k++)
				{
					if ((num2 & 1) != 0L)
					{
						ChangePlayerStateAspect changePlayerStateAspect4 = resolvedChunk[k];
						Execute(changePlayerStateAspect4);
						num++;
					}
					num2 >>= 1;
				}
			}

			private JobHandle __ThrowCodeGenException()
			{
				throw new Exception("This method should have been replaced by source gen.");
			}

			public void Run()
			{
				__ThrowCodeGenException();
			}

			public void RunByRef()
			{
				__ThrowCodeGenException();
			}

			public void Run(EntityQuery query)
			{
				__ThrowCodeGenException();
			}

			public void RunByRef(EntityQuery query)
			{
				__ThrowCodeGenException();
			}

			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public void Schedule()
			{
				__ThrowCodeGenException();
			}

			public void ScheduleByRef()
			{
				__ThrowCodeGenException();
			}

			public void Schedule(EntityQuery query)
			{
				__ThrowCodeGenException();
			}

			public void ScheduleByRef(EntityQuery query)
			{
				__ThrowCodeGenException();
			}

			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			public void ScheduleParallel()
			{
				__ThrowCodeGenException();
			}

			public void ScheduleParallelByRef()
			{
				__ThrowCodeGenException();
			}

			public void ScheduleParallel(EntityQuery query)
			{
				__ThrowCodeGenException();
			}

			public void ScheduleParallelByRef(EntityQuery query)
			{
				__ThrowCodeGenException();
			}

			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		private struct TypeHandle
		{
			[ReadOnly]
			public ComponentLookup<MeleeWeaponCD> __MeleeWeaponCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<OffHandCD> __OffHandCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CooldownCD> __CooldownCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<CastItemCD> __CastItemCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ParchmentRecipeCD> __ParchmentRecipeCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<ScannerCD> __ScannerCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

			[ReadOnly]
			public ComponentLookup<SittableCD> __SittableCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<Simulate> __Unity_Entities_Simulate_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<DirectionCD> __DirectionCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<TriggerEffectCD> __TriggerEffectCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<TileCD> __TileCD_RO_ComponentLookup;

			public ComponentLookup<DisablePhysicsCD> __DisablePhysicsCD_RW_ComponentLookup;

			public ComponentLookup<ControlledByOtherEntityCD> __ControlledByOtherEntityCD_RW_ComponentLookup;

			public ComponentLookup<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<WaterSourceCD> __WaterSourceCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PlayerGhost> __PlayerGhost_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<VehicleCD> __VehicleCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<BoatCD> __BoatCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MinecartCD> __MinecartCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<MoveFreelyWeaponCD> __MoveFreelyWeaponCD_RO_ComponentLookup;

			public ChangeStateJob.InternalCompilerQueryAndHandleData __PlayerState_ChangePlayerStateSystem_ChangeStateJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__MeleeWeaponCD_RO_ComponentLookup = state.GetComponentLookup<MeleeWeaponCD>(isReadOnly: true);
				__OffHandCD_RO_ComponentLookup = state.GetComponentLookup<OffHandCD>(isReadOnly: true);
				__CooldownCD_RO_ComponentLookup = state.GetComponentLookup<CooldownCD>(isReadOnly: true);
				__CastItemCD_RO_ComponentLookup = state.GetComponentLookup<CastItemCD>(isReadOnly: true);
				__ParchmentRecipeCD_RO_ComponentLookup = state.GetComponentLookup<ParchmentRecipeCD>(isReadOnly: true);
				__ScannerCD_RO_ComponentLookup = state.GetComponentLookup<ScannerCD>(isReadOnly: true);
				__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
				__SittableCD_RO_ComponentLookup = state.GetComponentLookup<SittableCD>(isReadOnly: true);
				__Unity_Entities_Simulate_RO_ComponentLookup = state.GetComponentLookup<Simulate>(isReadOnly: true);
				__DirectionCD_RO_ComponentLookup = state.GetComponentLookup<DirectionCD>(isReadOnly: true);
				__TriggerEffectCD_RO_ComponentLookup = state.GetComponentLookup<TriggerEffectCD>(isReadOnly: true);
				__TileCD_RO_ComponentLookup = state.GetComponentLookup<TileCD>(isReadOnly: true);
				__DisablePhysicsCD_RW_ComponentLookup = state.GetComponentLookup<DisablePhysicsCD>();
				__ControlledByOtherEntityCD_RW_ComponentLookup = state.GetComponentLookup<ControlledByOtherEntityCD>();
				__Unity_Transforms_LocalTransform_RW_ComponentLookup = state.GetComponentLookup<LocalTransform>();
				__WaterSourceCD_RO_ComponentLookup = state.GetComponentLookup<WaterSourceCD>(isReadOnly: true);
				__PlayerGhost_RO_ComponentLookup = state.GetComponentLookup<PlayerGhost>(isReadOnly: true);
				__VehicleCD_RO_ComponentLookup = state.GetComponentLookup<VehicleCD>(isReadOnly: true);
				__BoatCD_RO_ComponentLookup = state.GetComponentLookup<BoatCD>(isReadOnly: true);
				__MinecartCD_RO_ComponentLookup = state.GetComponentLookup<MinecartCD>(isReadOnly: true);
				__MoveFreelyWeaponCD_RO_ComponentLookup = state.GetComponentLookup<MoveFreelyWeaponCD>(isReadOnly: true);
				__PlayerState_ChangePlayerStateSystem_ChangeStateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnUpdate_00007117_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnUpdate_00007117_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnUpdate_00007117_0024PostfixBurstDelegate>(__codegen__OnUpdate).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(IntPtr self, IntPtr state)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
						return;
					}
				}
				__codegen__OnUpdate_0024BurstManaged(self, state);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnStartRunning_00007118_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStartRunning_00007118_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStartRunning_00007118_0024PostfixBurstDelegate>(__codegen__OnStartRunning).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(IntPtr self, IntPtr state)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
						return;
					}
				}
				__codegen__OnStartRunning_0024BurstManaged(self, state);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnStopRunning_00007119_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnStopRunning_00007119_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnStopRunning_00007119_0024PostfixBurstDelegate>(__codegen__OnStopRunning).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(IntPtr self, IntPtr state)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)functionPointer)(self, state);
						return;
					}
				}
				__codegen__OnStopRunning_0024BurstManaged(self, state);
			}
		}

		private uint _tickRate;

		private TileAccessor _tileAccessor;

		private TypeHandle __TypeHandle;

		private EntityQuery __query_96476547_0;

		private EntityQuery __query_96476547_1;

		private EntityQuery __query_96476547_2;

		private EntityQuery __query_96476547_3;

		private EntityQuery __query_96476547_4;

		private EntityQuery __query_96476547_5;

		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<PugDatabase.DatabaseBankCD>();
			state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
			state.RequireForUpdate<SubMapRegistry>();
			_tickRate = (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate;
		}

		[BurstCompile]
		public void OnStartRunning(ref SystemState state)
		{
			_tileAccessor = new TileAccessor(ref state);
		}

		[BurstCompile]
		public void OnStopRunning(ref SystemState state)
		{
		}

		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			EntityCommandBuffer ecb = __query_96476547_0.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
			__query_96476547_1.TryGetSingleton<NetworkTime>(out var value);
			_tileAccessor.Update(ref state);
			ChangeStateJob job = new ChangeStateJob
			{
				changePlayerStateShared = new ChangePlayerStateShared
				{
					databaseBankCD = __query_96476547_2.GetSingleton<PugDatabase.DatabaseBankCD>(),
					conditionsTableCD = __query_96476547_3.GetSingleton<ConditionsTableCD>(),
					currentTick = value.ServerTick,
					tickRate = _tickRate,
					tileAccessor = _tileAccessor,
					physicsWorld = __query_96476547_4.GetSingleton<PhysicsWorldSingleton>().PhysicsWorld,
					physicsWorldHistory = __query_96476547_5.GetSingleton<PhysicsWorldHistorySingleton>(),
					ecb = ecb,
					isFinalFullPredictionTick = value.IsFinalFullPredictionTick,
					isPartialTick = value.IsPartialTick
				},
				changePlayerStateLookup = new ChangePlayerStateLookup
				{
					meleeWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MeleeWeaponCD_RO_ComponentLookup, ref state),
					offHandLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__OffHandCD_RO_ComponentLookup, ref state),
					cooldownLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CooldownCD_RO_ComponentLookup, ref state),
					castItemLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__CastItemCD_RO_ComponentLookup, ref state),
					parchmentRecipeLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ParchmentRecipeCD_RO_ComponentLookup, ref state),
					scannerLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ScannerCD_RO_ComponentLookup, ref state),
					summarizedConditionsBufferLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state),
					sittableLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__SittableCD_RO_ComponentLookup, ref state),
					simulateLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Entities_Simulate_RO_ComponentLookup, ref state),
					directionLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DirectionCD_RO_ComponentLookup, ref state),
					triggerEffectLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TriggerEffectCD_RO_ComponentLookup, ref state),
					tileLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TileCD_RO_ComponentLookup, ref state),
					disablePhysicsLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__DisablePhysicsCD_RW_ComponentLookup, ref state),
					controlledByOtherEntityLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__ControlledByOtherEntityCD_RW_ComponentLookup, ref state),
					localTransformLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_Transforms_LocalTransform_RW_ComponentLookup, ref state),
					waterSourceLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__WaterSourceCD_RO_ComponentLookup, ref state),
					playerGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__PlayerGhost_RO_ComponentLookup, ref state),
					vehicleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__VehicleCD_RO_ComponentLookup, ref state),
					boatLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__BoatCD_RO_ComponentLookup, ref state),
					minecartLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MinecartCD_RO_ComponentLookup, ref state),
					moveFreelyWeaponLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__MoveFreelyWeaponCD_RO_ComponentLookup, ref state)
				},
				isServer = state.WorldUnmanaged.IsServer()
			};
			state.Dependency = __ScheduleViaJobChunkExtension_0(ref job, __TypeHandle.__PlayerState_ChangePlayerStateSystem_ChangeStateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, state.Dependency, ref state, hasUserDefinedQuery: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private JobHandle __ScheduleViaJobChunkExtension_0(ref ChangeStateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			dependency = __TypeHandle.__PlayerState_ChangePlayerStateSystem_ChangeStateJob_WithDefaultQuery_JobEntityTypeHandle.UpdateBaseEntityIndexArray(ref job, query, dependency, ref state);
			__TypeHandle.__PlayerState_ChangePlayerStateSystem_ChangeStateJob_WithDefaultQuery_JobEntityTypeHandle.AssignEntityManager(ref job, state.EntityManager);
			__TypeHandle.__PlayerState_ChangePlayerStateSystem_ChangeStateJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.Update(ref state);
			return __TypeHandle.__PlayerState_ChangePlayerStateSystem_ChangeStateJob_WithDefaultQuery_JobEntityTypeHandle.Schedule(ref job, query, dependency);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<BeginSimulationEntityCommandBufferSystem.Singleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_96476547_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_96476547_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_96476547_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ConditionsTableCD>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_96476547_3 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldSingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_96476547_4 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<PhysicsWorldHistorySingleton>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_96476547_5 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
			__AssignQueries(ref state);
			__TypeHandle.__AssignHandles(ref state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((ChangePlayerStateSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			__codegen__OnUpdate_00007117_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStartRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStartRunning_00007118_0024BurstDirectCall.Invoke(self, state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnStopRunning(IntPtr self, IntPtr state)
		{
			__codegen__OnStopRunning_00007119_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((ChangePlayerStateSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ChangePlayerStateSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStartRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ChangePlayerStateSystem*)self.ToPointer())->OnStartRunning(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnStopRunning_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((ChangePlayerStateSystem*)self.ToPointer())->OnStopRunning(ref *(SystemState*)state.ToPointer());
		}
	}
}
