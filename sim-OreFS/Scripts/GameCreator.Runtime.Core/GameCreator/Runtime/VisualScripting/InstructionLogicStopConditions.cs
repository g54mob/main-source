using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Stop Conditions")]
	[Description("Stops a Conditions component object that is being executed")]
	[Category("Visual Scripting/Stop Conditions")]
	[Parameter("Conditions", "The Conditions object that is stopped")]
	[Keywords(new string[] { "Cancel", "Pause" })]
	[Image(typeof(IconConditions), ColorTheme.Type.Red, typeof(OverlayCross))]
	public class InstructionLogicStopConditions : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Conditions = GetGameObjectConditions.Create();

		public override string Title => $"Stop {m_Conditions}";

		protected override Task Run(Args args)
		{
			Conditions conditions = m_Conditions.Get<Conditions>(args);
			if (conditions == null)
			{
				return Instruction.DefaultResult;
			}
			conditions.Cancel();
			return Instruction.DefaultResult;
		}
	}
}
