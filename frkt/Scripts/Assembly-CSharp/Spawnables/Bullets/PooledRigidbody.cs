using Components.Rigidbodies;
using UnityEngine;

namespace Spawnables.Bullets
{
	[RequireComponent(typeof(ExtendedRigidbody))]
	public class PooledRigidbody : h
	{
		public Rigidbody xdq => null;

		[field: SerializeField]
		private ExtendedRigidbody ExtendedRigidbody { get; set; }

		protected sealed override void cxu()
		{
		}

		protected sealed override void cxv()
		{
		}

		protected virtual void gfx()
		{
		}

		protected virtual void gfy()
		{
		}
	}
}
