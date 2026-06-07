using System.Collections.Generic;
using System.Text;
using LitJson;

namespace Gh.Tk
{
	public abstract class GameItemCraftableBase : GameItem, IPatronRatable
	{
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		protected List<ValueModifier> _modifiers;

		[JsonIgnore]
		public new GameItemCraftableBaseTemplate Template
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		[JsonIgnore]
		public string Category => null;

		protected GameItemCraftableBase()
		{
		}

		public GameItemCraftableBase(GameItemCraftableBaseTemplate template, bool representsTemplate = false)
		{
		}

		public void SetPercentageModifier(string key, float factor, string displayReasonKey)
		{
		}

		protected abstract int GetCraftableTargetTier();

		protected float GetPercentageModifierFactor(StringBuilder details = null)
		{
			return 0f;
		}

		public void RecordStaffSkillModifier(ActorSkill skill)
		{
		}

		public virtual int GetPrice()
		{
			return 0;
		}

		public int GetTier()
		{
			return 0;
		}

		public virtual (int, string) GetOkPrice(string race, int tier, bool generateReason)
		{
			return default((int, string));
		}

		public virtual float GetEffectiveQuality(string race, int tier, StringBuilder details = null)
		{
			return 0f;
		}

		public virtual float GetExpectedQuality(string race, int tier)
		{
			return 0f;
		}
	}
}
