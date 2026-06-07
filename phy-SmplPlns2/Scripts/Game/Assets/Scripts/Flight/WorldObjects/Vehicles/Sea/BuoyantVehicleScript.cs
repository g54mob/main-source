using System;
using Assets.Scripts.Multiplayer.FlightObjects;
using Assets.Scripts.Multiplayer.FlightObjects.Damage;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Sea
{
	public class BuoyantVehicleScript : MonoBehaviour
	{
		[Header("Buoyancy Controls")]
		[Tooltip("How strongly the vehicle corrects its altitude to stay at the water level.")]
		[SerializeField]
		private float _altitudeCorrectionForce = 10f;

		private NetworkedAreaBodyScript _body;

		private NetworkFlightObjectDamageReceiverScript _damageReceiver;

		[Tooltip("Dampens angular rotation to prevent the vehicle from rocking or overshooting its stable position.")]
		[SerializeField]
		private float _rotationalDamping = 5f;

		[Header("Stabilization Controls")]
		[Tooltip("The strength of the torque applied to keep the vehicle upright and counteract roll/pitch.")]
		[SerializeField]
		private float _stabilizationTorque = 100f;

		private float _targetLocalAltitudeY;

		[Tooltip("Dampens vertical movement to prevent bouncing in the water.")]
		[SerializeField]
		private float _verticalDamping = 5f;

		private float _waterHeightDisplacement;

		private Action<float> _waterHeightQueryCallback;

		private bool _waterHeightRequest;

		protected virtual void FixedUpdate()
		{
			if (_body?.Area?.IsOwner == true)
			{
				if (_waterHeightRequest)
				{
					FlightSceneScript.Instance.WaterQueryManager.QueryHeightDisplacement(base.transform.position, _waterHeightQueryCallback);
					_waterHeightRequest = false;
				}
				MaintainAltitude();
				StabilizeRotation();
			}
		}

		protected virtual void Start()
		{
			_targetLocalAltitudeY = base.transform.localPosition.y;
			_body = GetComponent<NetworkedAreaBodyScript>();
			_waterHeightQueryCallback = delegate(float x)
			{
				_waterHeightDisplacement = x;
			};
			_damageReceiver = GetComponent<NetworkFlightObjectDamageReceiverScript>();
		}

		protected virtual void Update()
		{
			_waterHeightRequest = true;
		}

		private void MaintainAltitude()
		{
			float num = _targetLocalAltitudeY + _waterHeightDisplacement;
			float y = base.transform.localPosition.y;
			Vector3 vector = Mathf.Clamp(num - y, -2f, 2f) * _altitudeCorrectionForce * Vector3.up;
			float y2 = _body.Body.linearVelocity.y;
			Vector3 vector2 = _verticalDamping * y2 * -Vector3.up;
			_body.Body.AddForce(vector + vector2);
		}

		private void StabilizeRotation()
		{
			Vector3 up = Vector3.up;
			Vector3 vector = Vector3.Cross(base.transform.up, up) * _stabilizationTorque;
			Vector3 angularVelocity = _body.Body.angularVelocity;
			angularVelocity.y = 0f;
			Vector3 vector2 = -angularVelocity * _rotationalDamping;
			_body.Body.AddTorque(vector + vector2);
		}
	}
}
