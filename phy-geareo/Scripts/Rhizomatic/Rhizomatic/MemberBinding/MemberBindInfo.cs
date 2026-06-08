using System;

namespace Rhizomatic.MemberBinding
{
	public class MemberBindInfo
	{
		public readonly bool isMethod;

		public string[] bindNames;

		public Type memberType;

		public string memberName;

		public Action<object, Member> setMember;

		public Func<object, Member> getMember;

		public Action<object, object[]> call;

		public MemberBindInfo(string memberName, string[] bindNames, Type memberType, Func<object, Member> getMember, Action<object, Member> setMember)
		{
		}

		public MemberBindInfo(string memberName, string[] bindNames, Action<object, object[]> call)
		{
		}
	}
}
