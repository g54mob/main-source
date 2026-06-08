using Trivial.Mono.Collections.Generic;

namespace Trivial.Mono.Cecil
{
	public interface ISecurityDeclarationProvider : IMetadataTokenProvider
	{
		bool HasSecurityDeclarations { get; }

		Collection<SecurityDeclaration> SecurityDeclarations { get; }
	}
}
