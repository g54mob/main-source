using UnityEngine.Events;

namespace Restory.Gameplay.GameSettings
{
	public interface IReadOnlyDifficultySettings
	{
		SpeedHunger SpeedHunger { get; }

		NumberWeeds NumberWeeds { get; }

		NumberLeeches NumberLeeches { get; }

		LeechBehavior LeechBehavior { get; }

		InfectionDamage InfectionDamage { get; }

		HungerDamage HungerDamage { get; }

		event UnityAction<SpeedHunger> OnSpeedHungerChanged;

		event UnityAction<NumberWeeds> OnNumberWeedsChanged;

		event UnityAction<NumberLeeches> OnNumberLeechesChanged;

		event UnityAction<LeechBehavior> OnLeechBehaviorChanged;

		event UnityAction<InfectionDamage> OnInfectionDamageChanged;

		event UnityAction<HungerDamage> OnHungerDamageChanged;

		event UnityAction OnChanged;

		CozyLevel GetCozyLevel();

		object Clone();

		bool IsDefault(IReadOnlyDifficultySettings defaultSettings);
	}
}
