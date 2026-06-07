using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.Flight.AI.ControlSystems;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Math;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class SpawnCraftScript : FlightPanelScript
	{
		public enum SpawnOptionType
		{
			Normal = 0,
			Custom = 1,
			Tanker = 2
		}

		public class SpawnOption
		{
			public string AircraftID { get; set; }

			public float Airspeed { get; internal set; }

			public string Name { get; set; }

			public SpawnOptionType OptionType { get; set; }

			public Action<SpawnOption> SpawnAction { get; set; }
		}

		public const string TankerId = "Required Craft\\__aiRefuelTanker__.xml";

		private ToggleControl _aggressiveToggle;

		private StartLocationData _defaultLocation;

		private CraftListControl _listControl;

		private InputWidget _searchInput;

		private StartLocationData _selectedLocation;

		private SpawnOption _selectedOption;

		private SliderControl _sliderAirspeed;

		private SliderControl _sliderAssist;

		private SliderControl _sliderBankAngle;

		private SliderControl _sliderHeading;

		private List<SpawnOption> _spawnOptions = new List<SpawnOption>();

		private SpinnerControl _teamSpinner;

		public override void InitializeFlightPanel(FlightUIScript flightUI)
		{
			base.InitializeFlightPanel(flightUI);
			_defaultLocation = new StartLocationData("Default", "Default", string.Empty, StartLocationType.Default, Vector3.zero, Vector3.zero, Vector3.zero, false);
			_searchInput = base.Widget.FindWidget<InputWidget>("search-input");
			_searchInput.Input.onValueChanged.AddListener(delegate
			{
				OnSearchChanged();
			});
			_aggressiveToggle = new ToggleControl(base.Widget.FindWidget("aggressive-toggle"));
			_teamSpinner = new SpinnerControl(base.Widget.FindWidget("team-spinner"));
			_teamSpinner.Values.Add("Ally");
			_teamSpinner.Values.Add("Neutral");
			_teamSpinner.Values.Add("Enemy");
			_teamSpinner.Value = "Enemy";
			TextWidget locationButtonText = base.Widget.FindWidget<TextWidget>("location-button-text");
			base.Flyout.Opened += delegate
			{
				BuildAircraftList();
				if (_selectedLocation == null || !IsNearbyLocation(_selectedLocation))
				{
					_selectedLocation = _defaultLocation;
				}
				locationButtonText.Text = _selectedLocation?.DisplayName ?? "Default";
				RefreshUI();
			};
			_sliderAirspeed = new SliderControl(base.Widget.FindWidget("airspeed-slider"));
			_sliderAirspeed.ValueFormatter = (float x) => x.Format(UnitType.Speed) ?? "";
			_sliderAirspeed.Slider.MinValue = 55f;
			_sliderAirspeed.Slider.MaxValue = 125f;
			_sliderHeading = new SliderControl(base.Widget.FindWidget("heading-slider"));
			_sliderHeading.ValueFormatter = (float x) => $"{x:0}°";
			_sliderHeading.Slider.MinValue = 0f;
			_sliderHeading.Slider.MaxValue = 360f;
			_sliderHeading.Slider.NumberOfSteps = 360;
			_sliderBankAngle = new SliderControl(base.Widget.FindWidget("bank-angle-slider"));
			_sliderBankAngle.ValueFormatter = (float x) => $"{x:n0}°";
			_sliderBankAngle.Slider.MinValue = -20f;
			_sliderBankAngle.Slider.MaxValue = 20f;
			_sliderBankAngle.Slider.Value = 0f;
			_sliderAssist = new SliderControl(base.Widget.FindWidget("assist-slider"));
			_sliderAssist.ValueFormatter = (float x) => Utilities.FormatPercentage(x) ?? "";
			_sliderAssist.Slider.MinValue = 0f;
			_sliderAssist.Slider.MaxValue = 1f;
			_sliderAssist.Slider.Value = 1f;
			SpinnerControl spinnerControl = new SpinnerControl(base.Widget.FindWidget("what-spinner"));
			spinnerControl.OnValueChanged = delegate(string _, string s)
			{
				SelectSpawnOption(s);
			};
			BuildSpawnOptions();
			foreach (SpawnOption spawnOption in _spawnOptions)
			{
				spinnerControl.Values.Add(spawnOption.Name);
			}
			spinnerControl.Value = _spawnOptions.First().Name;
			SelectSpawnOption(spinnerControl.Value);
			_listControl = new CraftListControl(base.Widget.FindWidget<ScrollViewWidget>("aircraft-scrollview"));
			base.Flyout.Opened += delegate
			{
				BuildAircraftList();
			};
		}

		protected void Update()
		{
			_listControl.Update();
		}

		private void BuildAircraftList()
		{
			List<CraftFileInfo> value;
			using (CollectionPool<List<CraftFileInfo>, CraftFileInfo>.Get(out value))
			{
				foreach (CraftFileInfo craft in Game.Instance.CraftDatabase.GetCrafts())
				{
					if (!craft.IsHidden)
					{
						value.Add(craft);
					}
				}
				value = value.OrderBy((CraftFileInfo x) => x.Name).ToList();
				_listControl.Items.Clear();
				foreach (CraftFileInfo item in value)
				{
					if (!item.IsHidden)
					{
						_listControl.Items.Add(new ListItem<CraftFileInfo>(item.Name, item)
						{
							CanDelete = false,
							CanRename = false
						});
					}
				}
			}
		}

		private void BuildSpawnOptions()
		{
			_spawnOptions.Add(new SpawnOption
			{
				Name = "Refueling Tanker",
				AircraftID = "Required Craft\\__aiRefuelTanker__.xml",
				OptionType = SpawnOptionType.Tanker,
				Airspeed = 100f,
				SpawnAction = delegate(SpawnOption x)
				{
					SpawnTanker(x);
				}
			});
			_spawnOptions.Add(new SpawnOption
			{
				Name = "Custom",
				AircraftID = null,
				OptionType = SpawnOptionType.Custom,
				SpawnAction = delegate(SpawnOption x)
				{
					SpawnCustom(x);
				}
			});
			_spawnOptions.Add(new SpawnOption
			{
				Name = "Modern Fighter",
				AircraftID = "__fighter_modern__",
				OptionType = SpawnOptionType.Normal,
				Airspeed = 100f,
				SpawnAction = delegate(SpawnOption x)
				{
					SpawnNormal(x);
				}
			});
			_spawnOptions.Add(new SpawnOption
			{
				Name = "Classic Fighter",
				AircraftID = "__P-51 WW2__",
				OptionType = SpawnOptionType.Normal,
				Airspeed = 50f,
				SpawnAction = delegate(SpawnOption x)
				{
					SpawnNormal(x);
				}
			});
			_spawnOptions.Add(new SpawnOption
			{
				Name = "Bomber",
				AircraftID = "__aiEscortBomber__",
				OptionType = SpawnOptionType.Normal,
				Airspeed = 65f,
				SpawnAction = delegate(SpawnOption x)
				{
					SpawnNormal(x);
				}
			});
			_spawnOptions.Add(new SpawnOption
			{
				Name = "Civilian",
				AircraftID = "__civilian__",
				OptionType = SpawnOptionType.Normal,
				Airspeed = 75f,
				SpawnAction = delegate(SpawnOption x)
				{
					SpawnNormal(x);
				}
			});
		}

		private List<StartLocationData> GetNearbyLocations()
		{
			List<StartLocationData> list = new List<StartLocationData>();
			list.Add(_defaultLocation);
			foreach (StartLocationData location in FlightSceneScript.Instance.StartLocationManager.Locations)
			{
				if (IsNearbyLocation(location))
				{
					list.Add(location);
				}
			}
			return list;
		}

		private bool IsNearbyLocation(StartLocationData location)
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			Vector3? vector = null;
			if (location.IsDynamicLocation)
			{
				DynamicStartLocationScript dynamicLocation = instance.StartLocationManager.GetDynamicLocation(location.DynamicLocationId);
				if (dynamicLocation != null && dynamicLocation.isActiveAndEnabled)
				{
					vector = dynamicLocation.GlobalPosition;
				}
			}
			else
			{
				vector = location.Position;
			}
			if (!vector.HasValue)
			{
				return false;
			}
			Vector3 b = instance.LocalPlayer?.FramePosition ?? Vector3.zero;
			return Vector3.Distance(Utility.ConvertAbsoluteToFloatingOriginPosition(vector.Value), b) <= AiManagerScript.AiSettings.AircraftDespawnDistance;
		}

		private void OnDespawnAllClicked(Widget widget)
		{
			Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, "Are you sure you want to despawn all AI aircraft?", null, delegate(MessageDialogScript d)
			{
				AiManagerScript.Instance.DespawnAllAI();
				d.Close();
				base.FlightUI.ShowMessage("Despawned all AI aircraft.");
			});
		}

		private void OnSearchChanged()
		{
			_listControl.SearchFilter = _searchInput.Text;
		}

		private void OnSelectLocationClicked(Widget widget)
		{
			SelectLocationScript selectLocation = base.FlightUI.Flyouts.SelectLocation.Widget.gameObject.GetComponentInChildren<SelectLocationScript>();
			selectLocation.SelectLocation(GetNearbyLocations(), delegate(StartLocationData l)
			{
				_selectedLocation = l;
				selectLocation.Flyout.Close();
				base.FlightUI.Flyouts.Selected = base.FlightUI.Flyouts.SpawnCraft;
			}, delegate
			{
				base.FlightUI.Flyouts.Selected = base.FlightUI.Flyouts.SpawnCraft;
			});
			base.FlightUI.Flyouts.Selected = base.FlightUI.Flyouts.SelectLocation;
		}

		private void OnSpawnClicked(Widget widget)
		{
			_selectedOption?.SpawnAction(_selectedOption);
		}

		private void RefreshUI()
		{
			AircraftScript aircraftScript = FlightSceneScript.Instance.LocalPlayer?.Aircraft;
			_sliderAirspeed.Slider.Slider.value = Mathf.Clamp(aircraftScript?.AirSpeed ?? 0f, 55f, 125f);
			_sliderHeading.Slider.Slider.value = Mathf.Repeat(aircraftScript?.Rotation.y ?? 0f, 360f);
		}

		private void SelectSpawnOption(string name)
		{
			_selectedOption = _spawnOptions.Where((SpawnOption x) => x.Name == name).FirstOrDefault() ?? _spawnOptions.First();
			base.Widget.EnableClass("normal", _selectedOption.OptionType == SpawnOptionType.Normal);
			base.Widget.EnableClass("custom", _selectedOption.OptionType == SpawnOptionType.Custom);
			base.Widget.EnableClass("tanker", _selectedOption.OptionType == SpawnOptionType.Tanker);
		}

		private void SpawnCraft(string craftID)
		{
			StartLocation location = ((_selectedLocation == _defaultLocation) ? null : FlightSceneScript.Instance.StartLocationManager.CreateAvailableStartLocation(_selectedLocation));
			bool isOn = _aggressiveToggle.Toggle.IsOn;
			ushort teamId = _teamSpinner.Value switch
			{
				"Ally" => 3, 
				"Neutral" => 2, 
				"Enemy" => 1, 
				_ => 2, 
			};
			AiManagerScript.Instance.SpawnSandboxAi(craftID, autoDespawn: false, forceSpawnEvenIfUnflyable: true, location, null, isOn, teamId, delegate(AiControlledAircraftScript aiAircraft)
			{
				PositionUtility.RepositionAircraftOnGround(aiAircraft.AiAircraftScript, excludePartsDisconnectedFromMainCockpit: false, 10f);
				aiAircraft.CurrentControlSystem.ControlFunction.RecheckLandingGearPosition();
				base.FlightUI.ShowMessage($"\"{aiAircraft.AiAircraftScript.Aircraft.Name}\" spawned");
			});
		}

		private void SpawnCustom(SpawnOption option)
		{
			if (_listControl.SelectedItem != null)
			{
				SpawnCraft(_listControl.SelectedItem.Item.Id);
			}
			else
			{
				base.FlightUI.ShowMessage("Select an aircraft before clicking the Spawn button.");
			}
		}

		private void SpawnNormal(SpawnOption option)
		{
			string craftID = "Required Craft\\" + option.AircraftID + ".xml";
			SpawnCraft(craftID);
		}

		private void SpawnTanker(SpawnOption option)
		{
			FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
			AircraftScript aircraftScript = localPlayer?.Aircraft;
			float num = Mathf.Clamp(aircraftScript?.Altitude ?? 0f, 300f, 7500f);
			float num2 = aircraftScript?.AltitudeAgl ?? 0f;
			if (num2 < 300f)
			{
				num = 300f - num2 + num;
			}
			Vector3 position = localPlayer?.GlobalPosition ?? Vector3.zero;
			float value = _sliderHeading.Slider.Value;
			Vector3 vector = new Vector3(Mathf.Sin(value * (MathF.PI / 180f)), 0f, Mathf.Cos(value * (MathF.PI / 180f)));
			position += vector * 300f;
			position.y = num + GameWorld.Instance.SeaLevel.GetValueOrDefault();
			float bankAngle = 0f - _sliderBankAngle.Slider.Value;
			float targetTAS = _sliderAirspeed.Slider.Value;
			if (aircraftScript != null && aircraftScript.AtmosphereSample.AirDensityRatio > 0f)
			{
				targetTAS /= Mathf.Sqrt(aircraftScript.AtmosphereSample.AirDensityRatio);
			}
			_ = (aircraftScript?.WindVelocity ?? Vector3.zero) + vector * targetTAS;
			StartLocation location = new StartLocation(position, Vector3.up * value + Vector3.forward * bankAngle, targetTAS, false);
			float assist = _sliderAssist.Slider.Value;
			ushort teamId = 3;
			AiManagerScript.Instance.SpawnSandboxAi("Required Craft\\__aiRefuelTanker__.xml", autoDespawn: false, forceSpawnEvenIfUnflyable: true, location, AiCsSandboxAirTraffic.AiMode.Default, aggressive: false, teamId, delegate(AiControlledAircraftScript ai)
			{
				AiCsFuelTanker aiCsFuelTanker = new AiCsFuelTanker();
				aiCsFuelTanker.Initialize(ai);
				aiCsFuelTanker.TargetRoll = bankAngle;
				aiCsFuelTanker.TargetSpeed = targetTAS;
				ai.SetAiControlSystem(aiCsFuelTanker);
				foreach (PartData part in ai.AiAircraftScript.Parts)
				{
					RefuelDrogueScript modifier = part.PartScript.GetModifier<RefuelDrogueScript>();
					if (modifier != null)
					{
						modifier.AssistStrength = assist;
					}
				}
				base.FlightUI.ShowMessage($"\"{ai.AiAircraftScript.Aircraft.Name}\" spawned");
			});
		}
	}
}
