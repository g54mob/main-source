using System;
using System.Linq;
using UnityEngine;

public class SnowfallVFX : MonoBehaviour
{
	[Serializable]
	private class FSnowfallVFXConfig
	{
		public int level;

		public float fogDensity;

		public AudioData ambientSound;

		[Header("Particles")]
		public int rate = 100;

		public Vector2 minMaxSpeed = new Vector2(2f, 6f);

		public Vector3 noiseIntensity = new Vector3(0.5f, 0f, 0.5f);

		public float noiseFrequency = 0.1f;
	}

	[SerializeField]
	private FSnowfallVFXConfig[] snowfallConfigs;

	private DayNightCycle dayNightCycle;

	private ParticleSystem particles;

	private int snowfallLevel;

	private AudioSource currentAmbientAudioSource;

	private Coroutine currentAmbiendAudioSourceCoroutine;

	private void Awake()
	{
		particles = GetComponentInChildren<ParticleSystem>();
	}

	public void Init(SnowfallController snowfallController)
	{
		Character playerCharacter = LTFunctionLibrary.GetLTGameManager().PlayerCharacter;
		if ((bool)playerCharacter)
		{
			base.transform.SetParent(playerCharacter.transform, worldPositionStays: false);
		}
		else
		{
			LTFunctionLibrary.GetLTGameManager().onSpawnPlayer += delegate(Character character, PlayerController controller, Character oldCharacter, PlayerController oldController)
			{
				base.transform.SetParent(character.transform);
			};
		}
		snowfallController.onSnowfallLevelChanged += SetSnowfallLevel;
		dayNightCycle = LTFunctionLibrary.GetLTLevelController().DayNightCycle;
	}

	public void SetSnowfallLevel(int level)
	{
		snowfallLevel = level;
		ApplySnowfallVFXConfig(GetSnowfallVFXConfig(snowfallLevel));
	}

	private FSnowfallVFXConfig GetSnowfallVFXConfig(int level)
	{
		if (snowfallConfigs == null || snowfallConfigs.Length == 0)
		{
			return null;
		}
		if (level <= snowfallConfigs[0].level)
		{
			return snowfallConfigs[0];
		}
		if (level >= snowfallConfigs[^1].level)
		{
			return snowfallConfigs[^1];
		}
		return snowfallConfigs.First((FSnowfallVFXConfig x) => x.level == level);
	}

	private void ApplySnowfallVFXConfig(FSnowfallVFXConfig snowfallVFXConfig)
	{
		dayNightCycle.ExtraFogDensity = snowfallVFXConfig.fogDensity;
		ParticleSystem.EmissionModule emission = particles.emission;
		emission.rateOverTime = snowfallVFXConfig.rate;
		ParticleSystem.MainModule main = particles.main;
		main.startSpeed = new ParticleSystem.MinMaxCurve(snowfallVFXConfig.minMaxSpeed.x, snowfallVFXConfig.minMaxSpeed.y);
		main.startLifetime = particles.transform.position.y / ((snowfallVFXConfig.minMaxSpeed.x + snowfallVFXConfig.minMaxSpeed.y) / 2f);
		ParticleSystem.NoiseModule noise = particles.noise;
		noise.strengthX = snowfallVFXConfig.noiseIntensity.x;
		noise.strengthY = snowfallVFXConfig.noiseIntensity.y;
		noise.strengthZ = snowfallVFXConfig.noiseIntensity.z;
		noise.frequency = snowfallVFXConfig.noiseFrequency;
		particles.Play();
		if ((bool)currentAmbientAudioSource)
		{
			AudioSystem.Instance.StopCoroutineCheckingVar(ref currentAmbiendAudioSourceCoroutine);
			AudioSystem.Instance.FadeAudioSource(currentAmbientAudioSource, 0f, 2f, unscaledDeltaTime: true);
			currentAmbientAudioSource = null;
		}
		if (snowfallVFXConfig.ambientSound != null && snowfallVFXConfig.ambientSound.AudioClips != null && snowfallVFXConfig.ambientSound.AudioClips.Length != 0)
		{
			currentAmbientAudioSource = AudioSystem.Instance.PlaySound2D(snowfallVFXConfig.ambientSound, AudioSystem.EAudioMixerGroup.Ambience, 0f, 0f, loop: true, AudioSystem.EAudioPriority.VeryHigh);
			currentAmbientAudioSource.volume = 0f;
			currentAmbiendAudioSourceCoroutine = AudioSystem.Instance.FadeAudioSource(currentAmbientAudioSource, snowfallVFXConfig.ambientSound.Volume, 2f, unscaledDeltaTime: true);
		}
	}
}
