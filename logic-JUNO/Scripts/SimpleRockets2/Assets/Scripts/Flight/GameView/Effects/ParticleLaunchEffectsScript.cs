using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using ModApi;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using ModApi.Craft.Propulsion;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Effects
{
	public class ParticleLaunchEffectsScript : MonoBehaviour
	{
		public const float MinIntensity = 1E-06f;

		private float _engineFalloffDistance;

		private float _engineMaxDistance;

		private List<IReactionEngine> _engines = new List<IReactionEngine>();

		[SerializeField]
		private float _intensityDivider = 10000f;

		[SerializeField]
		private float _intensityExponent = 0.4f;

		private List<IReactionEngine> _removeEngines = new List<IReactionEngine>();

		private float _simulationSpeed;

		private ParticleInterpolatorScript[] _systems;

		private VisualEffectsQualitySettings _visualEffects;

		protected virtual void OnDestroy()
		{
			_visualEffects.LaunchSteam.Changed -= OnLaunchSteamSettingChanged;
		}

		protected virtual void Start()
		{
			_engineMaxDistance = GetComponent<CapsuleCollider>().height / 2f;
			_engineFalloffDistance = _engineMaxDistance * 0.5f;
			_systems = GetComponentsInChildren<ParticleInterpolatorScript>(includeInactive: true);
			_visualEffects = Game.Instance.QualitySettings.VisualEffects;
			_visualEffects.LaunchSteam.Changed += OnLaunchSteamSettingChanged;
			UpdateActiveState();
		}

		protected virtual void Update()
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
			value = Mathf.Clamp01(value);
			if (value < 1E-06f)
			{
				value = 0f;
			}
			float num5 = ((value > 0f) ? 1f : 0.25f);
			if (_simulationSpeed < num5)
			{
				_simulationSpeed = Utilities.StepTowards(_simulationSpeed, 10f * Time.deltaTime, num5);
			}
			else
			{
				_simulationSpeed = Utilities.StepTowards(_simulationSpeed, 1f * Time.deltaTime, num5);
			}
			ParticleInterpolatorScript[] systems = _systems;
			for (int i = 0; i < systems.Length; i++)
			{
				systems[i].Interpolate(value, _simulationSpeed);
			}
		}

		private static bool ValidFuelType(FuelType fuelType)
		{
			return fuelType != FuelType.Jet;
		}

		private void OnLaunchSteamSettingChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			UpdateActiveState();
		}

		private void OnTriggerEnter(Collider other)
		{
			IReactionEngine reactionEngine = other.GetComponentInParent<PartScript>()?.GetComponentInChildren<IReactionEngine>();
			if (reactionEngine != null && !_engines.Contains(reactionEngine) && ValidFuelType(reactionEngine.FuelSource?.FuelType))
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

		private void UpdateActiveState()
		{
			if (!Game.InFlightScene)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			base.gameObject.SetActive(_visualEffects.LaunchSteam.Value);
			_engines.Clear();
		}
	}
}
