using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class HospitalAudioAmbienceManager : MustCallDestroy
	{
		private class AmbienceEmitters
		{
			public float Volume;

			public float PopulationVolume;

			public AudioEmitter HospitalEmitter;
		}

		private float _hospitalPlaneHeight;

		private HospitalAudioAmbienceManagerConfig _config;

		private CharacterManager _characterManager;

		private LevelCameraManager _levelCameraManager;

		private WorldState _worldState;

		private Vector2[] _viewportPoints = new Vector2[9]
		{
			new Vector2(0.25f, 0.25f),
			new Vector2(0.5f, 0.25f),
			new Vector2(0.75f, 0.25f),
			new Vector2(0.25f, 0.75f),
			new Vector2(0.5f, 0.75f),
			new Vector2(0.75f, 0.75f),
			new Vector2(0.25f, 0.5f),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.75f, 0.5f)
		};

		private Dictionary<HospitalAudioAmbienceManagerConfig.AmbienceConfig, AmbienceEmitters> _emitters = new Dictionary<HospitalAudioAmbienceManagerConfig.AmbienceConfig, AmbienceEmitters>();

		public HospitalAudioAmbienceManager(GameTime gameTime, CharacterManager characterManager, WorldState worldState, MetagameMap metagameMap, LevelCameraManager levelCameraManager, HospitalAudioAmbienceManagerConfig config)
		{
			_config = config;
			_characterManager = characterManager;
			_worldState = worldState;
			_levelCameraManager = levelCameraManager;
			if (AudioManager.Instance == null)
			{
				return;
			}
			foreach (HospitalAudioAmbienceManagerConfig.AmbienceConfig ambienceConfig in _config.AmbienceConfigs)
			{
				AudioEmitter audioEmitter = AudioManager.Instance.Play(ambienceConfig.HospitalAmbienceAudioEventName);
				if (audioEmitter != null)
				{
					audioEmitter.Volume = 0f;
					audioEmitter.Pause();
				}
				_emitters[ambienceConfig] = new AmbienceEmitters
				{
					HospitalEmitter = audioEmitter
				};
			}
		}

		public void Update()
		{
			int count = _characterManager.AllCharacters.Count;
			float num = 0f;
			Camera cameraComponent = _levelCameraManager.CurrentLevelCamera.CameraComponent;
			Vector2[] viewportPoints = _viewportPoints;
			foreach (Vector2 vector in viewportPoints)
			{
				Plane plane = new Plane(Vector3.up, new Vector3(0f, _hospitalPlaneHeight, 0f));
				Ray ray = cameraComponent.ViewportPointToRay(vector);
				if (plane.Raycast(ray, out var enter))
				{
					Vector3 point = ray.GetPoint(enter);
					if (_worldState.GetHospitalMapAtWorldPosition(point) != null)
					{
						num += 1f;
					}
				}
			}
			float num2 = num / (float)_viewportPoints.Length;
			float num3 = 0f;
			float y = cameraComponent.transform.position.y;
			foreach (KeyValuePair<HospitalAudioAmbienceManagerConfig.AmbienceConfig, AmbienceEmitters> emitter in _emitters)
			{
				HospitalAudioAmbienceManagerConfig.AmbienceConfig key = emitter.Key;
				AmbienceEmitters value = emitter.Value;
				if (value.HospitalEmitter != null)
				{
					float volume = value.Volume;
					if (IsPopulation(key.PopulationSize, count))
					{
						value.PopulationVolume = Mathf.MoveTowards(value.PopulationVolume, 1f, Time.unscaledDeltaTime / _config.AmbiencePopulationFadeDuration);
					}
					else
					{
						value.PopulationVolume = Mathf.MoveTowards(value.PopulationVolume, 0f, Time.unscaledDeltaTime / _config.AmbiencePopulationFadeDuration);
					}
					float num4 = 0f;
					if ((key.Location & HospitalAudioAmbienceManagerConfig.Location.Outside) != 0)
					{
						num4 += 1f - num2;
					}
					if ((key.Location & HospitalAudioAmbienceManagerConfig.Location.Hospital) != 0)
					{
						num4 += num2;
					}
					float num5 = value.PopulationVolume * num4;
					float time = y;
					num5 *= key.HeightVolumeCurve.Evaluate(time);
					if (volume < num5)
					{
						value.Volume = Mathf.Min(num5, volume + Time.unscaledDeltaTime / _config.AmbienceFadeDuration);
					}
					else
					{
						value.Volume = Mathf.Max(num5, volume - Time.unscaledDeltaTime / _config.AmbienceFadeDuration);
					}
					num3 += value.Volume;
				}
			}
			foreach (KeyValuePair<HospitalAudioAmbienceManagerConfig.AmbienceConfig, AmbienceEmitters> emitter2 in _emitters)
			{
				AmbienceEmitters value2 = emitter2.Value;
				if (value2.HospitalEmitter != null)
				{
					value2.HospitalEmitter.Volume = value2.Volume / Mathf.Max(1f, num3);
					if (Mathf.Approximately(0f, value2.HospitalEmitter.Volume))
					{
						value2.HospitalEmitter.Pause();
					}
					else
					{
						value2.HospitalEmitter.UnPause();
					}
				}
			}
		}

		private bool IsPopulation(HospitalAudioAmbienceManagerConfig.PopulationSize populationSize, int characterCount)
		{
			if ((populationSize & HospitalAudioAmbienceManagerConfig.PopulationSize.Small) != 0 && _config.SmallMinCharacterCount <= characterCount && characterCount <= _config.SmallMaxCharacterCount)
			{
				return true;
			}
			if ((populationSize & HospitalAudioAmbienceManagerConfig.PopulationSize.Medium) != 0 && _config.MediumMinCharacterCount <= characterCount && characterCount <= _config.MediumMaxCharacterCount)
			{
				return true;
			}
			if ((populationSize & HospitalAudioAmbienceManagerConfig.PopulationSize.Large) != 0 && _config.LargeMinCharacterCount <= characterCount && characterCount <= _config.LargeMaxCharacterCount)
			{
				return true;
			}
			return false;
		}

		public override void Destroy()
		{
			foreach (KeyValuePair<HospitalAudioAmbienceManagerConfig.AmbienceConfig, AmbienceEmitters> emitter in _emitters)
			{
				AmbienceEmitters value = emitter.Value;
				if (value.HospitalEmitter != null)
				{
					value.HospitalEmitter.Stop(playOutro: false);
				}
			}
			base.Destroy();
		}
	}
}
