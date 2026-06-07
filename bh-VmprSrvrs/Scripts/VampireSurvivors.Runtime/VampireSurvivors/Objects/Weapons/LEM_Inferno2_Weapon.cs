using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.App.Graphics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class LEM_Inferno2_Weapon : LEM_Inferno1_Weapon
	{
		[SerializeField]
		private Projectile _CombinedProjectilePrefab;

		[SerializeField]
		private GenericShadowText _NaneinfText;

		private BulletPool _combinedProjectilePool;

		private bool _hasCombined;

		private int _killsLastFrame;

		private PhaserSprite _jimboSprite;

		public int BlueKillScore { get; private set; }

		public int RedKillScore { get; private set; }

		protected virtual bool DespawnOnExplode => false;

		public override float PPower()
		{
			return 0f;
		}

		protected override void OnStart()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void InitNaneinfText()
		{
		}

		protected override void FireInfernoProjectiles(Vector2 pos)
		{
		}

		protected override void ResetKillTracking()
		{
		}

		protected override void UpdateKillCount()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void CheckForCombine(bool forceCombine = false)
		{
		}

		private void CombineProjectiles()
		{
		}

		public void TriggerNaneinf()
		{
		}

		private void DoCoinRosary()
		{
		}

		private List<EnemyController> GetAllEnemiesOnScreen()
		{
			return null;
		}

		private void DoNaneinfTextAnim()
		{
		}

		private void DoJimboSpriteAnim()
		{
		}

		private void AddToBlueKillScore(int amount = 1)
		{
		}

		private void AddToRedKillScore(int amount = 1)
		{
		}
	}
}
