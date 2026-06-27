using UnityEngine;

namespace DistantLands.Cozy
{
	public class SetHeightAttribute : PropertyAttribute
	{
		public int lines;

		public SetHeightAttribute()
		{
			lines = 1;
		}

		public SetHeightAttribute(int _lines)
		{
			lines = _lines;
		}
	}
}
