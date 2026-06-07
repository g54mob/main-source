using UIScripts.InfoHandles;

namespace Utility
{
	public interface IDataPointStream
	{
		string groupTitle { get; }

		string groupDesc { get; }

		int nStream { get; }

		bool isInfinite { get; }

		int nScales { get; }

		FloatValueFormat formating { get; }

		IDataPoint this[int depth, int i] { get; }

		bool DepthHasData(int depth);

		int DataAtDepth(int depth);

		int DataSizeAtDepth(int depth);

		void Log();

		DataStreamDescription[] GetStreamsDescriptions();

		DataStreamDescription GetStreamDescription(int i);

		IDataPoint PeekCurrentDataPoint();
	}
}
