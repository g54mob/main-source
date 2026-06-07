using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change State Weight")]
	[Description("Changes the weight of the State over time at the specified layer")]
	[Category("Characters/Animation/Change State Weight")]
	[Parameter("Character", "The character that plays the animation state")]
	[Parameter("Layer", "Slot number in which the animation state is allocated")]
	[Parameter("Weight", "The targeted opacity of the animation")]
	[Parameter("Transition", "The duration of the transition, in seconds")]
	[Keywords(new string[] { "Characters", "Animation", "Blend", "State", "Opacity" })]
	[Image(typeof(IconCharacterState), ColorTheme.Type.Yellow)]
	public class InstructionCharacterStateWeight : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		[Space]
		[SerializeField]
		private PropertyGetInteger m_Layer = new PropertyGetInteger(1);

		[SerializeField]
		private PropertyGetDecimal m_Weight = GetDecimalDecimal.Create(1f);

		[SerializeField]
		private PropertyGetDecimal m_Transition = GetDecimalConstantOne.Create;

		public override string Title => $"Change {m_Character} State weight to {m_Weight}";

		protected override Task Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return Instruction.DefaultResult;
			}
			int layer = (int)m_Layer.Get(args);
			float weight = (float)m_Weight.Get(args);
			float transition = (float)m_Transition.Get(args);
			character.States.ChangeWeight(layer, weight, transition);
			return Instruction.DefaultResult;
		}
	}
}
