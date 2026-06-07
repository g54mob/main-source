using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundBazaar : BackgroundManager
	{
		private float _colorBgValue;

		private Transform _spritesRootTransform;

		private List<PhaserSprite> _windows;

		private Timer _colorBgTimer;

		private ParticleEmitterManager _pfxEmitter;

		private ParticleSystem _pfxFire1;

		private ParticleSystem _pfxFire2;

		protected override void OnDestroy()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Create()
		{
		}

		public override void OnInitCompleted()
		{
		}

		private void SnapEggs()
		{
		}

		private void MakeFireEmitters()
		{
		}

		private void MakeWindows()
		{
		}
	}
}
