using System;

namespace Rhizomatic.MemberBinding
{
	[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
	public sealed class MemberAttribute : Attribute
	{
		public bool customName;

		public string name { get; }

		public MemberAttribute()
		{
		}

		public MemberAttribute(string name)
		{
		}

		public string GetName(string memberName)
		{
			return null;
		}
	}
}
