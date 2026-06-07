using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Revive")]
	[Image(typeof(IconSkull), ColorTheme.Type.Green)]
	[Category("Characters/On Revive")]
	[Description("Executed when a dead character revives")]
	[Keywords(new string[] { "Resurrect", "Respawn" })]
	public class EventCharacterOnRevive : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.EventRevive += OnRevive;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.EventRevive -= OnRevive;
		}

		private void OnRevive()
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character != null)
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
