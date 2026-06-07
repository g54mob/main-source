using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class PipLight : MonoBehaviour
{
	public enum ShadowTextureSize
	{
		x8 = 8,
		x16 = 0x10,
		x32 = 0x20,
		x64 = 0x40,
		x128 = 0x80,
		x256 = 0x100,
		x512 = 0x200,
		x1024 = 0x400,
		x2048 = 0x800,
		x4096 = 0x1000,
		x8192 = 0x2000
	}

	public enum ShadowRefreshMode
	{
		EveryFrame = 0,
		Manual = 1
	}

	[FormerlySerializedAs("radius")]
	public float range = 16f;

	public Color color = Color.white;

	public float intensity = 1f;

	[Range(1f, 179f)]
	public int angle = 30;

	[Range(0f, 1f)]
	public float lightOffset;

	[FormerlySerializedAs("lightType")]
	public LightType type = LightType.Point;

	public LightShadows shadowType = LightShadows.Hard;

	[Range(0f, 1f)]
	public float shadowBias = 0.03f;

	[Range(0f, 1f)]
	public float shadowScaleBias = 0.03f;

	[Range(0f, 1f)]
	public float shadowStrength = 1f;

	public LayerMask cullingMask = -1;

	public Cubemap cookie;

	private float _lastRefresh;

	[NonSerialized]
	public bool ShadowMapReady;

	[NonSerialized]
	public bool renderedThisFrame;

	[NonSerialized]
	public bool UpdateNextFrame = true;

	private RenderTexture shadowMap;

	private MaterialPropertyBlock propertyBlock;

	private ShadowTextureSize shadowResolutionCurrent = ShadowTextureSize.x256;

	private Camera shadowMapCamera;

	private static int prop_Pip_LightPositionRange;

	private static int prop_LightPositionRange;

	private static int prop_LightProjectionParams;

	private static int prop_ShadowMapTexture;

	private static int prop_LightColor;

	private static int prop_LightPos;

	private static int prop_ShadowData;

	private static int prop_CookieTex;

	private static int prop_LightMatrix0;

	private static int prop_WtoSMatrix;

	private static int prop_LightAsQuad;

	private static int prop_LightOffset;

	private static Shader depthShader;

	public static bool ForceWhite;

	private float prevRadius;

	private Vector3 lastPosition;

	private Matrix4x4 matrix;

	public static void ChangeUsedSize(int amount)
	{
	}

	private void OnEnable()
	{
		PipLightSystem.Instance.Add(this);
		UpdateNextFrame = true;
	}

	private void OnDisable()
	{
		PipLightSystem.Instance.Remove(this);
		if ((bool)shadowMap)
		{
			ChangeUsedSize(-shadowMap.width * shadowMap.height);
			shadowMap.Release();
			UnityEngine.Object.DestroyImmediate(shadowMap);
			shadowMap = null;
			ShadowMapReady = false;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = color;
		Gizmos.DrawWireSphere(base.transform.position, range);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = color;
		Gizmos.DrawIcon(base.transform.position, "PointLight Gizmo", true);
	}

	private void CheckCamera()
	{
		if (!shadowMapCamera)
		{
			shadowMapCamera = GetComponent<Camera>();
			if (!shadowMapCamera)
			{
				shadowMapCamera = base.gameObject.AddComponent<Camera>();
			}
			shadowMapCamera.clearFlags = CameraClearFlags.Color;
			shadowMapCamera.backgroundColor = Color.white;
			shadowMapCamera.useOcclusionCulling = false;
			shadowMapCamera.allowHDR = true;
			shadowMapCamera.enabled = false;
			shadowMapCamera.nearClipPlane = 0.01f;
			shadowMapCamera.renderingPath = RenderingPath.VertexLit;
			if (depthShader == null)
			{
				depthShader = Resources.Load<Shader>("PipLightDepth");
			}
			shadowMapCamera.SetReplacementShader(depthShader, "Pip");
		}
		shadowMapCamera.cullingMask = cullingMask;
	}

	private void CheckTexture()
	{
		if (!shadowMap)
		{
			if (shadowType != LightShadows.None)
			{
				shadowMap = new RenderTexture((int)shadowResolutionCurrent, (int)shadowResolutionCurrent, 0, RenderTextureFormat.R8, RenderTextureReadWrite.Linear);
				shadowMap.hideFlags = HideFlags.DontSave;
				shadowMap.isCubemap = type == LightType.Point;
				shadowMap.useMipMap = false;
				shadowMap.autoGenerateMips = false;
				UpdateNextFrame = true;
				_lastRefresh = Time.realtimeSinceStartup;
				ShadowMapReady = true;
				ChangeUsedSize(shadowMap.width * shadowMap.height);
			}
		}
		else if (shadowMap.height != (int)shadowResolutionCurrent)
		{
			ChangeUsedSize(-shadowMap.width * shadowMap.height);
			shadowMap.Release();
			shadowMap.width = (int)shadowResolutionCurrent;
			shadowMap.height = (int)shadowResolutionCurrent;
			shadowMap.isCubemap = type == LightType.Point;
			shadowMap.Create();
			ChangeUsedSize(shadowMap.width * shadowMap.height);
			UpdateNextFrame = true;
		}
		else if (shadowMap.isCubemap != (type == LightType.Point))
		{
			shadowMap.Release();
			shadowMap.isCubemap = type == LightType.Point;
			shadowMap.Create();
			UpdateNextFrame = true;
		}
		else if (shadowType == LightShadows.None)
		{
			ChangeUsedSize(-shadowMap.width * shadowMap.height);
			UnityEngine.Object.DestroyImmediate(shadowMap);
			ShadowMapReady = false;
		}
	}

	public void BeforeRender()
	{
		renderedThisFrame = false;
	}

	public MaterialPropertyBlock GetMaterialPropertyBlock(float blendSpeed)
	{
		if (propertyBlock == null)
		{
			propertyBlock = new MaterialPropertyBlock();
		}
		else
		{
			propertyBlock.Clear();
		}
		if (ShadowMapReady && shadowType != LightShadows.None)
		{
			propertyBlock.SetTexture(prop_ShadowMapTexture, shadowMap);
		}
		bool flag = cookie != null;
		if (flag || type == LightType.Spot)
		{
			if (flag)
			{
				propertyBlock.SetTexture(prop_CookieTex, cookie);
			}
			propertyBlock.SetMatrix(prop_LightMatrix0, base.transform.worldToLocalMatrix);
		}
		Vector4 value = base.transform.position;
		value.w = 1f / range;
		propertyBlock.SetVector(prop_LightPositionRange, value);
		value.w /= range;
		propertyBlock.SetVector(prop_LightPos, value);
		propertyBlock.SetVector(prop_LightColor, (ForceWhite ? (color.grayscale * Color.white) : color.linear) * intensity);
		propertyBlock.SetFloat(prop_LightAsQuad, 0f);
		float y = 0f;
		float z = 0f;
		if (type == LightType.Spot)
		{
			float num = (float)angle * ((float)Math.PI / 180f);
			y = Mathf.Cos(num * 0.5f);
			z = Mathf.Cos(num * 0.3333f);
			propertyBlock.SetMatrix(prop_WtoSMatrix, shadowMapCamera.projectionMatrix * shadowMapCamera.worldToCameraMatrix);
		}
		float num2 = Mathf.Clamp01((Time.realtimeSinceStartup - _lastRefresh) * blendSpeed);
		propertyBlock.SetVector(prop_LightOffset, new Vector4(lightOffset, y, z, shadowStrength * num2));
		return propertyBlock;
	}

	public void UpdateLOD(Camera cam)
	{
		Vector3 position = cam.transform.position;
		Vector3 position2 = base.transform.position;
		float num = Vector3.Distance(position, position2) * PipLightSystem.Instance.Renderer.levelOfDetailAggression;
		float num2 = ((!(num <= range)) ? (range / num) : 1f);
		int b = Mathf.ClosestPowerOfTwo((int)((float)PipLightSystem.Instance.Renderer.shadowMapResolution * num2));
		b = Mathf.Max(64, b);
		if (b != (int)shadowResolutionCurrent)
		{
			shadowResolutionCurrent = (ShadowTextureSize)b;
			UpdateNextFrame = true;
		}
		CheckTexture();
	}

	public void UpdateShadowMap()
	{
		if (renderedThisFrame || shadowType == LightShadows.None)
		{
			return;
		}
		CheckCamera();
		if (UpdateNextFrame || PipLightSystem.Instance.Renderer.shadowRefreshMode == ShadowRefreshMode.EveryFrame)
		{
			Vector4 value = base.transform.position;
			value.w = 1f / range;
			Shader.SetGlobalVector(prop_Pip_LightPositionRange, value);
			shadowMapCamera.farClipPlane = range;
			shadowMapCamera.targetTexture = shadowMap;
			if (type == LightType.Point)
			{
				shadowMapCamera.RenderToCubemap(shadowMap);
			}
			else
			{
				shadowMapCamera.fieldOfView = angle;
				shadowMapCamera.Render();
			}
			UpdateNextFrame = false;
			renderedThisFrame = true;
		}
	}

	public void WriteToCommandBuffer(CommandBuffer cameraBuffer, Mesh lightSphereMesh, Material material, float blendSpeed)
	{
		if (prevRadius != range || (!base.gameObject.isStatic && base.transform.position != lastPosition))
		{
			lastPosition = base.transform.position;
			prevRadius = range;
			matrix = Matrix4x4.TRS(base.transform.position, Quaternion.identity, Vector3.one * range * 2f);
		}
		cameraBuffer.DrawMesh(lightSphereMesh, matrix, material, 0, 0, GetMaterialPropertyBlock(blendSpeed));
	}

	public static void CheckKeywords()
	{
		prop_Pip_LightPositionRange = Shader.PropertyToID("Pip_LightPositionRange");
		prop_LightPositionRange = Shader.PropertyToID("_LightPositionRange");
		prop_LightProjectionParams = Shader.PropertyToID("_LightProjectionParams");
		prop_ShadowMapTexture = Shader.PropertyToID("_ShadowMapTexture2");
		prop_LightColor = Shader.PropertyToID("_LightColor");
		prop_LightPos = Shader.PropertyToID("_LightPos");
		prop_ShadowData = Shader.PropertyToID("_LightShadowData");
		prop_CookieTex = Shader.PropertyToID("_CookieTex");
		prop_LightMatrix0 = Shader.PropertyToID("_LightMatrix0");
		prop_WtoSMatrix = Shader.PropertyToID("_WtoSMatrix");
		prop_LightAsQuad = Shader.PropertyToID("_LightAsQuad");
		prop_LightOffset = Shader.PropertyToID("_LightOffset");
	}
}
