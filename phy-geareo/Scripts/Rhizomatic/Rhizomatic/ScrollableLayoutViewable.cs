using System;
using Rhizomatic.Reactive;

namespace Rhizomatic
{
	public class ScrollableLayoutViewable : Viewable
	{
		public State<LayoutItemBuilder> itemBuilder;

		public State<int> rangeMin;

		public State<int> rangeMax;

		public State<float> startPadding;

		public State<float> endPadding;

		public State<bool> willRefresh;

		public Action onReachStart;

		public Action onReachEnd;

		public Action onEnd;

		public Action onRefresh;

		public Action clear;
	}
}
