using UnityEngine;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	public class PatternFill : IFill
	{
		private float m_Opacity;

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

		public SceneNode Pattern { get; set; }

		public Rect Rect { get; set; }
	}
}
