using ContainedMiniSim.Authoring;
using ContainedMiniSim.Components;
using Pug.Conversion;

namespace ContainedMiniSim.Converters
{
	public class AquariumFishMovementConverter : SingleAuthoringComponentConverter<AquariumFishMovementAuthoring>
	{
		protected override void Convert(AquariumFishMovementAuthoring authoring)
		{
			AddComponentData(new AquariumFishMovementCD
			{
				swimSpeedMinMax = authoring.swimSpeedMinMax,
				idleTimeMinMax = authoring.idleTimeMinMax,
				smoothingFactor = authoring.smoothingFactor
			});
		}
	}
}
