using System.Collections.Generic;
using System.Linq;
using Pieces;
using UnityEngine;

public class Player
{
	public int Mana { get; set; }

	public int PiecesTaken { get; set; }

	public bool RemovedFromGame { get; set; }

	public int RedrawAttemptsLeft { get; set; }

	public bool AcceptedHand { get; set; }

	public List<Piece> pieceList { get; private set; }

	public bool HasCameraInfo { get; private set; }

	public Vector3 PreviousCameraPos { get; private set; }

	public float PreviousCameraRot { get; private set; }

	public bool HasTwinInCheck
	{
		get
		{
			if (pieceList != null)
			{
				return pieceList.Any((Piece x) => x.pieceType == PieceTypeEnum.Twin && ((Twin)x).InCheck);
			}
			return false;
		}
	}

	public void AddPiece(Piece piece)
	{
		if (pieceList == null)
		{
			pieceList = new List<Piece>();
		}
		pieceList.Add(piece);
	}

	public void RemovePiece(Piece piece)
	{
		if (pieceList.Contains(piece))
		{
			pieceList.Remove(piece);
		}
	}

	public void SetCameraInfo(Vector3 pos, float rot)
	{
		HasCameraInfo = true;
		PreviousCameraPos = pos;
		PreviousCameraRot = rot;
	}

	public void ResetCameraInfo()
	{
		HasCameraInfo = false;
		PreviousCameraPos = Vector3.zero;
		PreviousCameraRot = 0f;
	}
}
