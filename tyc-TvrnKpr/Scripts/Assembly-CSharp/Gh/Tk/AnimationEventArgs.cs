using System;

namespace Gh.Tk
{
	public class AnimationEventArgs : EventArgs
	{
		public string Name { get; }

		public BasicAnimationEventObserver AnimationEventObserver { get; }

		public AnimationEventArgs(string name, BasicAnimationEventObserver observer)
		{
		}
	}
}
