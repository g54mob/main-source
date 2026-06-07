using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Become Player")]
	[Image(typeof(IconPlayer), ColorTheme.Type.Yellow)]
	[Category("Characters/On Become Player")]
	[Description("Executed when a character becomes the Player")]
	public class EventCharacterOnBecomePlayer : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.EventChangeToPlayer += OnChangeToPlayer;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.EventChangeToPlayer -= OnChangeToPlayer;
		}

		private void OnChangeToPlayer()
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character != null)
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
