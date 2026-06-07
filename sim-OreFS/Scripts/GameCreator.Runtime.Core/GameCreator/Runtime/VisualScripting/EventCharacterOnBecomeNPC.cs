using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Become NPC")]
	[Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
	[Category("Characters/On Become NPC")]
	[Description("Executed when a character that is a Player becomes an NPC")]
	public class EventCharacterOnBecomeNPC : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.EventChangeToNPC += OnChangeToNPC;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.EventChangeToNPC -= OnChangeToNPC;
		}

		private void OnChangeToNPC()
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character != null)
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
