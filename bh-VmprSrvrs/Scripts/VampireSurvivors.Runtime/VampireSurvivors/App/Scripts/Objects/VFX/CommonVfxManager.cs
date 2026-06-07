using System;
using UnityEngine;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.App.Scripts.Objects.VFX
{
	public class CommonVfxManager : IDisposable
	{
		private ParticleEmitterManager _smallParticlesManager;

		private ParticleSystem _pxfEmitterBlue;

		private ParticleSystem _pfxEmitterRed;

		private GravityWell _well1;

		private GravityWell _well2;

		public ParticleSystem PxfEmitterBlue => null;

		public ParticleSystem PfxEmitterRed => null;

		public void Dispose()
		{
		}
	}
}
