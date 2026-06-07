using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Check Conditions")]
	[Description("If any of the Conditions list is false it early exits and skips the execution of the rest of the Instructions below")]
	[Category("Visual Scripting/Check Conditions")]
	[Parameter("Conditions", "List of Conditions that can evaluate to true or false")]
	[Parameter("Mode", "Whether to check the Conditions as an AND or an OR set")]
	[Keywords(new string[] { "Execute", "Call", "Check", "Evaluate" })]
	[Image(typeof(IconCondition), ColorTheme.Type.Green)]
	public class InstructionLogicCheckConditions : Instruction
	{
		[SerializeField]
		private ConditionList m_Conditions = new ConditionList();

		public override string Title => (string)((m_Conditions.Length switch
		{
			0 => "(none)", 
			1 => "Check " + (m_Conditions.Get(0)?.Title ?? "(unknown)"), 
			_ => $"Check {m_Conditions.Length} Conditions", 
		}) ?? "");

		protected override Task Run(Args args)
		{
			if (!m_Conditions.Check(args, CheckMode.And))
			{
				base.NextInstruction = int.MaxValue;
			}
			return Instruction.DefaultResult;
		}
	}
}
