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
	[Category("Cameras/Shots/Anchor/Change Distance")]
	[Description("Changes the anchored position the Shot sits relative to the target")]
	[Parameter("Distance", "The new distance relative to the target in local coordinates")]
	[Keywords(new string[] { "Cameras", "View" })]
	public class InstructionShotAnchorDistance : TInstructionShotAnchor
	{
		[SerializeField]
		private PropertyGetPosition m_Distance = GetPositionVector3.Create();

		public override string Title => $"Set {m_Shot}[Anchor] Distance = {m_Distance}";

		protected override Task Run(Args args)
		{
			ShotSystemAnchor shotSystem = GetShotSystem<ShotSystemAnchor>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Distance = m_Distance.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
