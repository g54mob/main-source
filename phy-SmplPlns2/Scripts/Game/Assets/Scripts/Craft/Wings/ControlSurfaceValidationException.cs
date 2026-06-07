using System;

namespace Assets.Scripts.Craft.Wings
{
	public class ControlSurfaceValidationException : Exception
	{
		public ControlSurfaceValidationException(string message)
			: base(message)
		{
		}
	}
}
