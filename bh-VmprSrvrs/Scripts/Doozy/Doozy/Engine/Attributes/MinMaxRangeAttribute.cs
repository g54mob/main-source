using System;

namespace Doozy.Engine.Attributes
{
	public class MinMaxRangeAttribute : Attribute
	{
		public float Min { get; private set; }

		public float Max { get; private set; }

		public MinMaxRangeAttribute(float min, float max)
		{
		}
	}
}
