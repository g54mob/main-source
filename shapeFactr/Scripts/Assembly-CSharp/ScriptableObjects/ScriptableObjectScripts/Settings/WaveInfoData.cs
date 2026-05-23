using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

namespace ScriptableObjects.ScriptableObjectScripts.Settings
{
	[CreateAssetMenu]
	public class WaveInfoData : ScriptableObject
	{
		[Serializable]
		public class LuggageMinOutputSet
		{
			public eLuggage luggage;

			public float minOutput;
		}

		[Serializable]
		public class AdditionalDivision
		{
			[Label("追加ステージ")]
			public eStageDivision division;

			[Label("追加ウェーブ")]
			public eWaveGroup waveGroup;
		}

		[Header("------------")]
		[Header("バトル初期設定ファイル")]
		[Header("------------")]
		[Header("標準バトル速度(逆数)")]
		public double defaultBattleReciprocalSpeed;

		[Space]
		[Header("Wave数設定")]
		[Header("(クリアウェーブ数はMstBattleに移行)")]
		[Label("展示用ウェーブ数")]
		[Tooltip("展示用はマスタにまだないので一応残しているだけ")]
		public int demoWaveCount;

		[Header("バトル全般設定")]
		[Label("有効：シード値")]
		public bool enabledSeed;

		[Label("シード値")]
		public int seed;

		[Label("強制ステージ変更")]
		[Tooltip("デバッグ用：インゲーム途中からの変更はできない。これがNone以外のときは下の設定を無視して強制的に選択したステージになる")]
		public eStageId stageId;

		[Label("本番or開発で読み込むステージ")]
		[Tooltip("Defineが設定されていない時、ロビーで侵攻を選択した場合に読み込まれるステージ")]
		public eStageId readMainStage;

		[Label("Trialで読み込むステージ")]
		[Tooltip("DefineがTrialのとき、ロビーで侵攻を選択した場合に読み込まれるステージ")]
		public eStageId readTrialStage;

		[Header("街から本の四隅までの角度調整")]
		[Label("右上")]
		[Range(-180f, 180f)]
		public float topRightCornerDegree;

		[Label("左上")]
		[Range(-180f, 180f)]
		public float topLeftCornerDegree;

		[Label("右下")]
		[Range(-180f, 180f)]
		public float bottomRightCornerDegree;

		[Label("左下")]
		[Range(-180f, 180f)]
		public float bottomLeftCornerDegree;

		[Header("外周")]
		public Rect outerRect;

		[Label("敵消滅距離")]
		[Tooltip("この距離拠点から離れた敵は消滅する")]
		public float destroyDestance;

		[Label("強制バトル画面遷移")]
		public bool isTransitionBattle;

		[Tooltip("バトル開始時強制にスピードを1に変える")]
		public bool firstBattleFixSpeed;

		[Label("敵増加率(wave)")]
		[Tooltip("ウェーブの終わりにかけて最終的に何倍出てくるか。(リニア曲線)1なら変わらない")]
		[Range(0f, 1f)]
		public float enemyIncreaseWave;

		[Label("最低保証出力(デフォルト)")]
		[Tooltip("mstBlendでcraftSpeedが取得できないときに使う")]
		public double defaultMinOutputInterval;

		[Label("最低保証出力倍率")]
		[Tooltip("mstBlendData.craftSpeed * nが最低保証出力になる")]
		public float minSallyOutputIncrease;

		[Label("例外保証秒数")]
		public List<LuggageMinOutputSet> overwriteMinOutput;

		[Label("ネームド選択時バトル時間")]
		public int namedBattleTime;

		[Label("ボス戦ネームドマイナスLv")]
		[Range(0f, 5f)]
		public int bossNamedMinusLevel;

		[Header("範囲攻撃が弾に当たるかどうか")]
		public bool rangeHitBullet;

		[Header("マナ設定項目")]
		[Label("待機中入手機械p1")]
		[Tooltip("機械p入手秒数が有効なら入手可能。入手秒数当たりの入手量")]
		[Range(0f, 100f)]
		public float getCost1StandBy;

		[Label("待機中入手機械p2")]
		[Tooltip("機械p入手秒数が有効なら入手可能。入手秒数当たりの入手量")]
		[Range(0f, 100f)]
		public float getCost2StandBy;

		[Label("機械p入手秒数")]
		[Tooltip("0未満で無効")]
		public double getCostPointTime;

		[Label("最大マナ係数")]
		[Tooltip("この値x入手機械pがマナ上限")]
		public float limitManaCoefficient;

		[Label("最大キーン数")]
		public int limitKeen;

		[Label("最大緑研究ポイント")]
		public int limitResearchPoint;

		[Label("最大赤研究ポイント")]
		public int limitRedResearchPoint;

		[Header("ルートショップ")]
		[Label("ランダムにする")]
		public bool routeRandom;

		[Label("選択肢数")]
		public int routeChoiceCount;

		[Header("クリック攻撃オプション")]
		[Label("初期使用奇跡")]
		public eMiracle defaultUseMiracle;

		[Label("範囲攻撃")]
		public bool isClickRange;

		[Header("ステータス異常全体設定")]
		[Label("炎上頻度(s)")]
		public double fireDuration;

		[Label("炎上ダメージマイナス")]
		public int fireDamageMinus;

		[Label("炎上スタック上限")]
		public int fireStackLimit;

		[Label("凍結発動閾値")]
		[Tooltip("ユニットのstatusEffect.icePointがこの値になれば凍結が発動する")]
		public float iceThreshold;

		[Label("凍結時間")]
		public int iceTime;

		[Label("停止抵抗上昇値")]
		public float increaseStopResistance;

		[Label("石化ダメージ上昇率")]
		[Range(1f, 5f)]
		public float petrifactionDamageUpRate;

		[Header("敵全体設定")]
		[Label("Hpバー表示閾値")]
		[Tooltip("この値以上のHpを持つ敵が出現した場合Hpが表示される")]
		public int hpBarThreshold;

		[Label("敵同士が反発しあう間隔(s)")]
		[Tooltip("最適化項目")]
		public double collisionCheckEnemies;

		[Label("敵が拠点に向かい始める距離(2乗した値を記入)")]
		public float startTrackingDistance;

		[Header("その他")]
		[Label("ユニットのアウトライン(バトル時)")]
		public float defaultUnitOutline;

		[Header("集中")]
		[Label("集中スロー倍率")]
		[Range(0f, 1f)]
		public double longThinkingGear;

		[Label("集中実経過時間(s)")]
		[Tooltip("スローが終了するまでのゲーム内経過時間は[集中スロー倍率x集中実経過時間(s)]")]
		public float longThinkingTimeScale;

		[Label("集中回復数(初期値)")]
		public int longThinkHealCount;

		[Label("集中チャージタイム(s)")]
		public double longThinkChargeTime;

		[Label("集中中もチャージするか")]
		public bool isLongThinkingCharge;

		[Label("集中通知チャージタイム(%)")]
		[Range(0f, 1f)]
		[Tooltip("集中通知が最大の状態で何秒(長考チャージタイムのn%)待つと表示されるか")]
		public float putChargeTimeRatio;

		[Label("有効：集中時マナ増加")]
		[Tooltip("増えないのは時間経過によるマナ増加のみ")]
		public bool isConcentrationManaUp;

		[Label("有効：集中時生産数増加")]
		public bool isConcentrationManufactureUp;

		[Label("有効：集中時納品数増加")]
		public bool isConcentrationCountUp;

		[Label("有効：集中時Exp増加")]
		public bool isConcentrationExpUp;

		[Header("追加ステージ設定")]
		[Label("追加ウェーブ")]
		public List<AdditionalDivision> additionalStages;

		public eStageId ReadMainStage => default(eStageId);

		public bool ContainsOuterLine(Vector3 localPos)
		{
			return false;
		}

		public Vector3 RoundOuterLine(Vector3 localPos)
		{
			return default(Vector3);
		}

		public AdditionalDivision GetAddDivisionSetting(eStageDivision division)
		{
			return null;
		}
	}
}
