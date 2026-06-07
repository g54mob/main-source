using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On App Focus")]
	[Category("Lifecycle/On App Focus")]
	[Description("Executed when the standalone application is brought to focus")]
	[Image(typeof(IconSquareOutline), ColorTheme.Type.Green, typeof(OverlayArrowLeft))]
	[Keywords(new string[] { "Foreground" })]
	public class EventOnAppFocus : Event
	{
		protected internal override void OnApplicationFocus(Trigger trigger, bool hasFocus)
		{
			base.OnApplicationFocus(trigger, hasFocus);
			trigger.Execute(base.Self);
		}
	}
}
