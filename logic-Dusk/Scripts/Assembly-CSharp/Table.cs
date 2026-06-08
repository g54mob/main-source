using System.Collections.Generic;
using System.IO;
using System.Linq;
using BoardEditor;
using Pieces;
using UnityEngine;

public class Table : MonoBehaviour, IMetaData
{
	private const float defaultMarkerHeight = 0.2f;

	public static Table Instance;

	public bool IsInEditorMode = true;

	public int ManaEarnedPerPiece = 1;

	public int ManaMax = 10;

	public Color MoveTintColor = Color.red;

	public float MoveTintLerp = 0.7f;

	public Color AltMoveTintColor = Color.yellow;

	public float AltMoveTintLerp = 0.7f;

	public Color PieceSpawnTintColor = Color.green;

	public Color PieceSpawnTintColor2 = Color.gray;

	public float PieceSpawnTintLerp = 0.7f;

	private bool _isWaitingOnUserInput;

	private int currentPlayerId = -1;

	private string currentBoardXml;

	public Transform tile;

	public List<IGEObject> boardObjects = new List<IGEObject>();

	public GEPaintedTiles paintedTiles;

	public List<TileData> legalTilesForNextSpawn = new List<TileData>();

	private List<SpawnMarker> legalSpawnMarkers = new List<SpawnMarker>();

	public GameObject MoveMarkerRing;

	public GameObject MoveMarkerDot;

	public string boardFilePath = string.Empty;

	public Player[] players;

	private BoardScript boardObject;

	public static GUISkin tableSkin;

	public static bool seeEmptyTiles { get; set; }

	public List<DesignedDungeonManager.MetaData> metaDataList { get; set; }

	public bool isWaitingOnUserInput
	{
		get
		{
			return _isWaitingOnUserInput;
		}
		set
		{
			_isWaitingOnUserInput = value;
		}
	}

	public Rect BoardDim { get; set; }

	public Vector2 BoardCenter { get; set; }

	public int CurrentPlayerId
	{
		get
		{
			return currentPlayerId;
		}
	}

	public Player CurrentPlayer
	{
		get
		{
			if (currentPlayerId >= 0)
			{
				return players[currentPlayerId];
			}
			return null;
		}
	}

	public string CurrentBoardXml
	{
		get
		{
			return currentBoardXml;
		}
	}

	public TileData[,] tiles
	{
		get
		{
			return DesignedDungeonManager.tiles;
		}
		set
		{
			DesignedDungeonManager.tiles = value;
		}
	}

	private void Awake()
	{
		Instance = this;
		seeEmptyTiles = false;
		tableSkin = (GUISkin)Resources.Load("UI/TableSkin");
		if (tableSkin != null)
		{
		}
		if (GlobalSettings.gameLaunchedFromMenu)
		{
			boardFilePath = GlobalSettings.gameBoardFile;
		}
		paintedTiles = new GEPaintedTiles(this);
	}

	private void Start()
	{
		players = new Player[1];
		players[0] = new Player();
		GlobalSettings.TileTints.moveColor = MoveTintColor;
		GlobalSettings.TileTints.moveLerp = MoveTintLerp;
		GlobalSettings.TileTints.altMoveColor = AltMoveTintColor;
		GlobalSettings.TileTints.altMoveLerp = AltMoveTintLerp;
		GlobalSettings.TileTints.pieceSpawnColor = PieceSpawnTintColor;
		GlobalSettings.TileTints.pieceSpawnColor2 = PieceSpawnTintColor2;
		GlobalSettings.TileTints.pieceSpawnLerp = PieceSpawnTintLerp;
		boardObject = (BoardScript)base.gameObject.GetComponent(typeof(BoardScript));
	}

	private void Update()
	{
	}

	public void OnGUI()
	{
		GUI.skin = tableSkin;
	}

	public int NumberOfPlayersLeftInGame()
	{
		return players.Where((Player x) => !x.RemovedFromGame).Count();
	}

	public int SetCurrentPlayer(int playerId)
	{
		currentPlayerId = playerId;
		return currentPlayerId;
	}

	public void InitEmptyBoard()
	{
		InitEmptyBoard(null, null, null, null);
	}

	public void InitEmptyBoard(TileScript.TileEventHandler mouseDownEvent, TileScript.TileEventHandler mouseUpEvent, TileScript.TileEventHandler mouseEnterEvent, TileScript.TileEventHandler mouseExitEvent)
	{
		tile.GetComponent<Renderer>().enabled = true;
		if (tiles == null)
		{
			tiles = new TileData[36, 28];
			for (int i = 0; i < 36; i++)
			{
				for (int j = 0; j < 28; j++)
				{
					Transform transform = (Transform)Object.Instantiate(tile, new Vector3((float)i * tile.transform.localScale.x, (float)j * tile.transform.localScale.y, 0f), Quaternion.identity);
					tiles[i, j] = new TileData();
					tiles[i, j].visualComponent = transform.GetComponent<TileScript>();
					tiles[i, j].visualComponent.parentTileData = tiles[i, j];
					if (mouseDownEvent != null)
					{
						tiles[i, j].visualComponent.MouseDownOnTileEvent += mouseDownEvent;
					}
					if (mouseUpEvent != null)
					{
						tiles[i, j].visualComponent.MouseUpOnTileEvent += mouseUpEvent;
					}
					if (mouseEnterEvent != null)
					{
						tiles[i, j].visualComponent.MouseEnterTileEvent += mouseEnterEvent;
					}
					if (mouseExitEvent != null)
					{
						tiles[i, j].visualComponent.MouseExitTileEvent += mouseExitEvent;
					}
					tiles[i, j].boardPosition = new BoardPosition(i, j);
					tiles[i, j].currentTileType = TileData.TileTypeEnum.Undefined;
					tiles[i, j].visualComponent.SetColor(GlobalSettings.editorUnusedTileColor);
				}
			}
		}
		else
		{
			if (boardObjects != null && boardObjects.Count > 0)
			{
				foreach (IGEObject boardObject in boardObjects)
				{
					boardObject.DeActivate();
					boardObject.Destroy();
				}
			}
			boardObjects.Clear();
			paintedTiles.Clear();
			for (int k = 0; k < 36; k++)
			{
				for (int l = 0; l < 28; l++)
				{
					tiles[k, l].currentTileType = TileData.TileTypeEnum.Undefined;
					tiles[k, l].visualComponent.SetColor(GlobalSettings.editorUnusedTileColor);
				}
			}
		}
		if (!seeEmptyTiles)
		{
			for (int m = 0; m < 36; m++)
			{
				for (int n = 0; n < 28; n++)
				{
					if (tiles[m, n].currentTileType == TileData.TileTypeEnum.Undefined)
					{
						tiles[m, n].visualComponent.GetComponent<Renderer>().enabled = false;
					}
				}
			}
		}
		tile.GetComponent<Renderer>().enabled = false;
	}

	public bool LoadBoard(out string xmlText, ref List<DesignedDungeonManager.MetaData> metaDataList)
	{
		return LoadBoard(boardFilePath, out xmlText, ref metaDataList);
	}

	public bool LoadBoard(string file, ref List<DesignedDungeonManager.MetaData> metaDataList)
	{
		string xmlText;
		return LoadBoard(file, out xmlText, ref metaDataList);
	}

	public bool LoadBoard(string file, out string xmlText, ref List<DesignedDungeonManager.MetaData> metaDataList)
	{
		bool flag = false;
		xmlText = string.Empty;
		if (GameFileHelper.ListAvailableInternalGameBoardNames().Any((string x) => x == file))
		{
			GameFileHelper.GetInternalBoardXml(file, out xmlText);
		}
		else if (File.Exists(file))
		{
			xmlText = File.ReadAllText(file);
		}
		if (!string.IsNullOrEmpty(xmlText))
		{
			flag = LoadBoardFromXml(xmlText, ref metaDataList);
			if (flag)
			{
				boardFilePath = file;
			}
		}
		return flag;
	}

	public bool LoadBoardFromXml(string xmlText, ref List<DesignedDungeonManager.MetaData> metaDataList)
	{
		currentBoardXml = xmlText;
		return DesignedDungeonManager.LoadBoardFromXml(xmlText, ref boardObjects, ref metaDataList);
	}

	public void StartNewBoard()
	{
		if (tiles != null)
		{
			if (IsInEditorMode)
			{
				GameEditorScript gameEditorScript = (GameEditorScript)GetComponent(typeof(GameEditorScript));
				gameEditorScript.SetPaintBrush(4);
			}
			for (int i = 0; i < 36; i++)
			{
				for (int j = 0; j < 28; j++)
				{
					TileData tileData = tiles[i, j];
					tileData.BoardX = i;
					tileData.BoardY = j;
				}
			}
		}
		else
		{
			Debug.LogWarning("Tiles are null!  The Table has not been properly initialized.  Be sure to call InitEmptyBoard() at least once!");
		}
	}

	public List<IGEObject> GetObjectListByType(GEObjectTypeEnum objectType)
	{
		List<IGEObject> list = new List<IGEObject>();
		foreach (IGEObject boardObject in boardObjects)
		{
			if (boardObject.objectType == GEObjectTypeEnum.Room)
			{
				list.Add(boardObject);
			}
		}
		return list;
	}

	public void StartTurn()
	{
	}

	public void CalculateLegalTilesForNextSpawn(int playerId, PieceTypeEnum pieceTypeToSpawn)
	{
		legalTilesForNextSpawn.Clear();
		legalSpawnMarkers.Clear();
		if (pieceTypeToSpawn == PieceTypeEnum.Twin)
		{
			IEnumerable<Piece> enumerable = boardObject.PieceList.Where((Piece x) => x.pieceType == PieceTypeEnum.Twin && x.player != playerId);
			TileData[,] array = tiles;
			int length = array.GetLength(0);
			int length2 = array.GetLength(1);
			for (int num = 0; num < length; num++)
			{
				for (int num2 = 0; num2 < length2; num2++)
				{
					TileData tileData = array[num, num2];
					bool flag = true;
					foreach (Piece item in enumerable)
					{
						if (!flag)
						{
							break;
						}
						foreach (Movement movement in item.movements)
						{
							if (!flag)
							{
								break;
							}
							foreach (Move move in movement.moves)
							{
								if (!flag)
								{
									break;
								}
								foreach (TileData allTile in move.AllTiles)
								{
									if (tileData == allTile)
									{
										flag = false;
										break;
									}
								}
							}
						}
					}
					if (flag)
					{
						legalTilesForNextSpawn.Add(tileData);
					}
				}
			}
			return;
		}
		Player player = players[playerId];
		IEnumerable<Piece> enumerable2 = player.pieceList.Where((Piece x) => x.pieceType == PieceTypeEnum.Twin);
		if (!(ConfigFileCTG.GetSetting("SpawnTileDimming").ToLower() == "yes"))
		{
			int num3 = 0;
			{
				foreach (Twin item2 in enumerable2)
				{
					Color highlightColor = GlobalSettings.TileTints.pieceSpawnColor;
					if (num3 == 1)
					{
						highlightColor = GlobalSettings.TileTints.pieceSpawnColor2;
					}
					foreach (TileData spawnTile in item2.SpawnTiles)
					{
						legalTilesForNextSpawn.Add(spawnTile);
						if (num3 == 0)
						{
							AddCircleMarkerToTilePosition(spawnTile, highlightColor);
						}
						else
						{
							AddDotMarkerToTilePosition(spawnTile, highlightColor);
						}
					}
					num3++;
				}
				return;
			}
		}
		foreach (Twin item3 in enumerable2)
		{
			legalTilesForNextSpawn.AddRange(item3.SpawnTiles);
		}
		TileData[,] array2 = tiles;
		int length3 = array2.GetLength(0);
		int length4 = array2.GetLength(1);
		TileData tile;
		for (int num4 = 0; num4 < length3; num4++)
		{
			for (int num5 = 0; num5 < length4; num5++)
			{
				tile = array2[num4, num5];
				if (!legalTilesForNextSpawn.Any((TileData x) => x.BoardX == tile.BoardX && x.BoardY == tile.BoardY))
				{
					tile.visualComponent.SetTileHighLightColor(Color.black, 0.7f, "dimmed legal tiles");
				}
			}
		}
	}

	private void ClearLegalSpawnLocations()
	{
		if (ConfigFileCTG.GetSetting("SpawnTileDimming").ToLower() == "yes")
		{
			TileData[,] array = tiles;
			int length = array.GetLength(0);
			int length2 = array.GetLength(1);
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					TileData tileData = array[i, j];
					if (!legalTilesForNextSpawn.Contains(tileData))
					{
						tileData.visualComponent.ClearTileHighLightColor("dimmed legal tiles");
					}
				}
			}
		}
		legalTilesForNextSpawn.Clear();
		legalSpawnMarkers.ForEach(delegate(SpawnMarker x)
		{
			Object.Destroy(x.gameObject);
		});
		legalSpawnMarkers.Clear();
	}

	private void AddDotMarkerToTilePosition(TileData tile, Color highlightColor)
	{
		Vector3 position = tile.visualComponent.transform.position;
		position.y += 0.2f;
		GameObject gameObject = (GameObject)Object.Instantiate(MoveMarkerDot, position, Quaternion.identity);
		SpawnMarker spawnMarker = (SpawnMarker)gameObject.GetComponent(typeof(SpawnMarker));
		spawnMarker.Tile = tile;
		gameObject.GetComponent<Renderer>().material.color = highlightColor;
		legalSpawnMarkers.Add(spawnMarker);
	}

	private void AddCircleMarkerToTilePosition(TileData tile, Color highlightColor)
	{
		Vector3 position = tile.visualComponent.transform.position;
		position.y += 0.2f;
		GameObject gameObject = (GameObject)Object.Instantiate(MoveMarkerRing, position, Quaternion.identity);
		SpawnMarker spawnMarker = (SpawnMarker)gameObject.GetComponent(typeof(SpawnMarker));
		spawnMarker.Tile = tile;
		gameObject.GetComponent<Renderer>().material.color = highlightColor;
		legalSpawnMarkers.Add(spawnMarker);
	}

	private void HandleGameplayManagerboardObjectCommonPlacedEvent()
	{
		isWaitingOnUserInput = false;
	}

	private void HandleGameplayManagerboardObjectPiecePlacedEvent(Piece piece, TileData tile)
	{
		ClearLegalSpawnLocations();
		HandleGameplayManagerboardObjectCommonPlacedEvent();
	}

	private void HandleGameplayManagerboardObjectModifierPlacedEvent(Piece piece, TileData tile)
	{
		HandleGameplayManagerboardObjectCommonPlacedEvent();
	}

	public string GetMetaData(string name)
	{
		if (metaDataList != null)
		{
			foreach (DesignedDungeonManager.MetaData metaData in metaDataList)
			{
				if (metaData.name == name)
				{
					return metaData.value;
				}
			}
		}
		return string.Empty;
	}

	public void SetMetaData(string name, string value)
	{
		if (metaDataList == null)
		{
			metaDataList = new List<DesignedDungeonManager.MetaData>();
		}
		int count = metaDataList.Count;
		for (int i = 0; i < count; i++)
		{
			DesignedDungeonManager.MetaData metaData = metaDataList[i];
			if (metaData.name == name)
			{
				metaData.value = value;
				return;
			}
		}
		metaDataList.Add(new DesignedDungeonManager.MetaData(name, value));
	}

	public string GetMetaDataValue(string name)
	{
		if (metaDataList == null)
		{
			return string.Empty;
		}
		foreach (DesignedDungeonManager.MetaData metaData in metaDataList)
		{
			if (metaData.name == name)
			{
				return metaData.value;
			}
		}
		return string.Empty;
	}
}
