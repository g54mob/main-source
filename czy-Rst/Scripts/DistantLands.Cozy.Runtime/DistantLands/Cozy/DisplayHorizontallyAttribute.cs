using UnityEngine;

namespace DistantLands.Cozy
{
	public class DisplayHorizontallyAttribute : PropertyAttribute
	{
		public string key;

		public DisplayHorizontallyAttribute(string _Key)
		{
			key = _Key;
		}
	}
}
