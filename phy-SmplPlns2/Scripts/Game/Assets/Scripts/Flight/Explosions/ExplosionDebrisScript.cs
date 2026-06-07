using UnityEngine;

namespace Assets.Scripts.Flight.Explosions
{
	public class ExplosionDebrisScript : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer _meshRenderer;

		[SerializeField]
		private ParticleSystem _particleSystem;

		[SerializeField]
		private Rigidbody _rigidbody;

		public MeshRenderer MeshRenderer => _meshRenderer;

		public ParticleSystem ParticleSystem => _particleSystem;

		public Rigidbody Rigidbody => _rigidbody;
	}
}
