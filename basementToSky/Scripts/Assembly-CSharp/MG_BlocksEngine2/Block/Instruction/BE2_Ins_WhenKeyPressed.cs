using System;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Utils;
using UnityEngine;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_WhenKeyPressed : BE2_InstructionBase, I_BE2_Instruction
	{
		private BE2_Dropdown _dropdown;

		private KeyCode _key;

		private readonly string[] _availableKeys = new string[5] { "W", "A", "S", "D", "Q" };

		protected override void OnStart()
		{
			_dropdown = BE2_Dropdown.GetBE2Component(base.Section0Inputs[0].Transform);
			if (_dropdown != null)
			{
				PopulateDropdown();
				_dropdown.value = 0;
				ParseKeyCode();
				_dropdown.onValueChanged.AddListener(delegate
				{
					ParseKeyCode();
				});
			}
		}

		private void PopulateDropdown()
		{
			_dropdown.ClearOptions();
			string[] availableKeys = _availableKeys;
			foreach (string option in availableKeys)
			{
				_dropdown.AddOption(option);
			}
			_dropdown.RefreshShownValue();
		}

		private void ParseKeyCode()
		{
			if (Enum.TryParse<KeyCode>(_dropdown.GetSelectedOptionText(), out var result))
			{
				_key = result;
			}
		}

		protected override void OnEnableInstruction()
		{
			BE2_ExecutionManager.Instance.AddToUpdate(OnUpdate);
		}

		protected override void OnDisableInstruction()
		{
			BE2_ExecutionManager.Instance.RemoveFromUpdate(OnUpdate);
		}

		private void OnUpdate()
		{
			if (Input.GetKeyDown(_key))
			{
				base.BlocksStack.IsActive = true;
			}
			if (Input.GetKeyUp(_key))
			{
				base.BlocksStack.IsActive = false;
			}
		}

		public new void Function()
		{
			ExecuteSection(0);
		}
	}
}
