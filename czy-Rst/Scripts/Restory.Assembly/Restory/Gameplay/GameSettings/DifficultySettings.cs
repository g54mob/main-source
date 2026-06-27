using System;
using UnityEngine;
using UnityEngine.Events;

namespace Restory.Gameplay.GameSettings
{
	[Serializable]
	public sealed class DifficultySettings : ICloneable, IReadOnlyDifficultySettings
	{
		private static readonly int NormalValue = new DifficultySettings(CozyLevel.Domestic).GetValue();

		[SerializeField]
		private SpeedHunger speedHunger;

		[SerializeField]
		private NumberWeeds numberWeeds;

		[SerializeField]
		private NumberLeeches numberLeeches;

		[SerializeField]
		private LeechBehavior leechBehavior;

		[SerializeField]
		private InfectionDamage infectionDamage;

		[SerializeField]
		private HungerDamage hungerDamage;

		public SpeedHunger SpeedHunger
		{
			get
			{
				return speedHunger;
			}
			set
			{
				speedHunger = value;
				this.OnSpeedHungerChanged?.Invoke(speedHunger);
				this.OnChanged?.Invoke();
			}
		}

		public NumberWeeds NumberWeeds
		{
			get
			{
				return numberWeeds;
			}
			set
			{
				numberWeeds = value;
				this.OnNumberWeedsChanged?.Invoke(numberWeeds);
				this.OnChanged?.Invoke();
			}
		}

		public NumberLeeches NumberLeeches
		{
			get
			{
				return numberLeeches;
			}
			set
			{
				numberLeeches = value;
				this.OnNumberLeechesChanged?.Invoke(numberLeeches);
				this.OnChanged?.Invoke();
			}
		}

		public LeechBehavior LeechBehavior
		{
			get
			{
				return leechBehavior;
			}
			set
			{
				leechBehavior = value;
				this.OnLeechBehaviorChanged?.Invoke(leechBehavior);
				this.OnChanged?.Invoke();
			}
		}

		public InfectionDamage InfectionDamage
		{
			get
			{
				return infectionDamage;
			}
			set
			{
				infectionDamage = value;
				this.OnInfectionDamageChanged?.Invoke(infectionDamage);
				this.OnChanged?.Invoke();
			}
		}

		public HungerDamage HungerDamage
		{
			get
			{
				return hungerDamage;
			}
			set
			{
				hungerDamage = value;
				this.OnHungerDamageChanged?.Invoke(hungerDamage);
				this.OnChanged?.Invoke();
			}
		}

		public event UnityAction<SpeedHunger> OnSpeedHungerChanged;

		public event UnityAction<NumberWeeds> OnNumberWeedsChanged;

		public event UnityAction<NumberLeeches> OnNumberLeechesChanged;

		public event UnityAction<LeechBehavior> OnLeechBehaviorChanged;

		public event UnityAction<InfectionDamage> OnInfectionDamageChanged;

		public event UnityAction<HungerDamage> OnHungerDamageChanged;

		public event UnityAction OnChanged;

		public DifficultySettings(CozyLevel cozyLevel)
		{
			SetCozyLevel(cozyLevel);
		}

		private int GetValue()
		{
			return (int)((int)((int)speedHunger + (int)numberWeeds + numberLeeches) + (int)leechBehavior + infectionDamage) + (int)hungerDamage;
		}

		public CozyLevel GetCozyLevel()
		{
			return (CozyLevel)Mathf.RoundToInt((float)GetValue() / (float)NormalValue * 2f);
		}

		public void SetCozyLevel(CozyLevel cozyLevel)
		{
			switch (cozyLevel)
			{
			case CozyLevel.Normal:
				speedHunger = SpeedHunger.Normal;
				numberWeeds = NumberWeeds.Normal;
				numberLeeches = NumberLeeches.Normal;
				leechBehavior = LeechBehavior.EatHarvest;
				infectionDamage = InfectionDamage.Normal;
				hungerDamage = HungerDamage.Normal;
				break;
			case CozyLevel.Cozy:
				speedHunger = SpeedHunger.Slowly;
				numberWeeds = NumberWeeds.Small;
				numberLeeches = NumberLeeches.Small;
				leechBehavior = LeechBehavior.EatHarvest;
				infectionDamage = InfectionDamage.Small;
				hungerDamage = HungerDamage.Small;
				break;
			case CozyLevel.Domestic:
				speedHunger = SpeedHunger.VerySlowly;
				numberWeeds = NumberWeeds.AlmostNone;
				numberLeeches = NumberLeeches.AlmostNone;
				leechBehavior = LeechBehavior.NotEatHarvest;
				infectionDamage = InfectionDamage.None;
				hungerDamage = HungerDamage.None;
				break;
			}
			this.OnSpeedHungerChanged?.Invoke(speedHunger);
			this.OnNumberWeedsChanged?.Invoke(numberWeeds);
			this.OnNumberLeechesChanged?.Invoke(numberLeeches);
			this.OnLeechBehaviorChanged?.Invoke(leechBehavior);
			this.OnInfectionDamageChanged?.Invoke(infectionDamage);
			this.OnHungerDamageChanged?.Invoke(hungerDamage);
			this.OnChanged?.Invoke();
		}

		public void SetAll(IReadOnlyDifficultySettings settings)
		{
			speedHunger = settings.SpeedHunger;
			numberWeeds = settings.NumberWeeds;
			numberLeeches = settings.NumberLeeches;
			leechBehavior = settings.LeechBehavior;
			infectionDamage = settings.InfectionDamage;
			hungerDamage = settings.HungerDamage;
			this.OnSpeedHungerChanged?.Invoke(speedHunger);
			this.OnNumberWeedsChanged?.Invoke(numberWeeds);
			this.OnNumberLeechesChanged?.Invoke(numberLeeches);
			this.OnLeechBehaviorChanged?.Invoke(leechBehavior);
			this.OnInfectionDamageChanged?.Invoke(infectionDamage);
			this.OnHungerDamageChanged?.Invoke(hungerDamage);
			this.OnChanged?.Invoke();
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public bool IsDefault(IReadOnlyDifficultySettings defaultSettings)
		{
			if (speedHunger == defaultSettings.SpeedHunger && numberWeeds == defaultSettings.NumberWeeds && numberLeeches == defaultSettings.NumberLeeches && leechBehavior == defaultSettings.LeechBehavior && infectionDamage == defaultSettings.InfectionDamage)
			{
				return hungerDamage == defaultSettings.HungerDamage;
			}
			return false;
		}
	}
}
