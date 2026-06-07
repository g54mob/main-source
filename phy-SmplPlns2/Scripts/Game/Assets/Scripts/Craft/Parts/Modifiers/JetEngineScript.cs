using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class JetEngineScript : EngineScript
	{
		private AudioSource _audio;

		private float _audioVolume;

		private Transform _fan;

		private ParticleSystem _smokeSystem;

		private ParticleSystem.EmissionModule _smokeSystemEmission;

		private ParticleSystem.MainModule _smokeSystemMain;

		public float AvailableAirIntakeRatio { get; set; }

		public override CraftEngineType EngineType => CraftEngineType.Jet;

		public override float IRSignature => base.ThrottleInput.Value * base.Engine.PowerMultiplier * base.Engine.Power * 1f;

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public Vector3 GetCurrentEngineForce()
		{
			AircraftScript aircraft = _part.Aircraft;
			Vector3 vector = Vector3.zero;
			if (aircraft.Fuel <= 0f || _part.EstimateOfUnderwaterPercent > 0.8f || base.EngineDestroyed)
			{
				base.EngineThrottle = 0f;
				_smokeSystemEmission.enabled = false;
			}
			else
			{
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
				if (base.Body != null)
				{
					_smokeSystemEmission.enabled = false;
					float engineThrottle = base.EngineThrottle;
					if (aircraft.Fuel > 0f && engineThrottle > 0f)
					{
						float num2 = AvailableAirIntakeRatio * base.PartScript.Aircraft.AtmosphereSample.AirDensityRatio;
						if (num2 > 1f || base.Engine.RequiredAirIntake == 0f)
						{
							num2 = 1f;
						}
						engineThrottle *= num2;
						_smokeSystemEmission.enabled = true;
						_smokeSystemMain.startSpeed = engineThrottle * 7f;
						if (base.Engine.AlphaTiedToThrottle)
						{
							Color color = _smokeSystemMain.startColor.color;
							color.a = engineThrottle;
							_smokeSystemMain.startColor = color;
						}
						float amount = engineThrottle * base.Engine.FuelConsumptionRate * Time.fixedDeltaTime;
						aircraft.UseFuel(amount);
						vector = base.CenterOfThrust.forward;
						vector *= engineThrottle * base.Engine.Power;
					}
				}
			}
			return vector * base.Engine.PowerMultiplier;
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightUnpaused);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocalUnpaused);
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (base.Engine.DuctedThrust)
			{
				return;
			}
			Vector3 currentEngineForce = GetCurrentEngineForce();
			if ((bool)base.Body)
			{
				Vector3 position = base.CenterOfThrust.position;
				AddForceAndTorque(currentEngineForce, position);
				if (AvailableAirIntakeRatio < 1f && base.Engine.RequiredAirIntake > 0f)
				{
					float num = AvailableAirIntakeRatio * AvailableAirIntakeRatio;
					_smokeSystemMain.startColor = new Color(num, num, num);
				}
				else if (_part.Aircraft.Fuel < 0.5f)
				{
					_smokeSystemMain.startColor = new Color(0.1f, 0.1f, 0.1f);
				}
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			base.ThrottleInput = base.PartScript.GetModifier<InputControllerScript>();
			_fan = Utilities.FindFirstGameObjectMyselfOrChildren("EngineTurbojetCompressor", _part.gameObject).transform;
			Transform transform = Utilities.FindFirstGameObjectMyselfOrChildren("EngineSmokeSystem", _part.gameObject).transform;
			base.CenterOfThrust = Utilities.FindFirstGameObjectMyselfOrChildren("CenterOfThrust", _part.gameObject).transform;
			if (transform != null)
			{
				_smokeSystem = transform.GetComponent<ParticleSystem>();
				_smokeSystemMain = _smokeSystem.main;
				_smokeSystemEmission = _smokeSystem.emission;
				_smokeSystemEmission.enabled = false;
				if (loadContext == CraftLoadContext.Flight && !base.Engine.DuctedThrust)
				{
					_smokeSystem.gameObject.SetActive(value: true);
				}
				else
				{
					_smokeSystem.gameObject.SetActive(value: false);
				}
				_smokeSystemMain.scalingMode = ParticleSystemScalingMode.Hierarchy;
				Vector3 localScale = _smokeSystem.transform.localScale;
				_smokeSystem.transform.localScale = new Vector3(localScale.x * base.Engine.ExhaustScale.x, localScale.y * base.Engine.ExhaustScale.y, localScale.z * base.Engine.ExhaustScale.z);
				if (base.Engine.ExhaustStartColorOverridePrimary.HasValue)
				{
					_smokeSystemMain.startColor = base.Engine.ExhaustStartColorOverridePrimary.Value;
				}
				base.Engine.ExhaustStartColorOverridePrimary = _smokeSystemMain.startColor.color;
			}
			_audio = _part.gameObject.GetComponent<AudioSource>();
			if (_audio != null)
			{
				_audioVolume = _audio.volume;
				_audio.volume = 0f;
			}
			if (loadContext == CraftLoadContext.Flight && !string.IsNullOrEmpty(base.Engine.SoundOverride))
			{
				AudioClip audioClip = Resources.Load(base.Engine.SoundOverride) as AudioClip;
				if (audioClip != null)
				{
					_audio.clip = audioClip;
				}
			}
			return UniTask.CompletedTask;
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			float num = 0f;
			if (_part.Aircraft.Fuel > 0f)
			{
				num = Mathf.Clamp(base.EngineThrottle, 0.01f, 1f);
			}
			_audio.volume = Mathf.Lerp(_audio.volume, num * _audioVolume, frame.DeltaTime * base.Engine.ThrottleResponse);
			_audio.pitch = Mathf.Lerp(_audio.pitch, 0.5f + 0.8f * base.EngineThrottle, frame.DeltaTime * base.Engine.ThrottleResponse);
			float num2 = -5000f * base.EngineThrottle / 60f;
			_fan.transform.Rotate(Vector3.forward, 360f * num2 * frame.DeltaTime);
		}
	}
}
