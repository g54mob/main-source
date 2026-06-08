using Timberborn.BlueprintSystem;

namespace Timberborn.Buildings
{
	internal record FireSpec : ComponentSpec
	{
		[Serialize]
		public string AttachmentId { get; init; }
	}
}
