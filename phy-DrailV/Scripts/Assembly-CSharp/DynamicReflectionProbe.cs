using System.Collections;
using System.Collections.Generic;
using DV.TerrainSystem;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;
using UnityEngine.Rendering;

[ExecutionOrder(10000)]
public class DynamicReflectionProbe : MonoBehaviour
{
	public enum ProbeType
	{
		SkyboxBase = 0,
		FullEnvironment = 1,
		CustomLocal = 2
	}

	public enum Positioning
	{
		CameraPosition = 0,
		WaterLevel = 1,
		InvertedWaterLevel = 2,
		InvertedGroundLevel = 3
	}

	private const float DEG_2_HOURS = 1f / 15f;

	private const float TIME_PASSED_FORCE_UPDATE_MINUTES = 1f;

	private const float TIME_PASSED_FORCE_UPDATE_HOUR = 1f / 60f;

	[SerializeField]
	private float updateTime = 0.05f;

	[SerializeField]
	private float distanceThresholdSquared = 2f;

	[SerializeField]
	private ReflectionProbeTimeSlicingMode timeSliceMode;

	[Header("Behavior")]
	public ProbeType probeType;

	public string assignShaderTexture = "";

	public bool assignAsSkybox;

	public Positioning positioning;

	[Header("Crossfade")]
	public bool crossfadeEnabled = true;

	public float speedMultiplier = 0.1f;

	public float timeMultiplier = 0.2f;

	public float fadePower = 5f;

	public bool doBlur = true;

	[Header("Tunnel")]
	public ReflectionProbe tunnelProbe;

	public Vector3 tunnelProbeSize = new Vector3(200f, 30f, 200f);

	public float tunnelBlendDistance = 10f;

	private ReflectionProbe renderProbe;

	private RenderTexture cubemap;

	private Vector4 hdrValues = Vector4.one;

	private int renderId = -1;

	private int currentProbe;

	private float lastUpdateTime;

	private Vector2 probePositionXZ;

	private WeatherPresetManager presetManager;

	private Coroutine updatePositionCoro;

	private ReflectionProbe mainProbe;

	private Cubemap[] tempCubemap;

	private float crossfade;

	private bool fading;

	private bool skipFade;

	private bool optionsSet;

	private Vector3 lastCameraPosition = Vector3.zero;

	private static readonly Color clearColorAllBlack = new Color(0f, 0f, 0f, 0f);

	private Material m_BlitCubemapMaterial;

	private Material skyboxMaterial;

	private CommandBuffer commandBuffer;

	private static readonly int sp_Tex = Shader.PropertyToID("_Tex");

	private static readonly int sp_MainTex = Shader.PropertyToID("_MainTex");

	private static readonly int sp_Over = Shader.PropertyToID("_Over");

	private static readonly int sp_Alpha = Shader.PropertyToID("_Alpha");

	private static readonly int sp_faceIndex = Shader.PropertyToID("_faceIndex");

	private static readonly int sp_ClipY = Shader.PropertyToID("_ReflectionClipY");

	private int sp_AssignedTexture;

	private int sp_AssignedTexture_HDR;

	private RaycastHit[] hits = new RaycastHit[8];

	private int raycastMask;

	public bool WantsToUpdate { get; private set; }

	public bool IsReady => optionsSet;

	public bool IsRendering => renderId >= 0;

	public ReflectionProbe Probe
	{
		get
		{
			if (!IsFullRate)
			{
				return mainProbe;
			}
			return renderProbe;
		}
	}

	public bool CompletedFirstRender { get; private set; }

	public bool IsFullRate => timeSliceMode == ReflectionProbeTimeSlicingMode.NoTimeSlicing;

	private void Start()
	{
		raycastMask = LayerMask.GetMask("Terrain");
		mainProbe = GetComponent<ReflectionProbe>();
		commandBuffer = new CommandBuffer();
		commandBuffer.name = "DV Environment probe blitter";
		sp_AssignedTexture = Shader.PropertyToID(assignShaderTexture);
		sp_AssignedTexture_HDR = Shader.PropertyToID(assignShaderTexture + "_HDR");
		List<ReflectionProbe> list = new List<ReflectionProbe>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			ReflectionProbe component = base.transform.GetChild(i).GetComponent<ReflectionProbe>();
			if ((bool)component && component != tunnelProbe)
			{
				list.Add(component);
			}
		}
		if (list.Count != 1)
		{
			Debug.LogError("'DynamicReflectionProbe' needs to have exactly 1 child ReflectionProbe. Destroying self.", base.transform);
			Object.Destroy(this);
			return;
		}
		renderProbe = list[0];
		presetManager = SingletonBehaviour<WeatherDriver>.Instance.manager;
		if (presetManager == null)
		{
			Debug.LogWarning("Weather Preset Manager missing, probe will not update based on sky dome time.");
		}
		else
		{
			presetManager.TimeJump += OnTimeJump;
		}
		base.transform.SetParent(WorldMover.OriginShiftParent, worldPositionStays: true);
		RenderSettings.defaultReflectionMode = DefaultReflectionMode.Custom;
		CreateCubemaps();
		m_BlitCubemapMaterial = CreateEngineMaterial(Shader.Find(doBlur ? "Hidden/BlitCubemap" : "Hidden/BlitCubemap (no blur)"));
		if (PlayerManager.ActiveCamera != null)
		{
			lastCameraPosition = PlayerManager.ActiveCamera.transform.position;
		}
		if (assignAsSkybox)
		{
			skyboxMaterial = new Material(Shader.Find("Skybox/Cubemap"));
			skyboxMaterial.hideFlags = HideFlags.HideAndDontSave;
			skyboxMaterial.name = "DV Terrain Skybox";
			skyboxMaterial.SetTexture(sp_Tex, cubemap);
		}
		SingletonBehaviour<ReflectionProbeScheduler>.Instance.RegisterProbe(this);
		WantsToUpdate = true;
	}

	private void OnTimeJump()
	{
		WantsToUpdate = true;
	}

	public static Material CreateEngineMaterial(Shader shader)
	{
		if (shader == null)
		{
			Debug.LogError("Cannot create required material because shader is null");
			return null;
		}
		return new Material(shader)
		{
			hideFlags = HideFlags.HideAndDontSave
		};
	}

	public static void ClearRenderTarget(CommandBuffer cmd, CameraClearFlags clearFlag, Color clearColor)
	{
		if (clearFlag != CameraClearFlags.Nothing)
		{
			cmd.ClearRenderTarget((clearFlag & CameraClearFlags.Depth) != 0, (clearFlag & CameraClearFlags.Color) != 0, clearColor);
		}
	}

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, CameraClearFlags clearFlag, Color clearColor, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = 0)
	{
		cmd.SetRenderTarget(buffer, miplevel, cubemapFace, depthSlice);
		ClearRenderTarget(cmd, clearFlag, clearColor);
	}

	public static void SetRenderTarget(CommandBuffer cmd, RenderTargetIdentifier buffer, CameraClearFlags clearFlag = CameraClearFlags.Nothing, int miplevel = 0, CubemapFace cubemapFace = CubemapFace.Unknown, int depthSlice = 0)
	{
		SetRenderTarget(cmd, buffer, clearFlag, clearColorAllBlack, miplevel, cubemapFace, depthSlice);
	}

	private void BlitCubemap(CommandBuffer cmd, Cubemap source, Cubemap over, float alpha, RenderTexture dest)
	{
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		for (int i = 0; i < 6; i++)
		{
			SetRenderTarget(cmd, dest, CameraClearFlags.Nothing, 0, (CubemapFace)i);
			materialPropertyBlock.SetTexture(sp_MainTex, source);
			materialPropertyBlock.SetTexture(sp_Over, over);
			materialPropertyBlock.SetFloat(sp_Alpha, alpha);
			materialPropertyBlock.SetFloat(sp_faceIndex, i);
			cmd.DrawProcedural(Matrix4x4.identity, m_BlitCubemapMaterial, 0, MeshTopology.Triangles, 3, 1, materialPropertyBlock);
		}
		cmd.GenerateMips(dest);
	}

	private void CreateCubemaps()
	{
		if ((bool)cubemap)
		{
			cubemap.Release();
		}
		int num = ((renderProbe.texture != null) ? renderProbe.texture.width : renderProbe.resolution);
		cubemap = new RenderTexture(num, num, 16, RenderTextureFormat.ARGB32, 8);
		cubemap.dimension = TextureDimension.Cube;
		cubemap.format = RenderTextureFormat.ARGBHalf;
		cubemap.useMipMap = true;
		cubemap.autoGenerateMips = false;
		cubemap.Create();
		if (tempCubemap != null)
		{
			for (int i = 0; i < tempCubemap.Length; i++)
			{
				if ((bool)tempCubemap[i])
				{
					Object.Destroy(tempCubemap[i]);
					tempCubemap[i] = null;
				}
			}
		}
		else
		{
			tempCubemap = new Cubemap[2];
		}
		for (int j = 0; j < 2; j++)
		{
			tempCubemap[j] = new Cubemap(num, renderProbe.hdr ? TextureFormat.RGBAHalf : TextureFormat.RGBA32, mipChain: true);
		}
	}

	private void RerenderAllProbes()
	{
		Transform transform = ((PlayerManager.ActiveCamera != null) ? PlayerManager.ActiveCamera.transform : null);
		if (transform != null)
		{
			base.transform.position = GetProbePosition(transform.position);
		}
		ReflectionProbeTimeSlicingMode timeSlicingMode = renderProbe.timeSlicingMode;
		renderProbe.timeSlicingMode = ReflectionProbeTimeSlicingMode.NoTimeSlicing;
		renderProbe.RenderProbe();
		renderProbe.timeSlicingMode = timeSlicingMode;
		renderId = -1;
		if ((SystemInfo.copyTextureSupport & CopyTextureSupport.RTToTexture) == 0 || !(renderProbe.texture != null))
		{
			return;
		}
		if (renderProbe.texture.width != tempCubemap[0].width || renderProbe.texture.height != tempCubemap[0].height || renderProbe.texture.width != tempCubemap[1].width || renderProbe.texture.height != tempCubemap[1].height || renderProbe.texture.width != cubemap.width || renderProbe.texture.height != cubemap.height)
		{
			CreateCubemaps();
		}
		for (int i = 0; i < tempCubemap.Length; i++)
		{
			if (renderProbe.texture.width != tempCubemap[i].width)
			{
				Debug.LogError("Size mismatch [" + i + "]: " + renderProbe.texture.width + " vs " + tempCubemap[i].width, renderProbe);
			}
			else
			{
				Graphics.CopyTexture(renderProbe.texture, tempCubemap[i]);
			}
		}
	}

	private IEnumerator PostResolutionChangeRender()
	{
		yield return null;
		RerenderAllProbes();
		yield return null;
		if ((SystemInfo.copyTextureSupport & CopyTextureSupport.RTToTexture) != CopyTextureSupport.None && (bool)renderProbe.texture)
		{
			Graphics.CopyTexture(renderProbe.texture, tempCubemap[0]);
			Graphics.CopyTexture(renderProbe.texture, tempCubemap[1]);
		}
		crossfade = 0f;
		fading = false;
		commandBuffer.Clear();
		BlitCubemap(commandBuffer, tempCubemap[(currentProbe + 1) % 2], tempCubemap[currentProbe], crossfade, cubemap);
		Graphics.ExecuteCommandBuffer(commandBuffer);
		PropagateRenderResult();
		optionsSet = true;
	}

	public void SetOptions(ReflectionProbeClearFlags flags, int mask, int resolution, ReflectionProbeTimeSlicingMode mode)
	{
		renderProbe.backgroundColor = Color.black;
		renderProbe.clearFlags = flags;
		if ((bool)mainProbe)
		{
			mainProbe.backgroundColor = Color.black;
			mainProbe.clearFlags = flags;
		}
		renderProbe.cullingMask = mask;
		if ((bool)mainProbe)
		{
			mainProbe.cullingMask = mask;
		}
		if (renderProbe.resolution != resolution)
		{
			renderProbe.resolution = resolution;
			if (!IsFullRate)
			{
				renderProbe.enabled = true;
			}
			if ((bool)mainProbe)
			{
				mainProbe.resolution = resolution;
				mainProbe.enabled = !IsFullRate;
			}
			CreateCubemaps();
		}
		bool isFullRate = IsFullRate;
		timeSliceMode = mode;
		if (base.enabled && IsFullRate != isFullRate)
		{
			TurnProbeOff();
			TurnProbeOn();
		}
		if (!IsFullRate)
		{
			StartCoroutine(PostResolutionChangeRender());
		}
		else
		{
			optionsSet = true;
		}
	}

	private void PropagateRenderResult()
	{
		if ((bool)mainProbe)
		{
			mainProbe.customBakedTexture = cubemap;
			mainProbe.mode = ReflectionProbeMode.Custom;
		}
		if (!string.IsNullOrEmpty(assignShaderTexture))
		{
			Shader.SetGlobalTexture(sp_AssignedTexture, cubemap);
			Shader.SetGlobalVector(sp_AssignedTexture_HDR, hdrValues);
		}
		if (assignAsSkybox && (bool)skyboxMaterial)
		{
			skyboxMaterial.mainTexture = cubemap;
			skyboxMaterial.SetTexture(sp_Tex, cubemap);
			RenderSettings.skybox = skyboxMaterial;
		}
	}

	private void OnValidate()
	{
		sp_AssignedTexture = Shader.PropertyToID(assignShaderTexture);
	}

	private void LateUpdate()
	{
		if (tunnelProbe != null)
		{
			Camera camera = ((PlayerManager.ActiveCamera != null) ? PlayerManager.ActiveCamera : Camera.main);
			Vector3 position = ((camera != null) ? camera.transform.position : base.transform.position);
			if ((bool)SingletonBehaviour<TerrainHoleManager>.Instance && (bool)SingletonBehaviour<TerrainHoleManager>.Instance.ClosestHoleIgnoringVisibility)
			{
				Vector3 position2 = SingletonBehaviour<TerrainHoleManager>.Instance.ClosestHoleIgnoringVisibility.transform.InverseTransformPoint(position);
				ZoneDetector.GetValue(ZoneDetector.ZoneType.Tunnel, out var value);
				if (position2.sqrMagnitude < tunnelProbe.size.x * tunnelProbe.size.x || value > 0f)
				{
					float a = Vector3.Dot(position2.normalized, Vector3.forward);
					float magnitude = position2.magnitude;
					float value2 = Mathf.Max(Mathf.Clamp01(Mathf.Max(a, Mathf.Clamp01(2f - magnitude)) * 1.5f), value);
					value2 = Mathf.Clamp01(value2);
					if (position2.z < 0.5f && position2.z > -2f && Mathf.Abs(position2.x) < 2.5f && Mathf.Abs(position2.y) < 8f)
					{
						value2 = 1f;
					}
					if (value2 > 0.01f)
					{
						tunnelProbe.enabled = true;
						tunnelProbe.blendDistance = tunnelBlendDistance;
						tunnelProbe.size = new Vector3(tunnelProbeSize.x * value2, tunnelProbeSize.y, tunnelProbeSize.z * value2);
						Vector3 right = SingletonBehaviour<TerrainHoleManager>.Instance.ClosestHoleIgnoringVisibility.transform.right;
						Vector2 normalized = new Vector2(right.x, right.z).normalized;
						float num = Mathf.Max(Mathf.Abs(normalized.x), Mathf.Abs(normalized.y));
						float num2 = 1f / num;
						position2.z = Mathf.Min(((0f - tunnelProbe.size.x) * 0.5f - tunnelProbe.blendDistance * 0.5f) * num2, position2.z);
						tunnelProbe.transform.position = SingletonBehaviour<TerrainHoleManager>.Instance.ClosestHoleIgnoringVisibility.transform.TransformPoint(position2);
						tunnelProbe.intensity = RenderSettings.ambientSkyColor.grayscale;
					}
					else
					{
						tunnelProbe.enabled = false;
					}
				}
				else
				{
					tunnelProbe.enabled = false;
				}
			}
			else
			{
				tunnelProbe.enabled = false;
			}
		}
		if (IsFullRate)
		{
			Transform transform = ((PlayerManager.ActiveCamera != null) ? PlayerManager.ActiveCamera.transform : null);
			if (transform != null)
			{
				Vector3 probePosition = GetProbePosition(transform.position);
				base.transform.position = probePosition;
			}
			if (probeType != ProbeType.FullEnvironment)
			{
				Graphics.CopyTexture(renderProbe.texture, tempCubemap[0]);
				hdrValues = renderProbe.textureHDRDecodeValues;
				commandBuffer.Clear();
				BlitCubemap(commandBuffer, tempCubemap[0], tempCubemap[0], 0f, cubemap);
				Graphics.ExecuteCommandBuffer(commandBuffer);
				PropagateRenderResult();
			}
			else if (PlayerManager.ActiveCamera != null)
			{
				Shader.SetGlobalFloat(sp_ClipY, (PlayerManager.ActiveCamera.transform.position.y + base.transform.position.y) * 0.5f);
			}
			return;
		}
		float num3 = 0f;
		if (PlayerManager.ActiveCamera != null)
		{
			Vector3 position3 = PlayerManager.ActiveCamera.transform.position;
			num3 = Vector3.Distance(position3, lastCameraPosition);
			lastCameraPosition = position3;
		}
		if (fading)
		{
			if (!crossfadeEnabled)
			{
				crossfade = 1f;
			}
			crossfade += num3 * speedMultiplier + Time.deltaTime * timeMultiplier;
			if (skipFade || crossfade > 1f)
			{
				crossfade = 1f;
				fading = false;
				skipFade = false;
			}
			commandBuffer.Clear();
			BlitCubemap(commandBuffer, tempCubemap[(currentProbe + 1) % 2], tempCubemap[currentProbe], crossfade, cubemap);
			Graphics.ExecuteCommandBuffer(commandBuffer);
			PropagateRenderResult();
		}
		if (renderId == -1 || !renderProbe.IsFinishedRendering(renderId))
		{
			return;
		}
		if ((SystemInfo.copyTextureSupport & CopyTextureSupport.RTToTexture) != CopyTextureSupport.None && renderProbe.texture != null)
		{
			if (renderProbe.texture.width != tempCubemap[0].width || renderProbe.texture.height != tempCubemap[0].height || renderProbe.texture.width != tempCubemap[1].width || renderProbe.texture.height != tempCubemap[1].height || renderProbe.texture.width != cubemap.width || renderProbe.texture.height != cubemap.height)
			{
				CreateCubemaps();
			}
			hdrValues = renderProbe.textureHDRDecodeValues;
			if (renderProbe.texture.width != tempCubemap[currentProbe].width)
			{
				Debug.LogError("Size mismatch [" + currentProbe + "]: " + renderProbe.texture.width + " vs " + tempCubemap[currentProbe].width, renderProbe);
			}
			else
			{
				Graphics.CopyTexture(renderProbe.texture, tempCubemap[currentProbe]);
			}
		}
		crossfade = 0f;
		fading = true;
		renderId = -1;
		if (!CompletedFirstRender || !crossfadeEnabled)
		{
			skipFade = true;
			CompletedFirstRender = true;
		}
	}

	public void TurnProbeOn()
	{
		if ((bool)mainProbe)
		{
			mainProbe.enabled = true;
		}
		base.transform.SetParent(WorldMover.OriginShiftParent, worldPositionStays: true);
		renderProbe.mode = ReflectionProbeMode.Realtime;
		renderProbe.refreshMode = ReflectionProbeRefreshMode.ViaScripting;
		renderProbe.timeSlicingMode = timeSliceMode;
		if (IsFullRate)
		{
			renderProbe.refreshMode = ReflectionProbeRefreshMode.EveryFrame;
			if (probeType == ProbeType.FullEnvironment)
			{
				renderProbe.importance = 1;
				renderProbe.size = new Vector3(20000f, 2000f, 20000f);
				renderProbe.enabled = true;
				if ((bool)mainProbe)
				{
					mainProbe.enabled = false;
				}
			}
		}
		else
		{
			renderProbe.refreshMode = ReflectionProbeRefreshMode.ViaScripting;
			renderProbe.importance = 0;
			renderProbe.size = Vector3.zero;
			renderProbe.enabled = true;
			if ((bool)mainProbe)
			{
				mainProbe.enabled = true;
			}
		}
		if (!WantsToUpdate)
		{
			UpdateReflectionProbe(forced: true);
		}
		if (updatePositionCoro != null)
		{
			StopCoroutine(updatePositionCoro);
		}
		if (!IsFullRate)
		{
			updatePositionCoro = StartCoroutine(UpdateReflectionProbeRealTime());
		}
	}

	public void TurnProbeOff()
	{
		if ((bool)mainProbe)
		{
			mainProbe.enabled = false;
		}
		base.transform.SetParent(null, worldPositionStays: true);
		renderProbe.mode = ReflectionProbeMode.Custom;
		if (IsFullRate)
		{
			renderProbe.refreshMode = ReflectionProbeRefreshMode.ViaScripting;
		}
		if (updatePositionCoro != null)
		{
			StopCoroutine(updatePositionCoro);
		}
		updatePositionCoro = null;
	}

	private IEnumerator UpdateReflectionProbeRealTime()
	{
		while (true)
		{
			yield return WaitFor.Seconds(updateTime);
			UpdateReflectionProbe(forced: false);
		}
	}

	private void UpdateReflectionProbe(bool forced)
	{
		if (!IsFullRate && !IsRendering && (!fading || forced))
		{
			if (forced)
			{
				DispatchRender(forced);
			}
			else
			{
				WantsToUpdate = true;
			}
		}
	}

	private Vector3 GetProbePosition(Vector3 refPos)
	{
		if (positioning == Positioning.WaterLevel)
		{
			float num = ((SingletonBehaviour<LevelInfo>.Instance != null) ? (SingletonBehaviour<LevelInfo>.Instance.waterLevel + 0.1f) : refPos.y);
			refPos.y = Mathf.Max(refPos.y, num);
			Vector3 result = refPos;
			if (Physics.RaycastNonAlloc(refPos, Vector3.down, hits, 50f, raycastMask) > 0)
			{
				float num2 = Mathf.Max(hits[0].point.y, num) - num;
				num2 = Mathf.InverseLerp(10f, 20f, num2) * num2;
				num += num2;
			}
			result.y -= (result.y - num) * 2f;
			return result;
		}
		if (positioning == Positioning.InvertedWaterLevel)
		{
			float num3 = Mathf.Min(refPos.y, (SingletonBehaviour<LevelInfo>.Instance != null) ? (SingletonBehaviour<LevelInfo>.Instance.waterLevel + 0.1f) : refPos.y);
			Vector3 result2 = refPos;
			result2.y = num3 - (refPos.y - num3);
			return result2;
		}
		if (positioning == Positioning.InvertedGroundLevel)
		{
			refPos.y = Mathf.Max(refPos.y, (SingletonBehaviour<LevelInfo>.Instance != null) ? (SingletonBehaviour<LevelInfo>.Instance.waterLevel + 0.1f) : refPos.y);
			Vector3 result3 = refPos;
			if (Physics.RaycastNonAlloc(refPos, Vector3.down, hits, 50f, raycastMask) > 0)
			{
				float y = hits[0].point.y;
				y = Mathf.Max(y, (SingletonBehaviour<LevelInfo>.Instance != null) ? (SingletonBehaviour<LevelInfo>.Instance.waterLevel + 0.1f) : y);
				result3.y = y - (result3.y - y);
			}
			return result3;
		}
		Vector3 result4 = refPos;
		result4.y = Mathf.Max(result4.y, (SingletonBehaviour<LevelInfo>.Instance != null) ? (SingletonBehaviour<LevelInfo>.Instance.waterLevel + 0.1f) : result4.y);
		return result4;
	}

	public void DispatchRender(bool forced = false)
	{
		if (IsFullRate)
		{
			return;
		}
		Transform transform = ((PlayerManager.ActiveCamera != null) ? PlayerManager.ActiveCamera.transform : null);
		if (!(transform != null))
		{
			return;
		}
		Vector3 probePosition = GetProbePosition(transform.position);
		float timeB = 0f;
		if (!presetManager)
		{
			presetManager = SingletonBehaviour<WeatherDriver>.Instance.manager;
		}
		else
		{
			timeB = presetManager.timeOfDay;
		}
		if (forced || (probePosition - base.transform.position).sqrMagnitude >= distanceThresholdSquared || GetDifferenceInHours(lastUpdateTime, timeB) > 1f)
		{
			currentProbe = (currentProbe + 1) % 2;
			base.transform.position = probePosition;
			lastUpdateTime = timeB;
			ReflectionProbeTimeSlicingMode timeSlicingMode = renderProbe.timeSlicingMode;
			renderProbe.timeSlicingMode = (forced ? ReflectionProbeTimeSlicingMode.NoTimeSlicing : timeSliceMode);
			renderId = renderProbe.RenderProbe();
			if (forced)
			{
				renderProbe.timeSlicingMode = timeSlicingMode;
			}
			WantsToUpdate = false;
		}
	}

	private float GetDifferenceInHours(float timeA, float timeB)
	{
		return Mathf.DeltaAngle(timeA * 360f, timeB * 360f) * (1f / 15f);
	}

	private void OnDestroy()
	{
		if ((bool)SingletonBehaviour<ReflectionProbeScheduler>.Instance)
		{
			SingletonBehaviour<ReflectionProbeScheduler>.Instance.UnregisterProbe(this);
		}
		if (tempCubemap != null)
		{
			for (int i = 0; i < tempCubemap.Length; i++)
			{
				Object.Destroy(tempCubemap[i]);
				tempCubemap[i] = null;
			}
			tempCubemap = null;
		}
		if (cubemap != null)
		{
			cubemap.Release();
			cubemap = null;
		}
		if (commandBuffer != null)
		{
			commandBuffer.Release();
			commandBuffer = null;
		}
		if ((bool)presetManager)
		{
			presetManager.TimeJump -= OnTimeJump;
		}
	}
}
