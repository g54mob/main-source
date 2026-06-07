using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Evil2_Weapon : Weapon
	{
		private bool _initialisedParticles;

		private PhaserSprite _cursor;

		private bool _hasGemini;

		private Timer rainStopTimer;

		private TP_Evil1_Weapon _baseWeapon;

		private PhaserSprite _sDarkness;

		public bool HasNightmare;

		private float _radius;

		public virtual float PlayerFacing => 0f;

		public virtual bool IsPrimaryWeapon => false;

		public override float PPower()
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

		protected float CalcRadAngle(float x1, float y1, float x2, float y2)
		{
			return 0f;
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

		private float Approach(float start, float end, float shift)
		{
			return 0f;
		}

		private void NightmareCheck()
		{
		}

		private bool IsCharacterInRange(Vector2 charPos, Vector2 projPos, float radiusSqrd)
		{
			return false;
		}
	}
}
