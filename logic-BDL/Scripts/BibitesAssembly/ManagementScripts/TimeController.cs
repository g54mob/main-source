using System;
using System.Collections.Generic;
using System.Linq;
using OneUseScripts;
using SettingScripts;
using UIScripts.SettingHandles;
using UIScripts.SettingHandles.References;
using UnityEngine;
using UnityEngine.UI;

namespace ManagementScripts
{
	public class TimeController : MonoBehaviour
	{
		public static TimeController Instance;

		[NonSerialized]
		public static FloatSetting targetTimeScale = new FloatSetting
		{
			Name = "Time Speed",
			precision = 2,
			val = 1f,
			DefaultValue = 1f,
			minValue = 0.1f,
			maxValue = 100f,
			prefix = "X ",
			SI = false,
			canGoOutOfBounds = true
		};

		[NonSerialized]
		public static FloatSetting engineTimeScale = new FloatSetting
		{
			val = 1f,
			DefaultValue = 1f,
			minValue = 0.1f,
			maxValue = 100f,
			canGoOutOfBounds = true
		};

		[SerializeField]
		private SettingSliderReference timeSliderRef;

		[NonSerialized]
		public LogFloatSettingSlider timeScaleSlider = new LogFloatSettingSlider(targetTimeScale, 5f);

		[SerializeField]
		private Button pauseButton;

		[SerializeField]
		private Button playButton;

		public List<PauseSource> Pauses = new List<PauseSource>();

		public static bool paused = false;

		private static float baseFixedDeltaTime = 0.025f;

		[NonSerialized]
		private static IntSetting simTPS = ScenarioIndependentSettings.Instance.simTPS;

		private float fpsMinRatio = float.PositiveInfinity;

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			timeScaleSlider.InitUIElement(timeSliderRef);
			targetTimeScale.Subscribe(SetTarget);
			engineTimeScale.Subscribe(UpdateTimeScale);
			simTPS.Subscribe(UpdateFixedDeltaTime);
			UpdateFixedDeltaTime(simTPS.val);
		}

		private void UpdateFixedDeltaTime(int tps)
		{
			baseFixedDeltaTime = 1f / (float)tps;
			UpdateTimeScale(Time.timeScale);
		}

		private void SetTarget(float val)
		{
			if (val < engineTimeScale.val)
			{
				engineTimeScale.SetValue(val);
			}
			else if (UserSettings.minimumFPS.val < 1)
			{
				engineTimeScale.SetValue(val);
			}
			else if (!TimeKeeper.firstUpdate)
			{
				CheckMinFPS(TimeKeeper.fps);
			}
			if (val > 0f)
			{
				ForcePlay();
			}
		}

		public void CheckMinFPS(float presentFPS)
		{
			if (Application.isFocused || !UserSettings.ignoreMinOnUnfocus.val)
			{
				int val = UserSettings.minimumFPS.val;
				if (val >= 1 && !paused && !(Mathf.Abs((float)val - presentFPS) < Mathf.Log(val, 2f) - 2f))
				{
					float value = Mathf.Clamp(engineTimeScale.val * presentFPS / (float)val, Mathf.Min(0.1f, targetTimeScale.val), targetTimeScale.val);
					engineTimeScale.SetValue(value);
				}
			}
		}

		private void UpdateTimeScale(float val)
		{
			Time.timeScale = val;
			paused = Mathf.Approximately(val, 0f);
			if (val > 0f && val < 1f)
			{
				Time.fixedDeltaTime = baseFixedDeltaTime * val;
			}
			if (val >= 1f)
			{
				Time.fixedDeltaTime = baseFixedDeltaTime;
			}
			Time.maximumDeltaTime = Time.fixedDeltaTime;
		}

		public void PlaySpeed()
		{
			targetTimeScale.SetValue(1f);
		}

		public void TogglePause()
		{
			TogglePauseGame();
		}

		public void TogglePauseGame(string source = "base", bool isUnpause = false)
		{
			PauseSource pauseSource = Pauses.FirstOrDefault((PauseSource p) => p.Source == source);
			if (pauseSource != null)
			{
				engineTimeScale.SetValue(pauseSource.PreviousTimeFactor);
				if (!Mathf.Approximately(pauseSource.PreviousTimeFactor, 0f))
				{
					timeScaleSlider.UpdateDisplayedValue(targetTimeScale.val);
				}
				Pauses.Remove(pauseSource);
			}
			else if (!isUnpause)
			{
				Pauses.Add(new PauseSource
				{
					PreviousTimeFactor = engineTimeScale.val,
					Source = source
				});
				engineTimeScale.SetValue(0f);
				paused = true;
				timeScaleSlider.UpdateDisplayedValue(0f);
			}
		}

		private void ForcePlay()
		{
			paused = false;
			if (Pauses.Count >= 1)
			{
				float value = Pauses.Max((PauseSource p) => p.PreviousTimeFactor);
				Pauses.Clear();
				engineTimeScale.SetValue(value);
				timeScaleSlider.UpdateDisplayedValue(targetTimeScale.val);
			}
		}

		private void OnDestroy()
		{
			UpdateTimeScale(1f);
			timeScaleSlider.ReleaseDependencies();
			targetTimeScale.UnSubscribe(SetTarget);
			engineTimeScale.UnSubscribe(UpdateTimeScale);
		}
	}
}
