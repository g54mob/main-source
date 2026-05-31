using System;
using UnityEngine;

[Serializable]
public class StoredStats
{
	public int exp;

	public float attackBoost;

	public float defenseBoost;

	public float energySpeed;

	public long capEnergy;

	public long curEnergy;

	public long idleEnergy;

	public long energyGained;

	public int energyPerBar;

	public float energyPower;

	public float energyBarProgress;

	public Adventure adventure;

	public Inventory inventory;

	public Magic magic;

	public TimeMachine machine;

	public PlayerTime totalPlaytime;

	public UnityEngine.Random.State lootState;

	public Purchases purchases;
}
