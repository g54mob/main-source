using System;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public sealed class fsForwardAttribute : Attribute
	{
		public string MemberName;

		public fsForwardAttribute(string memberName)
		{
		}
	}
}
