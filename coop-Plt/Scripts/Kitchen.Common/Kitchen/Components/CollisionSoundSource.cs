using UnityEngine;

namespace Kitchen.Components
{
	public class CollisionSoundSource : BaseSoundSource
	{
		public float MinimumVelocity = 1f;

		public LayerMask Layers;

		public float StartTime;

		private void OnCollisionEnter(Collision other)
		{
			if (StartTime == 0f)
			{
				StartTime = Time.realtimeSinceStartup;
			}
			if (!(Time.realtimeSinceStartup < StartTime + 5f) && (int)Layers == ((int)Layers | (1 << other.gameObject.layer)))
			{
				Volume = Mathf.Clamp((Mathf.Abs(other.relativeVelocity.magnitude) - MinimumVelocity) / 2f, 0f, 1f);
				SetVolume();
				Audio.Play();
			}
		}
	}
}
