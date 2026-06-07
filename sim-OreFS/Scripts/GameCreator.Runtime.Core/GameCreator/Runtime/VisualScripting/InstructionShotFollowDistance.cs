using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Distance")]
	[Category("Cameras/Shots/Follow/Change Distance")]
	[Description("Changes the offset distance between the Shot and the targeted object")]
	[Parameter("Distance", "The new offset distance in world coordinates")]
	[Keywords(new string[] { "Cameras", "Track", "View" })]
	public class InstructionShotFollowDistance : TInstructionShotFollow
	{
		[SerializeField]
		private PropertyGetPosition m_Offset = GetPositionVector3.Create();

		public override string Title => $"Set {m_Shot}[Follow] Distance = {m_Offset}";

		protected override Task Run(Args args)
		{
			ShotSystemFollow shotSystem = GetShotSystem<ShotSystemFollow>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Distance = m_Offset.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
