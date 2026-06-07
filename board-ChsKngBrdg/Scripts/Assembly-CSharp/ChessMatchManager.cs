using System.Collections;
using System.Collections.Generic;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

public class ChessMatchManager : MonoBehaviour
{
	public enum ChessCheatReason
	{
		Null = 0,
		WrongColorMoved = 1,
		MoveOutOfBounds = 2,
		CollideWithOwnColor = 3,
		MoveNotAllowedByType = 4,
		BlockWasIgnored = 5,
		QueenHasAffair = 6,
		LandmineWasMoved = 7,
		CastleWasMoved = 8
	}

	public enum ChessColor
	{
		White = 0,
		Black = 1,
		Utility = 2
	}

	public bool doKingKillCommand;

	public int boardSizeX;

	public int boardSizeY;

	public float OOBOpacity;

	public Canvas canvas;

	public GameObject whiteFlash;

	public GameObject boardSquarePrefab;

	public Transform OOBHolder;

	public GameObject checkVisualiserPrefab;

	public GameObject numberIndicatorPrefab;

	public RuleBookScreenManager ruleBookScreenManager;

	public RulebookFogManager rulebookFogManager;

	public SpeedChessManager speedChessManager;

	public GlobalColor outlineColor;

	public GlobalColor whiteColor;

	public GlobalColor blackColor;

	public GlobalColor dangerColor;

	public GlobalColor utilityColor;

	public static bool blockMovement;

	public static int turnCount;

	public static bool colorHasWon;

	public static ChessColor currentTurnColor;

	public ChessPieceData kingPieceData;

	public List<ChessPieceObject> whitePieces = new List<ChessPieceObject>();

	public List<ChessPieceObject> blackPieces = new List<ChessPieceObject>();

	public List<ChessPieceObject> utilityPieces = new List<ChessPieceObject>();

	public bool nextPlayerWonCheat;

	public bool blackWonTime;

	public bool whiteWonCheat;

	public ChessPieceObject lastTurnMovedChessPiece;

	public ChessPieceObject lastMovedPieceByWhite;

	public List<ChessCheatReason> lastTurnCheatReasons = new List<ChessCheatReason>();

	public int whiteCheatCount;

	private SoundManager soundManager;

	public GameObject chessPiecePrefab;

	public GameObject damageNumberPrefab;

	public ChessPieceData landmineData;

	public ChessPieceData castleData;

	public List<Vector3> slipperyPositions = new List<Vector3>();

	public GameObject slipperyTilePrefab;

	public List<GameObject> slipperyTiles = new List<GameObject>();

	public int slipperyTileCount;

	private int castleCounter;

	private int ascensionCounter;

	private int missedAccusationCounter;

	private int accuseCounter;

	public bool isJuggler = true;

	public int juggleCounter;

	public int slipStreakCounter;

	private int queenRallyCounter;

	public static bool noMoveAllowed;

	public bool isEndingTurn;

	public AnimationCurve ascensionFadeCurve;

	public ParticleSystem ascensionParticles;

	public ParticleSystem ascensionGodrayParticles;

	public ParticleSystem ascensionCloudParticles;

	public ChessPieceData pawnData;

	private bool ascensionEnding;

	private DuckManager duckManager;

	private TrollDialogManager trollDialogManager;

	private bool duckEnding;

	public LocalizedString scrapsString;

	public void Awake()
	{
		SaveSystem.currentPlayerSaveData.totalAttemptCount++;
		SaveSystem.currentPlayerSaveData.overworldState = OverworldTrollManager.OverworldState.ACT_II;
		SpeedrunTimer.doCountTime = true;
		SetupChessMatch();
		rulebookFogManager = Object.FindObjectOfType<RulebookFogManager>();
		soundManager = Object.FindObjectOfType<SoundManager>();
		speedChessManager = Object.FindObjectOfType<SpeedChessManager>();
		duckManager = Object.FindObjectOfType<DuckManager>();
		trollDialogManager = Object.FindObjectOfType<TrollDialogManager>();
		turnCount = 1;
		colorHasWon = false;
		blockMovement = false;
		noMoveAllowed = false;
		currentTurnColor = ChessColor.White;
		lastTurnMovedChessPiece = whitePieces[0];
	}

	public void Update()
	{
		if (doKingKillCommand && Input.GetKeyDown(KeyCode.End))
		{
			KingKillCommand();
		}
	}

	public void SetupChessMatch()
	{
		ChessColor chessColor = ChessColor.White;
		List<Vector3> list = new List<Vector3>();
		for (float num = (float)(-boardSizeX * 3) + 0.5f; num < (float)(boardSizeX * 3) + 0.5f; num += 1f)
		{
			switch (chessColor)
			{
			case ChessColor.Black:
				chessColor = ChessColor.White;
				break;
			case ChessColor.White:
				chessColor = ChessColor.Black;
				break;
			}
			for (float num2 = (float)(-boardSizeY * 3) + 0.5f; num2 < (float)(boardSizeY * 3) + 0.5f; num2 += 1f)
			{
				Vector2 vector = new Vector2(num, num2);
				SpriteRenderer componentInChildren = Object.Instantiate(boardSquarePrefab, vector, Quaternion.identity, base.transform).GetComponentInChildren<SpriteRenderer>();
				switch (chessColor)
				{
				case ChessColor.Black:
					componentInChildren.color = blackColor.globalColor;
					chessColor = ChessColor.White;
					break;
				case ChessColor.White:
					componentInChildren.color = whiteColor.globalColor;
					chessColor = ChessColor.Black;
					break;
				}
				if (vector.y >= (float)(-boardSizeY / 2) + 0.5f && vector.y < (float)(boardSizeY / 2) + 0.5f && vector.x >= (float)(-boardSizeX / 2) + 0.5f && vector.x < (float)(boardSizeX / 2) + 0.5f)
				{
					componentInChildren.color = new Color(componentInChildren.color.r, componentInChildren.color.g, componentInChildren.color.b, 1f);
					list.Add(vector);
				}
				else
				{
					componentInChildren.color = new Color(componentInChildren.color.r, componentInChildren.color.g, componentInChildren.color.b, OOBOpacity);
					componentInChildren.transform.parent = OOBHolder;
				}
			}
		}
		SetupPieceColor(whitePieces, ChessColor.White);
		SetupPieceColor(blackPieces, ChessColor.Black);
		List<Vector3> list2 = new List<Vector3>();
		foreach (Vector3 item in list)
		{
			if (item.y >= -0.5f && item.y <= 0.5f)
			{
				list2.Add(item);
			}
		}
		for (int i = 0; i < slipperyTileCount; i++)
		{
			Vector3 vector2 = list2[Random.Range(0, list2.Count)];
			list2.Remove(vector2);
			slipperyPositions.Add(vector2);
			GameObject gameObject = Object.Instantiate(slipperyTilePrefab, vector2, Quaternion.identity);
			slipperyTiles.Add(gameObject);
			gameObject.SetActive(value: false);
		}
		OOBHolder.gameObject.SetActive(value: false);
	}

	public void SetupPieceColor(List<ChessPieceObject> pieces, ChessColor chessColor)
	{
		foreach (ChessPieceObject piece in pieces)
		{
			SpriteRenderer spriteRenderer = piece.spriteRenderer;
			switch (chessColor)
			{
			case ChessColor.White:
				piece.pieceColor = ChessColor.White;
				spriteRenderer.color = whiteColor.globalColor;
				break;
			case ChessColor.Black:
				piece.pieceColor = ChessColor.Black;
				spriteRenderer.color = blackColor.globalColor;
				if (piece.pieceData.pieceType == ChessPieceData.ChessPieceType.King)
				{
					piece.TrollIdle();
				}
				break;
			}
			if (piece.transform.position.x < 0f)
			{
				piece.spriteRenderer.flipX = true;
				piece.outlineRenderer.flipX = true;
			}
		}
	}

	public void CompleteMove(ChessPieceObject movedChessPieceObject, Vector3 originPosition, Vector3 movedPosition)
	{
		ruleBookScreenManager.StopCheatGuessAttempt();
		if (lastTurnCheatReasons.Count > 0 && !nextPlayerWonCheat && currentTurnColor == ChessColor.White)
		{
			Debug.Log("Missed accusation");
			missedAccusationCounter++;
			if (missedAccusationCounter >= 3)
			{
				SteamAchievements.UnlockAchievement("MISS_THREE_CHEATS");
			}
		}
		if (currentTurnColor == ChessColor.White)
		{
			if (movedChessPieceObject == lastMovedPieceByWhite)
			{
				isJuggler = false;
			}
			if (isJuggler)
			{
				juggleCounter++;
			}
		}
		List<ChessCheatReason> list = new List<ChessCheatReason>();
		list = CheckForCheating(movedChessPieceObject, originPosition, movedPosition);
		nextPlayerWonCheat = false;
		if (list.Count > 0 && currentTurnColor == ChessColor.White)
		{
			nextPlayerWonCheat = true;
		}
		lastTurnMovedChessPiece = movedChessPieceObject;
		lastTurnCheatReasons = list;
		if (movedChessPieceObject.CheckIfOOB(movedPosition) && currentTurnColor == ChessColor.White && movedChessPieceObject.pieceData.pieceType != ChessPieceData.ChessPieceType.Bishop && movedChessPieceObject.pieceColor == ChessColor.Black && lastTurnCheatReasons.Count < 1)
		{
			SteamAchievements.UnlockAchievement("PIECE_OUT_OF_TOWN");
		}
		List<ChessPieceObject> capturedPieces = CheckForCapture(movedChessPieceObject, movedPosition);
		StartCoroutine(EndTurn(movedChessPieceObject, capturedPieces, movedPosition, originPosition));
	}

	public List<ChessCheatReason> CheckForCheating(ChessPieceObject movedChessPieceObject, Vector3 originPosition, Vector3 movedPosition, List<ChessPieceObject> excludePiecesInSearch = null)
	{
		List<ChessCheatReason> list = new List<ChessCheatReason>();
		if (movedChessPieceObject.pieceData.pieceType != ChessPieceData.ChessPieceType.Queen && currentTurnColor != movedChessPieceObject.pieceColor)
		{
			list.Add(ChessCheatReason.WrongColorMoved);
		}
		if (movedChessPieceObject.pieceData.pieceType != ChessPieceData.ChessPieceType.Bishop)
		{
			if (movedPosition.x < (float)(-boardSizeX / 2) + 0.5f || movedPosition.x > (float)(boardSizeX / 2))
			{
				list.Add(ChessCheatReason.MoveOutOfBounds);
			}
			if (movedPosition.y < (float)(-boardSizeY / 2) + 0.5f || movedPosition.y > (float)(boardSizeY / 2))
			{
				list.Add(ChessCheatReason.MoveOutOfBounds);
			}
		}
		bool flag = false;
		List<ChessPieceObject> list2 = new List<ChessPieceObject>();
		switch (movedChessPieceObject.pieceColor)
		{
		case ChessColor.White:
			list2 = whitePieces;
			break;
		case ChessColor.Black:
			list2 = blackPieces;
			break;
		}
		foreach (ChessPieceObject item in list2)
		{
			if (!(movedChessPieceObject != item) || !(movedPosition == RoundPoint(item.transform.position)))
			{
				continue;
			}
			if (excludePiecesInSearch != null)
			{
				if (!excludePiecesInSearch.Contains(item))
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
		}
		if (flag && movedChessPieceObject.pieceData.pieceType != ChessPieceData.ChessPieceType.Rook)
		{
			list.Add(ChessCheatReason.CollideWithOwnColor);
		}
		bool flag2 = false;
		foreach (Vector3 allowedMove in movedChessPieceObject.pieceData.allowedMoves)
		{
			switch (movedChessPieceObject.pieceColor)
			{
			case ChessColor.White:
				if (movedPosition - originPosition == allowedMove)
				{
					flag2 = true;
				}
				if (movedChessPieceObject.pieceData.infiniteMoveLength && (movedPosition - originPosition).normalized == allowedMove.normalized)
				{
					flag2 = true;
				}
				break;
			case ChessColor.Black:
				if (originPosition - movedPosition == allowedMove)
				{
					flag2 = true;
				}
				if (movedChessPieceObject.pieceData.infiniteMoveLength && (originPosition - movedPosition).normalized == allowedMove.normalized)
				{
					flag2 = true;
				}
				break;
			}
		}
		if (!flag2 && movedPosition - originPosition != Vector3.zero)
		{
			list.Add(ChessCheatReason.MoveNotAllowedByType);
		}
		bool flag3 = false;
		if (!movedChessPieceObject.pieceData.jumpOverOthers)
		{
			Vector3 normalized = (movedPosition - originPosition).normalized;
			normalized = new Vector3(Mathf.Round(normalized.x), Mathf.Round(normalized.y), 0f);
			Vector3 vector = originPosition + normalized;
			int num = 0;
			List<ChessPieceObject> list3 = new List<ChessPieceObject>();
			list3.AddRange(whitePieces);
			list3.AddRange(blackPieces);
			list3.AddRange(utilityPieces);
			while (vector != movedPosition && num < 8)
			{
				foreach (ChessPieceObject item2 in list3)
				{
					if (!flag3 && item2 != movedChessPieceObject && item2.pieceData.pieceType != ChessPieceData.ChessPieceType.Landmine && RoundPoint(item2.transform.position) == vector)
					{
						flag3 = true;
						if (excludePiecesInSearch != null && excludePiecesInSearch.Contains(item2))
						{
							flag3 = false;
						}
					}
				}
				vector += normalized;
				num++;
			}
		}
		if (flag3)
		{
			list.Add(ChessCheatReason.BlockWasIgnored);
		}
		bool flag4 = false;
		if (movedChessPieceObject.pieceData.pieceType == ChessPieceData.ChessPieceType.Queen)
		{
			foreach (ChessPieceObject item3 in CheckForCapture(movedChessPieceObject, movedPosition))
			{
				if (item3.pieceData.pieceType == ChessPieceData.ChessPieceType.King)
				{
					flag4 = true;
				}
			}
		}
		if (flag4)
		{
			list.Add(ChessCheatReason.QueenHasAffair);
		}
		if (movedChessPieceObject.pieceData.pieceType == ChessPieceData.ChessPieceType.Landmine)
		{
			list.Add(ChessCheatReason.LandmineWasMoved);
		}
		if (movedChessPieceObject.pieceData.pieceType == ChessPieceData.ChessPieceType.Castle)
		{
			list.Add(ChessCheatReason.CastleWasMoved);
		}
		if (list.Count > 0 && currentTurnColor == ChessColor.White)
		{
			whiteCheatCount++;
			SaveSystem.currentPlayerSaveData.totalCheatCount++;
			Debug.Log("cheat++");
		}
		if (nextPlayerWonCheat)
		{
			list.Clear();
			return list;
		}
		return list;
	}

	public List<ChessPieceObject> CheckForCapture(ChessPieceObject movedChessPieceObject, Vector3 movedPosition)
	{
		List<ChessPieceObject> list = new List<ChessPieceObject>();
		List<ChessPieceObject> list2 = new List<ChessPieceObject>();
		switch (movedChessPieceObject.pieceColor)
		{
		case ChessColor.White:
			list.AddRange(blackPieces.ToArray());
			if (movedChessPieceObject.pieceData.pieceType == ChessPieceData.ChessPieceType.Rook)
			{
				list.AddRange(whitePieces.ToArray());
				list.Remove(movedChessPieceObject);
			}
			break;
		case ChessColor.Black:
			list.AddRange(whitePieces.ToArray());
			if (movedChessPieceObject.pieceData.pieceType == ChessPieceData.ChessPieceType.Rook)
			{
				list.AddRange(blackPieces.ToArray());
				list.Remove(movedChessPieceObject);
			}
			break;
		case ChessColor.Utility:
			list.AddRange(blackPieces.ToArray());
			list.AddRange(whitePieces.ToArray());
			break;
		}
		foreach (ChessPieceObject item in list)
		{
			if (movedPosition == RoundPoint(item.transform.position))
			{
				list2.Add(item);
			}
		}
		foreach (ChessPieceObject utilityPiece in utilityPieces)
		{
			if (movedPosition == RoundPoint(utilityPiece.transform.position))
			{
				list2.Add(utilityPiece);
			}
		}
		list2.Remove(movedChessPieceObject);
		return list2;
	}

	public bool CheckIfPlayerGuessedCheat(ChessPieceObject chessPiece, RuleBookPage ruleBookPage)
	{
		bool flag = true;
		Debug.Log("Player accuses " + chessPiece.pieceColor.ToString() + " " + chessPiece.pieceData.pieceType.ToString() + " of cheating. (" + ruleBookPage.ruleCheatReason.ToString() + ")");
		if (chessPiece != lastTurnMovedChessPiece && !lastTurnCheatReasons.Contains(ChessCheatReason.CollideWithOwnColor))
		{
			flag = false;
		}
		if (!lastTurnCheatReasons.Contains(ruleBookPage.ruleCheatReason))
		{
			flag = false;
		}
		if (ruleBookPage.checkForSpecificPiece && chessPiece.pieceData.pieceType != ruleBookPage.ruleSpecificPiece)
		{
			flag = false;
		}
		nextPlayerWonCheat = true;
		lastTurnCheatReasons.Clear();
		if (!flag)
		{
			currentTurnColor = ChessColor.Black;
			return false;
		}
		whiteWonCheat = true;
		accuseCounter++;
		if (rulebookFogManager.CheckIfPageIsFogged(ruleBookPage))
		{
			SteamAchievements.UnlockAchievement("ACCUSE_WITHOUT_DEFOG");
		}
		if (accuseCounter == 1)
		{
			SteamAchievements.UnlockAchievement("ACCUSE_TROLL_SUCCESS");
		}
		SteamUserStats.AddStat("AccuseCounter", 1);
		SteamUserStats.StoreStats();
		return true;
	}

	public List<ChessPieceObject> GetPiecesByColorAndType(ChessColor chessColor, ChessPieceData.ChessPieceType chessPieceType, bool getBothColors = false)
	{
		List<ChessPieceObject> list = new List<ChessPieceObject>();
		if (chessColor == ChessColor.White || getBothColors)
		{
			foreach (ChessPieceObject whitePiece in whitePieces)
			{
				if (whitePiece.pieceData.pieceType == chessPieceType)
				{
					list.Add(whitePiece);
				}
			}
		}
		if (chessColor == ChessColor.Black || getBothColors)
		{
			foreach (ChessPieceObject blackPiece in blackPieces)
			{
				if (blackPiece.pieceData.pieceType == chessPieceType)
				{
					list.Add(blackPiece);
				}
			}
		}
		if (chessColor == ChessColor.Utility)
		{
			foreach (ChessPieceObject utilityPiece in utilityPieces)
			{
				if (utilityPiece.pieceData.pieceType == chessPieceType)
				{
					list.Add(utilityPiece);
				}
			}
		}
		return list;
	}

	private IEnumerator EndTurn(ChessPieceObject movedChessPiece, List<ChessPieceObject> capturedPieces, Vector3 movedPosition, Vector3 originPosition)
	{
		isEndingTurn = true;
		bool whiteKingKilled = false;
		bool blackKingKilled = false;
		movedChessPiece.UpdateSortOrder();
		bool stopSleeping = false;
		if (movedChessPiece.isSleeping)
		{
			movedChessPiece.isSleeping = false;
			stopSleeping = true;
			StartCoroutine(movedChessPiece.StopSleeping());
			yield return new WaitForSeconds(1f);
		}
		if (!stopSleeping)
		{
			if (movedChessPiece.pieceData.pieceType == ChessPieceData.ChessPieceType.Queen && movedChessPiece.pieceColor == ChessColor.Black)
			{
				queenRallyCounter++;
				if (queenRallyCounter >= 12)
				{
					SteamAchievements.UnlockAchievement("RALLY_QUEEN");
				}
			}
			else
			{
				queenRallyCounter = 0;
			}
			if (whitePieces.Count + blackPieces.Count == 2)
			{
				SteamAchievements.UnlockAchievement("SHOWDOWN_KINGS");
			}
			bool flag = false;
			if (movedChessPiece.pieceData.pieceType == ChessPieceData.ChessPieceType.Rook)
			{
				foreach (ChessPieceObject capturedPiece2 in capturedPieces)
				{
					if (capturedPiece2.pieceColor == movedChessPiece.pieceColor)
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				SpawnDamageNumber("X2", movedChessPiece.transform, new Vector3(0f, 1f * movedChessPiece.transform.localScale.y, 0f));
				movedChessPiece.transform.localScale *= 1.05f;
				SoundManager.LoadSoundEffect(movedChessPiece.transform, soundManager.chess_piece_rook_eat);
				movedChessPiece.rookEatScore++;
				if (movedChessPiece.rookEatScore >= 10)
				{
					SteamAchievements.UnlockAchievement("EAT_TEN_WHITE_PIECES");
				}
			}
			List<ChessPieceObject> landmineCaptures = new List<ChessPieceObject>();
			ChessPieceObject landmine = null;
			if (movedChessPiece.pieceData.pieceType == ChessPieceData.ChessPieceType.Bishop && movedPosition - originPosition != Vector3.zero)
			{
				ChessPieceObject chessPieceObject = SpawnUtility(originPosition, landmineData, ChessColor.Utility);
				SoundManager.LoadSoundEffect(movedChessPiece.spriteRenderer.transform, soundManager.chess_piece_landmine_spawn);
				landmineCaptures.AddRange(CheckForCapture(chessPieceObject, originPosition));
				if (landmineCaptures.Count > 0)
				{
					landmine = chessPieceObject;
				}
				landmineCaptures.Remove(landmine);
				if (GetPiecesByColorAndType(ChessColor.Utility, ChessPieceData.ChessPieceType.Landmine).Count >= 16)
				{
					SteamAchievements.UnlockAchievement("LEAVE_MANY_LANDMINES");
				}
			}
			if (landmine == null)
			{
				foreach (ChessPieceObject capturedPiece3 in capturedPieces)
				{
					if (capturedPiece3.pieceData.pieceType != ChessPieceData.ChessPieceType.Landmine && movedChessPiece.pieceData.pieceType != ChessPieceData.ChessPieceType.Landmine)
					{
						continue;
					}
					if (capturedPiece3.pieceData.pieceType == ChessPieceData.ChessPieceType.Landmine)
					{
						landmineCaptures.Add(movedChessPiece);
						landmine = capturedPiece3;
						continue;
					}
					landmine = movedChessPiece;
					if (capturedPiece3.pieceData.pieceType != ChessPieceData.ChessPieceType.King)
					{
						landmineCaptures.Add(capturedPiece3);
					}
				}
			}
			bool altruistAchievement = false;
			bool slayQueenAchievement = false;
			if (landmine != null)
			{
				foreach (ChessPieceObject item2 in landmineCaptures)
				{
					if (item2 != landmine && item2.pieceData.pieceType != ChessPieceData.ChessPieceType.King)
					{
						item2.spriteRenderer.color = new Color(0f, 0f, 0f, 0f);
						item2.outlineRenderer.color = new Color(0f, 0f, 0f, 0f);
					}
				}
				landmine.spriteRenderer.sortingLayerName = "UI";
				landmine.spriteRenderer.sortingOrder = 1000;
				landmine.LandmineExplodion();
				SoundManager.LoadSoundEffect(landmine.transform, soundManager.chess_piece_landmine_explode);
				StartCoroutine(Camera.main.GetComponent<ObjectShake>().Shake(0.15f, 0.25f));
				yield return new WaitForSeconds(landmine.landmineExplosionClip.length);
				capturedPieces.AddRange(landmineCaptures);
				capturedPieces.Add(landmine);
				Debug.Log("landmine: " + landmine.name);
				foreach (ChessPieceObject item3 in landmineCaptures)
				{
					Debug.Log("captures: " + item3.name);
					if (lastTurnCheatReasons.Count < 1 && currentTurnColor == ChessColor.White && item3.pieceColor == ChessColor.Black)
					{
						altruistAchievement = true;
					}
					if (lastTurnCheatReasons.Count < 1 && item3.pieceData.pieceType == ChessPieceData.ChessPieceType.Queen && currentTurnColor == ChessColor.White && item3.pieceColor == ChessColor.Black)
					{
						slayQueenAchievement = true;
					}
				}
				if (altruistAchievement)
				{
					SteamAchievements.UnlockAchievement("CAPTURE_BY_LANDMINE");
				}
				if (slayQueenAchievement)
				{
					SteamAchievements.UnlockAchievement("CAPTURE_QUEEN_BY_LANDMINE");
				}
			}
			foreach (ChessPieceObject capturedPiece in capturedPieces)
			{
				if (capturedPiece.pieceData.pieceType == ChessPieceData.ChessPieceType.King)
				{
					if (capturedPiece.pieceColor == ChessColor.White)
					{
						whiteKingKilled = true;
					}
					if (capturedPiece.pieceColor == ChessColor.Black)
					{
						blackKingKilled = true;
					}
					if (whiteKingKilled || blackKingKilled)
					{
						capturedPiece.outlineRenderer.sortingOrder = 10001;
						capturedPiece.outlineRenderer.sortingLayerName = "UI";
						capturedPiece.spriteRenderer.sortingOrder = 10000;
						capturedPiece.spriteRenderer.sortingLayerName = "UI";
						canvas.gameObject.SetActive(value: false);
						whiteFlash.SetActive(value: true);
						if (whiteKingKilled)
						{
							whiteFlash.GetComponent<SpriteRenderer>().color = outlineColor.globalColor;
						}
						if (blackKingKilled)
						{
							whiteFlash.GetComponent<SpriteRenderer>().color = whiteColor.globalColor;
							capturedPiece.animator.enabled = false;
							capturedPiece.fillAnimator.enabled = false;
							if (movedChessPiece.pieceData.pieceType == ChessPieceData.ChessPieceType.Queen && lastTurnCheatReasons.Count < 1)
							{
								SteamAchievements.UnlockAchievement("CAPTURE_KING_WITH_QUEEN");
							}
						}
						SoundManager.LoadSoundEffect(base.transform, soundManager.titel_impact);
						StartCoroutine(Camera.main.GetComponent<ObjectShake>().Shake(0.5f, 0.05f));
						yield return new WaitForSeconds(1f);
						if (blackKingKilled && blackPieces.Count == 1)
						{
							WhiteWin(capturedPiece.animator.transform.position);
							yield return new WaitForSeconds(float.PositiveInfinity);
						}
						SoundManager.LoadSoundEffect(capturedPiece.transform, soundManager.chess_piece_capture);
						capturedPiece.animator.enabled = true;
						capturedPiece.KingShatter();
						whiteFlash.SetActive(value: false);
						capturedPiece.spriteRenderer.gameObject.SetActive(value: false);
						canvas.gameObject.SetActive(value: true);
						yield return new WaitForSeconds(1f);
						capturedPiece.UpdateSortOrder();
						capturedPiece.outlineRenderer.sortingLayerName = "Outline";
					}
				}
				else
				{
					StartCoroutine(Camera.main.GetComponent<ObjectShake>().Shake(0.15f, 0.05f));
					SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_capture);
				}
				whitePieces.Remove(capturedPiece);
				blackPieces.Remove(capturedPiece);
				capturedPiece.transform.position = new Vector3(0f, 20f, 0f);
			}
			if (whitePieces.Count < 1 || whiteKingKilled)
			{
				colorHasWon = true;
				currentTurnColor = ChessColor.Black;
			}
			if (blackKingKilled)
			{
				if (blackPieces.Count < 1)
				{
					colorHasWon = true;
					currentTurnColor = ChessColor.White;
					WhiteWin(Vector3.zero);
					yield return new WaitForSeconds(float.PositiveInfinity);
				}
				else
				{
					yield return new WaitForSeconds(1f);
					ChessPieceObject capturedPiece = blackPieces[Random.Range(0, blackPieces.Count)];
					capturedPiece.pieceData = kingPieceData;
					capturedPiece.spriteRenderer.sprite = capturedPiece.pieceData.pieceFillSprite;
					capturedPiece.outlineRenderer.sprite = capturedPiece.pieceData.pieceOutlineSprite;
					capturedPiece.TrollIdle();
					for (int i = 0; i < 4; i++)
					{
						SoundManager.LoadSoundEffect(movedChessPiece.transform, soundManager.chess_piece_king_respawn);
						capturedPiece.spriteRenderer.color = new Color(capturedPiece.spriteRenderer.color.r, capturedPiece.spriteRenderer.color.g, capturedPiece.spriteRenderer.color.b, 0.25f);
						capturedPiece.outlineRenderer.color = new Color(capturedPiece.outlineRenderer.color.r, capturedPiece.outlineRenderer.color.g, capturedPiece.outlineRenderer.color.b, 0.25f);
						yield return new WaitForSeconds(0.25f);
						capturedPiece.spriteRenderer.color = new Color(capturedPiece.spriteRenderer.color.r, capturedPiece.spriteRenderer.color.g, capturedPiece.spriteRenderer.color.b, 1f);
						capturedPiece.outlineRenderer.color = new Color(capturedPiece.outlineRenderer.color.r, capturedPiece.outlineRenderer.color.g, capturedPiece.outlineRenderer.color.b, 1f);
						yield return new WaitForSeconds(0.25f);
					}
				}
			}
			bool doSLip = false;
			foreach (GameObject slipperyTile in slipperyTiles)
			{
				if (slipperyTile.transform.position == RoundPoint(movedPosition))
				{
					if (!slipperyTile.gameObject.activeSelf)
					{
						slipperyTile.SetActive(value: true);
					}
					doSLip = true;
				}
			}
			if (doSLip)
			{
				movedChessPiece.isSleeping = true;
				movedChessPiece.sleepturn = turnCount;
				StartCoroutine(movedChessPiece.SlipOnFloor(movedChessPiece.spriteRenderer.transform.parent.transform));
				yield return new WaitForSeconds(1f);
			}
			if (currentTurnColor == ChessColor.White && movedChessPiece.pieceColor == ChessColor.White)
			{
				if (doSLip)
				{
					slipStreakCounter++;
					if (slipStreakCounter >= 3)
					{
						SteamAchievements.UnlockAchievement("SLIP_THREE_WHITE_PIECES");
					}
				}
				else
				{
					slipStreakCounter = 0;
				}
			}
			if (movedChessPiece.pieceData.pieceType == ChessPieceData.ChessPieceType.Queen && capturedPieces.Count > 0)
			{
				List<ChessPieceObject> list = new List<ChessPieceObject>();
				list.AddRange(whitePieces);
				list.AddRange(blackPieces);
				list.AddRange(utilityPieces);
				foreach (ChessPieceObject item4 in list)
				{
					item4.transform.position = new Vector3(0f - item4.transform.position.x, item4.transform.position.y, item4.transform.position.z);
					StartCoroutine(item4.objectShake.Shake(0.15f, 0.05f));
				}
				foreach (GameObject slipperyTile2 in slipperyTiles)
				{
					slipperyTile2.transform.position = new Vector3(0f - slipperyTile2.transform.position.x, slipperyTile2.transform.position.y, slipperyTile2.transform.position.z);
				}
				SoundManager.LoadSoundEffect(movedChessPiece.transform, soundManager.chess_piece_queen_worldflip);
				yield return new WaitForSeconds(1.5f);
			}
			List<ChessPieceObject> castlePieces = new List<ChessPieceObject>();
			Vector3 roundedRookPosition = RoundPoint(movedChessPiece.transform.position);
			float largestCastleScale = 1f;
			if (movedChessPiece.pieceData.pieceType == ChessPieceData.ChessPieceType.Rook)
			{
				largestCastleScale = movedChessPiece.transform.localScale.y;
				List<ChessPieceObject> piecesByColorAndType = GetPiecesByColorAndType(ChessColor.White, ChessPieceData.ChessPieceType.Rook, getBothColors: true);
				piecesByColorAndType.Remove(movedChessPiece);
				foreach (ChessPieceObject item5 in piecesByColorAndType)
				{
					Vector3 b = RoundPoint(item5.transform.position);
					if (Vector3.Distance(roundedRookPosition, b) <= 1f)
					{
						if (item5.transform.localScale.y > largestCastleScale)
						{
							largestCastleScale = item5.transform.localScale.y;
						}
						item5.objectShake.StopAllCoroutines();
						item5.objectShake.isShaking = false;
						StartCoroutine(item5.objectShake.Shake(1f, 0.075f));
						castlePieces.Add(item5);
					}
				}
			}
			if (castlePieces.Count > 0)
			{
				movedChessPiece.objectShake.StopAllCoroutines();
				movedChessPiece.objectShake.isShaking = false;
				StartCoroutine(movedChessPiece.objectShake.Shake(1f, 0.075f));
				yield return new WaitForSeconds(1.5f);
				castlePieces.Add(movedChessPiece);
				foreach (ChessPieceObject item6 in castlePieces)
				{
					whitePieces.Remove(item6);
					blackPieces.Remove(item6);
					item6.transform.position = new Vector3(0f, 20f, 0f);
				}
				ChessPieceObject chessPieceObject2 = SpawnUtility(roundedRookPosition, castleData, ChessColor.Utility);
				StartCoroutine(chessPieceObject2.objectShake.Shake(0.15f, 0.075f));
				chessPieceObject2.transform.localScale *= largestCastleScale;
				lastTurnMovedChessPiece = chessPieceObject2;
				SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_castle_merge);
				castleCounter++;
				if (castleCounter >= 2)
				{
					SteamAchievements.UnlockAchievement("CREATE_TWO_CASTLES");
				}
				capturedPieces.AddRange(castlePieces);
			}
			if (movedChessPiece.pieceData.pieceType == ChessPieceData.ChessPieceType.Pawn)
			{
				bool flag2 = false;
				switch (movedChessPiece.pieceColor)
				{
				case ChessColor.White:
					if ((double)RoundPoint(movedChessPiece.transform.position).y >= 3.5)
					{
						flag2 = true;
					}
					break;
				case ChessColor.Black:
					if ((double)RoundPoint(movedChessPiece.transform.position).y <= -3.5)
					{
						flag2 = true;
					}
					break;
				}
				if (flag2)
				{
					whitePieces.Remove(movedChessPiece);
					blackPieces.Remove(movedChessPiece);
					capturedPieces.Add(movedChessPiece);
					StartCoroutine(movedChessPiece.Ascension());
					ascensionCounter++;
					if (ascensionCounter >= 2)
					{
						SteamAchievements.UnlockAchievement("ASCEND_TWO_PAWNS");
					}
					if (ascensionCounter >= 8)
					{
						yield return new WaitForSeconds(1f);
						ObjectShake cameraShake = Camera.main.GetComponent<ObjectShake>();
						cameraShake.StartCoroutine(cameraShake.Shake(float.PositiveInfinity, 0.025f));
						canvas.gameObject.SetActive(value: false);
						SpriteRenderer whiteFlashRenderer = whiteFlash.GetComponent<SpriteRenderer>();
						whiteFlashRenderer.color = whiteColor.globalColor;
						whiteFlashRenderer.color = new Color(whiteFlashRenderer.color.r, whiteFlashRenderer.color.g, whiteFlashRenderer.color.b, 0f);
						whiteFlash.SetActive(value: true);
						SoundManager.LoadSoundEffect(base.transform, soundManager.ascension_rise);
						float elaspedFadeSeconds = 0f;
						while (elaspedFadeSeconds < ascensionFadeCurve[ascensionFadeCurve.length - 1].time)
						{
							whiteFlashRenderer.color = new Color(whiteFlashRenderer.color.r, whiteFlashRenderer.color.g, whiteFlashRenderer.color.b, ascensionFadeCurve.Evaluate(elaspedFadeSeconds));
							elaspedFadeSeconds += Time.deltaTime;
							yield return null;
						}
						whiteFlashRenderer.color = whiteColor.globalColor;
						ascensionParticles.Play();
						ascensionGodrayParticles.Play();
						ascensionCloudParticles.Play();
						yield return new WaitForSeconds(1f);
						SoundManager.LoadSoundEffect(base.transform, soundManager.ascension_fall);
						SoundManager.LoadSoundEffect(ascensionParticles.transform, soundManager.ascension_rumble);
						while (elaspedFadeSeconds > 0f)
						{
							whiteFlashRenderer.color = new Color(whiteFlashRenderer.color.r, whiteFlashRenderer.color.g, whiteFlashRenderer.color.b, ascensionFadeCurve.Evaluate(elaspedFadeSeconds));
							elaspedFadeSeconds -= Time.deltaTime;
							yield return null;
						}
						whiteFlash.SetActive(value: false);
						whiteFlashRenderer.color = whiteColor.globalColor;
						List<Vector2> list2 = new List<Vector2>();
						List<ChessPieceObject> list3 = new List<ChessPieceObject>();
						list3.AddRange(whitePieces);
						list3.AddRange(blackPieces);
						list3.AddRange(utilityPieces);
						foreach (ChessPieceObject item7 in list3)
						{
							list2.Add(RoundPoint(item7.transform.position));
						}
						List<Vector2> spawnPositions = new List<Vector2>();
						for (float num = (float)(-boardSizeX) + 0.5f; num < (float)boardSizeX + 0.5f; num += 1f)
						{
							for (float num2 = (float)(-boardSizeY / 2) + 0.5f - 2f; num2 < (float)(boardSizeY / 2) + 0.5f + 2f; num2 += 1f)
							{
								Vector2 item = new Vector2(num, num2);
								if (!list2.Contains(item))
								{
									spawnPositions.Add(item);
								}
							}
						}
						List<ChessPieceObject> ascensionPieces = new List<ChessPieceObject>();
						int i = Mathf.Clamp(spawnPositions.Count, 0, 64);
						float spawnDelayTime = 1f;
						float spawnDelayDecreaseFactor = 1.05f;
						for (int j = 0; j < i; j++)
						{
							Vector2 vector = spawnPositions[Random.Range(0, spawnPositions.Count)];
							spawnPositions.Remove(vector);
							ChessPieceObject chessPieceObject3 = SpawnChessPiece(vector + new Vector2(0f, 20f), pawnData, ChessColor.White);
							chessPieceObject3.ascensionEndingSortOrder = j * 2;
							chessPieceObject3.StartCoroutine(chessPieceObject3.AscensionEndingEntrance());
							ascensionPieces.Add(chessPieceObject3);
							yield return new WaitForSeconds(spawnDelayTime);
							spawnDelayTime /= spawnDelayDecreaseFactor;
						}
						cameraShake.StopAllCoroutines();
						cameraShake.isShaking = false;
						ascensionParticles.gameObject.GetComponent<AudioSource>().Stop();
						yield return new WaitForSeconds(2f);
						ChessPieceObject capturedPiece = GetPiecesByColorAndType(ChessColor.Black, ChessPieceData.ChessPieceType.King)[0];
						spawnDelayTime = 0.5f;
						spawnDelayDecreaseFactor = 1.033f;
						float shakeAmount = 0.1f;
						float shakeIncreaseAmount = 0.4f / (float)i;
						foreach (ChessPieceObject ascensionPiece in ascensionPieces)
						{
							yield return new WaitForSeconds(spawnDelayTime);
							spawnDelayTime /= spawnDelayDecreaseFactor;
							ascensionPiece.StartCoroutine(ascensionPiece.AscensionEndingCapture(capturedPiece, shakeAmount));
							shakeAmount += shakeIncreaseAmount;
						}
						yield return new WaitForSeconds(0.5f);
						capturedPiece.outlineRenderer.sortingOrder = 12001;
						capturedPiece.outlineRenderer.sortingLayerName = "UI";
						capturedPiece.spriteRenderer.sortingOrder = 12000;
						capturedPiece.spriteRenderer.sortingLayerName = "UI";
						whiteFlash.SetActive(value: true);
						capturedPiece.fillAnimator.enabled = false;
						capturedPiece.animator.enabled = false;
						capturedPiece.StartCoroutine(capturedPiece.objectShake.Shake(0.125f, 0.5f));
						SoundManager.LoadSoundEffect(base.transform, soundManager.titel_impact);
						StartCoroutine(Camera.main.GetComponent<ObjectShake>().Shake(float.PositiveInfinity, shakeAmount / 1.25f));
						yield return new WaitForSeconds(3f);
						whiteFlash.SetActive(value: false);
						capturedPiece.spriteRenderer.enabled = false;
						capturedPiece.animator.enabled = true;
						capturedPiece.KingShatter();
						SoundManager.LoadSoundEffect(capturedPiece.transform, soundManager.chess_piece_capture);
						SoundManager.LoadSoundEffect(base.transform, soundManager.ascension_troll_kill);
						whiteFlashRenderer.color = whiteColor.globalColor;
						whiteFlashRenderer.color = new Color(whiteFlashRenderer.color.r, whiteFlashRenderer.color.g, whiteFlashRenderer.color.b, 0f);
						whiteFlash.SetActive(value: true);
						SoundManager.LoadSoundEffect(base.transform, soundManager.ascension_rise);
						elaspedFadeSeconds = 0f;
						while (elaspedFadeSeconds < ascensionFadeCurve[ascensionFadeCurve.length - 1].time)
						{
							whiteFlashRenderer.color = new Color(whiteFlashRenderer.color.r, whiteFlashRenderer.color.g, whiteFlashRenderer.color.b, ascensionFadeCurve.Evaluate(elaspedFadeSeconds));
							elaspedFadeSeconds += Time.deltaTime;
							yield return null;
						}
						whiteFlashRenderer.color = whiteColor.globalColor;
						ascensionEnding = true;
						WhiteWin(capturedPiece.transform.position);
					}
				}
			}
			if (duckManager.duckState != DuckManager.DuckState.HeldByPlayer && duckManager.duckState != DuckManager.DuckState.Inactive && !duckManager.holdingPiece && currentTurnColor == ChessColor.White && Vector3.Distance(movedChessPiece.transform.position, duckManager.transform.position) < 0.8f)
			{
				duckManager.holdingPiece = true;
				duckManager.heldPiece = movedChessPiece;
				movedChessPiece.transform.SetParent(duckManager.pieceHolder.transform);
				movedChessPiece.transform.localPosition = Vector3.zero;
				if (duckManager.duckState == DuckManager.DuckState.Swimming)
				{
					movedChessPiece.spriteRenderer.sortingLayerName = "Background";
					movedChessPiece.outlineRenderer.sortingLayerName = "Background";
				}
				else
				{
					movedChessPiece.spriteRenderer.sortingLayerName = "Fill";
					movedChessPiece.outlineRenderer.sortingLayerName = "Fill";
				}
				movedChessPiece.spriteRenderer.sortingOrder = duckManager.spriteRenderer.sortingOrder - 2;
				movedChessPiece.outlineRenderer.sortingOrder = duckManager.spriteRenderer.sortingOrder - 1;
				movedChessPiece.isDuckBound = true;
				SoundManager.LoadSoundEffect(base.transform, soundManager.duck_honk);
				SoundManager.LoadSoundEffect(duckManager.transform, soundManager.duck_flap);
				yield return new WaitForSeconds(3f);
				if (movedChessPiece.pieceData.pieceType == ChessPieceData.ChessPieceType.King && movedChessPiece.pieceColor == ChessColor.Black)
				{
					duckEnding = true;
					trollDialogManager.StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.duckBoundTrollTopics[0], 1f));
					while (TrollDialogManager.isInDialog)
					{
						yield return null;
					}
					yield return new WaitForSeconds(1f);
					trollDialogManager.StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.duckBoundTrollTopics[1], 0.5f));
					while (TrollDialogManager.isInDialog)
					{
						yield return null;
					}
					yield return new WaitForSeconds(1f);
					float num3 = Object.FindObjectOfType<TransitionManager>().StartTransition(TransitionManager.TransitionState.Out);
					yield return new WaitForSeconds(num3 / 1.5f);
					trollDialogManager.StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.duckBoundTrollTopics[2], 0.25f));
					while (TrollDialogManager.isInDialog)
					{
						yield return null;
					}
					yield return new WaitForSeconds(0.25f);
					trollDialogManager.StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.duckBoundTrollTopics[3], 0f));
					while (TrollDialogManager.isInDialog)
					{
						yield return null;
					}
					canvas.gameObject.SetActive(value: false);
					yield return new WaitForSeconds(2f);
					ChessPieceObject chessPieceObject4 = GetPiecesByColorAndType(ChessColor.Black, ChessPieceData.ChessPieceType.King)[0];
					WhiteWin(chessPieceObject4.transform.position);
				}
				else
				{
					blackPieces.Remove(movedChessPiece);
					if (currentTurnColor == ChessColor.White)
					{
						trollDialogManager.StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.GetRandomTopic(trollDialogManager.duckBoundWhiteTopics), 1f));
					}
					else
					{
						trollDialogManager.StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.GetRandomTopic(trollDialogManager.duckBoundBlackTopics), 1f));
					}
					while (TrollDialogManager.isInDialog)
					{
						yield return null;
					}
					yield return new WaitForSeconds(1f);
				}
			}
			bool flag3 = false;
			switch (currentTurnColor)
			{
			case ChessColor.White:
				lastMovedPieceByWhite = movedChessPiece;
				break;
			case ChessColor.Black:
				if (!colorHasWon)
				{
					flag3 = true;
				}
				break;
			}
			if (flag3)
			{
				rulebookFogManager.ProgressFogClearing(lastMovedPieceByWhite.pieceData.pieceType);
				while (rulebookFogManager.isProgressingFog)
				{
					yield return null;
				}
			}
			if (capturedPieces.Count >= 2 && lastTurnCheatReasons.Count < 1)
			{
				int num4 = 0;
				foreach (ChessPieceObject capturedPiece4 in capturedPieces)
				{
					if (capturedPiece4.pieceColor == ChessColor.Black)
					{
						num4++;
					}
				}
				if (num4 >= 2)
				{
					SteamAchievements.UnlockAchievement("CAPTURE_TWO");
				}
				if (num4 >= 3)
				{
					SteamAchievements.UnlockAchievement("CAPTURE_THREE");
				}
			}
		}
		SaveSystem.SavePlayerSaveData(SaveSystem.currentPlayerSaveData);
		movedChessPiece.UpdateSortOrder();
		if (!colorHasWon)
		{
			switch (currentTurnColor)
			{
			case ChessColor.White:
				currentTurnColor = ChessColor.Black;
				if (SpeedChessManager.doSpeedChess)
				{
					speedChessManager.FlipToBlack();
				}
				break;
			case ChessColor.Black:
				blockMovement = false;
				currentTurnColor = ChessColor.White;
				if (SpeedChessManager.doSpeedChess)
				{
					speedChessManager.FlipToWhite();
				}
				break;
			}
			turnCount++;
		}
		isEndingTurn = false;
	}

	public static Vector3 RoundPoint(Vector3 point)
	{
		return new Vector3(Mathf.Round(point.x + 0.5f) - 0.5f, Mathf.Round(point.y + 0.5f) - 0.5f, 0f);
	}

	public void WhiteWin(Vector3 kingPosition)
	{
		if (SpeedChessManager.doSpeedChess)
		{
			SteamAchievements.UnlockAchievement("WIN_SPEED_CHESS_ONE");
			if (SpeedChessManager.speedChessTime <= 180f)
			{
				SteamAchievements.UnlockAchievement("WIN_SPEED_CHESS_TWO");
			}
			if (SpeedChessManager.speedChessTime <= 60f)
			{
				SteamAchievements.UnlockAchievement("WIN_SPEED_CHESS_THREE");
			}
		}
		if (!duckEnding)
		{
			if (whitePieces.Count >= 10)
			{
				SteamAchievements.UnlockAchievement("WIN_BY_OVERKILL");
			}
			if (isJuggler)
			{
				SteamAchievements.UnlockAchievement("WIN_MATCH_BY_JUGGLING");
			}
		}
		if (ascensionEnding)
		{
			SaveSystem.currentPlayerSaveData.ending = OverworldTrollManager.Ending.AscensionEnding;
		}
		else if (duckEnding)
		{
			SaveSystem.currentPlayerSaveData.ending = OverworldTrollManager.Ending.DuckEnding;
		}
		else if (whiteCheatCount < 1)
		{
			SaveSystem.currentPlayerSaveData.ending = OverworldTrollManager.Ending.GoodEnding;
		}
		else
		{
			SaveSystem.currentPlayerSaveData.ending = OverworldTrollManager.Ending.BadEnding;
		}
		OverworldTrollManager.trollCapturePosition = kingPosition;
		SaveSystem.currentPlayerSaveData.overworldState = OverworldTrollManager.OverworldState.ACT_III;
		SaveSystem.SavePlayerSaveData(SaveSystem.currentPlayerSaveData);
		SceneManager.LoadScene("Overworld");
	}

	public IEnumerator CheckVisualiser(Vector3 position, Color color, float duration, Sprite sprite)
	{
		GameObject prefab = Object.Instantiate(checkVisualiserPrefab, position, Quaternion.identity);
		SpriteRenderer component = prefab.GetComponent<SpriteRenderer>();
		component.color = color;
		component.sprite = sprite;
		yield return new WaitForSeconds(duration);
		Object.Destroy(prefab);
	}

	public IEnumerator NumberIndicator(Vector3 position, float number, float duration)
	{
		Vector2 vector = Camera.main.WorldToScreenPoint(position);
		GameObject prefab = Object.Instantiate(numberIndicatorPrefab, vector, Quaternion.identity, canvas.transform);
		TMP_Text component = prefab.GetComponent<TMP_Text>();
		component.text = number.ToString("N0");
		float r = Random.Range(0f, 1f);
		float g = Random.Range(0f, 1f);
		float b = Random.Range(0f, 1f);
		component.color = new Color(r, g, b);
		yield return new WaitForSeconds(duration);
		Object.Destroy(prefab);
	}

	public ChessPieceObject SpawnUtility(Vector3 position, ChessPieceData data, ChessColor color)
	{
		ChessPieceObject component = Object.Instantiate(chessPiecePrefab, position, Quaternion.identity).GetComponent<ChessPieceObject>();
		component.pieceData = data;
		component.pieceColor = color;
		switch (color)
		{
		case ChessColor.White:
			component.spriteRenderer.color = whiteColor.globalColor;
			break;
		case ChessColor.Black:
			component.spriteRenderer.color = blackColor.globalColor;
			break;
		case ChessColor.Utility:
			component.spriteRenderer.color = utilityColor.globalColor;
			break;
		}
		if (data.pieceType == ChessPieceData.ChessPieceType.Landmine)
		{
			component.GetComponentInChildren<SineMovement>().enabled = false;
		}
		component.spriteRenderer.sprite = data.pieceFillSprite;
		component.outlineRenderer.sprite = data.pieceOutlineSprite;
		component.outlineRenderer.color = blackColor.globalColor;
		utilityPieces.Add(component);
		return component;
	}

	public ChessPieceObject SpawnChessPiece(Vector3 position, ChessPieceData data, ChessColor color)
	{
		ChessPieceObject component = Object.Instantiate(chessPiecePrefab, position, Quaternion.identity).GetComponent<ChessPieceObject>();
		component.pieceData = data;
		component.pieceColor = color;
		switch (color)
		{
		case ChessColor.White:
			component.spriteRenderer.color = whiteColor.globalColor;
			break;
		case ChessColor.Black:
			component.spriteRenderer.color = blackColor.globalColor;
			break;
		}
		component.spriteRenderer.sprite = data.pieceFillSprite;
		component.outlineRenderer.sprite = data.pieceOutlineSprite;
		component.outlineRenderer.color = outlineColor.globalColor;
		return component;
	}

	public DamageNumber SpawnDamageNumber(string text, Transform target, Vector3 offset)
	{
		DamageNumber component = Object.Instantiate(damageNumberPrefab, Camera.main.WorldToScreenPoint(target.position + offset), Quaternion.identity, canvas.transform).GetComponent<DamageNumber>();
		component.Setup(text, target, Camera.main, offset);
		return component;
	}

	public void KingKillCommand()
	{
		List<ChessPieceObject> list = new List<ChessPieceObject>();
		foreach (ChessPieceObject blackPiece in blackPieces)
		{
			if (blackPiece.pieceData.pieceType != ChessPieceData.ChessPieceType.King)
			{
				list.Add(blackPiece);
			}
		}
		foreach (ChessPieceObject item in list)
		{
			blackPieces.Remove(item);
			item.transform.position = new Vector3(0f, 20f, 0f);
		}
	}
}
