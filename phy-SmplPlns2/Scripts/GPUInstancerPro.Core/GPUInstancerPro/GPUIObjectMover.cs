using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUIObjectMover : MonoBehaviour
	{
		[Range(-100f, 100f)]
		public float forwardMove;

		[Range(-100f, 100f)]
		public float upwardMove;

		public Vector3 positionChange;

		public Vector3 rotationChange;

		public bool isLooping;

		public float loopDistance;

		public float loopAngle;

		public bool loopChangeDirection;

		public bool isRayCasting;

		public float rayCastHeight = 15f;

		public int rayCastLayer = 6;

		public float rayCastMaxDistance = 200f;

		public bool isOrbiting;

		public Transform orbitCenter;

		public float orbitSpeed = 1f;

		private Transform _cachedTransform;

		private Vector3 _startPosition;

		private Quaternion _startRotation;

		private float _orbitDistance;

		private bool _loopChangedDirection;

		private void OnEnable()
		{
			_cachedTransform = base.transform;
			_startPosition = _cachedTransform.position;
			_startRotation = _cachedTransform.rotation;
			if (orbitCenter != null)
			{
				_orbitDistance = Vector3.Distance(_startPosition, orbitCenter.position);
			}
		}

		private void Update()
		{
			Vector3 position = _cachedTransform.position;
			if (isOrbiting)
			{
				if (!(orbitCenter == null))
				{
					Vector3 position2 = orbitCenter.position;
					Vector3 position3 = position + _cachedTransform.right * orbitSpeed * Time.deltaTime;
					position3.y = _startPosition.y;
					_cachedTransform.position = position3;
					_cachedTransform.LookAt(orbitCenter);
					position3 = position2 - _cachedTransform.forward * _orbitDistance;
					position3.y = _startPosition.y;
					_cachedTransform.position = position3;
					Vector3 eulerAngles = _cachedTransform.rotation.eulerAngles;
					eulerAngles.x = _startRotation.eulerAngles.x;
					_cachedTransform.rotation = Quaternion.Euler(eulerAngles);
				}
				return;
			}
			Quaternion rotation = _cachedTransform.rotation;
			if (isLooping)
			{
				if (_loopChangedDirection && ((loopDistance > 0f && 0.1f > Vector3.Distance(position, _startPosition)) || (loopAngle > 0f && 0.5f > Mathf.Abs(Quaternion.Angle(rotation, _startRotation)))))
				{
					_loopChangedDirection = false;
					forwardMove = 0f - forwardMove;
					rotationChange = -rotationChange;
				}
				else if ((loopDistance > 0f && loopDistance < Vector3.Distance(position, _startPosition)) || (loopAngle > 0f && loopAngle < Mathf.Abs(Quaternion.Angle(rotation, _startRotation))))
				{
					if (!loopChangeDirection)
					{
						_cachedTransform.position = _startPosition;
						_cachedTransform.rotation = _startRotation;
						return;
					}
					_loopChangedDirection = true;
					forwardMove = 0f - forwardMove;
					rotationChange = -rotationChange;
				}
			}
			Vector3 vector = position;
			if (forwardMove != 0f)
			{
				vector += _cachedTransform.forward * forwardMove * Time.deltaTime;
			}
			if (upwardMove != 0f)
			{
				vector += _cachedTransform.up * upwardMove * Time.deltaTime;
			}
			vector += positionChange * Time.deltaTime;
			if (isRayCasting && Physics.Raycast(vector, Vector3.down, out var hitInfo, rayCastMaxDistance, 1 << rayCastLayer))
			{
				vector.y = hitInfo.point.y + rayCastHeight;
			}
			_cachedTransform.position = vector;
			Vector3 euler = rotation.eulerAngles + rotationChange * Time.deltaTime;
			_cachedTransform.rotation = Quaternion.Euler(euler);
		}

		public void ResetToStartingPositionAndRotation()
		{
			_cachedTransform.position = _startPosition;
			_cachedTransform.rotation = _startRotation;
		}
	}
}
