using System;

namespace Platforms
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
	public class Cert : Attribute
	{
		public Cert(params TRC[] tag)
		{
		}
	}
}
