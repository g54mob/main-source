using UnityEngine;

namespace DistantLands.Cozy
{
	public class CozySearchable : PropertyAttribute
	{
		public string[] keywords;

		public bool deepSearch;

		public CozySearchable(params string[] keywords)
		{
			this.keywords = keywords;
			deepSearch = false;
		}

		public CozySearchable(bool deepSearch, params string[] keywords)
		{
			this.keywords = keywords;
			this.deepSearch = deepSearch;
		}
	}
}
