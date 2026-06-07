using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Set Character Rotation")]
	[Description("Changes the rotation behavior of the Character")]
	[Category("Characters/Navigation/Set Character Rotation")]
	[Parameter("Character", "The Character that changes its Rotation behavior")]
	[Parameter("Rotation", "The Rotation behavior that decides where the Character faces")]
	[Keywords(new string[] { "Character", "Face", "Look", "Direction", "Pivot", "Lock" })]
	[Image(typeof(IconRotationYaw), ColorTheme.Type.Green)]
	public class InstructionCharacterNavigationFacing : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private UnitFacing m_Rotation = new UnitFacing();

		public override string Title => $"Change Rotation on {m_Character} to {m_Rotation}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			if (m_Rotation.Wrapper.GetType() != character.Facing.GetType())
			{
				character.Kernel.ChangeFacing(character, m_Rotation.Wrapper);
			}
			return Instruction.DefaultResult;
		}
	}
}
