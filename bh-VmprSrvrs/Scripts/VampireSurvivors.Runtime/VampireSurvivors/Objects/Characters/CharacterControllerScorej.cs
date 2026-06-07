using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class CharacterControllerScorej : CharacterController
	{
		private bool _canRetaliate;

		private float _retaliationDelay;

		private Timer _retaliationTimeout;

		public override bool NeedsCart => false;

		public override void LevelUp()
		{
		}

		public override void OnGetDamaged(string hexColor = "#ff0000", float vulnerabilityDelay = 120f, bool playDamageFx = true, bool playWeaponDamageFx = false)
		{
		}

		protected override void OnStop()
		{
		}

		public void ShowRings(int frames)
		{
		}
	}
}
