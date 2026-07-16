using System;
using UnityEngine;

[Serializable]
public class AreaPieceProperty
{
	public enum PieceType
	{
		Fill = 0,
		BorderFill = 1,
		BorderOneSide = 2,
		BorderTwoSides = 3,
		BorderCorner = 4,
		BorderEnd = 5,
		BorderDiagonal = 6,
		Entrance = 10,
		Exit = 11,
		WorkerEntrance = 12,
		FastPassEntrance = 13
	}

	public PieceType pieceType;

	public GameObject prefab;
}
