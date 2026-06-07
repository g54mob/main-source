using System;
using Client;
using Factory.Pools;
using UnityEngine;
using UnityEngine.Serialization;

namespace Motorways.Views
{
	public class TribandVehicleEffects : MonoBehaviour, IReusable
	{
		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("TribandVehicleEffects");

		[SerializeField]
		private ParticleSystem[] _feetParticleSystems;

		[FormerlySerializedAs("_spawnIntervalSquared")]
		[FormerlySerializedAs("_spawnDelaySquared")]
		[SerializeField]
		[Tooltip("The distance travelled between each particle spawns")]
		private float _spawnInterval;

		private Vector3 _lastPosition;

		private float _distanceSinceSpawn;

		private int _nextParticleSystemIndex;

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_lastPosition == Vector3.zero)
			{
				_lastPosition = base.transform.position;
			}
			float num = (0f - base.transform.rotation.eulerAngles.z) * ((float)Math.PI / 180f);
			for (int i = 0; i < _feetParticleSystems.Length; i++)
			{
				ParticleSystem.MainModule main = _feetParticleSystems[i].main;
				main.startRotation = num;
			}
			float magnitude = (base.transform.position - _lastPosition).magnitude;
			_distanceSinceSpawn += magnitude;
			if (_distanceSinceSpawn > _spawnInterval)
			{
				_feetParticleSystems[_nextParticleSystemIndex].Emit(1);
				_nextParticleSystemIndex = (_nextParticleSystemIndex + 1) % _feetParticleSystems.Length;
				_distanceSinceSpawn = 0f;
			}
			_lastPosition = base.transform.position;
			return TickResult.ContinueTicking;
		}

		public void Reset()
		{
			_lastPosition = default(Vector3);
			_distanceSinceSpawn = 0f;
			_nextParticleSystemIndex = 0;
		}
	}
}
