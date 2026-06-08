using System;
using System.Collections.Generic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace Rhizomatic
{
	public class NavigatorView : View<NavigatorViewable>
	{
		public class PageItem
		{
			public Page page;

			public PageView view;

			public bool closed;
		}

		public ViewLoader viewLoader;

		public Transform container;

		public PageTransition defaultTransition;

		public Action<PageItem> onPageOpened;

		public Action onStackChanged;

		public List<PageItem> stack { get; }

		public List<PageItem> pages { get; }

		protected override void OnRender()
		{
		}

		private void UpdateOrder()
		{
		}
	}
}
