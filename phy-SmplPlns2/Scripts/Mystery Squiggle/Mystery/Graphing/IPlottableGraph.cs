using UnityEngine;

namespace Mystery.Graphing
{
	public interface IPlottableGraph
	{
		IValueTransformer ValueTransformerX { get; }

		IValueTransformer ValueTransformerY { get; }

		IValueRange DefaultRangeX { get; }

		IValueRange DefaultRangeY { get; }

		IValueRange CreateRangeX();

		IValueRange CreateRangeY();

		void PlotGLLines();

		void PlotGLLines(float zoom, float pan);

		void PlotGLLines(float zoom, float pan, IValueRange rangeX, IValueRange rangeY);

		Vector2 GetTransformedPoint(object valueX, object valueY);

		Vector2 GetTransformedPoint(object valueX, object valueY, float zoom, float pan);

		Vector2 GetTransformedPoint(object valueX, object valueY, float zoom, float pan, IValueRange rangeX, IValueRange rangeY);

		void Clear();

		void ResetBounds();

		ILineGraphPoint[] ExportData();

		GraphPointSample GetYSampleAt(IValueRange rangeX, float xOffset);
	}
}
