using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;

namespace PlayerState
{
	[UpdateInGroup(typeof(LocalPresentationCueSystemGroup))]
	[WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation, WorldSystemFilterFlags.Default)]
	public struct ChangePlayerStatePresentationSystem : ISystem, ISystemCompilerGenerated
	{
		private struct ChangeStatePresentationJob
		{
			public ChangePlayerStatePresentationLookups changePlayerStatePresentationLookups;

			public void Execute(ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect)
			{
				ref PlayerStateCD valueRW = ref changePlayerStatePresentationAspect.playerStateCD.ValueRW;
				if (valueRW.AllStates() != valueRW.presentationCurrentStateMask)
				{
					PlayerController playerController = (PlayerController)Manager.memory.GetEntityMono(changePlayerStatePresentationAspect.entity);
					if (!(playerController == null))
					{
						PlayerStateEnum state = valueRW.presentationCurrentStateMask & ~valueRW.AllStates();
						PlayerStateEnum state2 = valueRW.AllStates() & ~valueRW.presentationCurrentStateMask;
						ExitState(state, playerController, ref changePlayerStatePresentationAspect, ref changePlayerStatePresentationLookups);
						valueRW.presentationCurrentStateMask = valueRW.AllStates();
						EnterState(state2, playerController, ref changePlayerStatePresentationAspect);
					}
				}
			}

			private static void ExitState(PlayerStateEnum state, PlayerController playerController, ref ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect, ref ChangePlayerStatePresentationLookups changePlayerStatePresentationLookups)
			{
				if ((state & PlayerStateEnum.SpawningFromCore) != PlayerStateEnum.Null)
				{
					SpawningFromCore.ExitStatePresentation(playerController);
				}
				if ((state & PlayerStateEnum.NoClip) != PlayerStateEnum.Null)
				{
					NoClip.ExitStatePresentation(playerController);
				}
				if ((state & PlayerStateEnum.Death) != PlayerStateEnum.Null)
				{
					Death.ExitStatePresentation(playerController);
				}
				if ((state & PlayerStateEnum.Sleep) != PlayerStateEnum.Null)
				{
					Sleep.ExitStatePresentation(playerController);
				}
				if ((state & PlayerStateEnum.Casting) != PlayerStateEnum.Null)
				{
					Casting.ExitStatePresentation(playerController, changePlayerStatePresentationAspect);
				}
				if ((state & PlayerStateEnum.MinecartRiding) != PlayerStateEnum.Null)
				{
					MinecartRiding.ExitStatePresentation(playerController);
				}
				if ((state & PlayerStateEnum.Fishing) != PlayerStateEnum.Null)
				{
					Fishing.ExitStatePresentation(playerController);
				}
				if ((state & PlayerStateEnum.BoatRiding) != PlayerStateEnum.Null)
				{
					BoatRiding.ExitStatePresentation(playerController, changePlayerStatePresentationAspect);
				}
				if ((state & PlayerStateEnum.VehicleRiding) != PlayerStateEnum.Null)
				{
					VehicleRiding.ExitStatePresentation(playerController, changePlayerStatePresentationAspect, changePlayerStatePresentationLookups);
				}
				if ((state & PlayerStateEnum.Teleporting) != PlayerStateEnum.Null)
				{
					Teleporting.ExitStatePresentation(playerController, changePlayerStatePresentationAspect);
				}
				if ((state & PlayerStateEnum.Sitting) != PlayerStateEnum.Null)
				{
					Sitting.ExitStatePresentation(playerController);
				}
				if ((state & PlayerStateEnum.PlayingInstrument) != PlayerStateEnum.Null)
				{
					PlayingInstrument.ExitStatePresentation(playerController);
				}
			}

			private static void EnterState(PlayerStateEnum state, PlayerController playerController, ref ChangePlayerStatePresentationAspect changePlayerStatePresentationAspect)
			{
				if ((state & PlayerStateEnum.SpawningFromCore) != PlayerStateEnum.Null)
				{
					SpawningFromCore.EnterStatePresentation(playerController);
				}
				if ((state & PlayerStateEnum.Walk) != PlayerStateEnum.Null)
				{
					Walk.EnterStatePresentation(playerController);
				}
				if ((state & PlayerStateEnum.Death) != PlayerStateEnum.Null)
				{
					Death.EnterStatePresentation(playerController, changePlayerStatePresentationAspect);
				}
				if ((state & PlayerStateEnum.Sleep) != PlayerStateEnum.Null)
				{
					Sleep.EnterStatePresentation(playerController, changePlayerStatePresentationAspect);
				}
				if ((state & PlayerStateEnum.Casting) != PlayerStateEnum.Null)
				{
					Casting.EnterStatePresentation(playerController);
				}
				if ((state & PlayerStateEnum.MinecartRiding) != PlayerStateEnum.Null)
				{
					MinecartRiding.EnterStatePresentation(playerController, changePlayerStatePresentationAspect);
				}
				if ((state & PlayerStateEnum.Fishing) != PlayerStateEnum.Null)
				{
					Fishing.EnterStatePresentation(playerController, changePlayerStatePresentationAspect);
				}
				if ((state & PlayerStateEnum.BoatRiding) != PlayerStateEnum.Null)
				{
					BoatRiding.EnterStatePresentation(playerController, changePlayerStatePresentationAspect);
				}
				if ((state & PlayerStateEnum.VehicleRiding) != PlayerStateEnum.Null)
				{
					VehicleRiding.EnterStatePresentation(playerController, changePlayerStatePresentationAspect);
				}
				if ((state & PlayerStateEnum.Teleporting) != PlayerStateEnum.Null)
				{
					Teleporting.EnterStatePresentation(playerController, changePlayerStatePresentationAspect);
				}
				if ((state & PlayerStateEnum.Sitting) != PlayerStateEnum.Null)
				{
					Sitting.EnterStatePresentation(playerController, changePlayerStatePresentationAspect);
				}
				if ((state & PlayerStateEnum.PlayingInstrument) != PlayerStateEnum.Null)
				{
					PlayingInstrument.EnterStatePresentation(playerController);
				}
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct IFE_1284889090_0
		{
			public struct ResolvedChunk
			{
				public ChangePlayerStatePresentationAspect.ResolvedChunk item1_ResolvedChunk;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				public ChangePlayerStatePresentationAspect Get(int index)
				{
					return item1_ResolvedChunk[index];
				}
			}

			public struct TypeHandle
			{
				private ChangePlayerStatePresentationAspect.TypeHandle item1_AspectTypeHandle;

				public TypeHandle(ref SystemState systemState)
				{
					item1_AspectTypeHandle = new ChangePlayerStatePresentationAspect.TypeHandle(ref systemState);
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

			public struct Enumerator : IEnumerator<ChangePlayerStatePresentationAspect>, IEnumerator, IDisposable
			{
				private InternalEntityQueryEnumerator _entityQueryEnumerator;

				private TypeHandle _typeHandle;

				private ResolvedChunk _resolvedChunk;

				private int _currentEntityIndex;

				private int _endEntityIndex;

				public ChangePlayerStatePresentationAspect Current => _resolvedChunk.Get(_currentEntityIndex);

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
				default(ChangePlayerStatePresentationAspect).CompleteDependencyBeforeRW(ref state);
			}
		}

		private struct TypeHandle
		{
			public IFE_1284889090_0.TypeHandle __IFE_1284889090_0_TypeHandle;

			[ReadOnly]
			public ComponentLookup<TriggerEffectCD> __TriggerEffectCD_RO_ComponentLookup;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void __AssignHandles(ref SystemState state)
			{
				__IFE_1284889090_0_TypeHandle = new IFE_1284889090_0.TypeHandle(ref state);
				__TriggerEffectCD_RO_ComponentLookup = state.GetComponentLookup<TriggerEffectCD>(isReadOnly: true);
			}
		}

		private TypeHandle __TypeHandle;

		private EntityQuery __query_1284889090_0;

		public void OnUpdate(ref SystemState state)
		{
			ChangeStatePresentationJob changeStatePresentationJob = new ChangeStatePresentationJob
			{
				changePlayerStatePresentationLookups = new ChangePlayerStatePresentationLookups
				{
					triggerEffectLookup = InternalCompilerInterface.GetComponentLookup(ref __TypeHandle.__TriggerEffectCD_RO_ComponentLookup, ref state)
				}
			};
			foreach (ChangePlayerStatePresentationAspect item in IFE_1284889090_0.Query(__query_1284889090_0, __TypeHandle.__IFE_1284889090_0_TypeHandle, ref state))
			{
				changeStatePresentationJob.Execute(item);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
			__query_1284889090_0 = entityQueryBuilder.WithAspect<ChangePlayerStatePresentationAspect>().Build(ref state);
			entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		public void OnCreateForCompiler(ref SystemState state)
		{
			__AssignQueries(ref state);
			__TypeHandle.__AssignHandles(ref state);
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((ChangePlayerStatePresentationSystem*)self.ToPointer())->OnUpdate(ref *(SystemState*)state.ToPointer());
		}

		[Unity.Entities.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((ChangePlayerStatePresentationSystem*)self.ToPointer())->OnCreateForCompiler(ref *(SystemState*)state.ToPointer());
		}
	}
}
