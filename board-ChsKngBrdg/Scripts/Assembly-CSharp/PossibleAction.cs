using UnityEngine;

public class PossibleAction
{
	public ChessPieceObject chessPiece;

	public Vector3 originPosition;

	public Vector3 movePosition;

	public float moveScore;

	public bool isCheating;

	public int cheekiness;

	public bool isBanned;

	public float scoreForNoise;

	public float scoreForCapturedWhitePieces;

	public float scoreForCapturedBlackPieces;

	public float scoreForTradingPiece;

	public float scoreForCapturedThisTurn;

	public float scoreForCapturedNextTurn;

	public float scoreForMovingOtherColor;

	public float scoreForFavorableTile;

	public float scoreForOutOfBounds;

	public float scoreForSlipping;

	public PossibleAction(ChessPieceObject chessPiece, Vector3 originPosition, Vector3 movePosition, float moveScore, bool isCheating)
	{
		this.chessPiece = chessPiece;
		this.originPosition = originPosition;
		this.movePosition = movePosition;
		this.moveScore = moveScore;
		this.isCheating = isCheating;
	}
}
