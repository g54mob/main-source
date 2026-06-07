using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class TextAreaLabel : BaseTextArea
	{
		public TextAreaLabel()
		{
		}

		public TextAreaLabel(string text)
			: base(text)
		{
		}
	}
}
