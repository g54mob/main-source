using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Stop Actions")]
	[Description("Stops an Actions component object that is being executed")]
	[Category("Visual Scripting/Stop Actions")]
	[Parameter("Actions", "The Actions object that is stopped")]
	[Keywords(new string[] { "Cancel", "Pause" })]
	[Image(typeof(IconInstructions), ColorTheme.Type.Red, typeof(OverlayCross))]
	public class InstructionLogicStopActions : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Actions = GetGameObjectActions.Create();

		public override string Title => $"Stop {m_Actions}";

		protected override Task Run(Args args)
		{
			Actions actions = m_Actions.Get<Actions>(args);
			if (actions == null)
			{
				return Instruction.DefaultResult;
			}
			actions.Cancel();
			return Instruction.DefaultResult;
		}
	}
}
