using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Characters
{
	public class EME_CharacterControllerShowstopper : CharacterController
	{
		private float _mightBonus;

		private float _cooldownBonus;

		private float _luckBonus;

		private float _morphDuration;

		private bool _isMorphed;

		private bool _hasBonusApplied;

		private EME_ShowstopperVfx _showStoperVfx;

		private BgmType _playerCurrentMusic;

		private BgmModType _playerCurrentbgmMod;

		private Timer _showstopperTimer;

		private Timer _showstopperMusicTimer;

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void AfterFullInitialization()
		{
		}

		private void CriticalHP()
		{
		}

		protected virtual void OnShowStopperStarted()
		{
		}

		protected void StartShowstopper()
		{
		}

		private void Unmorph()
		{
		}
	}
}
