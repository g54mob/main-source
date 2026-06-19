using Pug.Conversion;
using Unity.Mathematics;

public class ElectricOrbConverter : SingleAuthoringComponentConverter<ElectricOrbAuthoring>
{
	protected override void Convert(ElectricOrbAuthoring authoring)
	{
		AddComponentData(new ElectricOrbCD
		{
			startDuration = authoring.startDuration,
			loopDuration = authoring.loopDuration,
			endDuration = authoring.endDuration,
			hiddenEndDuration = authoring.hiddenEndDuration,
			bounceOnWalls = authoring.bounceOnWalls,
			movementPatternIndex = -1,
			movementPatterns = CreateAndAddSimpleBlobArrayAsset(authoring.movementPatterns, (ElectricOrbAuthoring.MovementPattern x) => new ElectricOrbMovementPatternBlob
			{
				pattern = x.pattern,
				minMaxDurationSeconds = x.minMaxDurationSeconds,
				minMaxSpeed = x.minMaxSpeed,
				sinusoidalPattern = x.sinusoidalPattern,
				sinusoidalMaxTurnAngleRadians = math.radians(x.sinusoidalMaxTurnAngleDegrees),
				sinusoidalRepeatTimeSeconds = x.sinusoidalRepeatTimePerSecond
			})
		});
	}
}
