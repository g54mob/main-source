using System.Collections.Generic;
using System.Globalization;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Utils;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_AddVariable : BE2_InstructionBase, I_BE2_Instruction
	{
		private string _vs0;

		private BE2_InputValues _v1;

		private BE2_InputValues _varValues;

		private string _lastValue;

		private BE2_Dropdown _dropdown;

		private BE2_VariablesManager _variablesManager;

		protected override void OnStart()
		{
			_variablesManager = BE2_VariablesManager.instance;
			_dropdown = BE2_Dropdown.GetBE2Component(GetSectionInputs(0)[0].Transform);
			if (_dropdown != null)
			{
				_dropdown.onValueChanged.AddListener(delegate
				{
					_lastValue = _dropdown.GetSelectedOptionText();
				});
				BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnAnyVariableAddedOrRemoved, PopulateDropdown);
				PopulateDropdown();
			}
		}

		private void OnDisable()
		{
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnAnyVariableAddedOrRemoved, PopulateDropdown);
		}

		private void PopulateDropdown()
		{
			_dropdown.ClearOptions();
			foreach (KeyValuePair<string, string> variables in _variablesManager.variablesList)
			{
				_dropdown.AddOption(variables.Key);
			}
			_dropdown.RefreshShownValue();
			_dropdown.value = _dropdown.GetIndexOf(_lastValue);
		}

		public new void Function()
		{
			_vs0 = base.Section0Inputs[0].StringValue;
			_v1 = base.Section0Inputs[1].InputValues;
			_varValues = _variablesManager.GetVariableValues(_vs0);
			if (_varValues.isText || _v1.isText)
			{
				_variablesManager.AddOrUpdateVariable(_vs0, _varValues.stringValue + _v1.stringValue);
			}
			else
			{
				float num = _varValues.floatValue + _v1.floatValue;
				_variablesManager.AddOrUpdateVariable(_vs0, num.ToString(CultureInfo.InvariantCulture));
			}
			ExecuteNextInstruction();
		}
	}
}
