using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FourSeasonsProjectile : Projectile
	{
		private FourSeasonsWeapon _trueWeapon;

		private Timer _expireTimer;

		private ParticleEmitterManager _particles;

		private ParticleSystem _fwEmitter;

		[SerializeField]
		private SpriteRenderer _ringRenderer;

		[SerializeField]
		private SpriteRenderer _rainbowRenderer;

		[SerializeField]
		private SpriteRenderer _raysRenderer;

		private MultiTargetTween _tween5;

		private MultiTargetTween _tween3;

		private MultiTargetTween _tween4;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween1;

		private int _season;

		private List<ParticleEmitterManager> _seasonParticles;

		private List<ParticleSystem> _seasonEmitters;

		private List<GravityWell> _seasonWells;

		private PhaserSprite _kanji;

		private List<Sprite> _kanjiFrames;

		private bool _initalized;

		public uint[] getEmitCustomTint(int season)
		{
			return null;
		}

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Initialize()
		{
		}

		private void MakeEmitter_Frames(List<string> frames, int season)
		{
		}

		private void OnRecycle()
		{
		}

		private void TryDetonate()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
