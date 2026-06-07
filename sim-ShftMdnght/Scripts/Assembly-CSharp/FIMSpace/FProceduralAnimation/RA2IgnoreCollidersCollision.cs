using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[AddComponentMenu("FImpossible Creations/Ragdoll Animator/Ignore Collision Between Colliders", 111)]
	public class RA2IgnoreCollidersCollision : FimpossibleComponent
	{
		public List<Collider> AColliders = new List<Collider>();

		public List<Collider> BColliders = new List<Collider>();

		public List<Collider> IgnoreEachCollision = new List<Collider>();

		private void Start()
		{
			foreach (Collider aCollider in AColliders)
			{
				foreach (Collider bCollider in BColliders)
				{
					Physics.IgnoreCollision(aCollider, bCollider, ignore: true);
				}
			}
			foreach (Collider aCollider2 in AColliders)
			{
				foreach (Collider item in IgnoreEachCollision)
				{
					Physics.IgnoreCollision(aCollider2, item, ignore: true);
				}
			}
			foreach (Collider bCollider2 in BColliders)
			{
				foreach (Collider item2 in IgnoreEachCollision)
				{
					Physics.IgnoreCollision(bCollider2, item2, ignore: true);
				}
			}
			foreach (Collider item3 in IgnoreEachCollision)
			{
				foreach (Collider item4 in IgnoreEachCollision)
				{
					Physics.IgnoreCollision(item4, item3, ignore: true);
				}
			}
		}
	}
}
