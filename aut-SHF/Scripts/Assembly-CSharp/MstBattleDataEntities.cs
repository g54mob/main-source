using System;
using System.Collections.Generic;

[Serializable]
public class MstBattleDataEntities
{
	public eStageId stageId;

	public int clearWave;

	public string name;

	public eModeType modeType;

	public string mapPath;

	public eWaveGroup waveGroup;

	public List<string> division;

	public bool applyKnowledge;

	public int applyAscension;

	public bool onlyRealTime;

	public int initMana;

	public int initGreenResearch;

	public int initRedResearch;

	public int initKeen;

	public int initRemoveMachinePoint;

	public int initConcentration;

	public int initMaxConcentration;

	public float difficultyCoefficient;

	public List<eResearchCategory> additionalInitResearch;

	public List<string> additionalInitLuggages;

	public List<string> initialUpgrade;

	public List<eCustomRuleId> ruleTag;
}
