using System;
using System.Collections.Generic;
using Dhs5.Utility.Settings;
using I2.Loc;
using Simulator.GameWorld;
using UnityEngine;
using UnityEngine.VFX;

namespace Tabletop.GameWorld
{
	[Settings("Tabletop/Wargame", Scope.Project)]
	public class WargameSettings : CustomSettings<WargameSettings>
	{
		[Serializable]
		private struct WargameTableMoneyBonuses
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

		[Header("Tutorial")]
		[SerializeField]
		private TutorialData m_squadTutorialData;

		[SerializeField]
		private TutorialData m_playTutorialData;

		[Header("Opponent")]
		[SerializeField]
		private float m_seatAnimationDuration = 3f;

		[Header("Dices")]
		[SerializeField]
		private Sprite[] m_playerDiceSprites;

		[SerializeField]
		private Sprite[] m_opponentDiceSprites;

		[SerializeField]
		private int[] m_diceFaces;

		[Space(10f)]
		[SerializeField]
		private WargameSkillEffect m_dice1Effect;

		[SerializeField]
		private WargameSkillEffect m_dice2Effect;

		[SerializeField]
		private WargameSkillEffect m_dice3Effect;

		[Header("Squads")]
		[SerializeField]
		private int m_squadSize;

		[SerializeField]
		private int m_maxArmyBySquad;

		[Header("Skills")]
		[SerializeField]
		[Range(1f, 5f)]
		private int m_diceByCondition;

		[Header("Tokens")]
		[SerializeField]
		private bool m_useTokens;

		[SerializeField]
		private int m_startToken;

		[SerializeField]
		private int m_damagePerToken;

		[Header("Start")]
		[SerializeField]
		private EWargameFirstPlayer m_firstPlayer;

		[Header("Rounds")]
		[SerializeField]
		private int m_roundCount;

		[Header("Instructions")]
		[SerializeField]
		private EnumValues<EWargameInstruction, LocalizedString> m_instructions;

		[Header("Dice Phase")]
		[SerializeField]
		private bool m_allowIncompleteValidation;

		[SerializeField]
		private bool m_playAtTheSameTime;

		[SerializeField]
		private int m_diceThrown;

		[SerializeField]
		private int m_diceKept;

		[SerializeField]
		private int m_initialAssault;

		[SerializeField]
		private int m_initialDamage;

		[SerializeField]
		private int m_rethrow;

		[Header("Combat Phase")]
		[Tooltip("Delay between effect trigger")]
		[SerializeField]
		private float m_delayBetweenEffectTrigger = 0.5f;

		[Tooltip("Delay between miniature activation")]
		[SerializeField]
		private float m_delayBetweenMiniatureActivation = 1.5f;

		[Tooltip("Delay between players miniature activation phase")]
		[SerializeField]
		private float m_delayBetweenPlayers = 2f;

		[Tooltip("Delay before declaring the round winner")]
		[SerializeField]
		private float m_delayBeforeRoundWinner = 2f;

		[Tooltip("Delay before activating the round result effects")]
		[SerializeField]
		private float m_delayBeforeRoundResultEffects = 2f;

		[Tooltip("Delay before activating the tokens of the round winner")]
		[SerializeField]
		private float m_delayBeforeTokensActivation = 2f;

		[Tooltip("Delay between token activations")]
		[SerializeField]
		private float m_delayBetweenTokenActivation = 0.5f;

		[Tooltip("Delay before applying the round damages")]
		[SerializeField]
		private float m_delayBeforeDamageApplication = 2f;

		[Tooltip("Delay before applying PV to 0 effects")]
		[SerializeField]
		private float m_delayBeforePVTo0Effects = 2f;

		[Tooltip("Delay between rounds")]
		[SerializeField]
		private float m_delayBetweenRounds = 1f;

		[Header("Visuals")]
		[SerializeField]
		private Color m_playerActivationColor;

		[SerializeField]
		private Color m_opponentActivationColor;

		[Header("Banner")]
		[SerializeField]
		private Sprite m_victoryBannerSprite;

		[SerializeField]
		private Sprite m_defeatBannerSprite;

		[Header("Results")]
		[SerializeField]
		private float m_moneyForVictory;

		[SerializeField]
		private MiniatureRarityModifier m_pieceForVictory;

		[Header("Preview")]
		[SerializeField]
		private Color m_previewTextColor;

		[Header("AI Squads")]
		[SerializeField]
		private List<WargameSquad> m_squads;

		[SerializeField]
		[VectorRange(0f, 5f)]
		private Vector2Int m_minimumActivations = new Vector2Int(2, 4);

		[Header("3D Dices")]
		[SerializeField]
		private float m_draggingDiceDistanceToCamera;

		[SerializeField]
		private GameObject m_dicePrefab;

		[SerializeField]
		private GameObject m_opponentDicePrefab;

		[Space(10f)]
		[SerializeField]
		private Vector3[] m_diceRotationForEachFace;

		[SerializeField]
		private float m_diceThrowDuration;

		[SerializeField]
		private float m_diceThrowPower;

		[SerializeField]
		private float m_diceThrowJumpDurationOffset;

		[SerializeField]
		private AnimationCurve m_diceThrowJumpEase;

		[SerializeField]
		private AnimationCurve m_diceThrowRotationEase;

		[SerializeField]
		private int m_diceThrowNumberOfJumps;

		[SerializeField]
		private int m_diceThrowNumberOfTurns;

		[SerializeField]
		[VectorRange(0f, 1f)]
		private Vector2 m_diceThrowRandomisation;

		[Header("Miniatures")]
		[SerializeField]
		[Range(0.01f, 0.1f)]
		private float m_miniatureScale;

		[SerializeField]
		[Layer]
		private int m_miniatureLayer;

		[Space(10f)]
		[SerializeField]
		private Color m_activeMiniatureColor;

		[SerializeField]
		private Color m_hoverMiniatureOutlineColor;

		[SerializeField]
		private Color m_hoverDiceOutlineColor;

		[Space(10f)]
		[SerializeField]
		private Vector3[] m_playerTooltipsPositions;

		[SerializeField]
		private Vector3[] m_opponentTooltipsPositions;

		[Header("Prefabs")]
		[SerializeField]
		private GameObject m_miniatureTooltipPrefab;

		[Header("Vfxs")]
		[SerializeField]
		private VisualEffect m_miniatureVfxPrefab;

		[Header("Clients Money Generation")]
		[SerializeField]
		private float m_moneyGenFrequency = 1f;

		[SerializeField]
		private float m_moneyGenAmount = 0.5f;

		[SerializeField]
		private WargameTableMoneyBonuses m_moneyGenBonuses;

		public static TutorialData SquadTutorialData => CustomSettings<WargameSettings>.I.m_squadTutorialData;

		public static TutorialData PlayTutorialData => CustomSettings<WargameSettings>.I.m_playTutorialData;

		public static float SeatAnimationDuration => CustomSettings<WargameSettings>.I.m_seatAnimationDuration;

		public static WargameSkillEffect Dice2Effect => CustomSettings<WargameSettings>.I.m_dice2Effect;

		public static WargameSkillEffect Dice3Effect => CustomSettings<WargameSettings>.I.m_dice3Effect;

		public static int SquadSize => CustomSettings<WargameSettings>.I.m_squadSize;

		public static int MaxArmyBySquad => CustomSettings<WargameSettings>.I.m_maxArmyBySquad;

		public static int DiceByCondition => CustomSettings<WargameSettings>.I.m_diceByCondition;

		public static bool UseTokens => CustomSettings<WargameSettings>.I.m_useTokens;

		public static int StartToken => CustomSettings<WargameSettings>.I.m_startToken;

		public static int DamagePerToken => CustomSettings<WargameSettings>.I.m_damagePerToken;

		public static EWargameFirstPlayer FirstPlayer => CustomSettings<WargameSettings>.I.m_firstPlayer;

		public static int RoundCount => CustomSettings<WargameSettings>.I.m_roundCount;

		public static bool AllowIncompleteValidation => CustomSettings<WargameSettings>.I.m_allowIncompleteValidation;

		public static bool PlayAtTheSameTime => CustomSettings<WargameSettings>.I.m_playAtTheSameTime;

		public static int DiceThrown => CustomSettings<WargameSettings>.I.m_diceThrown;

		public static int DiceKept => CustomSettings<WargameSettings>.I.m_diceKept;

		public static int InitialAssault => CustomSettings<WargameSettings>.I.m_initialAssault;

		public static int InitialDamage => CustomSettings<WargameSettings>.I.m_initialDamage;

		public static int Rethrow => CustomSettings<WargameSettings>.I.m_rethrow;

		public static float DelayBetweenEffectTrigger => CustomSettings<WargameSettings>.I.m_delayBetweenEffectTrigger;

		public static float DelayBetweenMiniatureActivation => CustomSettings<WargameSettings>.I.m_delayBetweenMiniatureActivation;

		public static float DelayBetweenPlayers => CustomSettings<WargameSettings>.I.m_delayBetweenPlayers;

		public static float DelayBeforeRoundWinner => CustomSettings<WargameSettings>.I.m_delayBeforeRoundWinner;

		public static float DelayBeforeRoundResultEffects => CustomSettings<WargameSettings>.I.m_delayBeforeRoundResultEffects;

		public static float DelayBeforeTokensActivation => CustomSettings<WargameSettings>.I.m_delayBeforeTokensActivation;

		public static float DelayBetweenTokenActivation => CustomSettings<WargameSettings>.I.m_delayBetweenTokenActivation;

		public static float DelayBeforeDamageApplication => CustomSettings<WargameSettings>.I.m_delayBeforeDamageApplication;

		public static float DelayBeforePVTo0Effects => CustomSettings<WargameSettings>.I.m_delayBeforePVTo0Effects;

		public static float DelayBetweenRounds => CustomSettings<WargameSettings>.I.m_delayBetweenRounds;

		public static Color PlayerActivationColor => CustomSettings<WargameSettings>.I.m_playerActivationColor;

		public static Color OpponentActivationColor => CustomSettings<WargameSettings>.I.m_opponentActivationColor;

		public static float MoneyForVictory => CustomSettings<WargameSettings>.I.m_moneyForVictory;

		public static MiniatureRarityModifier PieceForVictoryRarityModifier => CustomSettings<WargameSettings>.I.m_pieceForVictory;

		public static Color PreviewTextColor => CustomSettings<WargameSettings>.I.m_previewTextColor;

		public static int MinimumActivations => CustomSettings<WargameSettings>.I.m_minimumActivations.GetRandomInRange(maxInclusive: true);

		public static float DraggingDiceDistanceToCamera => CustomSettings<WargameSettings>.I.m_draggingDiceDistanceToCamera;

		public static GameObject DicePrefab => CustomSettings<WargameSettings>.I.m_dicePrefab;

		public static GameObject OpponentDicePrefab => CustomSettings<WargameSettings>.I.m_opponentDicePrefab;

		public static float DiceThrowPower => CustomSettings<WargameSettings>.I.m_diceThrowPower;

		public static float DiceThrowJumpDurationOffset => CustomSettings<WargameSettings>.I.m_diceThrowJumpDurationOffset;

		public static AnimationCurve DiceThrowJumpEase => CustomSettings<WargameSettings>.I.m_diceThrowJumpEase;

		public static AnimationCurve DiceThrowRotationEase => CustomSettings<WargameSettings>.I.m_diceThrowRotationEase;

		public static int DiceThrowNumberOfJumps => CustomSettings<WargameSettings>.I.m_diceThrowNumberOfJumps;

		public static int DiceThrowNumberOfTurns => CustomSettings<WargameSettings>.I.m_diceThrowNumberOfTurns;

		public static float MiniatureScale => CustomSettings<WargameSettings>.I.m_miniatureScale;

		public static int MiniatureLayer => CustomSettings<WargameSettings>.I.m_miniatureLayer;

		public static Color ActiveMiniatureColor => CustomSettings<WargameSettings>.I.m_activeMiniatureColor;

		public static Color HoverMiniatureOutlineColor => CustomSettings<WargameSettings>.I.m_hoverMiniatureOutlineColor;

		public static Color HoverDiceOutlineColor => CustomSettings<WargameSettings>.I.m_hoverDiceOutlineColor;

		public static GameObject MiniatureTooltipPrefab => CustomSettings<WargameSettings>.I.m_miniatureTooltipPrefab;

		public static VisualEffect MiniatureVfxPrefab => CustomSettings<WargameSettings>.I.m_miniatureVfxPrefab;

		public static float MoneyGenFrequency => CustomSettings<WargameSettings>.I.m_moneyGenFrequency;

		public static Sprite GetPlayerDiceSprite(int index)
		{
			if (CustomSettings<WargameSettings>.I.m_playerDiceSprites.IsIndexValid(index - 1))
			{
				return CustomSettings<WargameSettings>.I.m_playerDiceSprites[index - 1];
			}
			return null;
		}

		public static Sprite GetOpponentDiceSprite(int index)
		{
			if (CustomSettings<WargameSettings>.I.m_opponentDiceSprites.IsIndexValid(index - 1))
			{
				return CustomSettings<WargameSettings>.I.m_opponentDiceSprites[index - 1];
			}
			return null;
		}

		public static int GetRandomDiceFace()
		{
			return CustomSettings<WargameSettings>.I.m_diceFaces.GetRandom();
		}

		public static WargameSkillEffect GetDiceEffect(int value)
		{
			return value switch
			{
				1 => CustomSettings<WargameSettings>.I.m_dice1Effect, 
				2 => CustomSettings<WargameSettings>.I.m_dice2Effect, 
				3 => CustomSettings<WargameSettings>.I.m_dice3Effect, 
				_ => null, 
			};
		}

		public static string GetInstructionTerm(EWargameInstruction instruction)
		{
			return CustomSettings<WargameSettings>.I.m_instructions[instruction].mTerm;
		}

		public static Sprite GetBannerSpriteForResult(EWargameResult result)
		{
			return result switch
			{
				EWargameResult.PLAYER_A => CustomSettings<WargameSettings>.I.m_victoryBannerSprite, 
				EWargameResult.PLAYER_B => CustomSettings<WargameSettings>.I.m_defeatBannerSprite, 
				_ => CustomSettings<WargameSettings>.I.m_victoryBannerSprite, 
			};
		}

		public static WargameSquad GetRandomSquad()
		{
			return CustomSettings<WargameSettings>.I.m_squads.GetRandom();
		}

		public static Vector3 GetDiceRotationForFace(int face)
		{
			return CustomSettings<WargameSettings>.I.m_diceRotationForEachFace[face - 1];
		}

		public static float GetDiceThrowDuration()
		{
			return CustomSettings<WargameSettings>.I.m_diceThrowRandomisation.GetRandomInRange() * CustomSettings<WargameSettings>.I.m_diceThrowDuration;
		}

		public static Vector3 GetMiniatureTooltipPosition(bool belongToPlayer, int index)
		{
			if (belongToPlayer)
			{
				return CustomSettings<WargameSettings>.I.m_playerTooltipsPositions[index];
			}
			return CustomSettings<WargameSettings>.I.m_opponentTooltipsPositions[index];
		}

		public static float GetMoneyGenAmount(int tableLevel)
		{
			return CustomSettings<WargameSettings>.I.m_moneyGenAmount * CustomSettings<WargameSettings>.I.m_moneyGenBonuses.GetMultiplier(tableLevel);
		}
	}
}
