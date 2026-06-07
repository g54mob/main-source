using Ludiq;
using UnityEngine;

namespace Bolt
{
	public interface IEventMachine : IMachine, IGraphRoot, IGraphParent, IGraphNester, IAotStubbable
	{
		void TriggerAnimationEvent(AnimationEvent animationEvent);

		void TriggerUnityEvent(string name);
	}
}
