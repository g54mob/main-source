using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Stop State")]
	[Description("Stops an animation State from a Character")]
	[Category("Characters/Animation/Stop State")]
	[Parameter("Character", "The character that stops its animation State")]
	[Parameter("Layer", "Slot number from which the state is removed")]
	[Parameter("Delay", "Amount of seconds to wait before the animation stops playing")]
	[Parameter("Transition", "The amount of seconds the animation takes to blend out")]
	[Keywords(new string[] { "Characters", "Animation", "Animate", "State", "Exit", "Stop" })]
	[Image(typeof(IconCharacterState), ColorTheme.Type.TextLight, typeof(OverlayCross))]
	public class InstructionCharacterStopState : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[Space]
		[SerializeField]
		private PropertyGetInteger m_Layer = new PropertyGetInteger(1);

		[Space]
		[SerializeField]
		private PropertyGetDecimal m_Delay = GetDecimalConstantZero.Create;

		[SerializeField]
		private PropertyGetDecimal m_Transition = new PropertyGetDecimal(0.1f);

		public override string Title => $"Stop {m_Character} State in Layer {m_Layer}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			int layer = (int)m_Layer.Get(args);
			character.States.Stop(layer, (float)m_Delay.Get(args), (float)m_Transition.Get(args));
			return Instruction.DefaultResult;
		}
	}
}
