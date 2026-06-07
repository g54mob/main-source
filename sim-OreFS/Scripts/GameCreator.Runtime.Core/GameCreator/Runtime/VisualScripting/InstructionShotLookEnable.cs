using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Enable Look")]
	[Category("Cameras/Shots/Look/Enable Look")]
	[Description("Toggles the active state of a Camera Shot's Look system")]
	[Parameter("Active", "The next state")]
	[Keywords(new string[] { "Cameras", "Disable", "Activate", "Deactivate", "Bool", "Toggle", "Off", "On" })]
	public class InstructionShotLookEnable : TInstructionShotLook
	{
		[SerializeField]
		private PropertyGetBool m_Active = new PropertyGetBool(value: true);

		public override string Title => $"Set {m_Shot}[Look] to {m_Active}";

		protected override Task Run(Args args)
		{
			ShotSystemLook shotSystem = GetShotSystem<ShotSystemLook>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.IsActive = m_Active.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
