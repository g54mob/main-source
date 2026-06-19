using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WaterSim : MonoBehaviour
{
	private struct Impulse
	{
		public Vector3 position;

		public float radius;

		public float amplitude;
	}

	private struct SquareImpulse
	{
		public Vector3 position;

		public Quaternion rotation;

		public Vector3 size;

		public float amplitude;
	}

	public const int MAX_AFFECTOR_COUNT = 512;

	public const int CS_KERNEL_UPDATE = 0;

	public const int PASS_SURFACE = 0;

	public const int PASS_BLOCKER = 1;

	public const int PASS_AFFECTOR_CIRCLE = 2;

	public const int PASS_AFFECTOR_SQUARE = 3;

	public const int PASS_INSPECTOR = 4;

	[Min(0f)]
	public float texelSize = 0.25f;

	public Vector2Int resolution = new Vector2Int(512, 512);

	[Range(0f, 1f)]
	public float speedMultiplier = 1f;

	[Range(0f, 1f)]
	public float foamMultiplier = 1f;

	public Texture2D ambientHeightmap;

	private RenderTexture m_surface;

	private RenderTexture m_state;

	private RenderTexture m_prevState;

	private CommandBuffer m_cmd;

	private ComputeShader m_compute;

	private Material m_material;

	private Matrix4x4[] m_circleMatrices;

	private Matrix4x4[] m_squareMatrices;

	private Matrix4x4[] m_circlePrevMatrices;

	private Matrix4x4[] m_squarePrevMatrices;

	private Vector4[] m_circleParams;

	private Vector4[] m_squareParams;

	private bool m_hasPrevState;

	private MaterialPropertyBlock m_circleProperties;

	private MaterialPropertyBlock m_squareProperties;

	private Vector3 m_prevSimOrigin;

	private int m_simTick;

	private int m_circleAffectorCount;

	private int m_squareAffectorCount;

	private static readonly List<Impulse> s_impulses = new List<Impulse>();

	private static readonly List<SquareImpulse> s_squareImpulses = new List<SquareImpulse>();

	private static int _Params = Shader.PropertyToID("_Params");

	private static int _PrevMatrices = Shader.PropertyToID("_PrevMatrices");

	private static int _WaterSimTransform = Shader.PropertyToID("_WaterSimTransform");

	private static int _TexelDelta = Shader.PropertyToID("_TexelDelta");

	private static int _DeltaTime = Shader.PropertyToID("_DeltaTime");

	private static int _SpeedMultiplier = Shader.PropertyToID("_SpeedMultiplier");

	private static int _Surface = Shader.PropertyToID("_Surface");

	private static int _PrevState = Shader.PropertyToID("_PrevState");

	private static int _State = Shader.PropertyToID("_State");

	private static int _AmbientHeightmap = Shader.PropertyToID("_AmbientHeightmap");

	private static int _WaterSimState = Shader.PropertyToID("_WaterSimState");

	private static int _WaterSimPrevTransform = Shader.PropertyToID("_WaterSimPrevTransform");

	private static int _WaterSimPrevState = Shader.PropertyToID("_WaterSimPrevState");

	private static int _WaterSimTexelSize = Shader.PropertyToID("_WaterSimTexelSize");

	private static int _WaterSimDelta = Shader.PropertyToID("_WaterSimDelta");

	private static int _WaterSimFoamMultiplier = Shader.PropertyToID("_WaterSimFoamMultiplier");

	private static Mesh s_quad;

	public static WaterSim instance { get; private set; }

	public Vector2 size => (Vector2)resolution * texelSize;

	public Material material
	{
		get
		{
			if (m_material == null)
			{
				m_material = Resources.Load<Material>("Materials/WaterSim");
			}
			return m_material;
		}
	}

	public int circleAffectorCount => m_circleAffectorCount;

	public int squareAffectorCount => m_squareAffectorCount;

	public static Vector3 GetRenderOrigin()
	{
		return Manager.camera.RenderOrigo;
	}

	public Vector3 GetCenter()
	{
		Vector3 renderOrigin = GetRenderOrigin();
		Vector3 vector = base.transform.position + renderOrigin;
		vector.x = Mathf.Round(vector.x / texelSize) * texelSize;
		vector.z = Mathf.Round(vector.z / texelSize) * texelSize;
		return vector - renderOrigin;
	}

	private void OnEnable()
	{
		instance = this;
	}

	public void ResetSimulation()
	{
		m_hasPrevState = false;
	}

	private void FixedUpdate()
	{
		UpdateSimulation(Time.fixedDeltaTime);
	}

	public static void AddImpulse(Vector3 position, float radius = 0.5f, float amplitude = 1f)
	{
		if (!(instance == null) && instance.enabled && s_impulses.Count < 512)
		{
			s_impulses.Add(new Impulse
			{
				position = position,
				radius = radius,
				amplitude = amplitude
			});
		}
	}

	public static void AddSquareImpulse(Vector3 position, Quaternion rotation, Vector3 size, float amplitude = 1f)
	{
		if (!(instance == null) && instance.enabled && s_squareImpulses.Count < 512)
		{
			s_squareImpulses.Add(new SquareImpulse
			{
				position = position,
				rotation = rotation,
				size = size,
				amplitude = amplitude
			});
		}
	}

	private void LazyInitialize()
	{
		if (m_cmd == null)
		{
			m_cmd = new CommandBuffer
			{
				name = "WaterSim"
			};
		}
		if (m_compute == null)
		{
			m_compute = Resources.Load<ComputeShader>("WaterSim");
		}
		object surface = m_surface;
		if (surface == null || m_surface.width != resolution.x || m_surface.height != resolution.y)
		{
			if (surface != null)
			{
				Debug.Log("WaterSim.LazyInitialize: released all render textures.");
				m_surface.Release();
				m_state.Release();
				m_prevState.Release();
			}
			Debug.Log("WaterSim.LazyInitialize: created the surface texture.");
			m_surface = new RenderTexture(resolution.x, resolution.y, 0, RenderTextureFormat.R8)
			{
				useMipMap = false,
				name = "WaterSim (Surface)"
			};
			m_surface.Create();
			Debug.Log("WaterSim.LazyInitialize: created the state texture.");
			m_state = new RenderTexture(resolution.x, resolution.y, 0, RenderTextureFormat.ARGBHalf)
			{
				enableRandomWrite = true,
				useMipMap = false,
				name = "WaterSim (State)"
			};
			Debug.Log("WaterSim.LazyInitialize: created the previous state texture.");
			m_prevState = new RenderTexture(m_state)
			{
				name = "WaterSim (Previous state)"
			};
			m_state.Create();
			m_prevState.Create();
			m_hasPrevState = false;
		}
		if (s_quad == null)
		{
			CreateQuad();
		}
		if (m_circleMatrices == null || m_circleMatrices.Length != 512)
		{
			m_circleMatrices = new Matrix4x4[512];
			m_squareMatrices = new Matrix4x4[512];
			m_circlePrevMatrices = new Matrix4x4[512];
			m_squarePrevMatrices = new Matrix4x4[512];
			m_circleParams = new Vector4[512];
			m_squareParams = new Vector4[512];
		}
		if (m_circleProperties == null)
		{
			m_circleProperties = new MaterialPropertyBlock();
			m_squareProperties = new MaterialPropertyBlock();
		}
	}

	private void UpdateSimulation(float deltaTime)
	{
		LazyInitialize();
		Vector3 center = GetCenter();
		Vector3 renderOrigin = GetRenderOrigin();
		Vector3 vector = center + renderOrigin;
		Vector3 vector2 = (m_hasPrevState ? m_prevSimOrigin : vector);
		Vector3 vector3 = vector - vector2;
		Vector2 vector4 = new Vector2(vector3.x, vector3.z) / texelSize;
		Matrix4x4 inverse = Matrix4x4.TRS(center + Vector3.up * 10f, Quaternion.LookRotation(Vector3.down, Vector3.forward), new Vector3(1f, 1f, -1f)).inverse;
		Matrix4x4 inverse2 = Matrix4x4.TRS(center - vector3 + Vector3.up * 10f, Quaternion.LookRotation(Vector3.down, Vector3.forward), new Vector3(1f, 1f, -1f)).inverse;
		Matrix4x4 proj = Matrix4x4.Ortho((0f - size.x) / 2f, size.x / 2f, (0f - size.y) / 2f, size.y / 2f, 0.01f, 20f);
		material.SetFloat(_DeltaTime, deltaTime);
		RenderTexture prevState = m_prevState;
		m_prevState = m_state;
		m_state = prevState;
		m_cmd.Clear();
		m_cmd.SetRenderTarget(m_surface);
		m_cmd.ClearRenderTarget(clearDepth: false, clearColor: true, Color.clear);
		m_cmd.SetViewProjectionMatrices(inverse, proj);
		for (int i = 0; i < WaterSimSurface.instances.Count; i++)
		{
			WaterSimSurface waterSimSurface = WaterSimSurface.instances[i];
			if (waterSimSurface.type == WaterSimSurface.Type.Surface)
			{
				m_cmd.DrawRenderer(waterSimSurface.renderer, material, 0, 0);
			}
		}
		for (int j = 0; j < WaterSimSurface.instances.Count; j++)
		{
			WaterSimSurface waterSimSurface2 = WaterSimSurface.instances[j];
			if (waterSimSurface2.type == WaterSimSurface.Type.Blocker)
			{
				m_cmd.DrawRenderer(waterSimSurface2.renderer, material, 0, 1);
			}
		}
		m_cmd.SetRenderTarget(m_prevState);
		if (!m_hasPrevState)
		{
			m_cmd.ClearRenderTarget(clearDepth: false, clearColor: true, Color.clear);
		}
		m_cmd.SetViewProjectionMatrices(inverse2, proj);
		m_circleAffectorCount = 0;
		m_squareAffectorCount = 0;
		for (int k = 0; k < Mathf.Min(s_impulses.Count, 512); k++)
		{
			Impulse impulse = s_impulses[k];
			m_circleParams[m_circleAffectorCount] = new Vector4(0f, impulse.amplitude, 0f, 0f);
			m_circlePrevMatrices[m_circleAffectorCount] = Matrix4x4.TRS(impulse.position, Quaternion.identity, Vector3.one * impulse.radius * 2f);
			m_circleMatrices[m_circleAffectorCount] = m_circlePrevMatrices[m_circleAffectorCount];
			m_circleAffectorCount++;
		}
		for (int l = 0; l < Mathf.Min(s_squareImpulses.Count, 512); l++)
		{
			SquareImpulse squareImpulse = s_squareImpulses[l];
			m_squareParams[m_squareAffectorCount] = new Vector4(0f, squareImpulse.amplitude, 0f, 0f);
			m_squarePrevMatrices[m_squareAffectorCount] = Matrix4x4.TRS(squareImpulse.position, squareImpulse.rotation, squareImpulse.size);
			m_squareMatrices[m_squareAffectorCount] = m_squarePrevMatrices[m_squareAffectorCount];
			m_squareAffectorCount++;
		}
		s_impulses.Clear();
		s_squareImpulses.Clear();
		for (int m = 0; m < WaterSimAffector.instances.Count; m++)
		{
			WaterSimAffector waterSimAffector = WaterSimAffector.instances[m];
			waterSimAffector.prevLocalToWorld[0, 3] -= vector3.x;
			waterSimAffector.prevLocalToWorld[2, 3] -= vector3.z;
			Vector3 vector5 = (waterSimAffector.transform.position + renderOrigin - waterSimAffector.prevPosition) / deltaTime;
			if (!waterSimAffector.includedInSim)
			{
				vector5 = Vector3.zero;
				waterSimAffector.prevLocalToWorld = waterSimAffector.transform.localToWorldMatrix;
			}
			int num = Mathf.CeilToInt(1f / waterSimAffector.bobFrequency / deltaTime);
			float num2 = ((!waterSimAffector.smoothBobbing) ? ((float)(((m_simTick + Mathf.FloorToInt(waterSimAffector.randomOffset * (float)num)) % num == 0) ? 1 : 0)) : (Mathf.Sin((Time.time * waterSimAffector.bobFrequency + waterSimAffector.randomOffset) * 2f * MathF.PI) * deltaTime));
			num2 *= waterSimAffector.bobAmplitudeStill + vector5.magnitude * waterSimAffector.bobAmplitudeMovement;
			Vector4 vector6 = new Vector4(waterSimAffector.movement, num2, 0f, 0f);
			if (waterSimAffector.type == WaterSimAffector.Type.Circle && m_circleAffectorCount < 512)
			{
				m_circleParams[m_circleAffectorCount] = vector6;
				m_circlePrevMatrices[m_circleAffectorCount] = waterSimAffector.prevLocalToWorld;
				m_circleMatrices[m_circleAffectorCount] = waterSimAffector.transform.localToWorldMatrix;
				waterSimAffector.includedInSim = true;
				m_circleAffectorCount++;
			}
			else if (waterSimAffector.type == WaterSimAffector.Type.Square && m_squareAffectorCount < 512)
			{
				m_squareParams[m_squareAffectorCount] = vector6;
				m_squarePrevMatrices[m_squareAffectorCount] = waterSimAffector.prevLocalToWorld;
				m_squareMatrices[m_squareAffectorCount] = waterSimAffector.transform.localToWorldMatrix;
				waterSimAffector.includedInSim = true;
				m_squareAffectorCount++;
			}
			else
			{
				waterSimAffector.includedInSim = false;
			}
			waterSimAffector.prevLocalToWorld = waterSimAffector.transform.localToWorldMatrix;
			waterSimAffector.prevPosition = waterSimAffector.transform.position + renderOrigin;
		}
		if (m_circleAffectorCount > 0)
		{
			m_circleProperties.SetVectorArray(_Params, m_circleParams);
			m_circleProperties.SetMatrixArray(_PrevMatrices, m_circlePrevMatrices);
			m_cmd.DrawMeshInstanced(s_quad, 0, material, 2, m_circleMatrices, m_circleAffectorCount, m_circleProperties);
		}
		if (m_squareAffectorCount > 0)
		{
			m_squareProperties.SetVectorArray(_Params, m_squareParams);
			m_squareProperties.SetMatrixArray(_PrevMatrices, m_squarePrevMatrices);
			m_cmd.DrawMeshInstanced(s_quad, 0, material, 3, m_squareMatrices, m_squareAffectorCount, m_squareProperties);
		}
		m_cmd.SetGlobalVector(_WaterSimTransform, new Vector4(vector.x - size.x / 2f, vector.z - size.y / 2f, 1f / size.x, 1f / size.y));
		m_cmd.SetComputeVectorParam(m_compute, _TexelDelta, vector4);
		m_cmd.SetComputeFloatParam(m_compute, _DeltaTime, deltaTime);
		m_cmd.SetComputeFloatParam(m_compute, _SpeedMultiplier, speedMultiplier);
		m_cmd.SetComputeTextureParam(m_compute, 0, _Surface, m_surface);
		m_cmd.SetComputeTextureParam(m_compute, 0, _PrevState, m_prevState);
		m_cmd.SetComputeTextureParam(m_compute, 0, _State, m_state);
		m_cmd.SetComputeTextureParam(m_compute, 0, _AmbientHeightmap, ambientHeightmap);
		int threadGroupsX = Mathf.CeilToInt((float)resolution.x / 8f);
		int threadGroupsY = Mathf.CeilToInt((float)resolution.y / 8f);
		m_cmd.DispatchCompute(m_compute, 0, threadGroupsX, threadGroupsY, 1);
		m_cmd.SetGlobalTexture(_WaterSimState, m_state);
		m_cmd.SetGlobalVector(_WaterSimPrevTransform, new Vector4(vector2.x - size.x / 2f, vector2.z - size.y / 2f, 1f / size.x, 1f / size.y));
		m_cmd.SetGlobalTexture(_WaterSimPrevState, m_prevState);
		m_cmd.SetGlobalFloat(_WaterSimTexelSize, texelSize);
		m_cmd.SetGlobalFloat(_WaterSimFoamMultiplier, foamMultiplier);
		Graphics.ExecuteCommandBuffer(m_cmd);
		m_hasPrevState = true;
		m_simTick++;
		m_prevSimOrigin = vector;
	}

	private void LateUpdate()
	{
		float value = (float)(Time.timeAsDouble - Time.fixedTimeAsDouble) / Time.fixedDeltaTime;
		Shader.SetGlobalFloat(_WaterSimDelta, value);
	}

	private static void CreateQuad()
	{
		Vector3[] vertices = new Vector3[4]
		{
			new Vector3(-0.5f, 0f, -0.5f),
			new Vector3(0.5f, 0f, 0.5f),
			new Vector3(0.5f, 0f, -0.5f),
			new Vector3(-0.5f, 0f, 0.5f)
		};
		Vector2[] uv = new Vector2[4]
		{
			new Vector2(0f, 1f),
			new Vector2(1f, 0f),
			new Vector2(1f, 1f),
			new Vector2(0f, 0f)
		};
		int[] triangles = new int[6] { 0, 1, 2, 1, 0, 3 };
		s_quad = new Mesh
		{
			name = "WaterSimQuad",
			vertices = vertices,
			uv = uv,
			triangles = triangles
		};
		s_quad.RecalculateBounds();
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(GetCenter(), new Vector3(size.x, 0f, size.y));
	}
}
