using System.Collections;
using System.Collections.Generic;

namespace Mystery.Graphing
{
	public interface IGraphConsole : IEnumerable<IPlottableGraph>, IEnumerable
	{
		string Name { get; set; }

		IEnumerable<string> ValueNames { get; set; }

		float Height { get; set; }

		bool HeightIsChanging { get; set; }

		float Zoom { get; set; }

		float Pan { get; set; }

		bool HasYAxis { get; }

		bool MinLocked { get; set; }

		bool MaxLocked { get; set; }

		IValueRange RangeX { get; set; }

		IValueRange RangeY { get; set; }

		IValueTransformer TransformerX { get; }

		IValueTransformer TransformerY { get; }

		bool DisplayMidValue { get; }

		bool IsPanZooming { get; set; }

		void PlotGLLines();

		void GetSamplesAt(float x, List<GraphPointSample> samples);

		void Clear(bool resetRanges);

		string GetMaxXString();

		string GetMidXString();

		string GetMinXString();

		string GetMaxYString();

		string GetMidYString();

		string GetMinYString();

		object ParseX(string value, object fallback);

		object ParseY(string value, object fallback);

		void CleanUpBefore(float time, bool onlyCleanUpSharedTime);

		void CleanUpAfter(float time, bool onlyCleanUpSharedTime);

		void ResetBounds();

		List<ILineGraphPoint[]> ExportData();
	}
}
