using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Mannequin Rotation")]
	[Description("Changes the local rotation of the Mannequin object within the Character")]
	[Category("Characters/Properties/Mannequin Rotation")]
	[Parameter("Character", "The character target")]
	[Parameter("Rotation", "The Local Rotation of the Mannequin")]
	[Keywords(new string[] { "Location", "Model", "Local" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class InstructionCharacterPropertyMannequinRotation : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[Space]
		[SerializeField]
		private PropertyGetRotation m_Rotation = new PropertyGetRotation();

		public override string Title => $"Mannequin Rotation {m_Character} = {m_Rotation}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			Quaternion rotation = m_Rotation.Get(args);
			character.Animim.Rotation = rotation;
			character.Animim.ApplyMannequinRotation();
			return Instruction.DefaultResult;
		}
	}
}
