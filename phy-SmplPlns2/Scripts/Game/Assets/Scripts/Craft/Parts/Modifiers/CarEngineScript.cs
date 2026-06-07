using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Misc.SimpleBehaviours;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CarEngineScript : PartModifierScript, IRpmSource, IVariableOutput, ICraftEngine
	{
		private InputControllerScript _controller;

		private bool _disableAudio;

		private AudioSource _audio;

		private float _engineRpm;

		private float _maxRpm;

		private float _maxTorque;

		private int _numWheels;

		private AnimationCurveScript _rpmCurve;

		private List<ICarEngineWheel> _wheels = new List<ICarEngineWheel>();

		public CarEngineData CarEngine { get; set; }

		public bool EngineDestroyed { get; set; }

		public float EngineThrottle { get; set; }

		public float EngineThrottleMax { get; set; }

		public CraftEngineType EngineType => CraftEngineType.InternalCombustion;

		public float IRSignature => EngineThrottle * CarEngine.Power * 0.5f;

		public IPowertrain Powertrain => null;

		[VariableOutput("RPM")]
		public float ReportedRpm => _engineRpm;

		public int ReportedRpmPriority => 0;

		public PartScript ReportingPartScript => base.PartScript;

		public string ThrottleActivationGroup => _controller.InputController.ActivationGroup;

		public string ThrottleInput => _controller.InputController.Input;

		public void AddWheel(ICarEngineWheel wheel)
		{
			_wheels.Add(wheel);
			_numWheels = _wheels.Count;
		}

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level == PartDamageLevel.Moderate)
			{
				base.PartScript.Aircraft.DamageEffects.CreateFire(base.PartScript, null);
			}
			if (!EngineDestroyed)
			{
				if (Random.value < 0.3f * (float)level)
				{
					EngineDestroyed = true;
					return;
				}
				CarEngine.FuelConsumptionRate *= 10f;
				EngineThrottleMax *= 0.25f;
			}
		}

		public void RemoveWheel(ICarEngineWheel wheel)
		{
			if (_wheels.Contains(wheel))
			{
				wheel.SetEngineTorque(0f);
				_wheels.Remove(wheel);
				_numWheels = _wheels.Count;
			}
		}

		public void UpdateOutputs()
		{
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightUnpaused);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private float GetTorqueAtRpm(float rpm)
		{
			float time = Mathf.Clamp01(rpm / _maxRpm);
			return _rpmCurve.AnimationCurve.Evaluate(time) * _maxTorque;
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (base.PartModifier.UsedInPropMode)
			{
				return;
			}
			_disableAudio = false;
			if (frame.Craft.Fuel <= 0f || base.PartScript.EstimateOfUnderwaterPercent > 0.8f || EngineDestroyed)
			{
				_disableAudio = true;
				EngineThrottle = 0f;
			}
			else
			{
				EngineThrottle = Mathf.Min(Utilities.StepTowards(EngineThrottle, Time.fixedDeltaTime * CarEngine.ThrottleResponse, _controller.Value), EngineThrottleMax);
				if (frame.Craft.Fuel > 0f && EngineThrottle != 0f)
				{
					float amount = Mathf.Abs(EngineThrottle) * CarEngine.FuelConsumptionRate * Time.fixedDeltaTime;
					frame.Craft.UseFuel(amount);
				}
			}
			float num = 0f;
			if (_numWheels > 0)
			{
				float a = 0f;
				float num2 = 0f;
				for (int i = 0; i < _wheels.Count; i++)
				{
					num2 += _wheels[i].Rpm;
					a = Mathf.Max(a, _wheels[i].Rpm);
				}
				num = num2 / (float)_wheels.Count;
				float step = Time.deltaTime * 1000f;
				_engineRpm = Utilities.StepTowards(_engineRpm, step, num);
				float engineTorque = GetTorqueAtRpm(_engineRpm) * EngineThrottle / (float)_numWheels;
				for (int j = 0; j < _wheels.Count; j++)
				{
					_wheels[j].SetEngineTorque(engineTorque);
				}
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_controller = base.PartScript.GetModifier<InputControllerScript>();
			if (loadContext == CraftLoadContext.Flight)
			{
				_audio = base.PartScript.GetComponent<AudioSource>();
				_audio.maxDistance = 100f + 0.5f * CarEngine.Power;
				_maxTorque = CarEngine.Power * 15f * 0.01f;
				_rpmCurve = base.PartScript.GetComponent<AnimationCurveScript>();
				_maxRpm = 1500f;
				EngineThrottleMax = _controller.InputController.MaxValue;
			}
			return UniTask.CompletedTask;
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (!(_audio != null))
			{
				return;
			}
			float num = Mathf.Abs(EngineThrottle);
			if (num > 0.1f && !_audio.isPlaying)
			{
				_audio.Play();
				_audio.timeSamples = (int)(Random.value * (float)_audio.clip.samples);
			}
			if (_audio.isPlaying)
			{
				float num2 = Mathf.Clamp01(_engineRpm / _maxRpm);
				_audio.pitch = Mathf.Lerp(_audio.pitch, Mathf.Lerp(0.6f, 1.5f, num2 * num), frame.DeltaTime);
				float b = Mathf.Clamp01((400f + CarEngine.Power) * 0.001f) * ((_disableAudio ? 0f : 0.5f) + 0.5f * Mathf.Sqrt(num));
				_audio.volume = Mathf.Lerp(_audio.volume, b, frame.DeltaTime);
				if (_audio.volume < 0.01f)
				{
					_audio.Stop();
				}
			}
		}
	}
}
