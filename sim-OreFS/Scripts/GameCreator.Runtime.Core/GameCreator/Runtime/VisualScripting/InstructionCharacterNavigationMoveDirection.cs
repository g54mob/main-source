using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Move Direction")]
	[Description("Attempts to move the Character towards the specified direction")]
	[Category("Characters/Navigation/Move Direction")]
	[Parameter("Direction", "The the direction to move towards")]
	[Parameter("Priority", "Indicates the priority of this command against others")]
	[Keywords(new string[] { "Constant", "Walk", "Run", "To", "Vector" })]
	[Image(typeof(IconCharacterWalk), ColorTheme.Type.Blue, typeof(OverlayArrowRight))]
	public class InstructionCharacterNavigationMoveDirection : TInstructionCharacterNavigation
	{
		[SerializeField]
		private PropertyGetDirection m_Direction = GetDirectionVector.Create();

		[SerializeField]
		private PropertyGetInteger m_Priority = GetDecimalInteger.Create(0);

		public override string Title => $"Move {m_Character} to {m_Direction}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			Vector3 velocity = m_Direction.Get(args);
			int priority = (int)m_Priority.Get(args);
			character.Motion.MoveToDirection(velocity, Space.World, priority);
			return Instruction.DefaultResult;
		}
	}
}
