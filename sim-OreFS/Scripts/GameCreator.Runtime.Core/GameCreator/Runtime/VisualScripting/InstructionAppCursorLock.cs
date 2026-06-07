using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Lock Cursor")]
	[Description("Determines if the hardware pointer is locked to the center of the view or not")]
	[Category("Application/Cursor/Lock Cursor")]
	[Parameter("Lock Mode", "The behavior of the cursor. The default value is None")]
	[Keywords(new string[] { "Mouse", "State", "FPS", "Center", "Confine" })]
	[Image(typeof(IconCursor), ColorTheme.Type.Blue)]
	public class InstructionAppCursorLock : Instruction
	{
		[SerializeField]
		private CursorLockMode m_LockMode = CursorLockMode.Locked;

		public override string Title => $"Set Cursor to {TextUtils.Humanize(m_LockMode.ToString())}";

		protected override Task Run(Args args)
		{
			Cursor.lockState = m_LockMode;
			return Instruction.DefaultResult;
		}
	}
}
