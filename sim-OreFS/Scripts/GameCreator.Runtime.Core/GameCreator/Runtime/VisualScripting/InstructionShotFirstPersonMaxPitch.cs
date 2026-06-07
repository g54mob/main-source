using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Max Pitch")]
	[Category("Cameras/Shots/First Person/Change Max Pitch")]
	[Description("Changes the maximum rotation (up and down) allowed")]
	[Parameter("Max Pitch", "The amount the Shot is allowed to look up and down, in degrees")]
	public class InstructionShotFirstPersonMaxPitch : TInstructionShotFirstPerson
	{
		[SerializeField]
		private PropertyGetDecimal m_MaxPitch = GetDecimalDecimal.Create(60f);

		public override string Title => $"Set {m_Shot}[First Person] Max Pitch = {m_MaxPitch}";

		protected override Task Run(Args args)
		{
			ShotSystemFirstPerson shotSystem = GetShotSystem<ShotSystemFirstPerson>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.MaxPitch = (float)m_MaxPitch.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
