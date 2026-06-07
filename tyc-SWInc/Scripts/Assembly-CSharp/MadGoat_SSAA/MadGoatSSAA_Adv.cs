using UnityEngine;

namespace MadGoat_SSAA
{
	[ExecuteInEditMode]
	public class MadGoatSSAA_Adv : MadGoatSSAA
	{
		private void OnDisable()
		{
			SSAA_Internal.enabled = false;
			currentCamera.targetTexture.Release();
			currentCamera.targetTexture = null;
			Object.DestroyImmediate(renderCameraObject.gameObject);
		}

		public override void Init()
		{
			if (renderCameraObject == null)
			{
				if ((bool)GetComponentInChildren<MadGoatSSAA_InternalRenderer>())
				{
					SSAA_Internal = GetComponentInChildren<MadGoatSSAA_InternalRenderer>();
					renderCameraObject = SSAA_Internal.gameObject;
					renderCamera = renderCameraObject.GetComponent<Camera>();
					renderCameraObject.hideFlags = HideFlags.None;
					return;
				}
				renderCameraObject = new GameObject("RenderCameraObject");
				renderCameraObject.transform.SetParent(base.transform);
				renderCameraObject.transform.position = Vector3.zero;
				renderCameraObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
				renderCamera = renderCameraObject.AddComponent<Camera>();
				SSAA_Internal = renderCameraObject.AddComponent<MadGoatSSAA_InternalRenderer>();
				SSAA_Internal.current = renderCamera;
				SSAA_Internal.main = currentCamera;
				SSAA_Internal.enabled = true;
				renderCamera.CopyFrom(currentCamera);
				renderCamera.cullingMask = 0;
				renderCamera.clearFlags = CameraClearFlags.Nothing;
			}
			else
			{
				SSAA_Internal.enabled = true;
			}
			currentCamera.targetTexture = new RenderTexture(128, 128, 24, textureFormat);
			currentCamera.targetTexture.Create();
			SSAA_Internal.SendMessage("Start");
		}
	}
}
