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
	[Title("Change Target")]
	[Category("Cameras/Shots/First Person/Change Target")]
	[Description("Changes the targeted game object to view from")]
	[Parameter("Target", "The new target")]
	[Keywords(new string[] { "Cameras", "Track", "View" })]
	public class InstructionShotFirstPersonTarget : TInstructionShotFirstPerson
	{
		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectPlayer.Create();

		public override string Title => $"Set {m_Shot}[First Person] Target = {m_Target}";

		protected override Task Run(Args args)
		{
			ShotSystemFirstPerson shotSystem = GetShotSystem<ShotSystemFirstPerson>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Target = m_Target.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
