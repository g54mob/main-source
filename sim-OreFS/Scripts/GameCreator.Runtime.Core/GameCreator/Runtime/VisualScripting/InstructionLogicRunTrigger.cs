using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Run Trigger")]
	[Description("Executes a Trigger component object")]
	[Category("Visual Scripting/Run Trigger")]
	[Parameter("Trigger", "The Trigger object that is executed")]
	[Parameter("Wait Until Complete", "If true this instruction waits until the Trigger object finishes running")]
	[Keywords(new string[] { "Execute", "Call" })]
	[Image(typeof(IconTriggers), ColorTheme.Type.Yellow)]
	public class InstructionLogicRunTrigger : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Trigger = GetGameObjectTrigger.Create();

		[SerializeField]
		private bool m_WaitToFinish = true;

		public override string Title => string.Format("Run {0} {1}", m_Trigger, m_WaitToFinish ? "and wait" : string.Empty);

		protected override async Task Run(Args args)
		{
			Trigger trigger = m_Trigger.Get<Trigger>(args);
			if (!(trigger == null))
			{
				if (m_WaitToFinish)
				{
					await trigger.Execute(args);
				}
				else
				{
					trigger.Execute(args);
				}
			}
		}
	}
}
