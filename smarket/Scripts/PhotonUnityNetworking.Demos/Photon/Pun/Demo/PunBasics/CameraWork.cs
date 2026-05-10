using UnityEngine;

namespace Photon.Pun.Demo.PunBasics
{
	public class CameraWork : MonoBehaviour
	{
		[Tooltip("The distance in the local x-z plane to the target")]
		[SerializeField]
		private float distance;

		[Tooltip("The height we want the camera to be above the target")]
		[SerializeField]
		private float height;

		[Tooltip("Allow the camera to be offseted vertically from the target, for example giving more view of the sceneray and less ground.")]
		[SerializeField]
		private Vector3 centerOffset;

		[Tooltip("Set this as false if a component of a prefab being instanciated by Photon Network, and manually call OnStartFollowing() when and if needed.")]
		[SerializeField]
		private bool followOnStart;

		[Tooltip("The Smoothing for the camera to follow the target")]
		[SerializeField]
		private float smoothSpeed;

		private Transform cameraTransform;

		private bool isFollowing;

		private Vector3 cameraOffset;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		public void OnStartFollowing()
		{
		}

		private void Follow()
		{
		}

		private void Cut()
		{
		}
	}
}
