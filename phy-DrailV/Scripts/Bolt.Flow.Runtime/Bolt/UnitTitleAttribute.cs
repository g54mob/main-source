using System;

namespace Bolt
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class UnitTitleAttribute : Attribute
	{
		public string title { get; private set; }

		public UnitTitleAttribute(string title)
		{
			this.title = title;
		}
	}
}
