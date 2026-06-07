using System.Collections;
using System.Collections.Generic;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class SteamSmokeParticlePortReader : AParticlePortReader
	{
		[PortId(PortValueType.STATE, false)]
		public string fireOnPortId;

		[PortId(PortValueType.STATE, false)]
		public string chuffEventPortId;

		[PortId(PortValueType.STATE, false)]
		public string isBoilerBrokenPortId;

		[PortId(PortValueType.PRESSURE, false)]
		public string exhaustPressurePortId;

		[Header("Smoke particles")]
		public GameObject smokeParticlesParent;

		public AnimationCurve smokeStartSpeedMultiplier;

		public AnimationCurve smokeEmissionRateMultiplier;

		public AnimationCurve smokeMaxParticlesMultiplier;

		[Header("Ember particles")]
		public GameObject emberParticlesParent;

		public AnimationCurve emberStartSpeedMultiplier;

		public AnimationCurve emberEmissionRateMultiplier;

		public AnimationCurve emberMaxParticlesMultiplier;

		private ParticleSystemData[] smokeParticleSystemsData;

		private ParticleSystemData[] emberParticleSystemsData;

		private List<ParticleSystemData> allParticlesSystemsData;

		private Port fireOnPort;

		private Port chuffEventPort;

		private Port isBoilerBrokenPort;

		private Port exhaustPressurePort;

		private bool allParticlesStopped;

		private bool nextChuffQueued;

		private Coroutine chuffCoro;

		private Coroutine stopAllCoro;

		private float NormalizedPressureApplied => Mathf.InverseLerp(1f, 10f, exhaustPressurePort.Value);

		public override void Init(SimulationFlow simFlow)
		{
			if (!simFlow.TryGetPort(fireOnPortId, out fireOnPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: SteamSmokeParticlePortReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(chuffEventPortId, out chuffEventPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: SteamSmokeParticlePortReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(isBoilerBrokenPortId, out isBoilerBrokenPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: SteamSmokeParticlePortReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(exhaustPressurePortId, out exhaustPressurePort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: SteamSmokeParticlePortReader not initialized properly");
				return;
			}
			ParticleSystem[] componentsInChildren = smokeParticlesParent.GetComponentsInChildren<ParticleSystem>();
			smokeParticleSystemsData = new ParticleSystemData[componentsInChildren.Length];
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				smokeParticleSystemsData[i] = new ParticleSystemData(componentsInChildren[i]);
			}
			ParticleSystem[] array = emberParticlesParent?.GetComponentsInChildren<ParticleSystem>();
			emberParticleSystemsData = new ParticleSystemData[array.Length];
			for (int j = 0; j < array.Length; j++)
			{
				emberParticleSystemsData[j] = new ParticleSystemData(array[j]);
			}
			allParticlesSystemsData = new List<ParticleSystemData>();
			allParticlesSystemsData.AddRange(smokeParticleSystemsData);
			allParticlesSystemsData.AddRange(emberParticleSystemsData);
			UpdateParticles(isChuffEvent: false);
			fireOnPort.ValueUpdatedInternally += OnFireChanged;
			chuffEventPort.ValueUpdatedInternally += OnChuffEvent;
			isBoilerBrokenPort.ValueUpdatedInternally += OnBoilerBrokenChanged;
		}

		public override void Deinit()
		{
			fireOnPort.ValueUpdatedInternally -= OnFireChanged;
			chuffEventPort.ValueUpdatedInternally -= OnChuffEvent;
			isBoilerBrokenPort.ValueUpdatedInternally -= OnBoilerBrokenChanged;
		}

		private void UpdateParticles(bool isChuffEvent)
		{
			bool flag = fireOnPort.Value > 0f;
			float value = exhaustPressurePort.Value;
			bool num = isBoilerBrokenPort.Value > 0f;
			bool flag2 = isChuffEvent && value > 1f;
			if (num || (!flag && !flag2))
			{
				if (stopAllCoro == null && !allParticlesStopped)
				{
					stopAllCoro = StartCoroutine(StopAllCoro());
				}
				return;
			}
			if (flag2)
			{
				allParticlesStopped = false;
				if (stopAllCoro != null)
				{
					StopCoroutine(stopAllCoro);
					stopAllCoro = null;
				}
				if (chuffCoro == null)
				{
					chuffCoro = StartCoroutine(ChuffCoro());
				}
				else
				{
					nextChuffQueued = true;
				}
			}
			if (flag)
			{
				allParticlesStopped = false;
				if (stopAllCoro != null)
				{
					StopCoroutine(stopAllCoro);
					stopAllCoro = null;
				}
			}
			if (chuffCoro != null)
			{
				return;
			}
			ParticleSystemData[] array = smokeParticleSystemsData;
			foreach (ParticleSystemData particleSystemData in array)
			{
				ParticleSystem ps = particleSystemData.ps;
				if (flag)
				{
					if (!ps.isEmitting)
					{
						ps.gameObject.SetActive(value: true);
						ps.Play();
					}
					SetParticleParams(particleSystemData, smokeStartSpeedMultiplier, smokeEmissionRateMultiplier, smokeMaxParticlesMultiplier, 0f);
				}
				else if (ps.isEmitting)
				{
					ps.Stop();
				}
				else if (ps.gameObject.activeInHierarchy && !ps.IsAlive())
				{
					ps.gameObject.SetActive(value: false);
				}
			}
			array = emberParticleSystemsData;
			for (int i = 0; i < array.Length; i++)
			{
				ParticleSystem ps2 = array[i].ps;
				if (ps2.isEmitting)
				{
					ps2.Stop();
				}
				else if (ps2.gameObject.activeInHierarchy && !ps2.IsAlive())
				{
					ps2.gameObject.SetActive(value: false);
				}
			}
		}

		private IEnumerator ChuffCoro()
		{
			nextChuffQueued = true;
			while (nextChuffQueued)
			{
				float normalizedPressureApplied = NormalizedPressureApplied;
				ParticleSystemData[] array = smokeParticleSystemsData;
				foreach (ParticleSystemData particleSystemData in array)
				{
					ParticleSystem ps = particleSystemData.ps;
					if (!ps.isEmitting)
					{
						ps.gameObject.SetActive(value: true);
						ps.Play();
					}
					SetParticleParams(particleSystemData, smokeStartSpeedMultiplier, smokeEmissionRateMultiplier, smokeMaxParticlesMultiplier, normalizedPressureApplied);
				}
				bool flag = fireOnPort.Value > 0f;
				array = emberParticleSystemsData;
				foreach (ParticleSystemData particleSystemData2 in array)
				{
					ParticleSystem ps2 = particleSystemData2.ps;
					if (flag)
					{
						if (!ps2.isEmitting)
						{
							ps2.gameObject.SetActive(value: true);
							ps2.Play();
						}
						SetParticleParams(particleSystemData2, emberStartSpeedMultiplier, emberEmissionRateMultiplier, emberMaxParticlesMultiplier, normalizedPressureApplied);
					}
					else if (ps2.isEmitting)
					{
						ps2.Stop();
					}
					else if (ps2.gameObject.activeInHierarchy && !ps2.IsAlive())
					{
						ps2.gameObject.SetActive(value: false);
					}
				}
				nextChuffQueued = false;
				yield return WaitFor.Seconds(0.1f);
			}
			chuffCoro = null;
			UpdateParticles(isChuffEvent: false);
		}

		private void SetParticleParams(ParticleSystemData psd, AnimationCurve startSpeedCurve, AnimationCurve emissionRateCurve, AnimationCurve maxParticlesCurve, float normalizedPressureApplied)
		{
			ParticleSystem ps = psd.ps;
			float multiplier = startSpeedCurve.Evaluate(normalizedPressureApplied);
			ParticleSystem.MainModule main = ps.main;
			main.startSpeed = ParticlesPortReadersController.MultiplyWithMinMaxCurve(psd.initialStartSpeed, multiplier);
			float multiplier2 = emissionRateCurve.Evaluate(normalizedPressureApplied);
			ParticleSystem.EmissionModule emission = ps.emission;
			emission.rateOverTime = ParticlesPortReadersController.MultiplyWithMinMaxCurve(psd.initialRateOverTime, multiplier2);
			float num = maxParticlesCurve.Evaluate(normalizedPressureApplied);
			main.maxParticles = Mathf.RoundToInt((float)psd.initialMaxParticles * num);
		}

		private IEnumerator StopAllCoro()
		{
			while (true)
			{
				bool flag = true;
				foreach (ParticleSystemData allParticlesSystemsDatum in allParticlesSystemsData)
				{
					ParticleSystem ps = allParticlesSystemsDatum.ps;
					if (ps.isEmitting)
					{
						ps.Stop();
						flag = false;
					}
					else if (ps.gameObject.activeInHierarchy && !ps.IsAlive())
					{
						ps.gameObject.SetActive(value: false);
					}
					else
					{
						flag = false;
					}
				}
				if (flag)
				{
					break;
				}
				yield return WaitFor.Seconds(0.1f);
			}
			stopAllCoro = null;
			allParticlesStopped = true;
		}

		private void OnBoilerBrokenChanged(float newBoilerBroken)
		{
			UpdateParticles(isChuffEvent: false);
		}

		private void OnFireChanged(float obj)
		{
			UpdateParticles(isChuffEvent: false);
		}

		private void OnChuffEvent(float obj)
		{
			UpdateParticles(isChuffEvent: true);
		}
	}
}
