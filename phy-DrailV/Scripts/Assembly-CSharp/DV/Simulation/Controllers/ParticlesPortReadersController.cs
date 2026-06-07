using System;
using System.Collections;
using System.Collections.Generic;
using DV.Utils;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class ParticlesPortReadersController : ARefreshableChildrenController<AParticlePortReader>
	{
		[Serializable]
		public class ParticlePortReader
		{
			public enum ParticleProperty
			{
				ON_OFF = 0,
				START_LIFETIME = 1,
				START_SIZE = 2,
				START_SPEED = 3,
				MAX_PARTICLES = 4,
				RATE_OVER_TIME = 5,
				START_LIFETIME_MULTIPLIER = 100,
				START_SIZE_MULTIPLIER = 101,
				START_SPEED_MULTIPLIER = 102,
				MAX_PARTICLES_MULTIPLIER = 103,
				RATE_OVER_TIME_MULTIPLIER = 104
			}

			[Serializable]
			public class PropertyChangeDefinition
			{
				public ParticleProperty propertyType;

				public AnimationCurve propertyChangeCurve;
			}

			[Serializable]
			public class PortParticleUpdateDefinition
			{
				[PortId(null, null, false)]
				public string portId;

				public ValueModifier inputModifier;

				public List<PropertyChangeDefinition> propertiesToUpdate;

				[NonSerialized]
				public bool activationConditionFulfilled;

				[NonSerialized]
				private ParticlePortReader ppr;

				public void Init(ParticlePortReader ppr, SimulationFlow simFlow)
				{
					this.ppr = ppr;
					if (!simFlow.TryGetPort(portId, out var port))
					{
						Debug.LogError("PortParticleUpdateDefinition isn't initialized properly.");
						return;
					}
					OnValueUpdate(port.Value);
					port.ValueUpdatedInternally += OnValueUpdate;
				}

				public void Deinit(SimulationFlow simFlow)
				{
					if (!simFlow.TryGetPort(portId, out var port))
					{
						Debug.LogError("PortParticleUpdateDefinition isn't initialized properly.");
					}
					else
					{
						port.ValueUpdatedInternally -= OnValueUpdate;
					}
				}

				public void OnValueUpdate(float newValue)
				{
					if (inputModifier.absoluteInputValue)
					{
						newValue = Mathf.Abs(newValue);
					}
					newValue = newValue * inputModifier.valueMultiplier + inputModifier.valueOffset;
					if (inputModifier.absoluteResultValue)
					{
						newValue = Mathf.Abs(newValue);
					}
					foreach (PropertyChangeDefinition item in propertiesToUpdate)
					{
						float num = item.propertyChangeCurve.Evaluate(newValue);
						switch (item.propertyType)
						{
						case ParticleProperty.ON_OFF:
							activationConditionFulfilled = num > 0f;
							ppr.UpdateParticlesOnOffState();
							break;
						case ParticleProperty.START_LIFETIME:
						{
							ParticleSystemData[] particleSystemsData = ppr.particleSystemsData;
							for (int i = 0; i < particleSystemsData.Length; i++)
							{
								ParticleSystem.MainModule main8 = particleSystemsData[i].ps.main;
								main8.startLifetime = num;
							}
							break;
						}
						case ParticleProperty.START_SIZE:
						{
							ParticleSystemData[] particleSystemsData = ppr.particleSystemsData;
							for (int i = 0; i < particleSystemsData.Length; i++)
							{
								ParticleSystem.MainModule main = particleSystemsData[i].ps.main;
								main.startSize = num;
							}
							break;
						}
						case ParticleProperty.START_SPEED:
						{
							ParticleSystemData[] particleSystemsData = ppr.particleSystemsData;
							for (int i = 0; i < particleSystemsData.Length; i++)
							{
								ParticleSystem.MainModule main6 = particleSystemsData[i].ps.main;
								main6.startSpeed = num;
							}
							break;
						}
						case ParticleProperty.MAX_PARTICLES:
						{
							int maxParticles = (int)num;
							ParticleSystemData[] particleSystemsData = ppr.particleSystemsData;
							for (int i = 0; i < particleSystemsData.Length; i++)
							{
								ParticleSystem.MainModule main3 = particleSystemsData[i].ps.main;
								main3.maxParticles = maxParticles;
							}
							break;
						}
						case ParticleProperty.RATE_OVER_TIME:
						{
							ParticleSystemData[] particleSystemsData = ppr.particleSystemsData;
							for (int i = 0; i < particleSystemsData.Length; i++)
							{
								ParticleSystem.MinMaxCurve rateOverTime = particleSystemsData[i].ps.emission.rateOverTime;
								rateOverTime.constant = num;
							}
							break;
						}
						case ParticleProperty.START_LIFETIME_MULTIPLIER:
						{
							ParticleSystemData[] particleSystemsData = ppr.particleSystemsData;
							foreach (ParticleSystemData particleSystemData5 in particleSystemsData)
							{
								ParticleSystem.MainModule main7 = particleSystemData5.ps.main;
								main7.startLifetime = MultiplyWithMinMaxCurve(particleSystemData5.initialStartLifetime, num);
							}
							break;
						}
						case ParticleProperty.START_SIZE_MULTIPLIER:
						{
							ParticleSystemData[] particleSystemsData = ppr.particleSystemsData;
							foreach (ParticleSystemData particleSystemData4 in particleSystemsData)
							{
								ParticleSystem.MainModule main5 = particleSystemData4.ps.main;
								main5.startSize = MultiplyWithMinMaxCurve(particleSystemData4.initialStartSize, num);
							}
							break;
						}
						case ParticleProperty.START_SPEED_MULTIPLIER:
						{
							ParticleSystemData[] particleSystemsData = ppr.particleSystemsData;
							foreach (ParticleSystemData particleSystemData3 in particleSystemsData)
							{
								ParticleSystem.MainModule main4 = particleSystemData3.ps.main;
								main4.startSpeed = MultiplyWithMinMaxCurve(particleSystemData3.initialStartSpeed, num);
							}
							break;
						}
						case ParticleProperty.MAX_PARTICLES_MULTIPLIER:
						{
							int num2 = Mathf.RoundToInt(num);
							ParticleSystemData[] particleSystemsData = ppr.particleSystemsData;
							foreach (ParticleSystemData particleSystemData2 in particleSystemsData)
							{
								ParticleSystem.MainModule main2 = particleSystemData2.ps.main;
								main2.maxParticles = particleSystemData2.initialMaxParticles * num2;
							}
							break;
						}
						case ParticleProperty.RATE_OVER_TIME_MULTIPLIER:
						{
							ParticleSystemData[] particleSystemsData = ppr.particleSystemsData;
							foreach (ParticleSystemData particleSystemData in particleSystemsData)
							{
								ParticleSystem.EmissionModule emission = particleSystemData.ps.emission;
								emission.rateOverTime = MultiplyWithMinMaxCurve(particleSystemData.initialRateOverTime, num);
							}
							break;
						}
						default:
							Debug.LogError(string.Format("Unexpected state: Invalid {0}: {1}. Ignoring request!", "ParticleProperty", item.propertyType), ppr.particlesParent);
							break;
						}
					}
				}
			}

			[NonSerialized]
			public ParticlesPortReadersController particlesPortReader;

			public GameObject particlesParent;

			private ParticleSystemData[] particleSystemsData;

			private Coroutine turnOffCoro;

			public List<PortParticleUpdateDefinition> particleUpdaters;

			public void Init()
			{
				ParticleSystem[] componentsInChildren = particlesParent.GetComponentsInChildren<ParticleSystem>();
				if (componentsInChildren.Length == 0)
				{
					Debug.LogError("Unexpected state: No particle systems found on particlesParent: " + particlesParent.name);
				}
				particleSystemsData = new ParticleSystemData[componentsInChildren.Length];
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					particleSystemsData[i] = new ParticleSystemData(componentsInChildren[i]);
				}
			}

			public void SetInheritVelocityMultiplier(bool paused)
			{
				ParticleSystemData[] array = particleSystemsData;
				foreach (ParticleSystemData particleSystemData in array)
				{
					ParticleSystem.InheritVelocityModule inheritVelocity = particleSystemData.ps.inheritVelocity;
					inheritVelocity.curveMultiplier = (paused ? 0f : particleSystemData.initialVelMult);
				}
			}

			public void OnDisable()
			{
				if (turnOffCoro != null)
				{
					particlesPortReader.StopCoroutine(turnOffCoro);
				}
				turnOffCoro = null;
			}

			private void UpdateParticlesOnOffState()
			{
				bool flag = true;
				foreach (PortParticleUpdateDefinition particleUpdater in particleUpdaters)
				{
					foreach (PropertyChangeDefinition item in particleUpdater.propertiesToUpdate)
					{
						if (item.propertyType == ParticleProperty.ON_OFF)
						{
							flag = flag && particleUpdater.activationConditionFulfilled;
							if (!flag)
							{
								break;
							}
						}
					}
					if (!flag)
					{
						break;
					}
				}
				bool isActiveGO = particleSystemsData[0].IsActiveGO;
				bool isPlaying = particleSystemsData[0].ps.isPlaying;
				if (flag == isActiveGO && flag == isPlaying && (!flag || turnOffCoro == null))
				{
					return;
				}
				if (flag)
				{
					if (turnOffCoro != null)
					{
						particlesPortReader.StopCoroutine(turnOffCoro);
						turnOffCoro = null;
					}
					ParticleSystemData[] array = particleSystemsData;
					for (int i = 0; i < array.Length; i++)
					{
						ParticleSystem ps = array[i].ps;
						ps.gameObject.SetActive(value: true);
						ps.Play();
					}
				}
				else if (turnOffCoro == null)
				{
					turnOffCoro = particlesPortReader.StartCoroutine(TurnOffPS());
					ParticleSystemData[] array = particleSystemsData;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].ps.Stop();
					}
				}
			}

			private IEnumerator TurnOffPS()
			{
				ParticleSystemData[] array;
				while (true)
				{
					bool flag = false;
					array = particleSystemsData;
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i].ps.IsAlive())
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						break;
					}
					yield return null;
				}
				array = particleSystemsData;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].ps.gameObject.SetActive(value: false);
				}
				turnOffCoro = null;
			}
		}

		[Serializable]
		public class ParticleColorPortReader
		{
			public enum ColorPropertyChange
			{
				ALL = 0,
				RGB_ONLY = 1,
				ALPHA_ONLY = 2
			}

			public GameObject particlesParent;

			private ParticleSystem[] particleSystems;

			[PortId(null, null, false)]
			public string portId;

			public ValueModifier inputModifier;

			public ColorPropertyChange changeType;

			public Color startColorMin;

			public Color startColorMax;

			public AnimationCurve colorLerpCurve;

			public void Init(SimulationFlow simFlow)
			{
				if (!simFlow.TryGetPort(portId, out var port))
				{
					Debug.LogError("ParticleColorPortReader isn't initialized properly.");
					return;
				}
				particleSystems = particlesParent.GetComponentsInChildren<ParticleSystem>();
				if (particleSystems.Length == 0)
				{
					Debug.LogError("Unexpected state: No particle systems found on particlesParent: " + particlesParent.name);
				}
				OnValueUpdate(port.Value);
				port.ValueUpdatedInternally += OnValueUpdate;
			}

			public void Deinit(SimulationFlow simFlow)
			{
				if (!simFlow.TryGetPort(portId, out var port))
				{
					Debug.LogError("ParticleColorPortReader isn't initialized properly.");
				}
				else
				{
					port.ValueUpdatedInternally -= OnValueUpdate;
				}
			}

			public void OnValueUpdate(float newValue)
			{
				if (inputModifier.absoluteInputValue)
				{
					newValue = Mathf.Abs(newValue);
				}
				newValue = newValue * inputModifier.valueMultiplier + inputModifier.valueOffset;
				if (inputModifier.absoluteResultValue)
				{
					newValue = Mathf.Abs(newValue);
				}
				float t = colorLerpCurve.Evaluate(newValue);
				Color color = Color.Lerp(startColorMin, startColorMax, t);
				ParticleSystem[] array = particleSystems;
				for (int i = 0; i < array.Length; i++)
				{
					ParticleSystem.MainModule main = array[i].main;
					switch (changeType)
					{
					case ColorPropertyChange.ALL:
						main.startColor = color;
						break;
					case ColorPropertyChange.RGB_ONLY:
					{
						float a = main.startColor.color.a;
						main.startColor = new Color(color.r, color.g, color.b, a);
						break;
					}
					case ColorPropertyChange.ALPHA_ONLY:
					{
						Color color2 = main.startColor.color;
						main.startColor = new Color(color2.r, color2.g, color2.b, color.a);
						break;
					}
					}
				}
			}
		}

		[Serializable]
		public class ValueModifier
		{
			public float valueMultiplier = 1f;

			public float valueOffset;

			public bool absoluteInputValue;

			public bool absoluteResultValue;
		}

		public List<ParticlePortReader> particlePortReaders;

		public List<ParticleColorPortReader> particleColorPortReaders;

		public bool selfInitialization;

		private SimulationFlow simFlow;

		private void Start()
		{
			if (selfInitialization)
			{
				SimulationFlow simulationFlow = TrainCar.Resolve(base.transform)?.SimController?.simFlow;
				if (simulationFlow == null)
				{
					Debug.LogError("Couldn't find sf, ignoring ParticlesPortReadersController initialization!");
				}
				else
				{
					Init(simulationFlow);
				}
			}
		}

		public void Init(SimulationFlow simFlow)
		{
			this.simFlow = simFlow;
			AParticlePortReader[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Init(simFlow);
			}
			foreach (ParticlePortReader particlePortReader in particlePortReaders)
			{
				particlePortReader.Init();
				particlePortReader.particlesPortReader = this;
				foreach (ParticlePortReader.PortParticleUpdateDefinition particleUpdater in particlePortReader.particleUpdaters)
				{
					particleUpdater.Init(particlePortReader, simFlow);
				}
			}
			foreach (ParticleColorPortReader particleColorPortReader in particleColorPortReaders)
			{
				particleColorPortReader.Init(simFlow);
			}
			SingletonBehaviour<AppUtil>.Instance.GamePauseRequested += GamePauseRequested;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused += GameUnpaused;
		}

		private void GameUnpaused()
		{
			foreach (ParticlePortReader particlePortReader in particlePortReaders)
			{
				particlePortReader.SetInheritVelocityMultiplier(paused: false);
			}
		}

		private void GamePauseRequested()
		{
			foreach (ParticlePortReader particlePortReader in particlePortReaders)
			{
				particlePortReader.SetInheritVelocityMultiplier(paused: true);
			}
		}

		private void OnDisable()
		{
			foreach (ParticlePortReader particlePortReader in particlePortReaders)
			{
				particlePortReader.OnDisable();
			}
		}

		private void OnDestroy()
		{
			if (simFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, ignoring ParticlesPortReadersController deinitialization!");
				return;
			}
			AParticlePortReader[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deinit();
			}
			foreach (ParticlePortReader particlePortReader in particlePortReaders)
			{
				foreach (ParticlePortReader.PortParticleUpdateDefinition particleUpdater in particlePortReader.particleUpdaters)
				{
					particleUpdater.Deinit(simFlow);
				}
			}
			foreach (ParticleColorPortReader particleColorPortReader in particleColorPortReaders)
			{
				particleColorPortReader.Deinit(simFlow);
			}
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<AppUtil>.Instance.GamePauseRequested -= GamePauseRequested;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= GameUnpaused;
			}
		}

		public static ParticleSystem.MinMaxCurve MultiplyWithMinMaxCurve(ParticleSystem.MinMaxCurve minMaxCurve, float multiplier)
		{
			switch (minMaxCurve.mode)
			{
			case ParticleSystemCurveMode.Constant:
				minMaxCurve.constant *= multiplier;
				break;
			case ParticleSystemCurveMode.Curve:
			case ParticleSystemCurveMode.TwoCurves:
				minMaxCurve.curveMultiplier = multiplier;
				break;
			case ParticleSystemCurveMode.TwoConstants:
				minMaxCurve.constantMin *= multiplier;
				minMaxCurve.constantMax *= multiplier;
				break;
			default:
				Debug.LogError(string.Format("Unhandled {0} {1}", "MinMaxCurve", minMaxCurve));
				break;
			}
			return minMaxCurve;
		}
	}
}
