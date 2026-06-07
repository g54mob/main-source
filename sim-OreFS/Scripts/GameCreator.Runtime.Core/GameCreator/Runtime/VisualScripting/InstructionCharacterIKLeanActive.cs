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
	[Title("Active Lean IK")]
	[Description("Changes the active state of the Character Lean IK")]
	[Category("Characters/IK/Active Lean IK")]
	[Parameter("Character", "The character target")]
	[Parameter("Active", "Whether the IK system is active or not")]
	[Keywords(new string[] { "Inverse", "Kinematics", "IK" })]
	[Image(typeof(IconIK), ColorTheme.Type.Blue)]
	public class InstructionCharacterIKLeanActive : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetBool m_Active = GetBoolValue.Create(value: false);

		public override string Title => $"Lean IK of {m_Character} = {m_Active}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			if (character.IK.HasRig<RigLean>())
			{
				bool isActive = m_Active.Get(args);
				character.IK.GetRig<RigLean>().IsActive = isActive;
			}
			return Instruction.DefaultResult;
		}
	}
}
