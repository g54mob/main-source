using Libs;
using UnityEngine;
using UnityEngine.Serialization;

public class FactorySettings : ScriptableObject
{
	public enum CursorGuideType
	{
		Off = 0,
		FollowCursor = 1,
		AvoidCursor = 2,
		FixCursor = 3
	}

	private bool _onValidate;

	[FormerlySerializedAs("defaultFactorySpeed")]
	[Header("標準工場速度(逆数)。1で1秒1マス(生産)、2で2秒1マス(生産)")]
	public double defaultFactoryReciprocalSpeed;

	[Header("設備速度。2で1秒2マス[m/s]")]
	public double defaultMineSpeed;

	public double defaultExtractorSpeed;

	public double defaultExtractorUptakeInkSpeed;

	public double defaultBeltSpeed;

	public double defaultBridgeConveyerSpeed;

	public double defaultCrossBridgeConveyerSpeed;

	public double defaultTeleporterSpeed;

	public double defaultCanvasSpeed;

	public double defaultCutterSpeed;

	public double defaultRepainterSpeed;

	public double defaultChuChuHouseSpeed;

	public double defaultMiracleOrbSpeed;

	public double defaultMixColorSpeed;

	public double defaultAlbedoSpeed;

	public double defaultInkBottleProcessorSpeed;

	public double defaultInkBottleReverseSpeed;

	public double defaultInkChangerSpeed;

	public double defaultColorCoatingSpeed;

	public double defaultSplitterSpeed;

	public double defaultCombinerSpeed;

	public double defaultInserterSpeed;

	public double defaultTemporaryTableSpeed;

	public double defaultEngineSpeed;

	public double defaultSweetsStorageSpeed;

	public double defaultSweetsSupplySpeed;

	public double defaultRecycleBoxSpeed;

	public double defaultRecycleFacilitySpeed;

	public double defaultCopierSpeed;

	public double defaultUniqueHeroGeneratorSpeed;

	public double defaultGoalSpeed;

	public double defaultTrashCanSpeed;

	public double defaultPipeSpeed;

	public double defaultBridgePipeSpeed;

	public double defaultManholeSpeed;

	public double defaultCrossPipeSpeed;

	public double defaultInversionPipeSpeed;

	public double defaultInkSprinklerSpeed;

	public double defaultInkCatcherSpeed;

	public double defaultCompositeSpeed;

	public double defaultStatueSpeed;

	public double defaultMineShaftSpeed;

	[Header("エリートミニオンの倍率")]
	public double defaultEliteMinionSpeed;

	[Header("パレットの初期の回転")]
	public Dir.Rot defaultPaletteRot;

	[Header("液体容量関連")]
	public double defaultPipeCapacity;

	public double defaultBridgePipeCapacity;

	public double defaultUptakeInkCapacity;

	public double defaultInkBottleProcessorCapacity;

	public double defaultInkBottleReverseCapacity;

	public double defaultColorCoatingCapacity;

	public double defaultCanvasInkTankCapacity;

	[Space]
	[Tooltip("※液体変換効率の下限を下げるなら、中間タンクの拡大が必要")]
	public double defaultMixColorCapacity;

	[Space]
	public double defaultAlbedoCapacity;

	public double defaultInkChangerCapacity;

	public double defaultInkEngineCapacity;

	public double defaultManholeCapacity;

	public double defaultCrossPipeCapacity;

	public double defaultInversionPipeCapacity;

	public double defaultCompositeCapacity;

	[Header("ボトル詰め関連")]
	[Tooltip("インク消費効率")]
	public double defaultInkBottleProcessorInkParBottle;

	public double defaultInkBottleReverseInkParBottle;

	[Tooltip("キャンバスがボトルに変換するインク量")]
	public double defaultCanvasInkParBottle;

	[Tooltip("(廃止)キャンバスがインクを吸う速度")]
	public double defaultCanvasInkSuckSpeed;

	[Header("インクエンジン関連")]
	[FormerlySerializedAs("defaultInkEngineBoostAdd")]
	[Tooltip("機械に与えるブースト。\nAddなので、0.3なら1.3倍、1なら2倍")]
	public double inkEngineBoostAdd;

	[Tooltip("インクエンジン効率、100%にならないと無駄に消費してる状態")]
	public double inkEngineBoostEfficiency;

	[FormerlySerializedAs("defaultInkEngineInkSuckSpeed")]
	[Tooltip("(廃止)インクエンジンが燃料を吸う速度")]
	public double inkEngineInkSuckSpeed;

	[Header("スイーツ関連")]
	[FormerlySerializedAs("defaultSweetsSupplyBoostAdd")]
	[Tooltip("機械に与えるブースト。\nAddなので、0.3なら1.3倍、1なら2倍")]
	public double sweetsSupplyBoostAdd;

	[FormerlySerializedAs("defaultSweetsSupplyBoostRectLength")]
	[Tooltip("影響範囲、2ならxy:-2~+2の矩形範囲")]
	public int sweetsSupplyBoostRectLength;

	[FormerlySerializedAs("defaultSweetsSupplyBoostEfficiency")]
	[Tooltip("スイーツ供給効率、100%にならないと無駄に消費してる状態")]
	public double sweetsSupplyBoostEfficiency;

	[FormerlySerializedAs("defaultSweetsSupplyCapacity")]
	[Tooltip("食事処にスイーツが何個貯められるか")]
	public double sweetsSupplyCapacity;

	[FormerlySerializedAs("defaultSweetsStockMax")]
	[Tooltip("ストレージに何個貯められるか")]
	public int sweetsStorageStockMax;

	[Tooltip("受け入れるスイーツの種類")]
	public eLuggage[] sweetsList;

	[Tooltip("スイーツごとのブースト率")]
	public double[] sweetsBoostAddList;

	public int inkSprinklerRectLength;

	public double inkCatcherCapacity;

	public double defaultInkSprinklerCapacity;

	[Header("リサイクル関連")]
	[Tooltip("リサイクルされる数10なら10消費ごとに1リサイクル")]
	public int recycleCounter;

	[Tooltip("リサイクル場に貯めておけるLuggage数")]
	public int recycleFacilitySize;

	[Header("混色機効率アップ")]
	[Tooltip("混色機効率、100%にならないと無駄に消費してる状態")]
	public double defaultMixColorEfficiency;

	[Header("アルベドメーカー効率アップ")]
	[Tooltip("アルベドメーカー効率、100%にならないと無駄に消費してる状態")]
	public double defaultAlbedoEfficiency;

	[Header("インク変換機必要入力割合")]
	public int defaultInkChangerEfficiencySrc;

	[Header("インク変換機出力割合")]
	public int defaultInkChangerEfficiencyDst;

	[Header("並列回路：バフレート")]
	public double smartParallelCircuitBuffRate;

	[Header("並列回路：減衰率")]
	public double smartParallelCircuitAttenuationRate;

	[Header("選定の剣：死亡レート")]
	public double defaultSwordOfChoiceRate;

	[Header("追加ポータル設置確率")]
	public double extraPortalRate;

	[Header("追加チューチューハウス設置確率")]
	public double extraChuChuRate;

	[Header("ミニオン複数配置関連")]
	public double[] defaultMinionPowersDrawmotif;

	public double[] defaultMinionPowersUptakeInk;

	public double[] defaultMinionPowersCanvas;

	public double[] defaultMinionPowersCutter;

	public double[] defaultMinionPowersInkBottleProcessor;

	public double[] defaultMinionPowersMixColor;

	public double[] defaultMinionPowersChuChuHouse;

	public double[] defaultMinionPowersMiracleOrb;

	[Header("インサーターのアニメーションのTimeline。順に「ピックアップ時間」「運ぶ時間」「インサート時間」「戻る時間」")]
	public double[] inserterAnimationTimeline;

	[Header("旧フルエリアマップをロードする")]
	public bool loadFullAreaMap;

	[Header("Waveまたぎ回収時もマナ")]
	public bool repurchaseMana;

	[Header("Waveまたぎ回収時マナ割合")]
	public float repurchaseManaRate;

	[Header("Waveまたぎ回収時マナ100%機械")]
	public eMachine[] repurchaseMana100List;

	[Header("マウスオーバーが開くまでの秒数")]
	public float fieldMouseOverOpenWait;

	[Header("コンベアとパイプのマウスオーバーが開くまでの秒数")]
	public float fieldMouseOverOpenWaitForStream;

	[Header("選択解除状態だと即時マウスオーバー")]
	public bool fieldMouseOverAlwaysMode;

	[Header("稼働率を100%とする閾値(0.9 = value>90%のとき100%)")]
	public float fieldMouseOverUtilizationRoundUpValue;

	[Header("機会損失率を0%とする閾値(0.1 = value<10%のとき0%)")]
	public float fieldMouseOverOutputPortUtilizationRoundDownValue;

	[Header("分配機機能開放アタッチメント")]
	public eAttachment unlockSplitterAllFilter;

	public eAttachment unlockSplitterAllPriority;

	public eAttachment unlockSplitterNormalFilter;

	public eAttachment unlockSplitterNormalPriority;

	public eAttachment unlockSplitterTshapedFilter;

	public eAttachment unlockSplitterTshapedPriority;

	[Header("カーソル操作ガイドのタイプ")]
	public CursorGuideType cursorGuideType;

	[Header("FollowCursor時のオフセット位置")]
	public Vector2 cursorGuideFollowTypePivot;

	[Header("FixCursor時の固定位置")]
	public Vector2 cursorGuideFixTypePivot;

	[Header("長押し削除時の時間")]
	public double removeTimer;

	[Header("長押し設置時の時間")]
	public double longPushTimer;

	[Header("稼働率計算用ログサイズ")]
	public int defaultUtilizationLogSize;

	[Header("詰まりアイコン計算用ログサイズ")]
	public int jamLogSize;

	[FormerlySerializedAs("utilizationAve12")]
	[Header("詰まりアイコン計算用詰まり判定平均稼働率１段階目")]
	public double jamUtilizationAve12;

	[FormerlySerializedAs("utilizationAve34")]
	[Header("詰まりアイコン計算用詰まり判定平均稼働率２段階目")]
	public double jamUtilizationAve34;

	[Header("詰まりアイコン計算用詰まり判定直近時間１段階目")]
	public double jamNowRate12;

	[Header("詰まりアイコン計算用詰まり判定直近時間２段階目")]
	public double jamNowRate34;

	[Header("詰まりアイコン(インク)計算用ログサイズ")]
	public int jamInkLogSize;

	[Header("(旧)詰まりアイコン(インク)計算用詰まり判定割合１段階目")]
	public double jamInkExhaustionRate12;

	[Header("(旧)詰まりアイコン(インク)計算用詰まり判定割合２段階目")]
	public double jamInkExhaustionRate34;

	[Header("インク不足アイコンバー計算用青ゲージ出現判定割合")]
	public double inkEmptyBarFeedRate12;

	[Header("インク不足アイコンバー計算用赤アイコン出現判定割合")]
	public double inkEmptyBarFeedRate34;

	[Header("支払い有効ミニオン労働コスト")]
	public bool paymentWorkerCostMinion;

	[Header("ミニオン労働コスト")]
	public int workerCostMinion;

	[Header("エリートミニオン労働コスト")]
	public int workerCostEliteMinion;

	[Header("スポイト（抽出機）擬似稼働サイクル")]
	public double uptakeInkPseudoOperationCycle;

	[Header("魂の祭壇：基礎速度")]
	public double defaultAltarOfSpiritSpeed;

	[Header("魂の祭壇：ユニットとパーツの処理速度係数")]
	public double altarOfSpiritUnitSpeed;

	[Header("魂の祭壇：資源の処理速度係数")]
	public double altarOfSpiritShigenSpeed;

	[Header("魂の祭壇：インク資源のエネルギー係数(float)")]
	public float altarOfSpiritShigenInkEnergyRate;

	[Header("魂の祭壇：条件達成後の１納品あたりのブースト秒数")]
	public double altarOfSpiritBoostTime;

	[Header("魂の祭壇：パーティクルの秒数")]
	public float altarOfSpiritParticleDuration;

	[Header("量産機械：値引率")]
	public double massProductionDiscountRate;

	[Header("量産機械：最大値引率")]
	public double massProductionDiscountRateMax;

	[Header("鉱山：必要量増加率")]
	public double mineshaftIncreaseRateOfDemand;

	public bool IsOnValidate()
	{
		return false;
	}
}
