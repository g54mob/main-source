using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_RulerSword_Weapon_Sprite : PhaserSprite
	{
		private PhaserSprite _phaserSprite;

		public TP_RulerSword_Weapon Weapon;

		private Tween _scaleTween;

		private List<Projectile> bodies;

		public Vector2 offset_Idle;

		public Vector2 offset_Attack;

		private bool _isAttacking;

		public void Initialize(TP_RulerSword_Weapon _weapon, int hitBoxesAmount)
		{
		}

		public void Disable()
		{
		}

		public void Enable()
		{
		}

		public void Attack()
		{
		}
	}
}
