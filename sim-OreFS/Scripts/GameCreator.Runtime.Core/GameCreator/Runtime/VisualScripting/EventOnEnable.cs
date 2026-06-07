using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Enable")]
	[Category("Lifecycle/On Enable")]
	[Description("Executed when the game object it is attached to becomes enabled and active")]
	[Image(typeof(IconRadioOn), ColorTheme.Type.Yellow)]
	[Keywords(new string[] { "Active", "Disable", "Inactive" })]
	public class EventOnEnable : Event
	{
		protected internal override void OnEnable(Trigger trigger)
		{
			base.OnEnable(trigger);
			trigger.Execute(base.Self);
		}
	}
}
