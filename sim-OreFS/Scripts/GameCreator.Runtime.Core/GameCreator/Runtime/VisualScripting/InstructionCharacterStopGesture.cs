using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Stop Gestures")]
	[Description("Stops any animation Gestures playing on the Character")]
	[Category("Characters/Animation/Stop Gesture")]
	[Parameter("Character", "The character that plays animation Gestures")]
	[Parameter("Delay", "Amount of seconds to wait before the animation starts to blend out")]
	[Parameter("Transition", "The amount of seconds the animation takes to blend out")]
	[Keywords(new string[] { "Characters", "Animation", "Animate", "Gesture", "Play" })]
	[Image(typeof(IconCharacterGesture), ColorTheme.Type.TextLight, typeof(OverlayCross))]
	public class InstructionCharacterStopGesture : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[Space]
		[SerializeField]
		private PropertyGetDecimal m_Delay = GetDecimalConstantZero.Create;

		[SerializeField]
		private PropertyGetDecimal m_Transition = new PropertyGetDecimal(0.1f);

		public override string Title => $"Stop gestures on {m_Character}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			character.Gestures.Stop((float)m_Delay.Get(args), (float)m_Transition.Get(args));
			return Instruction.DefaultResult;
		}
	}
}
