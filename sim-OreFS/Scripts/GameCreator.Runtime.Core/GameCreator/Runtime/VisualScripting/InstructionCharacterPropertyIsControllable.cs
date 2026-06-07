using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Is Controllable")]
	[Description("Changes whether the Character (Player) responds using input commands")]
	[Category("Characters/Properties/Is Controllable")]
	[Parameter("Character", "The character target")]
	[Parameter("Is Controllable", "Whether the character responds to input commands")]
	[Image(typeof(IconPlayer), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyIsControllable : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[Space]
		[SerializeField]
		private PropertyGetBool m_IsControllable = new PropertyGetBool(value: true);

		public override string Title => $"Is Controllable {m_Character} = {m_IsControllable}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			bool isControllable = m_IsControllable.Get(args);
			character.Player.IsControllable = isControllable;
			return Instruction.DefaultResult;
		}
	}
}
