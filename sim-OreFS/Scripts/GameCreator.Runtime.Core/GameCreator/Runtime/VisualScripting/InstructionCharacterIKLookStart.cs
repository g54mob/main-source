using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Characters.IK;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Start Looking At")]
	[Description("Starts looking at a target using the Look At IK system")]
	[Category("Characters/IK/Start Looking At")]
	[Parameter("Character", "The character target")]
	[Parameter("Target", "The targeted Transform to look at")]
	[Parameter("Layer", "The priority of this IK over other Look At attempts")]
	[Keywords(new string[] { "Inverse", "Kinematics", "IK" })]
	[Image(typeof(IconEye), ColorTheme.Type.Blue)]
	public class InstructionCharacterIKLookStart : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectInstance.Create();

		[SerializeField]
		private int m_Priority = 1;

		public override string Title => $"{m_Character} look at {m_Target}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			Transform transform = m_Target.Get<Transform>(args);
			if (transform == null || !character.IK.HasRig<RigLookTo>())
			{
				return Instruction.DefaultResult;
			}
			LookToTransform target = new LookToTransform(m_Priority, transform, Vector3.zero);
			character.IK.GetRig<RigLookTo>().SetTarget(target);
			return Instruction.DefaultResult;
		}
	}
}
