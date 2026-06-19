using System.Reflection;

namespace PugMod
{
	public class MemberInfo
	{
		internal System.Reflection.MemberInfo Internal;

		public static implicit operator System.Reflection.MemberInfo(MemberInfo o)
		{
			return o.Internal;
		}

		public static implicit operator MemberInfo(System.Reflection.MemberInfo o)
		{
			return new MemberInfo
			{
				Internal = o
			};
		}
	}
}
