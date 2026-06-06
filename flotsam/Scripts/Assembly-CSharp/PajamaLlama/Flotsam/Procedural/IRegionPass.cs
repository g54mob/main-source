namespace PajamaLlama.Flotsam.Procedural
{
	public interface IRegionPass
	{
		int SpawnCount { get; }

		void Initialize(TileGenerator tileGenerator);

		bool InitializeRegion(TileGeneratorRegion region);

		void Run(RegionPassGroup regionPasses, TileGeneratorRegion region);

		void Uninitialize();
	}
}
