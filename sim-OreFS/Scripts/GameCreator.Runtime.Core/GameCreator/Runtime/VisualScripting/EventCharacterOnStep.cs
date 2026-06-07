using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Step")]
	[Image(typeof(IconFootprint), ColorTheme.Type.Yellow)]
	[Category("Characters/Navigation/On Step")]
	[Description("Executed every time the character takes a step")]
	[Keywords(new string[] { "Footstep", "Foot", "Feet", "Ground" })]
	public class EventCharacterOnStep : TEventCharacter
	{
		protected override void WhenEnabled(Trigger trigger, Character character)
		{
			character.Footsteps.EventStep += OnStep;
		}

		protected override void WhenDisabled(Trigger trigger, Character character)
		{
			character.Footsteps.EventStep -= OnStep;
		}

		private void OnStep(Transform foot)
		{
			m_Trigger.Execute(foot.gameObject);
		}
	}
}
