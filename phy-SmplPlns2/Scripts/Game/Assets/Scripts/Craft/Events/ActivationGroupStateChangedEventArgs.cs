using System;

namespace Assets.Scripts.Craft.Events
{
	public class ActivationGroupStateChangedEventArgs : EventArgs
	{
		public int ActivationGroup { get; }

		public bool ActivationGroupState { get; }

		public ActivationGroupStateChangedEventArgs(int group, bool state)
		{
			ActivationGroup = group;
			ActivationGroupState = state;
		}
	}
}
