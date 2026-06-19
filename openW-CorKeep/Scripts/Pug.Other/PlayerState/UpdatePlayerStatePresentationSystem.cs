using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.NetCode;

namespace PlayerState
{
	[UpdateAfter(typeof(ChangePlayerStatePresentationSystem))]
	[UpdateInGroup(typeof(LocalPresentationCueSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	[BurstCompile]
	public struct UpdatePlayerStatePresentationSystem : ISystem, ISystemCompilerGenerated
	{
		private struct UpdateStatePresentationJob
		{
			public StatePresentationUpdateLookups statePresentationUpdateLookups;

			public StatePresentationShared statePresentationShared;

			public void Execute(StatePresentationUpdateAspect stateUpdateAspect)
			{
				PlayerController playerController = (PlayerController)Manager.memory.GetEntityMono(stateUpdateAspect.entity);
				if (!(playerController == null))
				{
					PlayerStateEnum presentationCurrentStateMask = stateUpdateAspect.playerStateCD.ValueRO.presentationCurrentStateMask;
					if ((presentationCurrentStateMask & PlayerStateEnum.NoClip) != PlayerStateEnum.Null)
					{
						NoClip.UpdateStatePresentation(stateUpdateAspect, playerController);
					}
					if ((presentationCurrentStateMask & PlayerStateEnum.Death) != PlayerStateEnum.Null)
					{
						Death.UpdateStatePresentation(stateUpdateAspect, playerController, statePresentationUpdateLookups);
					}
					if ((presentationCurrentStateMask & PlayerStateEnum.Sleep) != PlayerStateEnum.Null)
					{
						Sleep.UpdateStatePresentation(stateUpdateAspect, playerController, statePresentationUpdateLookups);
					}
					if ((presentationCurrentStateMask & PlayerStateEnum.Fishing) != PlayerStateEnum.Null)
					{
						Fishing.UpdateStatePresentation(stateUpdateAspect, playerController);
					}
					if ((presentationCurrentStateMask & PlayerStateEnum.BoatRiding) != PlayerStateEnum.Null)
					{
						BoatRiding.UpdateStatePresentation(stateUpdateAspect, playerController);
					}
					if ((presentationCurrentStateMask & PlayerStateEnum.VehicleRiding) != PlayerStateEnum.Null)
					{
						VehicleRiding.UpdateStatePresentation(stateUpdateAspect, statePresentationUpdateLookups, playerController);
					}
					if ((presentationCurrentStateMask & PlayerStateEnum.Teleporting) != PlayerStateEnum.Null)
					{
						Teleporting.UpdateStatePresentation(stateUpdateAspect, statePresentationShared, statePresentationUpdateLookups, playerController);
					}
					if ((presentationCurrentStateMask & PlayerStateEnum.Sitting) != PlayerStateEnum.Null)
					{
						Sitting.UpdateStatePresentation(stateUpdateAspect, playerController);
					}
					if ((presentationCurrentStateMask & PlayerStateEnum.PlayingInstrument) != PlayerStateEnum.Null)
					{
						PlayingInstrument.UpdateStatePresentation(stateUpdateAspect, playerController);
					}
				}
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_2015969445_0
		{
			public struct ResolvedChunk
			{
				public StatePresentationUpdateAspect.ResolvedChunk item1_ResolvedChunk;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public StatePresentationUpdateAspect Get(int index)
				{
					return item1_ResolvedChunk[index];
				}
			}

			public struct TypeHandle
			{
				private StatePresentationUpdateAspect.TypeHandle item1_AspectTypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_AspectTypeHandle = new StatePresentationUpdateAspect.TypeHandle(ref systemState);
				}

				public void Update(ref SystemState systemState)
				{
					item1_AspectTypeHandle.Update(ref systemState);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					return new ResolvedChunk
					{
						item1_ResolvedChunk = item1_AspectTypeHandle.Resolve(archetypeChunk)
					};
				}
			}

			public struct Enumerator : IEnumerator<StatePresentationUpdateAspect>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public StatePresentationUpdateAspect Current => _resolvedChunk.Get(_currentEntityIndex);

				object IEnumerator.Current
				{
					get
					{
						throw new NotImplementedException();
					}
				}

				public Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
				{
					if (!entityQuery.IsEmptyIgnoreFilter)
					{
						CompleteDependencies(ref state);
						typeHandle.Update(ref state);
					}
					_entityQueryEnumerator = new InternalEntityQueryEnumerator(entityQuery);
					_currentEntityIndex = -1;
					_endEntityIndex = -1;
					_typeHandle = typeHandle;
					_resolvedChunk = default(ResolvedChunk);
				}

				public void Dispose()
				{
					_entityQueryEnumerator.Dispose();
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public bool MoveNext()
				{
					_currentEntityIndex++;
					if (_currentEntityIndex >= _endEntityIndex)
					{
						if (_entityQueryEnumerator.MoveNextEntityRange(out var movedToNewChunk, out var chunk, out var entityStartIndex, out var entityEndIndex))
						{
							if (movedToNewChunk)
							{
								_resolvedChunk = _typeHandle.Resolve(chunk);
							}
							_currentEntityIndex = entityStartIndex;
							_endEntityIndex = entityEndIndex;
							return true;
						}
						return false;
					}
					return true;
				}

				public Enumerator GetEnumerator()
				{
					return this;
				}

				public void Reset()
				{
					throw new NotImplementedException();
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				return new Enumerator(entityQuery, typeHandle, ref state);
			}

			public static void CompleteDependencies(ref SystemState state)
			{
				default(StatePresentationUpdateAspect).CompleteDependencyBeforeRW(ref state);
			}
		}

		private struct TypeHandle
		{
			public IFE_2015969445_0.TypeHandle __IFE_2015969445_0_TypeHandle;

			[ReadOnly]
			public ComponentLookup<GhostOwnerIsLocal> __Unity_NetCode_GhostOwnerIsLocal_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<PredictedGhost> __Unity_NetCode_PredictedGhost_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<VehicleCD> __VehicleCD_RO_ComponentLookup;

			[ReadOnly]
			public ComponentLookup<TriggerEffectCD> __TriggerEffectCD_RO_ComponentLookup;

			[ReadOnly]
			public BufferLookup<SummarizedConditionsBuffer> __SummarizedConditionsBuffer_RO_BufferLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_2015969445_0_TypeHandle = new IFE_2015969445_0.TypeHandle(ref state);
				__Unity_NetCode_GhostOwnerIsLocal_RO_ComponentLookup = state.GetComponentLookup<GhostOwnerIsLocal>(isReadOnly: true);
				__Unity_NetCode_PredictedGhost_RO_ComponentLookup = state.GetComponentLookup<PredictedGhost>(isReadOnly: true);
				__VehicleCD_RO_ComponentLookup = state.GetComponentLookup<VehicleCD>(isReadOnly: true);
				__TriggerEffectCD_RO_ComponentLookup = state.GetComponentLookup<TriggerEffectCD>(isReadOnly: true);
				__SummarizedConditionsBuffer_RO_BufferLookup = state.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void __codegen__OnCreate_00007197_0024PostfixBurstDelegate(IntPtr self, IntPtr state);

		internal static class __codegen__OnCreate_00007197_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<__codegen__OnCreate_00007197_0024PostfixBurstDelegate>(__codegen__OnCreate).Value;
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
				__codegen__OnCreate_0024BurstManaged(self, state);
			}
		}

		private TypeHandle __TypeHandle;

		private EntityQuery __query_2015969445_0;

		private EntityQuery __query_2015969445_1;

		private EntityQuery __query_2015969445_2;

		[BurstCompile]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<ClientServerTickRate>();
		}

		public void OnUpdate(ref SystemState state)
		{
			__query_2015969445_1.TryGetSingleton<NetworkTime>(out var value);
			UpdateStatePresentationJob updateStatePresentationJob = new UpdateStatePresentationJob
			{
				statePresentationUpdateLookups = new StatePresentationUpdateLookups
				{
					ghostOwnerIsLocalLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_GhostOwnerIsLocal_RO_ComponentLookup, ref state),
					predictedGhostLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__Unity_NetCode_PredictedGhost_RO_ComponentLookup, ref state),
					vehicleLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__VehicleCD_RO_ComponentLookup, ref state),
					triggerEffectLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TriggerEffectCD_RO_ComponentLookup, ref state),
					summarizedConditionsLookup = InternalCompilerInterface.GetBufferLookup(ref __TypeHandle.__SummarizedConditionsBuffer_RO_BufferLookup, ref state)
				},
				statePresentationShared = new StatePresentationShared
				{
					networkTime = value,
					tickRate = (uint)__query_2015969445_2.GetSingleton<ClientServerTickRate>().SimulationTickRate
				}
			};
			foreach (StatePresentationUpdateAspect item in IFE_2015969445_0.Query(__query_2015969445_0, __TypeHandle.__IFE_2015969445_0_TypeHandle, ref state))
			{
				updateStatePresentationJob.Execute(item);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAspect<StatePresentationUpdateAspect>();
			__query_2015969445_0 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<NetworkTime>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_2015969445_1 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder2 = entityQueryBuilder.WithAll<ClientServerTickRate>();
			entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
			__query_2015969445_2 = entityQueryBuilder2.Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
			__AssignQueries(ref state);
			__TypeHandle.__AssignHandles(ref state);
		}

		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			__codegen__OnCreate_00007197_0024BurstDirectCall.Invoke(self, state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((UpdatePlayerStatePresentationSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((UpdatePlayerStatePresentationSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreate_0024BurstManaged(IntPtr self, IntPtr state)
		{
			((UpdatePlayerStatePresentationSystem*)self.ToPointer())->OnCreate(ref *(SystemState*)state.ToPointer());
		}
	}
}
