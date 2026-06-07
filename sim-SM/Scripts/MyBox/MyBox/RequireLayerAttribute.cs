using System;

namespace MyBox
{
	[AttributeUsage(AttributeTargets.Class)]
	public class RequireLayerAttribute : Attribute
	{
		public readonly string LayerName;

		public readonly int LayerIndex;

		public RequireLayerAttribute(string layer)
		{
		}

		public RequireLayerAttribute(int layer)
		{
		}
	}
}
