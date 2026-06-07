using System.Collections.Generic;
using System.Reflection;

namespace Ludiq
{
	public class MemberInfoComparer : EqualityComparer<MemberInfo>
	{
		public override bool Equals(MemberInfo x, MemberInfo y)
		{
			return x?.MetadataToken == y?.MetadataToken;
		}

		public override int GetHashCode(MemberInfo obj)
		{
			return obj.MetadataToken;
		}
	}
}
