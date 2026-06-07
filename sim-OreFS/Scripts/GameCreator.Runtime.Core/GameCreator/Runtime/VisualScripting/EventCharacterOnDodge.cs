using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Dodge")]
	[Image(typeof(IconCharacterDash), ColorTheme.Type.Green)]
	[Category("Characters/Combat/On Dodge")]
	[Description("Executed every time the character evades an attack")]
	public class EventCharacterOnDodge : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.Dash.EventDodge += OnDodge;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.Dash.EventDodge -= OnDodge;
		}

		private void OnDodge()
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character != null)
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
