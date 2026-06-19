using UnityEngine;

namespace MateoRyhr
{
	public class JointTargetRotatorByVector2 : MonoBehaviour
	{
		[SerializeField]
		private ConfigurableJoint _joint;

		[SerializeField]
		private float _rotationSpeed = 10f;

		private Vector2 _input;

		private Vector3 _rotationToAdd;

		public void SetInput(Vector2 input)
		{
			_input = input;
		}

		private void FixedUpdate()
		{
			if (!(_joint.connectedBody == null))
			{
				Vector2 vector = _input * Time.fixedDeltaTime * _rotationSpeed;
				_rotationToAdd = Vector3.zero;
				Vector3 forward = base.transform.forward;
				Vector3 up = base.transform.up;
				if (Mathf.Abs(vector.y) > Mathf.Abs(vector.x) * 0.66f)
				{
					_rotationToAdd += forward * vector.y;
				}
				if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y) * 0.66f)
				{
					_rotationToAdd += up * (0f - vector.x);
				}
				_joint.connectedBody.angularVelocity = _rotationToAdd;
			}
		}

		public void ResetRotation()
		{
			_joint.targetRotation = Quaternion.identity;
		}
	}
}
