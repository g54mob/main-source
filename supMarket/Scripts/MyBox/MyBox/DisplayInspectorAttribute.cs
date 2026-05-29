using UnityEngine;

namespace MyBox
{
	public class DisplayInspectorAttribute : PropertyAttribute
	{
		public readonly bool DisplayScript;

		public DisplayInspectorAttribute(bool displayScriptField = true)
		{
		}
	}
}
