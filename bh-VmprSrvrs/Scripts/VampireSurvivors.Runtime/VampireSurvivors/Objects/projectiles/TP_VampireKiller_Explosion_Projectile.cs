using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_VampireKiller_Explosion_Projectile : Projectile
	{
		private ParticleSystem _pfxEmitter;

		private Tween _scaleTween;

		private PhaserSprite _animatedSprite;

		private PhaserSprite _sunraySprite;

		private uint[] _tints;

		private List<PhaserSprite> explosionSprites;

		private string[] _sideNames;

		private string[] _starNames;

		private string[] _flatNames;

		private List<PhaserSprite> BeamSprites;

		private List<PhaserSprite> SideSprites;

		private List<PhaserSprite> StarSprites;

		private List<PhaserSprite> FlatSprites;

		private List<List<PhaserSprite>> ListOfListsLol;

		private Timer attackTimer;

		private Timer expireTimer;

		private bool _isDespawning;

		private EnemyController _targetEnemy;

		private List<SfxType> sfxs;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void Explode()
		{
		}

		private void DisplayRandomFlare()
		{
		}

		public void SetTargetEnemy(EnemyController enemy)
		{
		}

		private void LateUpdate()
		{
		}

		public void StartDespawn()
		{
		}

		private void GenerateAnimatedSprites()
		{
		}

		private void GenerateParticleSystem()
		{
		}

		public override void Despawn()
		{
		}
	}
}
