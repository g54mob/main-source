using System;
using UnityEngine;

namespace Assets.Scripts.Environment
{
	public interface IEnvironment : IDisposable
	{
		float Brightness { get; }

		Vector3 CloudAnimation1 { get; set; }

		Vector3 CloudAnimation2 { get; set; }

		float CloudsCoverage { get; }

		bool DynamicWeatherEnabled { get; set; }

		float Fogginess { get; }

		bool IsNight { get; }

		float LengthOfDay { get; set; }

		Light Light { get; }

		float TargetTimeOfDay { get; }

		float TimeOfDay { get; set; }

		WeatherPreset WeatherType { get; }

		void OnBloomEnabled(bool enabled);

		void OnLevelLoaded();

		void OnLevelUnloaded();

		void OnRestartLevel();

		void OnStartClient(bool isServer);

		void RegisterCamera(Camera camera);

		void UnregisterCamera(Camera camera);

		void Update(float deltaTime, float unscaledDeltaTime);

		void UpdateTimeOfDay(float timeOfDay, float transitionTime);

		void UpdateWeather(WeatherPreset preset, float transitionTime, bool ignorePause);
	}
}
