using System.Collections.Generic;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Utils;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Op_IndexOfValueAtList : BE2_InstructionBase, I_BE2_Instruction
	{
		private BE2_Dropdown _dropdown;

		private string _lastValue;

		private BE2_VariablesListManager _variablesManager;

		protected override void OnStart()
		{
			_variablesManager = BE2_VariablesListManager.instance;
			_dropdown = BE2_Dropdown.GetBE2Component(GetSectionInputs(0)[1].Transform);
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

		private void PopulateDropdown()
		{
			_dropdown.ClearOptions();
			foreach (KeyValuePair<string, List<string>> list in _variablesManager.lists)
			{
				_dropdown.AddOption(list.Key);
			}
			_dropdown.RefreshShownValue();
			_dropdown.value = _dropdown.GetIndexOf(_lastValue);
		}

		public new string Operation()
		{
			return _variablesManager.GetValueIndexAtList(base.Section0Inputs[1].StringValue, base.Section0Inputs[0].StringValue).ToString();
		}
	}
}
