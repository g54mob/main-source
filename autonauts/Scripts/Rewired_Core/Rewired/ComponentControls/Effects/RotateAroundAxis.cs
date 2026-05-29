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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The current speed of rotation.")]
		private Speed _speed;

		[SerializeField]
		[Tooltip("The speed of rotation when Speed is set to Slow. This measured in degrees per second.")]
		[CustomObfuscation(rename = false)]
		private float _slowRotationSpeed = 5f;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The speed of rotation when Speed is set to Fast. This measured in degrees per second.")]
		private float _fastRotationSpeed = 20f;

		[Tooltip("The axis around which rotation will occur.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private RotationAxis _rotateAroundAxis = RotationAxis.Z;

		[Tooltip("The space in which rotation will occur.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Space _relativeTo = Space.Self;

		[Tooltip("Reverses the rotation direction.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
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
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -1447088651;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1447088650)
			{
			case 0:
				break;
			case 3:
				return;
			case 2:
				goto IL_0032;
			default:
				goto IL_0061;
			}
			goto IL_0008;
			IL_0032:
			float num2 = ((_speed == Speed.Fast) ? _fastRotationSpeed : _slowRotationSpeed);
			if (_reverse)
			{
				num2 *= -1f;
				num = -1447088649;
				goto IL_000d;
			}
			goto IL_0061;
			IL_0061:
			base.transform.Rotate(KTpmlaRTblWjuGPmcOTeFzfqNUU(_rotateAroundAxis), num2 * Time.deltaTime, _relativeTo);
		}

		private static Vector3 KTpmlaRTblWjuGPmcOTeFzfqNUU(RotationAxis P_0)
		{
			switch (P_0)
			{
			default:
				while (true)
				{
					switch (-1599852489 ^ -1599852490)
					{
					case 2:
						continue;
					case 1:
						throw new NotImplementedException();
					}
					break;
				}
				goto case RotationAxis.X;
			case RotationAxis.X:
				return new Vector3(1f, 0f, 0f);
			case RotationAxis.Y:
				return new Vector3(0f, 1f, 0f);
			case RotationAxis.Z:
				return new Vector3(0f, 0f, 1f);
			}
		}

		public void SetSpeed(Speed speed)
		{
			_speed = speed;
		}

		public void SetSpeed(int speed)
		{
			if (!Enum.IsDefined(typeof(Speed), speed))
			{
				return;
			}
			while (true)
			{
				_speed = (Speed)speed;
				int num = 1676394929;
				while (true)
				{
					switch (num ^ 0x63EBC1B0)
					{
					case 0:
						goto IL_0018;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0018:
					num = 1676394930;
				}
			}
		}
	}
}
