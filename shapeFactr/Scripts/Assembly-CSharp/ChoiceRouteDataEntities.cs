using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

[Serializable]
public class ChoiceRouteDataEntities
{
	[Serializable]
	public class EnforcementEvent
	{
		public int waveCount;

		[Label("１つ目のイベント")]
		public eRouteEvent eventType;

		[Label("ランダム")]
		[Tooltip("multiEventPools.event1内から選出")]
		public bool random1;

		public RouteEventCondition mainEventCondition;

		[Label("２つ目のイベント")]
		public eRouteEvent subEvent;

		[Label("ランダム")]
		[Tooltip("multiEventPools.event2内から選出")]
		public bool random2;

		public RouteEventCondition subEventCondition;

		[Label("条件無視(デバッグ用)")]
		[Tooltip("上の条件を無視してイベントが強制発生。UnityEditor、PRETRIALのみ有効。他は自動で無効")]
		public bool conditionless;
	}

	[Serializable]
	public class ConditionEvent
	{
		public eRouteEvent eventType;

		[Label("最大回数")]
		public int maxCount;
	}

	[Serializable]
	public class MultipleEventPool
	{
		public eRouteEvent event1;

		public eRouteEvent event2;
	}

	public enum eStagePreset
	{
		ThreeLoadFiveWidth = 0,
		TwoLoadFiveWidth = 1,
		ThreeLoadThreeWidth = 2,
		TwoLoadThreeWidth = 3,
		TwoLoadTwoWidth = 4,
		Endless = 5,
		OneLine = 6
	}

	[Serializable]
	public class RouteEventCondition
	{
		[Label("必要前回Waveクリア数")]
		[Tooltip("-1で無視")]
		public int prevWave;

		[Label("クリアアセンション数")]
		[Tooltip("-1で無視")]
		public int clearAscension;
	}

	[Serializable]
	public class RouteShopCondition
	{
		[Label("ショップが出現するか")]
		[Tooltip("falseならこのDivisionではルートショップが出ない")]
		public bool isEnableRouteShop;

		[Label("ショップの出現数")]
		[Tooltip("この回数分ルートショップが強制発生")]
		public int overrideCount;

		[Label("メインイベントを上書きするか")]
		[Tooltip("trueなら強制的にメインを上書き、falseなら可能な場合のみ")]
		public bool forceOverrideMainEvent;

		[Label("ショップが出現するLevel")]
		[Tooltip("Division内でのLevel(WaveCount)")]
		public List<int> enableLevels;
	}

	[Label("ウェーブ数")]
	public int waveCount;

	[Label("ステージプリセット")]
	public eStagePreset preset;

	[Tooltip("ここに入ってないイベントは出てこない")]
	public List<RouteNodeData> routeNodeDatas;

	[Label("強制イベント指定")]
	[Tooltip("指定したwaveCount後のイベントが全て決まったものになる")]
	public List<EnforcementEvent> enforcementEvents;

	[Header("複数イベント設定")]
	[Label("複数イベント確率")]
	[Range(0f, 1f)]
	[Tooltip("固定の複数イベントを除くイベントが2つになる確率")]
	public float multipleEventRate;

	[Label("イベント被り有")]
	public bool enableSameEvent;

	[Label("出現イベントリスト")]
	[Tooltip("この中から選出される")]
	public List<MultipleEventPool> multiEventPools;

	[Label("複数イベント除外Wave")]
	[Tooltip("序盤に2つ取得出来たら強すぎるので対策")]
	public List<int> ignoreMultiEventWave;

	[Header("エリート設定")]
	[Label("エリートティア")]
	[Tooltip("選択したTierの中からEnemyが選択される")]
	public eWaveTierId eliteTier;

	[Label("エリートレベル")]
	public int eliteLevel;

	[Label("エリート除外wave")]
	public int[] eliteIgnoreWave;

	[Label("強制ネームド戦")]
	[Tooltip("Divisionごとの左から何番目が強制かを入力。エリート除外waveが優先")]
	public List<int> enforceNamedWave;

	[Label("最小エリート数/wave")]
	[Tooltip("エリートマスがWave単位で出現する最低数(エリート除外waveが優先)")]
	public int minPerWave;

	[Label("最大エリート数/wave")]
	public int maxPerWave;

	[Label("エリート出現率/wave")]
	[Range(0f, 1f)]
	public float eliteProbability;

	[Label("エリート必通ルート(%)")]
	[Tooltip("エリートが必ず存在するルートが全ルートの通り数の何％に設定するか。エリート保障数を行ったうえで%に達するまでエリートに変更する。例：0.5に設定した場合、全ルート通り数が190ならそのうち95ルートでエリートが必ず出現する")]
	[Range(0f, 1f)]
	public float eliteRouteRaito;

	[Label("雑魚敵(wave数指定)")]
	[Tooltip("雑魚敵の設定。指定したwave数現在のwave数からマイナスしたときのenemyLevelを適用して雑魚敵を出す(計算結果は1より下にはならない)")]
	public int minusEnemyWaveLevel;

	[Header("ボス設定")]
	[Label("ボスティア設定")]
	[Tooltip("選択したTierの中からボスが選出される")]
	public eWaveTierId bossTier;

	[Label("ボスレベル")]
	public int bossLevel;

	[Label("ボス撃破時報酬")]
	public List<eUpgradePack> bossEliminationReward;

	[Label("ステージ数表示")]
	public bool enabledStageNum;

	[Header("マス配置設定")]
	public float paddingLeft;

	public float paddingRight;

	public float offsetX;

	public float spaceX;

	public bool fixWidth;

	[Header("試練設定")]
	[Label("試練が登場するかどうか")]
	public bool enabledOrdeal;

	[Header("ルートショップ設定")]
	public RouteShopCondition routeShopCondition;
}
