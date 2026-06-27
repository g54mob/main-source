using System;

namespace Restory.Gameplay.Elements
{
	public class ButtonElement : InsertableElement, IPowerUpElement, ISwitchableElement
	{
		private bool isSwitching;

		public bool IsOn => true;

		public event Action OnPowerUp;

		public event Action OnSwitched;

		public void InitSwitchInteraction()
		{
			if (!isSwitching)
			{
				isSwitching = true;
				this.OnSwitched?.Invoke();
			}
		}

		public void CompleteSwitchInteraction()
		{
			if (isSwitching)
			{
				this.OnPowerUp?.Invoke();
			}
			isSwitching = false;
		}
	}
}
