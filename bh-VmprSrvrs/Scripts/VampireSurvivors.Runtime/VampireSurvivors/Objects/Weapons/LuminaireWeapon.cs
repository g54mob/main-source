using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;

namespace VampireSurvivors.Objects.Weapons
{
	public class LuminaireWeapon : Weapon
	{
		private List<PhaserSprite> _doilies;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private Rectangle _rectangle;

		private List<string> _frames;

		private float _firingCounter;

		private bool _isInitialised;

		private uint[] _colors;

		[NonSerialized]
		public float FiredTimes;

		[NonSerialized]
		public ArcanaType FirstArcana;

		protected override void OnStart()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void SetupVFX()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void CheckArcanas()
		{
		}

		public override void Cleanup()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
