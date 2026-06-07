using UnityEngine;

namespace Rewired.ComponentControls.Effects
{
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
		[CustomObfuscation]
		private Speed _speed;

		[SerializeField]
		[CustomObfuscation]
		private float _slowRotationSpeed;

		[SerializeField]
		[CustomObfuscation]
		private float _fastRotationSpeed;

		[CustomObfuscation]
		[SerializeField]
		private RotationAxis _rotateAroundAxis;

		[SerializeField]
		[CustomObfuscation]
		private Space _relativeTo;

		[CustomObfuscation]
		[SerializeField]
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

		[CustomObfuscation]
		private void Update()
		{
		}

		private static Vector3 HUcKKIFLfmiycHeVeQOlfZgRXqGIA(RotationAxis P_0)
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
