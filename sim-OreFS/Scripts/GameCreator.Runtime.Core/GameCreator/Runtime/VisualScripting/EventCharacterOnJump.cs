using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Jump")]
	[Image(typeof(IconCharacterJump), ColorTheme.Type.Yellow)]
	[Category("Characters/Navigation/On Jump")]
	[Description("Executed every time the character performs a jump")]
	public class EventCharacterOnJump : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.EventJump += OnJump;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.EventJump -= OnJump;
		}

		private void OnJump(float velocity)
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character != null)
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
