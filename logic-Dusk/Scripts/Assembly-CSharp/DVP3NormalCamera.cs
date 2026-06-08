using UnityEngine;

public class DVP3NormalCamera : ImageEffectBase
{
	public RenderTexture pixelRT;

	public float scaleOfFlat = 0.33f;

	public float scaleOfRaised = 0.5f;

	private void OnPreRender()
	{
		if (DroneManager.Instance != null && DroneManager.Instance.CurrentDrone != null)
		{
			Transform transform = null;
			transform = ((!DroneManager.Instance.DebugUseTestSpotlight && !DroneManager.Instance.DebugUseCameraArraySpotlight) ? DroneManager.Instance.CurrentDrone.transform.Find("Spotlight").transform : ((!DroneManager.Instance.DebugUseCameraArraySpotlight) ? DroneManager.Instance.CurrentDrone.Swival.transform.Find("SpotlightTest").transform : DroneManager.Instance.CurrentDrone.transform.Find("SpotlightTestCameraArray").transform));
			Vector3 forward = transform.forward;
			Vector4 vec = new Vector4(forward.x, forward.y, forward.z, 1f);
			GameObject gameObject = GameObject.FindGameObjectWithTag("DroneMainCamera");
			Transform transform2 = gameObject.transform;
			Vector3 vector = transform2.InverseTransformPoint(DroneManager.Instance.CurrentDrone.transform.position);
			Vector4 vec2 = new Vector4(vector.x, vector.y, vector.z, 1f);
			vec2.x += 0.5f;
			vec2.y += 0.5f;
			Shader.SetGlobalVector("_ObjPos", vec2);
			Shader.SetGlobalVector("_ObjForward", vec);
		}
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
		base.material.SetTexture("_ProjectTex", pixelRT);
		base.material.SetFloat("_ScaleFloor", scaleOfFlat);
		base.material.SetFloat("_ScaleFloor", scaleOfRaised);
		Graphics.Blit(src, dest, base.material);
	}
}
