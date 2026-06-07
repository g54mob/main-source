using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Axonometry")]
	[Description("Changes the Character's Axonometry value")]
	[Category("Characters/Properties/Axonometry")]
	[Parameter("Axonometry", "The new Axonometry value")]
	[Keywords(new string[] { "Isometric", "Side", "Scroll" })]
	[Image(typeof(IconIsometric), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyAxonometry : TInstructionCharacterProperty
	{
		[SerializeField]
		private Axonometry m_Axonometry = new Axonometry();

		public override string Title => $"Axonometry of {m_Character} = {m_Axonometry}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			character.Driver.Axonometry = m_Axonometry.Clone() as Axonometry;
			character.Facing.Axonometry = m_Axonometry.Clone() as Axonometry;
			return Instruction.DefaultResult;
		}
	}
}
