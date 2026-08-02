using Rhizomatic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class BoardViewable : Viewable
	{
		public State<string> title;

		public State<bool> collapsed;

		public StateSelector<bool> notCollapsed;

		public Vector3 position;

		public Page page;

		public void Collapse()
		{
		}

		public void Close()
		{
		}
	}
}
