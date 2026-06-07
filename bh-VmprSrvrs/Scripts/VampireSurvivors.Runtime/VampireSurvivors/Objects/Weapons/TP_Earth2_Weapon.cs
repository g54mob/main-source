using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Earth2_Weapon : Weapon
	{
		[SerializeField]
		[Tooltip("Material to use for the crystals")]
		private Material _Material;

		private bool _initialisedParticles;

		private ParticleSystem _jewelPickupVfx;

		private PhaserSprite _cursor;

		private float _topBarHeight;

		private bool _hasGemini;

		private TP_Earth1_Weapon _earth1Weapon;

		private List<uint> _baseTints;

		private List<uint> _rainbowTints;

		public virtual float PlayerFacing => 0f;

		public virtual bool IsPrimaryWeapon => false;

		public List<uint> BaseTints => null;

		public List<uint> RainbowTints => null;

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

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		private void DisplayCursorVFX(int _times, float _duration)
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
