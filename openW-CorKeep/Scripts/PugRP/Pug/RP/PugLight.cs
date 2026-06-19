using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.RP
{
	[RequireComponent(typeof(Light))]
	[ExecuteInEditMode]
	public class PugLight : MonoBehaviour
	{
		public static readonly List<PugLight> instances = new List<PugLight>();

		public ShadowUpdateMode shadowUpdateMode;

		public bool skipShadowQueue;

		[Range(0f, 1f)]
		public float quality = 1f;

		[Range(0f, 1f)]
		public float physicality = 1f;

		[Min(0.01f)]
		public float size = 0.1f;

		public Transform directionalTextureAnchor;

		public ShadowsType directionalShadowsType;

		[Min(0f)]
		public float directionalRaymarchedShadowsRange = 4f;

		[Min(0f)]
		public float directionalRaymarchedShadowsBias = 0.01f;

		[Min(0f)]
		public bool directionalRaymarchedSkyTest;

		public Vector2 directionalTextureSize = new Vector2(40f, 20f);

		[Range(0f, 64f)]
		[Tooltip("The number of pixels per-meter to allocate for the directional texture.")]
		public float directionalTexturePPM = 16f;

		public Color directionalClearColor = new Color(1f, 1f, 1f, 0f);

		[Range(0f, 64f)]
		public float directionalTextureBlur;

		[Range(0f, 1f)]
		public float directionalTextureBlurBlend;

		private Light m_light;

		private Vector3 m_prevPosition;

		private float m_prevRange;

		private bool m_hasCachedData;

		private Vector3 m_cachedTruePosition;

		[NonSerialized]
		public Matrix4x4 directionalMatrix;

		private static GlobalKeyword s_directionalKeyword;

		private static bool s_directionalKeywordCreated = false;

		private RenderTexture m_directionalColorTexture;

		private RenderTexture m_directionalDepthTexture;

		private static string s_directionalColorTextureName = "Directional Color";

		private static string s_directionalDepthTextureName = "Directional Depth";

		private static int s_colorTextureTmp = Shader.PropertyToID("_DirectionalColorTmp");

		private Camera m_internalCamera;

		private CullingResults m_cullingResults;

		private RenderTextureDescriptor m_colorDesc;

		public Light light => m_light;

		public bool shouldRender
		{
			get
			{
				if (light != null)
				{
					if (light.shadows != LightShadows.None && !m_hasCachedData)
					{
						return PugRP.asset.punctualShadowsType == ShadowsType.Raymarching;
					}
					return true;
				}
				return false;
			}
		}

		public Vector3 cachedPosition => PugRPUtils.WorldToRender(m_cachedTruePosition);

		public Quaternion cachedRotation { get; private set; }

		public Vector3 cachedForward { get; private set; }

		public float cachedRange { get; private set; }

		public float cachedSpotAngle { get; private set; }

		public RenderTexture directionalColorTexture => m_directionalColorTexture;

		public RenderTexture directionalDepthTexture => m_directionalDepthTexture;

		private void OnEnable()
		{
			Initialize();
			m_hasCachedData = false;
			instances.Add(this);
		}

		private void OnDisable()
		{
			instances.Remove(this);
		}

		public void Initialize()
		{
			m_light = GetComponent<Light>();
		}

		public void SetShadowDirty()
		{
			m_light.SetShadowDirty();
		}

		public void UpdatePositionalData()
		{
			m_cachedTruePosition = PugRPUtils.RenderToWorld(base.transform.position);
			cachedRotation = base.transform.rotation;
			cachedForward = base.transform.forward;
			cachedRange = light.range;
			cachedSpotAngle = light.spotAngle;
			m_hasCachedData = true;
		}

		public bool CheckShadowDirty()
		{
			float range = m_light.range;
			Vector3 vector = PugRPUtils.RenderToWorld(m_light.transform.position);
			if (vector != m_prevPosition || range != m_prevRange)
			{
				m_prevPosition = vector;
				m_prevRange = range;
				return true;
			}
			return false;
		}

		public void UpdateDirectional(ScriptableRenderContext context, CommandBuffer cmd)
		{
			if (!s_directionalKeywordCreated)
			{
				s_directionalKeyword = GlobalKeyword.Create("RENDER_DIRECTIONAL_LIGHT");
				s_directionalKeywordCreated = true;
			}
			if (light.type != LightType.Directional || directionalTextureAnchor == null)
			{
				PugRPUtils.Release(ref m_directionalColorTexture);
				PugRPUtils.Release(ref m_directionalDepthTexture);
				return;
			}
			if (directionalShadowsType == ShadowsType.Raymap)
			{
				Debug.LogError("Directional lights do not support Raymap shadows, defaulting to Shadowmap");
				directionalShadowsType = ShadowsType.Shadowmap;
			}
			else if (directionalShadowsType == ShadowsType.Raymarching && PugRP.asset.punctualShadowsType == ShadowsType.Raymap)
			{
				Debug.LogError("Directional lights do not support Raymarching shadows when punctual shadows are set to Raymap, defaulting to Shadowmap");
				directionalShadowsType = ShadowsType.Shadowmap;
			}
			SnapDirectional(out var position, out var vector, out var resolution);
			m_colorDesc = new RenderTextureDescriptor(resolution.x, resolution.y, RenderTextureFormat.ARGB32, 0)
			{
				enableRandomWrite = true
			};
			PugRPUtils.Setup(ref m_directionalColorTexture, s_directionalColorTextureName, m_colorDesc);
			PugRPUtils.Setup(ref m_directionalDepthTexture, s_directionalDepthTextureName, resolution.x, resolution.y, PugRPUtils.depthBits, RenderTextureFormat.Shadowmap);
			if (m_internalCamera == null)
			{
				m_internalCamera = PugRPUtils.GetUtilityCamera("_DIRECTIONAL_TEXTURE_CAMERA");
			}
			float num = 100f;
			Vector2 vector2 = vector / 2f;
			m_internalCamera.transform.position = position - base.transform.forward * num;
			m_internalCamera.transform.rotation = base.transform.rotation;
			m_internalCamera.orthographic = true;
			m_internalCamera.orthographicSize = vector2.y;
			m_internalCamera.aspect = vector2.x / vector2.y;
			m_internalCamera.nearClipPlane = 0.01f;
			m_internalCamera.farClipPlane = num * 2f;
			Matrix4x4 inverse = Matrix4x4.TRS(m_internalCamera.transform.position, m_internalCamera.transform.rotation, new Vector3(1f, 1f, -1f)).inverse;
			Matrix4x4 matrix4x = Matrix4x4.Ortho(0f - vector2.x, vector2.x, 0f - vector2.y, vector2.y, m_internalCamera.nearClipPlane, m_internalCamera.farClipPlane);
			directionalMatrix = GL.GetGPUProjectionMatrix(matrix4x, renderIntoTexture: false) * inverse;
			m_internalCamera.worldToCameraMatrix = inverse;
			m_internalCamera.projectionMatrix = matrix4x;
			m_internalCamera.cullingMask = light.cullingMask;
			if (m_internalCamera.TryGetCullingParameters(out var cullingParameters))
			{
				cullingParameters.cullingOptions = CullingOptions.ForceEvenIfCameraIsNotActive | CullingOptions.DisablePerObjectCulling;
				if (PugRP.useSharedCullPass)
				{
					m_cullingResults = PugRP.sharedCullingResults;
				}
				else
				{
					m_cullingResults = context.Cull(ref cullingParameters);
					PugRP.cullOps++;
				}
				cmd.SetRenderTarget(m_directionalColorTexture, m_directionalDepthTexture);
				cmd.ClearRenderTarget(clearDepth: true, clearColor: true, directionalClearColor);
				cmd.SetViewProjectionMatrices(inverse, matrix4x);
				cmd.SetKeyword(in s_directionalKeyword, value: true);
				PugRP.DrawShadowGeometry(context, cmd, m_internalCamera, m_cullingResults);
				PugRP.DrawForwardTransparent(context, cmd, m_internalCamera, m_cullingResults, RenderQueueRange.transparent);
				cmd.SetKeyword(in s_directionalKeyword, value: false);
				if (directionalTextureBlur > 0f)
				{
					cmd.GetTemporaryRT(s_colorTextureTmp, m_colorDesc);
					PugRPUtils.WideBlur(cmd, m_directionalColorTexture, m_directionalColorTexture.descriptor, Mathf.Sqrt(directionalTextureBlur), 1f - directionalTextureBlurBlend);
					cmd.ReleaseTemporaryRT(s_colorTextureTmp);
				}
			}
		}

		public void SnapDirectional(out Vector3 position, out Vector2 size, out Vector2Int resolution)
		{
			resolution = new Vector2Int(Mathf.CeilToInt(directionalTextureSize.x * directionalTexturePPM), Mathf.CeilToInt(directionalTextureSize.y * directionalTexturePPM));
			size = new Vector2((float)resolution.x / directionalTexturePPM, (float)resolution.y / directionalTexturePPM);
			position = PugRPUtils.SnapBufferPosition(directionalTextureAnchor.position, directionalTextureAnchor.rotation, directionalTextureSize, new Vector2Int(resolution.x, resolution.y));
		}

		private void OnDrawGizmosSelected()
		{
			if (light.type == LightType.Directional && directionalTextureAnchor != null)
			{
				Gizmos.color = Color.white * 0.2f;
				Gizmos.matrix = Matrix4x4.TRS(directionalTextureAnchor.position, directionalTextureAnchor.rotation, new Vector3(directionalTextureSize.x, directionalTextureSize.y, 0f));
				Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
				SnapDirectional(out var position, out var vector, out var _);
				Gizmos.color = Color.white;
				Gizmos.matrix = Matrix4x4.TRS(position, directionalTextureAnchor.rotation, vector);
				Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
			}
			if (light.type != LightType.Directional && PugRP.asset.enablePhysicalLightAttenuation)
			{
				Gizmos.DrawWireSphere(light.transform.position, size);
			}
		}
	}
}
