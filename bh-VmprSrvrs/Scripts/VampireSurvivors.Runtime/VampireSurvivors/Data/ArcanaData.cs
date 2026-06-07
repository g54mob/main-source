using System;
using System.Collections.Generic;

namespace VampireSurvivors.Data
{
	[Serializable]
	public class ArcanaData
	{
		public int arcanaType { get; set; }

		public string name { get; set; }

		public string description { get; set; }

		public List<object> weapons { get; set; }

		public List<object> items { get; set; }

		public string texture { get; set; }

		public string frameName { get; set; }

		public bool enabled { get; set; }

		public bool unlocked { get; set; }

		public bool major { get; set; }

		public bool hidden { get; set; }

		public bool alwaysHidden { get; set; }

		public int stars { get; set; }

		public ContentGroupType contentGroup { get; set; }

		public string GetLocalizedNameTerm(ArcanaType t)
		{
			return null;
		}

		public string GetLocalizedDescriptionTerm(ArcanaType t)
		{
			return null;
		}

		public string GetLocalPrefix(ArcanaType t)
		{
			return null;
		}
	}
}
