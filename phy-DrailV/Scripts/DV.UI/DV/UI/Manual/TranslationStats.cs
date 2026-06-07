using Newtonsoft.Json;
using UnityEngine;

namespace DV.UI.Manual
{
	public class TranslationStats
	{
		[JsonProperty]
		public int revID;

		[JsonProperty]
		public int total;

		[JsonProperty]
		public int translated;

		[JsonProperty]
		public int outdated;

		public int Percentage
		{
			get
			{
				if (total > 0)
				{
					return Mathf.RoundToInt((float)translated / (float)total * 100f);
				}
				return 0;
			}
		}
	}
}
