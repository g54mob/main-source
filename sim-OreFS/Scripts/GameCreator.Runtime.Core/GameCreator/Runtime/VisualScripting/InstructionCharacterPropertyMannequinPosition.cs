using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Mannequin Position")]
	[Description("Changes the local position of the Mannequin object within the Character")]
	[Category("Characters/Properties/Mannequin Position")]
	[Parameter("Character", "The character target")]
	[Parameter("Position", "The Local Position of the Mannequin")]
	[Keywords(new string[] { "Location", "Model", "Local", "Change", "Set", "Root" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyMannequinPosition : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[Space]
		[SerializeField]
		private PropertyGetPosition m_Position = new PropertyGetPosition();

		public override string Title => $"Mannequin Position {m_Character} = {m_Position}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			Vector3 position = m_Position.Get(args);
			character.Animim.Position = position;
			character.Animim.ApplyMannequinPosition();
			return Instruction.DefaultResult;
		}
	}
}
