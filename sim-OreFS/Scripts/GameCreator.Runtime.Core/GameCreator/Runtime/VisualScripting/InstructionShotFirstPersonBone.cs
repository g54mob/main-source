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
	[Title("Change Bone")]
	[Category("Cameras/Shots/First Person/Change Bone")]
	[Description("Changes the Bone mount of the targeted object")]
	[Parameter("Bone", "The new bone of the character")]
	public class InstructionShotFirstPersonBone : TInstructionShotFirstPerson
	{
		[SerializeField]
		private Bone m_Bone = new Bone(HumanBodyBones.Head);

		public override string Title => $"Set {m_Shot} = {m_Bone}";

		protected override Task Run(Args args)
		{
			ShotSystemFirstPerson shotSystem = GetShotSystem<ShotSystemFirstPerson>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			shotSystem.Bone = m_Bone;
			return Instruction.DefaultResult;
		}
	}
}
