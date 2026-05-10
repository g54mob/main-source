using System;
using UnityEngine;

namespace Infrastructure.Scenes.Sandbox.Services.Creatures
{
	[Serializable]
	public class ContactPointCachedData
	{
		public Vector3 thisColliderLocalPoint;

		public Vector3 otherColliderLocalPoint;

		public Vector3 normal;

		public Vector3 impulse;

		public float separation;

		public Collider thisCollider;

		public Collider otherCollider;

		public ContactPointCachedData(ContactPoint contactPoint)
		{
		}

		public ContactPointCachedData()
		{
		}

		public void inf(ContactPoint a)
		{
		}

		public bool ing(out Vector3 a)
		{
			a = default(Vector3);
			return false;
		}

		public bool inh(out Vector3 a)
		{
			a = default(Vector3);
			return false;
		}

		public bool ini()
		{
			return false;
		}
	}
}
