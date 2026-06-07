using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Can Collide")]
	[Description("Changes whether the Character can collide with other objects or not")]
	[Category("Characters/Properties/Can Collide")]
	[Parameter("Character", "The character target")]
	[Parameter("Can Collide", "Whether the character collides with other physic objects")]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyCollision : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[Space]
		[SerializeField]
		private PropertyGetBool m_CanCollide = new PropertyGetBool(value: true);

		public override string Title => $"Can Collide {m_Character} = {m_CanCollide}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			bool collision = m_CanCollide.Get(args);
			character.Driver.Collision = collision;
			return Instruction.DefaultResult;
		}
	}
}
