using System;
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
		[Tooltip("The current speed of rotation.")]
		[CustomObfuscation(rename = false)]
		private Speed _speed;

		[Tooltip("The speed of rotation when Speed is set to Slow. This measured in degrees per second.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _slowRotationSpeed = 5f;

		[Tooltip("The speed of rotation when Speed is set to Fast. This measured in degrees per second.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _fastRotationSpeed = 20f;

		[Tooltip("The axis around which rotation will occur.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private RotationAxis _rotateAroundAxis = RotationAxis.Z;

		[CustomObfuscation(rename = false)]
		[Tooltip("The space in which rotation will occur.")]
		[SerializeField]
		private Space _relativeTo = Space.Self;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Reverses the rotation direction.")]
		private bool _reverse;

		public Speed speed
		{
			get
			{
				return _speed;
			}
			set
			{
				_speed = value;
			}
		}

		public float slowRotationSpeed
		{
			get
			{
				return _slowRotationSpeed;
			}
			set
			{
				_slowRotationSpeed = value;
			}
		}

		public float fastRotationSpeed
		{
			get
			{
				return _fastRotationSpeed;
			}
			set
			{
				_fastRotationSpeed = value;
			}
		}

		public RotationAxis rotateAroundAxis
		{
			get
			{
				return _rotateAroundAxis;
			}
			set
			{
				_rotateAroundAxis = value;
			}
		}

		public Space relativeTo
		{
			get
			{
				return _relativeTo;
			}
			set
			{
				_relativeTo = value;
			}
		}

		public bool reverse
		{
			get
			{
				return _reverse;
			}
			set
			{
				_reverse = value;
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			if (_speed == Speed.Stopped)
			{
				return;
			}
			while (true)
			{
				float num = ((_speed == Speed.Fast) ? _fastRotationSpeed : _slowRotationSpeed);
				int num2;
				if (_reverse)
				{
					num *= -1f;
					num2 = -1606372083;
					goto IL_000e;
				}
				goto IL_005a;
				IL_000e:
				while (true)
				{
					switch (num2 ^ -1606372084)
					{
					case 0:
						num2 = -1606372082;
						continue;
					default:
						return;
					case 2:
						break;
					case 1:
						goto IL_005a;
					case 3:
						return;
					}
					break;
				}
				continue;
				IL_005a:
				base.transform.Rotate(zJvhqntnnnvGRcdbSnXecZdmqBX(_rotateAroundAxis), num * Time.deltaTime, _relativeTo);
				num2 = -1606372081;
				goto IL_000e;
			}
		}

		private static Vector3 zJvhqntnnnvGRcdbSnXecZdmqBX(RotationAxis P_0)
		{
			switch (P_0)
			{
			case RotationAxis.X:
				return new Vector3(1f, 0f, 0f);
			case RotationAxis.Y:
				return new Vector3(0f, 1f, 0f);
			case RotationAxis.Z:
				return new Vector3(0f, 0f, 1f);
			default:
				throw new NotImplementedException();
			}
		}

		public void SetSpeed(Speed speed)
		{
			_speed = speed;
		}

		public void SetSpeed(int speed)
		{
			if (Enum.IsDefined(typeof(Speed), speed))
			{
				_speed = (Speed)speed;
			}
		}
	}
}
