using System;
using Assets.Scripts.Craft.Fuel;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Propulsion;
using ModApi.Math;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class FuelTankScript : PartModifierScript<FuelTankData>, IAnalyzePerformance, IFuelSource, IFuelTransferredHandler
	{
		private static bool _viewTankSet = true;

		private CraftFuelSource _craftFuelSource;

		private FuelTransferMode _fuelTransferMode;

		private bool _inFlightScene;

		public CraftFuelSource CraftFuelSource
		{
			get
			{
				return _craftFuelSource;
			}
			set
			{
				if (_craftFuelSource != value)
				{
					if (_craftFuelSource != null && _inFlightScene)
					{
						_craftFuelSource.RemoveFuelSource(this);
					}
					_craftFuelSource = value;
					this.CraftFuelSourceChanged?.Invoke(this, new EventArgs());
				}
			}
		}

		public FuelTransferMode FuelTransferMode
		{
			get
			{
				return _fuelTransferMode;
			}
			set
			{
				if (_fuelTransferMode == value)
				{
					return;
				}
				CraftScript craftScript = base.PartScript.CraftScript as CraftScript;
				if (FuelTransferMode == FuelTransferMode.None && value != FuelTransferMode.None)
				{
					if (SupportsFuelTransfer)
					{
						CraftFuelSource.FuelTransferMode = FuelTransferMode.None;
						craftScript.FuelTransfer.AddFuelSource(this);
						_fuelTransferMode = value;
					}
					else
					{
						Debug.LogError("Cannot enable fuel transfer on a disconnected tank");
					}
				}
				else if (FuelTransferMode != FuelTransferMode.None && value == FuelTransferMode.None)
				{
					craftScript.FuelTransfer.RemoveFuelSource(this);
					_fuelTransferMode = value;
				}
				else
				{
					_fuelTransferMode = value;
				}
			}
		}

		public FuelType FuelType => base.Data.FuelType;

		public bool IsDestroyed => base.PartScript.Data.IsDestroyed;

		public bool IsEmpty
		{
			get
			{
				if (base.Data.Fuel <= 9.999999747378752E-05)
				{
					return !Game.InfiniteFuelEnabled;
				}
				return false;
			}
		}

		public bool IsFull => base.Data.Fuel >= base.Data.Capacity;

		public Vector3 Position => base.PartScript.Transform.position;

		public int Priority => base.Data.Priority;

		public int SubPriority => base.Data.SubPriority;

		public bool SupportsFuelTransfer => !base.PartScript.Disconnected;

		public double TotalCapacity => base.Data.Capacity;

		public double TotalFuel => base.Data.Fuel;

		public bool UsesMachNumber => false;

		private IFuelSource InspectorFuelSource
		{
			get
			{
				if (_viewTankSet)
				{
					return CraftFuelSource;
				}
				return this;
			}
		}

		public event EventHandler<EventArgs> CraftFuelSourceChanged;

		public static string GetAmountLabel(IFuelSource fuelSource, float percentage = -1f)
		{
			if (fuelSource != null)
			{
				string arg = ((fuelSource.FuelType != FuelType.Battery) ? Units.GetMassString((float)(fuelSource.TotalFuel * (double)fuelSource.FuelType.Density * 0.009999999776482582)) : Units.GetEnergyString((float)fuelSource.TotalFuel * 1000f));
				return $"{arg} / {Units.GetPercentageString((percentage < 0f) ? fuelSource.GetRemainingPercentage() : percentage)}";
			}
			return "N/A";
		}

		public double AddFuel(double amount)
		{
			double result = 0.0;
			if (base.Data.Fuel < base.Data.Capacity)
			{
				if (base.Data.Fuel + amount <= base.Data.Capacity)
				{
					base.Data.Fuel += amount;
					result = amount;
				}
				else
				{
					result = base.Data.Capacity - base.Data.Fuel;
					base.Data.Fuel = base.Data.Capacity;
				}
				if (base.Data.FuelType.Density > 0f)
				{
					base.PartScript.BodyScript.OnPartMassChanged();
				}
			}
			return result;
		}

		public void CalculateSubPriority(bool reversed)
		{
			ICommandPod commandPod = base.PartScript.CommandPod;
			int num = ((commandPod == null || commandPod.CraftConfiguration.Type != CrafConfigurationType.Plane) ? ((int)(base.PartScript.Transform.localPosition.y * 10f)) : ((int)(base.PartScript.Transform.localPosition.z * 10f)));
			if (reversed)
			{
				num = -num;
			}
			base.Data.SubPriority = num;
		}

		public override void FlightEnd()
		{
			base.FlightEnd();
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			if (movedToNewCraft && base.PartScript.Disconnected && FuelTransferMode != FuelTransferMode.None)
			{
				Debug.LogFormat("Fuel tank disconnected and fuel transfer has been disabled.");
				FuelTransferMode = FuelTransferMode.None;
			}
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			if (base.PartScript.Disconnected && FuelTransferMode != FuelTransferMode.None)
			{
				Debug.LogFormat("Fuel tank disconnected and fuel transfer has been disabled.");
				FuelTransferMode = FuelTransferMode.None;
			}
		}

		public void OnFuelTransferred()
		{
			CraftFuelSource.RecalculateFuel();
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			GenerateInspectorModel(model, flightScene: true);
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			GenerateInspectorModel(groupModel, flightScene: false);
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
			FuelTransferMode = FuelTransferMode.None;
			CraftFuelSource = null;
		}

		public double RemoveFuel(double amount)
		{
			double result = 0.0;
			if (base.Data.Fuel > amount)
			{
				base.Data.Fuel -= amount;
				result = amount;
				if (base.Data.FuelType.Density > 0f)
				{
					base.PartScript.BodyScript.OnPartMassChanged();
				}
			}
			else if (base.Data.Fuel > 0.0)
			{
				result = base.Data.Fuel;
				base.Data.Fuel = 0.0;
				if (base.Data.FuelType.Density > 0f)
				{
					base.PartScript.BodyScript.OnPartMassChanged();
				}
			}
			return result;
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_inFlightScene = Game.InFlightScene;
		}

		private void GenerateInspectorModel(IGroupModel group, bool flightScene)
		{
			base.Data.FuelType.ToString();
			group.Add(new TextModel("Fuel Type", () => base.Data.FuelType.Name));
			group.Add(new TextModel("Explosive Power", () => base.Data.ExplosivePower.ToString("0"), null, "An arbitrary unit used to indicate how strong of an explosion this tank will cause. The power is added together between all the fuel tanks in a set."));
			SpinnerModel spinnerModel = new SpinnerModel(() => _viewTankSet ? "All Tanks in Set" : "Selected Tank");
			spinnerModel.NextClicked = delegate
			{
				_viewTankSet = !_viewTankSet;
			};
			spinnerModel.PrevClicked = spinnerModel.NextClicked;
			group.Add(spinnerModel);
			group.Add(new ProgressBarModel(() => GetAmountLabel(InspectorFuelSource), () => InspectorFuelSource?.GetRemainingPercentage() ?? 0f));
			if (FuelType.AllowFuelTransfer && flightScene)
			{
				IconButtonRowModel iconButtonRowModel = new IconButtonRowModel();
				IconButtonModel fuelTransferButtonNone = new IconButtonModel("Ui/Sprites/Flight/IconFuelTransferNone", delegate
				{
					InspectorFuelSource.FuelTransferMode = FuelTransferMode.None;
				}, "Disable fuel transfer.");
				IconButtonModel fuelTransferButtonFill = new IconButtonModel("Ui/Sprites/Flight/IconFuelTransferFill", delegate
				{
					InspectorFuelSource.FuelTransferMode = FuelTransferMode.Fill;
				}, "Fills the tank during fuel transfer. Requires at least one other tank to be set to Drain.");
				IconButtonModel fuelTransferButtonDrain = new IconButtonModel("Ui/Sprites/Flight/IconFuelTransferDrain", delegate
				{
					InspectorFuelSource.FuelTransferMode = FuelTransferMode.Drain;
				}, "Drains this tank during fuel transfer. Requires at least one other tank to be set to Fill.");
				iconButtonRowModel.Add(fuelTransferButtonFill);
				iconButtonRowModel.Add(fuelTransferButtonNone);
				iconButtonRowModel.Add(fuelTransferButtonDrain);
				iconButtonRowModel.UpdateAction = delegate
				{
					FuelTransferMode fuelTransferMode = InspectorFuelSource.FuelTransferMode;
					fuelTransferButtonNone.Style = ((fuelTransferMode == FuelTransferMode.None) ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default);
					fuelTransferButtonFill.Style = ((fuelTransferMode == FuelTransferMode.Fill) ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default);
					fuelTransferButtonDrain.Style = ((fuelTransferMode == FuelTransferMode.Drain) ? ButtonModel.ButtonStyle.Warning : ButtonModel.ButtonStyle.Default);
				};
				iconButtonRowModel.DetermineVisibility = () => InspectorFuelSource?.SupportsFuelTransfer ?? false;
				group.Add(iconButtonRowModel);
			}
			GroupModel groupModel = new GroupModel("Tank Set");
			groupModel.Collapsed = true;
			groupModel.Add(new TextModel("Tank Set ID", () => CraftFuelSource?.Id.ToString(), null, "Connected fuel tanks are combined into a single Tank Set. This is the ID of the Tank Set that contains this fuel tank."));
			groupModel.Add(new TextModel("Order in Set ", () => CraftFuelSource?.GetFuelSourceOrderInSet(this).ToString(), null, "Gets the Order of this fuel tank in its Tank Set. The fuel tanks with the lowest Order are emptied first."));
			groupModel.Add(new TextModel("Tanks in Set ", () => CraftFuelSource?.Count.ToString(), null, "Gets the number of fuel tanks in the Tank Set."));
			group.Add(groupModel);
		}
	}
}
