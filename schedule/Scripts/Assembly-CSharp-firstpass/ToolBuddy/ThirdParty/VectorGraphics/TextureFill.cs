using UnityEngine;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	public class TextureFill : IFill
	{
		private float m_Opacity;

		public Texture2D Texture { get; set; }

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
	}
}
