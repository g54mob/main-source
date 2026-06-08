using System;

namespace Rhizomatic.MemberBinding
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
	public sealed class CustomMemberBindingAttribute : Attribute
	{
	}
}
