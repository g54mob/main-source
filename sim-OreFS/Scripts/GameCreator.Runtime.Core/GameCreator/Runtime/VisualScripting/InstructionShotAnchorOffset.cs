using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Offset")]
	[Category("Cameras/Shots/Anchor/Change Offset")]
	[Description("Changes the offset position of the targeted object")]
	[Parameter("Offset", "The new offset in target local coordinates")]
	[Keywords(new string[] { "Cameras", "Track", "View" })]
	public class InstructionShotAnchorOffset : TInstructionShotAnchor
	{
		[SerializeField]
		private PropertyGetPosition m_Offset = GetPositionVector3.Create();

		public override string Title => $"Set {m_Shot}[Anchor] Offset = {m_Offset}";

		protected override Task Run(Args args)
		{
			ShotSystemAnchor shotSystem = GetShotSystem<ShotSystemAnchor>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Offset = m_Offset.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
