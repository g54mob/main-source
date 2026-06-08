using System;

namespace CsvHelper
{
	public readonly struct ReferenceHeaderPrefixArgs
	{
		public readonly Type MemberType;

		public readonly string MemberName;

		public ReferenceHeaderPrefixArgs(Type memberType, string memberName)
		{
			MemberType = memberType;
			MemberName = memberName;
		}
	}
}
