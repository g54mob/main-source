using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Smooth Time")]
	[Category("Cameras/Shots/First Person/Change Smooth Time")]
	[Description("Changes the maximum rotation (up and down) allowed")]
	[Parameter("Smooth Time", "How smooth the camera operates when rotating")]
	public class InstructionShotFirstPersonSmoothTime : TInstructionShotFirstPerson
	{
		[SerializeField]
		private PropertyGetDecimal m_SmoothTime = GetDecimalDecimal.Create(0.1f);

		public override string Title => $"Set {m_Shot}[First Person] Smooth Time = {m_SmoothTime}";

		protected override Task Run(Args args)
		{
			ShotSystemFirstPerson shotSystem = GetShotSystem<ShotSystemFirstPerson>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.SmoothTime = (float)m_SmoothTime.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
