namespace PajamaLlama.Flotsam.World
{
	public interface IWorldTile
	{
		void AddRegion(IWorldRegion worldRegion);

		void AddRoadSpawner(RoadSpawner roadSpawner);

		void AddLandmarkSpawner(LandmarkSpawner landmarkSpawner);

		void AddPointOfInterestSpawner(PointOfInterestSpawner pointOfInterestSpawner);

		void PopulateRegionNeighbors();
	}
}
