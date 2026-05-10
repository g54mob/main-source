using UnityEngine;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	public class GradientFill : IFill
	{
		private float m_Opacity;

		public GradientFillType Type { get; set; }

		public GradientStop[] Stops { get; set; }

		public FillMode Mode { get; set; }

		public float Opacity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AddressMode Addressing { get; set; }

		public Vector2 RadialFocus { get; set; }
	}
}
