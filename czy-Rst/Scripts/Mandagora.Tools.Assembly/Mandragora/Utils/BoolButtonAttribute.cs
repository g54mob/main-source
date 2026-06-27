using System;

namespace Mandragora.Utils
{
	public class BoolButtonAttribute : Attribute
	{
		public string Label;

		public bool Green = true;

		public bool Red = true;

		public bool Inverse;

		public readonly int Height;

		public readonly int Weight;

		public BoolButtonAttribute(int height = 25, int weight = 0)
		{
			Height = height;
			Weight = weight;
		}
	}
}
