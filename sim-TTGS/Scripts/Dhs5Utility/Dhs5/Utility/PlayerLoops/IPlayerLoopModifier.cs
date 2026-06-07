using UnityEngine.LowLevel;

namespace Dhs5.Utility.PlayerLoops
{
	public interface IPlayerLoopModifier
	{
		int Priority { get; }

		PlayerLoopSystem ModifyPlayerLoop(PlayerLoopSystem playerLoopSystem);
	}
}
