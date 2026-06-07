using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Poise Change")]
	[Image(typeof(IconShieldOutline), ColorTheme.Type.Yellow)]
	[Category("Characters/Combat/On Poise Change")]
	[Description("Executed every time the character's combat Poise changes")]
	[Keywords(new string[] { "Resistance", "Combat" })]
	public class EventCharacterOnPoiseChange : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.Combat.Poise.EventChange -= OnChange;
			character.Combat.Poise.EventChange += OnChange;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.Combat.Poise.EventChange -= OnChange;
		}

		private void OnChange()
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character != null)
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
