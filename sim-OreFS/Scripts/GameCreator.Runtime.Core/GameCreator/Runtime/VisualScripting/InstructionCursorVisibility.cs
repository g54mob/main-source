using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Cursor Visibility")]
	[Description("Determines if the hardware cursor is visible or not")]
	[Category("Application/Cursor/Cursor Visibility")]
	[Parameter("Is Visible", "If true the cursor is visible, unless it is set as Locked")]
	[Keywords(new string[] { "Mouse", "FPS", "Crosshair" })]
	[Image(typeof(IconCursor), ColorTheme.Type.Yellow)]
	public class InstructionCursorVisibility : Instruction
	{
		[SerializeField]
		private PropertyGetBool m_IsVisible = new PropertyGetBool(value: true);

		public override string Title => $"Set Cursor Visibility to {m_IsVisible}";

		protected override Task Run(Args args)
		{
			Cursor.visible = m_IsVisible.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
