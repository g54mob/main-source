using UnityEngine;

namespace DV.Printers
{
	public class PrinterControllerWithLamp : PrinterController
	{
		[SerializeField]
		private LampControl cooldownLamp;

		protected override void Awake()
		{
			base.Awake();
			if (cooldownLamp == null)
			{
				Debug.LogWarning("cooldownLamp isn't set! Lamp will not be functional!", this);
			}
			if ((bool)cooldownLamp)
			{
				cooldownLamp.SetLampState(LampControl.LampState.On);
			}
		}

		protected override void CooldownStarted()
		{
			base.CooldownStarted();
			if ((bool)cooldownLamp)
			{
				cooldownLamp.SetLampState(LampControl.LampState.Off);
			}
		}

		protected override void CooldownFinished()
		{
			base.CooldownFinished();
			if ((bool)cooldownLamp)
			{
				cooldownLamp.SetLampState(LampControl.LampState.On);
			}
		}
	}
}
