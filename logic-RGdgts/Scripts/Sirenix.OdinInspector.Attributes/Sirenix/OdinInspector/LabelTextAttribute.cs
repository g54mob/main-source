using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	public class LabelTextAttribute : Attribute
	{
		public string Text;

		public bool NicifyText;

		public LabelTextAttribute(string text)
		{
		}

		public LabelTextAttribute(string text, bool nicifyText)
		{
		}
	}
}
