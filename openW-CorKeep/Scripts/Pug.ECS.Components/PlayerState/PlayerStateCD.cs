using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.NetCode;

namespace PlayerState
{
	public struct PlayerStateCD : IComponentData, IQueryTypeParameter
	{
		[GhostField]
		public PlayerStateEnum nextState;

		[GhostField]
		public PlayerStateEnum level1State;

		[GhostField]
		public PlayerStateEnum level2State;

		[GhostField]
		public PlayerStateEnum level3State;

		[GhostField]
		public bool isStateLocked;

		[GhostField]
		public bool nextStateLocked;

		[GhostField]
		public bool nextStatePushed;

		[GhostField]
		public PlayerStateEnum nextPoppedStateMask;

		public PlayerStateEnum presentationCurrentStateMask;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly PlayerStateEnum AllStates()
		{
			return level1State | level2State | level3State;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool HasAnyState(PlayerStateEnum state)
		{
			return (state & AllStates()) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool HasNoneState(PlayerStateEnum state)
		{
			return !HasAnyState(state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetNextState(PlayerStateEnum nextState, bool nextStateLocked = false)
		{
			if (!this.nextStateLocked)
			{
				this.nextState = nextState;
				this.nextStateLocked = nextStateLocked;
				nextStatePushed = false;
				nextPoppedStateMask = PlayerStateEnum.Null;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void UnlockCurrentState(ref PlayerOrientationCD playerOrientationCD, bool stayInCurrentState = false)
		{
			if (isStateLocked)
			{
				playerOrientationCD.reorientationBlocked = false;
				isStateLocked = false;
				if (!stayInCurrentState)
				{
					SetNextState(PlayerStateEnum.Walk);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void PushState(PlayerStateEnum nextState)
		{
			if (!nextStateLocked)
			{
				this.nextState = nextState;
				nextStateLocked = false;
				nextStatePushed = true;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void PopState(PlayerStateEnum poppedState)
		{
			nextPoppedStateMask |= poppedState;
		}
	}
}
