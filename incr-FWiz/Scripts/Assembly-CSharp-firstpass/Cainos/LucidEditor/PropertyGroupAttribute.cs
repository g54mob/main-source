using System;

namespace Cainos.LucidEditor
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class PropertyGroupAttribute : Attribute
	{
		public readonly string path;

		public readonly string name;

		public readonly int groupDepth;

		public PropertyGroupAttribute(string groupPath)
		{
		}
	}
}
