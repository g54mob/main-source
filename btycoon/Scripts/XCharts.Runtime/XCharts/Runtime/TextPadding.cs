using System;

namespace XCharts.Runtime
{
	[Serializable]
	public class TextPadding : Padding
	{
		public TextPadding()
		{
		}

		public TextPadding(float top, float right, float bottom, float left)
		{
			SetPadding(top, right, bottom, left);
		}
	}
}
