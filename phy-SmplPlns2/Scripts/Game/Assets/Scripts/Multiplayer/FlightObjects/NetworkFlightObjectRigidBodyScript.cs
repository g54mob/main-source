using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Combat.Bullets;
using Assets.Scripts.Multiplayer.Extensions;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public class NetworkFlightObjectRigidBodyScript : NetworkFlightObjectComponent, IBulletImpact
	{
		private Rigidbody _body;

		private FlightSceneNetworkScript _flightSceneNetwork;

		private float _lastPhysicsTime;

		private double _lastSyncTime;

		[SerializeField]
		private float _syncRate;

		public float SyncRate
		{
			get
			{
				return _syncRate;
			}
			set
			{
				_syncRate = value;
			}
		}

		public bool OnBulletImpact(in Bullet bullet, BulletData bulletData)
		{
			return !base.IsOwner;
		}

		public override void OnCreated(NetworkFlightObject networkFlightObject)
		{
			base.OnCreated(networkFlightObject);
			_body = GetComponent<Rigidbody>();
			if (_body == null)
			{
				Debug.LogError("Unable to find Rigidbody for NetworkFlightObjectRigidBodyScript on game object '" + base.name + "' for flight object '" + networkFlightObject.name + "'", base.gameObject);
			}
			_flightSceneNetwork = FlightSceneScript.Instance.FlightSceneNetwork;
		}

		public override void ReadState(PooledReader reader)
		{
			if (!reader.ReadBoolean())
			{
				return;
			}
			float num = reader.ReadSingle();
			Vector3 vector = reader.ReadVector3() - GameWorld.Instance.FloatingOriginOffset;
			float num2 = _flightSceneNetwork.PhysicsTime - num;
			if (!(_lastPhysicsTime <= num))
			{
				return;
			}
			_lastPhysicsTime = num;
			Vector3 vector2 = reader.ReadVector3();
			Quaternion quaternion = reader.ReadQuaternion64();
			Vector3 vector3 = reader.ReadVector3Short();
			Vector3 vector4 = reader.ReadVector3Short();
			if (_body != null)
			{
				Quaternion quaternion2 = Quaternion.identity;
				if (vector4 != Vector3.zero)
				{
					float angle = vector4.magnitude * 57.29578f * num2;
					Vector3 normalized = vector4.normalized;
					quaternion2 = Quaternion.AngleAxis(angle, normalized);
				}
				Quaternion rotation = quaternion2 * quaternion;
				_body.transform.SetPositionAndRotation(vector2 + vector + num2 * vector3, rotation);
				if (!_body.isKinematic)
				{
					_body.linearVelocity = vector3;
					_body.angularVelocity = vector4;
				}
			}
		}

		public override void WriteState(PooledWriter writer)
		{
			double realtimeSinceStartupAsDouble = Time.realtimeSinceStartupAsDouble;
			bool flag = realtimeSinceStartupAsDouble - _lastSyncTime > (double)_syncRate;
			writer.WriteBoolean(flag);
			if (flag)
			{
				_lastSyncTime = realtimeSinceStartupAsDouble;
				writer.WriteSingle(_flightSceneNetwork.PhysicsTime);
				writer.WriteVector3(GameWorld.Instance.FloatingOriginOffset);
				writer.WriteVector3(base.transform.position);
				writer.WriteQuaternion64(base.transform.rotation);
				writer.WriteVector3Short(_body.linearVelocity);
				writer.WriteVector3Short(_body.angularVelocity);
			}
		}

		bool IBulletImpact.OnBulletImpact(in Bullet bullet, BulletData bulletData)
		{
			return OnBulletImpact(in bullet, bulletData);
		}
	}
}
