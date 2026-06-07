using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Enter State")]
	[Description("Makes a Character start an animation State")]
	[Category("Characters/Animation/Enter State")]
	[Parameter("Character", "The character that plays the animation state")]
	[Parameter("State", "The animation data necessary to play a state")]
	[Parameter("Layer", "Slot number in which the animation state is allocated")]
	[Parameter("Blend Mode", "Additively adds the new animation on top of the rest or overrides any lower layer animations")]
	[Parameter("Delay", "Amount of seconds to wait before the animation starts to play")]
	[Parameter("Speed", "Speed coefficient at which the animation plays")]
	[Parameter("Weight", "The opacity of the animation that plays. Between 0 and 1")]
	[Parameter("Transition", "The amount of seconds the animation takes to blend in")]
	[Keywords(new string[] { "Characters", "Animation", "Animate", "State", "Play" })]
	[Image(typeof(IconCharacterState), ColorTheme.Type.Green)]
	public class InstructionCharacterEnterState : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[Space]
		[SerializeField]
		private StateData m_State = new StateData(StateData.StateType.State);

		[SerializeField]
		private PropertyGetInteger m_Layer = new PropertyGetInteger(1);

		[SerializeField]
		private BlendMode m_BlendMode;

		[Space]
		[SerializeField]
		private float m_Delay;

		[SerializeField]
		private float m_Speed = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_Weight = 1f;

		[SerializeField]
		private float m_Transition = 0.1f;

		public override string Title => $"State {m_State} on {m_Character} in Layer {m_Layer}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			if (!m_State.IsValid(character))
			{
				return Instruction.DefaultResult;
			}
			ConfigState config = new ConfigState(m_Delay, m_Speed, m_Weight, m_Transition, 0f);
			int layer = (int)m_Layer.Get(args);
			character.States.SetState(m_State, layer, m_BlendMode, config);
			return Instruction.DefaultResult;
		}
	}
}
