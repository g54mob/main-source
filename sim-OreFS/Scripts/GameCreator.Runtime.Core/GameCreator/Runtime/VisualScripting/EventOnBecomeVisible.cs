using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Become Visible")]
	[Category("Lifecycle/On Become Visible")]
	[Description("Executed when the game object it is attached to becomes visible to any camera")]
	[Image(typeof(IconEye), ColorTheme.Type.Yellow)]
	[Keywords(new string[] { "Show", "Render", "Appear" })]
	public class EventOnBecomeVisible : Event
	{
		protected internal override void OnBecameVisible(Trigger trigger)
		{
			base.OnBecameVisible(trigger);
			trigger.Execute(base.Self);
		}
	}
}
