using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class StageRecord
{
	[Serializable]
	public class StageRecordEntry
	{
		[SerializeField]
		private eWorldType worldType;

		[SerializeField]
		private int stageIndex;

		[SerializeField]
		private int win;

		[SerializeField]
		private int lose;

		public eWorldType WorldType => default(eWorldType);

		public int StageIndex => 0;

		public int Win => 0;

		public int Lose => 0;

		public StageRecordEntry(eWorldType worldType, int stageIndex)
		{
		}

		public void RecordGame(bool isWin)
		{
		}

		public bool IsCleared()
		{
			return false;
		}

		public int GetTotalGameCount()
		{
			return 0;
		}
	}

	[SerializeField]
	private List<StageRecordEntry> list_StageRecords_Easy;

	[SerializeField]
	private List<StageRecordEntry> list_StageRecords_Normal;

	[SerializeField]
	private List<StageRecordEntry> list_StageRecords_Heroic;

	[SerializeField]
	private List<StageRecordEntry> list_StageRecords_Nightmare;

	[SerializeField]
	[Header("總共通過幾個普通關卡")]
	private int normalStageCleared;

	[SerializeField]
	[Header("總共通過幾個腐化關卡")]
	private int corruptStageCleared;

	[Header("總共通過幾個變異關卡")]
	[FormerlySerializedAs("variantStageCleared")]
	[SerializeField]
	private int anomalyStageCleared;

	[Header("總共通過幾個黑暗關卡")]
	private int darknessStageCleared;

	public StageRecordEntry GetStageRecordData(eGameDifficultyType difficulty, eWorldType world, int index)
	{
		return null;
	}

	public void RecordCurrentGameStart()
	{
	}

	public void RecordGameStart(eGameDifficultyType difficulty, eWorldType world, int index)
	{
	}

	public void RecordCurrentStageEnd(bool isWin)
	{
	}

	public void RecordStageEnd(eGameDifficultyType difficulty, eWorldType world, eStageType stageType, int index, bool isWin)
	{
	}

	private List<StageRecordEntry> GetList(eGameDifficultyType difficulty)
	{
		return null;
	}
}
