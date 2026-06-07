using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Set Poise")]
	[Description("Changes the current Poise value of a Character")]
	[Category("Characters/Combat/Poise/Set Poise")]
	[Parameter("Character", "The Character that attempts to change its Poise value")]
	[Parameter("Poise", "The new Poise value")]
	[Keywords(new string[] { "Character", "Combat" })]
	[Image(typeof(IconShieldOutline), ColorTheme.Type.Yellow)]
	public class InstructionCharacterSetPoise : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private PropertyGetDecimal m_Poise = GetDecimalDecimal.Create(1f);

		public override string Title => $"Set {m_Character} Poise = {m_Poise}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			float value = (float)m_Poise.Get(args);
			character.Combat.Poise.Set(value);
			return Instruction.DefaultResult;
		}
	}
}
