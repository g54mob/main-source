using UnityEngine;

namespace Mystery.Graphing
{
	public class StringLineGraphOverTime : LineGraphOverTime<string>
	{
		private static StringValueTransformer defaultRangeTransformer;

		public override ValueTransformer<string> ValueTransformerY
		{
			get
			{
				if (defaultRangeTransformer == null)
				{
					defaultRangeTransformer = new StringValueTransformer();
				}
				return defaultRangeTransformer;
			}
		}

		public override bool JoinPlottedLines => false;

		public override ValueRange<string> CreateRangeY()
		{
			return new StringRange();
		}

		protected override void PlotGLGraphLine(float transformedPointX, float transformedPointY, float pointX, float pointY, float totalDistanceX, float totalDistanceY)
		{
			GL.Vertex3(transformedPointX, 0f, 0f);
			GL.Vertex3(transformedPointX, 1f, 0f);
		}

		protected override void AddPointLineMesh(MeshBuilder meshBuilder, float transformedPointX, float transformedPointY, float pointX, float pointY, float totalDistanceX, float totalDistanceY)
		{
			meshBuilder.SetVertex(transformedPointX, 0f, 0f);
			meshBuilder.Push();
			meshBuilder.SetVertex(transformedPointX, 1f, 0f);
			meshBuilder.Push();
		}
	}
}
