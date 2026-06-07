using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Enable Head Leaning")]
	[Category("Cameras/Shots/Head Leaning/Enable Head Leaning")]
	[Description("Toggles the active state of a Camera Shot's Head Leaning system")]
	[Parameter("Active", "The next state")]
	[Keywords(new string[] { "Cameras", "Disable", "Activate", "Deactivate", "Bool", "Toggle", "Off", "On" })]
	public class InstructionShotHeadLeaningEnable : TInstructionShotHeadLeaning
	{
		[SerializeField]
		private PropertyGetBool m_Active = new PropertyGetBool(value: true);

		public override string Title => $"Set {m_Shot}[Head Leaning] to {m_Active}";

		protected override Task Run(Args args)
		{
			ShotSystemHeadLeaning shotSystem = GetShotSystem<ShotSystemHeadLeaning>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.IsActive = m_Active.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
