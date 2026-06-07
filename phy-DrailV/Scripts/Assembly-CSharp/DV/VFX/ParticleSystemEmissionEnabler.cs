using UnityEngine;

namespace DV.VFX
{
	public class ParticleSystemEmissionEnabler : MonoBehaviour
	{
		[Header("The listed particle systems emission modules will follow this scripts enabled state")]
		public ParticleSystem[] systems;

		private void Awake()
		{
			SetState(state: false);
		}

		private void OnEnable()
		{
			SetState(state: true);
		}

		private void OnDisable()
		{
			SetState(state: false);
		}

		private void SetState(bool state)
		{
			if (systems != null)
			{
				ParticleSystem[] array = systems;
				for (int i = 0; i < array.Length; i++)
				{
					ParticleSystem.EmissionModule emission = array[i].emission;
					emission.enabled = state;
				}
			}
		}
	}
}
