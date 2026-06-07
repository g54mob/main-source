using UnityEngine;

namespace UIScripts.InfoHandles
{
	public struct WedgeInfo
	{
		public string label;

		public Color color;

		public WedgeInfo(string newLabel, Color newColor)
		{
			label = newLabel;
			color = newColor;
		}
	}
}
