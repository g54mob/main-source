using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_RulerSword_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _InvisibleProjectilePrefab;

		[SerializeField]
		private GameObject _SwordsContainer;

		public BulletPool InvisibleProjectilesPool;

		private List<TP_RulerSword_Weapon_Sprite> _swords;

		private Vector3 innerRadius;

		private float momentum;

		private float lastVelX;

		private int _activeCount;

		private bool _isAttacking;

		public BulletPool SwordsPool => null;

		protected override void OnStart()
		{
		}

		private TP_RulerSword_Weapon_Sprite AddRulerSwordSprite(Vector2 pos, string textureName, string spriteName)
		{
			return null;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public bool ShowNextSword()
		{
			return false;
		}

		private void AddSword(TP_RulerSword_Weapon_Sprite swordToAdd)
		{
		}

		private TP_RulerSword_Weapon_Sprite MakeSword_Large()
		{
			return null;
		}

		private TP_RulerSword_Weapon_Sprite MakeSword_Small()
		{
			return null;
		}

		public bool AddNextSword()
		{
			return false;
		}

		public override void Fire()
		{
		}

		public void Attack()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
