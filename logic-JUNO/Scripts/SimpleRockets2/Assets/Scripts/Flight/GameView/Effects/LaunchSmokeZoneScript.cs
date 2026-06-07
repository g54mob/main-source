using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using ModApi.Craft.Propulsion;
using TrueClouds;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Effects
{
	public class LaunchSmokeZoneScript : MonoBehaviour
	{
		public const int MaxSmokeObjects = 30;

		private float _addSmokeTimer;

		private CloudCamera3D _cloudCamera;

		private float _engineFalloffDistance;

		private float _engineMaxDistance;

		private List<IReactionEngine> _engines = new List<IReactionEngine>();

		private float _intensity;

		[SerializeField]
		private float _intensityDivider = 10000f;

		[SerializeField]
		private float _intensityExponent = 0.4f;

		private List<IReactionEngine> _removeEngines = new List<IReactionEngine>();

		private List<LaunchSmokeScript> _smokes = new List<LaunchSmokeScript>();

		public void AddSmoke(Vector3 position)
		{
			SetupCloudCamera();
			LaunchSmokeScript component = Game.Instance.ResourceLoader.InstantiatePrefab("Flight/GameView/LaunchSmoke").GetComponent<LaunchSmokeScript>();
			component.transform.SetParent(base.transform);
			component.transform.localScale = Vector3.zero;
			component.transform.SetLocalPositionAndRotation(position, Quaternion.Euler(0f, Random.value * 360f, 0f));
			component.RotationSpeed = Random.Range(-1f, 1f) * 8f;
			component.Zone = this;
			component.BaseSpeed = Random.Range(0.85f, 1.15f);
			component.BaseScale = new Vector3(Random.Range(0.85f, 1.15f), Random.Range(1.25f, 1.75f), Random.Range(0.85f, 1.15f));
			_smokes.Add(component);
			while (_smokes.Count > 30)
			{
				RemoveSmoke(_smokes[0]);
			}
		}

		public void RemoveSmoke(LaunchSmokeScript launchSmokeScript)
		{
			_smokes.Remove(launchSmokeScript);
			launchSmokeScript.gameObject.SetActive(value: false);
			Object.Destroy(launchSmokeScript.gameObject);
			if (_smokes.Count == 0)
			{
				DisableCloudCamera();
			}
		}

		protected virtual void Start()
		{
			if (!Game.InFlightScene)
			{
				base.enabled = false;
				return;
			}
			_engineMaxDistance = GetComponent<SphereCollider>().radius;
			_engineFalloffDistance = _engineMaxDistance * 0.5f;
		}

		protected virtual void Update()
		{
			if (!Game.Instance.QualitySettings.VisualEffects.LaunchSteam.Value)
			{
				if (_cloudCamera != null && _cloudCamera.enabled && _smokes.Count == 0)
				{
					_cloudCamera.enabled = false;
				}
			}
			else
			{
				if (Game.Instance.FlightScene.TimeManager.Paused)
				{
					return;
				}
				_removeEngines.Clear();
				float num = 0f;
				Vector3 zero = Vector3.zero;
				foreach (IReactionEngine engine in _engines)
				{
					Transform transform = engine?.Part?.PartScript?.Transform;
					if (transform != null && !engine.Part.PartScript.Data.IsDestroyed)
					{
						float magnitude = (transform.position - base.transform.position).magnitude;
						if (magnitude < _engineMaxDistance)
						{
							float num2 = 1f - Mathf.Clamp01((magnitude - _engineFalloffDistance) / (_engineMaxDistance - _engineFalloffDistance));
							float num3 = Mathf.Clamp01(Vector3.Dot(-transform.up, -base.transform.up));
							num3 *= num3;
							float num4 = engine.CurrentThrust * num3 * num2;
							if (num4 > 0f)
							{
								num += num4;
								zero += transform.position * num4;
							}
						}
						else
						{
							_removeEngines.Add(engine);
						}
					}
					else
					{
						_removeEngines.Add(engine);
					}
				}
				foreach (IReactionEngine removeEngine in _removeEngines)
				{
					_engines.Remove(removeEngine);
				}
				float value = Mathf.Pow(num / _intensityDivider, _intensityExponent);
				value = Mathf.Clamp(value, 0f, 2.25f);
				if (value > _intensity)
				{
					_intensity = value;
				}
				else
				{
					float num5 = value - _intensity;
					_intensity += num5 * Time.deltaTime * 1f;
				}
				if (_cloudCamera != null)
				{
					Vector3 vector = base.transform.up * 25f * Mathf.Clamp(_intensity, 0.1f, 2f) - _cloudCamera.Wind;
					_cloudCamera.Wind += vector * Time.deltaTime * 5f;
				}
				Vector3? vector2 = null;
				if (num > 0f)
				{
					Vector3 position = zero / num;
					Vector3 value2 = base.transform.InverseTransformPoint(position);
					value2.y = 0f;
					vector2 = value2;
				}
				if (_intensity < 0.075f)
				{
					_intensity = 0f;
				}
				else
				{
					_addSmokeTimer -= Time.deltaTime * Mathf.Clamp(_intensity, 0.75f, 1.25f);
					if (_addSmokeTimer < 0f && vector2.HasValue)
					{
						_addSmokeTimer = 1f;
						AddSmoke(vector2.Value);
					}
				}
				foreach (LaunchSmokeScript smoke in _smokes)
				{
					if (vector2.HasValue)
					{
						smoke.AnimateTowardsCenterOfThrust(vector2.Value);
					}
					smoke.SetIntensity(_intensity);
				}
			}
		}

		private static void DisableCloudCamera()
		{
			CloudCamera3D component = Game.Instance.FlightScene.ViewManager.GameView.GameCamera.NearCamera.gameObject.GetComponent<CloudCamera3D>();
			if (component.enabled)
			{
				component.enabled = false;
			}
		}

		private static bool ValidFuelType(FuelType fuelType)
		{
			return fuelType != FuelType.Jet;
		}

		private void OnTriggerEnter(Collider other)
		{
			IReactionEngine reactionEngine = other.GetComponentInParent<PartScript>()?.GetComponentInChildren<IReactionEngine>();
			if (reactionEngine != null && !_engines.Contains(reactionEngine) && ValidFuelType(reactionEngine.FuelSource.FuelType))
			{
				_engines.Add(reactionEngine);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			IReactionEngine reactionEngine = other.GetComponentInParent<PartScript>()?.GetComponentInChildren<IReactionEngine>();
			if (reactionEngine != null && _engines.Contains(reactionEngine))
			{
				_engines.Remove(reactionEngine);
			}
		}

		private void SetupCloudCamera()
		{
			Camera nearCamera = Game.Instance.FlightScene.ViewManager.GameView.GameCamera.NearCamera;
			_cloudCamera = nearCamera.gameObject.GetComponent<CloudCamera3D>();
			if (!_cloudCamera.enabled)
			{
				_cloudCamera.enabled = true;
				_cloudCamera.DistanceToClouds = 7.5f;
				_cloudCamera.WorldBlockingMask = -469762048;
				_cloudCamera.CloudsMask = 4096;
			}
		}
	}
}
