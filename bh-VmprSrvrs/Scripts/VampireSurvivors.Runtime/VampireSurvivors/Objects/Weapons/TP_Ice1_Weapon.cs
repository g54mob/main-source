using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Ice1_Weapon : Weapon
	{
		private bool _initialisedParticles;

		private PhaserSprite _cursor;

		[NonSerialized]
		public static float staticTotalTime;

		protected WeaponType _counterWeaponType;

		protected Weapon _counterWeapon;

		protected SantaJavelinCounterWeapon _counterSet;

		protected bool _hasCounterSet;

		public virtual float PlayerFacing => 0f;

		public virtual bool IsPrimaryWeapon => false;

		public bool CanFireNormally { get; set; }

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

		public void Fire_FireCounter(bool skipTriggers = false)
		{
		}

		public override bool LevelUp()
		{
			return false;
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
