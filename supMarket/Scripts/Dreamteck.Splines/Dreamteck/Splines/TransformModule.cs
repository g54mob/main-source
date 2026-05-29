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
		private Vector3 _rotationOffset;

		[SerializeField]
		[HideInInspector]
		private Vector3 _baseScale;

		[SerializeField]
		[HideInInspector]
		private bool _2dMode;

		public VelocityHandleMode velocityHandleMode;

		private SplineSample _splineResult;

		public bool applyPositionX;

		public bool applyPositionY;

		public bool applyPositionZ;

		public bool applyPosition2D;

		public bool retainLocalPosition;

		public Spline.Direction direction;

		public bool applyRotationX;

		public bool applyRotationY;

		public bool applyRotationZ;

		public bool applyRotation2D;

		public bool retainLocalRotation;

		public bool applyScaleX;

		public bool applyScaleY;

		public bool applyScaleZ;

		[HideInInspector]
		public SplineUser targetUser;

		private static Vector3 position;

		private static Quaternion rotation;

		public Vector2 offset
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector3 rotationOffset
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public bool hasOffset => false;

		public bool hasRotationOffset => false;

		public Vector3 baseScale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public bool is2D
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public SplineSample splineResult
		{
			get
			{
				return default(SplineSample);
			}
			set
			{
			}
		}

		public bool applyPosition
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool applyRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool applyScale
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void ApplyTransform(Transform input)
		{
		}

		public void ApplyRigidbody(Rigidbody input)
		{
		}

		public void ApplyRigidbody2D(Rigidbody2D input)
		{
		}

		private Vector3 HandleVelocity(Vector3 velocity)
		{
			return default(Vector3);
		}

		private Vector3 GetPosition(Vector3 inputPosition)
		{
			return default(Vector3);
		}

		private Quaternion GetRotation(Quaternion inputRotation)
		{
			return default(Quaternion);
		}

		private Vector3 GetScale(Vector3 inputScale)
		{
			return default(Vector3);
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
