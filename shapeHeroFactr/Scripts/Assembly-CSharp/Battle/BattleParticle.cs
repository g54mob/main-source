using UnityEngine;

namespace Battle
{
	public class BattleParticle : MonoBehaviour
	{
		public ParticleSystem particle;

		public bool autoKill;

		private double _nowSpeedGear;

		private ParticleSystem[] _particles;

		private float[] _baseSimulations;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void Play(double simulationRatio = -1.0)
		{
		}

		private void ChangeSpeed(double simulationRatio)
		{
		}
	}
}
