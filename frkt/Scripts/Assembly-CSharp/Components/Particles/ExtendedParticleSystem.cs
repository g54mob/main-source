using UnityEngine;

namespace Components.Particles
{
	public class ExtendedParticleSystem : g, hk, hj
	{
		private enum CustomVelocityEmitterType
		{
			None = 0,
			VelocityHandler = 1,
			ConstantValue = 2
		}

		private ParticleSystemEmitterVelocityMode tfj;

		private ParticleSystem.MinMaxCurve tfk;

		private ParticleSystem.MinMaxCurve tfl;

		private bko tfm;

		private CustomVelocityEmitterType tfn;

		[field: SerializeField]
		public ParticleSystemHandler Handler { get; private set; }

		public ParticleSystem xow => null;

		protected ParticleSystem.MainModule xox => default(ParticleSystem.MainModule);

		protected sealed override void cxh()
		{
		}

		public void jfj()
		{
		}

		public void Stop()
		{
		}

		public void jfk(bko a)
		{
		}

		public void jfl(Vector3 a)
		{
		}

		public void jfm(ParticleSystem.MinMaxCurve a)
		{
		}

		public void jfn(ParticleSystem.MinMaxCurve a)
		{
		}

		public void jfo()
		{
		}

		public void eiz()
		{
		}

		public void jfp()
		{
		}

		protected virtual void jfq()
		{
		}

		protected virtual void gea()
		{
		}

		private void jfr()
		{
		}

		private void jfs()
		{
		}

		private void jft(Vector3 a)
		{
		}

		private void jfu()
		{
		}

		private void jfv()
		{
		}

		private void jfw()
		{
		}

		private void OnValidate()
		{
		}

		private void jfx()
		{
		}
	}
}
