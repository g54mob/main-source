using System;

namespace Bolt
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class UnitShortTitleAttribute : Attribute
	{
		public string title { get; private set; }

		public UnitShortTitleAttribute(string title)
		{
			this.title = title;
		}
	}
}
