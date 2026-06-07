using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Player")]
	[Description("Changes the Character identified as the Player")]
	[Category("Characters/Player/Change Player")]
	[Parameter("Character", "The Character becomes the new Player character")]
	[Keywords(new string[] { "Character", "Is", "Control" })]
	[Image(typeof(IconPlayer), ColorTheme.Type.Green)]
	public class InstructionCharacterChangePlayer : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_NewPlayer = GetGameObjectPlayer.Create();

		public override string Title => $"Change Player to {m_NewPlayer}";

		protected override Task Run(Args args)
		{
			Character character = m_NewPlayer.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			Character character2 = ShortcutPlayer.Get<Character>();
			if (character2 != null)
			{
				character2.IsPlayer = false;
			}
			character.IsPlayer = true;
			return Instruction.DefaultResult;
		}
	}
}
