using System.Collections.Immutable;
using Timberborn.BlueprintSystem;

namespace Timberborn.Illumination
{
	internal record IlluminatorLightObjectsSpec : ComponentSpec
	{
		[Serialize]
		public ImmutableArray<string> AttachmentIds { get; init; }
	}
}
