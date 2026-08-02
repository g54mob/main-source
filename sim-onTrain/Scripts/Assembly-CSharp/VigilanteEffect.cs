using System.Collections;
using DG.Tweening;
using Mirror;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VigilanteEffect : MonoBehaviour
{
	[Header("Post Process Volume")]
	[SerializeField]
	private Volume postProcessVolume;

	[Header("Effect Settings")]
	[SerializeField]
	private float effectDuration = 3f;

	[SerializeField]
	private AnimationCurve intensityCurve = AnimationCurve.EaseInOut(0f, 1f, 1f, 0f);

	[SerializeField]
	private Color vignetteColor = Color.red;

	[SerializeField]
	private float maxVignetteIntensity = 0.6f;

	[SerializeField]
	private float maxColorAdjustmentSaturation = -80f;

	[SerializeField]
	private float maxColorAdjustmentContrast = 20f;

	[Header("Screen Shake")]
	[SerializeField]
	private bool enableScreenShake = true;

	[SerializeField]
	private float shakeIntensity = 0.3f;

	[SerializeField]
	private float shakeDuration = 1f;

	[SerializeField]
	private int shakeVibrato = 10;

	[Header("Audio")]
	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip vigilanteSound;

	[SerializeField]
	private float soundVolume = 0.7f;

	private Vignette vignette;

	private ColorAdjustments colorAdjustments;

	private ChromaticAberration chromaticAberration;

	private FilmGrain filmGrain;

	private float originalVignetteIntensity;

	private Color originalVignetteColor;

	private float originalSaturation;

	private float originalContrast;

	private float originalChromaticIntensity;

	private float originalFilmGrainIntensity;

	private bool isEffectActive;

	private Coroutine currentEffectCoroutine;

	public bool IsEffectActive => isEffectActive;

	private void Awake()
	{
		if (postProcessVolume != null)
		{
			Object.DontDestroyOnLoad(postProcessVolume.gameObject);
			Object.DontDestroyOnLoad(base.gameObject);
		}
		InitializePostProcessComponents();
		StoreOriginalValues();
		if (audioSource == null)
		{
			audioSource = base.gameObject.AddComponent<AudioSource>();
		}
		audioSource.playOnAwake = false;
		audioSource.volume = soundVolume;
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
		if (currentEffectCoroutine != null)
		{
			StopCoroutine(currentEffectCoroutine);
		}
		ResetEffect();
	}

	private void InitializePostProcessComponents()
	{
		if (postProcessVolume == null)
		{
			postProcessVolume = Object.FindObjectOfType<Volume>();
			if (postProcessVolume == null)
			{
				Debug.LogWarning("No Post Process Volume found! Creating one automatically.");
				CreatePostProcessVolume();
			}
		}
		VolumeProfile profile = postProcessVolume.profile;
		if (profile != null)
		{
			profile.TryGet<Vignette>(out vignette);
			profile.TryGet<ColorAdjustments>(out colorAdjustments);
			profile.TryGet<ChromaticAberration>(out chromaticAberration);
			profile.TryGet<FilmGrain>(out filmGrain);
			if (vignette == null)
			{
				vignette = profile.Add<Vignette>();
				vignette.active = false;
			}
			if (colorAdjustments == null)
			{
				colorAdjustments = profile.Add<ColorAdjustments>();
				colorAdjustments.active = false;
			}
			if (chromaticAberration == null)
			{
				chromaticAberration = profile.Add<ChromaticAberration>();
				chromaticAberration.active = false;
			}
			if (filmGrain == null)
			{
				filmGrain = profile.Add<FilmGrain>();
				filmGrain.active = false;
			}
		}
	}

	private void CreatePostProcessVolume()
	{
		GameObject gameObject = new GameObject("Vigilante Post Process Volume");
		postProcessVolume = gameObject.AddComponent<Volume>();
		postProcessVolume.isGlobal = true;
		VolumeProfile profile = ScriptableObject.CreateInstance<VolumeProfile>();
		postProcessVolume.profile = profile;
		Debug.Log("Created new Post Process Volume for Vigilante Effect");
	}

	private void StoreOriginalValues()
	{
		if (vignette != null)
		{
			originalVignetteIntensity = vignette.intensity.value;
			originalVignetteColor = vignette.color.value;
		}
		if (colorAdjustments != null)
		{
			originalSaturation = colorAdjustments.saturation.value;
			originalContrast = colorAdjustments.contrast.value;
		}
		if (chromaticAberration != null)
		{
			originalChromaticIntensity = chromaticAberration.intensity.value;
		}
		if (filmGrain != null)
		{
			originalFilmGrainIntensity = filmGrain.intensity.value;
		}
	}

	private void OnVigilanteEffectTriggered(uint playerId, float duration)
	{
		if (!(NetworkClient.localPlayer == null) && NetworkClient.localPlayer.netId == playerId)
		{
			Debug.Log($"Vigilante effect triggered for local player! Duration: {duration}");
			TriggerEffect(duration);
		}
	}

	public void TriggerEffect(float duration = 0f)
	{
		ResetEffect();
		StoreOriginalValues();
		if (duration <= 0f)
		{
			duration = effectDuration;
		}
		if (currentEffectCoroutine != null)
		{
			StopCoroutine(currentEffectCoroutine);
		}
		currentEffectCoroutine = StartCoroutine(PlayVigilanteEffect(duration));
	}

	private IEnumerator PlayVigilanteEffect(float duration)
	{
		Debug.Log("Starting Vigilante Effect...");
		isEffectActive = true;
		PlayVigilanteSound();
		if (enableScreenShake)
		{
			TriggerScreenShake();
		}
		EnablePostProcessComponents();
		float elapsedTime = 0f;
		while (elapsedTime < duration)
		{
			float time = elapsedTime / duration;
			float intensity = intensityCurve.Evaluate(time);
			ApplyEffectIntensity(intensity);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		ResetEffect();
		isEffectActive = false;
		Debug.Log("Vigilante Effect completed.");
	}

	private void EnablePostProcessComponents()
	{
		if (vignette != null)
		{
			vignette.active = true;
		}
		if (colorAdjustments != null)
		{
			colorAdjustments.active = true;
		}
		if (chromaticAberration != null)
		{
			chromaticAberration.active = true;
		}
		if (filmGrain != null)
		{
			filmGrain.active = true;
		}
	}

	private void ApplyEffectIntensity(float intensity)
	{
		if (vignette != null)
		{
			vignette.intensity.value = Mathf.Lerp(originalVignetteIntensity, maxVignetteIntensity, intensity);
			vignette.color.value = Color.Lerp(originalVignetteColor, vignetteColor, intensity);
		}
		if (colorAdjustments != null)
		{
			colorAdjustments.saturation.value = Mathf.Lerp(originalSaturation, maxColorAdjustmentSaturation, intensity);
			colorAdjustments.contrast.value = Mathf.Lerp(originalContrast, maxColorAdjustmentContrast, intensity);
		}
		if (chromaticAberration != null)
		{
			chromaticAberration.intensity.value = Mathf.Lerp(originalChromaticIntensity, 1f, intensity);
		}
		if (filmGrain != null)
		{
			filmGrain.intensity.value = Mathf.Lerp(originalFilmGrainIntensity, 0.6f, intensity);
		}
	}

	private void ResetEffect()
	{
		if (vignette != null)
		{
			vignette.intensity.value = originalVignetteIntensity;
			vignette.color.value = originalVignetteColor;
			vignette.active = false;
		}
		if (colorAdjustments != null)
		{
			colorAdjustments.saturation.value = originalSaturation;
			colorAdjustments.contrast.value = originalContrast;
			colorAdjustments.active = false;
		}
		if (chromaticAberration != null)
		{
			chromaticAberration.intensity.value = originalChromaticIntensity;
			chromaticAberration.active = false;
		}
		if (filmGrain != null)
		{
			filmGrain.intensity.value = originalFilmGrainIntensity;
			filmGrain.active = false;
		}
	}

	private void PlayVigilanteSound()
	{
		if (audioSource != null && vigilanteSound != null)
		{
			audioSource.clip = vigilanteSound;
			audioSource.Play();
		}
	}

	private void TriggerScreenShake()
	{
		Camera camera = Camera.main;
		if (camera == null)
		{
			camera = Object.FindObjectOfType<Camera>();
		}
		if (camera != null)
		{
			camera.transform.DOShakePosition(shakeDuration, shakeIntensity, shakeVibrato).SetEase(Ease.OutQuad);
		}
	}

	[ContextMenu("Test Vigilante Effect")]
	public void TestVigilanteEffect()
	{
		TriggerEffect();
	}

	[ContextMenu("Reset Effect")]
	public void ForceResetEffect()
	{
		if (currentEffectCoroutine != null)
		{
			StopCoroutine(currentEffectCoroutine);
			currentEffectCoroutine = null;
		}
		ResetEffect();
		isEffectActive = false;
	}

	public void SetEffectDuration(float duration)
	{
		effectDuration = duration;
	}

	public void SetVignetteColor(Color color)
	{
		vignetteColor = color;
	}

	public void SetMaxVignetteIntensity(float intensity)
	{
		maxVignetteIntensity = Mathf.Clamp01(intensity);
	}

	public void SetScreenShakeEnabled(bool enabled)
	{
		enableScreenShake = enabled;
	}
}
