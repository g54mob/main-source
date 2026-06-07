using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class LEM_Inferno1_Weapon : LEM_BaseWeapon
	{
		private int _runEnemiesKilledWhenWeaponFired;

		[SerializeField]
		private bool _InfiniteDuration;

		public int FireCounter { get; private set; }

		public int KillsWhileCurrentProjectileActive { get; private set; }

		public int HighestKillScoreThisRun { get; private set; }

		public float YPosOffset => 0f;

		public float MaxProjectileScale => 0f;

		public bool InfiniteDuration => false;

		public override float PPower()
		{
			return 0f;
		}

		public override float PArea()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected virtual void ResetKillTracking()
		{
		}

		public override void InternalUpdate()
		{
		}

		protected virtual void UpdateKillCount()
		{
		}

		private void UpdateFiringInterval()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected virtual void FireInfernoProjectiles(Vector2 pos)
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		public void PlayBlueTextSfx()
		{
		}

		public void PlayRedTextSfx(int killCount = 0)
		{
		}

		protected void DespawnActiveProjectiles()
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
