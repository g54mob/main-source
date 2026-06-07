using UnityEngine;

namespace LeTai.Asset.TranslucentImage.Demo
{
	public class WorldSpaceSetup : MonoBehaviour
	{
		public Camera sceneCamera;

		public Camera uiCamera;

		public void SetUIAlwaysOnTop(bool isAlwaysOnTop)
		{
			if (isAlwaysOnTop)
			{
				sceneCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("UI"));
			}
			else
			{
				sceneCamera.cullingMask |= 1 << LayerMask.NameToLayer("UI");
			}
			uiCamera.gameObject.SetActive(isAlwaysOnTop);
		}
	}
}
