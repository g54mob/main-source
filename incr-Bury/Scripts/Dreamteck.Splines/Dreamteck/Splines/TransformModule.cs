using System;
using UnityEngine;

namespace Dreamteck.Splines
{
	[Serializable]
	public class TransformModule : ISerializationCallbackReceiver
	{
		public enum VelocityHandleMode
		{
			Zero = 0,
			Preserve = 1,
			Align = 2,
			AlignRealistic = 3
		}

		[SerializeField]
		[HideInInspector]
		private bool _hasOffset;

		[SerializeField]
		[HideInInspector]
		private bool _hasRotationOffset;

		[SerializeField]
		[HideInInspector]
		private Vector2 _offset;

		[SerializeField]
		[HideInInspector]
		private Vector3 _rotationOffset = Vector3.zero;

		[SerializeField]
		[HideInInspector]
		private Vector3 _baseScale = Vector3.one;

		[SerializeField]
		[HideInInspector]
		private bool _2dMode;

		public VelocityHandleMode velocityHandleMode;

		private SplineSample _splineResult;

		public bool applyPositionX = true;

		public bool applyPositionY = true;

		public bool applyPositionZ = true;

		public bool applyPosition2D = true;

		public bool retainLocalPosition;

		public Spline.Direction direction = Spline.Direction.Forward;

		public bool applyRotationX = true;

		public bool applyRotationY = true;

		public bool applyRotationZ = true;

		public bool applyRotation2D = true;

		public bool retainLocalRotation;

		public bool applyScaleX;

		public bool applyScaleY;

		public bool applyScaleZ;

		[HideInInspector]
		public SplineUser targetUser;

		private static Vector3 position = Vector3.zero;

		private static Quaternion rotation = Quaternion.identity;

		public Vector2 offset
		{
			get
			{
				return _offset;
			}
			set
			{
				if (value != _offset)
				{
					_offset = value;
					_hasOffset = _offset != Vector2.zero;
					if (targetUser != null)
					{
						targetUser.Rebuild();
					}
				}
			}
		}

		public Vector3 rotationOffset
		{
			get
			{
				return _rotationOffset;
			}
			set
			{
				if (value != _rotationOffset)
				{
					_rotationOffset = value;
					_hasRotationOffset = _rotationOffset != Vector3.zero;
					if (targetUser != null)
					{
						targetUser.Rebuild();
					}
				}
			}
		}

		public bool hasOffset => _hasOffset;

		public bool hasRotationOffset => _hasRotationOffset;

		public Vector3 baseScale
		{
			get
			{
				return _baseScale;
			}
			set
			{
				if (value != _baseScale)
				{
					_baseScale = value;
					if (targetUser != null)
					{
						targetUser.Rebuild();
					}
				}
			}
		}

		public bool is2D
		{
			get
			{
				return _2dMode;
			}
			set
			{
				_2dMode = value;
			}
		}

		public SplineSample splineResult
		{
			get
			{
				return _splineResult;
			}
			set
			{
				_splineResult = value;
			}
		}

		public bool applyPosition
		{
			get
			{
				if (_2dMode)
				{
					return applyPosition2D;
				}
				if (!applyPositionX && !applyPositionY)
				{
					return applyPositionZ;
				}
				return true;
			}
			set
			{
				applyPositionX = (applyPositionY = (applyPositionZ = (applyPosition2D = value)));
			}
		}

		public bool applyRotation
		{
			get
			{
				if (_2dMode)
				{
					return applyRotation2D;
				}
				if (!applyRotationX && !applyRotationY)
				{
					return applyRotationZ;
				}
				return true;
			}
			set
			{
				applyRotationX = (applyRotationY = (applyRotationZ = (applyRotation2D = value)));
			}
		}

		public bool applyScale
		{
			get
			{
				if (!applyScaleX && !applyScaleY)
				{
					return applyScaleZ;
				}
				return true;
			}
			set
			{
				applyScaleX = (applyScaleY = (applyScaleZ = value));
			}
		}

		public void ApplyTransform(Transform input)
		{
			input.position = GetPosition(input.position);
			input.rotation = GetRotation(input.rotation);
			input.localScale = GetScale(input.localScale);
		}

		public void ApplyRigidbody(Rigidbody input)
		{
			input.transform.localScale = GetScale(input.transform.localScale);
			input.MovePosition(GetPosition(input.position));
			input.linearVelocity = HandleVelocity(input.linearVelocity);
			input.MoveRotation(GetRotation(input.rotation));
			Vector3 angularVelocity = input.angularVelocity;
			if (applyRotationX)
			{
				angularVelocity.x = 0f;
			}
			if (applyRotationY)
			{
				angularVelocity.y = 0f;
			}
			if (applyRotationZ || applyRotation2D)
			{
				angularVelocity.z = 0f;
			}
			input.angularVelocity = angularVelocity;
		}

		public void ApplyRigidbody2D(Rigidbody2D input)
		{
			input.transform.localScale = GetScale(input.transform.localScale);
			input.position = GetPosition(input.position);
			input.linearVelocity = HandleVelocity(input.linearVelocity);
			input.rotation = GetRotation(Quaternion.Euler(0f, 0f, input.rotation)).eulerAngles.z;
			if (applyRotationX)
			{
				input.angularVelocity = 0f;
			}
		}

		private Vector3 HandleVelocity(Vector3 velocity)
		{
			Vector3 vector = Vector3.zero;
			Vector3 right = Vector3.right;
			switch (velocityHandleMode)
			{
			case VelocityHandleMode.Preserve:
				vector = velocity;
				break;
			case VelocityHandleMode.Align:
				right = _splineResult.forward;
				if (Vector3.Dot(velocity, right) < 0f)
				{
					right *= -1f;
				}
				vector = right * velocity.magnitude;
				break;
			case VelocityHandleMode.AlignRealistic:
				right = _splineResult.forward;
				if (Vector3.Dot(velocity, right) < 0f)
				{
					right *= -1f;
				}
				vector = right * velocity.magnitude * Vector3.Dot(velocity.normalized, right);
				break;
			}
			if (applyPositionX)
			{
				velocity.x = vector.x;
			}
			if (applyPositionY)
			{
				velocity.y = vector.y;
			}
			if (applyPositionZ)
			{
				velocity.z = vector.z;
			}
			return velocity;
		}

		private Vector3 GetPosition(Vector3 inputPosition)
		{
			position = _splineResult.position;
			Vector2 vector = _offset;
			if (vector != Vector2.zero)
			{
				position += _splineResult.right * vector.x * _splineResult.size + _splineResult.up * vector.y * _splineResult.size;
			}
			if (retainLocalPosition)
			{
				Matrix4x4 matrix4x = Matrix4x4.TRS(position, _splineResult.rotation, Vector3.one);
				Vector3 point = matrix4x.inverse.MultiplyPoint3x4(targetUser.transform.position);
				point.x = (applyPositionX ? 0f : point.x);
				point.y = (applyPositionY ? 0f : point.y);
				point.z = (applyPositionZ ? 0f : point.z);
				inputPosition = matrix4x.MultiplyPoint3x4(point);
			}
			else
			{
				if (applyPositionX)
				{
					inputPosition.x = position.x;
				}
				if (applyPositionY)
				{
					inputPosition.y = position.y;
				}
				if (applyPositionZ)
				{
					inputPosition.z = position.z;
				}
			}
			return inputPosition;
		}

		private Quaternion GetRotation(Quaternion inputRotation)
		{
			rotation = Quaternion.LookRotation(_splineResult.forward * ((direction == Spline.Direction.Forward) ? 1f : (-1f)), _splineResult.up);
			if (_2dMode)
			{
				if (applyRotation2D)
				{
					rotation *= Quaternion.Euler(90f, -90f, 0f);
					inputRotation = Quaternion.AngleAxis(rotation.eulerAngles.z + _rotationOffset.z, Vector3.forward);
				}
				return inputRotation;
			}
			if (_rotationOffset != Vector3.zero)
			{
				rotation *= Quaternion.Euler(_rotationOffset);
			}
			if (retainLocalRotation)
			{
				Vector3 eulerAngles = (Quaternion.Inverse(rotation) * inputRotation).eulerAngles;
				eulerAngles.x = (applyRotationX ? 0f : eulerAngles.x);
				eulerAngles.y = (applyRotationY ? 0f : eulerAngles.y);
				eulerAngles.z = (applyRotationZ ? 0f : eulerAngles.z);
				inputRotation = rotation * Quaternion.Euler(eulerAngles);
			}
			else if (!applyRotationX || !applyRotationY || !applyRotationZ)
			{
				Vector3 eulerAngles2 = rotation.eulerAngles;
				Vector3 eulerAngles3 = inputRotation.eulerAngles;
				if (!applyRotationX)
				{
					eulerAngles2.x = eulerAngles3.x;
				}
				if (!applyRotationY)
				{
					eulerAngles2.y = eulerAngles3.y;
				}
				if (!applyRotationZ)
				{
					eulerAngles2.z = eulerAngles3.z;
				}
				inputRotation.eulerAngles = eulerAngles2;
			}
			else
			{
				inputRotation = rotation;
			}
			return inputRotation;
		}

		private Vector3 GetScale(Vector3 inputScale)
		{
			if (applyScaleX)
			{
				inputScale.x = _baseScale.x * _splineResult.size;
			}
			if (applyScaleY)
			{
				inputScale.y = _baseScale.y * _splineResult.size;
			}
			if (applyScaleZ)
			{
				inputScale.z = _baseScale.z * _splineResult.size;
			}
			return inputScale;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			_hasRotationOffset = _rotationOffset != Vector3.zero;
			_hasOffset = _offset != Vector2.zero;
		}
	}
}
