using Photon.Realtime;
using UnityEngine;

namespace Photon.Pun.Demo.Asteroids
{
	public class Bullet : MonoBehaviour
	{
		public Player Owner { get; private set; }

		public void Start()
		{
		}

		public void OnCollisionEnter(Collision collision)
		{
		}

		public void InitializeBullet(Player owner, Vector3 originalDirection, float lag)
		{
		}
	}
}
