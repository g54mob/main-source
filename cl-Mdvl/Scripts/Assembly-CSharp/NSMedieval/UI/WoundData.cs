using System.Collections.Generic;

namespace NSMedieval.UI
{
	public readonly struct WoundData
	{
		public string Name { get; }

		public string WoundSeverity { get; }

		public bool Tended { get; }

		public bool Bleeding { get; }

		public List<string> TooltipData { get; }

		public WoundData(string name, string woundSeverity, bool tended, bool bleeding, List<string> tooltipData)
		{
			Name = name;
			WoundSeverity = woundSeverity;
			Tended = tended;
			Bleeding = bleeding;
			TooltipData = tooltipData;
		}
	}
}
