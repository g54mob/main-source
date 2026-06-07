using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Soma_Character : TP_Character
	{
		private bool _isDarkLord;

		private TP_SoulSteal_Weapon soulStealWeapon;

		private int blueSouls;

		private int redSouls;

		private int yellowSouls;

		private int blueBonusIndex;

		private int blueExtraStacks;

		private int redBonusIndex;

		private int redExtraStacks;

		private int yellowBonusIndex;

		private int yellowExtraStacks;

		public override bool DrainWeaponsImmunity => false;

		protected virtual int[] bonusTresholds => null;

		public override void AfterFullInitialization()
		{
		}

		protected override void OnStop()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public override void OnQuit()
		{
		}

		public void OnEnemyKilled(GameplaySignals.EnemyKilledImmediateSignal signal)
		{
		}

		public void SoulSteal()
		{
		}

		public override void OnAttackAnim(Weapon.FiringAnimation firingAnimation)
		{
		}

		public override void ClearFromSpecialAnims()
		{
		}

		protected bool UpdateSoulsCount(ref int total, ref int bonusIndex, ref int extraStacks)
		{
			return false;
		}

		public void SoulCollected(int soulType)
		{
		}

		private void UpdateBlue()
		{
		}

		private void UpdateRed()
		{
		}

		private void UpdateYellow()
		{
		}
	}
}
