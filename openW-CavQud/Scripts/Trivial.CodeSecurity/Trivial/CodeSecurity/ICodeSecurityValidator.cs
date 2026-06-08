using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity
{
	public interface ICodeSecurityValidator
	{
		bool IsAssemblyReferenceAllowed(string assemblyReference);

		bool IsNamespaceReferenceAllowed(string namespaceName);

		bool IsTypeReferenceAllowed(TypeReference reference);

		bool IsMemberReferenceAllowed(MemberReference reference);
	}
}
