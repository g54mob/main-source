using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity
{
	public interface ICodeSecurityValidator
	{
		bool AllowPInvoke { get; }

		bool IsAssemblyReferenceAllowed(string assemblyReference);

		bool IsNamespaceReferenceAllowed(TypeReference reference);

		bool IsTypeReferenceAllowed(TypeReference reference);

		bool IsMemberReferenceAllowed(MemberReference reference);
	}
}
