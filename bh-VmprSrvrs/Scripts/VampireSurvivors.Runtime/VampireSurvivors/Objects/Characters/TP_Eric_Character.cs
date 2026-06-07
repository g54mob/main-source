using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Eric_Character : TP_Character
	{
		private BgmType _saveBgm;

		private BgmModType _saveBgmMod;

		private float _morphDuration;

		private float _cooldownBonus;

		private bool _hasBonusApplied;

		private bool _isAflame;

		private bool changedBGM;

		private int triggeredAlcardes;

		public override void AfterFullInitialization()
		{
		}

		private void CriticalHP()
		{
		}

		private void Unmorph()
		{
		}
	}
}
