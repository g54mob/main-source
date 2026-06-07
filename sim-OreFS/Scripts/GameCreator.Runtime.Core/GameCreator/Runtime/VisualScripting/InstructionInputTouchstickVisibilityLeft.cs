using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Display Touchstick Left")]
	[Description("Shows or hides the default Touchstick on the left side")]
	[Category("Input/Display Touchstick Left")]
	[Parameter("Show", "Shows the touchstick if ticked. Hides the touchstick otherwise")]
	[Keywords(new string[] { "Joystick" })]
	[Image(typeof(IconTouchstick), ColorTheme.Type.Yellow, typeof(OverlayArrowLeft))]
	public class InstructionInputTouchstickVisibilityLeft : Instruction
	{
		[SerializeField]
		private PropertyGetBool m_Show = GetBoolValue.Create(value: false);

		public override string Title => $"Show Left Touchstick: {m_Show}";

		protected override Task Run(Args args)
		{
			GameObject iNSTANCE = TouchStickLeft.INSTANCE;
			if (iNSTANCE == null)
			{
				return Instruction.DefaultResult;
			}
			bool active = m_Show.Get(args);
			iNSTANCE.SetActive(active);
			return Instruction.DefaultResult;
		}
	}
}
