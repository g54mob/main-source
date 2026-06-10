using NSEipix.Base;
using UnityEngine;

namespace NSMedieval
{
	public class ScreenshotHandler : MonoSingleton<ScreenshotHandler>
	{
		[SerializeField]
		private Camera characterCamera;

		[SerializeField]
		private float cameraHeightOffset = 0.15f;

		public void CreateScreenshot(HumanoidBodyPreview humanoid, Texture2D outputTexture, RenderTexture renderTexture, int width, int height)
		{
			if (!(humanoid == null) && humanoid.HumanoidInstance != null)
			{
				SetCameraToNeckPosition(humanoid);
				characterCamera.targetTexture = renderTexture;
				characterCamera.forceIntoRenderTexture = true;
				characterCamera.Render();
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = renderTexture;
				outputTexture.ReadPixels(new Rect(0f, 0f, outputTexture.width, outputTexture.height), 0, 0);
				outputTexture.Apply();
				RenderTexture.active = active;
				characterCamera.targetTexture = null;
			}
		}

		private void SetCameraToNeckPosition(HumanoidBodyPreview humanoidToShoot)
		{
			Transform obj = base.transform;
			Vector3 position = obj.position;
			obj.position = new Vector3(position.x, humanoidToShoot.NeckPosition.position.y + cameraHeightOffset, position.z);
		}
	}
}
