using UnityEngine;

namespace MateoRyhr
{
	public class InteractableJointByAngle : MonoBehaviour
	{
		[SerializeField]
		private HingeJoint _hingeJoint;

		[SerializeField]
		private Vector3 _rotationOnClosed;

		[SerializeField]
		private Vector3 _rotationOnOpen;

		[SerializeField]
		private float _timeToRotate;

		[SerializeField]
		private bool _collisionCancelInteraction;

		[SerializeField]
		private float _forceToCancelInteraction;

		private Rigidbody _rigidbody;

		private void Awake()
		{
			_rigidbody = _hingeJoint.GetComponent<Rigidbody>();
		}

		private void OnCollisionStay(Collision other)
		{
			if (_collisionCancelInteraction && other.impulse.magnitude > _forceToCancelInteraction)
			{
				StopAllCoroutines();
			}
		}

		public void Interact()
		{
			if (IsNearestToGetClosed())
			{
				Open();
			}
			else
			{
				Close();
			}
		}

		private void Close()
		{
			StartRotation(_rotationOnClosed);
		}

		private void Open()
		{
			StartRotation(_rotationOnOpen);
		}

		private void StartRotation(Vector3 targetRotation)
		{
			Vector3 eulerAngles = _hingeJoint.transform.rotation.eulerAngles;
			this.LerpVector(eulerAngles, targetRotation, _timeToRotate, Rotate, fixedUpdate: true, timeScaled: true);
		}

		private void Rotate(Vector3 newRotation)
		{
			_rigidbody.MoveRotation(Quaternion.Euler(newRotation));
		}

		private bool IsNearestToGetClosed()
		{
			float num = Vector3.Distance(_hingeJoint.transform.rotation.eulerAngles, _rotationOnClosed);
			float num2 = Vector3.Distance(_hingeJoint.transform.rotation.eulerAngles, _rotationOnOpen);
			return num < num2;
		}
	}
}
