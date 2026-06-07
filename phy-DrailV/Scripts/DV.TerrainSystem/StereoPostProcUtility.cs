using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR;

public static class StereoPostProcUtility
{
	private static Mesh fullScreenMesh;

	private static Mesh[] halfScreenMeshes;

	private static readonly SinglePassStereoMode[] StereoModeTranslation;

	static StereoPostProcUtility()
	{
		halfScreenMeshes = new Mesh[2];
		StereoModeTranslation = new SinglePassStereoMode[4];
		StereoModeTranslation[0] = SinglePassStereoMode.None;
		StereoModeTranslation[1] = SinglePassStereoMode.SideBySide;
		StereoModeTranslation[2] = SinglePassStereoMode.Instancing;
		StereoModeTranslation[3] = SinglePassStereoMode.Multiview;
	}

	public static void InitializeAssets()
	{
		if (fullScreenMesh == null)
		{
			fullScreenMesh = new Mesh();
			fullScreenMesh.SetVertices(new Vector3[4]
			{
				new Vector3(-1f, -1f, 0f),
				new Vector3(-1f, 1f, 0f),
				new Vector3(1f, 1f, 0f),
				new Vector3(1f, -1f, 0f)
			});
			fullScreenMesh.SetUVs(0, new Vector2[4]
			{
				new Vector2(0f, 1f),
				new Vector2(0f, 0f),
				new Vector2(1f, 0f),
				new Vector2(1f, 1f)
			});
			fullScreenMesh.SetUVs(1, new Vector2[4]
			{
				new Vector2(0f, 1f),
				new Vector2(0f, 0f),
				new Vector2(1f, 0f),
				new Vector2(1f, 1f)
			});
			fullScreenMesh.SetIndices(new int[6] { 0, 1, 2, 2, 3, 0 }, MeshTopology.Triangles, 0);
			fullScreenMesh.UploadMeshData(markNoLongerReadable: true);
			for (int i = 0; i < 2; i++)
			{
				float num = (float)i - 1f;
				float num2 = i;
				halfScreenMeshes[i] = new Mesh();
				halfScreenMeshes[i].SetVertices(new Vector3[4]
				{
					new Vector3(num, -1f, 0f),
					new Vector3(num, 1f, 0f),
					new Vector3(num2, 1f, 0f),
					new Vector3(num2, -1f, 0f)
				});
				halfScreenMeshes[i].SetUVs(0, new Vector2[4]
				{
					new Vector2(num * 0.5f + 0.5f, 1f),
					new Vector2(num * 0.5f + 0.5f, 0f),
					new Vector2(num2 * 0.5f + 0.5f, 0f),
					new Vector2(num2 * 0.5f + 0.5f, 1f)
				});
				halfScreenMeshes[i].SetUVs(1, new Vector2[4]
				{
					new Vector2(0f, 1f),
					new Vector2(0f, 0f),
					new Vector2(1f, 0f),
					new Vector2(1f, 1f)
				});
				halfScreenMeshes[i].SetIndices(new int[6] { 0, 1, 2, 2, 3, 0 }, MeshTopology.Triangles, 0);
				halfScreenMeshes[i].UploadMeshData(markNoLongerReadable: true);
			}
		}
	}

	public static void RenderFullscreenEffect(CommandBuffer buff, Camera camera, Material material, Light light = null, int shaderPass = 0)
	{
		InitializeAssets();
		int num = (camera.stereoEnabled ? 2 : 0);
		XRSettings.StereoRenderingMode stereoRenderingMode = XRSettings.stereoRenderingMode;
		if (light != null)
		{
			Vector4 value = new Vector4(1f - light.shadowStrength, Mathf.Max(camera.farClipPlane / QualitySettings.shadowDistance, 1f), 5f / Mathf.Min(camera.farClipPlane, QualitySettings.shadowDistance), -1f * (2f + camera.fieldOfView / 180f * 2f));
			buff.SetGlobalVector("_LightShadowData", value);
		}
		if (num == 2 && XRSettings.stereoRenderingMode == XRSettings.StereoRenderingMode.SinglePass)
		{
			buff.SetSinglePassStereo(SinglePassStereoMode.None);
			Matrix4x4 inverse = camera.GetStereoViewMatrix(Camera.StereoscopicEye.Left).inverse;
			Matrix4x4 inverse2 = camera.GetStereoViewMatrix(Camera.StereoscopicEye.Right).inverse;
			Matrix4x4 stereoProjectionMatrix = camera.GetStereoProjectionMatrix(Camera.StereoscopicEye.Left);
			Matrix4x4 stereoProjectionMatrix2 = camera.GetStereoProjectionMatrix(Camera.StereoscopicEye.Right);
			Matrix4x4 inverse3 = GL.GetGPUProjectionMatrix(stereoProjectionMatrix, renderIntoTexture: true).inverse;
			Matrix4x4 inverse4 = GL.GetGPUProjectionMatrix(stereoProjectionMatrix2, renderIntoTexture: true).inverse;
			inverse3[1, 1] *= -1f;
			inverse4[1, 1] *= -1f;
			Vector3 vector = new Vector3(inverse.m03, inverse.m13, inverse.m23);
			buff.SetGlobalVector("_RenderCamera", new Vector4(vector.x, vector.y, vector.z, light ? light.shadowStrength : 0f));
			buff.SetGlobalMatrix("_WorldFromView", inverse);
			buff.SetGlobalMatrix("_ViewFromScreen", inverse3);
			buff.DrawMesh(halfScreenMeshes[0], Matrix4x4.identity, material, 0, shaderPass);
			vector = new Vector3(inverse2.m03, inverse2.m13, inverse2.m23);
			buff.SetGlobalVector("_RenderCamera", new Vector4(vector.x, vector.y, vector.z, light ? light.shadowStrength : 0f));
			buff.SetGlobalMatrix("_WorldFromView", inverse2);
			buff.SetGlobalMatrix("_ViewFromScreen", inverse4);
			buff.DrawMesh(halfScreenMeshes[1], Matrix4x4.identity, material, 0, shaderPass);
			buff.SetSinglePassStereo(StereoModeTranslation[(int)stereoRenderingMode]);
		}
		else
		{
			Vector3 vector = camera.transform.position;
			buff.SetGlobalVector("_RenderCamera", new Vector4(vector.x, vector.y, vector.z, light ? light.shadowStrength : 0f));
			Matrix4x4 cameraToWorldMatrix = camera.cameraToWorldMatrix;
			Matrix4x4 inverse5 = GL.GetGPUProjectionMatrix(camera.projectionMatrix, renderIntoTexture: true).inverse;
			inverse5[1, 1] *= -1f;
			buff.SetGlobalMatrix("_WorldFromView", cameraToWorldMatrix);
			buff.SetGlobalMatrix("_ViewFromScreen", inverse5);
			buff.DrawMesh(fullScreenMesh, Matrix4x4.identity, material, 0, 0);
		}
	}
}
