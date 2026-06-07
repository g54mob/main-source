using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages
{
	[UsedImplicitly]
	public class Background4 : BackgroundManager
	{
		private bool _hasSpawnedGuards;

		private bool _stopp;

		private bool _passed;

		private BgmType _saveBgm;

		private Timer _firstEvent;

		private Timer _recurringEvent;

		private MultiTargetTween _randomazzoTween;

		private Transform _spritesRootTransform;

		private readonly List<SpriteRenderer> _allSprites;

		private SpriteRenderer _sBackground;

		private SpriteRenderer _sStars2;

		private SpriteRenderer _sStars1;

		private SpriteRenderer _sPeaks;

		private SpriteRenderer _sMount2;

		private SpriteRenderer _sMist3;

		private SpriteRenderer _sMount1;

		private SpriteRenderer _sFlash;

		private SpriteRenderer _sMist2;

		private SpriteRenderer _sHills;

		private SpriteRenderer _sMist1;

		private SpriteRenderer _sForest;

		private SpriteRenderer _sDarkness;

		private PhaserSprite _sFog;

		private PhaserSprite _sFogExtraA;

		private PhaserSprite _sFogExtraB;

		private ParticleEmitterManager _particleEmitterManager;

		private ParticleSystem _pfxEmitter;

		private GravityWell _well;

		private List<RuneStripVfx> _runeStrips;

		private List<RuneStripVfx2> _runeStrips2;

		private const int SortingOrderBackmost = -32768;

		private const float TowerTop = 122.88f;

		private const float Bot = -245.76f;

		private const float Bott = -491.52f;

		protected override void OnUpdate()
		{
		}

		public override void OnInitCompleted()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void CustomPreload(Action onComplete)
		{
		}

		public override void Create()
		{
		}

		public override void Cleanup()
		{
		}

		private void PlayFlash()
		{
		}

		private void StopRune2()
		{
		}

		private void FixY(SpriteRenderer spriteRenderer, float min, float max, float prop)
		{
		}

		private void CheckPlayerVsBot(float prop)
		{
		}

		private void CheckPlayerVsTop()
		{
		}

		private void GenerateObjects()
		{
		}

		private void GenerateTrappedSorceress()
		{
		}

		private void OnRemoteEnemySpawned(EnemyController enemy)
		{
		}

		private void GenerateBridgeBoss()
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
