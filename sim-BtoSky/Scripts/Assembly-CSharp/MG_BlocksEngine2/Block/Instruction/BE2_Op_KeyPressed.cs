using System;
using MG_BlocksEngine2.Utils;
using UnityEngine;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Op_KeyPressed : BE2_InstructionBase, I_BE2_Instruction
	{
		private BE2_Dropdown _dropdown;

		private readonly string[] _availableKeys = new string[5] { "W", "A", "S", "D", "Q" };

		protected override void OnStart()
		{
			_dropdown = BE2_Dropdown.GetBE2Component(base.Section0Inputs[0].Transform);
			if (_dropdown != null)
			{
				PopulateCustomDropdown();
				_dropdown.value = 0;
				_dropdown.RefreshShownValue();
			}
		}

		private void PopulateCustomDropdown()
		{
			_dropdown.ClearOptions();
			string[] availableKeys = _availableKeys;
			foreach (string option in availableKeys)
			{
				_dropdown.AddOption(option);
			}
			_dropdown.RefreshShownValue();
		}

		public new string Operation()
		{
			if (Enum.TryParse<KeyCode>(_dropdown.GetSelectedOptionText(), out var result) && Input.GetKey(result))
			{
				return "1";
			}
			return "0";
		}
	}
}
