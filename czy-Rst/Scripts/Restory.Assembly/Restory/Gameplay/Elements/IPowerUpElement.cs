using System;

namespace Restory.Gameplay.Elements
{
	public interface IPowerUpElement : ISwitchableElement
	{
		bool IsOn { get; }

		event Action OnPowerUp;

		event Action OnSwitched;

		void CompleteSwitchInteraction();
	}
}
