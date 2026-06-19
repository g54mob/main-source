using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity
{
	public class IllegalMemberReference : IllegalTypeReference
	{
		private MemberReference referencedMember;

		public MemberReference ReferencedMember => referencedMember;

		public IllegalMemberReference(MemberReference illegalMember, IllegalReferenceUsage illegalUsage, bool indirect)
			: base(illegalMember.DeclaringType, illegalUsage, indirect)
		{
			referencedMember = illegalMember;
		}

		public override string ToString()
		{
			if (!indirect)
			{
				return $"Illegal reference to disallowed member: {referencedMember}";
			}
			return $"Indirect illegal reference via type exclusion to disallowed member: {referencedMember}";
		}
	}
}
