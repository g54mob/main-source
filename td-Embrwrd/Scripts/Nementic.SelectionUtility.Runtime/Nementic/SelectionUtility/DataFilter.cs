using UnityEngine;

namespace Nementic.SelectionUtility
{
	public class DataFilter
	{
		private string shortName;

		private FilterFunction filter;

		public static readonly DataFilter PassThrough;

		public string ShortName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public FilterFunction Filter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataFilter(string name, FilterFunction filter)
		{
		}

		internal bool IsAllowed(GameObject go)
		{
			return false;
		}
	}
}
