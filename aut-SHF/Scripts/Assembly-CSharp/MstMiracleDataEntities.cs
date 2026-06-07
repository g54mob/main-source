using System;
using System.Collections.Generic;

[Serializable]
public class MstMiracleDataEntities : ICommonEntiies
{
	public eMiracle id;

	public string name;

	public string desc;

	public eUnitRank rank;

	public eUnitRace race;

	public eUnitActionType actionType;

	public eSpellActionType spellType;

	public List<eUnitAttackType> attackType;

	public List<int> attackTypeLevel;

	public bool isClick;

	public int attackPoint;

	public float coolDownTime;

	public float radius;

	public int hitCount;

	public float speed;

	public int endurance;

	public double lifetime;

	public int sallyLimitCount;

	public bool ignoreReward;

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
