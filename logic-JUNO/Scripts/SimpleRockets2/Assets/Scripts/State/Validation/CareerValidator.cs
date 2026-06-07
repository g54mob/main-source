using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Career.Research;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Assets.Scripts.Craft.Parts.Modifiers.LandingGear;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.Craft.Parts.Modifiers.Solar;
using Assets.Scripts.Flight;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers;
using ModApi.Craft.Parts.Styles;
using ModApi.Craft.Propulsion;
using ModApi.Flight.Sim;
using ModApi.Math;
using ModApi.Scripts.State;
using ModApi.Scripts.State.Validation;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.State.Validation
{
	public class CareerValidator : IGameStateValidator
	{
		public enum ValidationOperationType
		{
			Unlocked = 0,
			MaxValue = 1
		}

		private CareerState _career;

		private TechTree _techTree;

		public bool IsCareerMode => true;

		public float? StartScaleFuselageOverride { get; set; }

		public float? StartScaleWingOverride { get; set; }

		public CareerValidator(CareerState career)
		{
			_career = career;
			_techTree = career.TechTree;
		}

		public static int GetNumberOfActiveCrafts(GameState gameState, int maxActiveCrafts)
		{
			FlightStateData flightStateData = gameState.LoadFlightStateData();
			int result = 0;
			if (flightStateData.CraftNodes.Where((ICraftNodeData x) => x.HasCommandPod).Count() >= maxActiveCrafts)
			{
				int num = 0;
				LaunchLocation selectedLaunchLocation = gameState.SelectedLaunchLocation;
				if (selectedLaunchLocation.LocationType == LaunchLocationType.SurfaceLockedGround)
				{
					FlightState flightState = gameState.LoadFlightState();
					IPlanetNode planetNode = flightState.RootNode.FindPlanet(selectedLaunchLocation.PlanetName);
					bool flag = !planetNode.IsTerrainDataLoaded;
					planetNode.LoadTerrainData();
					Vector3d surfacePosition = planetNode.GetSurfacePosition(selectedLaunchLocation.Latitude * 0.01745329, selectedLaunchLocation.Longitude * 0.01745329, AltitudeType.AboveGroundLevel, selectedLaunchLocation.AltitudeAboveGroundLevel);
					Vector3d launchPosition = planetNode.SurfaceVectorToPlanetVector(surfacePosition);
					foreach (ICraftNodeData craftNode in flightStateData.CraftNodes)
					{
						if (FlightSceneScript.IsCraftTooCloseToLaunchPosition(craftNode.Position, launchPosition) && craftNode.HasCommandPod)
						{
							num++;
						}
					}
					flightState.Destroy();
					if (flag)
					{
						planetNode.UnloadTerrainData();
					}
				}
				result = flightStateData.CraftNodes.Where((ICraftNodeData x) => x.HasCommandPod).Count() - num;
			}
			return result;
		}

		public float GetInitialPartScale(IGameStateValidator.InitialPartScaleType initialPartScaleType)
		{
			float result = 1f;
			string itemId;
			switch (initialPartScaleType)
			{
			case IGameStateValidator.InitialPartScaleType.Wing:
				if (StartScaleWingOverride.HasValue)
				{
					return StartScaleWingOverride.Value;
				}
				itemId = "StartScale.Wing";
				break;
			case IGameStateValidator.InitialPartScaleType.Fuselage:
				if (StartScaleFuselageOverride.HasValue)
				{
					return StartScaleFuselageOverride.Value;
				}
				itemId = "StartScale.Fuselage";
				break;
			default:
				throw new NotImplementedException($"Initial part scale type {initialPartScaleType} is not supported.");
			}
			if (_techTree.ItemValueExists(itemId))
			{
				result = _techTree.GetItemValue(itemId).ValueAsFloat;
			}
			return result;
		}

		public string GetItemId(string rootItemId, string specificId = null)
		{
			try
			{
				return string.Format(rootItemId, specificId);
			}
			catch (Exception ex)
			{
				throw new Exception("Could not parse tech item " + rootItemId + ", " + specificId + ": " + ex.ToString());
			}
		}

		public bool IsDesignerPartAvailable(DesignerPart designerPart)
		{
			if (designerPart.PayloadIds.Count > 0)
			{
				foreach (string payloadId in designerPart.PayloadIds)
				{
					if (!IsPayloadAvailable(payloadId))
					{
						return false;
					}
				}
				return true;
			}
			return _techTree.IsDesignerPartAvailable(designerPart);
		}

		public bool IsItemAvailable(string rootItemId, string specificId = null)
		{
			return _techTree.GetItemValue(GetItemId(rootItemId, specificId))?.ValueAsBool ?? false;
		}

		public bool IsLaunchLocationLocked(string name)
		{
			return !_career.UnlockedLocations.Contains(name);
		}

		public bool IsPartStyleAvailable(PartData partData, IPartStyle style)
		{
			bool result = true;
			string techItemIdForPartStyle = GetTechItemIdForPartStyle(partData, style);
			if (_techTree.ItemValueExists(techItemIdForPartStyle))
			{
				result = _techTree.GetItemValue(techItemIdForPartStyle).ValueAsBool;
			}
			return result;
		}

		public float ItemValue(string itemId)
		{
			return (_techTree?.GetItemValue(itemId)?.ValueAsFloat).GetValueOrDefault();
		}

		public ValidationResult ValidateCraft(ICraftScript craftScript, LaunchLocation launchLocation, bool fix = false)
		{
			ValidationResult validationResult = new ValidationResult();
			if (CareerState.IsDebugMode || IsItemAvailable("Cheats.SkipValidation"))
			{
				return validationResult;
			}
			ValidateActiveCrafts(validationResult);
			float num = Mathf.Max(craftScript.Data.Size.x, craftScript.Data.Size.z);
			ValidateFloat(validationResult, null, num - 0.05f, "Craft.MaxDiameter", $"Craft is too wide. {num:n2}m > " + "{0:n2}m");
			ValidateFloat(validationResult, null, craftScript.Data.Assembly.Parts.Count, "Craft.MaxPartCount", $"Craft has too many parts. {craftScript.Data.Assembly.Parts.Count} > " + "{0:n0}");
			ValidateFloat(validationResult, null, craftScript.Data.Size.y, "Craft.MaxHeight", $"Craft is too tall. {craftScript.Data.Size.y:n1}m > " + "{0:n1}m");
			if (launchLocation != null)
			{
				long num2 = (validationResult.LaunchCost = launchLocation.CalculateLaunchCost(craftScript.Data.Price, craftScript.Mass));
				if (num2 > _career.Money)
				{
					validationResult.AddMessage("Cost", "This craft will cost " + Units.GetMoneyString(num2) + " to launch from " + launchLocation.Name + ", but your company only has " + Units.GetMoneyString(_career.Money) + " in available funds. When in debt, milestones and exploration won't be evaluated, so you won't get any of their prizes.", null, ValidationMessageType.Warning);
				}
				if (launchLocation.MaxCraftDiameter > 0.0 && (double)num > launchLocation.MaxCraftDiameter)
				{
					validationResult.AddMessage(null, "This craft is too wide for the selected launch location. " + Units.GetDistanceString(num) + " > " + Units.GetDistanceString((float)launchLocation.MaxCraftDiameter));
				}
				if (launchLocation.MaxCraftHeight > 0.0 && (double)craftScript.Data.Size.y > launchLocation.MaxCraftHeight)
				{
					validationResult.AddMessage(null, "This craft is too tall for the selected launch location. " + Units.GetDistanceString(craftScript.Data.Size.y) + " > " + Units.GetDistanceString((float)launchLocation.MaxCraftHeight));
				}
				if (launchLocation.MaxCraftMass > 0.0 && (double)craftScript.Mass > launchLocation.MaxCraftMass)
				{
					validationResult.AddMessage(null, "This craft is too tall for the selected launch location. " + Units.GetMassString(craftScript.Mass) + " > " + Units.GetMassString((float)launchLocation.MaxCraftMass));
				}
			}
			foreach (PartData part in craftScript.Data.Assembly.Parts)
			{
				ValidatePart(part, validationResult, fix);
			}
			craftScript.ValidateCraft(validationResult);
			ValidatePayloads(validationResult, craftScript.Data.Assembly.Parts);
			return validationResult;
		}

		private static string GetTechItemIdForPartStyle(PartData partData, IPartStyle style)
		{
			return $"Style.{partData.PartType.Id}.{style.SubpartIndex}.{style.Id}";
		}

		private float ClampValue(float value, string techID)
		{
			return Mathf.Min(value, ItemValue(techID));
		}

		private bool IsPayloadAvailable(string payloadId)
		{
			return _career.Contracts.Payloads.NumPayloadsAvailableToLaunch(payloadId) > 0;
		}

		private void Validate(ValidationResult result, PartData part, object value, string id, ValidationOperationType operation, string errorMessage = null)
		{
			switch (operation)
			{
			case ValidationOperationType.Unlocked:
			{
				TechItemValue itemValue2 = _techTree.GetItemValue(GetItemId(id, value?.ToString()));
				if (itemValue2 != null && !itemValue2.ValueAsBool)
				{
					result.AddMessage(id, errorMessage, part);
				}
				break;
			}
			case ValidationOperationType.MaxValue:
			{
				float num = (float)value;
				TechItemValue itemValue = _techTree.GetItemValue(id);
				if (itemValue != null && itemValue.ValueAsFloat >= 0f && num > itemValue.ValueAsFloat)
				{
					errorMessage = string.Format(errorMessage, itemValue.ValueAsFloat);
					result.AddMessage(id, errorMessage, part);
				}
				break;
			}
			}
		}

		private void ValidateActiveCrafts(ValidationResult result)
		{
			int num = (int)ItemValue("MaxActiveCrafts");
			int numberOfActiveCrafts = GetNumberOfActiveCrafts(Game.Instance.GameState, num);
			if (numberOfActiveCrafts >= num)
			{
				result.AddMessage("MaxActiveCrafts", $"Cannot launch craft because there are {numberOfActiveCrafts} active craft(s) and your Tech Tree only allows up to {num}. Use the Resume Flight dialog in the main menu to remove active crafts from flight.").ClickAction = ClickAction.OpenResumeCrafts;
			}
		}

		private void ValidateFloat(ValidationResult result, PartData part, float value, string id, string errorMessage = null)
		{
			Validate(result, part, value, id, ValidationOperationType.MaxValue, errorMessage);
		}

		private void ValidatePart(PartData part, ValidationResult result, bool fix = false)
		{
			if (part.Payload?.PayloadId != null || part.Config.IgnoreValidation)
			{
				return;
			}
			if (!_techTree.IsPartTypeAvailable(part.PartType))
			{
				result.AddMessage("PartType." + part.PartType.Id, "The part '" + part.Name + "' is not available yet.", part);
			}
			if (part.PartScript.Disconnected)
			{
				result.AddMessage($"Disconnected.{part.Id}", "The part '" + part.Name + "' is not connected to the craft.", part);
			}
			foreach (PartModifierData modifier in part.Modifiers)
			{
				if (fix)
				{
					modifier.VersionUpToDate = 1;
					if (!(modifier is ConfigData configData))
					{
						if (!(modifier is ElectricMotorData electricMotorData))
						{
							if (!(modifier is JetEngineData jetEngineData))
							{
								if (!(modifier is RocketEngineData rocketEngineData))
								{
									if (!(modifier is FuelTankData fuelTankData))
									{
										if (!(modifier is FuselageData fuselageData))
										{
											if (!(modifier is SolarPanelArrayData solarPanelArrayData))
											{
												if (!(modifier is ResizableWheelData resizableWheelData))
												{
													if (!(modifier is CommandPodData commandPodData))
													{
														if (!(modifier is CameraVantageData cameraVantageData))
														{
															if (modifier is FlightProgramData flightProgramData)
															{
																flightProgramData.CareerLimits();
															}
														}
														else
														{
															cameraVantageData.IsNight &= IsItemAvailable("Camera.NightVision");
														}
													}
													else
													{
														commandPodData.Battery = ClampValue(commandPodData.Battery, "Command.Battery");
														commandPodData.Gyros = ClampValue(commandPodData.Gyros, "Command.Gyro");
													}
												}
												else
												{
													resizableWheelData.MotorTorque = ClampValue(resizableWheelData.MotorTorque, "Wheel.Torque");
													resizableWheelData.BrakeTorque = ClampValue(resizableWheelData.BrakeTorque, "Wheel.Brake");
													resizableWheelData.EnableSuspension &= IsItemAvailable("Wheel.Suspension");
												}
											}
											else
											{
												solarPanelArrayData.RowSize = (int)ClampValue(solarPanelArrayData.RowSize, "SolarPanelArray.Columns");
												solarPanelArrayData.Rows = (int)ClampValue(solarPanelArrayData.Rows, "SolarPanelArray.Rows");
												solarPanelArrayData.Length = (int)ClampValue(solarPanelArrayData.Length, "SolarPanelArray.Shape");
											}
										}
										else
										{
											fuselageData.DeadWeightPercentage = ClampValue(fuselageData.DeadWeightPercentage, "Fuselage.DeadWeight");
											if (!IsItemAvailable("Fuselage.Curve"))
											{
												fuselageData.DepthCurve = null;
											}
										}
									}
									else if (fuelTankData.PartPropertiesEnabled && fuelTankData.Fuel > 0.0 && !IsItemAvailable("FuelType." + fuelTankData.FuelType.Id))
									{
										fuelTankData.ChangeFuelType(FuelType.None);
									}
								}
								else
								{
									rocketEngineData.IsPimped = false;
								}
							}
							else
							{
								jetEngineData.HasAfterburner &= IsItemAvailable("JetEngine.Afterburner");
								jetEngineData.HasReverseThrust &= IsItemAvailable("JetEngine.Reverse");
							}
						}
						else
						{
							electricMotorData.PowerUsagePerTorque = 29f;
						}
					}
					else
					{
						configData.HeatShield = (configData.HeatShieldValidation ? ClampValue(configData.HeatShield, "Config.HeatShield") : configData.HeatShield);
						configData.DragScale = 1f;
						configData.MassScale = 1f;
						configData.PriceScale = 1f;
						configData.PartScale = Vector3.one;
						configData.IncludeInDrag = true;
					}
				}
				switch (modifier.VersionUpToDate)
				{
				case -1:
					result.AddMessage(modifier.TypeId + ".Version", "The " + modifier.TypeId + " modifier is outdated, you need to replace it with a new one.", part);
					break;
				case 0:
					result.AddPartWarning(modifier.TypeId + ".VersionAllowed", part, "The " + modifier.TypeId + " modifier has a newer version, you may miss some features or fixes by keeping it.");
					break;
				}
				if (!string.IsNullOrEmpty(modifier.ScaleCareerID))
				{
					ValidateFloat(result, part, modifier.Scale, modifier.ScaleCareerID, "The part is too large.");
				}
				if (!(modifier is ConfigData configData2))
				{
					if (!(modifier is JetEngineData jetEngineData2))
					{
						if (!(modifier is RocketEngineData rocketEngineData2))
						{
							if (!(modifier is FuelTankData fuelTankData2))
							{
								if (!(modifier is FuselageData fuselageData2))
								{
									if (!(modifier is WingData wingData))
									{
										if (!(modifier is ParachuteData parachuteData))
										{
											if (!(modifier is SolarPanelArrayData solarPanelArrayData2))
											{
												if (!(modifier is ElectricMotorData electricMotorData2))
												{
													if (!(modifier is PropellerAssemblyData propellerAssemblyData))
													{
														if (!(modifier is ResizableWheelData resizableWheelData2))
														{
															if (!(modifier is LandingGearData landingGearData))
															{
																if (!(modifier is CommandPodData commandPodData2))
																{
																	if (!(modifier is CameraVantageData cameraVantageData2))
																	{
																		if (!(modifier is EvaData evaData))
																		{
																			if (!(modifier is CrewCompartmentData crewCompartmentData))
																			{
																				if (modifier is FlightProgramData flightProgramData2)
																				{
																					if (flightProgramData2.MaxInstructionsPerFrame > 200)
																					{
																						result.AddMessage("Program.Instructions", "The program doesn't have a valid instruction per frame limit.", part);
																					}
																					if (flightProgramData2.MaxThreads != 50)
																					{
																						result.AddMessage("Program.Threads", "The program doesn't have a valid thread limit.", part);
																					}
																					if (flightProgramData2.MaxCallStackSize != 100)
																					{
																						result.AddMessage("Program.CallStack", "The program doesn't have a valid call stack size limit.", part);
																					}
																					if (flightProgramData2.BroadcastPowerConsumptionPerByte == 0f)
																					{
																						result.AddMessage("Program.BroadcastPower", "The program doesn't have a valid broadcast power consumption.", part);
																					}
																					if (flightProgramData2.PowerConsumptionPerInstruction == 0f)
																					{
																						result.AddMessage("Program.InstructionPower", "The program doesn't have a valid instruction power consumption.", part);
																					}
																				}
																			}
																			else
																			{
																				ValidateFloat(result, part, crewCompartmentData.VolumePerIndividual, "Compartment.Volume", "This crew compartment isn't available yet.");
																			}
																		}
																		else
																		{
																			CrewMember crewMember = Game.Instance.GameState.Crew.GetCrewMember(evaData.CrewId);
																			if (crewMember == null)
																			{
																				result.AddMessage("MissingCrew", "The astronaut does not have a crew member assigned.", part);
																			}
																			else if (crewMember.State != CrewMemberState.Available)
																			{
																				result.AddMessage("MissingCrew", "The astronaut does not have an available crew member assigned.", part);
																			}
																		}
																	}
																	else if (cameraVantageData2.IsNight && part.PartType.Id != "DockingPort1")
																	{
																		Validate(result, part, null, "Camera.NightVision", ValidationOperationType.Unlocked, "Night vision is not available yet.");
																	}
																}
																else
																{
																	commandPodData2.Script.RecalculateNumStages();
																	ValidateFloat(result, part, commandPodData2.Script.NumStages, "Craft.Stages", "This command unit has too many stages assigned.");
																	ValidateFloat(result, part, commandPodData2.Battery, "Command.Battery", "There's too much volume in the command disc dedicated to its battery.");
																	ValidateFloat(result, part, commandPodData2.Gyros, "Command.Gyro", "There's too much volume in the command disc dedicated to its gyroscopes.");
																}
															}
															else
															{
																ValidateFloat(result, part, landingGearData.TorqueUnscaled, "Wheel.Torque", "There's too much torque in the wheel.");
																ValidateFloat(result, part, landingGearData.BrakeTorqueUnscaled, "Wheel.Brake", "There's too much brake torque in the wheel.");
																if (!IsItemAvailable("Cheats.TinkerPanel"))
																{
																	if (landingGearData.ForwardOffset < -1f || landingGearData.ForwardOffset > 1f)
																	{
																		result.AddMessage("Gear.Forward", "The landing gear forward offset is out of range.", part);
																	}
																	if (landingGearData.HeightOffset < 0f || landingGearData.HeightOffset > 0.5f)
																	{
																		result.AddMessage("Gear.Height", "The landing gear height offset is out of range.", part);
																	}
																	if (landingGearData.SideOffset < -0.5f || landingGearData.SideOffset > 0.5f)
																	{
																		result.AddMessage("Gear.Side", "The landing gear side offset is out of range.", part);
																	}
																}
															}
														}
														else
														{
															ValidateFloat(result, part, resizableWheelData2.MotorTorque, "Wheel.Torque", "There's too much torque in the wheel.");
															ValidateFloat(result, part, resizableWheelData2.BrakeTorque, "Wheel.Brake", "There's too much brake torque in the wheel.");
															if (resizableWheelData2.EnableSuspension)
															{
																Validate(result, part, null, "Wheel.Suspension", ValidationOperationType.Unlocked, "Integrated suspensions are not available yet.");
															}
														}
													}
													else
													{
														ValidateFloat(result, part, propellerAssemblyData.BladeCount, "Prop.BladeCount", "There are too many blades in the propeller.");
														if (propellerAssemblyData.IsManual)
														{
															Validate(result, part, null, "Prop.VariablePitch", ValidationOperationType.Unlocked, "Variable pitch propeller blades are not available.");
														}
													}
												}
												else
												{
													ValidateFloat(result, part, electricMotorData2.TorqueUnscaled, "ElectricMotor.Torque", "There's too much torque in the motor.");
													ValidateFloat(result, part, electricMotorData2.BrakeTorqueUnscaled, "ElectricMotor.Brake", "There's too much brake torque in the motor.");
													ValidateFloat(result, part, electricMotorData2.Rpm, "ElectricMotor.RPM", "The motor RPMs are too high.");
													if (electricMotorData2.PowerUsagePerTorque != 29f && !IsItemAvailable("Cheats.TinkerPanel"))
													{
														result.AddMessage("ElectricMotor.Power", "This part has been tinkered, its power usage is not the stock one.", part);
													}
												}
											}
											else
											{
												ValidateFloat(result, part, solarPanelArrayData2.RowSize, "SolarPanelArray.Columns", "There are too many columns of panels.");
												ValidateFloat(result, part, solarPanelArrayData2.Rows, "SolarPanelArray.Rows", "There are too many rows of panels.");
												ValidateFloat(result, part, solarPanelArrayData2.Length, "SolarPanelArray.Shape", "The panels are stretched too much.");
											}
										}
										else
										{
											ValidateFloat(result, part, parachuteData.ChuteRadius, "Chute.Radius", "The radius is too large.");
											ValidateFloat(result, part, parachuteData.CordLength, "Chute.Length", "The cord is too long.");
										}
									}
									else
									{
										string name = part.PartType.Name;
										ValidateFloat(result, part, wingData.RootLeadingOffset, "Wing.Edge", "The root of the " + name + " is too large.");
										ValidateFloat(result, part, wingData.RootTrailingOffset, "Wing.Edge", "The root of the " + name + " is too large.");
										ValidateFloat(result, part, wingData.TipLeadingOffset, "Wing.Edge", "The tip of the " + name + " is too large.");
										ValidateFloat(result, part, wingData.TipTrailingOffset, "Wing.Edge", "The tip of the " + name + " is too large.");
										ValidateFloat(result, part, wingData.TipPosition.y, "Wing.Length", "The " + name + " is too long.");
										ValidateFloat(result, part, wingData.Thickness, "Wing.Thickness", "The " + name + " is too thick.");
										ValidateFloat(result, part, wingData.Script.ControlSurfaces.Count, "Wing.ControlSurfaces", "The " + name + " has too many control surfaces.");
										if (!IsItemAvailable("Cheats.TinkerPanel"))
										{
											wingData.Density = -1f;
											wingData.WingStrength = -1f;
										}
									}
								}
								else
								{
									ValidateFloat(result, part, fuselageData2.DeadWeightPercentage, "Fuselage.DeadWeight", "The fuselage dedicates too much of its volume to dead weight.");
									ValidateFloat(result, part, fuselageData2.Deformations.y, "Fuselage.Slant", "The fuselage is too slanted.");
									if (fuselageData2.DepthCurve != null)
									{
										Validate(result, part, null, "Fuselage.Curve", ValidationOperationType.Unlocked, "Custom nose cone curves are not available yet.");
									}
									float[] clampDistances = fuselageData2.ClampDistances;
									if (clampDistances[0] != -1f || clampDistances[1] != 1f || clampDistances[2] != -1f || clampDistances[3] != 1f || clampDistances[4] != -1f || clampDistances[5] != 1f || clampDistances[6] != -1f || clampDistances[7] != 1f)
									{
										Validate(result, part, null, "Fuselage.Clamp", ValidationOperationType.Unlocked, "Clamping fuselages is not available yet.");
									}
									if (!IsItemAvailable("Cheats.TinkerPanel") && fuselageData2.Deformations.x != fuselageData2.Deformations.z)
									{
										result.AddMessage("Fuselage.AsymPinch", "The pinch has to be the same on both ends of the fuselage.", part);
									}
								}
							}
							else if (fuelTankData2.PartPropertiesEnabled && fuelTankData2.Fuel > 0.0)
							{
								Validate(result, part, fuelTankData2.FuelType.Id, "FuelType.{0}", ValidationOperationType.Unlocked, fuelTankData2.FuelType.Name + " fuel type is not available yet.");
							}
						}
						else
						{
							Validate(result, part, rocketEngineData2.FuelType.Id, "FuelType.{0}", ValidationOperationType.Unlocked, rocketEngineData2.FuelType.Name + " fuel type is not available yet.");
							Validate(result, part, rocketEngineData2.EngineType.Id, "RocketEngine.Power.{0}", ValidationOperationType.Unlocked, rocketEngineData2.EngineType.Name + " engine type is not available yet.");
							Validate(result, part, rocketEngineData2.NozzleType.Id, "RocketEngine.Nozzle.{0}", ValidationOperationType.Unlocked, rocketEngineData2.NozzleType.Name + " nozzle is not available yet.");
							if (rocketEngineData2.EngineType.FuelGrains.Count > 0)
							{
								Validate(result, part, rocketEngineData2.FuelGrain.Id, "RocketEngine.Grain.{0}", ValidationOperationType.Unlocked, rocketEngineData2.FuelGrain.Name + " fuel grain is not available yet.");
							}
							if (!IsItemAvailable("Cheats.TinkerPanel"))
							{
								if (rocketEngineData2.UserChamberPressure < 0.5f || rocketEngineData2.UserChamberPressure > 1f)
								{
									result.AddMessage("RocketEngine.ChamberPressure", "The chamber pressure has been tinkered to be out of range.", part);
								}
								if (rocketEngineData2.GimbalRange < 0f || rocketEngineData2.GimbalRange > 1f)
								{
									result.AddMessage("RocketEngine.GimbalRange", "The gimbal range has been tinkered to be out of range.", part);
								}
								if (rocketEngineData2.ExtensionSize < 0f || rocketEngineData2.ExtensionSize > 2f)
								{
									result.AddMessage("RocketEngine.NozzleSize", "The nozzle extension has been tinkered to be out of range.", part);
								}
								if (rocketEngineData2.UserNozzleThroatRadius < 0.5f || rocketEngineData2.UserNozzleThroatRadius > 1f)
								{
									result.AddMessage("RocketEngine.ThroatSize", "The throat size has been tinkered to be out of range.", part);
								}
								if (rocketEngineData2.IsPimped)
								{
									result.AddMessage("RocketEngine.Pimped", "One or more XML edits have been detected.", part);
								}
							}
						}
					}
					else
					{
						ValidateFloat(result, part, jetEngineData2.BypassRatio, "JetEngine.BypassRatio", "Jet engine bypass ratio is too high.");
						ValidateFloat(result, part, jetEngineData2.CompressionRatio, "JetEngine.CompressionRatio", "Jet engine compression ratio is too high.");
						if (jetEngineData2.HasAfterburner)
						{
							Validate(result, part, null, "JetEngine.Afterburner", ValidationOperationType.Unlocked, "Jet engine afterburner is not available yet.");
						}
						if (jetEngineData2.HasReverseThrust)
						{
							Validate(result, part, null, "JetEngine.Reverse", ValidationOperationType.Unlocked, "Jet engine reverse thrust is not available yet.");
						}
					}
				}
				else if (!IsItemAvailable("Cheats.TinkerPanel"))
				{
					if (configData2.HeatShieldValidation)
					{
						ValidateFloat(result, part, configData2.HeatShieldScale, "Config.HeatShield", "You can't use as much heatshielding treatment yet.");
					}
					if (configData2.FuelLineOverride && part.PartType.Id != "Generator1")
					{
						Validate(result, part, null, "Config.FuelLine", ValidationOperationType.Unlocked, "Adding fuel lines to parts is not available yet.");
					}
					if (configData2.DragScale != 1f)
					{
						result.AddMessage("Tinker.DragScale", "This part has had its drag scale modified, use a non-tinkered part.", part);
					}
					if (!configData2.IncludeInDrag)
					{
						result.AddMessage("Tinker.IncludeInDrag", "This part has had its drag disabled, use a non-tinkered part.", part);
					}
					if (configData2.MassScale != 1f)
					{
						result.AddMessage("Tinker.MassScale", "This part has had its mass scale modified, use a non-tinkered part.", part);
					}
					if (configData2.PartScale != Vector3.one)
					{
						result.AddMessage("Tinker.PartScale", "This part has had its tinker size modified, use a non-tinkered part.", part);
					}
					if (configData2.PriceScale != 1f)
					{
						result.AddMessage("Tinker.PriceScale", "This part has had its price scale modified, use a non-tinkered part.", part);
					}
				}
				modifier.GetScript()?.ValidatePart(result);
			}
			foreach (PartStyleData style in part.Styles)
			{
				if (!IsPartStyleAvailable(part, style.Style))
				{
					result.AddMessage(GetTechItemIdForPartStyle(part, style.Style) ?? "", "Part style '" + style.Style.DisplayName + "' is not available yet.", part);
				}
			}
			foreach (PartConnection partConnection in part.PartConnections)
			{
				if (partConnection.Attachments.Count == 1 && partConnection.Attachments[0].AttachPointA.RequiresPhysicsJoint && partConnection.Attachments[0].AttachPointB.RequiresPhysicsJoint)
				{
					result.AddMessage("BadAttachment", "The part is using an invalid attachment. Connecting two shafts to eachother isn't supported.", part);
				}
			}
		}

		private void ValidatePayloads(ValidationResult result, IReadOnlyList<PartData> parts)
		{
			foreach (IGrouping<string, PartData> item in (from x in parts
				where !string.IsNullOrEmpty(x.Payload?.PayloadId)
				group x by x.Payload?.PayloadId).ToList())
			{
				string key = item.Key;
				int num = item.Count();
				int num2 = _career.Contracts.Payloads.NumPayloadsAvailableToLaunch(key);
				if (num > num2)
				{
					foreach (PartData item2 in item)
					{
						result.AddMessage($"Payload.{item2.Id}", $"This craft has {num} payload(s) of this type, but only {num2} payload(s) are available from active contracts.").PartID = item2.Id;
					}
				}
				else
				{
					if (num <= 1)
					{
						continue;
					}
					foreach (IGrouping<int, PartData> item3 in (from x in item
						group x by x.Payload.ContractNumber).ToList())
					{
						int contractNumber = item3.Key;
						Contract contract = _career.Contracts.Active.Where((Contract x) => x.ContractNumber == contractNumber).FirstOrDefault();
						if (contract == null)
						{
							continue;
						}
						int numPayloadsRequiredForContract = PayloadState.GetNumPayloadsRequiredForContract(contract, key);
						if (item3.Count() <= numPayloadsRequiredForContract || contractNumber <= 0)
						{
							continue;
						}
						foreach (PartData item4 in item3)
						{
							result.AddMessage($"Payload.{item4.Id}", $"Too many parts referencing the same contract {contract.Name}#{contract.ContractNumber}.").PartID = item4.Id;
						}
					}
				}
			}
		}
	}
}
