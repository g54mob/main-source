using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations
{
	public interface IAimTarget
	{
		bool AimAssist { get; }

		Transform AimPoint { get; }

		GameObject gameObject { get; }

		void IsBeenAimed(bool enter, Aim AimedBy);
	}
}
