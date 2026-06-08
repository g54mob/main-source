using System.Collections.Generic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace Rhizomatic
{
	public class ListLoader : MonoBehaviour
	{
		[SerializeField]
		private Transform container;

		[SerializeField]
		private ViewLoader viewLoader;

		public ViewLoader ViewLoader => null;

		public List<ListLoaderItem> items { get; }

		public void UpdateItems<T>(StateSelector<StateList<T>> newItems) where T : IViewable
		{
		}

		public void UpdateItems<T>(StateList<T> newItems) where T : IViewable
		{
		}

		public void UpdateItems<T>(IEnumerable<T> newItems) where T : IViewable
		{
		}

		public void Clear()
		{
		}

		private bool IsEqual(IViewable a, IViewable b)
		{
			return false;
		}

		private void Reset()
		{
		}
	}
}
