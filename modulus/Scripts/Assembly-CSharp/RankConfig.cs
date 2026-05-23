using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct RankConfig
{
	public int Rank;

	public int XPRequired;

	public Sprite Icon;

	public Sprite IconLarge;

	public List<AbstractRankUpBehavior> RankUpBehaviors;
}
