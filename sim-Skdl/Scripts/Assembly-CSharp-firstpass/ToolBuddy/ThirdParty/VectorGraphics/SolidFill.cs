using UnityEngine;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	public class SolidFill : IFill
	{
		private float m_Opacity;

		public Color Color { get; set; }

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

		public FillMode Mode { get; set; }
	}
}
