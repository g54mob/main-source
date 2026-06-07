using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Galamoth_Character : TP_Character
	{
		private bool _canRetaliate;

		private float _retaliationDelay;

		private Timer _retaliationTimeout;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void AfterFullInitialization()
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
