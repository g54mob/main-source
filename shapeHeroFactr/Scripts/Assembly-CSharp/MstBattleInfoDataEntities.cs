using System;
using System.Collections.Generic;

[Serializable]
public class MstBattleInfoDataEntities
{
	public int primaryId;

	public eWaveGroup waveGroup;

	public eStageDivision division;

	public int wave;

	public eWaveTierId enemyChoiceId;

	public int waveSpan;

	public int waveTime;

	public bool isBoss;

	public List<eUpgradePack> rewardUpgradepack;

	public List<eUpgradePack> pattern;

	public int mana;

	public int keen;

	public int researchPoint;

	public int exp;

	public int knowledgePoint;

	public float waveRate;

	public string fieldPrefab;

	public List<string> enemyLevels;
}
