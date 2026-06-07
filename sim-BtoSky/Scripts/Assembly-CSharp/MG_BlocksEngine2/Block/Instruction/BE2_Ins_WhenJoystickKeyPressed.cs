using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.UI;
using MG_BlocksEngine2.Utils;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Ins_WhenJoystickKeyPressed : BE2_InstructionBase, I_BE2_Instruction
	{
		private BE2_Dropdown _dropdown;

		private BE2_VirtualJoystick _virtualJoystick;

		protected override void OnStart()
		{
			_dropdown = BE2_Dropdown.GetBE2Component(GetSectionInputs(0)[0].Transform);
			_virtualJoystick = BE2_VirtualJoystick.instance;
		}

		protected override void OnEnableInstruction()
		{
			BE2_ExecutionManager.Instance.AddToUpdate(OnUpdate);
		}

		protected override void OnDisableInstruction()
		{
			BE2_ExecutionManager.Instance.RemoveFromUpdate(OnUpdate);
		}

		protected override void OnAwake()
		{
			base.BlocksStack.OnStackLastBlockExecuted.AddListener(EndExecution);
		}

		private void EndExecution()
		{
			if (!_virtualJoystick.keys[_dropdown.value].isPressed)
			{
				base.BlocksStack.IsActive = false;
			}
		}

		private void OnUpdate()
		{
			if (!base.BlocksStack.IsActive && (bool)_virtualJoystick && _virtualJoystick.keys[_dropdown.value].isPressed)
			{
				base.BlocksStack.IsActive = true;
			}
		}

		public new void Function()
		{
			ExecuteSection(0);
		}
	}
}
