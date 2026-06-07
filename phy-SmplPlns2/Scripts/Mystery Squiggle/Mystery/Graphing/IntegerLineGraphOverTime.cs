using UnityEngine;

namespace Mystery.Graphing
{
	public class IntegerLineGraphOverTime : LineGraphOverTime<long>
	{
		private static LongValueTransformer defaultRangeTransformer;

		private Vector2 previousTransformedPoint = new Vector2(float.PositiveInfinity, float.PositiveInfinity);

		private float previousX = float.PositiveInfinity;

		public override ValueTransformer<long> ValueTransformerY
		{
			get
			{
				if (defaultRangeTransformer == null)
				{
					defaultRangeTransformer = new LongValueTransformer();
				}
				return defaultRangeTransformer;
			}
		}

		public override ValueRange<long> CreateRangeY()
		{
			return new LongRange();
		}

		protected override void BeginMesh()
		{
			previousX = float.PositiveInfinity;
		}

		protected override void PlotGLGraphLine(float transformedPointX, float transformedPointY, float pointX, float pointY, float totalDistanceX, float totalDistanceY)
		{
			if (previousX < pointX)
			{
				float x = Mathf.Lerp(previousTransformedPoint.x, transformedPointX, 0.5f);
				GL.Vertex3(x, previousTransformedPoint.y, 0f);
				GL.Vertex3(x, previousTransformedPoint.y, 0f);
				GL.Vertex3(x, transformedPointY, 0f);
				GL.Vertex3(x, transformedPointY, 0f);
			}
			GL.Vertex3(transformedPointX, transformedPointY, 0f);
			GL.Vertex3(transformedPointX, transformedPointY, 0f);
			previousTransformedPoint = new Vector2(transformedPointX, transformedPointY);
			previousX = pointX;
		}

		protected override void AddPointLineMesh(MeshBuilder meshBuilder, float transformedPointX, float transformedPointY, float pointX, float pointY, float totalDistanceX, float totalDistanceY)
		{
			if (previousX < pointX)
			{
				float x = Mathf.Lerp(previousTransformedPoint.x, transformedPointX, 0.5f);
				meshBuilder.SetVertex(x, previousTransformedPoint.y, 0f);
				meshBuilder.Push();
				meshBuilder.SetVertex(x, previousTransformedPoint.y, 0f);
				meshBuilder.Push();
				meshBuilder.SetVertex(x, transformedPointY, 0f);
				meshBuilder.Push();
				meshBuilder.SetVertex(x, transformedPointY, 0f);
				meshBuilder.Push();
			}
			meshBuilder.SetVertex(transformedPointX, transformedPointY, 0f);
			meshBuilder.Push();
			meshBuilder.SetVertex(transformedPointX, transformedPointY, 0f);
			meshBuilder.Push();
			previousTransformedPoint = new Vector2(transformedPointX, transformedPointY);
			previousX = pointX;
		}
	}
}
