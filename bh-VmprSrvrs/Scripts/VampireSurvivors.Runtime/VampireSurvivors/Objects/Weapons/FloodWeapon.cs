using System.Collections.Generic;
using DG.Tweening;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics.Blitters;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class FloodWeapon : Weapon
	{
		public float VerticalOffset;

		private Blitter _blitter;

		private float _elapsed;

		private float _gravity;

		private float _wave1Alpha;

		private List<Bob> _wave1Group;

		private Tween _waveTween;

		private float _blitterWidth;

		private float _blitterHeight;

		private PhaserSprite _displaySprite;

		private PhaserSprite _damageSprite;

		private PhaserSprite _edgeSprite1;

		private PhaserSprite _edgeSprite2;

		private MultiTargetTween _alphaTween;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void DamageBelow(int index)
		{
		}

		private bool IsInFloodZone(EnemyController enemyController)
		{
			return false;
		}

		private void MakeBlitter()
		{
		}

		private void LateUpdate()
		{
		}

		public void UpdateVerticalOffset()
		{
		}

		private void UpdateBlitter()
		{
		}

		public override void Cleanup()
		{
		}
	}
}
