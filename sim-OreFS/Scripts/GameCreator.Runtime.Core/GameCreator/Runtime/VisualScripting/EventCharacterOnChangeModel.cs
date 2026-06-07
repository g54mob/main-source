using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Change Model")]
	[Image(typeof(IconCharacter), ColorTheme.Type.Blue)]
	[Category("Characters/On Change Model")]
	[Description("Executed when a character changes its model")]
	public class EventCharacterOnChangeModel : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.EventAfterChangeModel += OnChangeModel;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.EventAfterChangeModel -= OnChangeModel;
		}

		private void OnChangeModel()
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character != null)
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
