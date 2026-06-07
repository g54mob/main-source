namespace ToolBuddy.ThirdParty.VectorGraphics
{
	public class Shape
	{
		private Matrix2D m_FillTransform;

		public BezierContour[] Contours { get; set; }

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

		public PathProperties PathProps { get; set; }

		public bool IsConvex { get; set; }
	}
}
