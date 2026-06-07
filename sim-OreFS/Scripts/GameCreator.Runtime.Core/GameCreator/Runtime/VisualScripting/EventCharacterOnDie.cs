using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Die")]
	[Image(typeof(IconSkull), ColorTheme.Type.Red)]
	[Category("Characters/On Die")]
	[Description("Executed when the character dies")]
	public class EventCharacterOnDie : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.EventDie += OnDie;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.EventDie -= OnDie;
		}

		private void OnDie()
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character != null)
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
