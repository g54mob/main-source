using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Invincibility Change")]
	[Image(typeof(IconDiamondSolid), ColorTheme.Type.Yellow)]
	[Category("Characters/Combat/On Invincibility Change")]
	[Description("Executed when the character's Invincibility changes")]
	public class EventCharacterInvincibility : TEventCharacter
	{
		private enum Mode
		{
			OnChange = 0,
			OnBecomeInvincible = 1,
			OnBecomeVincible = 2
		}

		[SerializeField]
		private Mode m_Mode;

		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.Combat.Invincibility.EventChange += OnInvincibility;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.Combat.Invincibility.EventChange -= OnInvincibility;
		}

		private void OnInvincibility(bool isInvincible)
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character == null)
			{
				return;
			}
			switch (m_Mode)
			{
			case Mode.OnChange:
				m_Trigger.Execute(character.gameObject);
				break;
			case Mode.OnBecomeInvincible:
				if (isInvincible)
				{
					m_Trigger.Execute(character.gameObject);
				}
				break;
			case Mode.OnBecomeVincible:
				if (!isInvincible)
				{
					m_Trigger.Execute(character.gameObject);
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}
