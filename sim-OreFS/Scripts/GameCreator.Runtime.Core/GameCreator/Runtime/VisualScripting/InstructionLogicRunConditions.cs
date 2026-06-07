using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Run Conditions")]
	[Description("Executes a Conditions component object")]
	[Category("Visual Scripting/Run Conditions")]
	[Parameter("Conditions", "The Conditions object that is executed")]
	[Parameter("Wait Until Complete", "If true this instruction waits until the Conditions object finishes running")]
	[Keywords(new string[] { "Execute", "Call", "Check", "Evaluate" })]
	[Image(typeof(IconConditions), ColorTheme.Type.Green)]
	public class InstructionLogicRunConditions : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Conditions = GetGameObjectConditions.Create();

		[SerializeField]
		private bool m_WaitToFinish = true;

		public override string Title => string.Format("Run {0} {1}", m_Conditions, m_WaitToFinish ? "and wait" : string.Empty);

		protected override async Task Run(Args args)
		{
			Conditions conditions = m_Conditions.Get<Conditions>(args);
			if (!(conditions == null))
			{
				if (m_WaitToFinish)
				{
					await conditions.Run(args);
				}
				else
				{
					conditions.Run(args);
				}
			}
		}
	}
}
