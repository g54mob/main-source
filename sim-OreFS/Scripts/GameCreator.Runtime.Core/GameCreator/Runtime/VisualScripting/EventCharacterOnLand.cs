using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Land")]
	[Image(typeof(IconLand), ColorTheme.Type.Yellow)]
	[Category("Characters/Navigation/On Land")]
	[Description("Executed every time the character lands on the ground")]
	public class EventCharacterOnLand : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.EventLand += OnStep;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.EventLand -= OnStep;
		}

		private void OnStep(float velocity)
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character != null)
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
