namespace ModApi.Planet
{
	public interface IPlanetTerrainQuality
	{
		int MaxSubdivisionLevel { get; }

		int MinSubdivisionLevel { get; }

		long QuadSphereActivationDistance { get; }

		long QuadSphereTransitionDistance { get; }

		int TerrainQuadEdgeVertexCount { get; }

		int WaterQuadEdgeVertexCount { get; }
	}
}
