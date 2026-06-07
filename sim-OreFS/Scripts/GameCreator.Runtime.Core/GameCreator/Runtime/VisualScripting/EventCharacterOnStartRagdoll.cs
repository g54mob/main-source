using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Start Ragdoll")]
	[Image(typeof(IconSkeleton), ColorTheme.Type.Blue)]
	[Category("Characters/Ragdoll/On Start Ragdoll")]
	[Description("Executed when the character enters the ragdoll mode")]
	public class EventCharacterOnStartRagdoll : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.Ragdoll.EventAfterStartRagdoll += OnRagdoll;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.Ragdoll.EventAfterStartRagdoll -= OnRagdoll;
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
