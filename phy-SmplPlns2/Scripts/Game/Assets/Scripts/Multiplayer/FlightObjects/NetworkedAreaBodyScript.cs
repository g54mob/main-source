using System;
using Assets.Scripts.Multiplayer.Extensions;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public class NetworkedAreaBodyScript : NetworkedAreaItemScript
	{
		private Rigidbody _body;

		private Rigidbody _parentBody;

		private Vector3 _positionAtLastWrite;

		private Quaternion _rotationAtLastWrite;

		public Rigidbody Body => _body ?? (_body = GetComponent<Rigidbody>());

		public override float CalculateDelta()
		{
			if (base.IsActive)
			{
				return ((_positionAtLastWrite - base.transform.localPosition).sqrMagnitude * 20f + Quaternion.Angle(_rotationAtLastWrite, base.transform.localRotation) * 1f) * base.TimeSinceLastWrite;
			}
			return 0f;
		}

		public override void ReadState(PooledReader reader, float timeDelta)
		{
			base.ReadState(reader, timeDelta);
			Vector3 position = reader.ReadVector3();
			Quaternion quaternion = reader.ReadQuaternion64();
			Vector3 vector = reader.ReadVector3();
			Vector3 vector2 = reader.ReadVector3Short();
			if (_parentBody != null)
			{
				Vector3 vector3 = vector;
				Vector3 position2 = base.transform.parent.TransformPoint(position);
				Vector3 position3 = _parentBody.transform.InverseTransformPoint(position2) + vector3 * timeDelta;
				Vector3 position4 = _parentBody.transform.TransformPoint(position3);
				base.transform.position = position4;
				if (!_body.isKinematic)
				{
					_body.linearVelocity = _parentBody.linearVelocity + _parentBody.transform.TransformDirection(vector3);
				}
			}
			else
			{
				Vector3 vector4 = vector;
				Vector3 position5 = base.transform.parent.TransformPoint(position) + vector4 * timeDelta;
				base.transform.position = position5;
				if (!_body.isKinematic)
				{
					_body.linearVelocity = vector4;
				}
			}
			Quaternion quaternion2 = base.transform.parent.rotation * quaternion;
			Quaternion quaternion3 = Quaternion.identity;
			if (vector2 != Vector3.zero)
			{
				float angle = vector2.magnitude * 57.29578f * timeDelta;
				Vector3 normalized = vector2.normalized;
				quaternion3 = Quaternion.AngleAxis(angle, normalized);
			}
			Quaternion rotation = quaternion3 * quaternion2;
			base.transform.rotation = rotation;
			if (!_body.isKinematic)
			{
				_body.angularVelocity = vector2;
			}
		}

		public override void WriteState(PooledWriter writer)
		{
			base.WriteState(writer);
			_positionAtLastWrite = base.transform.localPosition;
			_rotationAtLastWrite = base.transform.localRotation;
			if (base.IsActive && _positionAtLastWrite.sqrMagnitude > 1000000f)
			{
				base.IsActive = false;
			}
			writer.WriteVector3(_positionAtLastWrite);
			writer.WriteQuaternion64(_rotationAtLastWrite);
			try
			{
				Vector3 value;
				if (!_body.isKinematic)
				{
					if (_parentBody != null)
					{
						Vector3 direction = _body.linearVelocity - _parentBody.linearVelocity;
						value = _parentBody.transform.InverseTransformDirection(direction);
					}
					else
					{
						value = _body.linearVelocity;
					}
				}
				else
				{
					value = Vector3.zero;
				}
				writer.WriteVector3(value);
				writer.WriteVector3Short(_body.angularVelocity);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception, base.gameObject);
			}
		}

		protected override void Awake()
		{
			base.Awake();
			_body = GetComponent<Rigidbody>();
			_parentBody = base.transform.parent.GetComponentInParent<Rigidbody>();
		}

		protected virtual void Start()
		{
			if (_parentBody != null && !_body.isKinematic)
			{
				_body.linearVelocity = _parentBody.linearVelocity;
			}
		}
	}
}
