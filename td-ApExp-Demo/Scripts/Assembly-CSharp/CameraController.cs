using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
	public static CameraController Instance;

	[Header("Zoom")]
	[SerializeField]
	private float zoomedInSize = 1.15f;

	[SerializeField]
	private float zoomedOutSize = 1.5f;

	[SerializeField]
	private float maxCamDst = 0.2f;

	[Header("Shake")]
	[SerializeField]
	[Range(0f, 1f)]
	private float shakeDurationMult = 1f;

	[SerializeField]
	[Range(0f, 1f)]
	private float shakeIntensityMult = 1f;

	private Vector3 shakeOffset;

	[SerializeField]
	private GameObject cameraGroup;

	[SerializeField]
	private AnimationCurve shakeCurve;

	[Header("Hub Tween")]
	[SerializeField]
	private float hubStartZoom = 2.5f;

	[SerializeField]
	private float hubZoomDuration = 1f;

	[Header("Zoom Settings")]
	[SerializeField]
	private float MaxCameraZoomOffset = 2.5f;

	[SerializeField]
	private float CoopCameraZoomFactorInverse = 10f;

	[SerializeField]
	private float MaxCameraSize = 1.3f;

	[Header("Cameras")]
	[SerializeField]
	private Camera camMain;

	[SerializeField]
	private Camera camWorld;

	[SerializeField]
	private Camera camWeather;

	[SerializeField]
	private Camera camBloom;

	[SerializeField]
	private Camera camPP;

	[SerializeField]
	private Camera camWorldSpaceUI;

	private float cameraZoomOffset;

	private int shakeTweenId;

	private int zoomTweenId;

	private int lockOnModuleTweenId;

	[Header("RT Raw Images")]
	[SerializeField]
	private RawImage rawWorld;

	[SerializeField]
	private RawImage rawWeather;

	[SerializeField]
	private RawImage rawPP;

	[SerializeField]
	private RawImage rawBloom;

	[SerializeField]
	private RawImage rawUI;

	private List<Module> aimingModules;

	[NonSerialized]
	public bool BlockCameraMovement;

	private CameraZoomPosition currentZoomPosition;

	public bool IsShakeEnabled { get; set; }

	public List<Transform> Targets { get; set; }

	public float CameraDstMult { get; set; } = 1f;

	public float InteractCameraDstMult { get; set; } = 1f;

	public bool IsCameraFree { get; set; }

	private void Awake()
	{
		Instance = this;
		RenderTexture renderTexture = RTFactory.CreateRT(1920, 1080);
		RenderTexture renderTexture2 = RTFactory.CreateRT(1920, 1080);
		RenderTexture renderTexture3 = RTFactory.CreateRT(480, 270);
		RenderTexture renderTexture4 = RTFactory.CreateRT(480, 270);
		RenderTexture renderTexture5 = RTFactory.CreateRT(1920, 1080);
		renderTexture3.filterMode = FilterMode.Point;
		renderTexture4.filterMode = FilterMode.Point;
		camWorld.targetTexture = renderTexture;
		camWeather.targetTexture = renderTexture2;
		camPP.targetTexture = renderTexture3;
		camBloom.targetTexture = renderTexture4;
		camWorldSpaceUI.targetTexture = renderTexture5;
		rawWorld.texture = renderTexture;
		rawWeather.texture = renderTexture2;
		rawPP.texture = renderTexture3;
		rawBloom.texture = renderTexture4;
		rawUI.texture = renderTexture5;
		shakeOffset = Vector3.zero;
		aimingModules = new List<Module>();
	}

	private void Start()
	{
		Targets = new List<Transform>();
		Targets.Add(PlayerManager.Instance.Players[0].transform);
		GameManager.Instance.JourneyStarted += delegate
		{
			HandleJourneyStarted();
		};
		GameManager.Instance.JourneyContinued += delegate
		{
			HandleJourneyContinued();
		};
		MenuManager.Instance.MenuOpened += delegate
		{
			shakeOffset = Vector3.zero;
		};
	}

	private void Update()
	{
		if (!GameManager.Instance.IsJourneyStarted)
		{
			return;
		}
		SyncPPCam();
		if (Targets == null || Targets.Count == 0)
		{
			return;
		}
		if (PlayerManager.Instance.IsCoop)
		{
			Zoom(0.5f);
		}
		if (!PlayerManager.Instance.IsCoop && aimingModules.Count > 0)
		{
			ModuleShield component = aimingModules[0].GetComponent<ModuleShield>();
			if ((object)component != null)
			{
				base.transform.position = component.plate.transform.position + shakeOffset;
				goto IL_00b2;
			}
		}
		if (IsCameraFree)
		{
			FollowTargetFree();
		}
		else
		{
			FollowTargetDirectly();
		}
		goto IL_00b2;
		IL_00b2:
		UIManager.Instance.IndicatorsRt.anchoredPosition = new Vector3(base.transform.position.x * 100f - 60f, 0f, 0f);
	}

	private void OnDestroy()
	{
		PlayerManager.Instance.OnCoopEnded -= HandleCoopStopped;
		Module.OnModuleStartAiming -= HandleStartAiming;
		Module.OnModuleEndAiming += HandleEndAiming;
	}

	private void HandleJourneyStarted()
	{
		PlayerManager.Instance.OnCoopEnded += HandleCoopStopped;
		Module.OnModuleStartAiming += HandleStartAiming;
		Module.OnModuleEndAiming += HandleEndAiming;
	}

	private void HandleJourneyContinued()
	{
		PlayerManager.Instance.OnCoopEnded += HandleCoopStopped;
		Module.OnModuleStartAiming += HandleStartAiming;
		Module.OnModuleEndAiming += HandleEndAiming;
		Targets = PlayerManager.Instance.Players.Select((PlayerController p) => p.transform).ToList();
		ZoomIn();
	}

	private void HandleStartAiming(Module module)
	{
		aimingModules.Add(module);
	}

	private void HandleEndAiming(Module module)
	{
		aimingModules.Remove(module);
	}

	public Vector3 GetAvgPlayerPosition()
	{
		if (Targets == null || Targets.Count == 0)
		{
			return Vector3.zero;
		}
		Vector3 zero = Vector3.zero;
		foreach (Transform target in Targets)
		{
			zero += target.position;
		}
		return zero / Targets.Count;
	}

	public float GetAvgPlayerDistance()
	{
		if (Targets == null || Targets.Count <= 1)
		{
			return 0f;
		}
		float num = 0f;
		for (int i = 0; i < Targets.Count - 1; i++)
		{
			for (int j = i + 1; j < Targets.Count; j++)
			{
				num += Vector3.Distance(Targets[i].position, Targets[j].position);
			}
		}
		return num / (float)(Targets.Count * (Targets.Count - 1) / 2);
	}

	private void SyncPPCam()
	{
		camPP.orthographicSize = camWorld.orthographicSize;
	}

	private bool IsInStartingHub()
	{
		if (LevelManager.Instance.IsAtDestination)
		{
			return LevelManager.Instance.LevelHistory.Count == 1;
		}
		return false;
	}

	private void FollowTargetDirectly()
	{
		if (!BlockCameraMovement)
		{
			if (MenuManager.Instance.CurrentMenu == null)
			{
				base.transform.position = GetAvgPlayerPosition() + shakeOffset;
			}
			else
			{
				base.transform.position = base.transform.position + shakeOffset;
			}
		}
	}

	private void FollowTargetLocked()
	{
		Vector3 avgPlayerPosition = GetAvgPlayerPosition();
		avgPlayerPosition.x = Mathf.Clamp(avgPlayerPosition.x, 0f - maxCamDst + avgPlayerPosition.x, maxCamDst + avgPlayerPosition.x);
		avgPlayerPosition.y = 0f;
		if (MenuManager.Instance.CurrentMenu == null)
		{
			base.transform.position = avgPlayerPosition + shakeOffset;
		}
		else
		{
			base.transform.position = base.transform.position + shakeOffset;
		}
	}

	private void SetPositionToAimingModule()
	{
		LeanTween.cancel(base.gameObject, zoomTweenId);
		zoomTweenId = LeanTween.value(base.gameObject, camWorld.orthographicSize, zoomedOutSize, 0.2f).setOnUpdate(delegate(float size)
		{
			camMain.orthographicSize = size;
			camWorld.orthographicSize = size;
			camWeather.orthographicSize = size;
			camPP.orthographicSize = size;
			camBloom.orthographicSize = size;
			camWorldSpaceUI.orthographicSize = size;
		}).setEase(LeanTweenType.easeOutQuad)
			.id;
		LeanTween.cancel(lockOnModuleTweenId);
		lockOnModuleTweenId = LeanTween.value(base.gameObject, camWorld.transform.position, aimingModules[0].transform.position, 0.2f).setOnUpdate(delegate(Vector2 pos)
		{
			base.gameObject.transform.position = pos;
		}).setEase(LeanTweenType.easeOutQuad)
			.id;
	}

	public void SetPosition(Vector3 pos)
	{
		base.transform.position = pos;
	}

	private void FollowTargetFree()
	{
		if (!BlockCameraMovement)
		{
			Vector3 vector = camWorld.ScreenToWorldPoint(Mouse.current.position.ReadValue());
			vector.z = base.transform.position.z;
			Vector3 avgPlayerPosition = GetAvgPlayerPosition();
			Vector3 vector2 = avgPlayerPosition + (vector - avgPlayerPosition) / 12f;
			if (MenuManager.Instance.CurrentMenu == null)
			{
				base.transform.position = new Vector3(Mathf.Clamp(vector2.x, avgPlayerPosition.x - maxCamDst, avgPlayerPosition.x + maxCamDst), Mathf.Clamp(vector2.y, avgPlayerPosition.y - maxCamDst, avgPlayerPosition.y + maxCamDst), base.transform.position.z) + shakeOffset;
			}
			else
			{
				base.transform.position = base.transform.position + shakeOffset;
			}
		}
	}

	public void ZoomIn()
	{
		currentZoomPosition = CameraZoomPosition.ZoomedIn;
		Zoom(0.5f, zoomedInSize);
	}

	public void ZoomOut()
	{
		currentZoomPosition = CameraZoomPosition.ZoomedOut;
		Zoom(0.5f, zoomedOutSize * CameraDstMult);
	}

	public void InteractionZoomOut()
	{
		currentZoomPosition = CameraZoomPosition.InteractionZoomedOut;
		Zoom(0.5f, zoomedOutSize * CameraDstMult * InteractCameraDstMult);
	}

	private void Zoom(float duration, float setSize = -1f)
	{
		float num = zoomedInSize;
		if (setSize > 0f)
		{
			num = setSize;
		}
		if (PlayerManager.Instance.IsCoop)
		{
			cameraZoomOffset = Mathf.Lerp(0f, MaxCameraZoomOffset, GetAvgPlayerDistance() / CoopCameraZoomFactorInverse);
			switch (currentZoomPosition)
			{
			case CameraZoomPosition.ZoomedIn:
				num = zoomedInSize + cameraZoomOffset;
				break;
			case CameraZoomPosition.ZoomedOut:
				num = zoomedOutSize * CameraDstMult + cameraZoomOffset;
				break;
			case CameraZoomPosition.InteractionZoomedOut:
				num = zoomedOutSize * CameraDstMult * InteractCameraDstMult + cameraZoomOffset;
				break;
			}
			num = Mathf.Clamp(num, zoomedInSize + cameraZoomOffset, MaxCameraSize);
		}
		LeanTween.cancel(base.gameObject, zoomTweenId);
		zoomTweenId = LeanTween.value(base.gameObject, camWorld.orthographicSize, num, duration).setOnUpdate(delegate(float size)
		{
			camMain.orthographicSize = size;
			camWorld.orthographicSize = size;
			camWeather.orthographicSize = size;
			camPP.orthographicSize = size;
			camBloom.orthographicSize = size;
			camWorldSpaceUI.orthographicSize = size;
		}).setEase(LeanTweenType.easeOutQuad)
			.id;
	}

	private void HandleCoopStopped(PlayerController pc)
	{
		switch (currentZoomPosition)
		{
		case CameraZoomPosition.ZoomedIn:
			ZoomIn();
			break;
		case CameraZoomPosition.ZoomedOut:
			ZoomOut();
			break;
		case CameraZoomPosition.InteractionZoomedOut:
			InteractionZoomOut();
			break;
		}
	}

	public void Shake(float duration, float intensity, bool force = false)
	{
		LeanTween.cancel(cameraGroup, shakeTweenId);
		if (force || IsShakeEnabled)
		{
			shakeTweenId = LeanTween.value(cameraGroup, 0f, 1f, duration * shakeDurationMult).setOnUpdate(delegate(float t)
			{
				float num = shakeCurve.Evaluate(t);
				float x = UnityEngine.Random.Range(-1f, 1f) * intensity * num * 0.1f * shakeIntensityMult;
				float y = UnityEngine.Random.Range(-1f, 1f) * intensity * num * 0.1f * shakeIntensityMult;
				shakeOffset = new Vector3(x, y, 0f);
			}).setOnComplete((Action)delegate
			{
				shakeOffset = Vector3.zero;
			})
				.setIgnoreTimeScale(useUnScaledTime: true)
				.id;
		}
	}

	public void EnterHubTween()
	{
		LeanTween.value(camWorld.gameObject, hubStartZoom, zoomedInSize, hubZoomDuration).setOnUpdate(delegate(float fov)
		{
			camMain.orthographicSize = fov;
			camWorld.orthographicSize = fov;
			camWeather.orthographicSize = fov;
			camPP.orthographicSize = fov;
			camBloom.orthographicSize = fov;
			camWorldSpaceUI.orthographicSize = fov;
		}).setEaseOutQuad();
	}
}
