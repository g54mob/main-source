using Pug.Conversion;
using Unity.Mathematics;

public class RoamingPathConverter : SingleAuthoringComponentConverter<RoamingPathAuthoring>
{
	protected override void Convert(RoamingPathAuthoring authoring)
	{
		AddComponentData(new RoamingPathCD
		{
			pathType = authoring.pathType,
			regionRadius = authoring.regionRadius,
			pointCount = authoring.pointCount,
			segmentation = authoring.segmentation,
			zigzagAmount = authoring.zigzagAmount,
			forceBiome = authoring.forceBiome.GetOrDefault(Biome.None),
			minAngleToBiomeMidpoint = math.radians(authoring.minAngleToBiomeMidpoint),
			angleWidth = math.radians(authoring.maxAngleToBiomeMidpoint - authoring.minAngleToBiomeMidpoint),
			distanceDeviation = authoring.distanceDeviation,
			pathLengthMultiplier = authoring.pathLengthMultiplier,
			distanceBetweenPoints = authoring.distanceBetweenPoints,
			curveSmoothness = authoring.curveSmoothness,
			angleDeviation = authoring.angleDeviation,
			pointsBetweenAngleDeviationChanges = authoring.pointsBetweenAngleDeviationChanges,
			drawDebugLines = authoring.drawDebugLines
		});
		EnsureHasBuffer<RoamingPathBuffer>();
		EnsureHasComponent<HasSpawnPointCD>();
		if (authoring.roamAroundPlayerIfInSubBiome)
		{
			EnsureHasComponent<ForceRoamAroundPlayerCD>(componentIsEnabled: false);
			AddComponentData(new RoamAroundPlayerWhenInSubBiomeCD
			{
				subBiomeTileset = authoring.playerCheckSubBiomeTileset
			});
		}
	}
}
