using System;
using Assets.Scripts.Environment;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Unique.Cthulhu
{
	public class CthulhuWeather : MonoBehaviour
	{
		private bool _inArea;

		protected virtual void Awake()
		{
			GameState.Instance.LevelRestarted += OnLevelRestarted;
		}

		protected virtual void OnDestroy()
		{
			GameState.Instance.LevelRestarted -= OnLevelRestarted;
			OnExitArea();
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (IsCockpit(other))
			{
				OnAreaEnter();
			}
		}

		protected virtual void OnTriggerExit(Collider other)
		{
			if (IsCockpit(other))
			{
				OnExitArea();
			}
		}

		private bool IsCockpit(Collider collider)
		{
			return collider == FlightSceneScript.Instance.LocalPlayer?.Aircraft?.MainCockpit.PrimaryPartCollider;
		}

		private void OnAreaEnter()
		{
			if (!_inArea)
			{
				_inArea = true;
				FlightSceneScript.Instance.Environment.UpdateWeather(WeatherPreset.Stormy, 10f, ignorePause: false);
				Game.Instance.MusicPlayer.FadeVolumeOut(8f);
			}
		}

		private void OnExitArea()
		{
			if (_inArea)
			{
				_inArea = false;
				FlightSceneScript.Instance.Environment.UpdateWeather(WeatherPreset.FewClouds, 10f, ignorePause: false);
				Game.Instance.MusicPlayer.FadeVolumeIn(8f);
			}
		}

		private void OnLevelRestarted(object sender, EventArgs e)
		{
			OnExitArea();
		}
	}
}
