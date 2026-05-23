using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class NoiseManager : MonoBehaviour
{
	public delegate void AlertNPCs();

	public AlertNPCs OnAlertNPCs;

	[SerializeField]
	private float noiseStep = 20f;

	[SerializeField]
	private float decayRate = 10f;

	[SerializeField]
	[Range(0f, 100f)]
	private float currentGlobalNoiseLevel;

	public EventReference noiseEvent;

	private EventInstance noiseSound;

	private const float MaxValue = 100f;

	private const float MinValue = 0f;

	public float CurrentGlobalNoiseLevel => currentGlobalNoiseLevel;

	private void Start()
	{
		noiseSound = RuntimeManager.CreateInstance(noiseEvent);
		RuntimeManager.AttachInstanceToGameObject(noiseSound, base.transform);
		noiseSound.setVolume(0f);
		noiseSound.start();
	}

	private void Update()
	{
		if (currentGlobalNoiseLevel < 99f)
		{
			currentGlobalNoiseLevel -= decayRate * Time.deltaTime;
			currentGlobalNoiseLevel = Mathf.Max(currentGlobalNoiseLevel, 0f);
			noiseSound.setVolume(currentGlobalNoiseLevel / 100f);
		}
		else
		{
			noiseSound.setVolume(1f);
		}
	}

	private void OnDestroy()
	{
		noiseSound.setVolume(0f);
	}

	public void IncreaseGlobalNoise()
	{
		currentGlobalNoiseLevel += noiseStep;
		if (currentGlobalNoiseLevel > 100f)
		{
			OnAlertNPCs();
			base.enabled = false;
		}
		else
		{
			currentGlobalNoiseLevel = Mathf.Min(currentGlobalNoiseLevel, 100f);
		}
	}

	public void IncreaseGlobalNoiseObstacle()
	{
		currentGlobalNoiseLevel += noiseStep * 10f;
		if (currentGlobalNoiseLevel > 100f)
		{
			OnAlertNPCs();
			base.enabled = false;
		}
		else
		{
			currentGlobalNoiseLevel = Mathf.Min(currentGlobalNoiseLevel, 100f);
		}
	}

	public void TriggerNPCs()
	{
		currentGlobalNoiseLevel = 101f;
		noiseSound.setVolume(1f);
		IncreaseGlobalNoise();
	}
}
