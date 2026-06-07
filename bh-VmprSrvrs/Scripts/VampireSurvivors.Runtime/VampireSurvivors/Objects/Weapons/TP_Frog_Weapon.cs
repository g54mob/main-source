using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Frog_Weapon : Weapon
	{
		private PhaserSprite _cursor;

		private SpriteTextureData _cursorSpriteData;

		private float _cursorMinAlpha;

		[NonSerialized]
		public static float staticTotalTime;

		protected WeaponType _counterWeaponType;

		protected Weapon _counterWeapon;

		protected SantaJavelinCounterWeapon _counterSet;

		protected bool _hasCounterSet;

		public virtual bool IsPrimaryWeapon => false;

		protected override int ProjectilePoolSize => 0;

		public override float PArea()
		{
			return 0f;
		}

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateCursor(float interval)
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void FireProjectiles(Vector2 pos)
		{
		}

		private Vector2 GetJumpDestination(Vector2 pos)
		{
			return default(Vector2);
		}

		protected void Fire_FireCounter(bool skipTriggers = false)
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
