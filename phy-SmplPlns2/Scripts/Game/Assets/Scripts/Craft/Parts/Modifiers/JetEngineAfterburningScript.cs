using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class JetEngineAfterburningScript : EngineScript
	{
		private const float AfterBurnerPercentWhereNormalSmokeIsMinimized = 0.75f;

		private const float AfterBurnerRange = 0.100000024f;

		private const float AfterBurnerStartThrottle = 0.9f;

		private const float MinNormalSmokeVisibility = 0.4f;

		private const float NormalSmokeVisibilityMinThrottle = 0.92499995f;

		private float _afterBurnerPercent;

		private ParticleSystem _afterburningSmokeSystem;

		private ParticleSystem.EmissionModule _afterburningSmokeSystemEmission;

		private ParticleSystem.MainModule _afterburningSmokeSystemMain;

		private float _afterburningSmokeSystemStartLifetime;

		private AudioSource _audio;

		private float _audioVolume;

		private Transform _fan;

		private ParticleSystem _smokeSystem;

		private ParticleSystem.EmissionModule _smokeSystemEmission;

		private ParticleSystem.MainModule _smokeSystemMain;

		private float _smokeSystemStartSize;

		public float AvailableAirIntakeRatio { get; set; }

		public override CraftEngineType EngineType => CraftEngineType.Jet;

		public override float IRSignature
		{
			get
			{
				float num = Mathf.Lerp(1f, 10f, _afterBurnerPercent);
				return base.ThrottleInput.Value * base.Engine.PowerMultiplier * base.Engine.Power * num;
			}
		}

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
				_afterburningSmokeSystemEmission.enabled = false;
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
					float engineThrottle = base.EngineThrottle;
					if (aircraft.Fuel > 0f && engineThrottle > 0f)
					{
						float num2 = AvailableAirIntakeRatio * base.PartScript.Aircraft.AtmosphereSample.AirDensityRatio;
						if (num2 > 1f || base.Engine.RequiredAirIntake == 0f)
						{
							num2 = 1f;
						}
						engineThrottle *= num2;
						if (base.EngineThrottle > 0.9f)
						{
							_afterBurnerPercent = (base.EngineThrottle - 0.9f) / 0.100000024f;
							_afterburningSmokeSystemEmission.enabled = true;
							if (base.EngineThrottle <= 0.92499995f)
							{
								float num3 = (0.92499995f - base.EngineThrottle) / 0.4f;
								_smokeSystemEmission.enabled = true;
								_smokeSystemMain.startSize = Mathf.Clamp(_smokeSystemStartSize * num3, 0.4f, float.MaxValue);
							}
							_afterburningSmokeSystemMain.startLifetime = _afterburningSmokeSystemStartLifetime * _afterBurnerPercent;
						}
						else
						{
							_afterburningSmokeSystemEmission.enabled = false;
							_smokeSystemEmission.enabled = true;
							_smokeSystemMain.startSpeed = base.EngineThrottle * 7f;
							_smokeSystemMain.startSize = _smokeSystemStartSize;
						}
						float amount = engineThrottle * base.Engine.FuelConsumptionRate * Time.fixedDeltaTime;
						aircraft.UseFuel(amount);
						vector = base.CenterOfThrust.forward;
						vector *= engineThrottle * base.Engine.Power;
					}
					else
					{
						_smokeSystemEmission.enabled = false;
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
			if (base.Body != null)
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
			Transform transform2 = Utilities.FindFirstGameObjectMyselfOrChildren("AfterburningEngineSmokeSystem", _part.gameObject).transform;
			base.CenterOfThrust = Utilities.FindFirstGameObjectMyselfOrChildren("CenterOfThrust", _part.gameObject).transform;
			bool flag = loadContext == CraftLoadContext.Flight;
			if (transform != null)
			{
				_smokeSystem = transform.GetComponent<ParticleSystem>();
				_smokeSystemMain = _smokeSystem.main;
				_smokeSystemEmission = _smokeSystem.emission;
				_smokeSystemEmission.enabled = false;
				_smokeSystemStartSize = _smokeSystemMain.startSize.constantMax;
				if (flag && !base.Engine.DuctedThrust)
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
			else
			{
				Debug.LogWarningFormat("No Smoke System Found For Jet Engine: {0}", _part.name);
			}
			if (transform2 != null)
			{
				_afterburningSmokeSystem = transform2.GetComponent<ParticleSystem>();
				_afterburningSmokeSystemMain = _afterburningSmokeSystem.main;
				_afterburningSmokeSystemEmission = _afterburningSmokeSystem.emission;
				_afterburningSmokeSystemEmission.enabled = false;
				_afterburningSmokeSystemStartLifetime = _afterburningSmokeSystemMain.startLifetime.constantMax;
				if (flag && !base.Engine.DuctedThrust)
				{
					_afterburningSmokeSystem.gameObject.SetActive(value: true);
				}
				else
				{
					_afterburningSmokeSystem.gameObject.SetActive(value: false);
				}
				if (base.Engine.ExhaustStartColorOverrideSecondary.HasValue)
				{
					_afterburningSmokeSystemMain.startColor = base.Engine.ExhaustStartColorOverrideSecondary.Value;
				}
				base.Engine.ExhaustStartColorOverrideSecondary = _afterburningSmokeSystemMain.startColor.color;
			}
			else
			{
				Debug.LogWarningFormat("No Afterburning Smoke System Found For Jet Engine: {0}", _part.name);
			}
			if (flag)
			{
				_audio = _part.gameObject.GetComponent<AudioSource>();
				_audioVolume = _audio.volume;
				if (!string.IsNullOrEmpty(base.Engine.SoundOverride))
				{
					AudioClip audioClip = Resources.Load(base.Engine.SoundOverride) as AudioClip;
					if (audioClip != null)
					{
						_audio.clip = audioClip;
					}
				}
			}
			return UniTask.CompletedTask;
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (_audio != null)
			{
				_audio.volume = base.EngineThrottle;
				_audio.pitch = base.EngineThrottle * 1.5f;
			}
			float num = -5000f * base.EngineThrottle / 60f;
			_fan.transform.Rotate(Vector3.forward, 360f * num * frame.DeltaTime);
		}
	}
}
