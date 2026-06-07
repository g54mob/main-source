using System;
using Gh.Tk.Story.Config;

namespace Gh.Tk.Story.GameModifiers
{
	[Serializable]
	public class DayCurveOverrideConfig
	{
		public string key;

		public DayCurveTypes type;

		[DropDownChoice(typeof(StoryHelper), "GetNamedDayCurves")]
		public string dayCurve;
	}
}
