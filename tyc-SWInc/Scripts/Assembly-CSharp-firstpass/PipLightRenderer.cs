using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PipLightRenderer : MonoBehaviour
{
	public static class Materials
	{
		private static Material[][][] PointCookieShadow;

		public static Material GetMaterial(PipLight pipLight)
		{
			return GetMaterial(pipLight.type, pipLight.cookie, pipLight.ShadowMapReady, pipLight.shadowType);
		}

		public static Material GetMaterial(LightType type, Cubemap cookie, bool shadowmapReady, LightShadows shadowType)
		{
			if (PointCookieShadow == null)
			{
				Initialize();
			}
			return PointCookieShadow[(type != LightType.Point) ? 1 : 0][cookie ? 1 : 0][(shadowmapReady && shadowType != LightShadows.None) ? 1 : 0];
		}

		private static Material GetMat(Shader pipLightShader, LightType type, bool cookie, bool shadow)
		{
			Material material = new Material(pipLightShader);
			material.EnableKeyword(type.ToString().ToUpper());
			if (cookie)
			{
				material.EnableKeyword("COOKIE");
			}
			if (shadow)
			{
				material.EnableKeyword("SHADOWS");
			}
			return material;
		}

		private static void Initialize()
		{
			Shader shader = Resources.Load<Shader>("PipLightLight");
			if (shader == null)
			{
				Debug.LogError("PipLightShader not found, is null");
			}
			if (!shader.isSupported)
			{
				Debug.LogError("PipLightShader not supported", shader);
			}
			PointCookieShadow = new Material[2][][]
			{
				new Material[2][]
				{
					new Material[2]
					{
						GetMat(shader, LightType.Point, false, false),
						GetMat(shader, LightType.Point, false, true)
					},
					new Material[2]
					{
						GetMat(shader, LightType.Point, true, false),
						GetMat(shader, LightType.Point, true, true)
					}
				},
				new Material[2][]
				{
					new Material[2]
					{
						GetMat(shader, LightType.Spot, false, false),
						GetMat(shader, LightType.Spot, false, true)
					},
					new Material[2]
					{
						GetMat(shader, LightType.Spot, true, false),
						GetMat(shader, LightType.Spot, true, true)
					}
				}
			};
		}
	}

	public static class GeometryUtilityUser
	{
		public static void CalculateFrustumPlanes(Plane[] OutPlanes, Camera camera)
		{
			Matrix4x4 matrix4x = camera.projectionMatrix * camera.worldToCameraMatrix;
			float m = matrix4x.m30;
			float m2 = matrix4x.m31;
			float m3 = matrix4x.m32;
			float m4 = matrix4x.m33;
			float m5 = matrix4x.m00;
			float m6 = matrix4x.m01;
			float m7 = matrix4x.m02;
			float m8 = matrix4x.m03;
			CalcPlane(ref OutPlanes[0], m5 + m, m6 + m2, m7 + m3, m8 + m4);
			CalcPlane(ref OutPlanes[1], 0f - m5 + m, 0f - m6 + m2, 0f - m7 + m3, 0f - m8 + m4);
			m5 = matrix4x.m10;
			m6 = matrix4x.m11;
			m7 = matrix4x.m12;
			m8 = matrix4x.m13;
			CalcPlane(ref OutPlanes[2], m5 + m, m6 + m2, m7 + m3, m8 + m4);
			CalcPlane(ref OutPlanes[3], 0f - m5 + m, 0f - m6 + m2, 0f - m7 + m3, 0f - m8 + m4);
			m5 = matrix4x.m20;
			m6 = matrix4x.m21;
			m7 = matrix4x.m22;
			m8 = matrix4x.m23;
			CalcPlane(ref OutPlanes[4], m5 + m, m6 + m2, m7 + m3, m8 + m4);
			CalcPlane(ref OutPlanes[5], 0f - m5 + m, 0f - m6 + m2, 0f - m7 + m3, 0f - m8 + m4);
		}

		private static void CalcPlane(ref Plane InPlane, float InA, float InB, float InC, float InDistance)
		{
			Vector3 normal = new Vector3(InA, InB, InC);
			float num = 1f / normal.magnitude;
			normal.x *= num;
			normal.y *= num;
			normal.z *= num;
			InPlane.normal = normal;
			InPlane.distance = InDistance * num;
		}
	}

	public Mesh lightSphereMesh;

	private Camera lightRendererCamera;

	private static Dictionary<Camera, CommandBuffer> buffers = new Dictionary<Camera, CommandBuffer>();

	private static CameraEvent InsertionPoint = CameraEvent.AfterFinalPass;

	public PipLight.ShadowTextureSize shadowMapResolution = PipLight.ShadowTextureSize.x256;

	public float levelOfDetailAggression = 1f;

	public PipLight.ShadowRefreshMode shadowRefreshMode;

	public float BlendSpeed = 4f;

	private Plane[] frustrumPlanes = new Plane[6];

	private void OnDisable()
	{
		CheckSupport();
		CommandBuffer value;
		if (buffers.TryGetValue(lightRendererCamera, out value))
		{
			lightRendererCamera.RemoveCommandBuffer(InsertionPoint, value);
			value.Dispose();
			buffers.Remove(lightRendererCamera);
		}
	}

	private void Awake()
	{
		PipLightSystem.Instance.Renderer = this;
		int num = SystemInfo.graphicsMemorySize - 1024;
		if (num >= 2048)
		{
			shadowMapResolution = PipLight.ShadowTextureSize.x1024;
		}
		else if (num >= 1024)
		{
			shadowMapResolution = PipLight.ShadowTextureSize.x512;
		}
		else if (num >= 512)
		{
			shadowMapResolution = PipLight.ShadowTextureSize.x256;
		}
		else if (num >= 256)
		{
			shadowMapResolution = PipLight.ShadowTextureSize.x128;
		}
		else
		{
			shadowMapResolution = PipLight.ShadowTextureSize.x64;
		}
	}

	private void OnDestroy()
	{
		if (PipLightSystem.Instance.Renderer == this)
		{
			PipLightSystem.Instance.Renderer = null;
		}
		CheckSupport();
		CommandBuffer value;
		if (buffers.TryGetValue(lightRendererCamera, out value))
		{
			lightRendererCamera.RemoveCommandBuffer(InsertionPoint, value);
			value.Dispose();
			buffers.Remove(lightRendererCamera);
		}
	}

	private void OnEnable()
	{
		lightRendererCamera = GetComponent<Camera>();
		CheckSupport();
		CommandBuffer value;
		if (buffers.TryGetValue(lightRendererCamera, out value))
		{
			lightRendererCamera.AddCommandBuffer(InsertionPoint, value);
		}
		PipLight.CheckKeywords();
	}

	private void LateUpdate()
	{
		PipLightSystem instance = PipLightSystem.Instance;
		PipLight[] lights = instance.lights;
		for (int i = 0; i < instance.lightsCount; i++)
		{
			lights[i].BeforeRender();
		}
		if (lightRendererCamera != null)
		{
			ReconstructLightBuffers(lightRendererCamera, true, true);
		}
	}

	public void ForceRefresh()
	{
		LateUpdate();
	}

	private void ReconstructLightBuffers(Camera renderCam, bool toCull, bool evalQual)
	{
		if (renderCam == null)
		{
			return;
		}
		CommandBuffer value;
		if (buffers.TryGetValue(renderCam, out value))
		{
			value.Clear();
		}
		else
		{
			value = new CommandBuffer();
			value.name = "Deferred pipLights";
			renderCam.AddCommandBuffer(InsertionPoint, value);
			buffers.Add(renderCam, value);
		}
		PipLightSystem instance = PipLightSystem.Instance;
		Bounds bounds = default(Bounds);
		if (toCull)
		{
			GeometryUtilityUser.CalculateFrustumPlanes(frustrumPlanes, renderCam);
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		bool flag = true;
		for (int i = 0; i < PipLightSystem.Instance.lightsCount; i++)
		{
			PipLight pipLight = PipLightSystem.Instance.lights[i];
			if (toCull)
			{
				bounds.center = pipLight.transform.position;
				bounds.extents = Vector3.one * pipLight.range;
				if (!GeometryUtility.TestPlanesAABB(frustrumPlanes, bounds))
				{
					continue;
				}
			}
			if (flag)
			{
				if (evalQual)
				{
					pipLight.UpdateLOD(renderCam);
				}
				pipLight.UpdateShadowMap();
				if (Time.realtimeSinceStartup - realtimeSinceStartup > 0.01f)
				{
					flag = false;
				}
			}
			pipLight.WriteToCommandBuffer(value, lightSphereMesh, Materials.GetMaterial(pipLight), BlendSpeed);
		}
	}

	private void CheckSupport()
	{
		if (!lightRendererCamera.allowHDR)
		{
			Debug.LogError("PipLights will only work with HDR (non-HDR not implemented", this);
		}
		if (lightRendererCamera.actualRenderingPath != RenderingPath.DeferredShading)
		{
			Debug.LogError("PipLights will only work with DeferredShading (by design limitations)", this);
		}
	}
}
