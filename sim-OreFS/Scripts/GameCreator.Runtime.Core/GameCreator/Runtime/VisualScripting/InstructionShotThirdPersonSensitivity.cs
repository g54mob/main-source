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
	[Title("Change Sensitivity")]
	[Category("Cameras/Shots/Third Person/Change Sensitivity")]
	[Description("Changes how sensitive the Shot reacts to input")]
	[Parameter("Sensitivity", "Input sensitivity for X and the Y axis")]
	[MovedFrom(true, "GameCreator.Runtime.VisualScripting", "GameCreator.Runtime.Core", "InstructionShotOrbitSensitivity")]
	public class InstructionShotThirdPersonSensitivity : TInstructionShotThirdPerson
	{
		[SerializeField]
		private PropertyGetPosition m_Sensitivity = GetPositionVector3.Create(new Vector3(180f, 180f));

		public override string Title => $"Set {m_Shot}[Third Person] Sensitivity = {m_Sensitivity}";

		protected override Task Run(Args args)
		{
			ShotSystemThirdPerson shotSystem = GetShotSystem<ShotSystemThirdPerson>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Sensitivity = m_Sensitivity.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
