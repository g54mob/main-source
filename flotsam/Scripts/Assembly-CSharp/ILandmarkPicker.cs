using System.Collections.Generic;
using PajamaLlama.Flotsam.World;

public interface ILandmarkPicker
{
	LandmarkSpawner BestPick { get; }

	ScoutingState MaximumScoutingState => ScoutingState.Selected;

	bool CanPickFrom(TileGeneratorBase tileGeneratorBase);

	bool SkipRegion(IWorldRegion region);

	bool SetBestPick(IEnumerable<LandmarkSpawner> spawners)
	{
		foreach (LandmarkSpawner spawner in spawners)
		{
			SetBestPick(spawner);
		}
		return BestPick != null;
	}

	bool SetBestPick(LandmarkSpawner spawner);

	bool IsBetterPick(LandmarkSpawner spawner);

	bool ConfirmBestPick(LandmarkSpawner spawner);

	bool TryGetNextWorldTile(out WorldTile tile, World world);
}
