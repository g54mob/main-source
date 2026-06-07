using System;

namespace Gh.Tk
{
	public class SystemStatusItemWithButton : SystemStatusItem
	{
		private Action _button;

		public string ButtonLabel { get; set; }

		public Action ClickAction => null;

		public SystemStatusItemWithButton(string codexId, Func<string> getTitle, Func<SystemStatus.PerformanceState> getState, string category, string buttonLabel, Action buttonAction)
		{
		}
	}
}
