using System;

namespace Assets.Scripts.Flight.Combat.Events
{
	public class TargetEventArgs : EventArgs
	{
		public Target Target { get; }

		public TargetEventArgs(Target target)
		{
			Target = target;
		}
	}
}
