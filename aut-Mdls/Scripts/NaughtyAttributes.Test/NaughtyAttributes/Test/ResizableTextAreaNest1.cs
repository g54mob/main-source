using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class ResizableTextAreaNest1
	{
		[ResizableTextArea]
		public string text1;

		public ResizableTextAreaNest2 nest2;
	}
}
