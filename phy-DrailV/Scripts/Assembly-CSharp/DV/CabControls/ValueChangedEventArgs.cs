using System;

namespace DV.CabControls
{
	public class ValueChangedEventArgs : EventArgs
	{
		public float oldValue;

		public float newValue;

		public float delta;

		public ValueChangedEventArgs(float oldValue, float newValue)
		{
			this.oldValue = oldValue;
			this.newValue = newValue;
			delta = newValue - oldValue;
		}

		public ValueChangedEventArgs(float oldValue, float newValue, float delta)
		{
			this.oldValue = oldValue;
			this.newValue = newValue;
			this.delta = delta;
		}
	}
}
