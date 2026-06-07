using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class EX_Rune1_Weapon : Weapon
	{
		public int AccumulatedProjectiles;

		private int activations;

		private List<PhaserSprite> magicCircles;

		private int magicCircleIndex;

		private float _angle1;

		private float _angle2;

		private float _angle3;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected float StripLength()
		{
			return 0f;
		}

		private void FireStripAtEnemy(EnemyController enemy, int index, Vector2 startPosition)
		{
		}

		private Vector2 GetScreenPosition()
		{
			return default(Vector2);
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		private void ShowMagicCircleAt(Vector2 position, int times)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Cleanup()
		{
		}
	}
}
