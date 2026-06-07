using UnityEngine;

namespace MalbersAnimations
{
	public interface IAnimatorListener
	{
		Transform transform { get; }

		bool OnAnimatorBehaviourMessage(string message, object value);
	}
}
