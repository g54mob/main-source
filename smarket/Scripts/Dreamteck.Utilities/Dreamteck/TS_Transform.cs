using System;
using UnityEngine;

namespace Dreamteck
{
	[Serializable]
	public class TS_Transform
	{
		private bool setPosition;

		private bool setRotation;

		private bool setScale;

		private bool setLocalPosition;

		private bool setLocalRotation;

		[SerializeField]
		[HideInInspector]
		private Transform _transform;

		[SerializeField]
		[HideInInspector]
		private float posX;

		[SerializeField]
		[HideInInspector]
		private float posY;

		[SerializeField]
		[HideInInspector]
		private float posZ;

		[SerializeField]
		[HideInInspector]
		private float scaleX;

		[SerializeField]
		[HideInInspector]
		private float scaleY;

		[SerializeField]
		[HideInInspector]
		private float scaleZ;

		[SerializeField]
		[HideInInspector]
		private float lossyScaleX;

		[SerializeField]
		[HideInInspector]
		private float lossyScaleY;

		[SerializeField]
		[HideInInspector]
		private float lossyScaleZ;

		[SerializeField]
		[HideInInspector]
		private float rotX;

		[SerializeField]
		[HideInInspector]
		private float rotY;

		[SerializeField]
		[HideInInspector]
		private float rotZ;

		[SerializeField]
		[HideInInspector]
		private float rotW;

		[SerializeField]
		[HideInInspector]
		private float lposX;

		[SerializeField]
		[HideInInspector]
		private float lposY;

		[SerializeField]
		[HideInInspector]
		private float lposZ;

		[SerializeField]
		[HideInInspector]
		private float lrotX;

		[SerializeField]
		[HideInInspector]
		private float lrotY;

		[SerializeField]
		[HideInInspector]
		private float lrotZ;

		[SerializeField]
		[HideInInspector]
		private float lrotW;

		public Vector3 position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Quaternion rotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public Vector3 scale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 lossyScale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Vector3 localPosition
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Quaternion localRotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public Transform transform => null;

		public TS_Transform(Transform input)
		{
		}

		public void Update()
		{
		}

		public void SetTransform(Transform input)
		{
		}

		public bool HasChange()
		{
			return false;
		}

		public bool HasPositionChange()
		{
			return false;
		}

		public bool HasRotationChange()
		{
			return false;
		}

		public bool HasScaleChange()
		{
			return false;
		}

		public Vector3 TransformPoint(Vector3 point)
		{
			return default(Vector3);
		}

		public Vector3 TransformDirection(Vector3 direction)
		{
			return default(Vector3);
		}

		public Vector3 InverseTransformPoint(Vector3 point)
		{
			return default(Vector3);
		}

		public Vector3 InverseTransformDirection(Vector3 direction)
		{
			return default(Vector3);
		}

		public T GetComponent<T>()
		{
			return default(T);
		}
	}
}
