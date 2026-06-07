using Assets.Scripts.Craft;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class NetworkJointScript : MonoBehaviour
	{
		public enum SimulationModeType
		{
			Source = 0,
			Target = 1,
			Observer = 2
		}

		private Rigidbody _body;

		[SerializeField]
		private float _damping;

		private bool _destroyed;

		private Vector3 _localPosition;

		[SerializeField]
		private float _maxForce;

		private Rigidbody _remoteBody;

		private Vector3 _remoteLocalPosition;

		private float _restLength;

		[SerializeField]
		private float _stiffness;

		public bool BodiesAlive { get; private set; }

		public float Distance { get; private set; }

		public bool IsOwner { get; set; }

		public SimulationModeType SimulationMode { get; private set; }

		public Transform TargetBodyTransform { get; private set; }

		public void DestroyJoint()
		{
			if (!_destroyed)
			{
				_destroyed = true;
				Object.Destroy(base.gameObject);
			}
		}

		public void Initialize(BodyScript sourceBody, Vector3 sourceLocalPosition, BodyScript targetBody, Vector3 targetLocalPosition, float power, SimulationModeType simulationMode)
		{
			Vector3 position = sourceBody.transform.TransformPoint(sourceLocalPosition);
			Vector3 position2 = targetBody.transform.TransformPoint(targetLocalPosition);
			Rigidbody componentInParent = sourceBody.GetComponentInParent<Rigidbody>();
			Rigidbody componentInParent2 = targetBody.GetComponentInParent<Rigidbody>();
			InitializeInternal(componentInParent, componentInParent.transform.InverseTransformPoint(position), componentInParent2, componentInParent2.transform.InverseTransformPoint(position2), simulationMode);
			Debug.Log($"Initialized Network Joint with simulation mode: '{simulationMode}'");
			BodiesAlive = true;
			_restLength = 0.05f;
			_stiffness = power * 0.1f;
			_maxForce = power;
			_damping = 1f;
		}

		protected virtual void FixedUpdate()
		{
			if (_body != null && _remoteBody != null)
			{
				if (SimulationMode != SimulationModeType.Observer)
				{
					Vector3 vector = _body.transform.TransformPoint(_localPosition);
					Vector3 vector2 = _remoteBody.transform.TransformPoint(_remoteLocalPosition) - vector;
					float num = (Distance = vector2.magnitude);
					vector2 = vector2.normalized;
					float num2 = _stiffness * (num - _restLength);
					Vector3 lhs = _remoteBody.linearVelocity - _body.linearVelocity;
					float num3 = _damping * Vector3.Dot(lhs, vector2);
					num2 += num3;
					num2 = Mathf.Clamp(num2, 0f - _maxForce, _maxForce);
					_body.AddForceAtPosition(vector2 * num2, vector);
				}
			}
			else
			{
				BodiesAlive = false;
			}
		}

		protected virtual void OnDestroy()
		{
			DestroyJoint();
		}

		protected virtual void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawSphere(_body.transform.TransformPoint(_localPosition), 0.2f);
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(_remoteBody.transform.TransformPoint(_remoteLocalPosition), 0.2f);
		}

		private void InitializeInternal(Rigidbody sourceRigidBody, Vector3 sourceLocalPosition, Rigidbody targetRigidBody, Vector3 targetLocalPosition, SimulationModeType simulationMode)
		{
			SimulationMode = simulationMode;
			TargetBodyTransform = targetRigidBody.transform;
			if (simulationMode == SimulationModeType.Source)
			{
				_body = sourceRigidBody;
				_localPosition = sourceLocalPosition;
				_remoteBody = targetRigidBody;
				_remoteLocalPosition = targetLocalPosition;
			}
			else
			{
				_body = targetRigidBody;
				_localPosition = targetLocalPosition;
				_remoteBody = sourceRigidBody;
				_remoteLocalPosition = sourceLocalPosition;
			}
		}
	}
}
