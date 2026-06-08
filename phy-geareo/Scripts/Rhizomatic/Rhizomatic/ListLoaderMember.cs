using System.Collections.Generic;
using Rhizomatic.MemberBinding;
using Rhizomatic.Reactive;

namespace Rhizomatic
{
	public class ListLoaderMember : Member<ListLoader>, ICrewRenderer
	{
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

		public void CrewRender(object value)
		{
		}
	}
}
