using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Alignment")]
	[Category("Cameras/Shots/Third Person/Change Alignment")]
	[Description("Changes whether and how the Shot aligns behind the targeted object")]
	[Parameter("Align with Target", "If the Shot should move behind the target after some idle time")]
	[Parameter("Delay", "If the Shot should move behind the target after some idle time")]
	[Parameter("Smooth Time", "The speed at which ")]
	[MovedFrom(true, "GameCreator.Runtime.VisualScripting", "GameCreator.Runtime.Core", "InstructionShotOrbitAlignment")]
	public class InstructionShotThirdPersonAlignment : TInstructionShotThirdPerson
	{
		[SerializeField]
		private bool m_AutoAlign = true;

		[SerializeField]
		private float m_Delay = 3f;

		[SerializeField]
		private float m_SmoothTime = 5f;

		public override string Title => string.Format("Set {0}[Third Person] Align = {1}", m_Shot, m_AutoAlign ? "Yes" : "No");

		protected override Task Run(Args args)
		{
			ShotSystemThirdPerson shotSystem = GetShotSystem<ShotSystemThirdPerson>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Alignment.AutoAlign = m_AutoAlign;
			shotSystem.Alignment.Delay = m_Delay;
			shotSystem.Alignment.SmoothTime = m_SmoothTime;
			return Instruction.DefaultResult;
		}
	}
}
