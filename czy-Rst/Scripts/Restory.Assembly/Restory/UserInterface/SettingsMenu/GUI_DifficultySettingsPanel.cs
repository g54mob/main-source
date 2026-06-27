using Restory.Gameplay.GameSettings;
using Restory.UserInterface.CommonElements;
using UnityEngine;

namespace Restory.UserInterface.SettingsMenu
{
	public sealed class GUI_DifficultySettingsPanel : GUI_ChildControlsSettingPanel
	{
		[SerializeField]
		private GUI_Switcher speedHunger;

		[SerializeField]
		private GUI_Switcher numberWeeds;

		[SerializeField]
		private GUI_Switcher numberLeeches;

		[SerializeField]
		private GUI_Switcher leechBehavior;

		[SerializeField]
		private GUI_Switcher infectionDamage;

		[SerializeField]
		private GUI_Switcher hungerDamage;

		protected override void SubscribeChildren()
		{
			base.SubscribeChildren();
			speedHunger.OnValueChanged += OnSpeedHungerChangedResolve;
			numberWeeds.OnValueChanged += OnNumberWeedsChangedResolve;
			numberLeeches.OnValueChanged += OnNumberLeechesChangedResolve;
			leechBehavior.OnValueChanged += OnLeechBehaviorChangedResolve;
			infectionDamage.OnValueChanged += OnInfectionDamageChangedResolve;
			hungerDamage.OnValueChanged += OnHungerDamageChangedResolve;
		}

		protected override void UnsubscribeChildren()
		{
			base.UnsubscribeChildren();
			speedHunger.OnValueChanged -= OnSpeedHungerChangedResolve;
			numberWeeds.OnValueChanged -= OnNumberWeedsChangedResolve;
			numberLeeches.OnValueChanged -= OnNumberLeechesChangedResolve;
			leechBehavior.OnValueChanged -= OnLeechBehaviorChangedResolve;
			infectionDamage.OnValueChanged -= OnInfectionDamageChangedResolve;
			hungerDamage.OnValueChanged -= OnHungerDamageChangedResolve;
		}

		public override void Load()
		{
			speedHunger.SetValueWithoutNotify((int)gameSettingsManager.DifficultySettings.SpeedHunger);
			numberWeeds.SetValueWithoutNotify((int)gameSettingsManager.DifficultySettings.NumberWeeds);
			numberLeeches.SetValueWithoutNotify((int)gameSettingsManager.DifficultySettings.NumberLeeches);
			leechBehavior.SetValueWithoutNotify((int)gameSettingsManager.DifficultySettings.LeechBehavior);
			infectionDamage.SetValueWithoutNotify((int)gameSettingsManager.DifficultySettings.InfectionDamage);
			hungerDamage.SetValueWithoutNotify((int)gameSettingsManager.DifficultySettings.HungerDamage);
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		public override void SetDefault()
		{
			speedHunger.SetValueWithoutNotify((int)gameSettingsManager.DefaultData.DifficultySettings.SpeedHunger);
			numberWeeds.SetValueWithoutNotify((int)gameSettingsManager.DefaultData.DifficultySettings.NumberWeeds);
			numberLeeches.SetValueWithoutNotify((int)gameSettingsManager.DefaultData.DifficultySettings.NumberLeeches);
			leechBehavior.SetValueWithoutNotify((int)gameSettingsManager.DefaultData.DifficultySettings.LeechBehavior);
			infectionDamage.SetValueWithoutNotify((int)gameSettingsManager.DefaultData.DifficultySettings.InfectionDamage);
			hungerDamage.SetValueWithoutNotify((int)gameSettingsManager.DefaultData.DifficultySettings.HungerDamage);
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		public override void Apply()
		{
			gameSettingsManager.DifficultySettings.SpeedHunger = (SpeedHunger)speedHunger.Value;
			gameSettingsManager.DifficultySettings.NumberWeeds = (NumberWeeds)numberWeeds.Value;
			gameSettingsManager.DifficultySettings.NumberLeeches = (NumberLeeches)numberLeeches.Value;
			gameSettingsManager.DifficultySettings.LeechBehavior = (LeechBehavior)leechBehavior.Value;
			gameSettingsManager.DifficultySettings.InfectionDamage = (InfectionDamage)infectionDamage.Value;
			gameSettingsManager.DifficultySettings.HungerDamage = (HungerDamage)hungerDamage.Value;
			gameSettingsSaver.Save();
			UpdateHasChanges();
			UpdateIsDefaultValues();
		}

		protected override void UpdateHasChanges()
		{
			if (!(gameSettingsManager == null))
			{
				SetHasChange(gameSettingsManager.DifficultySettings.SpeedHunger != (SpeedHunger)speedHunger.Value || gameSettingsManager.DifficultySettings.NumberWeeds != (NumberWeeds)numberWeeds.Value || gameSettingsManager.DifficultySettings.NumberLeeches != (NumberLeeches)numberLeeches.Value || gameSettingsManager.DifficultySettings.LeechBehavior != (LeechBehavior)leechBehavior.Value || gameSettingsManager.DifficultySettings.InfectionDamage != (InfectionDamage)infectionDamage.Value || gameSettingsManager.DifficultySettings.HungerDamage != (HungerDamage)hungerDamage.Value);
			}
		}

		protected override void UpdateIsDefaultValues()
		{
			if (!(gameSettingsManager == null))
			{
				SetIsDefaultValues(gameSettingsManager.DefaultData.DifficultySettings.SpeedHunger == (SpeedHunger)speedHunger.Value && gameSettingsManager.DefaultData.DifficultySettings.NumberWeeds == (NumberWeeds)numberWeeds.Value && gameSettingsManager.DefaultData.DifficultySettings.NumberLeeches == (NumberLeeches)numberLeeches.Value && gameSettingsManager.DefaultData.DifficultySettings.LeechBehavior == (LeechBehavior)leechBehavior.Value && gameSettingsManager.DefaultData.DifficultySettings.InfectionDamage == (InfectionDamage)infectionDamage.Value && gameSettingsManager.DefaultData.DifficultySettings.HungerDamage == (HungerDamage)hungerDamage.Value);
			}
		}

		private void OnSpeedHungerChangedResolve(int value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnSliderChangedValue?.Invoke();
		}

		private void OnNumberWeedsChangedResolve(int value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnSliderChangedValue?.Invoke();
		}

		private void OnNumberLeechesChangedResolve(int value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnSliderChangedValue?.Invoke();
		}

		private void OnLeechBehaviorChangedResolve(int value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnSliderChangedValue?.Invoke();
		}

		private void OnInfectionDamageChangedResolve(int value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnSliderChangedValue?.Invoke();
		}

		private void OnHungerDamageChangedResolve(int value)
		{
			UpdateHasChanges();
			UpdateIsDefaultValues();
			OnSliderChangedValue?.Invoke();
		}
	}
}
