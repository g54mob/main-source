using System;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.TravelEvents;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class PlayPlanetMusic : MonoBehaviour
	{
		public string[] GenericAmbientMusic;

		public string[] GenericActionMusic;

		public static string AmbientMusicId;

		public static string ActionMusicId;

		public static AudioObject AmbientTrack;

		public static AudioObject ActionTrack;

		public string AmbientLoopId;

		public static AudioObject AmbientLoop;

		[HideInInspector]
		public int EnemyCount;

		[HideInInspector]
		public bool WasAction;

		private NimbatusTerrainClimateZone _climateZone;

		private float _initVol;

		private float _currentVol;

		private float _targetVol;

		private bool _started;

		public void Start()
		{
			_currentVol = ((RuntimeGlobals.Settings.MusicVolume <= 0f) ? 0f : AudioController.GetCategoryVolume("Music"));
			AudioController.SetCategoryVolume("Music", _currentVol);
			AudioController.SetCategoryVolume("Sound", RuntimeGlobals.Settings.SoundEffectVolume);
			_climateZone = SerializableMonobehaviour<NimbatusClimateZoneManager, ClimateZoneManagerSaveData>.Instance.ActiveClimateZone;
			if (_climateZone != null)
			{
				AmbientMusicId = _climateZone.AmbientTheme;
				ActionMusicId = _climateZone.ActionTheme;
				AmbientLoopId = _climateZone.AmbientSoundloop;
			}
			if (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent != null)
			{
				ActionMusicId = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent.MissionSettings.ActionTheme;
				AmbientMusicId = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent.MissionSettings.AmbientTheme;
			}
			if (string.IsNullOrEmpty(ActionMusicId))
			{
				int num = UnityEngine.Random.Range(0, GenericActionMusic.Length);
				ActionMusicId = GenericActionMusic[num];
			}
			if (string.IsNullOrEmpty(AmbientMusicId))
			{
				int num2 = UnityEngine.Random.Range(0, GenericAmbientMusic.Length);
				AmbientMusicId = GenericAmbientMusic[num2];
			}
		}

		public void OnEnable()
		{
			WorldController.PlanetMusic = this;
		}

		public void OnDisable()
		{
			if (AmbientTrack != null && ActionTrack != null)
			{
				AmbientTrack.stopAfterFadeOut = true;
				ActionTrack.stopAfterFadeOut = true;
				ActionTrack.FadeOut(2f);
			}
			if (WorldController.PlanetMusic == this)
			{
				WorldController.PlanetMusic = null;
			}
		}

		public static void ToAmbientMusic()
		{
			if (AmbientTrack != null && ActionTrack != null)
			{
				AmbientTrack.FadeIn(1f);
				ActionTrack.FadeOut(1f, 0.5f);
			}
		}

		public static void ToActionMusic()
		{
			if (AmbientTrack != null && ActionTrack != null)
			{
				AmbientTrack.FadeOut(1f, 0.5f);
				ActionTrack.FadeIn(1f);
			}
		}

		public void Update()
		{
			if (RuntimeGlobals.IsGameLoading)
			{
				return;
			}
			if (!_started)
			{
				base.transform.position = RuntimeGlobals.Camera.transform.position;
				_started = true;
				if (!string.IsNullOrEmpty(AmbientLoopId))
				{
					AmbientLoop = AudioController.PlayAmbienceSound(AmbientLoopId, Vector3.zero);
					AudioSource component = AmbientLoop.GetComponent<AudioSource>();
					if (component == null)
					{
						throw new Exception("No audio source attached to audio object");
					}
					component.rolloffMode = AudioRolloffMode.Linear;
					component.maxDistance = (float)WorldController.TerrainSettings.PlanetSize * 1.8f;
					component.minDistance = (float)WorldController.TerrainSettings.PlanetSize * 1.4f;
				}
				ActionTrack = AudioController.Play(ActionMusicId);
				_initVol = ActionTrack.volume;
				ActionTrack.volume = 0f;
				ActionTrack.stopAfterFadeOut = false;
				AmbientTrack = AudioController.PlayMusic(AmbientMusicId);
				AmbientTrack.stopAfterFadeOut = false;
				ActionTrack.FadeOut(0.2f);
				Invoke("InitVolume", 0.2f);
			}
			if (!RuntimeGlobals.IsGamePaused)
			{
				_targetVol = RuntimeGlobals.Settings.MusicVolume;
				_currentVol = Mathf.Lerp(_currentVol, _targetVol, Time.unscaledDeltaTime);
				AudioController.SetCategoryVolume("Music", _currentVol);
			}
			else
			{
				_currentVol = RuntimeGlobals.Settings.MusicVolume;
			}
			if (EnemyCount > 0 && !WasAction)
			{
				ToActionMusic();
				WasAction = true;
			}
			else if (EnemyCount <= 0 && WasAction)
			{
				ToAmbientMusic();
				WasAction = false;
			}
		}

		public void InitVolume()
		{
			ActionTrack.volume = _initVol;
		}
	}
}
