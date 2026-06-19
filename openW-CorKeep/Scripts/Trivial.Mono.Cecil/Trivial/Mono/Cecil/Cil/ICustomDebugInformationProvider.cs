using Trivial.Mono.Collections.Generic;

namespace Trivial.Mono.Cecil.Cil
{
	public interface ICustomDebugInformationProvider : IMetadataTokenProvider
	{
		bool HasCustomDebugInformations { get; }

		Collection<CustomDebugInformation> CustomDebugInformations { get; }
	}
}
