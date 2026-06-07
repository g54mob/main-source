using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Can Interact")]
	[Description("Returns true if the Character has any interactive element available")]
	[Category("Characters/Interaction/Can Interact")]
	[Keywords(new string[] { "Character", "Button", "Pick", "Do", "Use", "Pull", "Press", "Push", "Talk" })]
	[Image(typeof(IconCharacterInteract), ColorTheme.Type.Green)]
	public class ConditionCharacterCanInteract : TConditionCharacter
	{
		protected override string Summary => $"can {m_Character} Interact";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return character.Interaction.CanInteract;
			}
			return false;
		}
	}
}
