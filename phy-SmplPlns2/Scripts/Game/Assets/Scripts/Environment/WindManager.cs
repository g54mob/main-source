using System;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer;
using UnityEngine;

namespace Assets.Scripts.Environment
{
	public class WindManager : MonoBehaviour
	{
		public enum WindGustMode
		{
			None = 0,
			Light = 1,
			Medium = 2,
			Heavy = 3
		}

		private const string DefaultWindGustKey = "WindSettings.DefaultWindGusts";

		private const string DefaultWindHeadingKey = "WindSettings.DefaultWindHeading";

		private const string DefaultWindSpeedKey = "WindSettings.DefaultWindSpeed";

		private static WindGustMode _savedGustMode;

		private static int _savedWindSpeed;

		[SerializeField]
		private FlightSceneNetworkScript _flightSceneNetwork;

		private Vector3 _lastSetWindVelocity;

		private Vector3 _previousWindVelocity;

		private float _randomChangeTimeRange = 10f;

		private float _timeUntilWindChange = 10f;

		private float _windChangeSpeed = 10f;

		private int _windHeading;

		private int _windSpeed;

		public bool DynamicWind { get; set; }

		public WindGustMode GustMode { get; set; }

		public Vector3 TargetWindVelocity { get; private set; }

		public int WindHeading
		{
			get
			{
				if (Mathf.Abs(WindVelocity.z) > 1f || Mathf.Abs(WindVelocity.x) > 1f)
				{
					int num = Mathf.RoundToInt(Mathf.Atan2(WindVelocity.x, WindVelocity.z) * 57.29578f);
					if (num < 0)
					{
						return num + 360;
					}
					if (num > 360)
					{
						return num - 360;
					}
				}
				return 0;
			}
			set
			{
				_windHeading = value;
				UpdateWind(_windHeading, _windSpeed);
			}
		}

		public int WindSpeed
		{
			get
			{
				return Mathf.RoundToInt(WindVelocity.magnitude * 2.23694f);
			}
			set
			{
				_windSpeed = value;
				UpdateWind(_windHeading, _windSpeed);
			}
		}

		public Vector3 WindVariance { get; set; }

		public Vector3 WindVelocity
		{
			get
			{
				return _flightSceneNetwork.WindVelocity;
			}
			private set
			{
				_flightSceneNetwork.WindVelocity = value;
			}
		}

		public static WindGustMode WindGustModeFromText(string text)
		{
			return (WindGustMode)Enum.Parse(typeof(WindGustMode), text.Replace(" ", string.Empty));
		}

		public void CalculateWindVelocity()
		{
			SetWindVelocity(Quaternion.Euler(0f, _windHeading, 0f) * Vector3.forward * _windSpeed / 2.23694f);
		}

		public WindGustMode LoadWindGustMode()
		{
			_savedGustMode = WindGustModeFromText(PlayerPrefs.GetString("WindSettings.DefaultWindGusts", "None"));
			GustMode = _savedGustMode;
			UpdateWindVariance();
			return GustMode;
		}

		public int LoadWindHeading()
		{
			_windHeading = PlayerPrefs.GetInt("WindSettings.DefaultWindHeading", 360);
			CalculateWindVelocity();
			return _windHeading;
		}

		public int LoadWindSpeed()
		{
			_windSpeed = _savedWindSpeed;
			CalculateWindVelocity();
			return _windSpeed;
		}

		public void SaveWind(int heading, int speedInMph, WindGustMode gustMode)
		{
			PlayerPrefs.SetInt("WindSettings.DefaultWindHeading", heading);
			PlayerPrefs.SetString("WindSettings.DefaultWindGusts", gustMode.ToString());
			_savedWindSpeed = speedInMph;
			_savedGustMode = gustMode;
		}

		public void UpdateWind(Vector3 windVelocity)
		{
			SetWindVelocity(windVelocity);
			UpdateWindVariance();
		}

		public void UpdateWind(int heading, int speed)
		{
			_windHeading = heading;
			_windSpeed = speed;
			UpdateWind(Quaternion.Euler(0f, heading, 0f) * Vector3.forward * ((float)speed / 2.23694f));
		}

		public void UpdateWindGustMode(WindGustMode gustMode)
		{
			GustMode = gustMode;
			UpdateWindVariance();
		}

		public void UpdateWindVariance()
		{
			WindVariance = new Vector3(Mathf.Abs(_lastSetWindVelocity.magnitude), 0f, Mathf.Abs(_lastSetWindVelocity.magnitude));
			switch (GustMode)
			{
			case WindGustMode.None:
				WindVariance = Vector3.zero;
				_windChangeSpeed = 0f;
				break;
			case WindGustMode.Light:
				WindVariance *= 0.1f;
				_windChangeSpeed = 10f;
				break;
			case WindGustMode.Medium:
				WindVariance *= 0.2f;
				_windChangeSpeed = 20f;
				break;
			case WindGustMode.Heavy:
				WindVariance *= 0.5f;
				_windChangeSpeed = 50f;
				break;
			}
		}

		protected virtual void Awake()
		{
			SetWindVelocity(Vector3.zero);
			GustMode = WindGustMode.None;
			if (!Game.Instance.CurrentLevel.IsSandbox)
			{
				base.enabled = false;
				return;
			}
			LoadWindHeading();
			LoadWindSpeed();
			LoadWindGustMode();
		}

		protected virtual void Update()
		{
			if (!GameState.Instance.IsPaused && FlightSceneScript.Instance.FlightSceneNetwork.IsHostStarted)
			{
				_timeUntilWindChange -= Time.deltaTime;
				if (GustMode != WindGustMode.None && _timeUntilWindChange <= 0f)
				{
					TargetWindVelocity = _lastSetWindVelocity + new Vector3(UnityEngine.Random.Range(0f - WindVariance.x, WindVariance.x), UnityEngine.Random.Range(0f - WindVariance.y, WindVariance.y), UnityEngine.Random.Range(0f - WindVariance.z, WindVariance.z));
					_timeUntilWindChange = UnityEngine.Random.Range(0f, _randomChangeTimeRange);
				}
				WindVelocity = Vector3.MoveTowards(WindVelocity, TargetWindVelocity, _windChangeSpeed * UnityEngine.Random.Range(0.1f, 2f) * Time.deltaTime);
				WindVelocity += new Vector3(UnityEngine.Random.Range(0f - WindVariance.x, WindVariance.x), UnityEngine.Random.Range(0f - WindVariance.y, WindVariance.y), UnityEngine.Random.Range(0f - WindVariance.z, WindVariance.z)) * 0.1f;
				if (WindVelocity != _previousWindVelocity)
				{
					_previousWindVelocity = WindVelocity;
				}
			}
		}

		private void SetWindVelocity(Vector3 v)
		{
			if (!(WindVelocity == v))
			{
				WindVelocity = v;
				_lastSetWindVelocity = v;
				TargetWindVelocity = v;
				UpdateWindVariance();
				_timeUntilWindChange = UnityEngine.Random.Range(0f, _randomChangeTimeRange);
			}
		}
	}
}
