using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Defense Change")]
	[Image(typeof(IconShieldSolid), ColorTheme.Type.Blue)]
	[Category("Characters/Combat/On Defense Change")]
	[Description("Executed when the Character's defense changes")]
	[Keywords(new string[] { "Defend", "Block", "Combat" })]
	public class EventCharacterOnDefenseChange : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.Combat.EventDefenseChange -= OnChangeDefense;
			character.Combat.EventDefenseChange += OnChangeDefense;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.Combat.EventDefenseChange -= OnChangeDefense;
		}

		private void OnChangeDefense()
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character != null)
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
