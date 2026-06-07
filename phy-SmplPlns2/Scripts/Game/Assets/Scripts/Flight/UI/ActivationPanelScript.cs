using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Input;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Flight.UI
{
	public class ActivationPanelScript : WidgetScript
	{
		private Widget[] _activationButtons = new Widget[8];

		private AircraftScript _aircraft;

		private Widget _airToAirModeButton;

		private Widget _airToGroundModeButton;

		private FlightUIScript _flightUI;

		private Widget _landingGearButton;

		private TargetingSystem.TargetingSystemMode _mode;

		private Widget _noWeaponContainer;

		private TextWidget _noWeaponText;

		private bool _targetingModeSelectionEnabled = true;

		private List<Widget> _weaponButtons = new List<Widget>();

		private Widget _weaponList;

		public void EnableTargetingModeSelection(bool enabled)
		{
			if (enabled)
			{
				_airToAirModeButton.RemoveClass("flight-btn-disabled");
				_airToGroundModeButton.RemoveClass("flight-btn-disabled");
			}
			else
			{
				_airToAirModeButton.AddClass("flight-btn-disabled");
				_airToGroundModeButton.AddClass("flight-btn-disabled");
			}
		}

		public void Initialize(FlightUIScript flightUI, Widget root)
		{
			_flightUI = flightUI;
			_airToAirModeButton = root.FindWidget("air-to-air-button");
			_airToGroundModeButton = root.FindWidget("air-to-gnd-button");
			_landingGearButton = root.FindWidget("landing-gear-button");
			_weaponList = root.FindWidget("weapon-list");
			_noWeaponContainer = root.FindWidget("no-weapon");
			_noWeaponText = root.FindWidget<TextWidget>("no-weapon-text");
			for (int i = 0; i < _activationButtons.Length; i++)
			{
				_activationButtons[i] = root.FindWidget($"activation-button-{i + 1}");
			}
			FlightSceneScript instance = FlightSceneScript.Instance;
			instance.PlayerEnteredAircraft += OnPlayerEnteredAircraft;
			instance.PlayerExitedAircraft += OnPlayerExitedAircraft;
		}

		protected virtual void OnDestroy()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			instance.PlayerEnteredAircraft -= OnPlayerEnteredAircraft;
			instance.PlayerExitedAircraft -= OnPlayerExitedAircraft;
		}

		protected virtual void Update()
		{
			AircraftScript aircraft = _aircraft;
			if (aircraft?.Controls != null && _targetingModeSelectionEnabled != aircraft.Controls.TargetingModeSelectionEnabled)
			{
				_targetingModeSelectionEnabled = aircraft.Controls.TargetingModeSelectionEnabled;
				EnableTargetingModeSelection(_targetingModeSelectionEnabled);
			}
			if ((object)aircraft != null && aircraft.Controls.LandingGearDown)
			{
				_landingGearButton.AddClass("btn-flight-selected");
			}
			else
			{
				_landingGearButton.RemoveClass("btn-flight-selected");
			}
			TargetingSystem.TargetingSystemMode targetingSystemMode = aircraft?.TargetingSystem.Mode ?? TargetingSystem.TargetingSystemMode.Off;
			if (_mode != targetingSystemMode)
			{
				_mode = targetingSystemMode;
				_airToAirModeButton.EnableClass("btn-flight-selected", targetingSystemMode == TargetingSystem.TargetingSystemMode.AirToAir);
				_airToGroundModeButton.EnableClass("btn-flight-selected", targetingSystemMode == TargetingSystem.TargetingSystemMode.AirToGround);
				foreach (Widget item in base.Widget.FindWidgetsByClass("weapon-element"))
				{
					item.Visible = targetingSystemMode != TargetingSystem.TargetingSystemMode.Off;
				}
			}
			for (int i = 0; i < _activationButtons.Length; i++)
			{
				if ((object)aircraft != null && aircraft.Controls.GetActivationState(i + 1))
				{
					_activationButtons[i].AddClass("btn-flight-selected");
				}
				else
				{
					_activationButtons[i].RemoveClass("btn-flight-selected");
				}
			}
		}

		private void AirToAirButtonClicked(Widget widget)
		{
			if (!(_aircraft == null))
			{
				if (_aircraft.TargetingSystem.Mode != TargetingSystem.TargetingSystemMode.AirToAir)
				{
					_aircraft.TargetingSystem.Mode = TargetingSystem.TargetingSystemMode.AirToAir;
				}
				else
				{
					_aircraft.TargetingSystem.Mode = TargetingSystem.TargetingSystemMode.Off;
				}
			}
		}

		private void AirToGroundButtonClicked(Widget widget)
		{
			if (!(_aircraft == null))
			{
				if (_aircraft.TargetingSystem.Mode != TargetingSystem.TargetingSystemMode.AirToGround)
				{
					_aircraft.TargetingSystem.Mode = TargetingSystem.TargetingSystemMode.AirToGround;
				}
				else
				{
					_aircraft.TargetingSystem.Mode = TargetingSystem.TargetingSystemMode.Off;
				}
			}
		}

		private void BuildWeaponsList()
		{
			foreach (Widget weaponButton in _weaponButtons)
			{
				weaponButton.Destroy();
			}
			_weaponButtons.Clear();
			_noWeaponContainer.Visible = false;
			if (_aircraft != null)
			{
				ICollection<WeaponSystem> weaponSystems = _aircraft.TargetingSystem.WeaponSystems;
				if (weaponSystems.Count > 0)
				{
					foreach (WeaponSystem weaponSystem in weaponSystems)
					{
						if ((weaponSystem.WeaponFunction & _aircraft.TargetingSystem.WeaponFunction) != WeaponFunction.None)
						{
							Widget widget = base.Widget.Context.CreateWidgetFromTemplate("weapon", _weaponList);
							_weaponButtons.Add(widget);
							widget.FindWidget<TextWidget>("weapon-name").Text = weaponSystem.WeaponPartName;
							widget.FindWidget<TextWidget>("weapon-count").Text = $"x{weaponSystem.Ammo}";
							widget.Clicked += delegate
							{
								OnWeaponButtonPressed(weaponSystem);
							};
							if (_aircraft.TargetingSystem.SelectedWeaponSystem == weaponSystem)
							{
								widget.AddClass("btn-weapon-selected");
							}
							if (weaponSystem.Ammo == 0)
							{
								widget.AddClass("btn-weapon-empty");
							}
						}
					}
				}
			}
			if (_weaponButtons.Count == 0)
			{
				if (_aircraft.TargetingSystem.Mode == TargetingSystem.TargetingSystemMode.AirToAir)
				{
					_noWeaponContainer.Visible = true;
					_noWeaponText.Text = "No air-to-air weapons";
				}
				else if (_aircraft.TargetingSystem.Mode == TargetingSystem.TargetingSystemMode.AirToGround)
				{
					_noWeaponContainer.Visible = true;
					_noWeaponText.Text = "No air-to-ground weapons";
				}
			}
		}

		private void LandingGearButtonClicked(Widget widget)
		{
			if (!GameInputs.Instance.LandingGear.Enabled)
			{
				return;
			}
			AircraftControls aircraftControls = _aircraft?.Controls;
			if (aircraftControls != null)
			{
				aircraftControls.LandingGearDown = !aircraftControls.LandingGearDown;
				if (aircraftControls.LandingGearDown)
				{
					_flightUI.ShowMessage("Extending landing gear", 1f);
				}
				else
				{
					_flightUI.ShowMessage("Retracting landing gear", 1f);
				}
			}
		}

		private void OnActivationButtonClicked(Widget widget, int activationGroup)
		{
			_aircraft?.Controls.ActivateGroup(activationGroup - 1);
		}

		private void OnHideClicked(Widget wigdet)
		{
			_flightUI.ShowInstrumentPanel();
		}

		private void OnNextTargetClicked(Widget widget)
		{
			_aircraft?.TargetingSystem?.NextTarget();
		}

		private void OnPlayerEnteredAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				_aircraft = e.Aircraft;
				e.Aircraft.TargetingSystem.WeaponsListUpdated += TargetingSystem_WeaponsListUpdated;
			}
		}

		private void OnPlayerExitedAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				_aircraft = null;
				e.Aircraft.TargetingSystem.WeaponsListUpdated -= TargetingSystem_WeaponsListUpdated;
			}
		}

		private void OnWeaponButtonPressed(WeaponSystem weaponSystem)
		{
			_aircraft?.TargetingSystem.SelectWeaponSystem(weaponSystem);
		}

		private void TargetingSystem_WeaponsListUpdated()
		{
			BuildWeaponsList();
		}
	}
}
