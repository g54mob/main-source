using UnityEngine;

namespace MalbersAnimations
{
	public interface IWayPoint : IAITarget, IObjectCore
	{
		Transform WPTransform { get; }

		float WaitTime { get; }

		Transform NextTarget();
	}
}
