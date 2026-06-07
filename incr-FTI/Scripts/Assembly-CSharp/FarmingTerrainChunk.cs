using System.Collections.Generic;
using FullSerializer;

public class FarmingTerrainChunk
{
	public readonly List<FarmingMinigameButton> tiles = new List<FarmingMinigameButton>();

	private readonly Coord startCoord;

	private readonly Coord endCoord;

	public FarmingTerrainChunk(Coord min, Coord max)
	{
		startCoord = min;
		endCoord = max;
	}

	public fsData GetData()
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		dictionary["start"] = SaveFile.DataFromCoord(startCoord);
		dictionary["end"] = SaveFile.DataFromCoord(endCoord);
		List<fsData> list = new List<fsData>();
		foreach (FarmingMinigameButton tile in tiles)
		{
			list.Add(tile.GetData());
		}
		dictionary["Items"] = new fsData(list);
		return new fsData(dictionary);
	}
}
