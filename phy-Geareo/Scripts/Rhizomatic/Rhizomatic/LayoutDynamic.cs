using System;
using System.Collections.Generic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace Rhizomatic
{
	public abstract class LayoutDynamic : MonoBehaviour
	{
		public ViewLoader viewLoader;

		public LayoutItemBuilder itemBuilder;

		public Action<LayoutItem> onItemCreated;

		protected Dictionary<int, LayoutItem> currentItems;

		protected abstract Transform GetContainer();

		protected abstract void BuildLayout();

		private void LateUpdate()
		{
		}

		private void UpdateLayout()
		{
		}

		public LayoutItem RequestItem(int index)
		{
			return null;
		}

		public void RemoveItem(int index)
		{
		}

		public virtual void Clear()
		{
		}
	}
}
