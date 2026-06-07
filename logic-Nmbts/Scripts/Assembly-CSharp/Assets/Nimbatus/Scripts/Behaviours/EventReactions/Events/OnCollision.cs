using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnCollision : NimbatusEvent
	{
		public LayerMask Mask;

		protected override void Subscribe()
		{
			OwnWorldObject.OnCollision += OwnWorldObject_OnCollision;
		}

		private void OwnWorldObject_OnCollision(Collision collision)
		{
			if (collision.gameObject != null && (int)Mask == ((int)Mask | (1 << collision.gameObject.layer)))
			{
				RaiseEvent();
			}
		}

		protected override void Unsubscribe()
		{
			OwnWorldObject.OnCollision -= OwnWorldObject_OnCollision;
		}
	}
}
