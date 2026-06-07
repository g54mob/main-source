using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Cursor Texture")]
	[Description("Changes the image of the hardware cursor")]
	[Category("Application/Cursor/Cursor Texture")]
	[Parameter("Texture", "The new appearance of the cursor. The texture must be set to Cursor type")]
	[Parameter("Tip", "The offset from the top left of the texture used as the target point")]
	[Parameter("Mode", "Determines if the cursor is rendered using software or hardware rendering")]
	[Keywords(new string[] { "Mouse", "Crosshair", "Click" })]
	[Image(typeof(IconCursor), ColorTheme.Type.Yellow)]
	public class InstructionCursorTexture : Instruction
	{
		[SerializeField]
		private PropertyGetTexture m_Texture = new PropertyGetTexture();

		[SerializeField]
		private Vector2 m_Tip = Vector2.zero;

		[SerializeField]
		private CursorMode m_Mode;

		public override string Title => $"Set Cursor Texture to {m_Texture}";

		protected override Task Run(Args args)
		{
			Cursor.SetCursor(m_Texture.Get(args) as Texture2D, m_Tip, m_Mode);
			return Instruction.DefaultResult;
		}
	}
}
