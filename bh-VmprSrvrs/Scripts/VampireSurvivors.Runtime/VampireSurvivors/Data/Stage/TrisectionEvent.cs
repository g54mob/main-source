using System;

namespace VampireSurvivors.Data.Stage
{
	[Serializable]
	public class TrisectionEvent : Event
	{
		public int weight;

		public int minLevel;

		public string localisationString { get; set; }
	}
}
