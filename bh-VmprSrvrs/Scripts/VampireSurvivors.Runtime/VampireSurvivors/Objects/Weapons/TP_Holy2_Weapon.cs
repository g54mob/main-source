using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Holy2_Weapon : Weapon
	{
		[SerializeField]
		private TP_Holy2_WeaponSupport support;

		private bool _initialisedParticles;

		private bool _hasGemini;

		private TP_Holy1_Weapon _holy1Weapon;

		public virtual bool IsPrimaryWeapon => false;

		protected override void Awake()
		{
		}

		public override float PInterval()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
