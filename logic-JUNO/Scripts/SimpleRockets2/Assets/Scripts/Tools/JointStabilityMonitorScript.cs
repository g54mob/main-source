using System;
using UnityEngine;

namespace Assets.Scripts.Tools
{
	public class JointStabilityMonitorScript : MonoBehaviour
	{
		[SerializeField]
		private bool _autoStabilizing;

		private Rigidbody _connectedBody;

		private Transform _connectedBodyTrans;

		private float _errorAngle;

		private float _errorPosition;

		private float _initialAngleOffset;

		private float _initialDistance;

		private Vector3 _initialTensorBody;

		private Vector3 _initialTensorConnectedBody;

		private Rigidbody _jointBody;

		private Transform _jointBodyTrans;

		public bool AutoStabilizeEnabled { get; set; }

		public float Stability { get; private set; }

		public static JointStabilityMonitorScript Create(Joint joint)
		{
			JointStabilityMonitorScript jointStabilityMonitorScript = joint.gameObject.AddComponent<JointStabilityMonitorScript>();
			jointStabilityMonitorScript.Initialize(joint);
			return jointStabilityMonitorScript;
		}

		public void Update()
		{
			if (_errorAngle > 5f || _errorPosition > 1f)
			{
				if (!_autoStabilizing)
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Unstable joint detected for body #" + _connectedBody.name + ".  Try increasing inertia tensor/mass", devlog: true);
					if (AutoStabilizeEnabled)
					{
						SetAutoStabilizeActive(enable: true);
					}
				}
			}
			else if (AutoStabilizeEnabled && _autoStabilizing)
			{
				SetAutoStabilizeActive(enable: false);
			}
		}

		private void FixedUpdate()
		{
			float magnitude = (_jointBodyTrans.position - _connectedBodyTrans.position).magnitude;
			float num = Quaternion.Angle(_jointBodyTrans.rotation, _connectedBodyTrans.rotation);
			_errorPosition = Math.Abs(magnitude - _initialDistance);
			_errorAngle = Math.Abs(num - _initialAngleOffset);
		}

		private void Initialize(Joint joint)
		{
			_jointBody = joint.GetComponent<Rigidbody>();
			_connectedBody = joint.connectedBody;
			_jointBodyTrans = _jointBody.transform;
			_connectedBodyTrans = _connectedBody.transform;
			_initialDistance = (_jointBodyTrans.position - _connectedBodyTrans.position).magnitude;
			_initialAngleOffset = Quaternion.Angle(_jointBodyTrans.rotation, _connectedBodyTrans.rotation);
		}

		private void SetAutoStabilizeActive(bool enable)
		{
			_autoStabilizing = enable;
			if (enable)
			{
				Debug.Log("Auto-stabilizing activated.");
				_initialTensorBody = _jointBody.inertiaTensor;
				_initialTensorConnectedBody = _connectedBody.inertiaTensor;
				_jointBody.inertiaTensor *= 5f;
				_connectedBody.inertiaTensor *= 5f;
			}
			else
			{
				Debug.Log("Auto-stabilizing deactivated");
				_jointBody.inertiaTensor = _initialTensorBody;
				_connectedBody.inertiaTensor = _initialTensorConnectedBody;
			}
		}
	}
}
