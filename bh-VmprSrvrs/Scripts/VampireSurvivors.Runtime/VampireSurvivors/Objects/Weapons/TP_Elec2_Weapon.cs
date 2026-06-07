using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Elec2_Weapon : Weapon
	{
		private float _mul;

		private bool _cooldownAffectedByMovement;

		private bool _initialisedParticles;

		private PhaserSprite _cursor;

		private bool _hasGemini;

		private Timer rainStopTimer;

		private TP_Elec1_Weapon _elec1Weapon;

		private Vector2 _mirrorPos;

		public virtual float PlayerFacing => 0f;

		public virtual bool IsPrimaryWeapon => false;

		protected override void Awake()
		{
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

		public void FireProjectiles(Vector2 pos)
		{
		}

		public override void CheckArcanas()
		{
		}

		private void DisplayCursorVFX(int _times, float _duration)
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
