using System;
using UnityEngine;

[Serializable]
public class WishProperties
{
	public long maxLevel;

	public string wishName;

	public string WishDesc;

	public float wishSpeedDivider;

	public float effectPerLevel;

	public difficulty difficultyRequirement;

	public Sprite wishSprite;
}
