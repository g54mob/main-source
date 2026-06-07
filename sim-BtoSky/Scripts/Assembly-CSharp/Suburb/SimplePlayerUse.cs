using UnityEngine;

namespace Suburb
{
	public class SimplePlayerUse : MonoBehaviour
	{
		public GameObject mainCamera;

		private GameObject objectClicked;

		public GameObject flashlight;

		public KeyCode OpenClose;

		public KeyCode Flashlight;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void RaycastCheck()
		{
			if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out var hitInfo, 2.3f) && (bool)hitInfo.collider.gameObject.GetComponent<SimpleOpenClose>())
			{
				hitInfo.collider.gameObject.BroadcastMessage("ObjectClicked");
			}
		}
	}
}
