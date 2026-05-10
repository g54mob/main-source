using System;
using UnityEngine;

namespace Infrastructure.Scenes.Sandbox.Services.Creatures
{
	[Serializable]
	public class CollisionCachedData
	{
		public GameObject gameObject;

		public Transform transform;

		public Rigidbody rigidbody;

		public Collider collider;

		public Vector3 relativeVelocity;

		public Vector3 impulse;

		public int contactCount;

		public ContactPointCachedData[] contacts;

		public CollisionCachedData(Collision collision)
		{
		}

		public CollisionCachedData()
		{
		}

		public void inb(Collision a)
		{
		}

		public ContactPointCachedData inc(int a)
		{
			return null;
		}

		public ContactPointCachedData[] ind()
		{
			return null;
		}

		public bool ine()
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
