using System;
using ProtoBuf.Internal;

namespace ProtoBuf
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
	public sealed class ProtoPartialIgnoreAttribute : ProtoIgnoreAttribute
	{
		public string MemberName { get; }

		public ProtoPartialIgnoreAttribute(string memberName)
		{
			if (string.IsNullOrEmpty(memberName))
			{
				ThrowHelper.ThrowArgumentNullException("memberName");
			}
			MemberName = memberName;
		}
	}
}
