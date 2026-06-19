using Unity.Entities;
using Unity.Mathematics;

public struct RoamingPathCD : IComponentData, IQueryTypeParameter
{
	public RoamingPathType pathType;

	public int regionRadius;

	public int pointCount;

	public int segmentation;

	public float zigzagAmount;

	public Biome forceBiome;

	public float minAngleToBiomeMidpoint;

	public float angleWidth;

	public float distanceDeviation;

	public float pathLengthMultiplier;

	public float2 distanceBetweenPoints;

	public float angleDeviation;

	public int pointsBetweenAngleDeviationChanges;

	public float curveSmoothness;

	public bool drawDebugLines;
}
