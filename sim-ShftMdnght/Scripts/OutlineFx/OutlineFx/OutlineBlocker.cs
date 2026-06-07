using UnityEngine;

namespace OutlineFx
{
	[DefaultExecutionOrder(10000)]
	public class OutlineBlocker : Outline
	{
		private static Color s_color = new Color(0f, 0f, 0f, 0.02745098f);

		public override Color Color
		{
			get
			{
				return new Color(0f, 0f, 0f, 0.05490196f);
			}
			set
			{
			}
		}
	}
}
