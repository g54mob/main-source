using UnityEngine;

namespace CTS
{
	public class SelectionMap_ParticuleSystemsStars : MonoBehaviour
	{
		[SerializeField]
		private SelectionMap_CityStarsVFX _manager;

		private ParticleSystem _particleSystems;

		private void Start()
		{
			_particleSystems = GetComponent<ParticleSystem>();
			ParticleSystem.MainModule main = _particleSystems.main;
			main.stopAction = ParticleSystemStopAction.Callback;
		}
	}
}
