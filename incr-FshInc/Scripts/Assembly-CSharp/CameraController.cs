using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraController : MonoBehaviour
{
	public static CameraController Instance;

	public Camera cam;

	private Vector3 initialPosition;

	private float initialSize;

	[Header("Accessibility Settings")]
	public bool enableScreenShake = true;

	public bool enableVisualEffects = true;

	public bool enableCameraZoom = true;

	[Header("Pixel Snapping")]
	public bool enablePixelSnap = true;

	public float pixelsPerUnit = 32f;

	[Header("Pan Settings")]
	public float panFactor = 0.04f;

	public float panDuration = 1f;

	[Header("Zoom Settings")]
	public float zoomInSize = 3f;

	public float zoomDuration = 0.5f;

	[Header("Shake Settings")]
	public float clickShakeDuration = 0.2f;

	public float clickShakeStrength = 0.2f;

	[Header("Reel-In Zoom")]
	public float incrementalZoomAmount = 0.05f;

	public float minZoomSize = 2f;

	[Header("Post-Processing FX")]
	public Volume postProcessVolume;

	public float clickChromaticPulse = 0.5f;

	public float clickVignettePulse = 0.45f;

	public float maxTensionVignette = 0.6f;

	private Vignette vignette;

	private ChromaticAberration chromaticAberration;

	private float initialVignetteIntensity;

	private float initialChromaticIntensity;

	private Transform trackingTarget;

	private Vector3 trackingVelocity = Vector3.zero;

	private void Awake()
	{
		Instance = this;
		cam = Camera.main;
		initialPosition = cam.transform.position;
		initialSize = cam.orthographicSize;
		enableScreenShake = PlayerPrefs.GetInt("Setting_Shake", 1) == 1;
		enableVisualEffects = PlayerPrefs.GetInt("Setting_VFX", 1) == 1;
		enableCameraZoom = PlayerPrefs.GetInt("Setting_Zoom", 1) == 1;
		if (postProcessVolume != null && postProcessVolume.profile != null)
		{
			postProcessVolume.profile.TryGet<Vignette>(out vignette);
			postProcessVolume.profile.TryGet<ChromaticAberration>(out chromaticAberration);
			if (vignette != null)
			{
				initialVignetteIntensity = vignette.intensity.value;
			}
			if (chromaticAberration != null)
			{
				initialChromaticIntensity = chromaticAberration.intensity.value;
			}
		}
	}

	public void PanTowards(Vector3 targetPosition)
	{
		trackingTarget = null;
		cam.transform.DOKill();
		Vector3 vector = targetPosition - initialPosition;
		vector.z = 0f;
		Vector3 endValue = initialPosition + vector * panFactor;
		endValue.z = initialPosition.z;
		cam.transform.DOMove(endValue, panDuration).SetEase(Ease.OutCubic);
	}

	public void ResetPan()
	{
		trackingTarget = null;
		cam.transform.DOKill();
		cam.transform.DOMove(initialPosition, panDuration).SetEase(Ease.OutCubic);
	}

	public void ZoomToTarget(Vector3 targetPosition)
	{
		trackingTarget = null;
		cam.transform.DOKill();
		cam.DOKill();
		ShortcutExtensions.DOMove(endValue: new Vector3(targetPosition.x, targetPosition.y, initialPosition.z), target: cam.transform, duration: zoomDuration).SetEase(Ease.OutCubic);
		if (enableCameraZoom)
		{
			cam.DOOrthoSize(zoomInSize, zoomDuration).SetEase(Ease.OutCubic);
		}
	}

	public void ResetZoom()
	{
		trackingTarget = null;
		cam.transform.DOKill();
		cam.DOKill();
		cam.transform.DOMove(initialPosition, zoomDuration).SetEase(Ease.OutCubic);
		cam.DOOrthoSize(initialSize, zoomDuration).SetEase(Ease.OutCubic);
		if (vignette != null)
		{
			vignette.intensity.value = initialVignetteIntensity;
		}
		if (chromaticAberration != null)
		{
			chromaticAberration.intensity.value = initialChromaticIntensity;
		}
	}

	public void TriggerShake()
	{
		if (enableScreenShake)
		{
			cam.DOShakePosition(clickShakeDuration, clickShakeStrength).SetId("CameraShake");
		}
	}

	public void IncrementalZoomIn()
	{
		if (enableCameraZoom && cam.orthographicSize > minZoomSize)
		{
			float a = cam.orthographicSize - incrementalZoomAmount;
			cam.DOOrthoSize(Mathf.Max(a, minZoomSize), 0.1f);
		}
	}

	public void SetZoomEnabled(bool isEnabled)
	{
		enableCameraZoom = isEnabled;
		if (!isEnabled)
		{
			cam.DOKill();
			cam.DOOrthoSize(initialSize, 0.2f);
		}
	}

	public void TriggerVisualPulse()
	{
		if (!enableVisualEffects)
		{
			return;
		}
		if (chromaticAberration != null)
		{
			DOTween.To(() => chromaticAberration.intensity.value, delegate(float x)
			{
				chromaticAberration.intensity.value = x;
			}, clickChromaticPulse, clickShakeDuration / 2f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutQuad);
		}
		if (vignette != null)
		{
			DOTween.To(() => vignette.intensity.value, delegate(float x)
			{
				vignette.intensity.value = x;
			}, clickVignettePulse, clickShakeDuration / 2f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.OutQuad);
		}
	}

	public void UpdateTensionVignette(float tension)
	{
		if (enableVisualEffects && vignette != null)
		{
			vignette.intensity.value = Mathf.Lerp(initialVignetteIntensity, maxTensionVignette, tension);
		}
	}

	public void SetShakeEnabled(bool isEnabled)
	{
		enableScreenShake = isEnabled;
		if (!isEnabled)
		{
			DOTween.Kill("CameraShake");
		}
	}

	public void SetVFXEnabled(bool isEnabled)
	{
		enableVisualEffects = isEnabled;
		if (!isEnabled)
		{
			ResetPostProcessing();
		}
	}

	private void ResetPostProcessing()
	{
		if (vignette != null)
		{
			DOTween.Kill(vignette.intensity);
			vignette.intensity.value = initialVignetteIntensity;
		}
		if (chromaticAberration != null)
		{
			DOTween.Kill(chromaticAberration.intensity);
			chromaticAberration.intensity.value = initialChromaticIntensity;
		}
	}

	private void LateUpdate()
	{
		if (trackingTarget != null)
		{
			Vector3 target = new Vector3(trackingTarget.position.x, trackingTarget.position.y, initialPosition.z);
			cam.transform.position = Vector3.SmoothDamp(cam.transform.position, target, ref trackingVelocity, zoomDuration * 0.5f);
		}
		if (enablePixelSnap)
		{
			Vector3 position = cam.transform.position;
			position.x = Mathf.Round(position.x * pixelsPerUnit) / pixelsPerUnit;
			position.y = Mathf.Round(position.y * pixelsPerUnit) / pixelsPerUnit;
			cam.transform.position = position;
		}
	}

	public void StartTrackingAndZoom(Transform target, float targetZoom = 3f)
	{
		trackingTarget = target;
		cam.transform.DOKill();
		cam.DOKill();
		if (enableCameraZoom)
		{
			cam.DOOrthoSize(targetZoom, zoomDuration).SetEase(Ease.OutCubic);
		}
	}
}
