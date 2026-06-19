using ContainedMiniSim.Authoring;
using ContainedMiniSim.Components;
using Pug.Conversion;

namespace ContainedMiniSim.Converters
{
	public class TerrariumCritterMovementConverter : SingleAuthoringComponentConverter<TerrariumCritterMovementAuthoring>
	{
		protected override void Convert(TerrariumCritterMovementAuthoring authoring)
		{
			AddComponentData(new TerrariumCritterMovementCD
			{
				moveSpeed = authoring.speed,
				minMaxIdleTime = authoring.minMaxIdleTime
			});
		}
	}
}
