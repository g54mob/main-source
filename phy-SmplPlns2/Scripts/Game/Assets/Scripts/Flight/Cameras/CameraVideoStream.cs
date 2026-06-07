using System;
using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public class CameraVideoStream : ICameraVideoStream
	{
		public Camera RenderCamera { get; private set; }

		public RenderTexture RenderTexture { get; private set; }

		public ICameraVideoStreamSource Source { get; private set; }

		public event Action<ICameraVideoStream> Released;

		public CameraVideoStream(ICameraVideoStreamSource source, RenderTexture renderTexture, Camera renderCamera)
		{
			Source = source;
			RenderTexture = renderTexture;
			RenderCamera = renderCamera;
			FlightSceneScript.Instance.Environment.RegisterCamera(renderCamera);
		}

		public void Release()
		{
			FlightSceneScript.Instance.Environment.UnregisterCamera(RenderCamera);
			this.Released?.Invoke(this);
			RenderTexture.Release();
			UnityEngine.Object.Destroy(RenderTexture);
			UnityEngine.Object.Destroy(RenderCamera.gameObject);
			RenderCamera = null;
			RenderTexture = null;
			Source = null;
		}
	}
}
