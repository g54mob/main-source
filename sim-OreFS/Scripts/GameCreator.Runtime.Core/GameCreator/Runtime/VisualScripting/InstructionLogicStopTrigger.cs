using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Stop Trigger")]
	[Description("Stops a Trigger component object that is being executed")]
	[Category("Visual Scripting/Stop Trigger")]
	[Parameter("Trigger", "The Trigger object that is stopped")]
	[Keywords(new string[] { "Cancel", "Pause" })]
	[Image(typeof(IconTriggers), ColorTheme.Type.Red, typeof(OverlayCross))]
	public class InstructionLogicStopTrigger : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Trigger = GetGameObjectTrigger.Create();

		public override string Title => $"Stop {m_Trigger}";

		protected override Task Run(Args args)
		{
			Trigger trigger = m_Trigger.Get<Trigger>(args);
			if (trigger == null)
			{
				return Instruction.DefaultResult;
			}
			trigger.Cancel();
			return Instruction.DefaultResult;
		}
	}
}
