using System;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class CylinderCockParticlePortReader : AParticlePortReader
	{
		[Serializable]
		public class CylinderSetup
		{
			public GameObject frontParticlesParent;

			public AnimationCurve frontActivityCurve;

			[NonSerialized]
			public ParticleSystemData[] frontParticlesData;

			public GameObject rearParticlesParent;

			public AnimationCurve rearActivityCurve;

			[NonSerialized]
			public ParticleSystemData[] rearParticlesData;
		}

		[PortId(PortValueType.STATE, false)]
		public string crankRotationPortId;

		[PortId(PortValueType.CONTROL, false)]
		public string reverserPortId;

		[PortId(PortValueType.STATE, false)]
		public string cylindersInletValveOpenPortId;

		[PortId(PortValueType.STATE, false)]
		public string cylinderCockFlowNormalizedPortId;

		[PortId(PortValueType.GENERIC, false)]
		public string forwardSpeedPortId;

		public CylinderSetup[] cylinderSetups;

		public float startSpeedMultiplierMin;

		public float startSpeedMultiplierMax;

		public float startSizeMultiplierMin;

		public float startSizeMultiplierMax;

		public float emissionRateMultiplierMin;

		public float emissionRateMultiplierMax;

		public float emissionRateMaxSpeedKmh = 60f;

		private Port crankRotationPort;

		private Port reverserPort;

		private Port cylindersInletValveOpenPort;

		private Port cylinderCockFlowNormalizedPort;

		private Port forwardSpeedPort;

		public override void Init(SimulationFlow simFlow)
		{
			if (!simFlow.TryGetPort(crankRotationPortId, out crankRotationPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: CylinderCockParticlePortReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(reverserPortId, out reverserPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: CylinderCockParticlePortReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(cylindersInletValveOpenPortId, out cylindersInletValveOpenPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: CylinderCockParticlePortReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(cylinderCockFlowNormalizedPortId, out cylinderCockFlowNormalizedPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: CylinderCockParticlePortReader not initialized properly");
				return;
			}
			if (!simFlow.TryGetPort(forwardSpeedPortId, out forwardSpeedPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: CylinderCockParticlePortReader not initialized properly");
				return;
			}
			CylinderSetup[] array = cylinderSetups;
			foreach (CylinderSetup cylinderSetup in array)
			{
				ParticleSystem[] componentsInChildren = cylinderSetup.frontParticlesParent.GetComponentsInChildren<ParticleSystem>();
				cylinderSetup.frontParticlesData = new ParticleSystemData[componentsInChildren.Length];
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					cylinderSetup.frontParticlesData[j] = new ParticleSystemData(componentsInChildren[j]);
				}
				ParticleSystem[] componentsInChildren2 = cylinderSetup.rearParticlesParent.GetComponentsInChildren<ParticleSystem>();
				cylinderSetup.rearParticlesData = new ParticleSystemData[componentsInChildren2.Length];
				for (int k = 0; k < componentsInChildren2.Length; k++)
				{
					cylinderSetup.rearParticlesData[k] = new ParticleSystemData(componentsInChildren2[k]);
				}
				if (cylinderSetup.frontParticlesData.Length == 0 || cylinderSetup.rearParticlesData.Length == 0)
				{
					Debug.LogError("Unexpected state: frontParticlesParent: " + cylinderSetup.frontParticlesParent.name + " or rearParticlesParent: " + cylinderSetup.frontParticlesParent.name + " don't contain any particle systems");
				}
			}
			crankRotationPort.ValueUpdatedInternally += UpdateCylCockParticles;
			reverserPort.ValueUpdatedInternally += UpdateCylCockParticles;
			cylinderCockFlowNormalizedPort.ValueUpdatedInternally += UpdateCylCockParticles;
		}

		public override void Deinit()
		{
			crankRotationPort.ValueUpdatedInternally -= UpdateCylCockParticles;
			reverserPort.ValueUpdatedInternally -= UpdateCylCockParticles;
			cylinderCockFlowNormalizedPort.ValueUpdatedInternally -= UpdateCylCockParticles;
			crankRotationPort = null;
			reverserPort = null;
			cylinderCockFlowNormalizedPort = null;
		}

		private void UpdateCylCockParticles(float crankRotation)
		{
			float cylCockFlow = cylinderCockFlowNormalizedPort.Value;
			bool flag = reverserPort.Value >= 0f;
			for (int i = 0; i < cylinderSetups.Length; i++)
			{
				bool isInletValveOpen = (Mathf.RoundToInt(cylindersInletValveOpenPort.Value) & (1 << i)) > 0;
				CylinderSetup cylinderSetup = cylinderSetups[i];
				HandleParticles(cylinderSetup.frontParticlesData, flag ? (cylinderSetup.frontActivityCurve.Evaluate(crankRotation) > 0f) : (cylinderSetup.rearActivityCurve.Evaluate(crankRotation) > 0f));
				HandleParticles(cylinderSetup.rearParticlesData, flag ? (cylinderSetup.rearActivityCurve.Evaluate(crankRotation) > 0f) : (cylinderSetup.frontActivityCurve.Evaluate(crankRotation) > 0f));
				void HandleParticles(ParticleSystemData[] particleSystemsData, bool isInActiveRange)
				{
					bool flag2 = isInActiveRange && isInletValveOpen && cylCockFlow > 0.01f;
					foreach (ParticleSystemData particleSystemData in particleSystemsData)
					{
						ParticleSystem ps = particleSystemData.ps;
						if (flag2)
						{
							if (!ps.isEmitting)
							{
								ps.gameObject.SetActive(value: true);
								ps.Play();
							}
							ParticleSystem.MainModule main = ps.main;
							float multiplier = Mathf.Lerp(startSpeedMultiplierMin, startSpeedMultiplierMax, cylCockFlow);
							main.startSpeed = ParticlesPortReadersController.MultiplyWithMinMaxCurve(particleSystemData.initialStartSpeed, multiplier);
							float multiplier2 = Mathf.Lerp(startSizeMultiplierMin, startSizeMultiplierMax, cylCockFlow);
							main.startSize = ParticlesPortReadersController.MultiplyWithMinMaxCurve(particleSystemData.initialStartSize, multiplier2);
							float multiplier3 = Mathf.Lerp(emissionRateMultiplierMin, emissionRateMultiplierMax, Mathf.Clamp01(Mathf.Abs(forwardSpeedPort.Value) / (emissionRateMaxSpeedKmh * (5f / 18f))));
							ParticleSystem.EmissionModule emission = ps.emission;
							emission.rateOverTime = ParticlesPortReadersController.MultiplyWithMinMaxCurve(particleSystemData.initialRateOverTime, multiplier3);
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
				}
			}
		}
	}
}
