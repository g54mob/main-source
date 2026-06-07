using UnityEngine;

namespace SoulGames.Utilities
{
	public class SimpleFirstPersonCameraHolder : MonoBehaviour
	{
		[Tooltip("Camera Position transform empty game object")]
		[SerializeField]
		private Transform cameraPosition;

		private void LateUpdate()
		{
			base.transform.position = cameraPosition.position;
		}
	}
}
