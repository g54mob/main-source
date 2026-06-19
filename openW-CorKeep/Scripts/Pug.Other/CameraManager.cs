using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Pug.RP;
using Pug.Sprite;
using Pug.UnityExtensions;
using QFSW.QC;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Scripting;

public class CameraManager : ManagerBase
{
	public enum CameraControlStyle
	{
		FollowPlayer = 0,
		Static = 1,
		ManualControl = 2
	}

	public enum CameraMovementStyle
	{
		Instant = 0,
		Smooth = 1
	}

	private class RenderAnchor
	{
		public Transform transform;

		public int refCount;

		public bool safe;
	}

	public const float MANUAL_CONTROL_SPEED = 12f;

	[Header("References")]
	public GameObject gameCameraParent;

	public Camera gameCamera;

	public Camera uiCamera;

	public Camera creditsCamera;

	public WaterSim waterSim;

	public CameraSceneFader gameCameraSceneFader;

	[Header("Settings")]
	public CameraMovementStyle cameraMovementStyle = CameraMovementStyle.Smooth;

	[Min(0f)]
	public float smoothedCameraLerpSpeed = 5f;

	[Min(0f)]
	public float smoothedCameraMinPixelSnap = 1f;

	[Min(0f)]
	public float smoothedCameraTeleportThreshold = 50f;

	[Header("Shaking")]
	public AnimationCurve defaultShakeCurveX = AnimationCurve.Linear(0f, 0f, 1f, 0f);

	public AnimationCurve defaultShakeCurveY = AnimationCurve.Linear(0f, 0f, 1f, 0f);

	public AnimationCurve singleShakeCurve = AnimationCurve.Linear(0f, 0f, 1f, 0f);

	[Header("Debugging")]
	public float cameraBoundsXMin = float.MinValue;

	public float cameraBoundsXMax = float.MaxValue;

	public float cameraBoundsZMin = float.MinValue;

	public float cameraBoundsZMax = float.MaxValue;

	public Vector3 manualControlTargetPosition = new Vector3(0f, 0f, 0f);

	[Space(10f)]
	public bool drawCameraGizmo = true;

	public bool moveOrigo = true;

	public bool drawInstancedSprites = true;

	public bool overridePugCameraParameters = true;

	[HideInInspector]
	public List<Vector3> backgroundCameraParentsInitialPositions = new List<Vector3>();

	public static Action CameraPositionUpdated = delegate
	{
	};

	public Action RenderOrigoUpdated;

	private Vector3 m_cameraTargetPosition;

	private Vector3 m_cameraCurrentPosition;

	private List<Transform> m_renderAnchorsOLD = new List<Transform> { null };

	private List<RenderAnchor> m_renderAnchors = new List<RenderAnchor>(16);

	private PugCamera m_gamePugCamera;

	private PugCamera m_uiPugCamera;

	private PugCamera m_creditsPugCamera;

	private TimerSimple m_zoomTimer = new TimerSimple(1f, false, false);

	private float m_zoom = 1f;

	private float m_startZoom = 1f;

	private float m_targetZoom = 1f;

	private float m_gameCameraParentY;

	private Vector3 m_smoothedCameraPositionPrev;

	private Vector3 m_smoothedCameraPosition;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("CameraManager.Init");

	private AnimationCurve currentShakeCurveX;

	private AnimationCurve currentShakeCurveY;

	private TimerSimple currentShakeTimer;

	private float currentShakeAmplitudeX = 1f;

	private float currentShakeAmplitudeY = 1f;

	private int currentShakePriority = -1;

	private float currentShakeIntensity = 1f;

	public PlayerController playerToFollow { get; set; }

	public CameraControlStyle currentCameraStyle { get; set; } = CameraControlStyle.Static;

	public Vector3Int RenderOrigo { get; private set; }

	public Transform VolatileRenderAnchor => m_renderAnchorsOLD.Last();

	public static float fixedTimeDelta => Mathf.Clamp01((float)(Time.timeAsDouble - Time.fixedTimeAsDouble) / Time.fixedDeltaTime);

	public Vector3 smoothedCameraPosition => Vector3.Lerp(m_smoothedCameraPositionPrev, m_smoothedCameraPosition, fixedTimeDelta);

	public Transform GetRenderAnchor()
	{
		RenderAnchor renderAnchor;
		for (int i = 0; i < m_renderAnchors.Count; i++)
		{
			renderAnchor = m_renderAnchors[i];
			if (renderAnchor.safe)
			{
				renderAnchor.refCount++;
				return renderAnchor.transform;
			}
		}
		GameObject gameObject = new GameObject($"__RenderAnchor_{m_renderAnchors.Count}");
		gameObject.hideFlags = HideFlags.DontSave;
		renderAnchor = new RenderAnchor
		{
			transform = gameObject.transform,
			refCount = 1,
			safe = true
		};
		m_renderAnchors.Add(renderAnchor);
		renderAnchor.transform.SetParent(base.transform);
		return renderAnchor.transform;
	}

	public void ReturnRenderAnchor(Transform anchor)
	{
		for (int i = 0; i < m_renderAnchors.Count; i++)
		{
			RenderAnchor renderAnchor = m_renderAnchors[i];
			if (renderAnchor.transform == anchor)
			{
				renderAnchor.refCount--;
				return;
			}
		}
		UnityEngine.Debug.LogError("Unable to return render anchor: Transform not found in anchor list!");
	}

	private void UpdateRenderAnchors()
	{
		for (int i = 0; i < m_renderAnchors.Count; i++)
		{
			RenderAnchor renderAnchor = m_renderAnchors[i];
			Vector3 position = renderAnchor.transform.position;
			renderAnchor.safe = position.x * position.x + position.z * position.z < 250000f;
			if (renderAnchor.refCount == 0)
			{
				renderAnchor.transform.position = Vector3.zero;
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		m_gamePugCamera = gameCamera.GetPugCamera();
		m_uiPugCamera = uiCamera.GetPugCamera();
		m_creditsPugCamera = creditsCamera.GetPugCamera();
	}

	public void Zoom(float startZoom = 1f, float targetZoom = 0.5f, float lifespan = 1f)
	{
		m_startZoom = startZoom;
		m_targetZoom = targetZoom;
		if (lifespan <= 0f)
		{
			m_zoomTimer.Stop();
			m_zoom = targetZoom;
		}
		else
		{
			m_zoomTimer.Start(lifespan);
		}
	}

	protected override void Start()
	{
		base.Start();
		gameCamera.transform.eulerAngles = new Vector3(45f, 0f, 0f);
		m_gameCameraParentY = gameCamera.transform.localPosition.y;
	}

	private void UpdateOrthographicSize()
	{
		int pixelHeight = m_gamePugCamera.GetPixelHeight();
		gameCamera.orthographicSize = m_zoom * 0.5f * ((float)pixelHeight / 16f);
	}

	public bool IsPointInViewport(Vector3 p, float epsilon = 0f)
	{
		return gameCamera.IsWorldPointInOrthoViewport(p, epsilon);
	}

	public float DistanceToCenterOfViewport(Vector2 p)
	{
		return Vector2.Distance(p, gameCamera.transform.Position2D());
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			currentShakeTimer = new TimerSimple(1f, false, false);
			m_renderAnchorsOLD.Clear();
			m_renderAnchorsOLD.Add(new GameObject($"RenderAnchorOLD_{m_renderAnchorsOLD.Count}").transform);
			m_renderAnchorsOLD[0].SetParent(base.transform);
			UpdateDynamicWaterSetting();
			return true;
		}
	}

	public void OnSceneUnload()
	{
		m_zoom = 1f;
		m_zoomTimer.Stop();
		ShowHUD(show: true);
	}

	public void ShowHUD(bool show)
	{
		if (show)
		{
			uiCamera.cullingMask |= 1 << ObjectLayerID.HUD;
		}
		else
		{
			uiCamera.cullingMask &= ~(1 << ObjectLayerID.HUD);
		}
	}

	public void UpdateSceneHandler(SceneHandler newSceneHandler)
	{
		ApplyCameraPosition(Vector3.zero);
		UpdateRenderOrigo();
		currentCameraStyle = ((!Manager.sceneHandler.isInGame) ? CameraControlStyle.Static : CameraControlStyle.FollowPlayer);
		manualControlTargetPosition = (m_cameraTargetPosition = GetCameraCurrentPosition());
	}

	private void UpdateRenderAnchorsOLD(Vector3Int newRenderOrigo)
	{
		foreach (Transform item in m_renderAnchorsOLD)
		{
			item.position -= (Vector3)(newRenderOrigo - RenderOrigo);
		}
		if (VolatileRenderAnchor.localPosition.sqrMagnitude > 10000f)
		{
			int count = m_renderAnchorsOLD.Count;
			m_renderAnchorsOLD.Add(new GameObject($"RenderAnchorOLD_{m_renderAnchorsOLD.Count}").transform);
			m_renderAnchorsOLD[count].SetParent(base.transform);
			m_renderAnchorsOLD[count].localPosition = Vector3.zero;
		}
		for (int num = m_renderAnchorsOLD.Count - 2; num >= 0; num--)
		{
			if (m_renderAnchorsOLD[num].localPosition.sqrMagnitude > 90000f)
			{
				foreach (Transform item2 in m_renderAnchorsOLD[num])
				{
					item2.SetParent(VolatileRenderAnchor, worldPositionStays: true);
				}
			}
		}
		for (int num2 = m_renderAnchorsOLD.Count - 2; num2 >= 0; num2--)
		{
			if (m_renderAnchorsOLD[num2].childCount == 0)
			{
				UnityEngine.Object.Destroy(m_renderAnchorsOLD[num2].gameObject);
				m_renderAnchorsOLD.RemoveAt(num2);
			}
		}
	}

	public void MoveRenderAnchors(Vector3Int origoDelta)
	{
		for (int i = 0; i < m_renderAnchors.Count; i++)
		{
			RenderAnchor renderAnchor = m_renderAnchors[i];
			if (renderAnchor.refCount > 0)
			{
				renderAnchor.transform.position -= new Vector3(origoDelta.x, 0f, origoDelta.z);
			}
		}
	}

	[Preserve]
	[Conditional("UNITY_EDITOR")]
	[Conditional("FORCE_DEBUG_MODE")]
	[Conditional("PUG_MARKETING_BUILD")]
	[Command("moveOrigo", "Set whether render origo should be moved with player.", QFSW.QC.Platform.AllPlatforms, MonoTargetType.Single, 0u)]
	public void SetMoveOrigo(bool trueOrFalse)
	{
		moveOrigo = trueOrFalse;
	}

	public void UpdateRenderOrigo()
	{
		Vector3Int vector3Int = (moveOrigo ? m_cameraCurrentPosition.RoundToInt() : Vector3Int.zero);
		if (vector3Int != RenderOrigo)
		{
			UpdateRenderAnchorsOLD(vector3Int);
			MoveRenderAnchors(vector3Int - RenderOrigo);
			RenderOrigo = vector3Int;
			PugRP.origin = RenderOrigo;
			RenderOrigoUpdated?.Invoke();
		}
	}

	public void FollowNextPlayer()
	{
		int i;
		for (i = 0; i < Manager.main.allPlayers.Count && !(playerToFollow == Manager.main.allPlayers[i]); i++)
		{
		}
		i = (i + 1) % Manager.main.allPlayers.Count;
		if (i < Manager.main.allPlayers.Count)
		{
			playerToFollow = Manager.main.allPlayers[i];
		}
		if (Vector3.Distance(playerToFollow.SmoothWorldPosition, m_cameraTargetPosition) > 20f)
		{
			ApplyCameraPosition(playerToFollow.WorldPosition);
		}
	}

	private void ApplyCameraPosition(Vector3 position)
	{
		m_cameraCurrentPosition = position;
		position -= (Vector3)RenderOrigo;
		position += Vector3.back * m_gameCameraParentY;
		if (Manager.sceneHandler != null)
		{
			Vector2 cameraShakeOffset = GetCameraShakeOffset();
			gameCameraParent.transform.position = new Vector3(position.x + cameraShakeOffset.x, 0f, position.z + cameraShakeOffset.y);
		}
		CameraPositionUpdated?.Invoke();
	}

	public Vector3 GetCameraCurrentPosition()
	{
		return m_cameraCurrentPosition;
	}

	private void SetCameraTargetPosition(Vector3 position)
	{
		m_cameraTargetPosition = position;
	}

	public Vector3 GetCameraTargetPosition()
	{
		return m_cameraTargetPosition;
	}

	private void Update()
	{
		UpdateGameAndUICameras(0f);
	}

	private void FixedUpdate()
	{
		float num = Mathf.Abs(m_smoothedCameraPosition.x - m_cameraTargetPosition.x);
		float num2 = Mathf.Abs(m_smoothedCameraPosition.z - m_cameraTargetPosition.z);
		if (Mathf.Sqrt(num * num + num2 * num2) > smoothedCameraTeleportThreshold)
		{
			ResetCameraSmoothing();
			return;
		}
		m_smoothedCameraPositionPrev = m_smoothedCameraPosition;
		float num3 = m_smoothedCameraPosition.x;
		float num4 = m_smoothedCameraPosition.z;
		if (!m_gamePugCamera.integerScaling || num > 0.0625f * smoothedCameraMinPixelSnap)
		{
			num3 = Mathf.Lerp(num3, m_cameraTargetPosition.x, Time.fixedDeltaTime * smoothedCameraLerpSpeed);
		}
		if (!m_gamePugCamera.integerScaling || num2 > 0.0625f * smoothedCameraMinPixelSnap)
		{
			num4 = Mathf.Lerp(num4, m_cameraTargetPosition.z, Time.fixedDeltaTime * smoothedCameraLerpSpeed);
		}
		m_smoothedCameraPosition = new Vector3(num3, m_smoothedCameraPosition.y, num4);
	}

	private void ResetCameraSmoothing()
	{
		m_smoothedCameraPositionPrev = (m_smoothedCameraPosition = m_cameraTargetPosition);
	}

	public void LateUpdate()
	{
		if (Manager.ecs.ClientWorld == null)
		{
			CameraUpdate(Time.deltaTime);
		}
	}

	public void CameraUpdate(float deltaTime, bool shouldDraw = true)
	{
		if (m_zoomTimer.isRunning)
		{
			if (m_zoomTimer.isTimerElapsed)
			{
				m_zoom = m_targetZoom;
				m_zoomTimer.Stop();
			}
			else
			{
				m_zoom = Mathf.SmoothStep(m_startZoom, m_targetZoom, m_zoomTimer.elapsedRatio);
			}
		}
		UpdateOrthographicSize();
		UpdateGameAndUICameras(deltaTime);
		UpdateTonemappingGammaAndColorDepth();
		UpdateBloom();
		UpdateLightQuality();
		UpdateLightTracingSettings();
		UpdateReflectionsSetting();
		UpdateAmbientOcclusionSettings();
		UpdateCRTFilterSettings();
		UpdateDynamicWaterSetting();
		UpdateRenderAnchors();
		if (shouldDraw)
		{
			Draw();
		}
	}

	public void Draw()
	{
		if (drawInstancedSprites)
		{
			SpriteInstancingManager.UpdateAndDraw();
		}
	}

	private void UpdateTonemappingGammaAndColorDepth()
	{
		m_gamePugCamera.tonemap = !Manager.sceneHandler.isGameStartUpLoading;
		float outputGamma = 1f - Manager.prefs.brightness / 2f;
		m_gamePugCamera.outputGamma = outputGamma;
		m_uiPugCamera.outputGamma = outputGamma;
		m_creditsPugCamera.outputGamma = outputGamma;
		m_gamePugCamera.outputLimitColorBitDepth = Manager.sceneHandler.isInGame && Manager.prefs.colorRange > 0;
		m_gamePugCamera.ditherOutput = ((Manager.prefs.colorRange != 1) ? 1 : 0);
	}

	private void UpdateBloom()
	{
		if (Manager.sceneHandler.isInGame)
		{
			m_gamePugCamera.bloom = Manager.prefs.bloom > 0;
			m_gamePugCamera.bloomWidth = Manager.prefs.bloom * 2;
			m_gamePugCamera.bloomThreshold = 1.9f;
		}
		else if (Manager.sceneHandler.isTitle)
		{
			m_gamePugCamera.bloom = true;
			m_gamePugCamera.bloomWidth = 3f;
			m_gamePugCamera.bloomThreshold = 0.75f;
		}
		else
		{
			m_gamePugCamera.bloom = false;
		}
	}

	private void UpdateLightQuality()
	{
		Shadows.maxShadowUpdatesPerFrameOverride = 2 + Manager.prefs.lightQuality;
		m_gamePugCamera.lightTracingMaxSampleCount = 15 + Manager.prefs.lightQuality * 5;
		switch (Manager.prefs.lightQuality)
		{
		default:
			m_gamePugCamera.indirectLightBounceCount = 1;
			m_gamePugCamera.indirectLightHighPrecision = false;
			PugRP.asset.punctualShadowsType = ShadowsType.Raymap;
			PugRP.asset.shadowResolution = Pug.RP.ShadowResolution._128;
			PugRP.asset.raymarchedShadowQuality = 0.25f;
			PugRP.asset.raymarchedShadowMaxSampleCount = 64;
			break;
		case 1:
			m_gamePugCamera.indirectLightBounceCount = 1;
			m_gamePugCamera.indirectLightHighPrecision = false;
			PugRP.asset.punctualShadowsType = ShadowsType.Raymap;
			PugRP.asset.shadowResolution = Pug.RP.ShadowResolution._256;
			PugRP.asset.raymarchedShadowQuality = 0.5f;
			PugRP.asset.raymarchedShadowMaxSampleCount = 86;
			break;
		case 2:
			m_gamePugCamera.indirectLightBounceCount = 2;
			m_gamePugCamera.indirectLightHighPrecision = false;
			PugRP.asset.punctualShadowsType = ShadowsType.Raymarching;
			PugRP.asset.raymarchedShadowQuality = 0.75f;
			PugRP.asset.raymarchedShadowMaxSampleCount = 106;
			break;
		case 3:
			m_gamePugCamera.indirectLightBounceCount = 2;
			m_gamePugCamera.indirectLightHighPrecision = true;
			PugRP.asset.punctualShadowsType = ShadowsType.Raymarching;
			PugRP.asset.raymarchedShadowQuality = 1f;
			PugRP.asset.raymarchedShadowMaxSampleCount = 128;
			break;
		}
		m_gamePugCamera.enableAnalyticNormalEdges = Manager.prefs.lightQuality > 0;
		m_gamePugCamera.indirectLightSkipPasses = 1;
		m_gamePugCamera.indirectLightRadianceCascadeCount = 4;
		m_gamePugCamera.indirectLightInputBlur = 4;
	}

	private void UpdateLightTracingSettings()
	{
		int objectShadows = Manager.prefs.objectShadows;
		m_gamePugCamera.lightTracingShadows = objectShadows == 2;
		int cullingMask = m_gamePugCamera.camera.cullingMask;
		cullingMask = ((objectShadows == 1) ? (cullingMask | (1 << ObjectLayerID.GroundShadow)) : (cullingMask & ~(1 << ObjectLayerID.GroundShadow)));
		m_gamePugCamera.camera.cullingMask = cullingMask;
		m_gamePugCamera.lightTracingOcclusion = Manager.prefs.ssaoQuality > 0 || m_gamePugCamera.lightTracingShadows;
		if (PugRP.asset.highPerformanceLightMode)
		{
			m_gamePugCamera.lightTracing = false;
		}
		else
		{
			m_gamePugCamera.lightTracing = m_gamePugCamera.lightTracingShadows || m_gamePugCamera.lightTracingOcclusion || m_gamePugCamera.lightTracingTransmittance;
		}
	}

	private void UpdateReflectionsSetting()
	{
		m_gamePugCamera.reflections = (Manager.prefs.reflections ? ReflectionsType.Planar : ReflectionsType.None);
	}

	private void UpdateAmbientOcclusionSettings()
	{
		switch (Manager.prefs.ssaoQuality)
		{
		default:
			m_gamePugCamera.lightTracingOcclusion = true;
			m_gamePugCamera.enableSSAO = false;
			break;
		case 1:
			m_gamePugCamera.lightTracingOcclusion = false;
			m_gamePugCamera.enableSSAO = true;
			m_gamePugCamera.ssaoSettings.sampleCount = 16;
			m_gamePugCamera.ssaoSettings.radius = 0.5f;
			m_gamePugCamera.ssaoSettings.directionality = 0f;
			break;
		case 2:
			m_gamePugCamera.lightTracingOcclusion = false;
			m_gamePugCamera.enableSSAO = true;
			m_gamePugCamera.ssaoSettings.sampleCount = 32;
			m_gamePugCamera.ssaoSettings.radius = 1f;
			m_gamePugCamera.ssaoSettings.directionality = 0f;
			break;
		}
	}

	private void UpdateCRTFilterSettings()
	{
		CRTFilterMode crtFilter = (CRTFilterMode)Manager.prefs.crtFilter;
		m_gamePugCamera.crtFilterSettings.mode = crtFilter;
		m_uiPugCamera.crtFilterSettings.CopyFromOther(m_gamePugCamera.crtFilterSettings);
		m_creditsPugCamera.crtFilterSettings.CopyFromOther(m_gamePugCamera.crtFilterSettings);
	}

	private void UpdateDynamicWaterSetting()
	{
		switch (Manager.prefs.dynamicWater)
		{
		case 0:
			waterSim.enabled = false;
			Shader.EnableKeyword("DYNAMIC_WATER_DISABLED");
			break;
		case 1:
			waterSim.enabled = true;
			Shader.DisableKeyword("DYNAMIC_WATER_DISABLED");
			waterSim.texelSize = 0.125f;
			waterSim.resolution = new Vector2Int(384, 256);
			waterSim.speedMultiplier = 0.5f;
			waterSim.foamMultiplier = 0.25f;
			break;
		case 2:
			waterSim.enabled = true;
			Shader.DisableKeyword("DYNAMIC_WATER_DISABLED");
			waterSim.texelSize = 0.0625f;
			waterSim.resolution = new Vector2Int(768, 512);
			waterSim.speedMultiplier = 1f;
			waterSim.foamMultiplier = 1f;
			break;
		}
	}

	public void UpdateGameAndUICameras(float deltaTime)
	{
		if (Manager.main.currentSceneHandler == null)
		{
			return;
		}
		if (currentCameraStyle == CameraControlStyle.ManualControl)
		{
			float num = deltaTime * 12f;
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				num *= 3f;
			}
			Vector2 vector = Manager.input.singleplayerInputModule.GetInputAxisValue(PlayerInput.InputAxisType.CHARACTER_MOVEMENT_HORIZONTAL, PlayerInput.InputAxisType.CHARACTER_MOVEMENT_VERTICAL) * num;
			manualControlTargetPosition += new Vector3(vector.x, 0f, vector.y);
		}
		CameraControlStyle cameraControlStyle = currentCameraStyle;
		if (cameraControlStyle == CameraControlStyle.FollowPlayer || (uint)(cameraControlStyle - 1) > 1u)
		{
			if (playerToFollow == null || !playerToFollow.gameObject.activeSelf)
			{
				playerToFollow = Manager.main.player;
			}
			if (playerToFollow != null)
			{
				SetCameraTargetPosition(playerToFollow.GetEntityPosition());
			}
			else
			{
				SetCameraTargetPosition(Vector3.zero);
			}
		}
		else
		{
			SetCameraTargetPosition(manualControlTargetPosition);
		}
		CameraMovementStyle cameraMovementStyle = this.cameraMovementStyle;
		if (!Manager.sceneHandler.isInGame)
		{
			cameraMovementStyle = CameraMovementStyle.Instant;
		}
		if (cameraMovementStyle == CameraMovementStyle.Instant || cameraMovementStyle != CameraMovementStyle.Smooth)
		{
			ApplyCameraPosition(m_cameraTargetPosition);
			ResetCameraSmoothing();
		}
		else
		{
			ApplyCameraPosition(smoothedCameraPosition);
		}
		if (overridePugCameraParameters)
		{
			m_gamePugCamera.integerScaling = Manager.prefs.integerScaling;
			m_uiPugCamera.integerScaling = Manager.prefs.integerScaling;
			m_creditsPugCamera.integerScaling = Manager.prefs.integerScaling;
		}
	}

	public void SnapCameraToPlayer()
	{
		SetCameraTargetPosition(Manager.main.player.WorldPosition);
		ApplyCameraPosition(m_cameraTargetPosition);
	}

	public void ShakeCameraNow(float shakeTime = 0.1f, float shakeAmplitudeX = 1f, float shakeAmplitudeY = 1f, AnimationCurve shakeCurveX = null, AnimationCurve shakeCurveY = null, int priority = 0, float intensity = 1f)
	{
		if (Manager.main.player != null)
		{
			Manager.main.player.inputModule.RumbleNow(shakeTime, math.lerp(shakeAmplitudeX, shakeAmplitudeY, 0.5f) * intensity);
		}
		if ((!IsCameraShaking() || priority >= currentShakePriority) && (!(shakeAmplitudeX <= 0f) || !(shakeAmplitudeY <= 0f)))
		{
			currentShakePriority = priority;
			currentShakeCurveX = ((shakeCurveX == null) ? defaultShakeCurveX : shakeCurveX);
			currentShakeCurveY = ((shakeCurveY == null) ? defaultShakeCurveY : shakeCurveY);
			currentShakeAmplitudeX = shakeAmplitudeX;
			currentShakeAmplitudeY = shakeAmplitudeY;
			currentShakeIntensity = intensity;
			currentShakeTimer.Start(shakeTime);
		}
	}

	public bool IsCameraShaking()
	{
		if (currentShakeTimer.isRunning)
		{
			return !currentShakeTimer.isTimerElapsed;
		}
		return false;
	}

	private Vector2 GetCameraShakeOffset()
	{
		if (!IsCameraShaking() || !Manager.prefs.screenShakes)
		{
			return Vector2.zero;
		}
		float time = currentShakeTimer.elapsedRatio * currentShakeIntensity % 1f;
		float num = currentShakeCurveX.Evaluate(time);
		float num2 = currentShakeCurveY.Evaluate(time);
		float x = num * currentShakeAmplitudeX;
		num2 *= currentShakeAmplitudeY;
		return new Vector2(x, num2);
	}
}
