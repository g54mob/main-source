using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Multiplayer;
using UnityEngine;

namespace Assets.Scripts.Environment
{
	public class DoorTeleporter : MonoBehaviour
	{
		[SerializeField]
		private Transform _destination;

		[SerializeField]
		private float _exitOffset = 2f;

		private float _lastEntry;

		protected void OnTriggerEnter(Collider other)
		{
			NetworkCharacterScript component = other.GetComponent<NetworkCharacterScript>();
			float num = FlightSceneScript.Instance.FlightSceneNetwork.PhysicsTime - _lastEntry;
			if (component != null && component.IsOwner && num > 1f)
			{
				_lastEntry = FlightSceneScript.Instance.FlightSceneNetwork.PhysicsTime;
				PositionUtility.TeleportPlayer(Utility.ConvertFloatingOriginToAbsolutePosition(_destination.position) + _exitOffset * _destination.forward, _destination.rotation.eulerAngles, Vector3.zero);
				CameraManagerScript cameraScript = FlightSceneScript.Instance.CameraScript;
				if (cameraScript.Controller.IsFirstPerson)
				{
					cameraScript.AddYawToCurrentCamera(Vector3.SignedAngle(-base.transform.forward, _destination.forward, Vector3.up));
				}
			}
		}
	}
}
