using System;
using UnityEngine;

namespace Lightbug.Utilities
{
	public struct Trigger : IEquatable<Trigger>, IEquatable<Collider>, IEquatable<Collider2D>
	{
		public bool firstContact;

		public Collider2D collider2D;

		public Collider collider3D;

		public GameObject gameObject;

		public Transform transform;

		private float fixedTime;

		public Trigger(Collider collider, float fixedTime)
		{
			this = default(Trigger);
			this.fixedTime = fixedTime;
			firstContact = true;
			collider3D = collider;
			gameObject = collider.gameObject;
			transform = collider.transform;
		}

		public Trigger(Collider2D collider, float fixedTime)
		{
			this = default(Trigger);
			this.fixedTime = fixedTime;
			firstContact = true;
			collider2D = collider;
			gameObject = collider.gameObject;
			transform = collider.transform;
		}

		public void Update(float fixedTime)
		{
			if (this.fixedTime != fixedTime)
			{
				firstContact = false;
			}
		}

		public void Set(bool firstContact, Collider2D collider)
		{
			if (firstContact)
			{
				fixedTime = Time.fixedTime;
			}
			this.firstContact = firstContact;
			collider2D = collider;
			gameObject = collider.gameObject;
			transform = collider.transform;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj.GetType() != typeof(Trigger))
			{
				return false;
			}
			return Equals((Trigger)obj);
		}

		public override int GetHashCode()
		{
			return gameObject.GetHashCode();
		}

		public bool Equals(Collider collider3D)
		{
			if (collider3D == null)
			{
				return false;
			}
			return this.collider3D == collider3D;
		}

		public bool Equals(Collider2D collider2D)
		{
			if (collider2D == null)
			{
				return false;
			}
			return this.collider2D == collider2D;
		}

		public bool Equals(Trigger trigger)
		{
			return gameObject == trigger.gameObject;
		}

		public static bool operator ==(Trigger a, Collider b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Trigger a, Collider b)
		{
			return !a.Equals(b);
		}

		public static bool operator ==(Trigger a, Collider2D b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Trigger a, Collider2D b)
		{
			return !a.Equals(b);
		}

		public static bool operator ==(Trigger a, Trigger b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(Trigger a, Trigger b)
		{
			return !a.Equals(b);
		}
	}
}
