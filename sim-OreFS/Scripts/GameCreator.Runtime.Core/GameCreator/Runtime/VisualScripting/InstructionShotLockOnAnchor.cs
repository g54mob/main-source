using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Anchor")]
	[Category("Cameras/Shots/Lock On/Change Anchor")]
	[Description("Changes the targeted game object to Lock On")]
	[Parameter("Anchor", "The new target to Anchor onto")]
	[Keywords(new string[] { "Cameras", "Track", "View" })]
	public class InstructionShotLockOnAnchor : TInstructionShotLockOn
	{
		[SerializeField]
		private PropertyGetGameObject m_Anchor = GetGameObjectPlayer.Create();

		public override string Title => $"Set {m_Shot}[Lock On] Anchor = {m_Anchor}";

		protected override Task Run(Args args)
		{
			ShotSystemLockOn shotSystem = GetShotSystem<ShotSystemLockOn>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Anchor = m_Anchor.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
