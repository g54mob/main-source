using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_AxeArmor_Character : TP_Character
	{
		private bool _canRetaliate;

		private float _retaliationDelay;

		private Timer _retaliationTimeout;

		public override void AfterFullInitialization()
		{
		}

		public override void OnAttackAnim(Weapon.FiringAnimation firingAnimation)
		{
		}

		public override void ClearFromSpecialAnims()
		{
		}

		public override void LevelUp()
		{
		}

		public override void OnGetDamaged(string hexColor = "#ff0000", float vulnerabilityDelay = 120f, bool playDamageFx = true, bool playWeaponDamageFx = false)
		{
		}

		public void ShowRings(int frames)
		{
		}
	}
}
