using UnityEngine;

namespace LeTai.Asset.TranslucentImage.Demo
{
	public class WorldSpaceSetup : MonoBehaviour
	{
		public Camera sceneCamera;

		public Camera uiCamera;

		public void Toggle()
		{
			sceneCamera.cullingMask ^= 1 << LayerMask.NameToLayer("UI");
			uiCamera.gameObject.SetActive(!uiCamera.gameObject.activeSelf);
		}
	}
}
