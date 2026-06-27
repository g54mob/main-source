using System;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	[Serializable]
	public class SonicBathTimerData
	{
		public bool IsCountdown { get; set; }

		public DateTime TargetDateTime { get; set; }
	}
}
