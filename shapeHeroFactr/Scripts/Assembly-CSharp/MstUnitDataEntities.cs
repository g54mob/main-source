using System;
using System.Collections.Generic;

[Serializable]
public class MstUnitDataEntities : ICommonEntiies
{
	public eUnit id;

	public eLuggage sorceLuggage;

	public string name;

	public eUnitRank rank;

	public eUnitRace race;

	public eUnitSize size;

	public string actionDesc;

	public eUnitActionType actionType;

	public List<eUnitAttackType> attackType;

	public List<int> attackTypeLevel;

	public int attackPoint;

	public int attackCount;

	public int endurance;

	public float lifeTime;

	public float speed;

	public int shield;

	public int shootCount;

	public bool enabledKnockBack;

	public int knockBackLimit;

	public float knockBackStanSecond;

	public float knockBackPower;

	public int sallyLimitCount;

	public bool ignoreReward;

	public bool isHidden;

	public string flavorText;

	public eMachine statueId;

	public string getStatueText;

	public string iconPath;

	public string gifPath;

	public string Name => null;

	public string Desc => null;

	public string IconPath => null;

	public string GifPath => null;
}
