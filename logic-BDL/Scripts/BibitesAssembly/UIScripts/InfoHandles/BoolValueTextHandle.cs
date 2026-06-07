using UnityEngine;

namespace UIScripts.InfoHandles
{
	public class BoolValueTextHandle : ValueTextHandle<bool>
	{
		public Color trueColor;

		public Color falseColor;

		public bool colorAnswers = true;

		public string trueText = "Yes";

		public string falseText = "No";

		protected override void OnValueChange()
		{
			text.text = (value ? trueText : falseText);
			if (colorAnswers)
			{
				text.color = (value ? trueColor : falseColor);
			}
		}
	}
}
