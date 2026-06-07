using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class RuleBookPage
{
	public string pageID;

	public LocalizedSprite localizedSprite;

	public ChessMatchManager.ChessCheatReason ruleCheatReason;

	public int ruleCheatScore;

	public string ruleBreakText;

	public LocalizedString ruleBreakString;

	public bool checkForSpecificPiece;

	public ChessPieceData.ChessPieceType ruleSpecificPiece;

	public DialogTopic trollDialogTopic;

	public bool checkForSpecificFogPiece;

	public ChessPieceData.ChessPieceType clearFogPiece;

	public int turnsToClearFog;

	public List<Sprite> contentSprites = new List<Sprite>();
}
