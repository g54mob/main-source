using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Props;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundFoscari2_Plain : BackgroundManager
	{
		private TileSprite _water;

		private float _beats;

		private float _tilingOffset;

		private PhaserSprite _sDarkness;

		private PhaserSprite _sFader;

		private PhaserSprite _pizzaAsprite;

		private Circle _pizzaA;

		private bool _canPizza;

		private BgmType _saveBGM;

		private BgmModType _saveBGMMod;

		private Timer beatTimer;

		private float _waterOffset;

		private EnemyJeneviv _jeneviv;

		private ParticleEmitterManager _shadowParticlesManager;

		private ParticleSystem _shadowEmitter;

		private PropFoscariSeal2 _seal;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _glitchEmitter;

		private ParticleSystem _glitchEmitter2;

		public override void Awake()
		{
		}

		public override void Create()
		{
		}

		public override void OnInitCompleted()
		{
		}

		public override void CheckMinute(int minute)
		{
		}

		public override void Cleanup()
		{
		}

		protected override void OnUpdate()
		{
		}

		public void StopBeat()
		{
		}

		public void ForceSpoopyMusic()
		{
		}

		public void onBeat()
		{
		}

		public void ResumeEnemiesMovement()
		{
		}

		public void MakePizza()
		{
		}

		public void CheckPizzas(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void AnimPizza()
		{
		}

		private void GimmeAbeat(float interval, Action callback)
		{
		}

		private void ClearBeat()
		{
		}
	}
}
