using System.Collections;
using System.Collections.Generic;
using System.Text;

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

		bool MinLocked { get; }

		bool MaxLocked { get; }

		object MinLockValue { get; }

		object MaxLockValue { get; }

		bool DisplayMidValue { get; }

		bool IsPanZooming { get; set; }

		void LockMin();

		void LockMin(object value);

		void LockMax();

		void LockMax(object value);

		void UnlockMin();

		void UnlockMax();

		void PlotGLLines();

		void BuildRTFSampleAt(float x, StringBuilder strBuilder, ref float labelWidth);

		void Clear();

		string GetYMaxString();

		string GetYMidString();

		string GetYMinString();

		object ParseY(string value, object fallback);

		void CleanUpHistory(float beforeTime);

		List<IPlottableGraphPoint[]> ExportData();
	}
}
