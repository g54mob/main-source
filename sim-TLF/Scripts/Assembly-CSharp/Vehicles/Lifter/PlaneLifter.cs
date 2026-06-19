using UnityEngine;

namespace Vehicles.Lifter
{
	public class PlaneLifter : MonoBehaviour
	{
		[SerializeField]
		private FixedJoint _liftingObject;

		[SerializeField]
		private float _liftSpeed = 1f;

		public void AttachToObject(Rigidbody objectToLift)
		{
			_liftingObject.connectedBody = objectToLift;
		}

		public void DetachFromObject()
		{
			_liftingObject.connectedBody = null;
		}

		public void LiftDown()
		{
			_liftingObject.transform.position -= Vector3.up * _liftSpeed * Time.deltaTime;
		}

		public void LiftUp()
		{
			_liftingObject.transform.position += Vector3.up * _liftSpeed * Time.deltaTime;
		}
	}
}
