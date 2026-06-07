using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On App Pause")]
	[Category("Lifecycle/On App Pause")]
	[Description("Executed when the standalone application loses its focus")]
	[Image(typeof(IconSquareOutline), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	[Keywords(new string[] { "Background", "Suspend" })]
	public class EventOnAppPause : Event
	{
		protected internal override void OnApplicationPause(Trigger trigger, bool hasFocus)
		{
			base.OnApplicationPause(trigger, hasFocus);
			trigger.Execute(base.Self);
		}
	}
}
