using System;
using UnityEngine;
using UnityEngine.Events;

namespace ModApi.Common.Physics
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

		public void OnCollisionEnter(Collision collision)
		{
			CollisionEnter.Invoke(collision);
		}

		public void OnCollisionExit(Collision collision)
		{
			CollisionExit.Invoke(collision);
		}

		public void OnCollisionStay(Collision collision)
		{
			CollisionStay.Invoke(collision);
		}
	}
}
