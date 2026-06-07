using System;

namespace Gh.Tk.Story.Logic
{
	[Serializable]
	public enum GuidePriority
	{
		Lower = -100,
		Low = -50,
		Default = 0,
		High = 50,
		Higher = 100,
		Important = 1000,
		Critical = 10000
	}
}
