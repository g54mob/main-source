using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class GhostAnimEventListener : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem[] _particles;

		private void Awake()
		{
			_particles = base.gameObject.GetComponentsInChildren<ParticleSystem>();
		}

		public void StartFX(AnimationEvent animationEvent)
		{
			if (_particles != null)
			{
				ParticleSystem[] particles = _particles;
				for (int i = 0; i < particles.Length; i++)
				{
					particles[i].Play();
				}
			}
		}

		public void StopFX(AnimationEvent animationEvent)
		{
			if (_particles != null)
			{
				ParticleSystem[] particles = _particles;
				for (int i = 0; i < particles.Length; i++)
				{
					particles[i].Stop();
				}
			}
		}
	}
}
