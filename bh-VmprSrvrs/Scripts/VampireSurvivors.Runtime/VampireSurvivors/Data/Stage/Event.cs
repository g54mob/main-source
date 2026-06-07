using System;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Stage
{
	[Serializable]
	public class Event
	{
		public string eventType { get; set; }

		public float delay { get; set; }

		public int repeat { get; set; }

		public float? chance { get; set; }

		public float? duration { get; set; }

		[Type(new Type[]
		{
			typeof(string),
			typeof(float)
		})]
		public int moreX { get; set; }

		[Type(new Type[]
		{
			typeof(string),
			typeof(float),
			typeof(string[])
		})]
		public object moreY { get; set; }

		public float moreZ { get; set; }

		public int minPlayersNeeded { get; set; }
	}
}
