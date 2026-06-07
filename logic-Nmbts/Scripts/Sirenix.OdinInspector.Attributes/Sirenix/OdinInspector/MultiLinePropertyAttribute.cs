using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public sealed class MultiLinePropertyAttribute : Attribute
	{
		public int Lines;

		public MultiLinePropertyAttribute(int lines = 3)
		{
			Lines = Math.Max(1, lines);
		}
	}
}
