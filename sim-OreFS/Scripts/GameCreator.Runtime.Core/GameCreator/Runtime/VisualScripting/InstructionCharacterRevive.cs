using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Revive Character")]
	[Description("Changes the state of the Character to alive")]
	[Category("Characters/Properties/Revive Character")]
	[Parameter("Character", "The character target")]
	[Keywords(new string[] { "Respawn", "Alive", "Resurrect" })]
	[Image(typeof(IconSkull), ColorTheme.Type.Green)]
	public class InstructionCharacterRevive : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public override string Title => $"Revive {m_Character}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			character.IsDead = false;
			return Instruction.DefaultResult;
		}
	}
}
