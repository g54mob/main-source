using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterSkillCard_Base
	{
		public CharacterController LinkedCharacter;

		public int AccumulatedLevels;

		public List<Dictionary<int, ModifierStats>> ModifierStatsMaps;

		public List<CharacterSkillCard_Base> SubCards;

		public ModifierStats OnEveryLevelUp;

		public int Rarity;

		public int AvailableSlots;

		public ModifierStats InitialBonus;

		public ArcanaType Type;

		public SkillCardEdition Edition;

		public float InitialRunEnemies;

		public float InitialRunCoins;

		public float InitialRunRunBossesCount;

		private int currentBonusIndex;

		private int currentExtraStacks;

		private int currentBonusIndex_Gold;

		private int currentExtraStacks_Gold;

		public virtual ArcanaType GalaType => default(ArcanaType);

		public virtual List<ArcanaType> FoilTypes => null;

		protected virtual int[] bonusTresholds => null;

		protected virtual int[] bonusTresholds_Gold => null;

		public CharacterSkillCard_Base(ArcanaType type)
		{
		}

		public void SetEdition(SkillCardEdition edition, bool activateEdition = true)
		{
		}

		public virtual void SetLinkedCharacter(CharacterController character)
		{
		}

		public virtual void InitialActivate()
		{
		}

		public virtual void OnOwnerLevelUp()
		{
		}

		public virtual void Update()
		{
		}

		public virtual void OnOwnerRevived(float percentage = 1f, bool instantRevival = false)
		{
		}

		public virtual void OnOwnerGetDamaged(float damageAmount)
		{
		}

		public virtual void OnOwnerCriticalHPTreshold(float rawValue)
		{
		}

		public virtual void OnOwnerLevelUpSkipped()
		{
		}

		protected virtual void OnEnemiesCountReached()
		{
		}

		protected virtual void OnGoldCountReached()
		{
		}

		protected void Update_CountEnemies()
		{
		}

		protected void Update_CountGold()
		{
		}

		protected void AddSubCard(ArcanaType type)
		{
		}

		protected void AddSubCard(CharacterSkillCard_Base subCard)
		{
		}

		public virtual void SetRarity(int rarity)
		{
		}

		private void ActivateSpecialEdition()
		{
		}

		private void MultiplyAllStats(float multiplier)
		{
		}

		protected virtual void OnActivate_Foil()
		{
		}

		protected virtual void OnActivate_Gala()
		{
		}

		protected float GetBonusMultiplier()
		{
			return 0f;
		}

		protected void AddRandomProgressiveBonus()
		{
		}

		protected void AddRandomInitialBonus()
		{
		}

		protected void AddRandomPerLevelBonus()
		{
		}
	}
}
