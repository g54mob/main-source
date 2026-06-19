using System;

namespace Sentry
{
	[AttributeUsage(AttributeTargets.Assembly)]
	public class DsnAttribute : Attribute
	{
		public string Dsn { get; }

		public DsnAttribute(string dsn)
		{
			Dsn = dsn;
		}
	}
}
