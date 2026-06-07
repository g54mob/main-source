using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Dash")]
	[Image(typeof(IconCharacterDash), ColorTheme.Type.Yellow)]
	[Category("Characters/Navigation/On Dash")]
	[Description("Executed every time the character performs a dash")]
	public class EventCharacterOnDash : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.Dash.EventDashStart += OnDash;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.Dash.EventDashStart -= OnDash;
		}

		private void OnDash()
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character != null)
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
