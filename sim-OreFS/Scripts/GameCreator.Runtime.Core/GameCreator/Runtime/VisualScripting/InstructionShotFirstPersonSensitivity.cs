using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Sensitivity")]
	[Category("Cameras/Shots/First Person/Change Sensitivity")]
	[Description("Changes how sensitive the Shot reacts to input")]
	[Parameter("Sensitivity", "Input sensitivity for X and the Y axis")]
	public class InstructionShotFirstPersonSensitivity : TInstructionShotFirstPerson
	{
		[SerializeField]
		private PropertyGetPosition m_Sensitivity = GetPositionVector3.Create(new Vector3(180f, 180f));

		public override string Title => $"Set {m_Shot}[First Person] Sensitivity = {m_Sensitivity}";

		protected override Task Run(Args args)
		{
			ShotSystemFirstPerson shotSystem = GetShotSystem<ShotSystemFirstPerson>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Sensitivity = m_Sensitivity.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
