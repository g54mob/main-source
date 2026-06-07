using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Become Invisible")]
	[Category("Lifecycle/On Become Invisible")]
	[Description("Executed when the game object it is attached to is no longer visible by any camera")]
	[Image(typeof(IconEye), ColorTheme.Type.Red)]
	[Keywords(new string[] { "Hide", "Disappear" })]
	public class EventOnBecomeInvisible : Event
	{
		protected internal override void OnBecameInvisible(Trigger trigger)
		{
			base.OnBecameInvisible(trigger);
			trigger.Execute(base.Self);
		}
	}
}
