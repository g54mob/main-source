using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterSkillCardsManager
	{
		private List<CharacterSkillCard_Base> _characterCards;

		public List<CharacterSkillCard_Base> ActiveCards => null;

		public void AddCharacterCard(CharacterSkillCard_Base card)
		{
		}

		public void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
		{
		}

		public void OnOwnerLevelUpSkipped()
		{
		}

		public void OnOwnerGetDamaged(float damageAmount)
		{
		}

		public void OnOwnerCriticalHPTreshold(float rawValue)
		{
		}

		public void OnOwnerLevelUp()
		{
		}

		public void UpdateCards()
		{
		}

		public static List<SkillCardEdition> GetSpecialEditions(int cardCount, ref Random random)
		{
			return null;
		}

		public static List<SkillCardEdition> GetRandomEditions(int totalCardsInDraft, ref Random random)
		{
			return null;
		}

		public static SkillCardEdition GetWeightedEdition(ref Random random, float wBase = 75f, float wFoil = 4f, float wGala = 4f, float wHolo = 7f, float wPoly = 7f, float wInve = 3f)
		{
			return default(SkillCardEdition);
		}

		public static float GetSurvarotDifficultyMultiplier()
		{
			return 0f;
		}

		public static float AdjustAdditionalEnemiesHPMultiplierWithINVE(float currentMul)
		{
			return 0f;
		}

		public static CharacterSkillCard_Base GetCardForArcanaType(ArcanaType arcanaType)
		{
			return null;
		}

		public static float SvMult_AnyRare()
		{
			return 0f;
		}

		public static float SvMult_Foil()
		{
			return 0f;
		}

		public static float SvMult_Gala()
		{
			return 0f;
		}

		public static float SvMult_Poly()
		{
			return 0f;
		}

		public static float SvMult_Holo()
		{
			return 0f;
		}

		public static float SvMult_Inve()
		{
			return 0f;
		}

		public static float SvMult_Base()
		{
			return 0f;
		}
	}
}
