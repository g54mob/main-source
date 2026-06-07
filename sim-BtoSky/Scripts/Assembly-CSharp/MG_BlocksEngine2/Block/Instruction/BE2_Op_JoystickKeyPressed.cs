using MG_BlocksEngine2.UI;

namespace MG_BlocksEngine2.Block.Instruction
{
	public class BE2_Op_JoystickKeyPressed : BE2_InstructionBase, I_BE2_Instruction
	{
		private BE2_VirtualJoystick _virtualJoystick;

		protected override void OnStart()
		{
			_virtualJoystick = BE2_VirtualJoystick.instance;
		}

		public new string Operation()
		{
			if (_virtualJoystick.keys[(int)base.Section0Inputs[0].FloatValue].isPressed)
			{
				return "1";
			}
			return "0";
		}
	}
}
