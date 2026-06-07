using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Focus")]
	[Image(typeof(IconCharacterInteract), ColorTheme.Type.Green, typeof(OverlayDot))]
	[Category("Interactive/On Focus")]
	[Description("Executed when the Character focuses on this Interactive object")]
	public class EventCharacterOnFocusInteractive : TEventCharacter
	{
		protected internal override void OnAwake(Trigger trigger)
		{
			base.OnAwake(trigger);
			trigger.RequireInteractionTracker();
		}

		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.Interaction.EventFocus += OnFocus;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.Interaction.EventFocus -= OnFocus;
		}

		private void OnFocus(Character character, IInteractive interactive)
		{
			if (base.IsActive && !(character == null) && character.Interaction.Target != null && !(character.Interaction.Target.Instance != m_Trigger.gameObject))
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
