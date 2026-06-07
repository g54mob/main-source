using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Run Actions")]
	[Description("Executes an Actions component object")]
	[Category("Visual Scripting/Run Actions")]
	[Parameter("Actions", "The Actions object that is executed")]
	[Parameter("Wait Until Complete", "If true this instruction waits until the Actions object finishes running")]
	[Keywords(new string[] { "Execute", "Call", "Instruction", "Action" })]
	[Image(typeof(IconInstructions), ColorTheme.Type.Blue)]
	public class InstructionLogicRunActions : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Actions = GetGameObjectActions.Create();

		[SerializeField]
		private bool m_WaitToFinish = true;

		public override string Title => string.Format("Run {0} {1}", m_Actions, m_WaitToFinish ? "and wait" : string.Empty);

		protected override async Task Run(Args args)
		{
			Actions actions = m_Actions.Get<Actions>(args);
			if (!(actions == null))
			{
				if (m_WaitToFinish)
				{
					await actions.Run(args);
				}
				else
				{
					actions.Run(args);
				}
			}
		}
	}
}
