using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
	public delegate void PiecePlacedEventHandler(Piece piece, TileScript tile);

	public delegate void ModifierPlacedEventHandler(Piece piece, TileScript tile);

	public delegate void SimpleEventHandler();

	public float defaultPieceHeight = 0.3f;

	public GameObject twin;

	public GameObject queen;

	public GameObject bishop;

	public GameObject rook;

	public GameObject wall;

	public GameObject swamp;

	public GameObject modifier;

	public Piece selectedPiece;

	private List<Piece> pieceList = new List<Piece>();

	private Table gameTable;

	private Piece floatingPiece;

	private bool isPlacingPiece;

	private bool tableLoaded;

	public List<Piece> PieceList
	{
		get
		{
			return pieceList;
		}
	}

	private void Awake()
	{
		gameTable = (Table)base.gameObject.GetComponent(typeof(Table));
		if (gameTable == null)
		{
			Debug.LogError("'Table' component not found!");
		}
		else
		{
			tableLoaded = false;
		}
	}

	private void Start()
	{
		gameTable.InitEmptyBoard();
		if (!string.IsNullOrEmpty(gameTable.boardFilePath))
		{
			List<DesignedDungeonManager.MetaData> metaDataList = null;
			string xmlText;
			if (!gameTable.LoadBoard(out xmlText, ref metaDataList))
			{
				Debug.LogWarning("There was an issue loading the file specified on the table (" + gameTable.boardFilePath + ").  Starting a basic board, instead.");
			}
			else
			{
				tableLoaded = true;
				gameTable.metaDataList = metaDataList;
			}
		}
		if (!tableLoaded)
		{
			Debug.Log("Starting a new Board");
			gameTable.StartNewBoard();
		}
	}

	private void Update()
	{
		if (isPlacingPiece && Input.GetKeyDown(KeyCode.R))
		{
			TogglePieceRotation(floatingPiece);
		}
	}

	private void TogglePieceRotation(Piece piece)
	{
		piece.ToggleRotation();
	}

	private GameObject InstantiatePiece(PieceTypeEnum pieceType, Vector3 position)
	{
		GameObject original = null;
		switch (pieceType)
		{
		case PieceTypeEnum.Bishop:
			original = bishop;
			break;
		case PieceTypeEnum.Queen:
			original = queen;
			break;
		case PieceTypeEnum.Rook:
			original = rook;
			break;
		case PieceTypeEnum.Twin:
			original = twin;
			break;
		case PieceTypeEnum.Wall:
			original = wall;
			break;
		case PieceTypeEnum.Swamp:
			original = swamp;
			break;
		}
		return (GameObject)Object.Instantiate(original, position, Quaternion.identity);
	}

	private Piece SpawnPiece(PieceTypeEnum pieceType, int x, int y)
	{
		Vector3 position = gameTable.tiles[x, y].visualComponent.transform.position;
		position.y += defaultPieceHeight;
		GameObject gameObject = InstantiatePiece(pieceType, position);
		Piece piece = (Piece)gameObject.GetComponent(typeof(Piece));
		piece.pieceType = pieceType;
		piece.setPosition(position);
		piece.tile = gameTable.tiles[x, y];
		piece.InitializePiece();
		piece.Enable();
		piece.rotateToCamera();
		return piece;
	}

	private Piece SetPiece(Piece piece, int player)
	{
		piece.player = player;
		gameTable.players[player].AddPiece(piece);
		pieceList.Add(piece);
		return piece;
	}

	public void RemovePiece(Piece piece, int attackingPlayerId, PieceTypeEnum attackingPieceType)
	{
		gameTable.players[piece.player].RemovePiece(piece);
		if (pieceList.Contains(piece))
		{
			pieceList.Remove(piece);
		}
		piece.board = null;
		piece.tile = null;
		piece.player = -1;
		piece.Remove();
	}

	public TileData GetTileRelative(TileData tile, int x, int y)
	{
		return GetTile(tile.boardPosition.x + x, tile.boardPosition.y + y);
	}

	public TileData GetTile(int x, int y)
	{
		if (x < 36 && y < 28 && x >= 0 && y >= 0)
		{
			return gameTable.tiles[x, y];
		}
		return null;
	}

	public bool isLegalBoadPosition(BoardPosition boardPosition)
	{
		TileData tile = GetTile(boardPosition.x, boardPosition.y);
		return isLegalTile(tile);
	}

	public bool isLegalTile(TileData tile)
	{
		if (tile != null && tile.visualComponent.GetComponent<Renderer>().enabled)
		{
			return true;
		}
		return false;
	}

	public bool isWithinBoardGrid(BoardPosition boardPosition)
	{
		int x = boardPosition.x;
		int y = boardPosition.y;
		if (x < 36 && y < 28 && x >= 0 && y >= 0)
		{
			return true;
		}
		return false;
	}

	private void HandleMouseDownOnTileEvent(TileScript tile)
	{
	}

	public void rotatePiecesToCamera()
	{
		foreach (Piece piece in pieceList)
		{
			piece.rotateToCamera();
		}
		if (floatingPiece != null)
		{
			floatingPiece.rotateToCamera();
		}
	}
}
