using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine.EventSystems;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Unfocus")]
	[Category("UI/Unfocus")]
	[Image(typeof(IconBullsEye), ColorTheme.Type.TextLight, typeof(OverlayCross))]
	[Description("Removes the focus from any UI component")]
	[Keywords(new string[] { "Deselect", "Lose" })]
	public class InstructionUIUnfocus : Instruction
	{
		public override string Title => "Unfocus";

		protected override Task Run(Args args)
		{
			if (EventSystem.current == null)
			{
				return Instruction.DefaultResult;
			}
			EventSystem.current.SetSelectedGameObject(null);
			return Instruction.DefaultResult;
		}
	}
}
