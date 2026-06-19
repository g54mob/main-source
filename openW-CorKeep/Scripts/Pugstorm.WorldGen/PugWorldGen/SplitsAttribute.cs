using UnityEngine;

namespace PugWorldGen
{
	public class SplitsAttribute : PropertyAttribute
	{
		public int splitCount;

		public string splitCountField;

		public SplitsAttribute(string splitCountField)
		{
			splitCount = -1;
			this.splitCountField = splitCountField;
		}

		public SplitsAttribute(int splitCount)
		{
			this.splitCount = splitCount;
		}

		public SplitsAttribute()
		{
			splitCount = 4;
			splitCountField = "";
		}
	}
}
