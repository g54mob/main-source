using UnityEngine;

namespace Photon.Pun.Demo.Asteroids
{
	public class Asteroid : MonoBehaviour
	{
		public bool isLargeAsteroid;

		private bool isDestroyed;

		private PhotonView photonView;

		private Rigidbody rigidbody;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void OnCollisionEnter(Collision collision)
		{
		}

		private void DestroyAsteroidGlobally()
		{
		}

		private void DestroyAsteroidLocally()
		{
		}
	}
}
