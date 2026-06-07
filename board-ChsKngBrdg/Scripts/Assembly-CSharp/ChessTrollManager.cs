using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChessTrollManager : MonoBehaviour
{
	public bool isDebugging;

	public ChessMatchManager chessMatchManager;

	public TrollDialogManager trollDialogManager;

	public RuleBookScreenManager ruleBookScreenManager;

	public RulebookFogManager rulebookFogManager;

	private bool isPerformingAction;

	public static bool doStartTopic;

	public float cheatingChance;

	public float cheakingChanceIncreaseMin;

	public float cheakingChanceIncreaseMax;

	public List<ChessMatchManager.ChessCheatReason> lastCheatReasons = new List<ChessMatchManager.ChessCheatReason>();

	public float fakeOutChance;

	public bool isPerformingFakeOut;

	[Header("Weight Parameters")]
	public float scoreForNoiseWeight;

	public float scoreForCapturedWhitePiecesWeight;

	public float scoreForCapturedBlackPiecesWeight;

	public float scoreForTradingPieceWeight;

	public float scoreForCapturedThisTurnWeight;

	public float scoreForCapturedNextTurnWeight;

	public float scoreForMovingOtherColorWeight;

	public float scoreForFavorableTileWeight;

	public float scoreForOutOfBoundsWeight;

	public float scoreForSlippingWeight;

	public void Start()
	{
		rulebookFogManager = Object.FindObjectOfType<RulebookFogManager>();
		if (doStartTopic)
		{
			doStartTopic = false;
			StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.GetRandomTopic(trollDialogManager.startTopics), 1f));
			SaveSystem.currentPlayerSaveData.firstGameinScene = false;
		}
		else if (SaveSystem.currentPlayerSaveData.firstGameinScene)
		{
			SaveSystem.currentPlayerSaveData.firstGameinScene = false;
		}
	}

	public void Update()
	{
		if (!ChessMatchManager.colorHasWon && !ruleBookScreenManager.showingCheatGuessResult)
		{
			if (chessMatchManager.whiteWonCheat)
			{
				chessMatchManager.whiteWonCheat = false;
				ChessMatchManager.blockMovement = true;
				StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.GetRandomTopic(trollDialogManager.caughtCheatingTopics), 0.5f, noAnimation: false, cancelStopMovement: true));
			}
			if (ChessMatchManager.currentTurnColor == ChessMatchManager.ChessColor.Black && !isPerformingAction)
			{
				isPerformingAction = true;
				StartCoroutine(PerformAction());
			}
			if (ChessMatchManager.currentTurnColor != ChessMatchManager.ChessColor.Black && isPerformingAction)
			{
				isPerformingAction = false;
			}
		}
	}

	public IEnumerator PerformAction()
	{
		if (chessMatchManager.nextPlayerWonCheat)
		{
			if (chessMatchManager.blackWonTime)
			{
				StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.GetRandomTopic(trollDialogManager.speedChessFailTopics), 0.5f));
			}
			else
			{
				RuleBookPage cheatPage;
				if (chessMatchManager.lastTurnCheatReasons.Count > 0)
				{
					StartCoroutine(ruleBookScreenManager.CheatScreen());
					yield return new WaitForSeconds(4f);
					cheatPage = ruleBookScreenManager.FindCheatReasonInRuleBook(chessMatchManager.lastTurnCheatReasons, chessMatchManager.lastTurnMovedChessPiece.pieceData.pieceType, doReverseCheat: false);
				}
				else
				{
					cheatPage = ruleBookScreenManager.FindCheatReasonInRuleBook(null, chessMatchManager.lastTurnMovedChessPiece.pieceData.pieceType, doReverseCheat: true);
				}
				trollDialogManager.SpawnTextBalloon();
				while (cheatPage != ruleBookScreenManager.currentRuleBookScreen.ruleBookPages[0] && cheatPage != ruleBookScreenManager.currentRuleBookScreen.ruleBookPages[1])
				{
					yield return null;
				}
				ObjectShake objectShake = ((cheatPage != ruleBookScreenManager.currentRuleBookScreen.ruleBookPages[0]) ? ruleBookScreenManager.rightPageImage.GetComponent<ObjectShake>() : ruleBookScreenManager.leftPageImage.GetComponent<ObjectShake>());
				objectShake.StartCoroutine(objectShake.Shake(2f, 0.025f));
				yield return new WaitForSeconds(1f);
				if (rulebookFogManager.CheckIfPageIsFogged(cheatPage))
				{
					rulebookFogManager.isProgressingFog = true;
					StartCoroutine(rulebookFogManager.ClearFog(rulebookFogManager.GetPageFogEntry(cheatPage)));
				}
				while (rulebookFogManager.isProgressingFog)
				{
					yield return null;
				}
				if (cheatPage.trollDialogTopic != null)
				{
					StartCoroutine(trollDialogManager.PerformDialog(cheatPage.trollDialogTopic, 0.5f));
				}
				else
				{
					StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.GetRandomTopic(trollDialogManager.falseAccusationTopics), 0.5f));
				}
			}
		}
		else if (!chessMatchManager.isJuggler && chessMatchManager.juggleCounter >= 20)
		{
			chessMatchManager.juggleCounter = 0;
			StartCoroutine(trollDialogManager.PerformDialog(trollDialogManager.GetRandomTopic(trollDialogManager.jugglerFailTopics), 0.5f));
		}
		else
		{
			trollDialogManager.RollForRandomDialog();
		}
		while (TrollDialogManager.isInDialog)
		{
			yield return null;
		}
		bool didFakeOut = false;
		if (!SpeedrunTimer.doSpeedrunTimer)
		{
			for (int i = 1; i <= 3; i++)
			{
				if (!didFakeOut)
				{
					didFakeOut = CheckForFakeOut(i);
				}
				else
				{
					CheckForFakeOut(i);
				}
				while (isPerformingFakeOut)
				{
					yield return null;
				}
			}
		}
		List<PossibleAction> list = new List<PossibleAction>();
		list.AddRange(GeneratePossibleMovesPerColor(chessMatchManager.blackPieces));
		list.AddRange(GeneratePossibleMovesPerColor(chessMatchManager.whitePieces));
		list.AddRange(GeneratePossibleMovesPerColor(chessMatchManager.utilityPieces));
		PossibleAction chosenAction = ChooseActionBasedOnCheatingChance(list);
		List<ChessMatchManager.ChessCheatReason> list2 = chessMatchManager.CheckForCheating(chosenAction.chessPiece, chosenAction.originPosition, chosenAction.originPosition + chosenAction.movePosition);
		if (list2.Count > 0)
		{
			lastCheatReasons = list2;
		}
		if (didFakeOut)
		{
			yield return new WaitForSeconds(0.25f);
		}
		else
		{
			yield return new WaitForSeconds(Random.Range(0.33f, 0.66f));
		}
		StartCoroutine(chosenAction.chessPiece.DragChessPiece(chosenAction.originPosition, chosenAction.movePosition));
		cheatingChance += Random.Range(cheakingChanceIncreaseMin, cheakingChanceIncreaseMax);
	}

	public List<PossibleAction> GeneratePossibleMovesPerColor(List<ChessPieceObject> chessPieces)
	{
		List<PossibleAction> list = new List<PossibleAction>();
		foreach (ChessPieceObject chessPiece in chessPieces)
		{
			Vector3 originPosition = ChessMatchManager.RoundPoint(chessPiece.transform.position);
			list.AddRange(GeneratePossibleMovesPerMoves(chessPiece, chessPiece.pieceData.allowedMoves, originPosition));
			if (chessPiece.pieceColor == ChessMatchManager.ChessColor.Black)
			{
				list.AddRange(GeneratePossibleMovesPerMoves(chessPiece, chessPiece.pieceData.cheatMoves, originPosition));
			}
		}
		return list;
	}

	public List<PossibleAction> GeneratePossibleMovesPerMoves(ChessPieceObject chessPiece, List<Vector3> moves, Vector3 originPosition)
	{
		List<PossibleAction> list = new List<PossibleAction>();
		foreach (Vector3 move in moves)
		{
			PossibleAction possibleAction = new PossibleAction(chessPiece, originPosition, move * -1f, 0f, isCheating: false);
			float scoreForNoise = Random.Range(0f, 1f);
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float scoreForCapturedThisTurn = 0f;
			float scoreForCapturedNextTurn = 0f;
			float scoreForMovingOtherColor = 0f;
			float num4 = 0f;
			float scoreForOutOfBounds = 0f;
			float scoreForSlipping = 0f;
			bool flag = false;
			List<ChessPieceObject> list2 = new List<ChessPieceObject>();
			list2 = chessMatchManager.CheckForCapture(possibleAction.chessPiece, possibleAction.movePosition + possibleAction.originPosition);
			if (chessPiece.pieceColor == ChessMatchManager.ChessColor.Black)
			{
				foreach (ChessPieceObject item in list2)
				{
					if (item.pieceColor == ChessMatchManager.ChessColor.White)
					{
						num += (float)item.pieceData.pieceScore;
					}
					if (item.pieceColor == ChessMatchManager.ChessColor.Utility)
					{
						flag = true;
					}
				}
			}
			else
			{
				foreach (ChessPieceObject item2 in list2)
				{
					if (item2.pieceColor == ChessMatchManager.ChessColor.Black)
					{
						num2 += (float)item2.pieceData.pieceScore;
					}
					if (item2.pieceColor == ChessMatchManager.ChessColor.Utility)
					{
						flag = true;
					}
				}
			}
			num3 = chessPiece.pieceData.pieceScore;
			bool flag2 = false;
			foreach (GameObject slipperyTile in chessMatchManager.slipperyTiles)
			{
				if (slipperyTile.activeSelf && possibleAction.movePosition + possibleAction.originPosition == ChessMatchManager.RoundPoint(slipperyTile.transform.position))
				{
					flag2 = true;
				}
			}
			if (flag2)
			{
				scoreForSlipping = chessPiece.pieceData.pieceScore;
			}
			if (chessPiece.pieceColor == ChessMatchManager.ChessColor.Black)
			{
				bool flag3 = false;
				bool flag4 = false;
				List<ChessPieceObject> list3 = new List<ChessPieceObject> { chessPiece };
				if (list2.Count > 0)
				{
					list3.AddRange(list2);
				}
				foreach (ChessPieceObject whitePiece in chessMatchManager.whitePieces)
				{
					if (whitePiece.isSleeping)
					{
						break;
					}
					Vector3 vector = ChessMatchManager.RoundPoint(whitePiece.transform.position);
					foreach (Vector3 allowedMove in whitePiece.pieceData.allowedMoves)
					{
						if (allowedMove + vector == possibleAction.originPosition)
						{
							List<ChessMatchManager.ChessCheatReason> list4 = chessMatchManager.CheckForCheating(whitePiece, vector, vector + allowedMove);
							list4.Remove(ChessMatchManager.ChessCheatReason.WrongColorMoved);
							if (list4.Count < 1)
							{
								flag3 = true;
							}
						}
						if (allowedMove + vector == possibleAction.originPosition + possibleAction.movePosition)
						{
							List<ChessMatchManager.ChessCheatReason> list5 = chessMatchManager.CheckForCheating(whitePiece, vector, vector + allowedMove, list3);
							list5.Remove(ChessMatchManager.ChessCheatReason.WrongColorMoved);
							if (list5.Count < 1)
							{
								flag4 = true;
							}
						}
					}
				}
				if (flag3 && !flag4)
				{
					scoreForCapturedThisTurn = chessPiece.pieceData.pieceScore;
				}
				if (flag4 || flag)
				{
					scoreForCapturedNextTurn = chessPiece.pieceData.pieceScore;
				}
			}
			if (chessPiece.pieceColor != ChessMatchManager.ChessColor.Black && chessPiece.pieceData.pieceType != ChessPieceData.ChessPieceType.King)
			{
				bool flag5 = false;
				foreach (ChessPieceObject blackPiece in chessMatchManager.blackPieces)
				{
					foreach (Vector3 allowedMove2 in blackPiece.pieceData.allowedMoves)
					{
						if (allowedMove2 + ChessMatchManager.RoundPoint(blackPiece.transform.position) == possibleAction.originPosition + possibleAction.movePosition)
						{
							flag5 = true;
						}
					}
				}
				if (flag5)
				{
					scoreForMovingOtherColor = chessPiece.pieceData.pieceScore;
				}
			}
			float num5 = 999f;
			foreach (Vector3 favorableTile in chessPiece.pieceData.favorableTiles)
			{
				if (chessPiece.pieceColor == ChessMatchManager.ChessColor.Black)
				{
					float num6 = Vector3.Distance(favorableTile, possibleAction.originPosition + possibleAction.movePosition);
					if (num6 < num5)
					{
						num5 = num6;
					}
				}
				else
				{
					float num7 = Vector3.Distance(-favorableTile, possibleAction.originPosition + possibleAction.movePosition);
					if (num7 < num5)
					{
						num5 = num7;
					}
				}
			}
			num4 = (8f - num5) / 8f * 10f;
			Vector2 vector2 = Camera.main.WorldToViewportPoint(possibleAction.originPosition + possibleAction.movePosition);
			if (!(vector2.x >= 0f) || !(vector2.x <= 1f) || !(vector2.y >= 0f) || !(vector2.y <= 1f))
			{
				scoreForOutOfBounds = 100f;
			}
			List<ChessMatchManager.ChessCheatReason> list6 = chessMatchManager.CheckForCheating(possibleAction.chessPiece, possibleAction.originPosition, possibleAction.movePosition + possibleAction.originPosition);
			if (list6.Count > 0)
			{
				possibleAction.isCheating = true;
				possibleAction.cheekiness = CalculateCheekiness(list6);
			}
			if (list6.Count > 0)
			{
				foreach (ChessMatchManager.ChessCheatReason item3 in list6)
				{
					if (lastCheatReasons.Contains(item3))
					{
						possibleAction.isBanned = true;
					}
				}
			}
			if (chessPiece.pieceData.pieceType == ChessPieceData.ChessPieceType.King && chessPiece.pieceColor == ChessMatchManager.ChessColor.White)
			{
				possibleAction.isBanned = true;
			}
			if (chessPiece.pieceData.pieceType == ChessPieceData.ChessPieceType.Landmine && list2.Count > 0)
			{
				possibleAction.isBanned = true;
			}
			if (possibleAction.isCheating && flag)
			{
				possibleAction.isBanned = true;
			}
			if (chessPiece.pieceData.pieceType == ChessPieceData.ChessPieceType.Pawn)
			{
				switch (chessPiece.pieceColor)
				{
				case ChessMatchManager.ChessColor.White:
					if ((double)(possibleAction.originPosition.y + possibleAction.movePosition.y) >= 3.5)
					{
						possibleAction.isBanned = true;
					}
					break;
				case ChessMatchManager.ChessColor.Black:
					if ((double)(possibleAction.originPosition.y + possibleAction.movePosition.y) <= -3.5)
					{
						possibleAction.isBanned = true;
					}
					break;
				}
			}
			possibleAction.scoreForNoise = scoreForNoise;
			possibleAction.scoreForCapturedWhitePieces = num;
			possibleAction.scoreForCapturedBlackPieces = num2;
			possibleAction.scoreForTradingPiece = num3;
			possibleAction.scoreForCapturedThisTurn = scoreForCapturedThisTurn;
			possibleAction.scoreForCapturedNextTurn = scoreForCapturedNextTurn;
			possibleAction.scoreForMovingOtherColor = scoreForMovingOtherColor;
			possibleAction.scoreForFavorableTile = num4;
			possibleAction.scoreForOutOfBounds = scoreForOutOfBounds;
			possibleAction.moveScore = CalculateMoveScore(scoreForNoise, num, num2, num3, scoreForCapturedThisTurn, scoreForCapturedNextTurn, scoreForMovingOtherColor, num4, scoreForOutOfBounds, scoreForSlipping);
			if (possibleAction.isBanned)
			{
				possibleAction.moveScore = -999f;
			}
			if (isDebugging && chessPiece.pieceColor != ChessMatchManager.ChessColor.White)
			{
				StartCoroutine(chessMatchManager.NumberIndicator(possibleAction.originPosition + possibleAction.movePosition, possibleAction.moveScore, 2f));
			}
			list.Add(possibleAction);
		}
		return list;
	}

	public PossibleAction ChooseActionBasedOnCheatingChance(List<PossibleAction> possibleActions)
	{
		possibleActions = possibleActions.OrderByDescending((PossibleAction x) => x.moveScore).ToList();
		if (chessMatchManager.nextPlayerWonCheat)
		{
			ChessPieceObject chessPieceObject = chessMatchManager.GetPiecesByColorAndType(ChessMatchManager.ChessColor.Black, ChessPieceData.ChessPieceType.King)[0];
			Vector3 vector = ChessMatchManager.RoundPoint(chessPieceObject.transform.position);
			Vector3 vector2 = Vector3.zero;
			foreach (ChessPieceObject whitePiece in chessMatchManager.whitePieces)
			{
				if (whitePiece.pieceData.pieceType == ChessPieceData.ChessPieceType.King)
				{
					vector2 = ChessMatchManager.RoundPoint(whitePiece.transform.position);
				}
			}
			return new PossibleAction(chessPieceObject, vector, vector2 - vector, 1000f, isCheating: true);
		}
		if (!possibleActions[0].isCheating)
		{
			return possibleActions[0];
		}
		bool flag = false;
		if (Random.Range(0f, 100f) <= cheatingChance + CalculateCheatChanceBonus(possibleActions[0]))
		{
			Debug.Log("Choosing to cheat!!");
			flag = true;
		}
		if (flag)
		{
			List<ChessPieceObject> list = chessMatchManager.CheckForCapture(possibleActions[0].chessPiece, possibleActions[0].movePosition + possibleActions[0].originPosition);
			bool flag2 = false;
			if (list.Count > 0)
			{
				foreach (ChessPieceObject item in list)
				{
					if (item.pieceData.pieceType == ChessPieceData.ChessPieceType.King)
					{
						flag2 = true;
					}
				}
			}
			if (!flag2 && possibleActions[0].isCheating)
			{
				cheatingChance = 0f;
				return possibleActions[0];
			}
		}
		for (int num = 1; num < possibleActions.Count; num++)
		{
			if (!possibleActions[num].isCheating)
			{
				return possibleActions[num];
			}
		}
		cheatingChance = 0f;
		return possibleActions[0];
	}

	public float CalculateMoveScore(float scoreForNoise, float scoreForCapturedWhitePieces, float scoreForCapturedBlackPieces, float scoreForTradingPiece, float scoreForCapturedThisTurn, float scoreForCapturedNextTurn, float scoreForMovingOtherColor, float scoreForFavorableTile, float scoreForOutOfBounds, float scoreForSlipping)
	{
		scoreForNoise *= 100f;
		scoreForNoise = Mathf.Clamp(scoreForNoise, 0f, 100f);
		scoreForNoise *= scoreForNoiseWeight;
		scoreForCapturedWhitePieces *= 10f;
		if (scoreForCapturedWhitePieces > 0f && scoreForCapturedNextTurn == 0f)
		{
			scoreForCapturedWhitePieces *= 5f;
		}
		scoreForCapturedWhitePieces = Mathf.Clamp(scoreForCapturedWhitePieces, 0f, 1000f);
		scoreForCapturedWhitePieces *= scoreForCapturedWhitePiecesWeight;
		scoreForCapturedBlackPieces *= 10f;
		scoreForCapturedBlackPieces = Mathf.Clamp(scoreForCapturedBlackPieces, 0f, 1000f);
		scoreForCapturedBlackPieces *= scoreForCapturedBlackPiecesWeight;
		scoreForCapturedBlackPieces = 0f - scoreForCapturedBlackPieces;
		scoreForTradingPiece = 100f - (scoreForTradingPiece * 10f - 10f);
		scoreForTradingPiece = Mathf.Clamp(scoreForTradingPiece, 0f, 1000f);
		scoreForTradingPiece *= scoreForTradingPieceWeight;
		scoreForCapturedThisTurn *= 10f;
		scoreForCapturedThisTurn = Mathf.Clamp(scoreForCapturedThisTurn, 0f, 1000f);
		scoreForCapturedThisTurn *= scoreForCapturedThisTurnWeight;
		scoreForCapturedNextTurn *= 10f;
		scoreForCapturedNextTurn = Mathf.Clamp(scoreForCapturedNextTurn, 0f, 1000f);
		scoreForCapturedNextTurn *= scoreForCapturedNextTurnWeight;
		scoreForCapturedNextTurn = 0f - scoreForCapturedNextTurn;
		scoreForMovingOtherColor *= 10f;
		scoreForMovingOtherColor = Mathf.Clamp(scoreForMovingOtherColor, 0f, 1000f);
		scoreForMovingOtherColor *= scoreForMovingOtherColorWeight;
		scoreForFavorableTile *= 10f;
		scoreForFavorableTile = Mathf.Clamp(scoreForFavorableTile, 0f, 100f);
		scoreForFavorableTile *= scoreForFavorableTileWeight;
		scoreForOutOfBounds = Mathf.Clamp(scoreForOutOfBounds, 0f, 100f);
		scoreForOutOfBounds *= scoreForOutOfBoundsWeight;
		scoreForOutOfBounds = 0f - scoreForOutOfBounds;
		scoreForSlipping *= 10f;
		scoreForSlipping = Mathf.Clamp(scoreForSlipping, 0f, 1000f);
		scoreForSlipping *= scoreForSlippingWeight;
		scoreForSlipping = 0f - scoreForSlipping;
		float value = (scoreForNoise + scoreForCapturedWhitePieces + scoreForCapturedBlackPieces + scoreForTradingPiece + scoreForCapturedThisTurn + scoreForCapturedNextTurn + scoreForMovingOtherColor + scoreForFavorableTile + scoreForOutOfBounds + scoreForSlipping) / 6f;
		value = Mathf.Clamp(value, 0f, 1000f);
		if (isDebugging)
		{
			Debug.Log("scoreForNoise: " + scoreForNoise);
			Debug.Log("scoreForCapturedWhitePieces: " + scoreForCapturedWhitePieces);
			Debug.Log("scoreForCapturedBlackPieces: " + scoreForCapturedBlackPieces);
			Debug.Log("scoreForTradingPiece: " + scoreForTradingPiece);
			Debug.Log("scoreForCapturedThisTurn: " + scoreForCapturedThisTurn);
			Debug.Log("scoreForCapturedNextTurn: " + scoreForCapturedNextTurn);
			Debug.Log("scoreForMovingOtherColor: " + scoreForMovingOtherColor);
			Debug.Log("scoreForFavorableTile: " + scoreForFavorableTile);
			Debug.Log("scoreForOutOfBounds: " + scoreForOutOfBounds);
			Debug.Log("moveScore: " + value);
		}
		return value;
	}

	public int CalculateCheekiness(List<ChessMatchManager.ChessCheatReason> cheatReasons)
	{
		int num = 0;
		if (cheatReasons.Contains(ChessMatchManager.ChessCheatReason.WrongColorMoved))
		{
			num += 50;
		}
		if (cheatReasons.Contains(ChessMatchManager.ChessCheatReason.MoveOutOfBounds))
		{
			num += 75;
		}
		if (cheatReasons.Contains(ChessMatchManager.ChessCheatReason.CollideWithOwnColor))
		{
			num += 75;
		}
		if (cheatReasons.Contains(ChessMatchManager.ChessCheatReason.MoveNotAllowedByType))
		{
			num += 25;
		}
		if (cheatReasons.Contains(ChessMatchManager.ChessCheatReason.BlockWasIgnored))
		{
			num += 75;
		}
		return num;
	}

	public float CalculateCheatChanceBonus(PossibleAction possibleAction)
	{
		return Mathf.Clamp((100 - possibleAction.cheekiness) / 20, 0f, 100f);
	}

	public bool CheckForFakeOut(float multiplier)
	{
		float num = Random.Range(0, 100);
		float num2 = (1 - chessMatchManager.blackPieces.Count / 16) * 4;
		if (chessMatchManager.blackPieces.Count < 3)
		{
			num2 += 50f;
		}
		float num3 = (fakeOutChance + num2) / multiplier;
		if (num < num3)
		{
			PerformFakeOut();
			return true;
		}
		return false;
	}

	public void PerformFakeOut()
	{
		List<ChessPieceObject> list = new List<ChessPieceObject>();
		list.AddRange(chessMatchManager.whitePieces);
		list.AddRange(chessMatchManager.blackPieces);
		list.AddRange(chessMatchManager.utilityPieces);
		ChessPieceObject chessPieceObject = list[Random.Range(0, list.Count)];
		isPerformingFakeOut = true;
		StartCoroutine(chessPieceObject.FakeOut(ChessMatchManager.RoundPoint(chessPieceObject.transform.position)));
	}
}
