using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace VFX.Blood
{
	public class BloodDrainParticle : h
	{
		private const float pwz = 0.025f;

		private fd pxa;

		private List<ParticleCollisionEvent> pxb;

		private bfc pxc;

		[field: SerializeField]
		public ParticleSystem PS { get; private set; }

		[Inject]
		private void dyk(fd a, bfc b)
		{
		}

		protected override void cxh()
		{
		}

		protected override void cxu()
		{
		}

		protected override void cxv()
		{
		}

		private void OnParticleCollision(GameObject other)
		{
		}

		private void dyl(GameObject a)
		{
		}

		private void dym(ParticleCollisionEvent a)
		{
		}
	}
}
