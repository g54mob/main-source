using UnityEngine.Playables;

namespace Animancer
{
	public interface IPlayableWrapper
	{
		IPlayableWrapper Parent { get; }

		float Weight { get; }

		Playable Playable { get; }

		int ChildCount { get; }

		bool KeepChildrenConnected { get; }

		float Speed { get; set; }

		bool ApplyAnimatorIK { get; set; }

		bool ApplyFootIK { get; set; }

		AnimancerNode GetChild(int index);
	}
}
