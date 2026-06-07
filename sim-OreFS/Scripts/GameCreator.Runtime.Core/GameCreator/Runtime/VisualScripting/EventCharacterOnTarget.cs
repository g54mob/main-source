using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Target Change")]
	[Image(typeof(IconBullsEye), ColorTheme.Type.Yellow)]
	[Category("Characters/Combat/On Target Change")]
	[Description("Executed every time the character's combat Target changes")]
	[Keywords(new string[] { "Focus", "Combat", "Aim" })]
	public class EventCharacterOnTarget : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.Combat.Targets.EventChangeTarget -= OnChangeTarget;
			character.Combat.Targets.EventChangeTarget += OnChangeTarget;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.Combat.Targets.EventChangeTarget -= OnChangeTarget;
		}

		private void OnChangeTarget(GameObject newTarget)
		{
			m_Trigger.Execute(newTarget);
		}
	}
}
