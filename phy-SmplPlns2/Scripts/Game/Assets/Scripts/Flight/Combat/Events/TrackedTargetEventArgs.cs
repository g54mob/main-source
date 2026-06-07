using System;

namespace Assets.Scripts.Flight.Combat.Events
{
	public class TrackedTargetEventArgs : EventArgs
	{
		public TrackedTarget TrackedTarget { get; }

		public TrackedTargetEventArgs(TrackedTarget trackedTarget)
		{
			TrackedTarget = trackedTarget;
		}
	}
}
