using Assets.Scripts.Audio;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class PropEngineScript : EngineScript
	{
		private AudioSource _engineAudioSource;

		private Transform _prop;

		public override float IRSignature => base.ThrottleInput.Value * base.Engine.PowerMultiplier * base.Engine.Power * 0.1f;

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightUnpaused);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (base.PartModifier.UsedInPropMode)
			{
				return;
			}
			AircraftScript aircraft = _part.Aircraft;
			if (aircraft.Fuel <= 0f || _part.EstimateOfUnderwaterPercent > 0.8f || base.EngineDestroyed)
			{
				base.EngineThrottle = 0f;
				return;
			}
			float num = base.ThrottleInput.Value * base.EngineThrottleFunctionalHealth;
			if (base.EngineThrottle < num)
			{
				base.EngineThrottle += Time.fixedDeltaTime * base.Engine.ThrottleResponse * base.EngineThrottleFunctionalHealth;
				if (base.EngineThrottle > num)
				{
					base.EngineThrottle = num;
				}
			}
			else if (base.EngineThrottle > num)
			{
				base.EngineThrottle -= Time.fixedDeltaTime * base.Engine.ThrottleResponse;
				if (base.EngineThrottle < num)
				{
					base.EngineThrottle = num;
				}
			}
			if (base.Body != null && aircraft.Fuel > 0f && base.EngineThrottle > 0f)
			{
				float amount = base.EngineThrottle * base.Engine.FuelConsumptionRate * Time.fixedDeltaTime;
				aircraft.UseFuel(amount);
				Vector3 force = base.transform.forward * (base.EngineThrottle * base.Engine.Power * _part.Aircraft.AtmosphereSample.AirDensityRatio);
				AddForceAndTorque(force, base.CenterOfThrust.position);
			}
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			base.ThrottleInput = base.PartScript.GetModifier<InputControllerScript>();
			_applyEngineTorque = true;
			_prop = base.transform.parent.Find("Propeller");
			base.CenterOfThrust = base.transform;
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_engineAudioSource = base.gameObject.AddComponent<AudioSource>();
				_engineAudioSource.loop = true;
				_engineAudioSource.playOnAwake = true;
				_engineAudioSource.clip = AudioStore.BladeEngineAudio.Resource;
				_engineAudioSource.outputAudioMixerGroup = AudioStore.Parts;
				_engineAudioSource.volume = 0f;
				_engineAudioSource.dopplerLevel = 0f;
				_engineAudioSource.minDistance = 10f;
				_engineAudioSource.maxDistance = 500f;
				_engineAudioSource.spatialBlend = 1f;
				_engineAudioSource.Play();
			}
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (_engineAudioSource != null)
			{
				_engineAudioSource.volume = base.EngineThrottle;
			}
			float num = -5000f * base.EngineThrottle / 60f;
			_prop.transform.Rotate(Vector3.forward, 360f * num * frame.DeltaTime);
		}
	}
}
