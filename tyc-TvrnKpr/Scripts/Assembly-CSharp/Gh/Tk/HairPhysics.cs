using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(Collider))]
	[DisallowMultipleComponent]
	public class HairPhysics : MonoBehaviour
	{
		private Collider _collider;

		private List<Collider> _collidableObjects;

		private void Start()
		{
		}

		public void SetCollidableObjects(List<Collider> collidableObjects)
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
		}
	}
}
