using System;
using Dhs5.Utility.Settings;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[Settings("Tabletop/Painting", Scope.Project)]
	public class PaintingSettings : CustomSettings<PaintingSettings>
	{
		[Serializable]
		private struct PaintingGameScoreFormula
		{
			[SerializeField]
			private int m_a;

			[SerializeField]
			private int m_b;

			[SerializeField]
			private int m_c;

			[SerializeField]
			private int m_d;

			[SerializeField]
			private float m_e;

			[SerializeField]
			private float m_f;

			public int GetScore(int circlesPassed, int consecutiveSuccess)
			{
				return (int)Mathf.Pow(m_a, (float)m_b + m_f * (float)consecutiveSuccess) + (int)((float)m_c + (float)m_d * Mathf.Pow(circlesPassed, m_e));
			}
		}

		[Serializable]
		private struct PaintingTableScoreBonuses
		{
			[SerializeField]
			[Range(0f, 1f)]
			private float m_lvl1Bonus;

			[SerializeField]
			[Range(0f, 1f)]
			private float m_lvl2Bonus;

			[SerializeField]
			[Range(0f, 1f)]
			private float m_lvl3Bonus;

			[SerializeField]
			[Range(0f, 1f)]
			private float m_lvl4Bonus;

			[SerializeField]
			[Range(0f, 1f)]
			private float m_lvl5Bonus;

			public float GetMultiplier(int tableLevel)
			{
				return tableLevel switch
				{
					1 => 1f + m_lvl1Bonus, 
					2 => 1f + m_lvl2Bonus, 
					3 => 1f + m_lvl3Bonus, 
					4 => 1f + m_lvl4Bonus, 
					5 => 1f + m_lvl5Bonus, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		[Serializable]
		private struct MaxPaintingScore
		{
			[SerializeField]
			private int m_maxScore;

			public void Refresh()
			{
				m_maxScore = ComputeMaxPaintingGameScore();
			}

			public static implicit operator int(MaxPaintingScore score)
			{
				return score.m_maxScore;
			}
		}

		[Serializable]
		private struct MiniaturePricingFormula
		{
			[SerializeField]
			private float m_a;

			[SerializeField]
			private float m_b;

			[SerializeField]
			private float m_c;

			[SerializeField]
			private float m_d;

			public float GetPrice(int score, float marketPrice)
			{
				return m_a + (1f + m_b) * marketPrice * (1f + m_c * Mathf.Pow(score, m_d));
			}
		}

		[Serializable]
		private struct PaintingTableMoneyBonuses
		{
			[SerializeField]
			[Range(0f, 1f)]
			private float m_lvl1Bonus;

			[SerializeField]
			[Range(0f, 1f)]
			private float m_lvl2Bonus;

			[SerializeField]
			[Range(0f, 1f)]
			private float m_lvl3Bonus;

			[SerializeField]
			[Range(0f, 1f)]
			private float m_lvl4Bonus;

			[SerializeField]
			[Range(0f, 1f)]
			private float m_lvl5Bonus;

			public float GetMultiplier(int tableLevel)
			{
				return tableLevel switch
				{
					1 => 1f + m_lvl1Bonus, 
					2 => 1f + m_lvl2Bonus, 
					3 => 1f + m_lvl3Bonus, 
					4 => 1f + m_lvl4Bonus, 
					5 => 1f + m_lvl5Bonus, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		[Header("Materials")]
		[SerializeField]
		private Material m_miniaturesPlasticMat;

		[SerializeField]
		private Material m_miniaturesLeadMat;

		[SerializeField]
		private Material m_miniaturesGoldMat;

		private static Material _miniatureCachedMat;

		private static int _texLerpFactorShaderProperty;

		public static int _paintProgressionShaderProperty;

		[Header("Collection UI")]
		[SerializeField]
		private float m_paintButtonPressTime = 3f;

		[Header("Painting Game")]
		[SerializeField]
		private int m_paintingGameActionCount = 6;

		[SerializeField]
		private int m_paintingGameMaxCirclesPassed = 5;

		[SerializeField]
		private int m_paintingGameMaxConsecutiveFail = 2;

		[Space(10f)]
		[SerializeField]
		[VectorRange(0f, 1f)]
		private Vector2 m_diskStartSize = new Vector2(0.5f, 0.75f);

		[SerializeField]
		[Range(0f, 1f)]
		private float m_diskSizeReducing = 0.1f;

		[Space(10f)]
		[SerializeField]
		private float m_diskShrinkStartDuration = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_diskNormalAcceleration = 0.2f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_diskFailAcceleration = 0.3f;

		[SerializeField]
		[Range(0.5f, 1f)]
		private float m_diskDurationGamepadMultiplicator = 0.9f;

		[Space(10f)]
		[SerializeField]
		private PaintingGameScoreFormula m_paintingGameScoreFormula;

		[SerializeField]
		private PaintingTableScoreBonuses m_tableScoreBonuses;

		[SerializeField]
		private MaxPaintingScore m_maxScore;

		[Header("Miniature Pricing")]
		[SerializeField]
		private MiniaturePricingFormula m_miniaturePricingFormula;

		[Header("Clients Money Generation")]
		[SerializeField]
		private float m_moneyGenFrequency = 1f;

		[SerializeField]
		private float m_moneyGenAmount = 0.5f;

		[SerializeField]
		private PaintingTableMoneyBonuses m_moneyGenBonuses;

		public static int TexLerpFactorShaderProperty
		{
			get
			{
				if (_texLerpFactorShaderProperty == 0)
				{
					_texLerpFactorShaderProperty = Shader.PropertyToID("_LocalTexLerpFactor");
				}
				return _texLerpFactorShaderProperty;
			}
		}

		public static int PaintProgressionShaderProperty
		{
			get
			{
				if (_paintProgressionShaderProperty == 0)
				{
					_paintProgressionShaderProperty = Shader.PropertyToID("_LocalPaintProgression");
				}
				return _paintProgressionShaderProperty;
			}
		}

		public static float PaintButtonPressTime => CustomSettings<PaintingSettings>.I.m_paintButtonPressTime;

		public static int PaintingGameActionsCount => CustomSettings<PaintingSettings>.I.m_paintingGameActionCount;

		public static int PaintingGameMaxCirclesPassed => CustomSettings<PaintingSettings>.I.m_paintingGameMaxCirclesPassed;

		public static int PaintingGameMaxConsecutiveFail => CustomSettings<PaintingSettings>.I.m_paintingGameMaxConsecutiveFail;

		public static Vector2 DiskStartSize => CustomSettings<PaintingSettings>.I.m_diskStartSize;

		public static float DiskSizeReducing => CustomSettings<PaintingSettings>.I.m_diskSizeReducing;

		public static float DiskShrinkStartDuration => CustomSettings<PaintingSettings>.I.m_diskShrinkStartDuration;

		public static float DiskNormalAcceleration => CustomSettings<PaintingSettings>.I.m_diskNormalAcceleration;

		public static float DiskFailAcceleration => CustomSettings<PaintingSettings>.I.m_diskFailAcceleration;

		public static float DiskDurationGamepadMultiplicator => CustomSettings<PaintingSettings>.I.m_diskDurationGamepadMultiplicator;

		public static float MoneyGenFrequency => CustomSettings<PaintingSettings>.I.m_moneyGenFrequency;

		public static Material GetMiniaturesUnpaintedMat(int rarity)
		{
			return MiniatureSettings.GetTypeFromRarity(rarity) switch
			{
				EMiniatureType.COMMON => CustomSettings<PaintingSettings>.I.m_miniaturesPlasticMat, 
				EMiniatureType.UNCOMMON => CustomSettings<PaintingSettings>.I.m_miniaturesLeadMat, 
				EMiniatureType.RARE => CustomSettings<PaintingSettings>.I.m_miniaturesGoldMat, 
				_ => null, 
			};
		}

		public static void SetCachedMaterial(Material mat)
		{
			_miniatureCachedMat = mat;
		}

		public static Material GetCachedMaterial()
		{
			return _miniatureCachedMat;
		}

		public static int ComputePaintingGameScore(UI_PaintingGame.Try paintingGameTry)
		{
			return Mathf.RoundToInt((float)CustomSettings<PaintingSettings>.I.m_paintingGameScoreFormula.GetScore(paintingGameTry.circlesPassed, paintingGameTry.consecutiveSuccess) * CustomSettings<PaintingSettings>.I.m_tableScoreBonuses.GetMultiplier(PaintingTable.CurrentlyUsedLevel));
		}

		private static int ComputeMaxPaintingGameScore()
		{
			int num = 0;
			for (int i = 0; i < PaintingGameActionsCount; i++)
			{
				num += CustomSettings<PaintingSettings>.I.m_paintingGameScoreFormula.GetScore(0, Mathf.Max(0, i));
			}
			return num;
		}

		public static int GetMaxPaintingGameScore()
		{
			return CustomSettings<PaintingSettings>.I.m_maxScore;
		}

		public static float GetPaintLerpFactorByScore(int score)
		{
			return 1f - (float)score / (float)GetMaxPaintingGameScore();
		}

		public static void SetMaterialValuesByScore(Material mat, int score)
		{
			mat.SetFloat(PaintProgressionShaderProperty, score);
			mat.SetFloat(TexLerpFactorShaderProperty, GetPaintLerpFactorByScore(score));
		}

		public static float GetMiniaturePrice(int score, float marketPrice)
		{
			if ((float)score <= 0f)
			{
				return marketPrice;
			}
			return CustomSettings<PaintingSettings>.I.m_miniaturePricingFormula.GetPrice(score, marketPrice);
		}

		public static float GetMoneyGenAmount(int tableLevel)
		{
			return CustomSettings<PaintingSettings>.I.m_moneyGenAmount * CustomSettings<PaintingSettings>.I.m_moneyGenBonuses.GetMultiplier(tableLevel);
		}
	}
}
