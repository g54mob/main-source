using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Can Jump")]
	[Description("Changes whether the Character is allowed to jump or not")]
	[Category("Characters/Properties/Can Jump")]
	[Parameter("Character", "The character target")]
	[Parameter("Can Jump", "Whether the character is allowed to jump or not")]
	[Keywords(new string[] { "Hop", "Elevate" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyCanJump : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[Space]
		[SerializeField]
		private PropertyGetBool m_CanJump = new PropertyGetBool(value: true);

		public override string Title => $"Can Jump {m_Character} = {m_CanJump}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			bool canJump = m_CanJump.Get(args);
			character.Motion.CanJump = canJump;
			return Instruction.DefaultResult;
		}
	}
}
