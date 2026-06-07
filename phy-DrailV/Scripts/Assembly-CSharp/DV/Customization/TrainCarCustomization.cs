using System;
using System.Collections.Generic;
using DV.Customization.Gadgets;
using DV.JObjectExtstensions;
using DV.Simulation.Cars;
using LocoSim.Attributes;
using LocoSim.Implementations;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization
{
	[RequireComponent(typeof(TrainCar))]
	public sealed class TrainCarCustomization : Customization
	{
		[Serializable]
		private struct STDPortDefinition
		{
			public STDSimPort port;

			[PortId(null, null, false)]
			public string name;

			public bool readOnly;

			public Port portReference;

			public STDPortDefinition(STDSimPort port, string name, bool readOnly)
			{
				this.port = port;
				this.name = name;
				this.readOnly = readOnly;
				portReference = null;
			}
		}

		public class TrainCarCustomizerBase : CustomizerBase
		{
			[Serializable]
			public struct TrainCarRequirements
			{
				[Serializable]
				public struct PortRequirement
				{
					public STDSimPort port;

					public bool requireWrite;
				}

				[Tooltip("Which part of a train car can this be placed onto")]
				public CustomizerTrainCarRequirements trainCarPresence;

				[Tooltip("Require base controls, such as throttle, brake, reverser, e.t.c.")]
				public bool baseControls;

				[Tooltip("Require main electrics fuse to")]
				public bool electricsFuse;

				[Tooltip("Require MU support")]
				public bool muSupport;

				[Tooltip("Require a cabin")]
				public bool cabin;

				[Tooltip("Require simulation ports")]
				public PortRequirement[] simPorts;
			}

			public enum CustomizerTrainCarRequirements : byte
			{
				[Tooltip("Can be only placed on a TrainCar interior")]
				RequireInterior = 0,
				[Tooltip("Can be only placed on a TrainCar")]
				RequireTrainCar = 1,
				[Tooltip("No additional restrictions")]
				None = 2
			}

			private static int uidCounter;

			public const string KEY_HAS_BEEN_WIRED = "beenWired";

			public const string KEY_WIRING_UNITS = "wiringUnits";

			public const string KEY_UID = "uid";

			public const int SOLDERING_UNITS_REQUIRED = 65536;

			[SerializeField]
			private TrainCarRequirements requirements;

			[SerializeField]
			private bool requireSoldering;

			private Fuse fuse;

			private int solderingUnits;

			private bool powerSwitch = true;

			public bool IsOnTrainCar => CustomTrainCar != null;

			public TrainCarCustomization CustomTrainCar { get; private set; }

			public TrainCar TrainCar => CustomTrainCar?.TrainCar;

			public BaseControlsOverrider Controls { get; private set; }

			public bool HasControls => Controls != null;

			public bool PowerState
			{
				get
				{
					if (powerSwitch)
					{
						return fuse?.State ?? (!requireSoldering);
					}
					return false;
				}
			}

			public bool IsSoldered => solderingUnits >= 65536;

			public bool IsSolderable => requireSoldering;

			public bool NeedsSoldering
			{
				get
				{
					if (requireSoldering)
					{
						return !IsSoldered;
					}
					return false;
				}
			}

			public float SolderingProgress => (float)solderingUnits / 65536f;

			public int SolderingProgressUnits => solderingUnits;

			public int SolderingUnitsRequired => 65536 - solderingUnits;

			public int UID { get; private set; }

			public bool PowerSwitch
			{
				get
				{
					return powerSwitch;
				}
				set
				{
					if (powerSwitch != value)
					{
						powerSwitch = value;
						if (base.Custom != null)
						{
							RaisePowerStateChanged();
						}
					}
				}
			}

			public event Action<TrainCarCustomizerBase, bool> PowerStateChanged;

			public int MakeSoldered(int inputUnits = 65536)
			{
				if (!requireSoldering || inputUnits < 0)
				{
					return 0;
				}
				if (inputUnits > SolderingUnitsRequired)
				{
					inputUnits = SolderingUnitsRequired;
				}
				solderingUnits += inputUnits;
				if (solderingUnits >= 65536 && fuse == null)
				{
					SetFuse(CustomTrainCar?.electronicsFuse);
				}
				return inputUnits;
			}

			public int RemoveSoldering(int unitsToRemove = 65536)
			{
				if (!requireSoldering || unitsToRemove < 0)
				{
					return 0;
				}
				if (unitsToRemove > solderingUnits)
				{
					unitsToRemove = solderingUnits;
				}
				solderingUnits -= unitsToRemove;
				if (solderingUnits <= 0 && fuse != null)
				{
					SetFuse(null);
				}
				return unitsToRemove;
			}

			public bool SetSolderingUnits(int units)
			{
				if (units < 0)
				{
					units = 0;
				}
				if (units > 65536)
				{
					units = SolderingUnitsRequired;
				}
				solderingUnits = units;
				if (solderingUnits >= 65536)
				{
					MakeSoldered(0);
				}
				else
				{
					RemoveSoldering(0);
				}
				return IsSoldered;
			}

			public void PopFuse()
			{
				if (fuse != null && PowerState)
				{
					fuse.ChangeState(newState: false);
				}
			}

			protected virtual void OnPowerStateChanged(bool newState)
			{
			}

			public bool HasPort(STDSimPort port, bool requireWrite = false)
			{
				return CustomTrainCar.HasPort(port, requireWrite);
			}

			public bool IsPortReadonly(STDSimPort port)
			{
				return CustomTrainCar.IsPortReadonly(port);
			}

			public bool TryReadPort(STDSimPort port, out float value)
			{
				value = 0f;
				if (CustomTrainCar == null || !CustomTrainCar.HasPort(port))
				{
					return false;
				}
				value = CustomTrainCar.ReadPort(port);
				return true;
			}

			public float? TryReadPort(STDSimPort port)
			{
				if (CustomTrainCar == null || !CustomTrainCar.HasPort(port))
				{
					return null;
				}
				return CustomTrainCar.ReadPort(port);
			}

			public bool TryWritePort(STDSimPort port, float value)
			{
				if (CustomTrainCar == null || !CustomTrainCar.HasPort(port, requireWrite: true))
				{
					return false;
				}
				CustomTrainCar.WritePort(port, value);
				return true;
			}

			public override bool IsValidTarget(Customization target, Collider hitCollider)
			{
				if (base.IsValidTarget(target, hitCollider))
				{
					return IsValidTargetSelf(target, hitCollider);
				}
				return false;
			}

			private bool IsValidTargetSelf(Customization target, Collider hitCollider)
			{
				TrainCarCustomization trainCarCustomization = target as TrainCarCustomization;
				if (requirements.baseControls && trainCarCustomization?.Controls == null)
				{
					return false;
				}
				if (requirements.electricsFuse && trainCarCustomization?.electronicsFuse == null)
				{
					return false;
				}
				if (requirements.muSupport && trainCarCustomization?.TrainCar.muModule == null)
				{
					return false;
				}
				if (requirements.cabin && trainCarCustomization?.TrainCar.carLivery.interiorPrefab == null)
				{
					return false;
				}
				if (requirements.simPorts != null && requirements.simPorts.Length != 0)
				{
					if (trainCarCustomization == null)
					{
						return false;
					}
					for (int i = 0; i < requirements.simPorts.Length; i++)
					{
						if (!trainCarCustomization.HasPort(requirements.simPorts[i].port, requirements.simPorts[i].requireWrite))
						{
							return false;
						}
					}
				}
				return true;
			}

			protected override void OnAfterLinked()
			{
				if (UID == 0)
				{
					AssignNewUID();
				}
				base.OnAfterLinked();
				CustomTrainCar = base.Custom as TrainCarCustomization;
				Controls = CustomTrainCar?.Controls;
				if (IsSoldered || !IsSolderable)
				{
					SetFuse(CustomTrainCar?.electronicsFuse);
				}
				RaisePowerStateChanged();
			}

			protected override void OnBeforeUnlinked()
			{
				SetFuse(null);
				CustomTrainCar = null;
				Controls = null;
				base.OnBeforeUnlinked();
				AssignUID(0);
				RemoveSoldering();
			}

			private void SetFuse(Fuse fuse)
			{
				if (this.fuse != fuse)
				{
					if (this.fuse != null)
					{
						this.fuse.StateUpdated -= RaisePowerStateChanged;
					}
					this.fuse = fuse;
					if (this.fuse != null)
					{
						this.fuse.StateUpdated += RaisePowerStateChanged;
					}
					RaisePowerStateChanged();
				}
			}

			protected void RaisePowerStateChanged(bool _ = false)
			{
				bool powerState = PowerState;
				OnPowerStateChanged(powerState);
				foreach (CustomizerLODObject lODObject in base.LODObjects)
				{
					lODObject.OnPowerStateChanged(powerState);
				}
				this.PowerStateChanged?.Invoke(this, powerState);
			}

			public override void SaveDataRequested(JObject dst)
			{
				base.SaveDataRequested(dst);
				dst.SetInt("wiringUnits", solderingUnits);
				dst.SetInt("uid", UID);
			}

			public override void SaveDataLoaded(JObject src)
			{
				base.SaveDataLoaded(src);
				AssignUID(src.GetInt("uid") ?? 0);
				int? num = src.GetInt("wiringUnits");
				if (num.HasValue)
				{
					if (solderingUnits != 0)
					{
						RemoveSoldering();
					}
					solderingUnits = 0;
					MakeSoldered(num.Value);
				}
			}

			private void AssignNewUID()
			{
				UID = ++uidCounter;
			}

			private void AssignUID(int uid)
			{
				UID = uid;
				if (uidCounter < uid)
				{
					uidCounter = uid;
				}
			}
		}

		private const float IMPACT_DISMOUNT_MIN = 0.3f;

		private const float IMPACT_DISMOUNT_MAX = 3f;

		[FuseId]
		public string electronicsFuseID;

		[SerializeField]
		private STDPortDefinition[] standardizedPorts = Array.Empty<STDPortDefinition>();

		private SimController sim;

		private Fuse electronicsFuse;

		private readonly Dictionary<STDSimPort, int> ports = new Dictionary<STDSimPort, int>();

		private Rigidbody rigidbody;

		public TrainCar TrainCar { get; private set; }

		public BaseControlsOverrider Controls { get; private set; }

		public bool AreLODsLoaded { get; private set; }

		public override Transform GetParentingTransform()
		{
			return TrainCar.interior;
		}

		public override string GetIdentificationKey()
		{
			return TrainCar.CarGUID;
		}

		internal void Initialize(TrainCar trainCar)
		{
			if (TrainCar != null)
			{
				Debug.LogError("[CUSTOMIZATION] DOUBLE INITIALIZATION!");
				return;
			}
			TrainCar = trainCar;
			trainCar.physicsLod.TrainPhysicsLodChanged += PhysicsLODChanged;
			PhysicsLODChanged(trainCar.physicsLod.CurrentLod);
			sim = trainCar.SimController;
			Controls = sim?.controlsOverrider;
			if (!string.IsNullOrWhiteSpace(electronicsFuseID))
			{
				sim?.simFlow?.TryGetFuse(electronicsFuseID, out electronicsFuse);
			}
			InitializeSimPorts();
			rigidbody = trainCar.rb;
		}

		private void PhysicsLODChanged(int currentLOD)
		{
			bool flag = currentLOD <= 0;
			if (AreLODsLoaded == flag)
			{
				return;
			}
			AreLODsLoaded = flag;
			foreach (CustomizerBase customizer in base.Customizers)
			{
				customizer.SetLODState(flag);
			}
		}

		protected override bool ShouldLODBeLoaded(CustomizerBase customizer)
		{
			return AreLODsLoaded;
		}

		private void InitializeSimPorts()
		{
			SimulationFlow simulationFlow = sim?.simFlow;
			if (simulationFlow == null)
			{
				return;
			}
			for (int num = standardizedPorts.Length - 1; num >= 0; num--)
			{
				if (!simulationFlow.TryGetPort(standardizedPorts[num].name, out standardizedPorts[num].portReference))
				{
					Debug.LogError("[CUSTOMIZATION] Port ID '" + standardizedPorts[num].name + "' could not be found on '" + base.name + "'!");
				}
				else
				{
					ports[standardizedPorts[num].port] = num;
				}
			}
		}

		public bool HasPort(STDSimPort port, bool requireWrite = false)
		{
			if (ports.TryGetValue(port, out var value))
			{
				if (requireWrite)
				{
					return !standardizedPorts[value].readOnly;
				}
				return true;
			}
			return false;
		}

		public bool IsPortReadonly(STDSimPort port)
		{
			return standardizedPorts[ports[port]].readOnly;
		}

		public float ReadPort(STDSimPort port)
		{
			return standardizedPorts[ports[port]].portReference.Value;
		}

		public void WritePort(STDSimPort port, float value)
		{
			int num = ports[port];
			if (standardizedPorts[num].readOnly)
			{
				Debug.LogError("[CUSTOMIZATION] Attempt to write into a port which is marked as read only!");
			}
			else
			{
				standardizedPorts[num].portReference.Value = value;
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			float value = collision.impulse.sqrMagnitude / (rigidbody.mass * rigidbody.mass);
			float num = Mathf.InverseLerp(0.09f, 9f, value);
			if (num <= 0f)
			{
				return;
			}
			for (int num2 = base.Customizers.Count - 1; num2 >= 0; num2--)
			{
				Drillable component;
				if (num2 >= base.Customizers.Count)
				{
					Debug.LogError("[CUSTOMIZATION] " + base.gameObject.name + " Tried to remove a gadget due to collision, but it caused a list shift outside of the expected range!");
				}
				else if (base.Customizers[num2] is GadgetBase gadgetBase && gadgetBase.TryGetComponent<Drillable>(out component) && component.FirmlyAttachedPointCount == 0 && num >= UnityEngine.Random.value)
				{
					gadgetBase.ForceRemove();
				}
			}
		}
	}
}
