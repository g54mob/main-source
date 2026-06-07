using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New ChessPieceData", menuName = "ChessPieces")]
public class ChessPieceData : ScriptableObject
{
	public enum ChessPieceType
	{
		Pawn = 0,
		Bishop = 1,
		Knight = 2,
		Rook = 3,
		Queen = 4,
		King = 5,
		Null = 6,
		Landmine = 7,
		Castle = 8
	}

	public ChessPieceType pieceType;

	public Sprite pieceOutlineSprite;

	public Sprite pieceFillSprite;

	public int pieceScore;

	public bool infiniteMoveLength;

	public bool jumpOverOthers;

	public LocalizedString pieceNameString;

	public List<Vector3> favorableTiles = new List<Vector3>();

	public List<Vector3> allowedMoves = new List<Vector3>();

	public List<Vector3> cheatMoves = new List<Vector3>();
}
