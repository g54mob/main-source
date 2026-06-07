using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using Assets.Scripts.Craft.FlightData;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Craft.Program;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Input
{
	public class InputControllerInput : IInputControllerInput
	{
		private enum TargetModifierType
		{
			Unknown = 0,
			Script = 1,
			Data = 2,
			FlightProgram = 3
		}

		private int? _activationGroupId;

		private bool _enabled;

		private Func<float> _getInput;

		private object _targetInstance;

		private string _targetModifierId;

		private TargetModifierType _targetModifierType;

		private string _targetPartId;

		private PropertyInfo _targetProperty;

		private string _targetPropertyName;

		public int? ActivationGroupId => _activationGroupId;

		public bool Enabled => _enabled;

		public Type TargetType { get; private set; }

		public float Value => _getInput();

		private InputControllerInput()
		{
			_enabled = false;
			_getInput = null;
			_targetInstance = null;
		}

		public static IInputControllerInput Create(string inputName)
		{
			if (string.IsNullOrEmpty(inputName))
			{
				return null;
			}
			PropertyInfo property = typeof(CraftControls).GetProperty(inputName);
			if (property != null)
			{
				return new InputControllerInput
				{
					_activationGroupId = null,
					_targetPartId = null,
					_targetModifierId = null,
					_targetPropertyName = property.Name,
					_targetProperty = property,
					TargetType = typeof(CraftControls)
				};
			}
			if (inputName.StartsWith("AG", StringComparison.Ordinal))
			{
				if (!int.TryParse(inputName.Substring(2), out var result) || result < 1)
				{
					return InputControllerExpression.Create(inputName);
				}
				return new InputControllerInput
				{
					_activationGroupId = result,
					_targetPartId = null,
					_targetModifierId = null,
					_targetPropertyName = null,
					_targetProperty = null,
					TargetType = typeof(CraftControls)
				};
			}
			Type type = null;
			if (inputName.StartsWith("FlightData.", StringComparison.Ordinal))
			{
				type = typeof(CraftFlightData);
				property = type.GetProperty(inputName.Substring(11));
			}
			else if (inputName.StartsWith("FD.", StringComparison.Ordinal))
			{
				type = typeof(CraftFlightData);
				property = type.GetProperty(inputName.Substring(3));
			}
			else if (inputName.StartsWith("OrbitData.", StringComparison.Ordinal))
			{
				type = typeof(CraftOrbitData);
				property = type.GetProperty(inputName.Substring(10));
			}
			else if (inputName.StartsWith("OD.", StringComparison.Ordinal))
			{
				type = typeof(CraftOrbitData);
				property = type.GetProperty(inputName.Substring(3));
			}
			if (type != null)
			{
				if (property == null)
				{
					return InputControllerExpression.Create(inputName);
				}
				return new InputControllerInput
				{
					_activationGroupId = null,
					_targetPartId = null,
					_targetModifierId = null,
					_targetPropertyName = property.Name,
					_targetProperty = property,
					TargetType = typeof(CraftFlightData)
				};
			}
			char c = inputName[0];
			if (c == '-' || char.IsNumber(c))
			{
				if (float.TryParse(inputName, out var result2))
				{
					return new InputControllerInputConstant(result2);
				}
				return InputControllerExpression.Create(inputName);
			}
			int num = inputName.IndexOf('.');
			if (num == -1 || !Regex.IsMatch(inputName, "^[\\w ]+(?:\\.[\\w ]+){0,2}$"))
			{
				return InputControllerExpression.Create(inputName);
			}
			string text = inputName.Remove(num);
			inputName = ((inputName.Length <= num + 1) ? string.Empty : inputName.Substring(num + 1));
			num = inputName.IndexOf('.');
			if (num == -1)
			{
				return new InputControllerInputPartModifierWrapper(text, inputName);
			}
			string text2 = inputName.Remove(num);
			string text3 = ((inputName.Length <= num + 1) ? string.Empty : inputName.Substring(num + 1));
			TargetModifierType targetModifierType = TargetModifierType.Script;
			if (text3.StartsWith("Data.", StringComparison.Ordinal))
			{
				targetModifierType = TargetModifierType.Data;
				text3 = text3.Substring(5);
			}
			else if (text2 == "FlightProgram" || text2 == "VZ")
			{
				targetModifierType = TargetModifierType.FlightProgram;
			}
			return new InputControllerInput
			{
				_activationGroupId = null,
				_targetPartId = text,
				_targetModifierId = text2,
				_targetModifierType = targetModifierType,
				_targetPropertyName = text3,
				_targetProperty = null,
				TargetType = null
			};
		}

		public static PartModifierData FindTargetModifier(IPartScript partScript, string targetPart, string targetModifier)
		{
			PartData partData = null;
			PartModifierData partModifierData;
			if (string.IsNullOrEmpty(targetPart))
			{
				partData = partScript.Data;
			}
			else
			{
				if (targetPart == "*")
				{
					partModifierData = null;
					if (partData == null && partScript.Data.GroupId.HasValue)
					{
						partModifierData = FindModifierIdInGroup(partScript.Data, targetModifier);
					}
					if (partModifierData == null)
					{
						partModifierData = partScript.CraftScript.Data.FindModifierById(targetModifier);
					}
					return partModifierData;
				}
				if (targetPart[0] == '$' && int.TryParse(targetPart.Substring(1), out var result))
				{
					partData = partScript.CraftScript.Data.Assembly.GetPartById(result);
				}
				else
				{
					if (partData == null && partScript.Data.GroupId.HasValue)
					{
						partData = FindConnectedPartInGroup(partScript.Data, targetPart);
					}
					if (partData == null)
					{
						partData = partScript.CraftScript.Data.Assembly.GetPartByName(targetPart);
					}
				}
			}
			if (partData == null)
			{
				return null;
			}
			partModifierData = partData.GetModifierById(targetModifier) ?? partData.GetModifierByTypeId(targetModifier);
			if (partModifierData == null && targetModifier == "ElectricMotor")
			{
				partModifierData = partData.GetModifierById("ElectricMotorOld") ?? partData.GetModifierByTypeId("ElectricMotorOld");
			}
			return partModifierData;
		}

		public static bool IsValidInput(PartModifierScript modifier, IPartScript part)
		{
			if (modifier == null)
			{
				return false;
			}
			IPartScript partScript = modifier.PartScript;
			if (partScript.CraftScript != part.CraftScript)
			{
				return false;
			}
			if (partScript.Disconnected != part.Disconnected)
			{
				return false;
			}
			if (part.Disconnected)
			{
				IBodyScript bodyScript = part.BodyScript;
				if (bodyScript == null || !bodyScript.PartIsland.ContainsPart(partScript.Data))
				{
					return false;
				}
			}
			return true;
		}

		public void RefreshInput(IPartScript partScript)
		{
			if (TargetType == typeof(CraftControls))
			{
				CraftControls craftControls = partScript.CommandPod?.Controls;
				if (craftControls != null && !partScript.Disconnected)
				{
					if (_getInput == null || craftControls != _targetInstance)
					{
						if (_activationGroupId.HasValue)
						{
							_getInput = CreateActivationGroupInputDelegate(craftControls);
						}
						else
						{
							_getInput = CreateInputDelegate(craftControls, _targetProperty);
						}
					}
				}
				else
				{
					_getInput = null;
				}
			}
			else if (TargetType == typeof(CraftFlightData))
			{
				ICraftFlightData flightData = partScript.CraftScript.FlightData;
				if (flightData != null && !partScript.Disconnected)
				{
					if (_getInput == null || flightData != _targetInstance)
					{
						_getInput = CreateInputDelegate(flightData, _targetProperty);
					}
				}
				else
				{
					_getInput = null;
				}
			}
			else if (TargetType == typeof(CraftOrbitData))
			{
				ICraftOrbitData orbit = partScript.CraftScript.FlightData.Orbit;
				if (orbit != null && !partScript.Disconnected)
				{
					if (_getInput == null || orbit != _targetInstance)
					{
						_getInput = CreateInputDelegate(orbit, _targetProperty);
					}
				}
				else
				{
					_getInput = null;
				}
			}
			else if (_targetModifierType == TargetModifierType.Script)
			{
				PartModifierScript partModifierScript = _targetInstance as PartModifierScript;
				if (!IsValidInput(partModifierScript, partScript))
				{
					partModifierScript = FindTargetModifier(partScript, _targetPartId, _targetModifierId)?.GetScript();
					if (!IsValidInput(partModifierScript, partScript))
					{
						partModifierScript = null;
					}
				}
				if (partModifierScript != null)
				{
					if (_getInput == null || partModifierScript != _targetInstance)
					{
						Type type = partModifierScript.GetType();
						if (type != TargetType)
						{
							TargetType = type;
							_targetProperty = type.GetProperty(_targetPropertyName);
							if (_targetProperty == null)
							{
								Type[] interfaces = type.GetInterfaces();
								foreach (Type type2 in interfaces)
								{
									_targetProperty = type2.GetProperty(_targetPropertyName);
									if (_targetProperty != null)
									{
										break;
									}
								}
								if (_targetProperty == null)
								{
									Debug.LogWarning($"Could not find input '{_targetPropertyName}' on part modifier of type '{type}'.");
								}
							}
						}
						_getInput = ((_targetProperty == null) ? null : CreateInputDelegate(partModifierScript, _targetProperty));
					}
				}
				else
				{
					_getInput = null;
				}
			}
			else if (_targetModifierType == TargetModifierType.Data)
			{
				PartModifierData partModifierData = _targetInstance as PartModifierData;
				if (!IsValidInput(partModifierData?.GetScript(), partScript))
				{
					partModifierData = FindTargetModifier(partScript, _targetPartId, _targetModifierId);
					if (!IsValidInput(partModifierData?.GetScript(), partScript))
					{
						partModifierData = null;
					}
				}
				if (partModifierData != null)
				{
					if (_getInput == null || partModifierData != _targetInstance)
					{
						Type type3 = partModifierData.GetType();
						if (type3 != TargetType)
						{
							TargetType = type3;
							_targetProperty = type3.GetProperty(_targetPropertyName);
							if (_targetProperty == null)
							{
								Debug.LogWarning($"Could not find input '{_targetPropertyName}' on part modifier of type '{type3}'.");
							}
						}
						_getInput = ((_targetProperty == null) ? null : CreateInputDelegate(partModifierData, _targetProperty));
					}
				}
				else
				{
					_getInput = null;
				}
			}
			else if (_targetModifierType == TargetModifierType.FlightProgram)
			{
				FlightProgramScript flightProgramScript = _targetInstance as FlightProgramScript;
				if (!IsValidInput(flightProgramScript, partScript))
				{
					flightProgramScript = FindTargetModifier(partScript, _targetPartId, "FlightProgram")?.GetScript() as FlightProgramScript;
					if (!IsValidInput(flightProgramScript, partScript))
					{
						flightProgramScript = null;
					}
				}
				if (flightProgramScript != null)
				{
					if (_getInput == null || flightProgramScript != _targetInstance)
					{
						_getInput = CreateFlightProgramVariableDelegate(flightProgramScript, _targetPropertyName);
					}
				}
				else
				{
					_getInput = null;
				}
			}
			_enabled = _getInput != null;
			if (_getInput == null)
			{
				_targetInstance = null;
			}
		}

		private static PartData FindConnectedPartInGroup(PartData part, string partName)
		{
			HashSet<int> visitedParts = new HashSet<int> { part.Id };
			return FindConnectedPartInGroup(part, partName, visitedParts);
		}

		private static PartData FindConnectedPartInGroup(PartData part, string partName, HashSet<int> visitedParts)
		{
			if (part.Name == partName)
			{
				return part;
			}
			foreach (PartConnection partConnection in part.PartConnections)
			{
				PartData otherPart = partConnection.GetOtherPart(part);
				Guid? groupId = otherPart.GroupId;
				Guid? groupId2 = part.GroupId;
				if (groupId.HasValue == groupId2.HasValue && (!groupId.HasValue || groupId.GetValueOrDefault() == groupId2.GetValueOrDefault()) && visitedParts.Add(otherPart.Id))
				{
					PartData partData = FindConnectedPartInGroup(otherPart, partName, visitedParts);
					if (partData != null)
					{
						return partData;
					}
				}
			}
			return null;
		}

		private static PartModifierData FindModifierIdInGroup(PartData part, string modifierId)
		{
			HashSet<int> visitedParts = new HashSet<int> { part.Id };
			return FindModifierIdInGroup(part, modifierId, visitedParts);
		}

		private static PartModifierData FindModifierIdInGroup(PartData part, string modifierId, HashSet<int> visitedParts)
		{
			foreach (PartModifierData modifier in part.Modifiers)
			{
				if (modifier.Id == modifierId)
				{
					return modifier;
				}
			}
			foreach (PartConnection partConnection in part.PartConnections)
			{
				PartData otherPart = partConnection.GetOtherPart(part);
				Guid? groupId = otherPart.GroupId;
				Guid? groupId2 = part.GroupId;
				if (groupId.HasValue == groupId2.HasValue && (!groupId.HasValue || groupId.GetValueOrDefault() == groupId2.GetValueOrDefault()) && visitedParts.Add(otherPart.Id))
				{
					PartModifierData partModifierData = FindModifierIdInGroup(otherPart, modifierId, visitedParts);
					if (partModifierData != null)
					{
						return partModifierData;
					}
				}
			}
			return null;
		}

		private Func<float> CreateActivationGroupInputDelegate(CraftControls controls)
		{
			_targetInstance = controls;
			return () => controls.GetActivationGroup(_activationGroupId.Value) ? 1 : (-1);
		}

		private Func<float> CreateFlightProgramVariableDelegate(FlightProgramScript modifier, string variableName)
		{
			_targetInstance = modifier;
			return delegate
			{
				ExpressionResult expressionResult = modifier?.GetGlobalVariable(variableName);
				return (expressionResult != null) ? ((float)expressionResult.NumberValue) : 0f;
			};
		}

		private Func<float> CreateInputDelegate(object target, PropertyInfo property)
		{
			_targetInstance = target;
			if (property.PropertyType == typeof(float))
			{
				return (Func<float>)property.GetGetMethod().CreateDelegate(typeof(Func<float>), target);
			}
			if (property.PropertyType == typeof(double))
			{
				Func<double> getter = (Func<double>)property.GetGetMethod().CreateDelegate(typeof(Func<double>), target);
				return () => (float)getter();
			}
			if (property.PropertyType == typeof(bool))
			{
				Func<bool> getter2 = (Func<bool>)property.GetGetMethod().CreateDelegate(typeof(Func<bool>), target);
				return () => getter2() ? 1 : (-1);
			}
			_targetInstance = null;
			Debug.LogError("'" + property.Name + "' is unsupported. Only float, double, and boolean properties are supported as input controller inputs.");
			return () => 0f;
		}
	}
}
