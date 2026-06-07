using System;
using Ludiq;

namespace Bolt
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	public class PortKeyAttribute : Attribute
	{
		public string key { get; }

		public PortKeyAttribute(string key)
		{
			Ensure.That("key").IsNotNull(key);
			this.key = key;
		}
	}
}
