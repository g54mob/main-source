using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Has State in Layer")]
	[Description("Returns true if the Character has a State running at the specified layer index")]
	[Category("Characters/Animation/Has State in Layer")]
	[Parameter("Layer", "The layer in which the Character may have a State running")]
	[Keywords(new string[] { "Characters", "Animation", "Animate", "State", "Play" })]
	[Image(typeof(IconCharacterState), ColorTheme.Type.Red)]
	public class ConditionCharacterStateLayer : TConditionCharacter
	{
		[SerializeField]
		private PropertyGetInteger m_Layer = new PropertyGetInteger(1);

		protected override string Summary => $"has {m_Character} State at {m_Layer}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			int layer = (int)m_Layer.Get(args);
			bool flag = character.States.IsAvailable(layer);
			if (character != null)
			{
				return !flag;
			}
			return false;
		}
	}
}
