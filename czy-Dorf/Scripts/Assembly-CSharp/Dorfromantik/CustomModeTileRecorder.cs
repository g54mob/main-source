using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Dorfromantik
{
	public class CustomModeTileRecorder : MonoBehaviour
	{
		private sealed class _003C_003Ec__DisplayClass22_0
		{
			public List<GroupType> groupTypes;

			internal bool _003CRecordTileGeneration_003Eb__0(CustomGroupTypeId x)
			{
				return x.groupType == groupTypes[0];
			}
		}

		[SerializeField]
		private bool record;

		[SerializeField]
		private string subfolderName = "TileRecordings";

		[SerializeField]
		private CustomGroupTypeId[] groupTypeById;

		[SerializeField]
		private CustomModeConfiguration customModeConfiguration;

		[SerializeField]
		private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

		[SerializeField]
		private TileGenerator tileGenerator;

		private string fileName;

		private string fileEnding = ".csv";

		private List<string> tiles = new List<string>();

		private List<string> questTiles = new List<string>();

		private List<string> preplacedTiles = new List<string>();

		private World world;

		private CustomModeInitializer customModeInitializer;

		private UndoTracker undoTracker;

		private string DirectoryPath => Path.Combine(Application.persistentDataPath, subfolderName);

		private string FilePath => Path.Combine(DirectoryPath, fileName + fileEnding);

		private void Awake()
		{
			world = Object.FindObjectOfType<World>();
			customModeInitializer = Object.FindObjectOfType<CustomModeInitializer>();
			undoTracker = Object.FindObjectOfType<UndoTracker>();
		}

		private void Start()
		{
			if (Application.isEditor)
			{
				OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup += StartRecording;
				undoTracker.OnUndo += UndoStoredTurn;
			}
		}

		private void UndoStoredTurn(Tile undoneTile)
		{
			if (undoneTile is QuestTile)
			{
				if (questTiles.Count > 0)
				{
					questTiles.RemoveAt(questTiles.Count - 1);
				}
			}
			else if (tiles.Count > 0)
			{
				tiles.RemoveAt(tiles.Count - 1);
			}
		}

		private void StartRecording()
		{
			OverwritingSingleton<GameSession>.Instance.OnWorldWasSetup -= StartRecording;
			fileName = "SessionRecord_" + customModeConfiguration.configString;
			BinarySaveLoad.CreateDirectories(FilePath);
			if (File.Exists(FilePath))
			{
				int num = Enumerable.Count(Directory.EnumerateFiles(DirectoryPath, "*" + fileName + "*" + fileEnding, SearchOption.AllDirectories));
				fileName += $"_{num}";
			}
			tileGenerator.OnTileGenerated += RecordTileGeneration;
		}

		private void RecordTileGeneration(Tile generatedTile)
		{
			int totalTileCount = world.TotalTileCount;
			if (generatedTile is QuestTile questTile)
			{
				questTiles.Add($"{totalTileCount},{tileGenerator.TileGenerationSeed},{tileGenerator.TileGenerationStep},{tileGenerator.GeneratedTileCount},{tileGenerator.GeneratedQuestCount},{questTile.id},{questTile.Seed},{((!(questTile.QuestWatcher.CurrentQuest == null)) ? questTile.QuestWatcher.CurrentQuest.id : QuestId.Undefined)}," + $"{questTile.QuestWatcher.HasFollowupQuest}");
			}
			else
			{
				string text = "";
				for (int i = 0; i < 6; i++)
				{
					_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass22_0();
					CS_0024_003C_003E8__locals3.groupTypes = generatedTile.GetEdgeTypes(i, Space.Self);
					text = ((CS_0024_003C_003E8__locals3.groupTypes.Count != 0) ? (text + Enumerable.First(groupTypeById, (CustomGroupTypeId x) => x.groupType == CS_0024_003C_003E8__locals3.groupTypes[0]).id) : (text + "x"));
				}
				tiles.Add($"{totalTileCount},{tileGenerator.TileGenerationSeed},{tileGenerator.TileGenerationStep},{tileGenerator.GeneratedTileCount},{tileGenerator.GeneratedQuestCount},{text},{generatedTile.Seed}");
			}
			StoreDocument();
		}

		private void StoreDocument()
		{
			StreamWriter streamWriter = new StreamWriter(FilePath);
			streamWriter.WriteLine("ConfigString," + customModeConfiguration.configString);
			streamWriter.WriteLine($"Tile Generation Seed,{tileGenerator.TileGenerationSeed}");
			streamWriter.WriteLine("QUEST TILES");
			streamWriter.WriteLine("Index,Seed,Generation Step,Generated Tile Count,Generated Quest Count,QuestTileId,Tile Seed,QuestId,Has Flag Quest");
			foreach (string questTile in questTiles)
			{
				streamWriter.WriteLine(questTile ?? "");
			}
			streamWriter.WriteLine("\nTILES");
			streamWriter.WriteLine("Index,Seed,Generation Step,Generated Tile Count,Generated Quest Count,TileString, Tile Seed");
			foreach (string tile in tiles)
			{
				streamWriter.WriteLine(tile ?? "");
			}
			streamWriter.Flush();
			streamWriter.Close();
		}

		private void OnDestroy()
		{
			tileGenerator.OnTileGenerated -= RecordTileGeneration;
		}
	}
}
