using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Set Player Input")]
	[Description("Changes how the Player Character reacts to input commands")]
	[Category("Characters/Player/Set Player Input")]
	[Parameter("Character", "The Character that changes its Player Input behavior")]
	[Parameter("Input", "The new input method that the Character starts to listen")]
	[Keywords(new string[] { "Character", "Button", "Control", "Keyboard", "Mouse", "Gamepad", "Joystick" })]
	[Image(typeof(IconGamepadCross), ColorTheme.Type.Green)]
	public class InstructionCharacterPlayer : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private UnitPlayer m_Input = new UnitPlayer();

		public override string Title => $"Change Player Input on {m_Character} to {m_Input}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			character.Kernel.ChangePlayer(character, m_Input.Wrapper);
			return Instruction.DefaultResult;
		}
	}
}
