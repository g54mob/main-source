using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace VRM
{
	public class VRMFirstPersonCameraManager : MonoBehaviour
	{
		[Serializable]
		private class CameraWithRawImage
		{
			public Camera Camera;

			public RenderTexture Texture;

			public RawImage Image;
		}

		[SerializeField]
		private CameraWithRawImage m_topLeft;

		[SerializeField]
		private CameraWithRawImage m_topRight;

		[SerializeField]
		private CameraWithRawImage m_bottomRight;

		[SerializeField]
		[Header("Cameras")]
		private Camera m_firstPersonCamera;

		[SerializeField]
		private Camera[] m_thirdPersonCameras;

		private void Reset()
		{
			Camera[] source = UnityEngine.Object.FindObjectsOfType<Camera>();
			m_firstPersonCamera = Camera.main;
			m_thirdPersonCameras = source.Where((Camera x) => x != m_firstPersonCamera).ToArray();
		}

		private void Update()
		{
			int w = Screen.width / 2;
			int h = Screen.height / 2;
			SetupRenderTarget(m_topLeft, w, h);
			SetupRenderTarget(m_topRight, w, h);
			SetupRenderTarget(m_bottomRight, w, h);
		}

		private void SetupRenderTarget(CameraWithRawImage cameraWithImage, int w, int h)
		{
			if (!(cameraWithImage.Camera == null) && !(cameraWithImage.Image == null) && (cameraWithImage.Texture == null || cameraWithImage.Texture.width != w || cameraWithImage.Texture.height != h))
			{
				RenderTexture renderTexture = (cameraWithImage.Texture = new RenderTexture(w, h, 16));
				cameraWithImage.Camera.targetTexture = renderTexture;
				cameraWithImage.Image.texture = renderTexture;
			}
		}
	}
}
