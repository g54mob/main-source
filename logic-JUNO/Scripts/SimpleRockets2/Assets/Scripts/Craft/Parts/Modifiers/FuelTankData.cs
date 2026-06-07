using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Design;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using ModApi.Craft.Propulsion;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Fuel Tank")]
	public class FuelTankData : PartModifierData<FuelTankScript>
	{
		public delegate void FuelTankDataDelegate(FuelTankData fuelTank);

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Auto Select Fuel Type", Order = 1, Tooltip = "Auto select the fuel type based on the type of rocket engine that is connected to this tank.")]
		private bool _autoFuelType = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private double _capacity;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private double _fuel;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Fuel Type", Order = 2, Tooltip = "The type of fuel stored in this fuel tank.")]
		private string _fuelType = "LOX/RP1";

		[SerializeField]
		[DesignerPropertyLabel(Order = 3, PreserveState = false, NeverSerialize = true)]
		private string _fuelTypeDescription = string.Empty;

		[SerializeField]
		[DesignerPropertyLabel(Label = "Fuel Type", PreserveState = false, NeverSerialize = true, Order = 2, Tooltip = "The type of fuel stored in this fuel tank.")]
		private string _fuelTypeReadOnly = string.Empty;

		[SerializeField]
		[DesignerPropertySpinner(-10, 10, 1, Label = "Priority", Order = 20, Tooltip = "Within the same Tank Set, fuel tanks with a higher priority will be drained first. Fuel tanks with the same non-zero priority will drain at the same time.")]
		private int _priority;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _subPriority;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _utilization = -1f;

		public bool AutoFuelType => _autoFuelType;

		public double Capacity
		{
			get
			{
				return _capacity;
			}
			set
			{
				_capacity = value;
			}
		}

		public double ExplosivePower => ((FuelType == FuelType.Battery) ? Capacity : Fuel) * (double)FuelType.ExplosivePower * (double)base.Part.Config.Explosiveness;

		public double Fuel
		{
			get
			{
				return _fuel;
			}
			set
			{
				_fuel = value;
			}
		}

		public FuelType FuelType { get; private set; }

		public override float MassDry
		{
			get
			{
				if (FuelType != FuelType.Battery)
				{
					return 0f;
				}
				float num = (float)Capacity / 3.6f;
				return 0.004464286f * num * 0.01f;
			}
		}

		public override float MassWet
		{
			get
			{
				if (FuelType == FuelType.Battery)
				{
					return 0f;
				}
				return (float)(Fuel * (double)FuelType.Density * 0.009999999776482582);
			}
		}

		public override long Price => (int)(base.Mass * 100f * FuelType.Price);

		public int Priority => _priority;

		public int SubPriority
		{
			get
			{
				return _subPriority;
			}
			set
			{
				_subPriority = value;
			}
		}

		public float Utilization
		{
			get
			{
				if (_utilization >= 0f)
				{
					return Mathf.Clamp01(_utilization);
				}
				return Mathf.Clamp01(1f - FuelType.StorageOverhead);
			}
			set
			{
				_utilization = value;
			}
		}

		public event FuelTankDataDelegate FuelTypeChanged;

		public void CalculateInitialFuel(float volume, float percentage)
		{
			if (FuelType == FuelType.Battery)
			{
				Capacity = volume * 2494.8f;
				Fuel = Capacity * (double)percentage;
			}
			else
			{
				Capacity = volume;
				Fuel = Capacity * (double)percentage;
			}
		}

		public void ChangeFuelType(FuelType fuelType)
		{
			if (Game.InDesignerScene)
			{
				if (FuelType != fuelType)
				{
					FuelType = fuelType;
					_fuelType = FuelType.Id;
					this.FuelTypeChanged?.Invoke(this);
				}
			}
			else
			{
				Debug.LogError("Changing a fuel tank's fuel type is only supported in the designer.");
			}
		}

		public override void RestoreFromState(XElement stateElement, bool restoreAll)
		{
			base.RestoreFromState(stateElement, restoreAll);
			UpdateFuelType();
		}

		protected override void OnCreated(XElement partModifierXml)
		{
			base.OnCreated(partModifierXml);
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnPropertyChanged(() => _autoFuelType, delegate
			{
				OnAutoFuelTypeChanged();
			});
			d.OnSpinnerValuesRequested(() => _fuelType, GetSpinnerValues);
			d.OnValueLabelRequested(() => _fuelType, (string x) => FuelType.Name);
			d.OnValueLabelRequested(() => _fuelTypeReadOnly, (string x) => FuelType.Name);
			d.OnValueLabelRequested(() => _fuelTypeDescription, (string x) => FuelType.Description);
			d.OnVisibilityRequested(() => _fuelType, (bool x) => !_autoFuelType);
			d.OnVisibilityRequested(() => _fuelTypeReadOnly, (bool x) => _autoFuelType);
			d.OnPropertyChanged(() => _priority, delegate
			{
				OnPropertyChangedInDesigner(updateFuelType: false);
			});
			d.OnPropertyChanged(() => _fuelType, delegate
			{
				OnPropertyChangedInDesigner(updateFuelType: true);
			});
		}

		private void GetSpinnerValues(List<string> fuelTypes)
		{
			fuelTypes.Clear();
			foreach (FuelType fuel in Game.Instance.PropulsionData.Fuels)
			{
				if (fuel.DisplayInDesigner && Game.Instance.GameState.Validator.IsItemAvailable("FuelType." + fuel.Id))
				{
					fuelTypes.Add(fuel.Id);
				}
			}
		}

		private void OnAutoFuelTypeChanged()
		{
			if (!_autoFuelType)
			{
				return;
			}
			string text = null;
			foreach (AttachPoint attachPoint in base.Part.AttachPoints)
			{
				if (!attachPoint.FuelLine)
				{
					continue;
				}
				foreach (PartConnection partConnection in attachPoint.PartConnections)
				{
					PartData otherPart = partConnection.GetOtherPart(base.Part);
					IReactionEngine modifierWithInterface = otherPart.PartScript.GetModifierWithInterface<IReactionEngine>();
					if (modifierWithInterface != null)
					{
						text = modifierWithInterface.FuelSource.FuelType.Id;
						break;
					}
					FuelTankData modifier = otherPart.GetModifier<FuelTankData>();
					if (modifier != null && modifier.AutoFuelType && modifier.FuelType != FuelType.None)
					{
						text = modifier.FuelType.Id;
					}
				}
			}
			if (text != null)
			{
				_fuelType = text;
				UpdateFuelType();
				OnPropertyChangedInDesigner(updateFuelType: true);
			}
		}

		private void OnPropertyChangedInDesigner(bool updateFuelType)
		{
			Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			if (updateFuelType)
			{
				UpdateFuelType();
				this.FuelTypeChanged?.Invoke(this);
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(FuelTankData m)
				{
					m.UpdateFuelType();
				});
			}
			base.Part.PartScript.CraftScript.SetStructureChanged();
		}

		private void UpdateFuelType()
		{
			FuelType = Game.Instance.PropulsionData.GetFuelType(_fuelType);
			if (FuelType == null)
			{
				FuelType = Game.Instance.PropulsionData.GetFuelType("LOX/RP1");
				_fuelType = FuelType.Id;
			}
		}
	}
}
