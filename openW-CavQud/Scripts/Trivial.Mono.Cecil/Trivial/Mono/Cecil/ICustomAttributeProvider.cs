using Trivial.Mono.Collections.Generic;

namespace Trivial.Mono.Cecil
{
	public interface ICustomAttributeProvider : IMetadataTokenProvider
	{
		Collection<CustomAttribute> CustomAttributes { get; }

		bool HasCustomAttributes { get; }
	}
}
