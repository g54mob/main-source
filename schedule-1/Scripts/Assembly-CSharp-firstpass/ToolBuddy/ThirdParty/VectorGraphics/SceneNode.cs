using System.Collections.Generic;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	public class SceneNode
	{
		private Matrix2D m_Transform;

		public List<SceneNode> Children { get; set; }

		public List<Shape> Shapes { get; set; }

		public Matrix2D Transform
		{
			get
			{
				return default(Matrix2D);
			}
			set
			{
			}
		}

		public SceneNode Clipper { get; set; }
	}
}
