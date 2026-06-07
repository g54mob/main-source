using System.Collections.Generic;
using DV.ThingTypes;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CargoEffects : MonoBehaviour, ICargoEffects
{
	[Header("Leak Related")]
	public GameObject leakRupture;

	[Header("Explosion Related")]
	public List<ParticleSystem> explosionParticleSystems;

	public List<AudioSource> explosionAudio;

	public Gradient explosionColorGradient;

	public float lightFadeTime = 1f;

	public float lightIntensityMax = 25f;

	[Range(0f, 0.99f)]
	public float maxLightReachTimeRatio = 0.059f;

	protected const string RUPTURE_PARENT_NAME = "LeakPositions";

	protected const float EXPLOSION_EFFECTS_DURATION = 5f;

	protected List<Transform> potentialLeakTransforms = new List<Transform>();

	private Vector3 DEFAULT_SOLID_EFFECTS_POSITION = new Vector3(0f, 1f, 0f);

	private Vector3 DEFAULT_FLUID_EFFECTS_POSITION = new Vector3(1f, 2f, 1f);

	private ICargoContent cargoContent;

	private Light explosionLight;

	private PostProcessVolume explosionPostProcessing;

	private bool lightUp;

	private float lightUpElapsedTime;

	private Transform lightOriginalParent;

	private Transform explosionPostProcessingParent;

	private Vector3 explosionPostProcessingLocalPosition;

	private Vector3 lightLocalPosition;

	private TrainCar trainCar;

	private HazmatCargoEffectsController effectsController;

	private void Awake()
	{
		effectsController = GetComponent<HazmatCargoEffectsController>();
		if ((bool)effectsController)
		{
			effectsController.ToggleEffects(on: false, forced: true);
			effectsController.enabled = false;
		}
		explosionLight = GetComponentInChildren<Light>();
		if (explosionLight != null)
		{
			lightOriginalParent = explosionLight.transform.parent;
			lightLocalPosition = explosionLight.transform.localPosition;
		}
		explosionPostProcessing = GetComponentInChildren<PostProcessVolume>();
		if (explosionPostProcessing != null)
		{
			explosionPostProcessingParent = explosionPostProcessing.transform.parent;
			explosionPostProcessingLocalPosition = explosionPostProcessing.transform.localPosition;
		}
		base.enabled = false;
	}

	public void AllowSpecialEffects(bool allow)
	{
		if ((bool)effectsController)
		{
			effectsController.AllowSpecialEffects(allow);
		}
	}

	public void SetupForContent(ICargoContent cargoContent)
	{
		this.cargoContent = cargoContent;
		trainCar = cargoContent.Car();
		cargoContent.AboutToReturnToPool += ResetAndReturnToPool;
		if (cargoContent.GetCargoPhase() != CargoPhase.Solid)
		{
			FindPotentialRuptureTransforms();
		}
		SetRandomEffectsPosition();
	}

	private void FindPotentialRuptureTransforms()
	{
		if (potentialLeakTransforms.Count > 0)
		{
			potentialLeakTransforms.Clear();
		}
		Transform transform = TryGetLeakParent(trainCar.GetComponent<CargoModelController>()?.GetCurrentCargoModel()?.transform);
		if (transform == null)
		{
			transform = TryGetLeakParent(trainCar.transform);
		}
		if (transform != null)
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				potentialLeakTransforms.Add(transform.GetChild(i).transform);
			}
		}
	}

	private Transform TryGetLeakParent(Transform parentTransform)
	{
		if (parentTransform == null)
		{
			return null;
		}
		for (int i = 0; i < parentTransform.childCount; i++)
		{
			Transform child = parentTransform.GetChild(i);
			if (child.name.StartsWith("LeakPositions"))
			{
				return child;
			}
		}
		return null;
	}

	private void ResetAndReturnToPool()
	{
		cargoContent.AboutToReturnToPool -= ResetAndReturnToPool;
		ToggleRuptureVisibility(on: false);
		if (effectsController != null)
		{
			effectsController.ToggleEffects(on: false, forced: true);
			effectsController.enabled = false;
		}
		if (explosionLight != null)
		{
			lightUp = false;
			lightUpElapsedTime = 0f;
			explosionLight.transform.SetParent(lightOriginalParent);
			explosionLight.transform.localPosition = lightLocalPosition;
			explosionLight.enabled = false;
		}
		if (explosionPostProcessing != null)
		{
			explosionPostProcessing.transform.SetParent(explosionPostProcessingParent);
			explosionPostProcessing.transform.localPosition = explosionPostProcessingLocalPosition;
			explosionPostProcessing.enabled = false;
		}
		cargoContent = null;
		trainCar = null;
		base.enabled = false;
	}

	private void SetRandomEffectsPosition()
	{
		if (potentialLeakTransforms.Count > 0)
		{
			int index = Random.Range(0, potentialLeakTransforms.Count);
			Vector3 localPosition = potentialLeakTransforms[index].localPosition;
			Quaternion localRotation = potentialLeakTransforms[index].localRotation;
			base.transform.localPosition = localPosition;
			base.transform.localRotation = localRotation;
			base.transform.localRotation *= Quaternion.Euler(0f, 90f, 0f);
		}
		else
		{
			base.transform.localPosition = ((cargoContent.GetCargoPhase() == CargoPhase.Solid) ? DEFAULT_SOLID_EFFECTS_POSITION : DEFAULT_FLUID_EFFECTS_POSITION);
		}
	}

	private void Update()
	{
		if (!lightUp)
		{
			return;
		}
		if (lightUpElapsedTime > lightFadeTime)
		{
			lightUp = false;
			explosionLight.enabled = false;
			explosionPostProcessing.enabled = false;
			return;
		}
		float num = lightFadeTime * maxLightReachTimeRatio;
		if (lightUpElapsedTime < num)
		{
			float t = lightUpElapsedTime / num;
			explosionLight.intensity = InterpolateCubicInOut(0f, lightIntensityMax, t);
			if (explosionPostProcessing.enabled)
			{
				explosionPostProcessing.weight = InterpolateCubicInOut(0f, 1f, t);
			}
		}
		else
		{
			float t2 = (lightUpElapsedTime - num) / (lightFadeTime - num);
			explosionLight.intensity = InterpolateCubicInOut(lightIntensityMax, 0f, t2);
			if (explosionPostProcessing.enabled)
			{
				explosionPostProcessing.weight = InterpolateCubicInOut(1f, 0f, t2);
			}
		}
		float time = Mathf.Clamp01(lightUpElapsedTime / lightFadeTime);
		explosionLight.color = explosionColorGradient.Evaluate(time);
		lightUpElapsedTime += Time.deltaTime;
	}

	public void UpdateEffectsFlowIn(float flowIn)
	{
		if (!(effectsController == null))
		{
			effectsController.flowIn = flowIn;
		}
	}

	public void UpdateEffectsFlowOut(float flowOut)
	{
		if (!(effectsController == null))
		{
			effectsController.flowOut = flowOut;
		}
	}

	public void OnCargoExploded()
	{
		if (effectsController != null)
		{
			effectsController.ToggleEffects(on: false);
		}
		ToggleRuptureVisibility(on: false);
		if (explosionLight != null)
		{
			base.enabled = true;
			explosionLight.enabled = true;
			explosionLight.transform.SetParent(WorldMover.OriginShiftParent);
			lightUp = true;
			lightUpElapsedTime = 0f;
		}
		bool flag = GamePreferences.Get<bool>(Preferences.PostProcessing);
		if (explosionPostProcessing != null && flag)
		{
			explosionPostProcessing.transform.SetParent(WorldMover.OriginShiftParent);
			explosionPostProcessing.enabled = true;
		}
		foreach (ParticleSystem explosionParticleSystem in explosionParticleSystems)
		{
			if (explosionParticleSystem != null)
			{
				explosionParticleSystem.Play();
			}
		}
		foreach (AudioSource item in explosionAudio)
		{
			if (item != null)
			{
				item.Play();
			}
		}
	}

	private float InterpolateCubicInOut(float from, float to, float t)
	{
		if (t >= 1f)
		{
			return to;
		}
		if (t <= 0f)
		{
			return from;
		}
		float num = to - from;
		float num2 = t - 1f;
		return from + num * ((t < 0.5f) ? (4f * t * t * t) : (4f * num2 * num2 * num2 + 1f));
	}

	public void ActivateEffectsExternally(bool playRuptureSound = false)
	{
		if (!(effectsController == null))
		{
			effectsController.enabled = true;
			effectsController.ToggleEffects(on: true);
			if (playRuptureSound)
			{
				effectsController.PlayRuptureSound();
			}
		}
	}

	public void ToggleRuptureVisibility(bool on)
	{
		if (leakRupture != null)
		{
			leakRupture.SetActive(on);
		}
	}
}
