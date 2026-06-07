using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Enable Head Bobbing")]
	[Category("Cameras/Shots/Head Bobbing/Enable Head Bobbing")]
	[Description("Toggles the active state of a Camera Shot's Head Bobbing system")]
	[Parameter("Active", "The next state")]
	[Keywords(new string[] { "Cameras", "Disable", "Activate", "Deactivate", "Bool", "Toggle", "Off", "On" })]
	public class InstructionShotHeadBobbingEnable : TInstructionShotHeadBobbing
	{
		[SerializeField]
		private PropertyGetBool m_Active = new PropertyGetBool(value: true);

		public override string Title => $"Set {m_Shot}[Head Bobbing] to {m_Active}";

		protected override Task Run(Args args)
		{
			ShotSystemHeadBobbing shotSystem = GetShotSystem<ShotSystemHeadBobbing>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.IsActive = m_Active.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
