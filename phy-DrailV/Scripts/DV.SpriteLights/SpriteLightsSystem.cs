using System.Collections.Generic;
using DV;
using DV.Utils;
using DV.VFX;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class SpriteLightsSystem : SingletonBehaviour<SpriteLightsSystem>
{
	private Mesh glowSphereMesh;

	private Texture2D glowLUT;

	private Material glowMaterialInside;

	private Material glowMaterialOutside;

	private Material flareNearMaterial;

	private Material flareFarMaterial;

	private Mesh streakMesh;

	private Material streakMaterial;

	private ComputeShader cullingShader;

	private ComputeShader rangeShader;

	private List<GeneratedLightsController> controllers = new List<GeneratedLightsController>();

	private NativeArray<SpriteLight.SpriteLightData> instanceArray = new NativeArray<SpriteLight.SpriteLightData>(1024, Allocator.Persistent);

	private const int INITIAL_SIZE = 1024;

	private const int INSTANCE_DATA_SIZE = 72;

	private uint[] glowIndirectArgs = new uint[5];

	private uint[] flareIndirectArgs = new uint[5];

	private uint[] streakIndirectArgs = new uint[5];

	private ComputeBuffer instanceBuffer;

	private ComputeBuffer culledNearBuffer;

	private ComputeBuffer culledFarBuffer;

	private ComputeBuffer nearGlowArgsBuffer;

	private ComputeBuffer farGlowArgsBuffer;

	private ComputeBuffer nearFlareArgsBuffer;

	private ComputeBuffer farFlareArgsBuffer;

	private ComputeBuffer culledStreakBuffer;

	private ComputeBuffer streakArgsBuffer;

	private Mesh quadMesh;

	private bool doFullRebuild;

	private int lastCount = -1;

	private bool collectionChanged;

	private static readonly int sp_LightWorldShift = Shader.PropertyToID("_LightWorldShift");

	private static readonly int sp_InstanceData = Shader.PropertyToID("_InstanceData");

	private static readonly int sp_InstanceBuffer = Shader.PropertyToID("instanceBuffer");

	private static readonly int sp_VisibleInstances = Shader.PropertyToID("visibleInstances");

	private static readonly int sp_InstanceCount = Shader.PropertyToID("instanceCount");

	private static readonly int sp_CameraPosition = Shader.PropertyToID("cameraPosition");

	private static readonly int sp_Range = Shader.PropertyToID("range");

	private static readonly int sp_FrustumPlanes = Shader.PropertyToID("frustumPlanes");

	private static readonly int sp_NearVisibleInstances = Shader.PropertyToID("nearVisibleInstances");

	private static readonly int sp_FarVisibleInstances = Shader.PropertyToID("farVisibleInstances");

	public float FadeoutRange { get; set; } = 200f;

	public bool DrawVolumetrics { get; set; } = true;

	public bool DrawFlares { get; set; } = true;

	public bool DrawReflectionStreaks { get; set; } = true;

	public int ReflectionStreakLayer { get; set; } = 28;

	public Transform ReflectionProbeTransform { get; set; }

	public new static string AllowAutoCreate()
	{
		return "[SpriteLightsSystem]";
	}

	public void RegisterLightsController(GeneratedLightsController controller)
	{
		if (!controllers.Contains(controller))
		{
			controllers.Add(controller);
			collectionChanged = true;
		}
	}

	public void UnregisterLightsController(GeneratedLightsController controller)
	{
		controllers.Remove(controller);
		collectionChanged = true;
	}

	protected override void Initialize()
	{
		base.Initialize();
		quadMesh = new Mesh();
		quadMesh.name = "Quad";
		quadMesh.vertices = new Vector3[4]
		{
			new Vector3(-1f, -1f, 0f),
			new Vector3(1f, -1f, 0f),
			new Vector3(1f, 1f, 0f),
			new Vector3(-1f, 1f, 0f)
		};
		quadMesh.uv = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(1f, 0f),
			new Vector2(1f, 1f),
			new Vector2(0f, 1f)
		};
		quadMesh.triangles = new int[6] { 0, 1, 2, 0, 2, 3 };
		quadMesh.UploadMeshData(markNoLongerReadable: true);
		glowSphereMesh = Resources.Load<Mesh>("SpriteLights/Icosphere");
		cullingShader = Resources.Load<ComputeShader>("SpriteLights/LightInstanceProcessing");
		rangeShader = Resources.Load<ComputeShader>("SpriteLights/LightInstanceRangeCheck");
		flareNearMaterial = Resources.Load<Material>("SpriteLights/GeneratedLightGlare");
		streakMaterial = Resources.Load<Material>("SpriteLights/VolumeLightGlareMaterial");
		streakMesh = Resources.Load<Mesh>("SpriteLights/StreakyLight");
		flareFarMaterial = Object.Instantiate(flareNearMaterial);
		flareFarMaterial.enableInstancing = true;
		glowMaterialInside = Resources.Load<Material>("SpriteLights/LightVolumeMaterialInside");
		glowMaterialOutside = Resources.Load<Material>("SpriteLights/LightVolumeMaterialOutside");
		glowIndirectArgs[0] = glowSphereMesh.GetIndexCount(0);
		glowIndirectArgs[1] = 0u;
		glowIndirectArgs[2] = glowSphereMesh.GetIndexStart(0);
		glowIndirectArgs[3] = glowSphereMesh.GetBaseVertex(0);
		glowIndirectArgs[4] = 0u;
		flareIndirectArgs[0] = quadMesh.GetIndexCount(0);
		flareIndirectArgs[1] = 0u;
		flareIndirectArgs[2] = quadMesh.GetIndexStart(0);
		flareIndirectArgs[3] = quadMesh.GetBaseVertex(0);
		flareIndirectArgs[4] = 0u;
		streakIndirectArgs[0] = streakMesh.GetIndexCount(0);
		streakIndirectArgs[1] = 0u;
		streakIndirectArgs[2] = streakMesh.GetIndexStart(0);
		streakIndirectArgs[3] = streakMesh.GetBaseVertex(0);
		streakIndirectArgs[4] = 0u;
		nearGlowArgsBuffer = new ComputeBuffer(1, glowIndirectArgs.Length * 4, ComputeBufferType.DrawIndirect);
		nearGlowArgsBuffer.SetData(glowIndirectArgs);
		farGlowArgsBuffer = new ComputeBuffer(1, glowIndirectArgs.Length * 4, ComputeBufferType.DrawIndirect);
		farGlowArgsBuffer.SetData(glowIndirectArgs);
		nearFlareArgsBuffer = new ComputeBuffer(1, flareIndirectArgs.Length * 4, ComputeBufferType.DrawIndirect);
		nearFlareArgsBuffer.SetData(flareIndirectArgs);
		farFlareArgsBuffer = new ComputeBuffer(1, flareIndirectArgs.Length * 4, ComputeBufferType.DrawIndirect);
		farFlareArgsBuffer.SetData(flareIndirectArgs);
		streakArgsBuffer = new ComputeBuffer(1, streakIndirectArgs.Length * 4, ComputeBufferType.DrawIndirect);
		streakArgsBuffer.SetData(streakIndirectArgs);
		instanceBuffer = new ComputeBuffer(1024, 72);
		instanceBuffer.SetCounterValue(0u);
		culledNearBuffer = new ComputeBuffer(1024, 72, ComputeBufferType.Append);
		culledNearBuffer.SetCounterValue(0u);
		culledFarBuffer = new ComputeBuffer(1024, 72, ComputeBufferType.Append);
		culledFarBuffer.SetCounterValue(0u);
		culledStreakBuffer = new ComputeBuffer(1024, 72, ComputeBufferType.Append);
		culledStreakBuffer.SetCounterValue(0u);
		rangeShader.SetBuffer(0, sp_InstanceBuffer, instanceBuffer);
		rangeShader.SetBuffer(0, sp_VisibleInstances, culledStreakBuffer);
		cullingShader.SetBuffer(0, sp_InstanceBuffer, instanceBuffer);
		cullingShader.SetBuffer(0, sp_NearVisibleInstances, culledNearBuffer);
		cullingShader.SetBuffer(0, sp_FarVisibleInstances, culledFarBuffer);
		glowMaterialInside.SetBuffer(sp_InstanceData, culledNearBuffer);
		glowMaterialOutside.SetBuffer(sp_InstanceData, culledFarBuffer);
		flareNearMaterial.SetBuffer(sp_InstanceData, culledNearBuffer);
		flareFarMaterial.SetBuffer(sp_InstanceData, culledFarBuffer);
		streakMaterial.SetBuffer(sp_InstanceData, culledStreakBuffer);
	}

	public void RebuildAllData()
	{
		foreach (GeneratedLightsController controller in controllers)
		{
			controller.UpdateAllLights();
		}
		doFullRebuild = true;
		Debug.Log("[SLS] Force-rebuilding all data... " + controllers.Count + " controllers");
	}

	private int ComputeRealtimeLightCount()
	{
		int num = 0;
		foreach (GeneratedLightsController controller in controllers)
		{
			num += controller.RealtimeEntryCount;
		}
		return num;
	}

	private void LateUpdate()
	{
		if (!DrawFlares && !DrawReflectionStreaks && !DrawVolumetrics)
		{
			return;
		}
		Camera main = Camera.main;
		if (main == null)
		{
			return;
		}
		Vector3 vector = ((SingletonBehaviour<WorldTimeBasedEvents>.Instance != null && SingletonBehaviour<WorldTimeBasedEvents>.Instance.provider != null) ? SingletonBehaviour<WorldTimeBasedEvents>.Instance.provider.CurrentMove : Vector3.zero);
		bool flag = collectionChanged || doFullRebuild;
		if (!flag)
		{
			for (int i = 0; i < controllers.Count; i++)
			{
				if (controllers[i].IsDirty)
				{
					flag = true;
					break;
				}
			}
		}
		int num = (flag ? ComputeRealtimeLightCount() : lastCount);
		if (num <= 0)
		{
			return;
		}
		if (num > instanceArray.Length)
		{
			int num2;
			for (num2 = instanceArray.Length; num2 < num; num2 *= 2)
			{
			}
			if (instanceArray.IsCreated)
			{
				instanceArray.Dispose();
			}
			instanceArray = new NativeArray<SpriteLight.SpriteLightData>(num2, Allocator.Persistent);
			instanceBuffer.Release();
			instanceBuffer = new ComputeBuffer(num2, 72);
			culledNearBuffer.Release();
			culledNearBuffer = new ComputeBuffer(num2, 72, ComputeBufferType.Append);
			culledFarBuffer.Release();
			culledFarBuffer = new ComputeBuffer(num2, 72, ComputeBufferType.Append);
			culledStreakBuffer.Release();
			culledStreakBuffer = new ComputeBuffer(num2, 72, ComputeBufferType.Append);
			rangeShader.SetBuffer(0, sp_InstanceBuffer, instanceBuffer);
			rangeShader.SetBuffer(0, sp_VisibleInstances, culledStreakBuffer);
			cullingShader.SetBuffer(0, sp_InstanceBuffer, instanceBuffer);
			cullingShader.SetBuffer(0, sp_NearVisibleInstances, culledNearBuffer);
			cullingShader.SetBuffer(0, sp_FarVisibleInstances, culledFarBuffer);
			glowMaterialInside.SetBuffer(sp_InstanceData, culledNearBuffer);
			glowMaterialOutside.SetBuffer(sp_InstanceData, culledFarBuffer);
			flareNearMaterial.SetBuffer(sp_InstanceData, culledNearBuffer);
			flareFarMaterial.SetBuffer(sp_InstanceData, culledFarBuffer);
			streakMaterial.SetBuffer(sp_InstanceData, culledStreakBuffer);
			flag = true;
		}
		if (flag)
		{
			int num3 = 0;
			for (int j = 0; j < controllers.Count; j++)
			{
				NativeArray<SpriteLight.SpriteLightData>.Copy(controllers[j].LocalData, 0, instanceArray, num3, controllers[j].RealtimeEntryCount);
				num3 += controllers[j].RealtimeEntryCount;
				controllers[j].IsDirty = false;
			}
			instanceBuffer.SetData(instanceArray);
			lastCount = num;
			collectionChanged = false;
			doFullRebuild = false;
		}
		int threadGroupsX = Mathf.CeilToInt((float)num / 64f);
		if (DrawReflectionStreaks)
		{
			culledStreakBuffer.SetCounterValue(0u);
			rangeShader.SetInt(sp_InstanceCount, num);
			rangeShader.SetVector(sp_CameraPosition, ((ReflectionProbeTransform != null) ? ReflectionProbeTransform : main.transform).position);
			rangeShader.SetFloat(sp_Range, FadeoutRange);
			rangeShader.SetVector(sp_LightWorldShift, vector);
			rangeShader.Dispatch(0, threadGroupsX, 1, 1);
			ComputeBuffer.CopyCount(culledStreakBuffer, streakArgsBuffer, 4);
		}
		if (DrawFlares || DrawVolumetrics)
		{
			culledNearBuffer.SetCounterValue(0u);
			culledFarBuffer.SetCounterValue(0u);
			cullingShader.SetInt(sp_InstanceCount, num);
			using (PooledArray<Plane> pooledArray = ArrayPool<Plane>.New(6))
			{
				using (PooledArray<Vector4> pooledArray2 = ArrayPool<Vector4>.New(6))
				{
					GeometryUtility.CalculateFrustumPlanes(main, pooledArray);
					for (int k = 0; k < 6; k++)
					{
						pooledArray2[k] = new Vector4(pooledArray[k].normal.x, pooledArray[k].normal.y, pooledArray[k].normal.z, pooledArray[k].distance);
					}
					cullingShader.SetVectorArray(sp_FrustumPlanes, pooledArray2);
				}
			}
			cullingShader.SetVector(sp_CameraPosition, main.transform.position);
			cullingShader.SetFloat(sp_Range, FadeoutRange);
			cullingShader.SetVector(sp_LightWorldShift, vector);
			cullingShader.Dispatch(0, threadGroupsX, 1, 1);
			ComputeBuffer.CopyCount(culledNearBuffer, nearGlowArgsBuffer, 4);
			ComputeBuffer.CopyCount(culledFarBuffer, farGlowArgsBuffer, 4);
			ComputeBuffer.CopyCount(culledNearBuffer, nearFlareArgsBuffer, 4);
			ComputeBuffer.CopyCount(culledFarBuffer, farFlareArgsBuffer, 4);
		}
		Shader.SetGlobalVector(sp_LightWorldShift, vector);
		if (DrawVolumetrics)
		{
			Graphics.DrawMeshInstancedIndirect(glowSphereMesh, 0, glowMaterialInside, new Bounds(Vector3.zero, Vector3.one * 300000f), nearGlowArgsBuffer, 0, null, ShadowCastingMode.Off, receiveShadows: false, 0, main, LightProbeUsage.Off, null);
			Graphics.DrawMeshInstancedIndirect(glowSphereMesh, 0, glowMaterialOutside, new Bounds(Vector3.zero, Vector3.one * 300000f), farGlowArgsBuffer, 0, null, ShadowCastingMode.Off, receiveShadows: false, 0, main, LightProbeUsage.Off, null);
		}
		if (DrawFlares)
		{
			Graphics.DrawMeshInstancedIndirect(quadMesh, 0, flareNearMaterial, new Bounds(Vector3.zero, Vector3.one * 300000f), nearFlareArgsBuffer, 0, null, ShadowCastingMode.Off, receiveShadows: false, 0, main, LightProbeUsage.Off, null);
			Graphics.DrawMeshInstancedIndirect(quadMesh, 0, flareFarMaterial, new Bounds(Vector3.zero, Vector3.one * 300000f), farFlareArgsBuffer, 0, null, ShadowCastingMode.Off, receiveShadows: false, 0, main, LightProbeUsage.Off, null);
		}
		if (DrawReflectionStreaks)
		{
			Graphics.DrawMeshInstancedIndirect(streakMesh, 0, streakMaterial, new Bounds(Vector3.zero, Vector3.one * 300000f), streakArgsBuffer, 0, null, ShadowCastingMode.Off, receiveShadows: false, ReflectionStreakLayer, null, LightProbeUsage.Off, null);
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		instanceBuffer?.Release();
		instanceArray.Dispose();
		culledNearBuffer?.Release();
		culledFarBuffer?.Release();
		culledStreakBuffer?.Release();
		nearGlowArgsBuffer?.Release();
		farGlowArgsBuffer?.Release();
		nearFlareArgsBuffer?.Release();
		farFlareArgsBuffer?.Release();
		streakArgsBuffer?.Release();
	}
}
