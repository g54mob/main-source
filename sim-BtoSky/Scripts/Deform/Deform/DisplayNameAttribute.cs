using UnityEngine;

namespace Deform
{
	public class DisplayNameAttribute : PropertyAttribute
	{
		public readonly GUIContent GUIContent;

		public DisplayNameAttribute(string displayName, string tooltip = "")
		{
			GUIContent = new GUIContent(displayName, tooltip);
		}
	}
}
