using System;
using System.Collections.Generic;

[Serializable]
public class MstScoreRecordEntities
{
	public eScoreRecord id;

	public List<eStageId> targetStages;

	public string title;

	public string desc;

	public int basePoint;

	public eScoreLogicKind logicKind;

	public List<string> param;

	public bool isAscensionBonus;

	public bool calcLastWave;
}
