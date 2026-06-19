using Items;
using UnityEngine;

namespace Vehicles.Lifter
{
	public class LiftingObjectTrigger : MonoBehaviour, IUsable
	{
		[SerializeField]
		private FixedJoint _fixedJoint;

		[SerializeField]
		private bool _isObjectInTriggered;

		[SerializeField]
		private bool _isGripped;

		private GrabTrigger _currentGrabTrigger;

		public bool IsObjectInTrigger => _isObjectInTriggered;

		public bool IsGripped => _isGripped;

		public bool GrabbedRigidbody => _currentGrabTrigger.Rigidbody;

		private void OnTriggerEnter(Collider other)
		{
			_isObjectInTriggered = true;
			other.TryGetComponent<GrabTrigger>(out _currentGrabTrigger);
		}

		private void OnTriggerExit(Collider other)
		{
			_isObjectInTriggered = false;
			_currentGrabTrigger = null;
		}

		void IUsable.Use()
		{
			if (_isObjectInTriggered)
			{
				_isGripped = !_isGripped;
			}
			else if (_isGripped)
			{
				_isGripped = false;
			}
		}

		void IUsable.UnUse()
		{
		}

		public void AttachRigidbody()
		{
			if (_currentGrabTrigger.Rigidbody != null)
			{
				Vector3 eulerAngles = _currentGrabTrigger.Rigidbody.transform.rotation.eulerAngles;
				eulerAngles.z = 0f;
				_currentGrabTrigger.Rigidbody.transform.rotation = Quaternion.Euler(eulerAngles);
				_fixedJoint.connectedBody = _currentGrabTrigger.Rigidbody;
			}
		}

		public void DetachRigidbody()
		{
			_fixedJoint.connectedBody = null;
		}
	}
}
