using UnityEngine;

namespace Rhizomatic.Reactive
{
	public class ParentViewLoader : ViewLoader
	{
		public Transform parent;

		public bool fitRect;

		public ViewLoader viewLoader;

		protected override bool DoCanOpen(IViewable viewable)
		{
			return false;
		}

		protected override View DoOpen(IViewable viewable)
		{
			return null;
		}

		protected override void DoClose(View view)
		{
		}

		private void Reset()
		{
		}
	}
}
