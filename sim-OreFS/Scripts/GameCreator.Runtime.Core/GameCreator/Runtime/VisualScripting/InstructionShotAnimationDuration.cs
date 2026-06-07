using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Duration")]
	[Category("Cameras/Shots/Animation/Change Duration")]
	[Description("Changes the duration it takes for the Animation shot to complete")]
	[Parameter("Duration", "The new duration in seconds")]
	[Keywords(new string[] { "Cameras", "Track", "View" })]
	public class InstructionShotAnimationDuration : TInstructionShotAnimation
	{
		[SerializeField]
		private PropertyGetDecimal m_Duration = GetDecimalDecimal.Create(5f);

		public override string Title => $"Set {m_Shot}[Animation] Duration = {m_Duration}";

		protected override Task Run(Args args)
		{
			ShotSystemAnimation shotSystem = GetShotSystem<ShotSystemAnimation>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Duration = (float)m_Duration.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
