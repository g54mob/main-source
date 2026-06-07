using System;
using System.Collections.Generic;
using DV.JObjectExtstensions;
using DV.ThingTypes;
using DV.Wheels;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Damage
{
	public class DamageController : MonoBehaviour
	{
		public delegate void PowerTrainOffDueCollision(TrainCar car);

		private const string BODY_HP_SAVE_KEY = "bodyHP";

		private const string WHEELS_HP_SAVE_KEY = "wheelsHP";

		private const string MECHANICAL_POWERTRAIN_HP_SAVE_KEY = "mechanicalPT";

		private const string ELECTRICAL_POWERTRAIN_HP_SAVE_KEY = "electricalPT";

		private const string WINDOWS_BROKEN_SAVE_KEY = "windowsBroken";

		private const float WHEELSLIP_DMG_PER_S = 10f;

		private const float WHEELSLIDE_DMG_PER_S = 4f;

		private const float WHEEL_COLLISION_DMG_MULTIPLIER = 0.01f;

		private const float WHEEL_FIRE_DMG_MULTIPLIER = 0.01f;

		private const float WHEEL_DERAIL_DMG_PERCENTAGE = 0.05f;

		private const float BRAKING_BOGIE_DMG_PER_S = 0.33f;

		private const float STRESS_BOGIE_DMG_PER_S = 0.03f;

		private const float MECHANICAL_POWERTRAIN_COLLISION_DMG_MULTIPLIER = 0.15f;

		private const float MECHANICAL_POWERTRAIN_OFF_COLLISION_DAMAGE_THRESHOLD = 100f;

		private const float MECHANICAL_POWERTRAIN_FIRE_DMG_MULTIPLIER = 0.1f;

		private const float ELECTRICAL_POWERTRAIN_COLLISION_DMG_MULTIPLIER = 0.15f;

		private const float ELECTRICAL_POWERTRAIN_OFF_COLLISION_DAMAGE_THRESHOLD = 100f;

		private const float ELECTRICAL_POWERTRAIN_FIRE_DMG_MULTIPLIER = 0.1f;

		public AnimationCurve speedToBrakeDamageCurve;

		[NonSerialized]
		public CarDamageModel bodyDamage;

		[NonSerialized]
		public TrainDamage wheels;

		[NonSerialized]
		public TrainDamage mechanicalPT;

		[NonSerialized]
		public TrainDamage electricalPT;

		[Header("Windows - set to null if unused")]
		public WindowsBreakingController windows;

		[Header("Simulation")]
		[PortId(PortValueType.DAMAGE, false)]
		public string[] bodyDamagerPortIds;

		[PortId(PortType.EXTERNAL_IN, PortValueType.STATE, false)]
		public string[] bodyHealthStateExternalInPortIds;

		[PortId(PortValueType.DAMAGE, false)]
		public string[] mechanicalPTDamagerPortIds;

		[PortId(PortValueType.DAMAGE, false)]
		public string[] mechanicalPTPercentualDamagerPortIds;

		[PortId(PortType.EXTERNAL_IN, PortValueType.STATE, false)]
		public string[] mechanicalPTHealthStateExternalInPortIds;

		[PortId(PortType.EXTERNAL_IN, PortValueType.STATE, false)]
		public string[] mechanicalPTOffExternalInPortIds;

		[PortId(PortValueType.DAMAGE, false)]
		public string[] electricalPTDamagerPortIds;

		[PortId(PortType.EXTERNAL_IN, PortValueType.STATE, false)]
		public string[] electricalPTHealthStateExternalInPortIds;

		[PortId(PortType.EXTERNAL_IN, PortValueType.STATE, false)]
		public string[] electricalPTOffExternalInPortIds;

		private List<Port> bodyDamagerPorts;

		private List<Port> bodyHealthStateExternalInPorts;

		private List<Port> mechanicalPTDamagerPorts;

		private List<Port> mechanicalPTPercentualDamagerPorts;

		private List<Port> mechanicalPTHealthStateExternalInPorts;

		private List<Port> mechanicalPTOffExternalInPorts;

		private List<Port> electricalPTDamagerPorts;

		private List<Port> electricalPTHealthStateExternalInPorts;

		private List<Port> electricalPTOffExternalInPorts;

		private TrainCar train;

		private TrainStress trainStress;

		private GameParams gameParams;

		public bool IsFullyRepaired
		{
			get
			{
				if (bodyDamage.currentHealth == bodyDamage.maxHealth && (wheels == null || wheels.CurrentHitPoints == wheels.fullHitPoints) && (mechanicalPT == null || mechanicalPT.CurrentHitPoints == mechanicalPT.fullHitPoints))
				{
					if (electricalPT != null)
					{
						return electricalPT.CurrentHitPoints == electricalPT.fullHitPoints;
					}
					return true;
				}
				return false;
			}
		}

		public event PowerTrainOffDueCollision MechanicalPTOffDueCollision;

		public event PowerTrainOffDueCollision ElectricalPTOffDueCollision;

		public bool IsRepairedAbovePercentage(float percentage)
		{
			if (bodyDamage.currentHealth > bodyDamage.maxHealth * percentage && (wheels == null || wheels.CurrentHitPoints > wheels.fullHitPoints * percentage) && (mechanicalPT == null || mechanicalPT.CurrentHitPoints > mechanicalPT.fullHitPoints * percentage))
			{
				if (electricalPT != null)
				{
					return electricalPT.CurrentHitPoints > electricalPT.fullHitPoints * percentage;
				}
				return true;
			}
			return false;
		}

		private void Start()
		{
			gameParams = Globals.G.GameParams;
			SetupListeners(on: true);
			if (windows != null)
			{
				windows.Initialize();
			}
			SimulationFlow simulationFlow = TrainCar.Resolve(base.transform)?.SimController?.simFlow;
			if (simulationFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, DamageController can't function properly!");
				return;
			}
			bodyDamagerPorts = new List<Port>();
			string[] array = bodyDamagerPortIds;
			foreach (string portId in array)
			{
				if (simulationFlow.TryGetPort(portId, out var port))
				{
					bodyDamagerPorts.Add(port);
				}
			}
			bodyHealthStateExternalInPorts = new List<Port>();
			array = bodyHealthStateExternalInPortIds;
			foreach (string portId2 in array)
			{
				if (simulationFlow.TryGetPort(portId2, out var port2))
				{
					bodyHealthStateExternalInPorts.Add(port2);
				}
			}
			mechanicalPTDamagerPorts = new List<Port>();
			array = mechanicalPTDamagerPortIds;
			foreach (string portId3 in array)
			{
				if (simulationFlow.TryGetPort(portId3, out var port3))
				{
					mechanicalPTDamagerPorts.Add(port3);
				}
			}
			mechanicalPTPercentualDamagerPorts = new List<Port>();
			array = mechanicalPTPercentualDamagerPortIds;
			foreach (string portId4 in array)
			{
				if (simulationFlow.TryGetPort(portId4, out var port4))
				{
					mechanicalPTPercentualDamagerPorts.Add(port4);
				}
			}
			mechanicalPTHealthStateExternalInPorts = new List<Port>();
			array = mechanicalPTHealthStateExternalInPortIds;
			foreach (string portId5 in array)
			{
				if (simulationFlow.TryGetPort(portId5, out var port5))
				{
					mechanicalPTHealthStateExternalInPorts.Add(port5);
				}
			}
			mechanicalPTOffExternalInPorts = new List<Port>();
			array = mechanicalPTOffExternalInPortIds;
			foreach (string portId6 in array)
			{
				if (simulationFlow.TryGetPort(portId6, out var port6))
				{
					mechanicalPTOffExternalInPorts.Add(port6);
				}
			}
			electricalPTDamagerPorts = new List<Port>();
			array = electricalPTDamagerPortIds;
			foreach (string portId7 in array)
			{
				if (simulationFlow.TryGetPort(portId7, out var port7))
				{
					electricalPTDamagerPorts.Add(port7);
				}
			}
			electricalPTHealthStateExternalInPorts = new List<Port>();
			array = electricalPTHealthStateExternalInPortIds;
			foreach (string portId8 in array)
			{
				if (simulationFlow.TryGetPort(portId8, out var port8))
				{
					electricalPTHealthStateExternalInPorts.Add(port8);
				}
			}
			electricalPTOffExternalInPorts = new List<Port>();
			array = electricalPTOffExternalInPortIds;
			foreach (string portId9 in array)
			{
				if (simulationFlow.TryGetPort(portId9, out var port9))
				{
					electricalPTOffExternalInPorts.Add(port9);
				}
			}
		}

		public void InitializeTrainCarScripts(TrainCar train, CarDamageModel carDmgModel, TrainStress trainStress)
		{
			this.train = train;
			if (carDmgModel == null || trainStress == null)
			{
				Debug.LogError("Provided null for carDmgModel or trainStress! Damage will not work for locos!", this);
			}
			this.trainStress = trainStress;
			bodyDamage = carDmgModel;
			TrainCarType_v2 parentType = train.carLivery.parentType;
			if (parentType.damage.wheelsHP > 0f)
			{
				wheels = new TrainDamage(parentType.damage.wheelsHP);
			}
			if (parentType.damage.mechanicalPowertrainHP > 0f)
			{
				mechanicalPT = new TrainDamage(parentType.damage.mechanicalPowertrainHP);
			}
			if (parentType.damage.electricalPowertrainHP > 0f)
			{
				electricalPT = new TrainDamage(parentType.damage.electricalPowertrainHP);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				TrainCarCollisions trainCarCollisions = train.TrainCarCollisions;
				trainCarCollisions.CarDamaged = (Action<float, Vector3>)Delegate.Combine(trainCarCollisions.CarDamaged, new Action<float, Vector3>(OnCollisionDamage));
				trainStress.StressDamage += OnCollisionDamage;
				train.TileInteraction.CarBurning += OnFireDamage;
				train.OnDerailed += OnDerailDamage;
			}
			else
			{
				TrainCarCollisions trainCarCollisions2 = train.TrainCarCollisions;
				trainCarCollisions2.CarDamaged = (Action<float, Vector3>)Delegate.Remove(trainCarCollisions2.CarDamaged, new Action<float, Vector3>(OnCollisionDamage));
				trainStress.StressDamage -= OnCollisionDamage;
				train.TileInteraction.CarBurning -= OnFireDamage;
				train.OnDerailed -= OnDerailDamage;
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void Update()
		{
			float deltaTime = Time.deltaTime;
			if (!TimeUtil.IsFlowing)
			{
				return;
			}
			if (wheels != null)
			{
				if (train.adhesionController.wheelslipController.IsSome(out var value) && value.wheelslip > 0f)
				{
					ApplyDamageWithSensitivityModifier(wheels, value.wheelslip * 10f * deltaTime);
				}
				AdhesionController adhesionController = train.adhesionController;
				if (adhesionController != null && adhesionController.wheelSlide > 0f)
				{
					float num = speedToBrakeDamageCurve.Evaluate(train.GetAbsSpeed() * 3.6f);
					if (num > 0f)
					{
						ApplyDamageWithSensitivityModifier(wheels, adhesionController.wheelSlide * 4f * num * deltaTime);
					}
				}
				if (trainStress.stress > 0.01f)
				{
					ApplyDamageWithSensitivityModifier(wheels, trainStress.stress * 0.03f * deltaTime);
				}
				float brakingFactor = train.brakeSystem.brakingFactor;
				if (brakingFactor > 0.001f)
				{
					float num2 = speedToBrakeDamageCurve.Evaluate(train.GetAbsSpeed() * 3.6f);
					if (num2 > 0f)
					{
						ApplyDamageWithSensitivityModifier(wheels, num2 * brakingFactor * 0.33f * deltaTime);
					}
				}
			}
			if (bodyDamage != null)
			{
				float num3 = 0f;
				foreach (Port bodyDamagerPort in bodyDamagerPorts)
				{
					num3 += bodyDamagerPort.Value;
				}
				if (num3 > 0f)
				{
					bodyDamage.DamageCar(num3);
				}
				foreach (Port bodyHealthStateExternalInPort in bodyHealthStateExternalInPorts)
				{
					bodyHealthStateExternalInPort.ExternalValueUpdate(bodyDamage.HealthPercentage);
				}
			}
			if (mechanicalPT != null)
			{
				float num4 = 0f;
				foreach (Port mechanicalPTPercentualDamagerPort in mechanicalPTPercentualDamagerPorts)
				{
					num4 += mechanicalPTPercentualDamagerPort.Value;
				}
				num4 *= mechanicalPT.fullHitPoints;
				foreach (Port mechanicalPTDamagerPort in mechanicalPTDamagerPorts)
				{
					num4 += mechanicalPTDamagerPort.Value;
				}
				if (num4 > 0f)
				{
					ApplyDamageWithSensitivityModifier(mechanicalPT, num4);
				}
				foreach (Port mechanicalPTHealthStateExternalInPort in mechanicalPTHealthStateExternalInPorts)
				{
					mechanicalPTHealthStateExternalInPort.ExternalValueUpdate(mechanicalPT.HealthPercentage);
				}
			}
			if (electricalPT == null)
			{
				return;
			}
			float num5 = 0f;
			foreach (Port electricalPTDamagerPort in electricalPTDamagerPorts)
			{
				num5 += electricalPTDamagerPort.Value;
			}
			if (num5 > 0f)
			{
				ApplyDamageWithSensitivityModifier(electricalPT, num5);
			}
			foreach (Port electricalPTHealthStateExternalInPort in electricalPTHealthStateExternalInPorts)
			{
				electricalPTHealthStateExternalInPort.ExternalValueUpdate(electricalPT.HealthPercentage);
			}
		}

		private void OnCollisionDamage(float colDamage, Vector3 forceDirection)
		{
			if (wheels != null)
			{
				float num = bodyDamage.GetModifiedCollisionDamage(colDamage) * 0.01f;
				if (num > 0f)
				{
					ApplyDamageWithSensitivityModifier(wheels, num);
				}
			}
			if (mechanicalPT != null)
			{
				float num2 = bodyDamage.GetModifiedCollisionDamage(colDamage) * 0.15f;
				if (num2 > 0f)
				{
					ApplyDamageWithSensitivityModifier(mechanicalPT, num2);
				}
				if (num2 > 100f)
				{
					foreach (Port mechanicalPTOffExternalInPort in mechanicalPTOffExternalInPorts)
					{
						mechanicalPTOffExternalInPort.ExternalValueUpdate(1f);
					}
					this.MechanicalPTOffDueCollision?.Invoke(train);
				}
			}
			if (electricalPT != null)
			{
				float num3 = bodyDamage.GetModifiedCollisionDamage(colDamage) * 0.15f;
				if (num3 > 0f)
				{
					ApplyDamageWithSensitivityModifier(electricalPT, num3);
				}
				if (num3 > 100f)
				{
					foreach (Port electricalPTOffExternalInPort in electricalPTOffExternalInPorts)
					{
						electricalPTOffExternalInPort.ExternalValueUpdate(1f);
					}
					this.ElectricalPTOffDueCollision?.Invoke(train);
				}
			}
			if (windows != null)
			{
				windows.OnCollisionDamage(colDamage, forceDirection);
			}
		}

		private void OnFireDamage(float timeInFire)
		{
			if (wheels != null)
			{
				float num = bodyDamage.GetModifiedFireDamage(timeInFire) * 0.01f;
				if (num > 0f)
				{
					ApplyDamageWithSensitivityModifier(wheels, num);
				}
			}
			if (mechanicalPT != null)
			{
				float num2 = bodyDamage.GetModifiedFireDamage(timeInFire) * 0.1f;
				if (num2 > 0f)
				{
					ApplyDamageWithSensitivityModifier(mechanicalPT, num2);
				}
			}
			if (electricalPT != null)
			{
				float num3 = bodyDamage.GetModifiedFireDamage(timeInFire) * 0.1f;
				if (num3 > 0f)
				{
					ApplyDamageWithSensitivityModifier(electricalPT, num3);
				}
			}
		}

		private void OnDerailDamage(TrainCar _)
		{
			if (AStartGameData.carsAndJobsLoadingFinished && wheels != null)
			{
				ApplyDamageWithSensitivityModifier(wheels, wheels.fullHitPoints * 0.05f);
			}
		}

		public void IgnoreDamage(bool set)
		{
			bodyDamage.IgnoreDamage(set);
			wheels?.IgnoreDamage(set);
			mechanicalPT?.IgnoreDamage(set);
			electricalPT?.IgnoreDamage(set);
		}

		public void RepairAll()
		{
			bodyDamage.RepairCar(bodyDamage.maxHealth - bodyDamage.currentHealth);
			wheels?.RepairDamage(wheels.fullHitPoints - wheels.CurrentHitPoints);
			mechanicalPT?.RepairDamage(mechanicalPT.fullHitPoints - mechanicalPT.CurrentHitPoints);
			electricalPT?.RepairDamage(electricalPT.fullHitPoints - electricalPT.CurrentHitPoints);
			if (windows != null)
			{
				windows.RepairWindows();
			}
		}

		public void DamageFullyAll()
		{
			bodyDamage.DamageCar(bodyDamage.currentHealth, useSensitivityModifier: false);
			wheels?.ApplyDamage(wheels.CurrentHitPoints);
			mechanicalPT?.ApplyDamage(mechanicalPT.CurrentHitPoints);
			electricalPT?.ApplyDamage(electricalPT.CurrentHitPoints);
		}

		private void ApplyDamageWithSensitivityModifier(TrainDamage damageType, float damageAmount)
		{
			if (damageAmount > 0f)
			{
				damageType.ApplyDamage(damageAmount * gameParams.DamageSensitivityModifier);
			}
			else
			{
				Debug.LogWarning("ApplyDamage attempt with damage amount less or equal to 0, this should not happen.", this);
			}
		}

		public JObject GetDamageSaveData()
		{
			JObject jObject = new JObject();
			jObject.SetFloat("bodyHP", bodyDamage.HealthPercentage);
			if (wheels != null)
			{
				jObject.SetFloat("wheelsHP", wheels.HealthPercentage);
			}
			if (mechanicalPT != null)
			{
				jObject.SetFloat("mechanicalPT", mechanicalPT.HealthPercentage);
			}
			if (electricalPT != null)
			{
				jObject.SetFloat("electricalPT", electricalPT.HealthPercentage);
			}
			if (windows != null)
			{
				jObject.SetBool("windowsBroken", windows.windowsBroken);
			}
			return jObject;
		}

		public void LoadDamagesState(JObject stateData)
		{
			float? num = stateData.GetFloat("bodyHP");
			if (num.HasValue)
			{
				bodyDamage.LoadCarDamageState(num.Value);
			}
			else
			{
				Debug.LogError("No load data for bodyHP found!", this);
			}
			if (wheels != null)
			{
				float? num2 = stateData.GetFloat("wheelsHP");
				if (num2.HasValue)
				{
					wheels.SetCurrentHealthPercentage(num2.Value);
				}
				else
				{
					Debug.LogError("No load data for wheelsHP found!", this);
				}
			}
			if (mechanicalPT != null)
			{
				float? num3 = stateData.GetFloat("mechanicalPT");
				if (num3.HasValue)
				{
					mechanicalPT.SetCurrentHealthPercentage(num3.Value);
				}
				else
				{
					Debug.LogError("No load data for mechanicalPT found!", this);
				}
			}
			if (electricalPT != null)
			{
				float? num4 = stateData.GetFloat("electricalPT");
				if (num4.HasValue)
				{
					electricalPT.SetCurrentHealthPercentage(num4.Value);
				}
				else
				{
					Debug.LogError("No load data for electricalPT found!", this);
				}
			}
			if (windows != null)
			{
				bool? flag = stateData.GetBool("windowsBroken");
				if (flag.HasValue)
				{
					windows.windowsBroken = flag.Value;
				}
				else
				{
					Debug.LogError("No load data for windowsBroken found!", this);
				}
			}
		}
	}
}
