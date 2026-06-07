using System;

namespace Ludiq
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class InspectorAdaptiveWidthAttribute : Attribute
	{
		public float width { get; private set; }

		public InspectorAdaptiveWidthAttribute(float width)
		{
			this.width = width;
		}
	}
}
