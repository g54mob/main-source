using UnityEngine;

public class RenderLayer
{
	public int layerBits;

	public CameraClearFlags clearFlags;

	public Color clearColor = new Color(0f, 0f, 0f, 0f);

	public RenderingPath renderingPath;

	public RenderTarget renderTarget;

	public Vector3? forceCameraPos;

	public float? farClipPlane;

	public bool occlusionCulling;

	public Vector4 GetClipPlanes(Camera camera)
	{
		float nearClipPlane = camera.nearClipPlane;
		float num = ((!farClipPlane.HasValue) ? camera.farClipPlane : farClipPlane.Value);
		return new Vector4(nearClipPlane, num, nearClipPlane / num, 1f);
	}

	public Matrix4x4 GetViewProj(Camera camera)
	{
		Matrix4x4 worldToCameraMatrix = camera.worldToCameraMatrix;
		Matrix4x4 proj = Matrix4x4.Perspective(camera.fieldOfView, camera.aspect, camera.nearClipPlane, (!farClipPlane.HasValue) ? camera.farClipPlane : farClipPlane.Value);
		Matrix4x4 gPUProjectionMatrix = GL.GetGPUProjectionMatrix(proj, false);
		return gPUProjectionMatrix * worldToCameraMatrix;
	}

	public void Render(Camera camera, RenderTexture renderTexture, bool disableOcclusionCulling = false, int andCullingMask = -1)
	{
		float num = camera.farClipPlane;
		Vector3 position = camera.transform.position;
		DepthTextureMode depthTextureMode = camera.depthTextureMode;
		if (farClipPlane.HasValue)
		{
			camera.farClipPlane = farClipPlane.Value;
		}
		if (forceCameraPos.HasValue)
		{
			camera.transform.position = Vector3.Scale(forceCameraPos.Value, camera.transform.position);
		}
		RenderTarget.SetShaderTargetSize(renderTexture);
		camera.cullingMask = layerBits;
		camera.useOcclusionCulling = !disableOcclusionCulling && occlusionCulling;
		camera.targetTexture = renderTexture;
		camera.clearFlags = clearFlags;
		camera.renderingPath = renderingPath;
		camera.backgroundColor = clearColor;
		if (camera.renderingPath == RenderingPath.Forward || camera.renderingPath == RenderingPath.VertexLit)
		{
			camera.depthTextureMode = DepthTextureMode.None;
		}
		if (andCullingMask != -1)
		{
			camera.cullingMask &= andCullingMask;
			camera.clearFlags = CameraClearFlags.Color;
			camera.backgroundColor = Color.clear;
		}
		camera.Render();
		camera.farClipPlane = num;
		camera.transform.position = position;
		camera.depthTextureMode = depthTextureMode;
	}
}
