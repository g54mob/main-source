using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Poise Break")]
	[Image(typeof(IconShieldOutline), ColorTheme.Type.Red, typeof(OverlayBolt))]
	[Category("Characters/Combat/On Poise Break")]
	[Description("Executed when a character's Poise is broken")]
	[Keywords(new string[] { "Resistance", "Combat" })]
	public class EventCharacterOnPoiseBreak : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.Combat.Poise.EventPoiseBreak -= OnBreak;
			character.Combat.Poise.EventPoiseBreak += OnBreak;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.Combat.Poise.EventPoiseBreak -= OnBreak;
		}

		private void OnBreak()
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character != null)
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
