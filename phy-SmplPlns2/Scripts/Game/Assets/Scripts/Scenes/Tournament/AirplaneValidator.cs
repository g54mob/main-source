using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Scenes.Tournament
{
	public class AirplaneValidator
	{
		public string Message { get; set; }

		public int Status { get; set; }

		public AirplaneValidator()
		{
			Message = string.Empty;
		}

		public void Validate(string aircraftId, string tournamentClass)
		{
			Status = 1;
			Message = string.Empty;
			XElement xElement = Game.Instance.CraftDatabase.LoadCraftXml(aircraftId, showErrorDialogs: false);
			if (xElement != null)
			{
				AircraftData aircraftData = new AircraftData(xElement, CraftLoadContext.Default);
				if (aircraftData.Assembly.MissingParts.Count > 0)
				{
					ValidationError("Failed to load aircraft (probably using mods).");
				}
				switch (tournamentClass)
				{
				case "Car Class":
					ValidateClassCar(aircraftData);
					break;
				case "Prop Class":
					ValidateClassProp(aircraftData);
					break;
				case "Unlimited Class":
					ValidateClassUnlimited(aircraftData);
					break;
				case "Mod Class":
					ValidateNoProhibitedModifiers(aircraftData);
					break;
				}
			}
			else
			{
				ValidationError("Unable to open aircraft design.");
			}
		}

		public void Validate(AircraftData aircraft, string tournamentClass)
		{
			Status = 1;
			Message = string.Empty;
			switch (tournamentClass)
			{
			case "Car Class":
				ValidateClassCar(aircraft);
				break;
			case "Prop Class":
				ValidateClassProp(aircraft);
				break;
			case "Unlimited Class":
				ValidateClassUnlimited(aircraft);
				break;
			case "Mod Class":
				ValidateNoProhibitedModifiers(aircraft);
				break;
			}
		}

		public void ValidationError(string message)
		{
			Message = Message + message + " ";
			Status = 3;
		}

		private void Assert(float value, float min, float max, string message)
		{
			if (value < min || value > max)
			{
				ValidationError($"Modded {message}.");
			}
		}

		private void Assert(bool value, bool expected, string message)
		{
			if (value != expected)
			{
				ValidationError($"Modded {message}.");
			}
		}

		private void Assert(int value, int min, int max, string message)
		{
			if (value < min || value > max)
			{
				ValidationError($"Modded {message}.");
			}
		}

		private void Assert(float value, float expected, string message)
		{
			if (!Utilities.CompareFloats(value, expected, 0.1f))
			{
				ValidationError($"Modded {message}.");
			}
		}

		private void ValidateBladedEngine(BladedEngineData bladedEngine, PartData part)
		{
			Assert(bladedEngine.BladeCount, 2, 6, "Blade count");
			Assert(bladedEngine.Power, bladedEngine.MinPower, bladedEngine.MaxPower, "Max power");
			Assert(bladedEngine.ChordScale, 0.99f, 3.01f, "Blade chord");
			if (bladedEngine.IsMaxRpmAModdedValue)
			{
				float num = BladedEngineData.CalculateMaxEngineRpm(bladedEngine.Diameter);
				if (bladedEngine.MaxRpm > num * 1.05f)
				{
					ValidationError($"Modded Max RPM is greater than calculated RPM: {bladedEngine.MaxRpm} > {num}");
				}
			}
			Assert(bladedEngine.Diameter, bladedEngine.MinDiameter - 0.1f, bladedEngine.MaxDiameter + 0.1f, "Blade diameter");
		}

		private void ValidateClassCar(AircraftData aircraft)
		{
			ValidateCommon(aircraft);
			foreach (PartData part in aircraft.Assembly.Parts)
			{
				foreach (PartModifierData modifier in part.Modifiers)
				{
					if (modifier is EngineData)
					{
						ValidationError("Jet and prop engines are not allowed.");
					}
					if (modifier is CarEngineData { Power: >600f } carEngineData)
					{
						ValidationError($"RPM is invalid: {carEngineData.Power}");
					}
				}
			}
		}

		private void ValidateClassProp(AircraftData aircraft)
		{
			ValidateCommon(aircraft);
			foreach (PartData part in aircraft.Assembly.Parts)
			{
				foreach (PartModifierData modifier in part.Modifiers)
				{
					if (!(modifier is EngineData engineData))
					{
						continue;
					}
					if (engineData.EngineType == "Prop")
					{
						if (!(engineData is PropEngineAdvancedData))
						{
							ValidationError("Old style prop engines are not allowed.");
						}
					}
					else
					{
						ValidationError("Jet engines are not allowed.");
					}
				}
			}
		}

		private void ValidateClassUnlimited(AircraftData aircraft)
		{
			ValidateCommon(aircraft);
		}

		private void ValidateCommon(AircraftData aircraft)
		{
			ValidateNoProhibitedModifiers(aircraft);
			foreach (PartData part in aircraft.Assembly.Parts)
			{
				if (part.PartType != null && part.PartType.Mod != null)
				{
					ValidationError("Contains a part from a mod");
				}
			}
			foreach (PartData part2 in aircraft.Assembly.Parts)
			{
				if (part2.PartScale.HasValue && !Utilities.CompareVector3s(part2.PartScale.Value, Vector3.one, 0.11f))
				{
					ValidationError("Part scale did not pass validation: " + part2.PartScale.Value.ToString());
				}
				if (part2.MassScale != 1f)
				{
					ValidationError("Mass scale did not pass validation: " + part2.MassScale);
				}
				if (part2.DragScale != 1f)
				{
					ValidationError("Drag scale did not pass validation: " + part2.DragScale);
				}
				if (part2.DragTypeAsConfigured != PartDragType.Default)
				{
					ValidationError("DragType did not pass validation: " + part2.DragTypeAsConfigured);
				}
				foreach (PartModifierData modifier in part2.Modifiers)
				{
					if (modifier is BladedEngineData bladedEngine)
					{
						ValidateBladedEngine(bladedEngine, part2);
					}
					if (modifier is EngineData { PowerMultiplier: not 1f })
					{
						ValidationError("Engine power multiplier did not pass validation.");
					}
					if (modifier is InputControllerData inputController && !ValidateInputController(inputController, part2))
					{
						ValidationError("Input controller did not pass validation.");
					}
					if (modifier is FuelTankData fuelTankData && (fuelTankData.Fuel < 0f || fuelTankData.Capacity < 0f))
					{
						ValidationError("Fuel tank did not pass validation.");
					}
				}
			}
		}

		private bool ValidateInputController(InputControllerData inputController, PartData part)
		{
			if (inputController.Name.ToLower() == "throttle" && (inputController.MinValue < 0f || inputController.MaxValue > 1f))
			{
				return false;
			}
			bool flag = false;
			foreach (PartModifierData modifier in part.Modifiers)
			{
				if (modifier.Id == "Engine")
				{
					flag = true;
				}
			}
			if (flag && (inputController.MinValue < 0f || inputController.MaxValue > 1f))
			{
				return false;
			}
			return true;
		}

		private void ValidateNoProhibitedModifiers(AircraftData aircraft)
		{
			foreach (PartData part in aircraft.Assembly.Parts)
			{
				foreach (PartModifierData modifier in part.Modifiers)
				{
					if (modifier.Id == "Bomb" || modifier.Id == "Missile" || modifier.Id == "Gun" || modifier.Id == "Cannon" || modifier.Id == "Torpedo" || modifier.Id == "RocketWeapon" || modifier.Id == "RocketPod")
					{
						ValidationError("Has weapons.");
					}
					else if (modifier.Id == "AirBrake")
					{
						ValidationError("Has air brake.");
					}
				}
			}
		}
	}
}
