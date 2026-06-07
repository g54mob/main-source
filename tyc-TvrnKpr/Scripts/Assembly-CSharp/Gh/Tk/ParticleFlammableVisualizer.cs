using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class ParticleFlammableVisualizer : MonoBehaviour
	{
		public ParticleSystem ps;

		public ParticleSystem hitPs;

		public float yOffset;

		public List<ParticleCollisionEvent> collisionEvents;

		private GameObjectX _gox;

		private void Start()
		{
		}

		private void OnParticleCollision(GameObject other)
		{
		}
	}
}
