using UnityEngine;

namespace CTS.Rendering
{
	public class RenderDepthRequest
	{
		public RenderTexture RenderTarget;

		public Vector3 Position;

		public Quaternion Rotation;

		public float Range;

		public float NearPlane;

		public float FOV;

		public LayerMask LayerMask;

		public Camera TemporaryCamera;

		public bool WasRendered;

		public void UpdateCamera()
		{
			TemporaryCamera.transform.SetPositionAndRotation(Position, Rotation);
			TemporaryCamera.targetTexture = RenderTarget;
			TemporaryCamera.farClipPlane = Range;
			TemporaryCamera.nearClipPlane = NearPlane;
			TemporaryCamera.fieldOfView = FOV;
			TemporaryCamera.cullingMask = LayerMask;
			TemporaryCamera.aspect = (float)RenderTarget.width / (float)RenderTarget.height;
		}
	}
}
