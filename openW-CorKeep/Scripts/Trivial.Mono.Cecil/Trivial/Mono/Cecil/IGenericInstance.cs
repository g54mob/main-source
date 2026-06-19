using Trivial.Mono.Collections.Generic;

namespace Trivial.Mono.Cecil
{
	public interface IGenericInstance : IMetadataTokenProvider
	{
		bool HasGenericArguments { get; }

		Collection<TypeReference> GenericArguments { get; }
	}
}
