using System;

namespace Noesis
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class ContentPropertyAttribute : Attribute
	{
		private string _name;

		public string Name => null;

		public ContentPropertyAttribute()
		{
		}

		public ContentPropertyAttribute(string name)
		{
		}
	}
}
