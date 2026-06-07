using UnityEngine;

namespace Mystery.Graphing
{
	public interface IPlottableGraph
	{
		string YValueFormat { get; }

		object MinY { get; }

		object MaxY { get; }

		void PlotGLLines();

		void PlotGLLines(float zoom, float pan);

		void PlotGLLines(float zoom, float pan, object minY, object maxY);

		void Clear();

		void GetYSampleAt(float x, out string valueString, out Color valueColor);

		string GetYStringAt(float x);

		string GetYMinString();

		string GetYMidString();

		string GetYMidString(object min, object max);

		string GetYMaxString();

		string YToString(object yValue);

		IPlottableGraphPoint[] ExportData();

		object ParseY(string value, object fallback);
	}
}
