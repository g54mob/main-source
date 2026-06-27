using System;

namespace Restory.Gameplay.Elements
{
	public class ToggleElement : InsertableElement, IPowerUpElement, ISwitchableElement
	{
		private bool isOn;

		private bool isSwitching;

		public bool IsOn => isOn;

		public event Action OnPowerUp;

		public event Action OnSwitched;

		public override void Reset()
		{
			if (isOn)
			{
				this.OnSwitched?.Invoke();
			}
			base.Reset();
			isSwitching = false;
		}

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
			isOn = !isOn;
			if (isOn && isSwitching)
			{
				this.OnPowerUp?.Invoke();
			}
			isSwitching = false;
		}
	}
}
