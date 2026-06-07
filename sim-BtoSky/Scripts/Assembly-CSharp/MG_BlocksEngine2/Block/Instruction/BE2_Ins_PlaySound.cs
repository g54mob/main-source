using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Utils;
using UnityEngine;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_PlaySound : BE2_InstructionBase, I_BE2_Instruction
	{
		private BE2_Dropdown _dropdown;

		private string _value;

		private void PopulateDropdown()
		{
			_dropdown.ClearOptions();
			AudioClip[] audiosArray = BE2_AudioManager.instance.audiosArray;
			foreach (AudioClip audioClip in audiosArray)
			{
				_dropdown.AddOption(audioClip.name);
			}
			_dropdown.value = 1;
			_dropdown.RefreshShownValue();
			_dropdown.value = 0;
		}

		protected override void OnStart()
		{
			_dropdown = BE2_Dropdown.GetBE2Component(GetSectionInputs(0)[0].Transform);
			if (_dropdown != null)
			{
				PopulateDropdown();
			}
		}

		public new void Function()
		{
			_value = base.Section0Inputs[0].StringValue;
			int indexOf = _dropdown.GetIndexOf(_value);
			BE2_AudioManager.instance.PlaySound(indexOf);
			ExecuteNextInstruction();
		}
	}
}
