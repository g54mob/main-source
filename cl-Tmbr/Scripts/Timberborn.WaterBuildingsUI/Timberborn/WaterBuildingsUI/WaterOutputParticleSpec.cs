using Timberborn.BlueprintSystem;

namespace Timberborn.WaterBuildingsUI
{
	internal record WaterOutputParticleSpec : ComponentSpec
	{
		[Serialize]
		public string AttachmentId { get; init; }
	}
}
