using System;

namespace MalbersAnimations
{
	[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
	public sealed class LineAttribute : Attribute
	{
		public readonly float height;

		public LineAttribute()
		{
			height = 8f;
		}

		public LineAttribute(float height)
		{
			this.height = height;
		}
	}
}
