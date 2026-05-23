using System.Collections.Generic;
using System.Globalization;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.UI;
using UnityEngine;

namespace MG_BlocksEngine2.Environment
{
	public class BE2_VariablesManager : MonoBehaviour, I_BE2_VariablesManager
	{
		public static BE2_VariablesManager instance;

		public BE2_UI_NewVariablePanel newVariablePanel;

		public Dictionary<string, string> variablesList;

		private void Awake()
		{
			instance = this;
			variablesList = new Dictionary<string, string>();
		}

		public bool ContainsVariable(string variable)
		{
			return variablesList.ContainsKey(variable);
		}

		public void AddOrUpdateVariable(string variable, string value)
		{
			if (!variablesList.ContainsKey(variable))
			{
				variablesList.Add(variable, value);
				BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableAddedOrRemoved);
			}
			else
			{
				variablesList[variable] = value;
			}
			BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableValueChanged);
		}

		public void RemoveVariable(string variable)
		{
			if (variablesList.ContainsKey(variable))
			{
				variablesList.Remove(variable);
			}
			BE2_MainEventsManager.Instance.TriggerEvent(BE2EventTypes.OnAnyVariableAddedOrRemoved);
		}

		public string GetVariableStringValue(string variable)
		{
			if (variablesList.ContainsKey(variable))
			{
				return variablesList[variable];
			}
			return "";
		}

		public float GetVariableFloatValue(string variable)
		{
			if (variablesList.ContainsKey(variable))
			{
				try
				{
					return float.Parse(variablesList[variable], CultureInfo.InvariantCulture);
				}
				catch
				{
					return 0f;
				}
			}
			return 0f;
		}

		public BE2_InputValues GetVariableValues(string variable)
		{
			bool flag = false;
			if (variablesList.ContainsKey(variable))
			{
				float floatValue = 0f;
				string text = variablesList[variable];
				try
				{
					floatValue = float.Parse(text, CultureInfo.InvariantCulture);
					flag = false;
				}
				catch
				{
					flag = true;
				}
				return new BE2_InputValues(text, floatValue, flag);
			}
			return new BE2_InputValues("", 0f, isText: false);
		}

		public void CreateAndAddVarToPanel(string varName)
		{
			if ((bool)newVariablePanel)
			{
				newVariablePanel.CreateVariable(varName);
			}
		}
	}
}
