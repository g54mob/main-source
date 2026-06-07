using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Gley.TrafficSystem.Scripts.ToUse
{
	public class MultiplayerVehicleBroadcast : MonoBehaviourPun
	{
		[Header("[-- Body Visuals --]")]
		[SerializeField]
		private List<MeshRenderer> bodyMeshRenderers;

		[Header("[-- Wheel Transforms --]")]
		[SerializeField]
		private Transform frontLeftWheel;

		[SerializeField]
		private Transform frontRightWheel;

		[SerializeField]
		private Transform rearLeftWheel;

		[SerializeField]
		private Transform rearRightWheel;

		[Header("[-- Physics --]")]
		[SerializeField]
		private float wheelRadius;

		[SerializeField]
		private float smoothing;

		[SerializeField]
		private float maxSteerAngle;

		private Vector3 _lastPosition;

		private float _averageSpeed;

		private float _rollAngle;

		private float _steerAngle;

		private float _lastYaw;

		[Space]
		[Space]
		[SerializeField]
		private List<Component> isClientRemovedComponents;

		private EngineSoundComponent _engineSound;

		private Quaternion _flInit;

		private Quaternion _frInit;

		private Quaternion _rlInit;

		private Quaternion _rrInit;

		private void OnDisable()
		{
		}

		private void OnSyncRequest(string invokerUserID)
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public void EngineSoundInitialize()
		{
		}

		public void UpdateEngineSound(float masterVolume, float getCurrentSpeed, float maxSpeed)
		{
		}

		[PunRPC]
		public void DeactivateVehicle()
		{
		}

		[PunRPC]
		public void ActivateVehicle()
		{
		}

		public void BodyRenderersStat_Broadcast(bool stat)
		{
		}

		[PunRPC]
		public void BodyRenderersStat_Rpc(bool stat)
		{
		}

		public void RefreshPosition_Broadcast()
		{
		}
	}
}
