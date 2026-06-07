using System;
using System.Collections.Generic;
using Battle;
using Libs;
using SaveData;
using UI;
using UnityEngine;

[Serializable]
public class DetailScoreSetting
{
	[Serializable]
	public class EnablePointSet<T>
	{
		[Label("有効")]
		public bool enabled;

		[Label("ポイント設定")]
		public T pointSetting;

		[Label("アセンションボーナス")]
		public bool ascensionBonus;
	}

	[Serializable]
	public class RecordPoint
	{
		[Label("スコアタイトル")]
		public eScoreRecord record;

		[Label("ポイント")]
		public int point;
	}

	[Serializable]
	public class TargetRecordPoint<T> : RecordPoint
	{
		public T target;
	}

	[Serializable]
	public class TargetPoint<T>
	{
		public T target;

		[Label("ポイント")]
		public int point;
	}

	[Serializable]
	public class RecordWithTargets<T>
	{
		[Label("スコアタイトル")]
		public eScoreRecord record;

		public List<TargetPoint<T>> targetList;
	}

	[Serializable]
	public class RecordPointWithTargets<T> : RecordPoint
	{
		public List<T> targetList;

		public RecordPointWithTargets(List<T> list, eScoreRecord record, int point)
		{
		}
	}

	[Header("アセンションボーナス")]
	[Tooltip("(スコア) * (1 + (アセンション * n))")]
	public float ascensionIncrease;

	[Header("終了時一度だけ計算")]
	[Header("クリア報酬")]
	public EnablePointSet<RecordPoint> clearScore;

	[Header("最終レベルxn")]
	public EnablePointSet<List<TargetRecordPoint<int>>> lastLevel;

	[Header("残りHpによるポイント(n% * point)")]
	public EnablePointSet<RecordPoint> remainHp;

	[Header("(最後だけ)該当ランクのポイント(point)x納品数")]
	[Tooltip("各ヒーローランク納品数*係数*各ランクのポイント(最後に切り捨て)")]
	public EnablePointSet<List<TargetRecordPoint<eUnitRank>>> lastHeroRank;

	[Label("ヒーローランク係数")]
	public float heroRankCoefficient;

	[Header("取得緑研究")]
	public EnablePointSet<List<TargetRecordPoint<int>>> lastGetGreenPoint;

	[Header("取得赤研究")]
	public EnablePointSet<List<TargetRecordPoint<int>>> lastGetRedPoint;

	[Header("全ボス撃破")]
	public EnablePointSet<RecordPoint> allBossEliminated;

	[Header("ノーダメージ")]
	public EnablePointSet<RecordPoint> noDamage;

	[Header("クリア階層")]
	public EnablePointSet<RecordPoint> clearWave;

	[Header("ウェーブ種類")]
	public EnablePointSet<List<TargetRecordPoint<eEnemyType>>> waveType;

	[Space]
	[Header("チャレンジ専用")]
	[Header("イースターエッグ")]
	public EnablePointSet<List<RecordPointWithTargets<eLuggage>>> easterEgg;

	private List<(eScoreRecord, int)> CheckMoreBorderList(List<TargetRecordPoint<int>> borderPointList, int value)
	{
		return null;
	}

	public void CalcFinishWaveScore(ref WaveLog nowLog)
	{
	}

	public void CalcFinishScore(InGameData inGameData)
	{
	}

	public int GetIntoAscensionPoint(int basePoint, float ascensionRatio, bool on)
	{
		return 0;
	}

	public JDictionary<eScoreRecord, ScoreDetailModel> GetAllScoreAmount(PlayBattleData playData)
	{
		return null;
	}

	public int GetDeliveryLuggagePoint(eLuggage luggage, int value)
	{
		return 0;
	}
}
