using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

namespace ScriptableObjects.ScriptableObjectScripts.Settings
{
	public class RewardSetting : ScriptableObject
	{
		[Serializable]
		public struct AdditionalPoint
		{
			public ePointType type;

			public int value;

			public AdditionalPoint(ePointType type, int value)
			{
				this.type = default(ePointType);
				this.value = 0;
			}
		}

		[Serializable]
		public struct FirstFixRecipe
		{
			public eWriterId writer;

			public List<eLuggage> fixLuggages;
		}

		public enum ResourceTag
		{
			None = 0,
			PrimitiveMotifSmall = 1,
			PrimitiveMotifNormal = 2,
			PrimitiveMotifLarge = 3,
			SemiMotifSmall32 = 4,
			InkSmall12 = 5,
			InkNormal23 = 6,
			InkLarge33 = 7,
			StarOrHeart = 8
		}

		[Serializable]
		public class ResourcePoolSetting
		{
			public eStageId stageId;

			[Label("レアリティ")]
			[Tooltip("付けてないときはノーマルからしか選出されない")]
			public bool useRarity;

			[Label("レアが出る確率(%)")]
			[Range(0f, 1f)]
			public float rareRate;

			[Label("取得できるモチーフソースのプール(ノーマル)")]
			public List<ResourceTag> getableMotifSourcesTag;

			[Label("取得できるモチーフソースのプール(レア)")]
			public List<ResourceTag> getableRareMotifSourcesTag;

			[Label("取得できるインクだまりのプール(ノーマル)")]
			public List<ResourceTag> getableInkSourceTag;

			[Label("取得できるインクだまりのプール(レア)")]
			public List<ResourceTag> getableRareInkSourceTag;

			[Label("その他(ノーマル)")]
			public List<eMachine> getOtherSourcePool;

			[Label("その他(レア)")]
			public List<eMachine> getRareOtherSourcePool;

			public List<eMachine> GetNormalMotifResources => null;

			public List<eMachine> GetRareMotifResources => null;

			public List<eMachine> GetNormalInkResources => null;

			public List<eMachine> GetRareInkResources => null;

			public List<eMachine> GetNormalAll()
			{
				return null;
			}

			public List<eMachine> GetRareAll()
			{
				return null;
			}

			private List<eMachine> ConvertResourceTagToMachine(List<ResourceTag> tags)
			{
				return null;
			}
		}

		[Header("報酬関連")]
		[Label("エリート撃破時報酬")]
		public List<eUpgradePack> eliteEliminationReward;

		[Label("ネームドクリア時追加ポイント")]
		public List<AdditionalPoint> clearBonusPoints;

		[Label("ネームドクリア時のマナ倍率(n倍)")]
		[Range(1f, 10f)]
		public float clearNamedManaIncrease;

		[Label("ボス撃破時追加ポイント")]
		public List<AdditionalPoint> defeatBonusPoints;

		[Label("ノープール時スキップ報酬")]
		[Tooltip("全報酬共通。[ePoint,int...]の繰り返しのフォーマットで入力")]
		public List<string> noPoolSkipBonus;

		[Label("生産速度アップ")]
		[Tooltip("UnitのLevelUpするごとに上からx+1の値が生産速度になる")]
		public double[] speedUpRateByLevel;

		[Label("初期解放可能スキルレベル")]
		[Tooltip("0の時がユニットの初期状態で何のバフも発動しない")]
		[Range(0f, 10f)]
		public int initialOpenSkillLevel;

		[Label("ヒーロー情報自動切換え時間(s)")]
		public float infoToggleTime;

		[Header("レベルアップ設定")]
		[Label("付与研究ポイント")]
		public int levelupGetGreenResearch;

		[Label("付与キーン")]
		public int levelupGetKeen;

		[Label("レベルアップマナ上昇率")]
		[Range(0f, 1f)]
		public float levelupManaIncreaseRatio;

		[Label("レベルごとのマナ取得上昇率")]
		[Range(0f, 1f)]
		public float levelPerManaIncrease;

		[Label("レア出現率")]
		[Range(0f, 1f)]
		public float lvupRarePercent;

		[Label("最大レア出現数")]
		public int maxLvupRare;

		[Header("マスター初回プレイ時報酬")]
		public List<FirstFixRecipe> firstFixRecipes;

		[Header("資源取得時のプール設定")]
		public List<ResourcePoolSetting> resourcePools;

		[Header("資源取得時のプール設定")]
		public List<ResourcePoolSetting> resourceStarOrHeartPools;

		[Header("ヒーロー報酬でレシピが出現する確率")]
		[Range(0f, 1f)]
		public float heroRewardRecipeRatio;

		[Header("エンドレス時の安全地帯ステップ数(どんな値でも最初は安全地帯)")]
		public int endlessRareRestStep;
	}
}
