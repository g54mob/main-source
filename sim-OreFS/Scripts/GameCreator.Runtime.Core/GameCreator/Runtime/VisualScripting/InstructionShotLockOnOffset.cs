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
	[Category("Cameras/Shots/Lock On/Change Offset")]
	[Description("Changes the offset position of the targeted object")]
	[Parameter("Offset", "The new offset in self local coordinates")]
	[Keywords(new string[] { "Cameras", "Track", "View" })]
	public class InstructionShotLockOnOffset : TInstructionShotLockOn
	{
		[SerializeField]
		private PropertyGetPosition m_Offset = GetPositionVector3.Create();

		public override string Title => $"Set {m_Shot}[Lock On] Offset = {m_Offset}";

		protected override Task Run(Args args)
		{
			ShotSystemLockOn shotSystem = GetShotSystem<ShotSystemLockOn>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Offset = m_Offset.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
