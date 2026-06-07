using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Fixed Update")]
	[Category("Lifecycle/On Fixed Update")]
	[Description("Executed every fixed frame as long as the game object is enabled (physics loop")]
	[Image(typeof(IconLoop), ColorTheme.Type.Green)]
	[Keywords(new string[] { "Loop", "Tick", "Continuous", "Physics", "Rigidbody" })]
	public class EventOnFixedUpdate : Event
	{
		protected internal override void OnFixedUpdate(Trigger trigger)
		{
			base.OnFixedUpdate(trigger);
			trigger.Execute(base.Self);
		}
	}
}
