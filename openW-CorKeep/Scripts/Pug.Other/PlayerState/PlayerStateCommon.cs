using System.Runtime.CompilerServices;

namespace PlayerState
{
	public class PlayerStateCommon
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ExitPoppedState(ChangePlayerStateAspect changePlayerStateAspect, ChangePlayerStateShared changePlayerStateShared)
		{
			if (changePlayerStateAspect.playerStateCD.ValueRO.HasAnyState(PlayerStateEnum.MinecartRiding | PlayerStateEnum.BoatRiding))
			{
				PlayerController.PlayAnimationTrigger(-1193264516, changePlayerStateShared.currentTick, changePlayerStateAspect.animationBuffer, ref changePlayerStateAspect.animationBufferPointer.ValueRW);
			}
		}
	}
}
