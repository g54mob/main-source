using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Set Character Driver")]
	[Description("Changes the driver behavior of the Character")]
	[Category("Characters/Navigation/Set Character Driver")]
	[Parameter("Character", "The Character that changes its Driver behavior")]
	[Parameter("Driver", "The Driver behavior that decides how the Character moves")]
	[Keywords(new string[] { "Character", "Drive", "Controller", "Navmesh", "Agent", "Rigidbody" })]
	[Image(typeof(IconWheel), ColorTheme.Type.Green)]
	public class InstructionCharacterNavigationDriver : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[SerializeField]
		private UnitDriver m_Driver = new UnitDriver();

		public override string Title => $"Change Driver on {m_Character} to {m_Driver}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			if (m_Driver.Wrapper.GetType() != character.Driver.GetType())
			{
				character.Kernel.ChangeDriver(character, m_Driver.Wrapper);
			}
			return Instruction.DefaultResult;
		}
	}
}
