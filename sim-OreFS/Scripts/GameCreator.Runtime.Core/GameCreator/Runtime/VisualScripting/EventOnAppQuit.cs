using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On App Quit")]
	[Category("Lifecycle/On App Quit")]
	[Description("Executed right before exiting the standalone application")]
	[Image(typeof(IconExit), ColorTheme.Type.Red)]
	[Keywords(new string[] { "Exit", "Close" })]
	public class EventOnAppQuit : Event
	{
		protected internal override void OnApplicationQuit(Trigger trigger)
		{
			base.OnApplicationQuit(trigger);
			trigger.Execute(base.Self);
		}
	}
}
