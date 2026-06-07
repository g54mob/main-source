using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Recover Ragdoll")]
	[Image(typeof(IconSkeleton), ColorTheme.Type.Green)]
	[Category("Characters/Ragdoll/On Recover Ragdoll")]
	[Description("Executed when the character recovers from the ragdoll mode")]
	public class EventCharacterOnRecoverRagdoll : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.Ragdoll.EventAfterStartRecover += OnRagdoll;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.Ragdoll.EventAfterStartRecover -= OnRagdoll;
		}

		private void OnRagdoll()
		{
			Character character = m_Character.Get<Character>(m_Trigger.gameObject);
			if (character != null)
			{
				m_Trigger.Execute(character.gameObject);
			}
		}
	}
}
