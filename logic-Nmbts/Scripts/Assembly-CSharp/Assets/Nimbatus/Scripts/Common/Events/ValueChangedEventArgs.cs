using System;

namespace Assets.Nimbatus.Scripts.Common.Events
{
	public class ValueChangedEventArgs : EventArgs
	{
		public readonly float LastValue;

		public readonly float NewValue;

		public ValueChangedEventArgs(float lastValue, float newValue)
		{
			LastValue = lastValue;
			NewValue = newValue;
		}
	}
}
