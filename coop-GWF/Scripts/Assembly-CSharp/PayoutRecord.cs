using System;
using UnityEngine;

[Serializable]
public class PayoutRecord
{
	public float timestamp;

	public string playerName;

	public PlayerProfile playerProfile;

	public long bet;

	public long payout;

	public long profit;

	public bool isWin;

	public bool isLoss;

	public CasinoGameType gameType;

	public Vector3 gamePosition;
}
