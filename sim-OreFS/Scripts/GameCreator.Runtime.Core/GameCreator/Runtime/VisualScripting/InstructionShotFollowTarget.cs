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
	[Category("Cameras/Shots/Follow/Change Target")]
	[Description("Changes the targeted game object to Follow")]
	[Parameter("Follow", "The new target to follow")]
	[Keywords(new string[] { "Cameras", "Track", "View" })]
	public class InstructionShotFollowTarget : TInstructionShotFollow
	{
		[SerializeField]
		private PropertyGetGameObject m_Follow = GetGameObjectPlayer.Create();

		public override string Title => $"Set {m_Shot}[Follow] Follow = {m_Follow}";

		protected override Task Run(Args args)
		{
			ShotSystemFollow shotSystem = GetShotSystem<ShotSystemFollow>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Follow = m_Follow.Get<Transform>(args);
			return Instruction.DefaultResult;
		}
	}
}
