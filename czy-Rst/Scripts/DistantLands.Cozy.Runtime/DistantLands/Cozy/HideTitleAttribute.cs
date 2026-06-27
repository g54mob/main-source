using UnityEngine;

namespace DistantLands.Cozy
{
	public class HideTitleAttribute : PropertyAttribute
	{
		public string title;

		public float lines;

		public HideTitleAttribute()
		{
			title = "";
			lines = 1f;
		}

		public HideTitleAttribute(float _lines)
		{
			title = "";
			lines = _lines;
		}

		public HideTitleAttribute(string _title, float _lines)
		{
			title = _title;
			lines = _lines;
		}
	}
}
