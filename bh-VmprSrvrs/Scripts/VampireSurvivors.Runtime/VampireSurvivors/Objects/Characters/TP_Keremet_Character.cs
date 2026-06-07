using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Keremet_Character : TP_Character
	{
		private float OverhealDelay;

		private float OverhealTriggerValue2;

		private bool _canOverheal;

		private Timer _overHealTimer;

		private Weapon keremetWeapon;

		public override void AfterFullInitialization()
		{
		}

		private void FireMorbus(float value, float rawValue)
		{
		}
	}
}
