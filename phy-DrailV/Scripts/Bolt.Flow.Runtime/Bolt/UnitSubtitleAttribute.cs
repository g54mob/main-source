using System;

namespace Bolt
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class UnitSubtitleAttribute : Attribute
	{
		public string subtitle { get; private set; }

		public UnitSubtitleAttribute(string subtitle)
		{
			this.subtitle = subtitle;
		}
	}
}
