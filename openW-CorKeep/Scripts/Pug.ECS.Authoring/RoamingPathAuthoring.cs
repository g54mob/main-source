using NaughtyAttributes;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Mathematics;
using UnityEngine;

[DisallowMultipleComponent]
public class RoamingPathAuthoring : MonoBehaviour
{
	public RoamingPathType pathType;

	[AllowNesting]
	[ShowIf("pathType", RoamingPathType.RandomInsideCircle)]
	public int regionRadius = 50;

	[AllowNesting]
	[ShowIf("pathType", RoamingPathType.RandomInsideCircle)]
	public int pointCount = 10;

	[AllowNesting]
	[ShowIf("pathType", RoamingPathType.RandomInsideCircle)]
	public int segmentation = 10;

	[AllowNesting]
	[ShowIf("pathType", RoamingPathType.RandomInsideCircle)]
	public float zigzagAmount;

	[AllowNesting]
	[ShowIf("pathType", RoamingPathType.StayInsideBiomeAtDistanceFromCore)]
	public OptionalValue<Biome> forceBiome;

	[AllowNesting]
	[ShowIf("pathType", RoamingPathType.StayInsideBiomeAtDistanceFromCore)]
	public float minAngleToBiomeMidpoint = -10f;

	[AllowNesting]
	[ShowIf("pathType", RoamingPathType.StayInsideBiomeAtDistanceFromCore)]
	public float maxAngleToBiomeMidpoint = 10f;

	[AllowNesting]
	[ShowIf("pathType", RoamingPathType.StayInsideBiomeAtDistanceFromCore)]
	public float distanceDeviation;

	[AllowNesting]
	[ShowIf("pathType", RoamingPathType.StayInsideBiomeAtDistanceFromCore)]
	public float pathLengthMultiplier = 1f;

	[AllowNesting]
	[ShowIf("pathType", RoamingPathType.StayInsideBiomeAtDistanceFromCore)]
	[MinMaxSlider(1f, 200f)]
	public Vector2 distanceBetweenPoints;

	[AllowNesting]
	[ShowIf("pathType", RoamingPathType.StayInsideBiomeAtDistanceFromCore)]
	[Range(0f, 0.9f)]
	public float curveSmoothness = 0.5f;

	[AllowNesting]
	[ShowIf("pathType", RoamingPathType.StayInsideBiomeAtDistanceFromCore)]
	[Range(0f, 85f)]
	public float angleDeviation = 50f;

	[AllowNesting]
	[ShowIf("pathType", RoamingPathType.StayInsideBiomeAtDistanceFromCore)]
	public int pointsBetweenAngleDeviationChanges = 5;

	public bool roamAroundPlayerIfInSubBiome;

	public Tileset playerCheckSubBiomeTileset;

	public bool drawDebugLines;

	private void OnValidate()
	{
		maxAngleToBiomeMidpoint = math.max(minAngleToBiomeMidpoint, maxAngleToBiomeMidpoint);
	}
}
