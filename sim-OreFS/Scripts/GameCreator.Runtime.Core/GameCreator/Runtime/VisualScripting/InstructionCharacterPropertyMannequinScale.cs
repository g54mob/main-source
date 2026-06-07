using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Mannequin Scale")]
	[Description("Changes the local scale of the Mannequin object within the Character")]
	[Category("Characters/Properties/Mannequin Scale")]
	[Parameter("Character", "The character target")]
	[Parameter("Scale", "The Local Scale of the Mannequin")]
	[Keywords(new string[] { "Location", "Model", "Local" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyMannequinScale : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[Space]
		[SerializeField]
		private PropertyGetScale m_Scale = new PropertyGetScale();

		public override string Title => $"Mannequin Scale {m_Character} = {m_Scale}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			Vector3 scale = m_Scale.Get(args);
			character.Animim.Scale = scale;
			character.Animim.ApplyMannequinScale();
			return Instruction.DefaultResult;
		}
	}
}
