using UnityEngine;

namespace Kitchen.Components
{
	public class HingeSoundSource : BaseSoundSource
	{
		public HingeJoint Joint;

		public float BasePitch = 1f;

		public float PitchVariation = 0.5f;

		public float VolumeVariation = 0.5f;

		public float MinimumVelocity = 20f;

		public float Lifetime;

		private void Update()
		{
			Lifetime += Time.deltaTime;
			if (!(Lifetime < 5f))
			{
				float num = Mathf.Clamp((Mathf.Abs(Joint.velocity) - MinimumVelocity) / 90f, 0f, 1f);
				Volume = num * VolumeVariation;
				SetVolume();
			}
		}
	}
}
