using System.Collections.Generic;
using Assets.Scripts.Levels;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public static class PauseManager
	{
		private static List<AudioSource> _audioSources = new List<AudioSource>();

		private static bool _pausedByUser = false;

		private static int _pauseRequestCount = 0;

		private static bool _userInitiatedPauseChangeDisabled;

		public static bool AllowTimeScaleChanges { get; set; } = true;

		public static bool FastForwardEnabled { get; private set; }

		public static float FastForwardSpeed => 2.5f;

		public static bool Paused { get; private set; }

		public static bool SlowMotionEnabled { get; private set; }

		public static float SlowMotionSpeed => 0.125f;

		public static void DisableUserPauseChange()
		{
			_userInitiatedPauseChangeDisabled = true;
		}

		public static void EnableUserPauseChange()
		{
			_userInitiatedPauseChangeDisabled = false;
		}

		public static bool RequestPauseChange(bool paused, bool userInitiated)
		{
			if (AllowTimeScaleChanges && (!_userInitiatedPauseChangeDisabled || !userInitiated))
			{
				bool flag = false;
				if (!userInitiated)
				{
					flag = true;
					if (paused)
					{
						_pauseRequestCount++;
					}
					else if (!_pausedByUser || _pauseRequestCount > 1)
					{
						_pauseRequestCount--;
					}
					if (_pauseRequestCount < 0)
					{
						_pauseRequestCount = 0;
					}
					paused = _pauseRequestCount > 0;
				}
				else
				{
					if (_pauseRequestCount == 0)
					{
						flag = true;
					}
					else if (_pauseRequestCount == 1 && _pausedByUser && !paused)
					{
						flag = true;
						_pauseRequestCount--;
					}
					_pausedByUser = paused;
				}
				if (flag && Paused != paused)
				{
					Paused = paused;
					if (Paused)
					{
						StartPause();
					}
					else
					{
						EndPause();
					}
					ApplyCurrentTimescale();
					GameState.Instance.IsPaused = Paused;
					GameState.Instance.RaisePauseChanged(Paused, userInitiated);
				}
			}
			return Paused;
		}

		public static void Reset()
		{
			_pauseRequestCount = 0;
			_pausedByUser = false;
			_audioSources.Clear();
			Paused = false;
			SlowMotionEnabled = false;
			FastForwardEnabled = false;
			ApplyCurrentTimescale();
			EnableUserPauseChange();
			GameState.Instance.IsPaused = false;
			GameState.Instance.RaisePauseChanged(paused: false, userInitiated: false);
		}

		public static void SetFastForward(bool enabled)
		{
			if (AllowTimeScaleChanges)
			{
				SlowMotionEnabled = false;
				FastForwardEnabled = enabled;
				ApplyCurrentTimescale();
			}
		}

		public static void SetSlowMotion(bool enabled)
		{
			if (AllowTimeScaleChanges)
			{
				SlowMotionEnabled = enabled;
				FastForwardEnabled = false;
				ApplyCurrentTimescale();
			}
		}

		public static bool ToggleFastForward(bool silent = false)
		{
			SetFastForward(!FastForwardEnabled);
			if (!silent)
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage(string.Format("Fast Forward {0}", FastForwardEnabled ? "Enabled" : "Disabled"));
			}
			return FastForwardEnabled;
		}

		public static bool ToggleSlowMotion(bool silent = false)
		{
			SetSlowMotion(!SlowMotionEnabled);
			if (!silent)
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage(string.Format("Slow Motion {0}", SlowMotionEnabled ? "Enabled" : "Disabled"));
			}
			return SlowMotionEnabled;
		}

		private static void ApplyCurrentTimescale()
		{
			Physics.simulationMode = (Game.Instance.SceneManager.InMenuScene ? SimulationMode.Script : SimulationMode.FixedUpdate);
			float fixedDeltaTime = Game.Instance.Settings.Quality.Physics.FixedDeltaTime;
			if (Game.Instance.SceneManager.InDesignerScene)
			{
				Time.timeScale = 1f;
				Time.fixedDeltaTime = 0.1f;
			}
			else if (Paused)
			{
				Time.timeScale = 0f;
				Time.fixedDeltaTime = fixedDeltaTime;
			}
			else if (SlowMotionEnabled)
			{
				Time.timeScale = SlowMotionSpeed;
				Time.fixedDeltaTime = fixedDeltaTime * Time.timeScale;
			}
			else if (FastForwardEnabled)
			{
				Time.timeScale = FastForwardSpeed;
				Time.fixedDeltaTime = fixedDeltaTime;
			}
			else
			{
				Time.timeScale = 1f;
				Time.fixedDeltaTime = fixedDeltaTime;
			}
		}

		private static void EndPause()
		{
			if (LevelBase.CurrentLevel != null)
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage(string.Empty);
			}
			UnpauseAudio();
		}

		private static void PauseAudio()
		{
			if (LevelBase.CurrentLevel == null)
			{
				return;
			}
			List<AudioSource> value;
			using (CollectionPool<List<AudioSource>, AudioSource>.Get(out value))
			{
				FlightSceneScript.Instance.AircraftContainer.GetComponentsInChildren(value);
				if (LevelBase.CurrentLevel.WorldRigidbodiesContainer != null)
				{
					List<AudioSource> value2;
					using (CollectionPool<List<AudioSource>, AudioSource>.Get(out value2))
					{
						LevelBase.CurrentLevel.WorldRigidbodiesContainer.GetComponentsInChildren(value2);
						value.AddRange(value2);
					}
				}
				_audioSources.Clear();
				foreach (AudioSource item in value)
				{
					if (item.enabled && item.isPlaying)
					{
						item.Pause();
						_audioSources.Add(item);
					}
				}
			}
		}

		private static void StartPause()
		{
			if (LevelBase.CurrentLevel != null)
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage("Paused");
				PauseAudio();
			}
		}

		private static void UnpauseAudio()
		{
			foreach (AudioSource audioSource in _audioSources)
			{
				if (audioSource != null)
				{
					audioSource.UnPause();
				}
			}
			_audioSources.Clear();
		}
	}
}
