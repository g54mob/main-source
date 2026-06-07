using System;
using UnityEngine;
using UnityEngine.Events;

namespace Jundroo.Common.Physics
{
	public class CollisionNotifier : MonoBehaviour
	{
		[Serializable]
		public class CollisionEvent : UnityEvent<Collision>
		{
		}

		[SerializeField]
		private CollisionEvent _collisionEnter = new CollisionEvent();

		[SerializeField]
		private CollisionEvent _collisionExit = new CollisionEvent();

		[SerializeField]
		private CollisionEvent _collisionStay = new CollisionEvent();

		public CollisionEvent CollisionEnter => _collisionEnter;

		public CollisionEvent CollisionExit => _collisionExit;

		public CollisionEvent CollisionStay => _collisionStay;

		protected virtual void OnCollisionEnter(Collision collision)
		{
			CollisionEnter.Invoke(collision);
		}

		protected virtual void OnCollisionExit(Collision collision)
		{
			CollisionExit.Invoke(collision);
		}

		protected virtual void OnCollisionStay(Collision collision)
		{
			CollisionStay.Invoke(collision);
		}
	}
}
