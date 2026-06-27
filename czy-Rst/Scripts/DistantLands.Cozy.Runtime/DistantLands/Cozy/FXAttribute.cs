using UnityEngine;

namespace DistantLands.Cozy
{
	public class FXAttribute : PropertyAttribute
	{
		public string title;

		public FXAttribute()
		{
			title = "";
		}

		public FXAttribute(string _title)
		{
			title = _title;
		}
	}
}
