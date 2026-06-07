using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Blur")]
	[Image(typeof(IconCharacterInteract), ColorTheme.Type.Red, typeof(OverlayDot))]
	[Category("Interactive/On Blur")]
	[Description("Executed when the Character loses focus on this Interactive object")]
	public class EventCharacterOnBlurInteractive : TEventCharacter
	{
		protected internal override void OnAwake(Trigger trigger)
		{
			base.OnAwake(trigger);
			trigger.RequireInteractionTracker();
		}

		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.Interaction.EventBlur += OnBlur;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.Interaction.EventBlur -= OnBlur;
		}

		private void OnBlur(Character character, IInteractive interactive)
		{
			if (base.IsActive && !(character == null) && character.Interaction.Target != null)
			{
				int instanceID = character.Interaction.Target.InstanceID;
				int instanceID2 = m_Trigger.gameObject.GetInstanceID();
				if (instanceID == instanceID2)
				{
					m_Trigger.Execute(character.gameObject);
				}
			}
		}
	}
}
