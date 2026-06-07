using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class VariableSystemScript : MonoBehaviour
	{
		private static readonly string[] _defaultVariableNames;

		private static readonly MethodInfo _variableGetMethod;

		private static readonly Regex _variableNameRegex;

		private bool _initialised;

		private Dictionary<string, AircraftVariable> _nameLookup = new Dictionary<string, AircraftVariable>();

		private bool _queueRefresh;

		public AircraftScript AircraftScript { get; set; }

		public List<IVariableOutput> OutputScripts { get; private set; } = new List<IVariableOutput>();

		public List<VariableSetter> Setters { get; private set; }

		public List<AircraftVariable> Variables { get; private set; } = new List<AircraftVariable>();

		static VariableSystemScript()
		{
			_defaultVariableNames = new string[1] { "RotorRPM" };
			_variableGetMethod = typeof(AircraftVariable).GetProperty("Value", BindingFlags.Instance | BindingFlags.Public).GetGetMethod();
			_variableNameRegex = new Regex("[A-z_][A-z_0-9]*");
		}

		public AircraftVariable AddVariable(string name)
		{
			if (!_variableNameRegex.IsMatch(name))
			{
				throw new Exception("Variable name " + name + " is invalid: Names can contain letters, numbers and underscores but must not start with a number.");
			}
			if (_nameLookup.TryGetValue(name, out var value))
			{
				return value;
			}
			if (AircraftScript.ExpressionContext.Properties.ContainsKey(name))
			{
				throw new Exception("Variable: '" + name + "' is already a built in variable");
			}
			AircraftVariable aircraftVariable = new AircraftVariable(name);
			Variables.Add(aircraftVariable);
			_nameLookup.Add(name, aircraftVariable);
			AircraftScript.ExpressionContext.AddVariable(name, _variableGetMethod, aircraftVariable);
			return aircraftVariable;
		}

		public void Initialise(List<VariableSetter> setters, AircraftScript aircraft)
		{
			AircraftScript = aircraft;
			Setters = setters;
		}

		public void RecompileAll()
		{
			RefreshVariables();
			foreach (VariableSetter setter in Setters)
			{
				setter.Compile(AircraftScript);
			}
			foreach (IVariableOutput outputScript in OutputScripts)
			{
				foreach (VariableOutput variableOutput in outputScript.PartModifier.VariableOutputs)
				{
					variableOutput.Compile();
				}
			}
		}

		public void RefreshVariables()
		{
			foreach (AircraftVariable value2 in _nameLookup.Values)
			{
				value2._used = false;
			}
			string[] defaultVariableNames = _defaultVariableNames;
			foreach (string text in defaultVariableNames)
			{
				EnsureExists(text);
			}
			foreach (VariableSetter setter in Setters)
			{
				EnsureExists(setter.VariableName);
			}
			OutputScripts.Clear();
			foreach (PartData part in AircraftScript.Aircraft.Assembly.Parts)
			{
				foreach (PartModifierScript modifier in part.PartScript.Modifiers)
				{
					if (!(modifier is IVariableOutput variableOutput))
					{
						continue;
					}
					foreach (VariableOutput variableOutput2 in modifier.PartModifier.VariableOutputs)
					{
						variableOutput2.Enabled = EnsureExists(variableOutput2.Variable, logWarning: false);
						if (!variableOutput2.Enabled)
						{
							Debug.LogWarning($"Invalid output variable name '{variableOutput2.Variable}' on part {part.Id}");
						}
					}
					if (variableOutput is IVariableDeclarations variableDeclarations)
					{
						IEnumerator<string> variableOutputs = variableDeclarations.GetVariableOutputs();
						while (variableOutputs.MoveNext())
						{
							EnsureExists(variableOutputs.Current);
						}
					}
					OutputScripts.Add(variableOutput);
				}
			}
			AircraftVariable[] array = Variables.ToArray();
			foreach (AircraftVariable aircraftVariable in array)
			{
				if (!aircraftVariable._used)
				{
					RemoveVariable(aircraftVariable);
				}
			}
			bool EnsureExists(string name, bool logWarning = true)
			{
				try
				{
					if (_nameLookup.TryGetValue(name, out var value))
					{
						value._used = true;
					}
					else
					{
						AddVariable(name);
					}
					return true;
				}
				catch (Exception ex)
				{
					if (logWarning)
					{
						Debug.LogWarning("Invalid variable name: " + name + "\nMessage: " + ex.Message);
					}
					return false;
				}
			}
		}

		public void RemoveVariable(AircraftVariable av)
		{
			Variables.Remove(av);
			_nameLookup.Remove(av.Name);
			AircraftScript.ExpressionContext.Properties.Remove(av.Name);
		}

		protected virtual void FixedUpdate()
		{
			if (!_initialised)
			{
				return;
			}
			foreach (AircraftVariable variable in Variables)
			{
				variable.StartFrame();
			}
			foreach (IVariableOutput outputScript in OutputScripts)
			{
				if (outputScript.PartModifier.VariableOutputs.Count == 0 && !(outputScript is IVariableDeclarations))
				{
					continue;
				}
				outputScript.UpdateOutputs();
				foreach (VariableOutput variableOutput in outputScript.PartModifier.VariableOutputs)
				{
					if (variableOutput.IsActivated && variableOutput.Enabled)
					{
						_nameLookup[variableOutput.Variable].SetValue(variableOutput.Value, variableOutput.Priority);
					}
				}
			}
			foreach (VariableSetter setter in Setters)
			{
				if (setter.IsCompiled && setter.Activated)
				{
					try
					{
						_nameLookup[setter.VariableName].SetValue(setter.Value, setter.Priority);
					}
					catch (KeyNotFoundException exception)
					{
						Debug.LogException(exception);
						base.enabled = false;
					}
				}
			}
			foreach (AircraftVariable variable2 in Variables)
			{
				variable2.EndWritablePhase();
			}
		}

		protected virtual void Start()
		{
			if (AircraftScript.LoadContext == CraftLoadContext.Flight)
			{
				UniTask.RunOnThreadPool(delegate
				{
					List<VariableSetter> list = null;
					foreach (VariableSetter setter in Setters)
					{
						try
						{
							setter.Compile(AircraftScript);
						}
						catch (Exception arg)
						{
							Debug.LogWarning($"Variable error: {arg}");
						}
					}
					if (list != null)
					{
						foreach (VariableSetter item in list)
						{
							Setters.Remove(item);
						}
					}
					_initialised = true;
				}).Forget();
			}
			else
			{
				RefreshVariables();
				_queueRefresh = false;
			}
		}

		protected virtual void Update()
		{
			if (_queueRefresh)
			{
				_queueRefresh = false;
				RefreshVariables();
			}
		}
	}
}
