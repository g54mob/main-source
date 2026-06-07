using UnityEngine;

namespace Rewired.ComponentControls.Effects
{
	[AddComponentMenu("Rewired/Touch Controls/Effects/Rotate Around Axis")]
	public class RotateAroundAxis : MonoBehaviour
	{
		public enum Speed
		{
			Stopped = 0,
			Slow = 1,
			Fast = 2
		}

		public enum RotationAxis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		[SerializeField]
		[Tooltip("The current speed of rotation.")]
		[CustomObfuscation(rename = false)]
		private Speed _speed;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The speed of rotation when Speed is set to Slow. This measured in degrees per second.")]
		private float _slowRotationSpeed;

		[Tooltip("The speed of rotation when Speed is set to Fast. This measured in degrees per second.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _fastRotationSpeed;

		[CustomObfuscation(rename = false)]
		[Tooltip("The axis around which rotation will occur.")]
		[SerializeField]
		private RotationAxis _rotateAroundAxis;

		[Tooltip("The space in which rotation will occur.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Space _relativeTo;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Reverses the rotation direction.")]
		private bool _reverse;

		public Speed speed
		{
			get
			{
				return default(Speed);
			}
			set
			{
			}
		}

		public float slowRotationSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float fastRotationSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public RotationAxis rotateAroundAxis
		{
			get
			{
				return default(RotationAxis);
			}
			set
			{
			}
		}

		public Space relativeTo
		{
			get
			{
				return default(Space);
			}
			set
			{
			}
		}

		public bool reverse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
		}

		private static Vector3 yzmkpaihcbOegsiKJfSeHfHDqYJR(RotationAxis P_0)
		{
			return default(Vector3);
		}

		public void SetSpeed(Speed speed)
		{
		}

		public void SetSpeed(int speed)
		{
		}
	}
}
