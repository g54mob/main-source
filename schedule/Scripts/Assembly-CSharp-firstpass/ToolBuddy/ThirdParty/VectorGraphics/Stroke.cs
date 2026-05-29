using UnityEngine;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	public class Stroke
	{
		private Matrix2D m_FillTransform;

		public Color Color
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public IFill Fill { get; set; }

		public Matrix2D FillTransform
		{
			get
			{
				return default(Matrix2D);
			}
			set
			{
			}
		}

		public float HalfThickness { get; set; }

		public float[] Pattern { get; set; }

		public float PatternOffset { get; set; }

		public float TippedCornerLimit { get; set; }
	}
}
