using System;
using System.Collections.Generic;
using Rhizomatic.Reactive;

namespace Rhizomatic
{
	public class RecyclerLayoutViewable : Viewable
	{
		public State<LayoutItemBuilder> itemBuilder;

		public State<int> count;

		public Action clear;

		public static RecyclerLayoutViewable FromStateSelector<T>(StateSelector<List<T>> list) where T : IViewable
		{
			return null;
		}
	}
}
