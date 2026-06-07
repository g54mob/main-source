using System;

namespace Gh
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
	public class MakeButtonAttribute : Attribute
	{
		public string Label { get; }

		public MakeButtonAttribute(string label = null)
		{
		}
	}
}
